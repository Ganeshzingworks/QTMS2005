using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessFacade;
using BusinessFacade.Transactions;
using System.Threading;
using System.Globalization;
using QTMS.Tools;

namespace QTMS.Transactions
{
    public partial class FrmPMModification : System.Windows.Forms.Form
    {
        public FrmPMModification()
        {

            InitializeComponent();
        }
        #region Variables

        double noofpallets;
        double NoOfShippers;
        Comman_Class Comman_Class_obj = new Comman_Class();
        PMTransaction_Class PMTransaction_Class_obj = new PMTransaction_Class();
        LineMaster_Class LineMaster_Class_Obj = new LineMaster_Class();
        PMMaster_Class PMMaster_Class_obj = new PMMaster_Class();
        //private bool DoTesting=true;
        #endregion

        private static FrmPMModification frmPMModification_Obj = null;
        public static FrmPMModification GetInstance()
        {
            if (frmPMModification_Obj == null)
            {
                frmPMModification_Obj = new Transactions.FrmPMModification();
            }
            return frmPMModification_Obj;
        }

        private void FrmPMModification_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            Bind_Details();
            //BtnReset_Click(sender, e);
            CmbDetails.Focus();
        }
        private void FrmPMModification_Resize(object sender, EventArgs e)
        {
            //if (this.WindowState == FormWindowState.Maximized)
            //{
            //    this.WindowState = FormWindowState.Normal;
            //    this.Dock = DockStyle.Fill;
            //}
        }

        public void Bind_Details()
        {
            CmbDetails.BeginUpdate();
            try
            {
                DataSet ds = new DataSet();
                DataRow dr;
                ds = PMTransaction_Class_obj.Select_ModificationPMDetails();
                PMTransaction_Class_obj.pmsuppliercocid = Convert.ToInt64(ds.Tables[0].Rows[0]["PMSupplierCOCID"]);
                dr = ds.Tables[0].NewRow();
                dr["Details"] = "--Select--";
                dr["PMTransID"] = "0";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                CmbDetails.DataSource = ds.Tables[0];
                CmbDetails.DisplayMember = "Details";
                CmbDetails.ValueMember = "PMTransID";
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

        public void resetall()
        {

            txtNoofBatches.Text = "";
            txtControltype.Text = "";
            DtpAcceptedDate.Value = Comman_Class_obj.Select_ServerDate();
            DtpInspDate.Value = Comman_Class_obj.Select_ServerDate();
            DtpReceiptDate.Value = Comman_Class_obj.Select_ServerDate();
            cmbType.SelectedIndex = 0;

            txtQtySampled.Text = "";
            txtNoOfPallets.Text = "";
            txtNoOfShippers.Text = "";
            lblDisplay.Text = "";

            txtSpecificationNo.Text = "";
            txtChallanNo.Text = "";
            txtMRR.Text = "";
            cmbPMReception.SelectedIndex = 0;
            cmbSupplierReportReceived.SelectedIndex = 0;
            cmbType.SelectedIndex = 0;

            cmbDefectObserved.SelectedIndex = 0;
            txtNoOfDefect.Enabled = false;
            txtNoOfDefect.Text = "";
            dgDefect.Rows.Clear();
            dgDefect.Columns["ActionTaken"].DataPropertyName = "--Select--";

            txtQuantity.Text = "";
            lblPeriodicDone.Text = "";
            dgAllTests.Rows.Clear();
            dgAllTestsP.Rows.Clear();
            //tabcontrol always show Systematic tab
            tabControl1.SelectedIndex = 0;

            //RdoLaunch.Checked = true;
            for (int i = 0; i < chkRejectComments.Items.Count; i++)
            {
                if (chkRejectComments.GetItemChecked(i) == true)
                {
                    chkRejectComments.SetItemChecked(i, false);
                }
            }
            RdoAccept.Checked = true;
            RdoAWD.Checked = false;
            RdoTreatment.Checked = false;
            RdoSendBackToSupplier.Checked = false;

            CmbDetails.Focus();
        }

        private void CmbDetails_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                resetall();
                if (CmbDetails.SelectedValue != null && CmbDetails.SelectedValue.ToString() != "")
                {
                    PMTransaction_Class_obj.pmtransid = Convert.ToInt64(CmbDetails.SelectedValue);

                    DataSet ds = new DataSet();
                    DataSet dsDefect = new DataSet();
                    ds = PMTransaction_Class_obj.Select_ModificationPMDetails_Details();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        PMMaster_Class_obj.pmcodeid = Convert.ToInt64(ds.Tables[0].Rows[0]["PMCodeID"]);//Use this datset assign PMCodeID for use of to show test for specific PMcode ID
                        PMTransaction_Class_obj.pmcodeid = Convert.ToInt64(ds.Tables[0].Rows[0]["PMCodeID"]);//This for PM Transaction Class
                        PMTransaction_Class_obj.pmchangeid = Convert.ToInt64(ds.Tables[0].Rows[0]["PMChangeID"]);
                        PMTransaction_Class_obj.pmfamilyid = Convert.ToInt64(ds.Tables[0].Rows[0]["PMFamilyID"]);
                        PMTransaction_Class_obj.transcoc = Convert.ToString(ds.Tables[0].Rows[0]["TransCOC"]);
                        PMTransaction_Class_obj.analysisdone = Convert.ToInt16(ds.Tables[0].Rows[0]["AnalysisDone"]);
                        PMTransaction_Class_obj.pmtestid = Convert.ToInt64(ds.Tables[0].Rows[0]["PMTestID"]);
                        PMTransaction_Class_obj.cocapplicable = Convert.ToString(ds.Tables[0].Rows[0]["COCApplicable"]);

                        ////modified for PM code and supplier newly created then show Yes in first reception

                        //PMTransaction_Class_obj.pmsupplcocid = Convert.ToInt64(ds.Tables[0].Rows[0]["PMSupplierCOCID"]);
                        //PMTransaction_Class_obj.pmsupplcocid = Convert.ToInt64(CmbDetails.SelectedValue);
                        //DataSet ds1 = new DataSet();
                        //ds1 = PMTransaction_Class_obj.Check_PMTransaction();
                        //if (ds1.Tables[0].Rows.Count > 0)
                        //{
                        //    cmbPMReception.SelectedIndex = 0;
                        //    cmbPMReception.Enabled = true;
                        //}
                        //else
                        //{
                        //    cmbPMReception.SelectedIndex = 2;
                        //    cmbPMReception.Enabled = false;
                        //}

                        DtpAcceptedDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["AcceptedDate"]);
                        DtpReceiptDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["ReceiptDate"]);
                        DtpInspDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["InspDate"]);
                        txtNoofBatches.Text = Convert.ToString(ds.Tables[0].Rows[0]["NoOFBatches"]);
                        txtControltype.Text = Convert.ToString(ds.Tables[0].Rows[0]["ControlType"]);
                        PMTransaction_Class_obj.type = txtControltype.Text.Trim();

                        if (Convert.ToString(ds.Tables[0].Rows[0]["LaunchRegular"]) == "L")
                            cmbType.SelectedIndex = 1;
                        else if (Convert.ToString(ds.Tables[0].Rows[0]["LaunchRegular"]) == "R")
                            cmbType.SelectedIndex = 2;
                        else if (Convert.ToString(ds.Tables[0].Rows[0]["LaunchRegular"]) == "")
                            cmbType.SelectedIndex = 0;

                        txtQtySampled.Text = Convert.ToString(ds.Tables[0].Rows[0]["QuantitySampled"]);
                        txtNoOfPallets.Text = Convert.ToString(ds.Tables[0].Rows[0]["NoOfPallets"]);
                        txtNoOfShippers.Text = Convert.ToString(ds.Tables[0].Rows[0]["NoOfShippers"]);

                        txtSpecificationNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["SpecificationNo"]);
                        txtChallanNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["ChallanNo"]);
                        txtMRR.Text = Convert.ToString(ds.Tables[0].Rows[0]["MRR"]);

                        if (Convert.ToString(ds.Tables[0].Rows[0]["SRR"]) == "N")
                            cmbSupplierReportReceived.SelectedIndex = 1;
                        else if (Convert.ToString(ds.Tables[0].Rows[0]["SRR"]) == "Y")
                            cmbSupplierReportReceived.SelectedIndex = 2;
                        else if (Convert.ToString(ds.Tables[0].Rows[0]["SRR"]) == "")
                            cmbSupplierReportReceived.SelectedIndex = 0;

                        if (Convert.ToString(ds.Tables[0].Rows[0]["FirstPMReception"]) == "N")
                            cmbPMReception.SelectedIndex = 1;
                        else if (Convert.ToString(ds.Tables[0].Rows[0]["FirstPMReception"]) == "Y")
                            cmbPMReception.SelectedIndex = 2;
                        else if (Convert.ToString(ds.Tables[0].Rows[0]["FirstPMReception"]) == "")
                            cmbPMReception.SelectedIndex = 0;

                        if (Convert.ToString(ds.Tables[0].Rows[0]["DefectObserved"]) == "N")
                            cmbDefectObserved.SelectedIndex = 1;
                        else if (Convert.ToString(ds.Tables[0].Rows[0]["DefectObserved"]) == "Y")
                            cmbDefectObserved.SelectedIndex = 2;
                        else if (Convert.ToString(ds.Tables[0].Rows[0]["DefectObserved"]) == "")
                            cmbDefectObserved.SelectedIndex = 0;

                        txtNoOfDefect.Text = Convert.ToString(ds.Tables[0].Rows[0]["NoOfDefect"]);

                        dsDefect = PMTransaction_Class_obj.Select_PMDefect_PMTestID();
                        if (dsDefect.Tables[0].Rows.Count > 0)
                        {
                            for (int d = 0; d < dsDefect.Tables[0].Rows.Count; d++)
                            {
                                dgDefect.Rows.Add();
                                //dgDefect.Rows[d].ReadOnly = true;
                                dgDefect.Rows[d].DefaultCellStyle.BackColor = Color.FromKnownColor(KnownColor.LightGray);

                                dgDefect["PMDefectID", d].Value = Convert.ToString(dsDefect.Tables[0].Rows[d]["PMDefectID"]);
                                dgDefect["DefectComment", d].Value = Convert.ToString(dsDefect.Tables[0].Rows[d]["DefectComment"]);
                                dgDefect["DefectQuantity", d].Value = Convert.ToString(dsDefect.Tables[0].Rows[d]["DefectQuantity"]);

                                if (Convert.ToString(dsDefect.Tables[0].Rows[d]["ActionTaken"]) == "Q")
                                    dgDefect["ActionTaken", d].Value = "Line Stopped : Requested QC to check";
                                else if (Convert.ToString(dsDefect.Tables[0].Rows[d]["ActionTaken"]) == "R")
                                    dgDefect["ActionTaken", d].Value = "Line Stopped : Material returned to store";
                                else if (Convert.ToString(dsDefect.Tables[0].Rows[d]["ActionTaken"]) == "S")
                                    dgDefect["ActionTaken", d].Value = "On Line Sorting";
                                else if (Convert.ToString(dsDefect.Tables[0].Rows[d]["ActionTaken"]) == "A")
                                    dgDefect["ActionTaken", d].Value = "On Line Adjustment";
                                else if (Convert.ToString(dsDefect.Tables[0].Rows[d]["ActionTaken"]) == "O")
                                    dgDefect["ActionTaken", d].Value = "Other";

                                if (Convert.ToString(dsDefect.Tables[0].Rows[d]["QualityDecision"]).ToUpper() == "ZD".ToUpper())
                                    dgDefect["QualityDecision", d].Value = "ZD";
                                if (Convert.ToString(dsDefect.Tables[0].Rows[d]["QualityDecision"]).ToUpper() == "ZD Nomenclature".ToUpper())
                                    dgDefect["QualityDecision", d].Value = "ZD";
                                else if (Convert.ToString(dsDefect.Tables[0].Rows[d]["QualityDecision"]).ToUpper() == "Critical".ToUpper())
                                    dgDefect["QualityDecision", d].Value = "Critical";
                                else if (Convert.ToString(dsDefect.Tables[0].Rows[d]["QualityDecision"]).ToUpper() == "Major".ToUpper())
                                    dgDefect["QualityDecision", d].Value = "Major";
                                else if (Convert.ToString(dsDefect.Tables[0].Rows[d]["QualityDecision"]).ToUpper() == "Minor".ToUpper())
                                    dgDefect["QualityDecision", d].Value = "Minor";
                                else if (Convert.ToString(dsDefect.Tables[0].Rows[d]["QualityDecision"]).ToUpper() == "Other".ToUpper())
                                    dgDefect["QualityDecision", d].Value = "Other";

                                //dgDefect["QualityDecision", d].Value = Convert.ToString(dsDefect.Tables[0].Rows[d]["QualityDecision"]);
                                // In New change the status is showing from suppliernote is it close or Open?
                                DataSet dsDefStatus = PMTransaction_Class_obj.Select_tblSupplierCorrectiveNote_DefectStatus();
                                int icount = dsDefStatus.Tables[0].Rows.Count;
                                if (dsDefStatus.Tables[0].Rows.Count > 0)
                                {
                                    //if (dsDefStatus.Tables[0].Rows[icount - 1][0].ToString() == "O")
                                    //    dgDefect["DefectStatus", d].Value = "Open";
                                    if (dsDefStatus.Tables[0].Rows[icount - 1][0].ToString() == "C")
                                        dgDefect["DefectStatus", d].Value = "Close";
                                }
                                else
                                {
                                    if (Convert.ToString(dsDefect.Tables[0].Rows[d]["DefectStatus"]) == "O")
                                        dgDefect["DefectStatus", d].Value = "Open";
                                    else if (Convert.ToString(dsDefect.Tables[0].Rows[d]["DefectStatus"]) == "C")
                                        dgDefect["DefectStatus", d].Value = "Close";
                                }
                                //

                            }
                        }

                        txtQuantity.Text = Convert.ToString(ds.Tables[0].Rows[0]["Quantity"]);

                        if (Convert.ToChar(ds.Tables[0].Rows[0]["ActualStatus"]) == 'A')
                            RdoAccept.Checked = true;
                        else if (Convert.ToChar(ds.Tables[0].Rows[0]["ActualStatus"]) == 'R')
                            RdoReject.Checked = true;
                        else if (Convert.ToChar(ds.Tables[0].Rows[0]["ActualStatus"]) == 'D')
                            RdoAWD.Checked = true;
                        else if (Convert.ToChar(ds.Tables[0].Rows[0]["ActualStatus"]) == 'T')
                            RdoTreatment.Checked = true;
                        else if (Convert.ToChar(ds.Tables[0].Rows[0]["ActualStatus"]) == 'S')
                            RdoSendBackToSupplier.Checked = true;

                        if (Convert.ToString(ds.Tables[0].Rows[0]["RejectComment"]) == "BOR")
                            chkRejectComments.SetItemChecked(0, true);
                        else if (Convert.ToString(ds.Tables[0].Rows[0]["RejectComment"]) == "BOF")
                            chkRejectComments.SetItemChecked(1, true);
                        else if (Convert.ToString(ds.Tables[0].Rows[0]["RejectComment"]) == "COC")
                            chkRejectComments.SetItemChecked(2, true);

                        if (txtQuantity.Text != "")
                        {
                            if (PMTransaction_Class_obj.analysisdone == 0)
                            {
                                MessageBox.Show("Sampling and Analysis is not applicable for this Lot..!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                            tabControl1.SelectedIndex = 0;

                            PMTransaction_Class_obj.frequency = "Systematic";
                            FillTestGrid();
                            dgAllTests.Focus();
                        }
                    }
                    else
                    {
                        PMTransaction_Class_obj.pmfamilyid = 0;
                    }

                    if (PMTransaction_Class_obj.analysisdone == 1)
                    {
                        SamplingGroupBox.Enabled = true;
                        tabControl1.Enabled = true;
                        //SamplingGroupBox.Visible = true;
                        //tabControl1.Visible = true;
                    }
                    else
                    {
                        SamplingGroupBox.Enabled = false;
                        tabControl1.Enabled = false;
                        //SamplingGroupBox.Visible = false;
                        //tabControl1.Visible = false;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNoOfShippers_Leave(object sender, EventArgs e)
        {

            if (txtQtySampled.Text == "")
            {
                MessageBox.Show("Please Enter the Sampling Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lblDisplay.Visible = false;
                txtQtySampled.Focus();

                return;
            }
            if (txtNoOfPallets.Text == "")
            {
                MessageBox.Show("Please Enter the Number of Pallets", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNoOfPallets.Focus();
                return;
            }
            if (txtNoOfShippers.Text == "")
            {
                MessageBox.Show("Please Enter the Number of Shippers", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lblDisplay.Visible = false;
                txtNoOfShippers.Focus();
                return;
            }

            lblDisplay.Visible = true;
            //double real = Math.Sqrt(Convert.ToDouble(txtNoOfShippers.Text.ToString()));

            //noofshippers = Convert.ToInt32(Math.Ceiling(real));           

            //NoOfSegments = Convert.ToDouble(txtNoOfShippers.Text.ToString());
            double real = Math.Sqrt(Convert.ToDouble(txtNoOfShippers.Text.ToString()));
            double fraction = real - Math.Floor(real);
            if (fraction <= 0.5)
            {
                NoOfShippers = Convert.ToDouble(Math.Floor(real));
            }
            else
            {
                NoOfShippers = Convert.ToDouble(Math.Ceiling(real));

            }

            lblDisplay.Text = txtQtySampled.Text.ToString() + " " + "Samples are Collected From " + NoOfShippers.ToString() + " " + "Shippers" + " " + "of" + " " + noofpallets.ToString() + " " + "Palettes";
        }

        private void txtQtySampled_Leave(object sender, EventArgs e)
        {

            if (txtQtySampled.Text == "")
            {
                MessageBox.Show("Please Enter The Quantity Sampled Field", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            lblDisplay.Text = "";

            if (txtNoOfShippers.Text != "")
            {
                //txtNoOfShippers_Leave(sender, e);
                lblDisplay.Text = txtQtySampled.Text.ToString() + " " + "Samples are Collected From " + NoOfShippers.ToString() + " " + "Shippers" + " " + "of" + " " + noofpallets.ToString() + " " + "Palettes";
            }
        }

        private void txtNoofPalettes_Leave(object sender, EventArgs e)
        {
            if (txtQtySampled.Text == "")
            {
                MessageBox.Show("Please Enter the Sampling Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lblDisplay.Visible = false;
                txtQtySampled.Focus();

                return;
            }
            if (txtNoOfPallets.Text != "")
            {
                // NoOfSegments = Convert.ToDouble(txtNoOfPallets.Text.ToString());
                double real = Math.Sqrt(Convert.ToDouble(txtNoOfPallets.Text.ToString()));
                double fraction = real - Math.Floor(real);
                if (fraction <= 0.5)
                {
                    noofpallets = Convert.ToDouble(Math.Floor(real));
                }
                else
                {
                    noofpallets = Convert.ToDouble(Math.Ceiling(real));
                }
            }

            if (txtNoOfShippers.Text != "")
            {
                txtNoOfShippers_Leave(sender, e);
            }
        }

        private void RdoReject_CheckedChanged(object sender, EventArgs e)
        {
            if (RdoReject.Checked == true)
            {
                RdoAWD.Visible = true;
                RdoTreatment.Visible = true;
                chkRejectComments.Visible = true;
                RdoSendBackToSupplier.Visible = true;
                if (PMTransaction_Class_obj.cocapplicable != null && PMTransaction_Class_obj.cocapplicable.ToUpper() == "Y".ToUpper())
                {
                    for (int i = 0; i < chkRejectComments.Items.Count; i++)
                    {
                        if (chkRejectComments.Items[i].ToString() == "COC")
                            chkRejectComments.SetItemChecked(i, true);
                    }
                }
                else
                {
                    for (int i = 0; i < chkRejectComments.Items.Count; i++)
                    {
                        if (chkRejectComments.Items[i].ToString() == "Blocked on Receipt")
                            chkRejectComments.SetItemChecked(i, true);
                    }
                }
            }
        }

        private void RdoAccept_CheckedChanged(object sender, EventArgs e)
        {
            RdoAWD.Visible = false;
            RdoTreatment.Visible = false;
            chkRejectComments.Visible = false;
            RdoSendBackToSupplier.Visible = false;
            for (int i = 0; i < chkRejectComments.Items.Count; i++)
            {
                if (chkRejectComments.GetItemChecked(i) == true)
                {
                    chkRejectComments.SetItemChecked(i, false);
                }
            }
            for (int d = 0; d < dgDefect.Rows.Count; d++)
            {
                if (!dgDefect.Rows[d].IsNewRow)
                {
                    dgDefect["DefectStatus", d].Value = "Close";
                }
            }
        }

        private void RdoSendBackToSupplier_CheckedChanged(object sender, EventArgs e)
        {
            if (RdoSendBackToSupplier.Checked == true)
            {
                RdoAWD.Visible = true;
                RdoTreatment.Visible = true;
                chkRejectComments.Visible = true;
                RdoSendBackToSupplier.Visible = true;
            }
            for (int i = 0; i < chkRejectComments.Items.Count; i++)
            {
                if (chkRejectComments.GetItemChecked(i) == true)
                {
                    chkRejectComments.SetItemChecked(i, false);
                }
            }
        }

        private void RdoAWD_CheckedChanged(object sender, EventArgs e)
        {
            if (RdoAWD.Checked == true)
            {
                RdoAWD.Visible = true;
                RdoTreatment.Visible = true;
                chkRejectComments.Visible = true;
                RdoSendBackToSupplier.Visible = true;
            }
        }

        private void RdoTreatment_CheckedChanged(object sender, EventArgs e)
        {
            if (RdoTreatment.Checked == true)
            {
                RdoAWD.Visible = true;
                RdoTreatment.Visible = true;
                chkRejectComments.Visible = true;
                RdoSendBackToSupplier.Visible = true;
            }
        }

        private void chkRejectComments_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            //Can select only one item
            if (e.NewValue == CheckState.Checked)
            {
                for (int i = 0; i < chkRejectComments.Items.Count; i++)
                {
                    if (e.Index != i)
                    {
                        chkRejectComments.SetItemChecked(i, false);
                    }
                }
            }
        }

        private void chkRejectComments_Click(object sender, EventArgs e)
        {
            if (chkRejectComments.GetItemCheckState(chkRejectComments.SelectedIndex) == CheckState.Unchecked)
            {
                chkRejectComments.SetItemCheckState(chkRejectComments.SelectedIndex, CheckState.Checked);
            }
            else if (chkRejectComments.GetItemCheckState(chkRejectComments.SelectedIndex) == CheckState.Checked)
            {
                chkRejectComments.SetItemCheckState(chkRejectComments.SelectedIndex, CheckState.Unchecked);
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                dgAllTests.Rows.Clear();
                dgAllTestsP.Rows.Clear();

                if (txtQuantity.Text == "")
                {
                    MessageBox.Show("Please Enter Quantity", "Warning");
                    txtQuantity.Focus();
                    return;
                }

                if (PMTransaction_Class_obj.analysisdone == 0)
                {
                    MessageBox.Show("Sampling and Analysis is not applicable for this Lot..!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                tabControl1.SelectedIndex = 0;

                PMTransaction_Class_obj.frequency = "Systematic";
                FillTestGrid();
                dgAllTests.Focus();
            }
            else if (Convert.ToInt32(e.KeyChar) != 8)
            {
                if ((Convert.ToInt32(e.KeyChar) >= 48) && (Convert.ToInt32(e.KeyChar) <= 57))
                {

                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {

            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedIndex == 1)
                {
                    if (MessageBox.Show("Do you want to perform Periodic Testing ?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    {
                        PMTransaction_Class_obj.frequency = "Periodic";
                        FillTestGrid_Periodic();
                        dgAllTestsP.Focus();
                    }
                    else
                    {
                        tabControl1.SelectedIndex = 0;
                    }

                }
                else if (tabControl1.SelectedIndex == 0)
                {
                    PMTransaction_Class_obj.frequency = "Systematic";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }

        private void FillTestGrid()
        {
            try
            {
                if (txtQuantity.Text == "")
                {
                    MessageBox.Show("Please Enter Quantity", "Warning");
                    txtQuantity.Focus();
                    return;
                }
                else
                {
                    dgAllTests.Rows.Clear();

                    if ((Convert.ToInt64(txtQuantity.Text) < 501))
                    {
                        MessageBox.Show("Quantity Less Than 501", "Warning");
                        txtQuantity.Text = "";
                        txtQuantity.Focus();
                        return;
                    }
                    else if ((Convert.ToInt64(txtQuantity.Text) >= 501) && (Convert.ToInt64(txtQuantity.Text) <= 1200))
                    {
                        PMTransaction_Class_obj.lotsize = "501-1200";
                    }
                    else if ((Convert.ToInt64(txtQuantity.Text) >= 1201) && (Convert.ToInt64(txtQuantity.Text) <= 3200))
                    {
                        PMTransaction_Class_obj.lotsize = "1201-3200";
                    }
                    else if ((Convert.ToInt64(txtQuantity.Text) >= 3201) && (Convert.ToInt64(txtQuantity.Text) <= 10000))
                    {
                        PMTransaction_Class_obj.lotsize = "3201-10000";
                    }
                    else if ((Convert.ToInt64(txtQuantity.Text) >= 10001) && (Convert.ToInt64(txtQuantity.Text) <= 35000))
                    {
                        PMTransaction_Class_obj.lotsize = "10001-35000";
                    }
                    else if ((Convert.ToInt64(txtQuantity.Text) >= 35001) && (Convert.ToInt64(txtQuantity.Text) <= 150000))
                    {
                        PMTransaction_Class_obj.lotsize = "35001-150000";
                    }
                    else if ((Convert.ToInt64(txtQuantity.Text) >= 150001) && (Convert.ToInt64(txtQuantity.Text) <= 5000000))
                    {
                        PMTransaction_Class_obj.lotsize = "150001-5000000";
                    }
                    else
                    {
                        MessageBox.Show("Quantity greater Than 5000000", "Warning");
                        txtQuantity.Text = "";
                        txtQuantity.Focus();
                        return;
                    }

                    //only systematic testing is done regularly
                    //Periodic testing is done once a year

                    PMTransaction_Class_obj.frequency = "Systematic";

                    DataSet dsInspMethod = new DataSet();
                    DataSet dsAll = new DataSet();
                    DataTable Dt = new DataTable();
                    //Dt = PMMaster_Class_obj.Select_tblPMCodeFamilyTestRelation_PMCodeID();

                    //if (Dt.Rows.Count > 0)
                    //{
                    //    PMTransaction_Class_obj.pmcodeid = PMMaster_Class_obj.pmcodeid;
                    //    DataSet ds = new DataSet();
                    //    ds = PMTransaction_Class_obj.Select_View_PMFGMethodDetails_TestNo_TestName_PMCodeID();
                    //    if (ds.Tables[0].Rows.Count > 0)
                    //    {
                    //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    //        {
                    //            dgAllTests.Rows.Add();
                    //            dgAllTests["TestNo", dgAllTests.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestNo"];
                    //            dgAllTests["TestMethod", dgAllTests.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestName"];
                    //            PMTransaction_Class_obj.testname = dgAllTests["TestMethod", dgAllTests.Rows.Count - 1].Value.ToString();

                    //            dgAllTests["TestDesc", dgAllTests.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestDesc"];

                    //            dsInspMethod = PMTransaction_Class_obj.Select_View_PMFGMethodDetails_InspectionMethod_Modification();

                    //            if (dsInspMethod.Tables[0].Rows.Count <= 0)
                    //            {
                    //                dsInspMethod = PMTransaction_Class_obj.Select_View_PMFGMethodDetails_InspectionMethod();
                    //            }

                    //            DataGridViewComboBoxCell combo = new DataGridViewComboBoxCell();
                    //            combo.DisplayMember = dsInspMethod.Tables[0].Columns["InspectionMethod"].ToString();
                    //            combo.Items.Add(dsInspMethod.Tables[0].Rows[0][0].ToString());
                    //            //for (int row = 0; row < dsInspMethod.Tables[0].Rows.Count; row++)
                    //            //{
                    //            //    combo.Items.Add(dsInspMethod.Tables[0].Rows[row][0].ToString());
                    //            //}
                    //            dgAllTests.Rows[i].Cells["InspectionMethod"] = combo;

                    //            DataSet dsReading;
                    //            dsReading = new DataSet();
                    //            PMTransaction_Class_obj.inspectionmethod = dsInspMethod.Tables[0].Rows[0][0].ToString();
                    //            PMTransaction_Class_obj.fgmethodno = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_FGMethodNo();

                    //            combo.Value = dsInspMethod.Tables[0].Rows[0][0].ToString();
                    //            //dsAll = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_All_Modification();
                    //            dsAll = PMTransaction_Class_obj.Select_PMFGMethodDetails_PMTransID();
                    //            if (dsAll.Tables[0].Rows.Count <= 0)
                    //            {
                    //                dsAll = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_All();
                    //                dsAll.Tables[0].Columns.Add("SampleSizeReading");
                    //                dsAll.Tables[0].Columns.Add("AQLReading");
                    //                dsAll.Tables[0].Columns.Add("AQLZReading");
                    //                dsAll.Tables[0].Columns.Add("AQLCReading");
                    //                dsAll.Tables[0].Columns.Add("AQLMReading");
                    //                dsAll.Tables[0].Columns.Add("AQLM1Reading");
                    //            }
                    //            DisplayDataGridView_All(dsAll, dgAllTests.Rows.Count - 1);

                    //        }
                    //    }

                    //}
                    //else
                    //{
                    //    DataSet ds = new DataSet();
                    //    ds = PMTransaction_Class_obj.Select_View_PMFGMethodDetails_TestNo_TestName();

                    //    if (ds.Tables[0].Rows.Count > 0)
                    //    {
                    //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    //        {
                    //            dgAllTests.Rows.Add();
                    //            dgAllTests["TestNo", dgAllTests.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestNo"];
                    //            dgAllTests["TestMethod", dgAllTests.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestName"];
                    //            PMTransaction_Class_obj.testname = dgAllTests["TestMethod", dgAllTests.Rows.Count - 1].Value.ToString();

                    //            dgAllTests["TestDesc", dgAllTests.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestDesc"];

                    //            dsInspMethod = PMTransaction_Class_obj.Select_View_PMFGMethodDetails_InspectionMethod_Modification();

                    //            if (dsInspMethod.Tables[0].Rows.Count <= 0)
                    //            {
                    //                dsInspMethod = PMTransaction_Class_obj.Select_View_PMFGMethodDetails_InspectionMethod();
                    //            }

                    //            DataGridViewComboBoxCell combo = new DataGridViewComboBoxCell();
                    //            combo.DisplayMember = dsInspMethod.Tables[0].Columns["InspectionMethod"].ToString();
                    //            combo.Items.Add(dsInspMethod.Tables[0].Rows[0][0].ToString());
                    //            //for (int row = 0; row < dsInspMethod.Tables[0].Rows.Count; row++)
                    //            //{
                    //            //    combo.Items.Add(dsInspMethod.Tables[0].Rows[row][0].ToString());
                    //            //}
                    //            dgAllTests.Rows[i].Cells["InspectionMethod"] = combo;

                    //            DataSet dsReading;
                    //            dsReading = new DataSet();
                    //            PMTransaction_Class_obj.inspectionmethod = dsInspMethod.Tables[0].Rows[0][0].ToString();
                    //            PMTransaction_Class_obj.fgmethodno = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_FGMethodNo();

                    //            combo.Value = dsInspMethod.Tables[0].Rows[0][0].ToString();
                    //            //dsAll = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_All_Modification();
                    //            dsAll = PMTransaction_Class_obj.Select_PMFGMethodDetails_PMTransID();
                    //            if (dsAll.Tables[0].Rows.Count <= 0)
                    //            {
                    //                dsAll = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_All();
                    //                dsAll.Tables[0].Columns.Add("SampleSizeReading");
                    //                dsAll.Tables[0].Columns.Add("AQLReading");
                    //                dsAll.Tables[0].Columns.Add("AQLZReading");
                    //                dsAll.Tables[0].Columns.Add("AQLCReading");
                    //                dsAll.Tables[0].Columns.Add("AQLMReading");
                    //                dsAll.Tables[0].Columns.Add("AQLM1Reading");
                    //            }
                    //            DisplayDataGridView_All(dsAll, dgAllTests.Rows.Count - 1);

                    //        }
                    //    }

                    //}

                    #region Newly Added Code
                    DataSet ds = new DataSet();
                    //ds = PMTransaction_Class_obj.Select_View_PMFGMethodDetails_TestNo_TestName();
                    ds = PMTransaction_Class_obj.Select_ModificationPMFGMethodDetails_TestNo_TestName();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            dgAllTests.Rows.Add();
                            dgAllTests["TestNo", dgAllTests.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestNo"];
                            dgAllTests["TestMethod", dgAllTests.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestName"];
                            PMTransaction_Class_obj.testname = dgAllTests["TestMethod", dgAllTests.Rows.Count - 1].Value.ToString();

                            dgAllTests["TestDesc", dgAllTests.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestDesc"];

                            //dsInspMethod = PMTransaction_Class_obj.Select_View_PMFGMethodDetails_InspectionMethod();
                            //DataGridViewComboBoxCell combo = new DataGridViewComboBoxCell();
                            //combo.DisplayMember = ds.Tables[0].Rows[i]["InspectionMethod"].ToString();
                            //combo.Items.Add(ds.Tables[0].Rows[i]["InspectionMethod"].ToString());
                            dgAllTests["InspectionMethod", dgAllTests.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["InspectionMethod"];//combo;


                            dgAllTests["Frequency", dgAllTests.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["frequency"];

                            dgAllTests["LotSize", dgAllTests.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["lotsize"];

                            dgAllTests["SampleSizeStandard", dgAllTests.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["samplesize"];

                            //Set to blank
                            dgAllTests["SampleSizeReading", dgAllTests.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["SampleSizeReading"];

                            //dataGridView 5 --> editable for sample size reading                        


                            if (Convert.ToString(ds.Tables[0].Rows[i]["aql"]) == "")
                            {
                                dgAllTests["AQLStandard", dgAllTests.Rows.Count - 1].Value = "N/A";
                                dgAllTests["AQLReading", dgAllTests.Rows.Count - 1].Value = "N/A";

                                dgAllTests["AQLReading", dgAllTests.Rows.Count - 1].ReadOnly = true;
                                dgAllTests["AQLReading", dgAllTests.Rows.Count - 1].Style.BackColor = Color.FromKnownColor(KnownColor.LightGray);
                            }
                            else
                            {
                                dgAllTests["AQLStandard", dgAllTests.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["aql"];
                                dgAllTests["AQLReading", dgAllTests.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["AQLReading"];

                                dgAllTests["AQLReading", dgAllTests.Rows.Count - 1].ReadOnly = false;
                                dgAllTests["AQLReading", dgAllTests.Rows.Count - 1].Style.BackColor = Color.White;
                            }

                            if (Convert.ToString(ds.Tables[0].Rows[i]["aqlz"]) == "")
                            {
                                dgAllTests["AQLzStandard", dgAllTests.Rows.Count - 1].Value = "N/A";
                                dgAllTests["AQLzReading", dgAllTests.Rows.Count - 1].Value = "N/A";

                                dgAllTests["AQLzReading", dgAllTests.Rows.Count - 1].ReadOnly = true;
                                dgAllTests["AQLzReading", dgAllTests.Rows.Count - 1].Style.BackColor = Color.FromKnownColor(KnownColor.LightGray);
                            }
                            else
                            {
                                dgAllTests["AQLzStandard", dgAllTests.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["aqlz"];
                                dgAllTests["AQLzReading", dgAllTests.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["AQLZReading"];

                                dgAllTests["AQLzReading", dgAllTests.Rows.Count - 1].ReadOnly = false;
                                dgAllTests["AQLzReading", dgAllTests.Rows.Count - 1].Style.BackColor = Color.White;
                            }

                            if (Convert.ToString(ds.Tables[0].Rows[i]["aqlc"]) == "")
                            {
                                dgAllTests["AQLcStandard", dgAllTests.Rows.Count - 1].Value = "N/A";
                                dgAllTests["AQLcReading", dgAllTests.Rows.Count - 1].Value = "N/A";

                                dgAllTests["AQLcReading", dgAllTests.Rows.Count - 1].ReadOnly = true;
                                dgAllTests["AQLcReading", dgAllTests.Rows.Count - 1].Style.BackColor = Color.FromKnownColor(KnownColor.LightGray);
                            }
                            else
                            {
                                dgAllTests["AQLcStandard", dgAllTests.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["aqlc"];
                                dgAllTests["AQLcReading", dgAllTests.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["AQLCReading"];

                                dgAllTests["AQLcReading", dgAllTests.Rows.Count - 1].ReadOnly = false;
                                dgAllTests["AQLcReading", dgAllTests.Rows.Count - 1].Style.BackColor = Color.White;
                            }

                            if (Convert.ToString(ds.Tables[0].Rows[i]["aqlm"]) == "")
                            {
                                dgAllTests["AQLMStandard", dgAllTests.Rows.Count - 1].Value = "N/A";
                                dgAllTests["AQLMReading", dgAllTests.Rows.Count - 1].Value = "N/A";

                                dgAllTests["AQLMReading", dgAllTests.Rows.Count - 1].ReadOnly = true;
                                dgAllTests["AQLMReading", dgAllTests.Rows.Count - 1].Style.BackColor = Color.FromKnownColor(KnownColor.LightGray);
                            }
                            else
                            {
                                dgAllTests["AQLMStandard", dgAllTests.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["aqlm"];
                                dgAllTests["AQLMReading", dgAllTests.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["AQLMReading"];

                                dgAllTests["AQLMReading", dgAllTests.Rows.Count - 1].ReadOnly = false;
                                dgAllTests["AQLMReading", dgAllTests.Rows.Count - 1].Style.BackColor = Color.White;
                            }

                            if (Convert.ToString(ds.Tables[0].Rows[i]["aqlm1"]) == "")
                            {
                                dgAllTests["AQLM1Standard", dgAllTests.Rows.Count - 1].Value = "N/A";
                                dgAllTests["AQLM1Reading", dgAllTests.Rows.Count - 1].Value = "N/A";

                                dgAllTests["AQLM1Reading", dgAllTests.Rows.Count - 1].ReadOnly = true;
                                dgAllTests["AQLM1Reading", dgAllTests.Rows.Count - 1].Style.BackColor = Color.FromKnownColor(KnownColor.LightGray);
                            }
                            else
                            {
                                dgAllTests["AQLM1Standard", dgAllTests.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["aqlm1"];
                                dgAllTests["AQLM1Reading", dgAllTests.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["AQLM1Reading"];

                                dgAllTests["AQLM1Reading", dgAllTests.Rows.Count - 1].ReadOnly = false;
                                dgAllTests["AQLM1Reading", dgAllTests.Rows.Count - 1].Style.BackColor = Color.White;
                            }


                        }
                    }
                    #endregion

                    #region Old Code

                    //        //DataGridViewComboBoxCell combo = new DataGridViewComboBoxCell();
                    //        //combo.DisplayMember = dsInspMethod.Tables[0].Columns["InspectionMethod"].ToString();
                    //        //combo.Items.Add(dsInspMethod.Tables[0].Rows[0][0].ToString());
                    //        //for (int row = 0; row < dsInspMethod.Tables[0].Rows.Count; row++)
                    //        //{
                    //        //    combo.Items.Add(dsInspMethod.Tables[0].Rows[row][0].ToString());
                    //        //}
                    //        //dgAllTests.Rows[i].Cells["InspectionMethod"] = combo;

                    //        //DataSet dsReading;
                    //        //dsReading = new DataSet();
                    //        //PMTransaction_Class_obj.inspectionmethod = dsInspMethod.Tables[0].Rows[0][0].ToString();
                    //        //PMTransaction_Class_obj.fgmethodno = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_FGMethodNo();

                    //        //combo.Value = dsInspMethod.Tables[0].Rows[0][0].ToString();
                    //        //dsAll = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_All();
                    //        //DisplayDataGridView_All(dsAll, dgAllTests.Rows.Count - 1);
                    //        //for (int row = 0; row < dsInspMethod.Tables[0].Rows.Count; row++)
                    //        //{
                    //        //    dsReading = new DataSet();
                    //        //    PMTransaction_Class_obj.inspectionmethod = dsInspMethod.Tables[0].Rows[row][0].ToString();
                    //        //    PMTransaction_Class_obj.fgmethodno = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_FGMethodNo();

                    //        //    combo.Value = dsInspMethod.Tables[0].Rows[row][0].ToString();
                    //        //    dsAll = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_All();
                    //        //    DisplayDataGridView_All(dsAll, dgAllTests.Rows.Count - 1);
                    //        //}
                    #endregion


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FillTestGrid_Periodic()
        {
            try
            {
                if (txtQuantity.Text == "")
                {
                    MessageBox.Show("Please Enter Quantity", "Warning");
                    txtQuantity.Focus();
                    return;
                }
                else
                {
                    dgAllTestsP.Rows.Clear();

                    if ((Convert.ToInt64(txtQuantity.Text) < 501))
                    {
                        MessageBox.Show("Quantity Less Than 501", "Warning");
                        txtQuantity.Text = "";
                        txtQuantity.Focus();
                        return;
                    }
                    else if ((Convert.ToInt64(txtQuantity.Text) >= 501) && (Convert.ToInt64(txtQuantity.Text) <= 1200))
                    {
                        PMTransaction_Class_obj.lotsize = "501-1200";
                    }
                    else if ((Convert.ToInt64(txtQuantity.Text) >= 1201) && (Convert.ToInt64(txtQuantity.Text) <= 3200))
                    {
                        PMTransaction_Class_obj.lotsize = "1201-3200";
                    }
                    else if ((Convert.ToInt64(txtQuantity.Text) >= 3201) && (Convert.ToInt64(txtQuantity.Text) <= 10000))
                    {
                        PMTransaction_Class_obj.lotsize = "3201-10000";
                    }
                    else if ((Convert.ToInt64(txtQuantity.Text) >= 10001) && (Convert.ToInt64(txtQuantity.Text) <= 35000))
                    {
                        PMTransaction_Class_obj.lotsize = "10001-35000";
                    }
                    else if ((Convert.ToInt64(txtQuantity.Text) >= 35001) && (Convert.ToInt64(txtQuantity.Text) <= 150000))
                    {
                        PMTransaction_Class_obj.lotsize = "35001-150000";
                    }
                    else if ((Convert.ToInt64(txtQuantity.Text) >= 150001) && (Convert.ToInt64(txtQuantity.Text) <= 5000000))
                    {
                        PMTransaction_Class_obj.lotsize = "150001-5000000";
                    }
                    else
                    {
                        MessageBox.Show("Quantity greater Than 5000000", "Warning");
                        txtQuantity.Text = "";
                        txtQuantity.Focus();
                        return;
                    }

                    //only systematic testing is done regularly
                    //Periodic testing is done once a year

                    PMTransaction_Class_obj.frequency = "Periodic";



                    DataSet dsInspMethod = new DataSet();
                    DataSet dsAll = new DataSet();
                    //DataTable Dt = new DataTable();
                    //Dt = PMMaster_Class_obj.Select_tblPMCodeFamilyTestRelation_PMCodeID();

                    //if (Dt.Rows.Count > 0)
                    //{
                    //    PMTransaction_Class_obj.pmcodeid = PMMaster_Class_obj.pmcodeid;
                    //    DataSet ds = new DataSet();
                    //    ds = PMTransaction_Class_obj.Select_View_PMFGMethodDetails_TestNo_TestName_PMCodeID();
                    //    if (ds.Tables[0].Rows.Count > 0)
                    //    {
                    //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    //        {
                    //            dgAllTestsP.Rows.Add();
                    //            dgAllTestsP["TestNoP", dgAllTestsP.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestNo"];
                    //            dgAllTestsP["TestMethodP", dgAllTestsP.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestName"];
                    //            PMTransaction_Class_obj.testname = dgAllTestsP["TestMethodP", dgAllTestsP.Rows.Count - 1].Value.ToString();

                    //            dgAllTestsP["TestDescP", dgAllTestsP.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestDesc"];

                    //            dsInspMethod = PMTransaction_Class_obj.Select_View_PMFGMethodDetails_InspectionMethod_Modification();

                    //            if (dsInspMethod.Tables[0].Rows.Count <= 0)
                    //            {
                    //                dsInspMethod = PMTransaction_Class_obj.Select_View_PMFGMethodDetails_InspectionMethod();
                    //            }

                    //            DataGridViewComboBoxCell combo = new DataGridViewComboBoxCell();
                    //            combo.DisplayMember = dsInspMethod.Tables[0].Columns["InspectionMethod"].ToString();
                    //            combo.Items.Add(dsInspMethod.Tables[0].Rows[0][0].ToString());
                    //            //for (int row = 0; row < dsInspMethod.Tables[0].Rows.Count; row++)
                    //            //{
                    //            //    combo.Items.Add(dsInspMethod.Tables[0].Rows[row][0].ToString());
                    //            //}
                    //            dgAllTestsP.Rows[i].Cells["InspectionMethodP"] = combo;

                    //            DataSet dsReading;
                    //            dsReading = new DataSet();
                    //            PMTransaction_Class_obj.inspectionmethod = dsInspMethod.Tables[0].Rows[0][0].ToString();
                    //            PMTransaction_Class_obj.fgmethodno = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_FGMethodNo();

                    //            combo.Value = dsInspMethod.Tables[0].Rows[0][0].ToString();
                    //            //dsAll = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_All_Modification();
                    //            dsAll = PMTransaction_Class_obj.Select_PMFGMethodDetails_PMTransID();
                    //            if (dsAll.Tables[0].Rows.Count <= 0)
                    //            {
                    //                dsAll = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_All();
                    //                dsAll.Tables[0].Columns.Add("SampleSizeReading");
                    //                dsAll.Tables[0].Columns.Add("AQLReading");
                    //                dsAll.Tables[0].Columns.Add("AQLZReading");
                    //                dsAll.Tables[0].Columns.Add("AQLCReading");
                    //                dsAll.Tables[0].Columns.Add("AQLMReading");
                    //                dsAll.Tables[0].Columns.Add("AQLM1Reading");
                    //            }
                    //            DisplayDataGridView_All_Periodic(dsAll, dgAllTestsP.Rows.Count - 1);
                    //        }
                    //    }

                    //}
                    //else
                    //{
                    //    DataSet ds = new DataSet();
                    //    ds = PMTransaction_Class_obj.Select_View_PMFGMethodDetails_TestNo_TestName();
                    //    if (ds.Tables[0].Rows.Count > 0)
                    //    {
                    //        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    //        {
                    //            dgAllTestsP.Rows.Add();
                    //            dgAllTestsP["TestNoP", dgAllTestsP.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestNo"];
                    //            dgAllTestsP["TestMethodP", dgAllTestsP.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestName"];
                    //            PMTransaction_Class_obj.testname = dgAllTestsP["TestMethodP", dgAllTestsP.Rows.Count - 1].Value.ToString();

                    //            dgAllTestsP["TestDescP", dgAllTestsP.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestDesc"];

                    //            dsInspMethod = PMTransaction_Class_obj.Select_View_PMFGMethodDetails_InspectionMethod_Modification();

                    //            DataGridViewComboBoxCell combo = new DataGridViewComboBoxCell();
                    //            combo.DisplayMember = dsInspMethod.Tables[0].Columns["InspectionMethod"].ToString();
                    //            combo.Items.Add(dsInspMethod.Tables[0].Rows[0][0].ToString());
                    //            //for (int row = 0; row < dsInspMethod.Tables[0].Rows.Count; row++)
                    //            //{
                    //            //    combo.Items.Add(dsInspMethod.Tables[0].Rows[row][0].ToString());
                    //            //}
                    //            dgAllTestsP.Rows[i].Cells["InspectionMethodP"] = combo;

                    //            DataSet dsReading;
                    //            dsReading = new DataSet();
                    //            PMTransaction_Class_obj.inspectionmethod = dsInspMethod.Tables[0].Rows[0][0].ToString();
                    //            PMTransaction_Class_obj.fgmethodno = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_FGMethodNo();

                    //            combo.Value = dsInspMethod.Tables[0].Rows[0][0].ToString();
                    //            //dsAll = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_All_Modification();
                    //            dsAll = PMTransaction_Class_obj.Select_PMFGMethodDetails_PMTransID();
                    //            if (dsAll.Tables[0].Rows.Count <= 0)
                    //            {
                    //                dsAll = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_All();
                    //                dsAll.Tables[0].Columns.Add("SampleSizeReading");
                    //                dsAll.Tables[0].Columns.Add("AQLReading");
                    //                dsAll.Tables[0].Columns.Add("AQLZReading");
                    //                dsAll.Tables[0].Columns.Add("AQLCReading");
                    //                dsAll.Tables[0].Columns.Add("AQLMReading");
                    //                dsAll.Tables[0].Columns.Add("AQLM1Reading");
                    //            }
                    //            DisplayDataGridView_All_Periodic(dsAll, dgAllTestsP.Rows.Count - 1);

                    //        }
                    //    }
                    //}


                    #region Newly Added Code
                    DataSet ds = new DataSet();
                    ds = PMTransaction_Class_obj.Select_ModificationPMFGMethodDetails_TestNo_TestName();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            dgAllTestsP.Rows.Add();
                            dgAllTestsP["TestNoP", dgAllTestsP.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestNo"];
                            dgAllTestsP["TestMethodP", dgAllTestsP.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestName"];
                            PMTransaction_Class_obj.testname = dgAllTestsP["TestMethodP", dgAllTestsP.Rows.Count - 1].Value.ToString();

                            dgAllTestsP["TestDescP", dgAllTestsP.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestDesc"];

                            dgAllTestsP["InspectionMethodP", dgAllTestsP.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["InspectionMethod"];//combo;


                            dgAllTestsP["FrequencyP", dgAllTestsP.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["frequency"];

                            dgAllTestsP["LotSizeP", dgAllTestsP.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["lotsize"];

                            dgAllTestsP["SampleSizeStandardP", dgAllTestsP.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["samplesize"];

                            //Set to blank
                            dgAllTestsP["SampleSizeReadingP", dgAllTestsP.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["SampleSizeReading"];

                            //dataGridView 5 --> editable for sample size reading                        


                            if (Convert.ToString(ds.Tables[0].Rows[i]["aql"]) == "")
                            {
                                dgAllTestsP["AQLStandardP", dgAllTestsP.Rows.Count - 1].Value = "N/A";
                                dgAllTestsP["AQLReadingP", dgAllTestsP.Rows.Count - 1].Value = "N/A";

                                dgAllTestsP["AQLReadingP", dgAllTestsP.Rows.Count - 1].ReadOnly = true;
                                dgAllTestsP["AQLReadingP", dgAllTestsP.Rows.Count - 1].Style.BackColor = Color.FromKnownColor(KnownColor.LightGray);
                            }
                            else
                            {
                                dgAllTestsP["AQLStandardP", dgAllTestsP.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["aql"];
                                dgAllTestsP["AQLReadingP", dgAllTestsP.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["AQLReading"];

                                dgAllTestsP["AQLReadingP", dgAllTestsP.Rows.Count - 1].ReadOnly = false;
                                dgAllTestsP["AQLReadingP", dgAllTestsP.Rows.Count - 1].Style.BackColor = Color.White;
                            }

                            if (Convert.ToString(ds.Tables[0].Rows[i]["aqlz"]) == "")
                            {
                                dgAllTestsP["AQLzStandardP", dgAllTestsP.Rows.Count - 1].Value = "N/A";
                                dgAllTestsP["AQLzReadingP", dgAllTestsP.Rows.Count - 1].Value = "N/A";

                                dgAllTestsP["AQLzReadingP", dgAllTestsP.Rows.Count - 1].ReadOnly = true;
                                dgAllTestsP["AQLzReadingP", dgAllTestsP.Rows.Count - 1].Style.BackColor = Color.FromKnownColor(KnownColor.LightGray);
                            }
                            else
                            {
                                dgAllTestsP["AQLzStandardP", dgAllTestsP.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["aqlz"];
                                dgAllTestsP["AQLzReadingP", dgAllTestsP.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["AQLZReading"];

                                dgAllTestsP["AQLzReadingP", dgAllTestsP.Rows.Count - 1].ReadOnly = false;
                                dgAllTestsP["AQLzReadingP", dgAllTestsP.Rows.Count - 1].Style.BackColor = Color.White;
                            }

                            if (Convert.ToString(ds.Tables[0].Rows[i]["aqlc"]) == "")
                            {
                                dgAllTestsP["AQLcStandardP", dgAllTestsP.Rows.Count - 1].Value = "N/A";
                                dgAllTestsP["AQLcReadingP", dgAllTestsP.Rows.Count - 1].Value = "N/A";

                                dgAllTestsP["AQLcReadingP", dgAllTestsP.Rows.Count - 1].ReadOnly = true;
                                dgAllTestsP["AQLcReadingP", dgAllTestsP.Rows.Count - 1].Style.BackColor = Color.FromKnownColor(KnownColor.LightGray);
                            }
                            else
                            {
                                dgAllTestsP["AQLcStandardP", dgAllTestsP.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["aqlc"];
                                dgAllTestsP["AQLcReadingP", dgAllTestsP.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["AQLCReading"];

                                dgAllTestsP["AQLcReadingP", dgAllTestsP.Rows.Count - 1].ReadOnly = false;
                                dgAllTestsP["AQLcReadingP", dgAllTestsP.Rows.Count - 1].Style.BackColor = Color.White;
                            }

                            if (Convert.ToString(ds.Tables[0].Rows[i]["aqlm"]) == "")
                            {
                                dgAllTestsP["AQLMStandardP", dgAllTestsP.Rows.Count - 1].Value = "N/A";
                                dgAllTestsP["AQLMReadingP", dgAllTestsP.Rows.Count - 1].Value = "N/A";

                                dgAllTestsP["AQLMReadingP", dgAllTestsP.Rows.Count - 1].ReadOnly = true;
                                dgAllTestsP["AQLMReadingP", dgAllTestsP.Rows.Count - 1].Style.BackColor = Color.FromKnownColor(KnownColor.LightGray);
                            }
                            else
                            {
                                dgAllTestsP["AQLMStandardP", dgAllTestsP.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["aqlm"];
                                dgAllTestsP["AQLMReadingP", dgAllTestsP.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["AQLMReading"];

                                dgAllTestsP["AQLMReadingP", dgAllTestsP.Rows.Count - 1].ReadOnly = false;
                                dgAllTestsP["AQLMReadingP", dgAllTestsP.Rows.Count - 1].Style.BackColor = Color.White;
                            }

                            if (Convert.ToString(ds.Tables[0].Rows[i]["aqlm1"]) == "")
                            {
                                dgAllTestsP["AQLM1StandardP", dgAllTestsP.Rows.Count - 1].Value = "N/A";
                                dgAllTestsP["AQLM1ReadingP", dgAllTestsP.Rows.Count - 1].Value = "N/A";

                                dgAllTestsP["AQLM1ReadingP", dgAllTestsP.Rows.Count - 1].ReadOnly = true;
                                dgAllTestsP["AQLM1ReadingP", dgAllTestsP.Rows.Count - 1].Style.BackColor = Color.FromKnownColor(KnownColor.LightGray);
                            }
                            else
                            {
                                dgAllTestsP["AQLM1StandardP", dgAllTestsP.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["aqlm1"];
                                dgAllTestsP["AQLM1ReadingP", dgAllTestsP.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["AQLM1Reading"];

                                dgAllTestsP["AQLM1ReadingP", dgAllTestsP.Rows.Count - 1].ReadOnly = false;
                                dgAllTestsP["AQLM1ReadingP", dgAllTestsP.Rows.Count - 1].Style.BackColor = Color.White;
                            }


                        }
                    }
                    #endregion
                    #region Old code
                    //        //dsInspMethod = PMTransaction_Class_obj.Select_View_PMFGMethodDetails_InspectionMethod();

                    //        //DataGridViewComboBoxCell combo = new DataGridViewComboBoxCell();
                    //        //combo.DisplayMember = dsInspMethod.Tables[0].Columns["InspectionMethod"].ToString();

                    //        //for (int row = 0; row < dsInspMethod.Tables[0].Rows.Count; row++)
                    //        //{
                    //        //    combo.Items.Add(dsInspMethod.Tables[0].Rows[row][0].ToString());
                    //        //}
                    //        //dgAllTestsP.Rows[i].Cells["InspectionMethodP"] = combo;

                    //        //DataSet dsReading;

                    //        //for (int row = 0; row < dsInspMethod.Tables[0].Rows.Count; row++)
                    //        //{
                    //        //    dsReading = new DataSet();
                    //        //    PMTransaction_Class_obj.inspectionmethod = dsInspMethod.Tables[0].Rows[row][0].ToString();
                    //        //    PMTransaction_Class_obj.fgmethodno = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_FGMethodNo();

                    //        //    combo.Value = dsInspMethod.Tables[0].Rows[row][0].ToString();
                    //        //    dsAll = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_All();
                    //        //    DisplayDataGridView_All_Periodic(dsAll, dgAllTestsP.Rows.Count - 1);
                    //        //}
                    #endregion
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DisplayDataGridView_All(DataSet dsAll, int rowIndex)
        {

            if (dsAll.Tables[0].Rows.Count > 0)
            {

                dgAllTests["Frequency", rowIndex].Value = dsAll.Tables[0].Rows[0]["frequency"];

                dgAllTests["LotSize", rowIndex].Value = dsAll.Tables[0].Rows[0]["lotsize"];

                dgAllTests["SampleSizeStandard", rowIndex].Value = dsAll.Tables[0].Rows[0]["samplesize"];

                //Set to blank
                if (dsAll.Tables[0].Rows[0]["SampleSizeReading"].ToString() != "")
                    dgAllTests["SampleSizeReading", rowIndex].Value = dsAll.Tables[0].Rows[0]["SampleSizeReading"];
                else
                    dgAllTests["SampleSizeReading", rowIndex].Value = "";

                //dataGridView 5 --> editable for sample size reading                        


                if (Convert.ToString(dsAll.Tables[0].Rows[0]["aql"]) == "")
                {
                    dgAllTests["AQLStandard", rowIndex].Value = "N/A";
                    dgAllTests["AQLReading", rowIndex].Value = "N/A";

                    dgAllTests["AQLReading", rowIndex].ReadOnly = true;
                    dgAllTests["AQLReading", rowIndex].Style.BackColor = Color.FromKnownColor(KnownColor.LightGray);
                }
                else
                {
                    dgAllTests["AQLStandard", rowIndex].Value = dsAll.Tables[0].Rows[0]["aql"];
                    if (dsAll.Tables[0].Rows[0]["AQLReading"].ToString() != "")
                        dgAllTests["AQLReading", rowIndex].Value = dsAll.Tables[0].Rows[0]["AQLReading"];
                    else
                        dgAllTests["AQLReading", rowIndex].Value = "";

                    dgAllTests["AQLReading", rowIndex].ReadOnly = false;
                    dgAllTests["AQLReading", rowIndex].Style.BackColor = Color.White;
                }

                if (Convert.ToString(dsAll.Tables[0].Rows[0]["aqlz"]) == "")
                {
                    dgAllTests["AQLzStandard", rowIndex].Value = "N/A";
                    dgAllTests["AQLzReading", rowIndex].Value = "N/A";

                    dgAllTests["AQLzReading", rowIndex].ReadOnly = true;
                    dgAllTests["AQLzReading", rowIndex].Style.BackColor = Color.FromKnownColor(KnownColor.LightGray);
                }
                else
                {
                    dgAllTests["AQLzStandard", rowIndex].Value = dsAll.Tables[0].Rows[0]["aqlz"];
                    if (dsAll.Tables[0].Rows[0]["AQLZReading"].ToString() != "")
                        dgAllTests["AQLzReading", rowIndex].Value = dsAll.Tables[0].Rows[0]["AQLZReading"];
                    else
                        dgAllTests["AQLzReading", rowIndex].Value = "";

                    dgAllTests["AQLzReading", rowIndex].ReadOnly = false;
                    dgAllTests["AQLzReading", rowIndex].Style.BackColor = Color.White;
                }

                if (Convert.ToString(dsAll.Tables[0].Rows[0]["aqlc"]) == "")
                {
                    dgAllTests["AQLcStandard", rowIndex].Value = "N/A";
                    dgAllTests["AQLcReading", rowIndex].Value = "N/A";

                    dgAllTests["AQLcReading", rowIndex].ReadOnly = true;
                    dgAllTests["AQLcReading", rowIndex].Style.BackColor = Color.FromKnownColor(KnownColor.LightGray);
                }
                else
                {
                    dgAllTests["AQLcStandard", rowIndex].Value = dsAll.Tables[0].Rows[0]["aqlc"];
                    if (dsAll.Tables[0].Rows[0]["AQLCReading"].ToString() != "")
                        dgAllTests["AQLcReading", rowIndex].Value = dsAll.Tables[0].Rows[0]["AQLCReading"];
                    else
                        dgAllTests["AQLcReading", rowIndex].Value = "";

                    dgAllTests["AQLcReading", rowIndex].ReadOnly = false;
                    dgAllTests["AQLcReading", rowIndex].Style.BackColor = Color.White;
                }

                if (Convert.ToString(dsAll.Tables[0].Rows[0]["aqlm"]) == "")
                {
                    dgAllTests["AQLMStandard", rowIndex].Value = "N/A";
                    dgAllTests["AQLMReading", rowIndex].Value = "N/A";

                    dgAllTests["AQLMReading", rowIndex].ReadOnly = true;
                    dgAllTests["AQLMReading", rowIndex].Style.BackColor = Color.FromKnownColor(KnownColor.LightGray);
                }
                else
                {
                    dgAllTests["AQLMStandard", rowIndex].Value = dsAll.Tables[0].Rows[0]["aqlm"];
                    if (dsAll.Tables[0].Rows[0]["AQLMReading"].ToString() != "")
                        dgAllTests["AQLMReading", rowIndex].Value = dsAll.Tables[0].Rows[0]["AQLMReading"];
                    else
                        dgAllTests["AQLMReading", rowIndex].Value = "";

                    dgAllTests["AQLMReading", rowIndex].ReadOnly = false;
                    dgAllTests["AQLMReading", rowIndex].Style.BackColor = Color.White;
                }

                if (Convert.ToString(dsAll.Tables[0].Rows[0]["aqlm1"]) == "")
                {
                    dgAllTests["AQLM1Standard", rowIndex].Value = "N/A";
                    dgAllTests["AQLM1Reading", rowIndex].Value = "N/A";

                    dgAllTests["AQLM1Reading", rowIndex].ReadOnly = true;
                    dgAllTests["AQLM1Reading", rowIndex].Style.BackColor = Color.FromKnownColor(KnownColor.LightGray);
                }
                else
                {
                    dgAllTests["AQLM1Standard", rowIndex].Value = dsAll.Tables[0].Rows[0]["aqlm1"];
                    if (dsAll.Tables[0].Rows[0]["AQLM1Reading"].ToString() != "")
                        dgAllTests["AQLM1Reading", rowIndex].Value = dsAll.Tables[0].Rows[0]["AQLM1Reading"];
                    else
                        dgAllTests["AQLM1Reading", rowIndex].Value = "";

                    dgAllTests["AQLM1Reading", rowIndex].ReadOnly = false;
                    dgAllTests["AQLM1Reading", rowIndex].Style.BackColor = Color.White;
                }
            }
        }

        private void DisplayDataGridView_All_Periodic(DataSet dsAll, int rowIndex)
        {

            if (dsAll.Tables[0].Rows.Count > 0)
            {

                dgAllTestsP["FrequencyP", rowIndex].Value = dsAll.Tables[0].Rows[0]["frequency"];

                dgAllTestsP["LotSizeP", rowIndex].Value = dsAll.Tables[0].Rows[0]["lotsize"];

                dgAllTestsP["SampleSizeStandardP", rowIndex].Value = dsAll.Tables[0].Rows[0]["samplesize"];

                //Set to blank
                if (dsAll.Tables[0].Rows[0]["SampleSizeReading"].ToString() != "")
                    dgAllTestsP["SampleSizeReadingP", rowIndex].Value = dsAll.Tables[0].Rows[0]["SampleSizeReading"];
                else
                    dgAllTestsP["SampleSizeReadingP", rowIndex].Value = "";

                //dataGridView 5 --> editable for sample size reading                        


                if (Convert.ToString(dsAll.Tables[0].Rows[0]["aql"]) == "")
                {
                    dgAllTestsP["AQLStandardP", rowIndex].Value = "N/A";
                    dgAllTestsP["AQLReadingP", rowIndex].Value = "N/A";

                    dgAllTestsP["AQLReadingP", rowIndex].ReadOnly = true;
                    dgAllTestsP["AQLReadingP", rowIndex].Style.BackColor = Color.FromKnownColor(KnownColor.LightGray);
                }
                else
                {
                    dgAllTestsP["AQLStandardP", rowIndex].Value = dsAll.Tables[0].Rows[0]["aql"];
                    if (dsAll.Tables[0].Rows[0]["AQLReading"].ToString() != "")
                        dgAllTestsP["AQLReadingP", rowIndex].Value = dsAll.Tables[0].Rows[0]["AQLReading"];
                    else
                        dgAllTestsP["AQLReadingP", rowIndex].Value = "";

                    dgAllTestsP["AQLReadingP", rowIndex].ReadOnly = false;
                    dgAllTestsP["AQLReadingP", rowIndex].Style.BackColor = Color.White;
                }

                if (Convert.ToString(dsAll.Tables[0].Rows[0]["aqlz"]) == "")
                {
                    dgAllTestsP["AQLzStandardP", rowIndex].Value = "N/A";
                    dgAllTestsP["AQLzReadingP", rowIndex].Value = "N/A";

                    dgAllTestsP["AQLzReadingP", rowIndex].ReadOnly = true;
                    dgAllTestsP["AQLzReadingP", rowIndex].Style.BackColor = Color.FromKnownColor(KnownColor.LightGray);
                }
                else
                {
                    dgAllTestsP["AQLzStandardP", rowIndex].Value = dsAll.Tables[0].Rows[0]["aqlz"];
                    if (dsAll.Tables[0].Rows[0]["AQLZReading"].ToString() != "")
                        dgAllTestsP["AQLzReadingP", rowIndex].Value = dsAll.Tables[0].Rows[0]["AQLZReading"];
                    else
                        dgAllTestsP["AQLzReadingP", rowIndex].Value = "";

                    dgAllTestsP["AQLzReadingP", rowIndex].ReadOnly = false;
                    dgAllTestsP["AQLzReadingP", rowIndex].Style.BackColor = Color.White;
                }

                if (Convert.ToString(dsAll.Tables[0].Rows[0]["aqlc"]) == "")
                {
                    dgAllTestsP["AQLcStandardP", rowIndex].Value = "N/A";
                    dgAllTestsP["AQLcReadingP", rowIndex].Value = "N/A";

                    dgAllTestsP["AQLcReadingP", rowIndex].ReadOnly = true;
                    dgAllTestsP["AQLcReadingP", rowIndex].Style.BackColor = Color.FromKnownColor(KnownColor.LightGray);
                }
                else
                {
                    dgAllTestsP["AQLcStandardP", rowIndex].Value = dsAll.Tables[0].Rows[0]["aqlc"];
                    if (dsAll.Tables[0].Rows[0]["AQLCReading"].ToString() != "")
                        dgAllTestsP["AQLcReadingP", rowIndex].Value = dsAll.Tables[0].Rows[0]["AQLCReading"];
                    else
                        dgAllTestsP["AQLcReadingP", rowIndex].Value = "";

                    dgAllTestsP["AQLcReadingP", rowIndex].ReadOnly = false;
                    dgAllTestsP["AQLcReadingP", rowIndex].Style.BackColor = Color.White;
                }

                if (Convert.ToString(dsAll.Tables[0].Rows[0]["aqlm"]) == "")
                {
                    dgAllTestsP["AQLMStandardP", rowIndex].Value = "N/A";
                    dgAllTestsP["AQLMReadingP", rowIndex].Value = "N/A";

                    dgAllTestsP["AQLMReadingP", rowIndex].ReadOnly = true;
                    dgAllTestsP["AQLMReadingP", rowIndex].Style.BackColor = Color.FromKnownColor(KnownColor.LightGray);
                }
                else
                {
                    dgAllTestsP["AQLMStandardP", rowIndex].Value = dsAll.Tables[0].Rows[0]["aqlm"];
                    if (dsAll.Tables[0].Rows[0]["AQLMReading"].ToString() != "")
                        dgAllTestsP["AQLMReadingP", rowIndex].Value = dsAll.Tables[0].Rows[0]["AQLMReading"];
                    else
                        dgAllTestsP["AQLMReadingP", rowIndex].Value = "";

                    dgAllTestsP["AQLMReadingP", rowIndex].ReadOnly = false;
                    dgAllTestsP["AQLMReadingP", rowIndex].Style.BackColor = Color.White;
                }

                if (Convert.ToString(dsAll.Tables[0].Rows[0]["aqlm1"]) == "")
                {
                    dgAllTestsP["AQLM1StandardP", rowIndex].Value = "N/A";
                    dgAllTestsP["AQLM1ReadingP", rowIndex].Value = "N/A";

                    dgAllTestsP["AQLM1ReadingP", rowIndex].ReadOnly = true;
                    dgAllTestsP["AQLM1ReadingP", rowIndex].Style.BackColor = Color.FromKnownColor(KnownColor.LightGray);
                }
                else
                {
                    dgAllTestsP["AQLM1StandardP", rowIndex].Value = dsAll.Tables[0].Rows[0]["aqlm1"];
                    if (dsAll.Tables[0].Rows[0]["AQLM1Reading"].ToString() != "")
                        dgAllTestsP["AQLM1ReadingP", rowIndex].Value = dsAll.Tables[0].Rows[0]["AQLM1Reading"];
                    else
                        dsAll.Tables[0].Rows[0]["AQLM1Reading"] = "";

                    dgAllTestsP["AQLM1ReadingP", rowIndex].ReadOnly = false;
                    dgAllTestsP["AQLM1ReadingP", rowIndex].Style.BackColor = Color.White;
                }
            }
        }

        ComboBox cmb;
        private void dgAllTests_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgAllTests.CurrentCell.RowIndex < 0
               || (dgAllTests.CurrentCell.ColumnIndex != dgAllTests.Columns["InspectionMethod"].Index
                    && dgAllTests.CurrentCell.ReadOnly == true))
            {
                return;
            }
            else if (dgAllTests.CurrentCell.ColumnIndex == dgAllTests.Columns["InspectionMethod"].Index)
            {
                cmb = e.Control as ComboBox;
                cmb.Text = e.Control.Text;
                cmb.TextChanged += new EventHandler(cmb_TextChanged);
                return;
            }
            else if (dgAllTests.CurrentCell.ReadOnly == false)
            {

                dgAllTests.EditingControl.KeyPress += new KeyPressEventHandler(EditingControl_KeyPress);
            }
        }

        private void dgAllTestsP_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgAllTestsP.CurrentCell.RowIndex < 0
               || (dgAllTestsP.CurrentCell.ColumnIndex != dgAllTestsP.Columns["InspectionMethodP"].Index
                    && dgAllTestsP.CurrentCell.ReadOnly == true))
            {
                return;
            }
            else if (dgAllTestsP.CurrentCell.ColumnIndex == dgAllTestsP.Columns["InspectionMethodP"].Index)
            {
                cmb = e.Control as ComboBox;
                cmb.Text = e.Control.Text;
                cmb.TextChanged += new EventHandler(cmb_TextChanged_Periodic);
                return;
            }
            else if (dgAllTestsP.CurrentCell.ReadOnly == false)
            {

                dgAllTestsP.EditingControl.KeyPress += new KeyPressEventHandler(EditingControl_KeyPress);
            }
        }

        public void cmb_TextChanged(object sender, EventArgs e)
        {
            if (dgAllTests.CurrentCell.RowIndex < 0 || dgAllTests.CurrentCell.ColumnIndex != dgAllTests.Columns["InspectionMethod"].Index || cmb.Text == "")
            {
                return;
            }
            else
            {

                DataSet dsAll = new DataSet();

                PMTransaction_Class_obj.inspectionmethod = cmb.Text;
                PMTransaction_Class_obj.testname = dgAllTests["TestMethod", dgAllTests.CurrentCell.RowIndex].Value.ToString();
                dsAll = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_All();
                DisplayDataGridView_All(dsAll, dgAllTests.CurrentCell.RowIndex);

            }

        }

        public void cmb_TextChanged_Periodic(object sender, EventArgs e)
        {
            if (dgAllTestsP.CurrentCell.RowIndex < 0 || dgAllTestsP.CurrentCell.ColumnIndex != dgAllTestsP.Columns["InspectionMethodP"].Index || cmb.Text == "")
            {
                return;
            }
            else
            {

                DataSet dsAll = new DataSet();

                PMTransaction_Class_obj.inspectionmethod = cmb.Text; //dataGridView.Rows[dataGridView.CurrentCell.RowIndex].Cells["InspectionMethod"].Value.ToString();
                PMTransaction_Class_obj.testname = dgAllTestsP["TestMethodP", dgAllTestsP.CurrentCell.RowIndex].Value.ToString();
                dsAll = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_All();
                DisplayDataGridView_All_Periodic(dsAll, dgAllTestsP.CurrentCell.RowIndex);

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

        private void dgAllTests_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Convert.ToInt32(e.KeyChar) != 8) && (Convert.ToInt32(e.KeyChar) != 46))
            {
                if ((Convert.ToInt32(e.KeyChar) < 48) || (Convert.ToInt32(e.KeyChar) > 57))
                {

                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void dgAllTestsP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Convert.ToInt32(e.KeyChar) != 8) && (Convert.ToInt32(e.KeyChar) != 46))
            {
                if ((Convert.ToInt32(e.KeyChar) < 48) || (Convert.ToInt32(e.KeyChar) > 57))
                {

                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        private void dgAllTests_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgAllTests.Columns["SampleSizeReading"].Index)
            {
                return;
            }
            else
            {

                if (dgAllTests.CurrentCell.EditedFormattedValue.ToString() != "")
                {
                    if (Convert.ToInt64(dgAllTests.CurrentCell.EditedFormattedValue) < Convert.ToInt64(dgAllTests["SampleSizeStandard", dgAllTests.CurrentCell.RowIndex].Value))
                    {
                        MessageBox.Show("Sample Size Reading is less than Sample Size Standard", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        e.Cancel = true;

                    }
                }
            }
        }

        private void dgAllTestsP_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgAllTestsP.Columns["SampleSizeReadingP"].Index)
            {
                return;
            }
            else
            {

                if (dgAllTestsP.CurrentCell.EditedFormattedValue.ToString() != "")
                {
                    if (Convert.ToInt64(dgAllTestsP.CurrentCell.EditedFormattedValue) < Convert.ToInt64(dgAllTestsP["SampleSizeStandardP", dgAllTestsP.CurrentCell.RowIndex].Value))
                    {
                        MessageBox.Show("Sample Size Reading is less than Sample Size Standard", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        e.Cancel = true;

                    }
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (CmbDetails.SelectedIndex == 0 || CmbDetails.Text == "--Select--" || CmbDetails.SelectedValue == null)
                {
                    MessageBox.Show("Select Details", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CmbDetails.Focus();
                    return;
                }
                else
                {

                    if (PMTransaction_Class_obj.analysisdone == 1)
                    {
                        if (txtQtySampled.Text == "")
                        {
                            MessageBox.Show("Please Enter Sampling Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtQtySampled.Focus();
                            return;
                        }
                        if (txtNoOfPallets.Text == "")
                        {
                            MessageBox.Show("Please Enter No of Palettes", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtNoOfPallets.Focus();
                            return;
                        }
                        if (txtNoOfShippers.Text == "")
                        {
                            MessageBox.Show("Please Enter No of Shippers", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtNoOfShippers.Focus();
                            return;
                        }
                    }
                    if (cmbDefectObserved.SelectedIndex == 0 || cmbDefectObserved.Text == "--Select--")
                    {
                        MessageBox.Show("Please Select Defect Observed", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                        cmbDefectObserved.Focus();
                        return;
                    }
                    if (cmbDefectObserved.SelectedIndex == 2 && txtNoOfDefect.Text.Trim() == "")
                    {
                        MessageBox.Show("Please enter No of Defects", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                        txtNoOfDefect.Focus();
                        return;
                    }
                    if (cmbDefectObserved.SelectedItem.ToString() == "Yes")
                    {
                        for (int d = 0; d < dgDefect.Rows.Count; d++)
                        {
                            if (!dgDefect.Rows[d].IsNewRow)
                            {
                                if (Convert.ToString(dgDefect["DefectComment", d].Value) == "")
                                {
                                    MessageBox.Show("Enter Defect Comment", "Defect", MessageBoxButtons.OK, MessageBoxIcon.None);
                                    dgDefect["DefectCommnet", d].Selected = true;
                                    return;
                                }
                                if (Convert.ToString(dgDefect["DefectQuantity", d].Value) == "")
                                {
                                    MessageBox.Show("Enter Defect Quantity", "Defect", MessageBoxButtons.OK, MessageBoxIcon.None);
                                    dgDefect["DefectQuantity", d].Selected = true;
                                    return;
                                }
                                if (Convert.ToString(dgDefect["ActionTaken", d].Value) == "")
                                {
                                    MessageBox.Show("Enter Defect ActionTaken", "Defect", MessageBoxButtons.OK, MessageBoxIcon.None);
                                    dgDefect["ActionTaken", d].Selected = true;
                                    return;
                                }
                                if (Convert.ToString(dgDefect["DefectStatus", d].Value) == "")
                                {
                                    MessageBox.Show("Enter Defect Status", "Defect", MessageBoxButtons.OK, MessageBoxIcon.None);
                                    dgDefect["DefectStatus", d].Selected = true;
                                    return;
                                }
                            }
                        }
                    }
                    if (txtQuantity.Text == "")
                    {
                        MessageBox.Show("Please Enter Received Quantity", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtQuantity.Focus();
                        return;
                    }
                    if (cmbType.Text == "Launch")
                    {
                        if (dgAllTests.Rows.Count == 0 || dgAllTestsP.Rows.Count == 0)
                        {
                            MessageBox.Show("Please perform systematic and periodic tesing", "New Launch", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    if (RdoAccept.Checked == false && RdoReject.Checked == false && RdoSendBackToSupplier.Checked == false && RdoAWD.Checked == false && RdoTreatment.Checked == false)
                    {
                        MessageBox.Show("Please Select Status", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (cmbType.Text == "Launch")
                    {
                        if (MessageBox.Show("New Launch ?", "Regular/Launch", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                        {
                            return;
                        }
                    }
                    if (cmbType.Text == "Regular")
                    {
                        if (MessageBox.Show("Regular ?", "Regular/Launch", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                        {
                            return;
                        }
                    }
                    if (RdoAccept.Checked == true)
                    {
                        if (MessageBox.Show("ACCEPT ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                        {
                            return;
                        }
                    }
                    if (RdoReject.Checked == true)
                    {
                        if (MessageBox.Show("REJECT ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                        {
                            return;
                        }
                    }
                    if (RdoAWD.Checked == true)
                    {
                        if (MessageBox.Show("ACCEPT WITH DERROGATION ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                        {
                            return;
                        }
                    }
                    if (RdoTreatment.Checked == true)
                    {
                        if (MessageBox.Show("TREATEMENT ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                        {
                            return;
                        }
                    }
                    if (RdoSendBackToSupplier.Checked == true)
                    {
                        if (MessageBox.Show("SEND BACK TO SUPPLIER ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                        {
                            return;
                        }
                    }
                    PMTransaction_Class_obj.pmtransid = Convert.ToInt64(CmbDetails.SelectedValue.ToString());

                    if (PMTransaction_Class_obj.pmtransid != 0)
                    {
                        //-------Insert tblPMSampling
                        if (txtQtySampled.Text.Trim() == "")
                            PMTransaction_Class_obj.quantitysampled = 0;
                        else
                            PMTransaction_Class_obj.quantitysampled = Convert.ToInt64(txtQtySampled.Text.ToString());

                        if (txtNoOfPallets.Text.Trim() == "")
                            PMTransaction_Class_obj.noofpallets = 0;
                        else
                            PMTransaction_Class_obj.noofpallets = Convert.ToInt32(txtNoOfPallets.Text.ToString());

                        if (txtNoOfShippers.Text.Trim() == "")
                            PMTransaction_Class_obj.noofshippers = 0;
                        else
                            PMTransaction_Class_obj.noofshippers = Convert.ToInt32(txtNoOfShippers.Text.ToString());

                        DataSet dss = new DataSet();
                        dss = PMTransaction_Class_obj.Select_tblPMSampling();
                        if (dss.Tables[0].Rows.Count > 0)
                        {
                            PMTransaction_Class_obj.pmsamplingid = Convert.ToInt64(dss.Tables[0].Rows[0]["PMSamplingID"]);
                            PMTransaction_Class_obj.Update_tblPMSampling();
                        }

                        //---------Insert tblPMDetails                         
                        PMTransaction_Class_obj.specificationno = txtSpecificationNo.Text.ToString().Trim();
                        PMTransaction_Class_obj.challanno = txtChallanNo.Text.ToString().Trim();
                        PMTransaction_Class_obj.mrr = txtMRR.Text.ToString().Trim();
                        if (cmbSupplierReportReceived.SelectedIndex == 1)
                        {
                            PMTransaction_Class_obj.srr = Convert.ToString("N");
                        }
                        else if (cmbSupplierReportReceived.SelectedIndex == 2)
                        {
                            PMTransaction_Class_obj.srr = Convert.ToString("Y");
                        }
                        else
                        {
                            PMTransaction_Class_obj.srr = Convert.ToString("");
                        }

                        if (cmbType.SelectedIndex == 1)
                        {
                            PMTransaction_Class_obj.launchregular = Convert.ToString("L");
                        }
                        else if (cmbType.SelectedIndex == 2)
                        {
                            PMTransaction_Class_obj.launchregular = Convert.ToString("R");
                        }
                        else
                        {
                            PMTransaction_Class_obj.launchregular = Convert.ToString("");
                        }

                        if (cmbPMReception.SelectedIndex == 1)
                        {
                            PMTransaction_Class_obj.firstpmreception = Convert.ToString("N");
                        }
                        else if (cmbPMReception.SelectedIndex == 2)
                        {
                            PMTransaction_Class_obj.firstpmreception = Convert.ToString("Y");
                        }
                        else
                        {
                            PMTransaction_Class_obj.firstpmreception = Convert.ToString("");
                        }

                        PMTransaction_Class_obj.noofbatches = Convert.ToInt32(txtNoofBatches.Text.Trim());

                        bool b = PMTransaction_Class_obj.Update_tblPMDetails();

                        //--------Insert tblPMTest                         

                        PMTransaction_Class_obj.accepteddate = Convert.ToString(DtpAcceptedDate.Value);
                        PMTransaction_Class_obj.receiptdate = Convert.ToString(DtpReceiptDate.Value);
                        PMTransaction_Class_obj.quantity = Convert.ToInt64(txtQuantity.Text.ToString());

                        PMTransaction_Class_obj.loginid = FrmMain.LoginID;

                        DataSet dst = new DataSet();
                        dst = PMTransaction_Class_obj.Select_tblPMTest();
                        if (dst.Tables[0].Rows.Count > 0)
                        {
                            PMTransaction_Class_obj.pmtestid = Convert.ToInt64(dst.Tables[0].Rows[0]["PMTestID"]);
                            PMTransaction_Class_obj.Update_tblPMTest();
                        }

                        if (PMTransaction_Class_obj.pmtestid != 0)
                        {
                            PMTransaction_Class_obj.inspdate = DtpInspDate.Value.ToShortDateString();

                            if (cmbDefectObserved.SelectedIndex == 1)
                                PMTransaction_Class_obj.defectobserved = Convert.ToString("N");
                            else if (cmbDefectObserved.SelectedIndex == 2)
                                PMTransaction_Class_obj.defectobserved = Convert.ToString("Y");
                            else
                                PMTransaction_Class_obj.defectobserved = Convert.ToString("");

                            if (txtNoOfDefect.Text.Trim() != "")
                                PMTransaction_Class_obj.noofdefect = Convert.ToInt32(txtNoOfDefect.Text.Trim());
                            else
                                PMTransaction_Class_obj.noofdefect = 0;

                            if (RdoAccept.Checked == true)
                                PMTransaction_Class_obj.status = "A";
                            else if (RdoAWD.Checked == true)
                                PMTransaction_Class_obj.status = "A";
                            else if (RdoReject.Checked == true)
                                PMTransaction_Class_obj.status = "R";
                            else if (RdoTreatment.Checked == true)
                                PMTransaction_Class_obj.status = "R";
                            else if (RdoSendBackToSupplier.Checked == true)
                                PMTransaction_Class_obj.status = "R";

                            //--------Actual Status-------
                            if (RdoAccept.Checked == true)
                                PMTransaction_Class_obj.actualstatus = "A";
                            else if (RdoAWD.Checked == true)
                                PMTransaction_Class_obj.actualstatus = "D";
                            else if (RdoReject.Checked == true)
                                PMTransaction_Class_obj.actualstatus = "R";
                            else if (RdoTreatment.Checked == true)
                                PMTransaction_Class_obj.actualstatus = "T";
                            else if (RdoSendBackToSupplier.Checked == true)
                                PMTransaction_Class_obj.actualstatus = "S";

                            PMTransaction_Class_obj.rejectcomment = Convert.ToString("N/A");
                            for (int i = 0; i < chkRejectComments.Items.Count; i++)
                            {
                                if (chkRejectComments.GetItemChecked(i) == true)
                                {
                                    if (i == 0)
                                    {
                                        PMTransaction_Class_obj.rejectcomment = Convert.ToString("BOR");
                                        break;
                                    }
                                    else if (i == 1)
                                    {
                                        PMTransaction_Class_obj.rejectcomment = Convert.ToString("BOF");
                                        break;
                                    }
                                    else if (i == 2)
                                    {
                                        PMTransaction_Class_obj.rejectcomment = Convert.ToString("COC");
                                        break;
                                    }
                                }
                            }
                            PMTransaction_Class_obj.currentflag = 1;
                            PMTransaction_Class_obj.fromAnalysisReanalysis = 1; // This Flag shows records only in modification
                            PMTransaction_Class_obj.loginid = FrmMain.LoginID;

                            DataSet dsC = new DataSet();
                            dsC = PMTransaction_Class_obj.Select_tblPMStatus();
                            if (dsC.Tables[0].Rows.Count > 0)
                            {
                                PMTransaction_Class_obj.pmchangeid = Convert.ToInt64(dsC.Tables[0].Rows[0]["PMChangeID"]);
                                PMTransaction_Class_obj.Update_tblPMStatus();
                            }

                            //IF Lot Rejected then update cocapplicable to 'N' for that PMCode and Supplier
                            if (PMTransaction_Class_obj.cocapplicable == "Y" && PMTransaction_Class_obj.status == "R")
                            {
                                if (MessageBox.Show("Lot is rejected.\nRemove from COC?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                                {
                                    //...........................................................
                                    //... check in coc status from PMTransID of tblPMTransaction
                                    // get second last record .if match with current status then delete otherwise insert in tranction

                                    bool COCFlag;
                                    DataSet dsStatus = new DataSet();
                                    //if( PMTransaction_Class_obj.cocapplicable =="N")
                                    //{
                                    //    COCFlag=false;
                                    //}
                                    //else 
                                    //{
                                    //    COCFlag=true;
                                    //}

                                    //check second last record from tblTransaction
                                    dsStatus = PMTransaction_Class_obj.CheckCOCStatus_tblPMTransaction();
                                    if (dsStatus.Tables[0].Rows.Count > 0)
                                    {
                                        //check not exist condition(if that TransID is not in tblPMCOCHistory then insert )
                                        if (dsStatus.Tables[0].Rows[0]["TransCOC"].ToString() == PMTransaction_Class_obj.cocapplicable)
                                        {

                                            PMTransaction_Class_obj.DeleteCOCStatus_tblPMCOCHistory();
                                        }
                                        else
                                        {
                                            //if not equal to previous record on tblTransaction and cocapplicable in tblPMSupplierCOC then insert
                                            PMTransaction_Class_obj.Insert_tblPMCOCHistory();
                                        }
                                    }

                                    //....................................................
                                    // pmsuppliercocid assign in CmbDetails Bind method by correction by sameer 15/2/2011
                                    // PMTransaction_Class_obj.pmsuppliercocid = Convert.ToInt64(CmbDetails.SelectedValue.ToString());
                                    PMTransaction_Class_obj.cocapplicable = "N";
                                    PMTransaction_Class_obj.Update_tblPMSupplierCOC_COCApplicable();
                                }
                            }


                            if (PMTransaction_Class_obj.pmchangeid != 0)
                            {
                                //----------Inser Defect
                                for (int d = 0; d < dgDefect.Rows.Count; d++)
                                {
                                    if (!dgDefect.Rows[d].IsNewRow)
                                    {
                                        PMTransaction_Class_obj.defectcomment = Convert.ToString(dgDefect["DefectComment", d].Value);
                                        PMTransaction_Class_obj.defectquantity = Convert.ToString(dgDefect["DefectQuantity", d].Value);

                                        if (Convert.ToString(dgDefect["ActionTaken", d].Value) == "Line Stopped : Requested QC to check")
                                            PMTransaction_Class_obj.actiontaken = "Q";
                                        else if (Convert.ToString(dgDefect["ActionTaken", d].Value) == "Line Stopped : Material returned to store")
                                            PMTransaction_Class_obj.actiontaken = "R";
                                        else if (Convert.ToString(dgDefect["ActionTaken", d].Value) == "On Line Sorting")
                                            PMTransaction_Class_obj.actiontaken = "S";
                                        else if (Convert.ToString(dgDefect["ActionTaken", d].Value) == "On Line Adjustment")
                                            PMTransaction_Class_obj.actiontaken = "A";
                                        else if (Convert.ToString(dgDefect["ActionTaken", d].Value) == "Other")
                                            PMTransaction_Class_obj.actiontaken = "O";

                                        PMTransaction_Class_obj.qualitydecision = Convert.ToString(dgDefect["QualityDecision", d].Value);

                                        if (Convert.ToString(dgDefect["DefectStatus", d].Value) == "Open")
                                            PMTransaction_Class_obj.defectstatus = "O";
                                        if (Convert.ToString(dgDefect["DefectStatus", d].Value) == "Close")
                                            PMTransaction_Class_obj.defectstatus = "C";

                                        if (dgDefect["PMDefectID", d].Value == null || Convert.ToString(dgDefect["PMDefectID", d].Value) == "")
                                        {
                                            PMTransaction_Class_obj.pmdefectid = PMTransaction_Class_obj.Insert_tblPMDefect();
                                        }
                                        else
                                        {
                                            PMTransaction_Class_obj.pmdefectid = Convert.ToInt64(dgDefect["PMDefectID", d].Value);
                                            PMTransaction_Class_obj.Update_tblPMDefect();
                                        }
                                    }
                                }

                                PMTransaction_Class_obj.Delete_tblPMFGTestMethodDetails();

                                //---------Save systematic tests
                                for (int i = 0; i < dgAllTests.Rows.Count; i++)
                                {
                                    //FinishedGoodTest_Class_Obj.pkgtechno = 
                                    PMTransaction_Class_obj.testname = dgAllTests["TestMethod", i].Value.ToString();
                                    PMTransaction_Class_obj.inspectionmethod = dgAllTests["InspectionMethod", i].Value.ToString();
                                    PMTransaction_Class_obj.frequency = dgAllTests["Frequency", i].Value.ToString();
                                    //FinishedGoodTest_Class_Obj.type 
                                    PMTransaction_Class_obj.lotsize = dgAllTests["LotSize", i].Value.ToString();

                                    PMTransaction_Class_obj.fgmethodno = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_FGMethodNo();

                                    //Insert standard reading in tblPMFGTestMethoddetails(Transaction level)
                                    if (dgAllTests["SampleSizeStandard", i].Value.ToString() == "")
                                    {
                                        PMTransaction_Class_obj.samplesize = 0;
                                    }
                                    else
                                    {
                                        PMTransaction_Class_obj.samplesize = Convert.ToInt32(dgAllTests["SampleSizeStandard", i].Value);
                                    }
                                    PMTransaction_Class_obj.aql = dgAllTests["AQLStandard", i].Value.ToString();
                                    PMTransaction_Class_obj.aqlz = dgAllTests["AQLzStandard", i].Value.ToString();
                                    PMTransaction_Class_obj.aqlc = dgAllTests["AQLcStandard", i].Value.ToString();
                                    PMTransaction_Class_obj.aqlm = dgAllTests["AQLMStandard", i].Value.ToString();
                                    PMTransaction_Class_obj.aqlm1 = dgAllTests["AQLM1Standard", i].Value.ToString();


                                    if (dgAllTests["SampleSizeReading", i].Value.ToString() == "")
                                    {
                                        PMTransaction_Class_obj.samplesizereading = 0;
                                    }
                                    else
                                    {
                                        PMTransaction_Class_obj.samplesizereading = Convert.ToInt32(dgAllTests["SampleSizeReading", i].Value);
                                    }
                                    PMTransaction_Class_obj.aqlreading = dgAllTests["AQLReading", i].Value.ToString();
                                    PMTransaction_Class_obj.aqlzreading = dgAllTests["AQLZReading", i].Value.ToString();
                                    PMTransaction_Class_obj.aqlcreading = dgAllTests["AQLCReading", i].Value.ToString();
                                    PMTransaction_Class_obj.aqlmreading = dgAllTests["AQLMReading", i].Value.ToString();
                                    PMTransaction_Class_obj.aqlm1reading = dgAllTests["AQLM1Reading", i].Value.ToString();

                                    PMTransaction_Class_obj.Insert_tblPMFGTestMethodDetails();
                                }

                                //--------------Save Periodic Tests
                                for (int i = 0; i < dgAllTestsP.Rows.Count; i++)
                                {
                                    //FinishedGoodTest_Class_Obj.pkgtechno = 
                                    PMTransaction_Class_obj.testname = dgAllTestsP["TestMethodP", i].Value.ToString();
                                    PMTransaction_Class_obj.inspectionmethod = dgAllTestsP["InspectionMethodP", i].Value.ToString();
                                    PMTransaction_Class_obj.frequency = dgAllTestsP["FrequencyP", i].Value.ToString();
                                    //FinishedGoodTest_Class_Obj.type 
                                    PMTransaction_Class_obj.lotsize = dgAllTestsP["LotSizeP", i].Value.ToString();

                                    PMTransaction_Class_obj.fgmethodno = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_FGMethodNo();

                                    //Insert standard reading in tblPMFGTestMethoddetails(Transaction level)
                                    if (dgAllTestsP["SampleSizeStandardP", i].Value.ToString() == "")
                                    {
                                        PMTransaction_Class_obj.samplesize = 0;
                                    }
                                    else
                                    {
                                        PMTransaction_Class_obj.samplesize = Convert.ToInt32(dgAllTestsP["SampleSizeStandardP", i].Value);
                                    }
                                    PMTransaction_Class_obj.aql = dgAllTestsP["AQLStandardP", i].Value.ToString();
                                    PMTransaction_Class_obj.aqlz = dgAllTestsP["AQLzStandardP", i].Value.ToString();
                                    PMTransaction_Class_obj.aqlc = dgAllTestsP["AQLcStandardP", i].Value.ToString();
                                    PMTransaction_Class_obj.aqlm = dgAllTestsP["AQLMStandardP", i].Value.ToString();
                                    PMTransaction_Class_obj.aqlm1 = dgAllTestsP["AQLM1StandardP", i].Value.ToString();


                                    if (dgAllTestsP["SampleSizeReadingP", i].Value.ToString() == "")
                                    {
                                        PMTransaction_Class_obj.samplesizereading = 0;
                                    }
                                    else
                                    {
                                        PMTransaction_Class_obj.samplesizereading = Convert.ToInt32(dgAllTestsP["SampleSizeReadingP", i].Value);
                                    }
                                    PMTransaction_Class_obj.aqlreading = dgAllTestsP["AQLReadingP", i].Value.ToString();
                                    PMTransaction_Class_obj.aqlzreading = dgAllTestsP["AQLZReadingP", i].Value.ToString();
                                    PMTransaction_Class_obj.aqlcreading = dgAllTestsP["AQLCReadingP", i].Value.ToString();
                                    PMTransaction_Class_obj.aqlmreading = dgAllTestsP["AQLMReadingP", i].Value.ToString();
                                    PMTransaction_Class_obj.aqlm1reading = dgAllTestsP["AQLM1ReadingP", i].Value.ToString();

                                    PMTransaction_Class_obj.Insert_tblPMFGTestMethodDetails();
                                }
                            }
                        }
                    }
                }

                //Insert TransID & Dimension para statusID
                DataTable dt = new DataTable();
                foreach (long i in GlobalVariables.lstStatusID)
                {
                    PMTransaction_Class_obj.dpTransStatusID = i;
                    dt = PMTransaction_Class_obj.Select_DimensionStatusPMTransRelation();
                    // If PMTransID & Status ID already exist do not insert new record 
                    if (dt.Rows.Count <= 0)
                        PMTransaction_Class_obj.Insert_DimensionStatusPMTransRelation();
                }
                if (GlobalVariables.City.ToLower() == "pune")
                {
                    if (PMTransaction_Class_obj.cocapplicable == "N")
                    {
                        bool ChangeCOC = false; DataSet ds = new DataSet();
                        ds = PMTransaction_Class_obj.Select_LastTen_DefectObserved();
                        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {

                            if (ds.Tables[0].Rows.Count == 10)
                            {
                                ChangeCOC = true;
                                foreach (DataRow dr in ds.Tables[0].Rows)
                                {
                                    if (dr["DefectObserved"].ToString() == "Y")
                                    {
                                        ChangeCOC = false;
                                        break;
                                    }

                                }
                                if (ChangeCOC)
                                {
                                    //PMTransaction_Class_obj.pmsuppliercocid = Convert.ToInt64(CmbDetails.SelectedValue.ToString());
                                    PMTransaction_Class_obj.cocapplicable = "Y";
                                    PMTransaction_Class_obj.Update_tblPMSupplierCOC_COCApplicable();
                                    PMTransaction_Class_obj.Insert_tblPMCOCHistory();

                                }
                            }
                        }


                    }
                }
                MessageBox.Show("Record Saved Successfully..!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                BtnReset_Click(sender, e);

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
                if ((CmbDetails.Text == "--Select--" || CmbDetails.SelectedValue == null || CmbDetails.SelectedValue.ToString() == ""))
                {
                    MessageBox.Show("Please Select Details ...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CmbDetails.Focus();
                    return;
                }

                PMTransaction_Class_obj.pmtransid = Convert.ToInt64(CmbDetails.SelectedValue.ToString());

                if (MessageBox.Show("Are You sure want to delete?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                else
                {
                    bool b = PMTransaction_Class_obj.Delete_tblPMTransaction();
                    if (b == true)
                    {
                        MessageBox.Show("Record deleted Succesfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Bind_Details();
                        BtnReset_Click(sender, e);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Sorry you Can't Delete this Record", "Messages", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            Bind_Details();
            resetall();
        }

        private void txtQtySampled_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&
                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&
                 e.KeyChar != 9)
            {
                e.Handled = true;
            }
        }

        private void txtNoofPalettes_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&
                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&
                 e.KeyChar != 9)
            {
                e.Handled = true;
            }
        }

        private void txtNoofShippers_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&
                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&
                 e.KeyChar != 9)
            {
                e.Handled = true;
            }
        }

        private void cmbDetectObserved_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDefectObserved.SelectedItem.ToString() != "Yes")
            {
                foreach (DataGridViewRow dr in dgDefect.Rows)
                {
                    if (dr.Cells["PMDefectID"].Value == null || Convert.ToString(dr.Cells["PMDefectID"].Value) == "")
                        if (!dr.IsNewRow)
                            dgDefect.Rows.Remove(dr);
                }
                dgDefect.AllowUserToAddRows = false;
                txtNoOfDefect.Enabled = false;
                txtNoOfDefect.Text = "";
            }
            else
            {
                dgDefect.AllowUserToAddRows = true;
                txtNoOfDefect.Enabled = true;
            }
        }

        private void txtNoOfDefect_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&
                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&
                 e.KeyChar != 9)
            {
                e.Handled = true;
            }
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgAllTests_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    if (e.ColumnIndex == dgAllTests.Columns["TestMethod"].Index)
                    {

                        PMTestMaster_Class PMTestMaster_Class_obj = new PMTestMaster_Class();
                        DataSet ds = new DataSet();
                        long TransID = 0;
                        PMTestMaster_Class_obj.testno = Convert.ToInt64(dgAllTests["TestNo", e.RowIndex].Value);
                        ds = PMTestMaster_Class_obj.Select_PMFGTestMaster_TestNo();

                        if (ds.Tables[0].Rows[0]["DimensionTest"].ToString() != "")
                        {
                            if (Convert.ToBoolean(ds.Tables[0].Rows[0]["DimensionTest"]) == true)
                            {
                                if (CmbDetails.SelectedValue != null)
                                    TransID = Convert.ToInt64(CmbDetails.SelectedValue);

                                //FrmDimensionTransaction obj = new FrmDimensionTransaction(TransID, PMTestMaster_Class_obj.testno, Convert.ToInt64(dgAllTests["SampleSizeStandard", e.RowIndex].Value));
                                //obj.ShowDialog();
                                FrmDimensionTransaction obj = new FrmDimensionTransaction(TransID, PMTestMaster_Class_obj.testno, Convert.ToInt64(dgAllTests["SampleSizeStandard", e.RowIndex].Value), RdoAccept);
                                obj.ShowDialog();

                            }
                            else
                                MessageBox.Show("Dimension Test Not applicable", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                            MessageBox.Show("Dimension Test Not applicable", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgAllTestsP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == dgAllTestsP.Columns["TestMethodP"].Index)
                {

                    PMTestMaster_Class PMTestMaster_Class_obj = new PMTestMaster_Class();
                    DataSet ds = new DataSet();
                    long TransID = 0;
                    PMTestMaster_Class_obj.testno = Convert.ToInt64(dgAllTestsP["TestNoP", e.RowIndex].Value);
                    ds = PMTestMaster_Class_obj.Select_PMFGTestMaster_TestNo();

                    if (ds.Tables[0].Rows[0]["DimensionTest"].ToString() != "")
                    {
                        if (Convert.ToBoolean(ds.Tables[0].Rows[0]["DimensionTest"]) == true)
                        {
                            if (CmbDetails.SelectedValue != null)
                                TransID = Convert.ToInt64(CmbDetails.SelectedValue);

                            FrmDimensionTransaction obj = new FrmDimensionTransaction(TransID, PMTestMaster_Class_obj.testno, Convert.ToInt64(dgAllTestsP["SampleSizeStandardP", e.RowIndex].Value));
                            obj.ShowDialog();
                        }
                        else
                            MessageBox.Show("Dimension Test Not applicable", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        MessageBox.Show("Dimension Test Not applicable", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}





