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
using System.Collections;

namespace QTMS.Transactions
{
    public partial class FrmPMTransaction : System.Windows.Forms.Form
    {
        public FrmPMTransaction()
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

        // variables for printing a gridview.
        //StringFormat strFormat; //Used to format the grid rows.
        //ArrayList arrColumnLefts = new ArrayList();//Used to save left coordinates of columns
        //ArrayList arrColumnWidths = new ArrayList();//Used to save column widths
        //int iCellHeight = 0; //Used to get/set the datagridview cell height
        //int iTotalWidth = 0; //
        //int iRow = 0;//Used as counter
        //bool bFirstPage = false; //Used to check whether we are printing first page
        //bool bNewPage = false;// Used to check whether we are printing a new page
        //int iHeaderHeight = 0; //Used for the header height
        //

        #endregion

        private static FrmPMTransaction frmPMTransaction_Obj = null;
        public static FrmPMTransaction GetInstance()
        {
            if (frmPMTransaction_Obj == null)
            {
                frmPMTransaction_Obj = new Transactions.FrmPMTransaction();
            }
            return frmPMTransaction_Obj;
        }

        private void FrmPMTransaction_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            Bind_Details();
            BtnReset_Click(sender, e);
            CmbDetails.Focus();

        }

        private void FrmPMTransaction_Resize(object sender, EventArgs e)
        {
            //if (this.WindowState == FormWindowState.Maximized)
            //{
            //    this.WindowState = FormWindowState.Normal;
            //    this.Dock = DockStyle.Fill;
            //}
        }

        public void Bind_Details()
        {
            try
            {
                DataSet ds = new DataSet();
                DataRow dr;
                ds = PMTransaction_Class_obj.Select_PMCodeMaster_PMSupplierMaster_PMSupplierCOC();
                dr = ds.Tables[0].NewRow();
                dr["Details"] = "--Select--";
                dr["PMSupplierCOCID"] = "0";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                CmbDetails.DataSource = ds.Tables[0];
                CmbDetails.DisplayMember = "Details";
                CmbDetails.ValueMember = "PMSupplierCOCID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void resetall()
        {
            txtLotNo.Text = "";
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

            cmbDefectObserved.SelectedIndex = 0;
            txtNoOfDefect.Enabled = false;
            txtNoOfDefect.Text = "";
            dgDefect.Enabled = false;
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
                if (CmbDetails.SelectedValue != null && CmbDetails.SelectedValue.ToString() != "" && CmbDetails.SelectedValue.ToString() != "0")
                {
                    //modified for PM code and supplier newly created then show Yes in first reception
                    DataSet ds1 = new DataSet();
                    PMTransaction_Class_obj.pmsupplcocid = Convert.ToInt64(CmbDetails.SelectedValue);
                    ds1 = PMTransaction_Class_obj.Check_PMTransaction();
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        cmbPMReception.SelectedIndex = 0;
                        cmbPMReception.Enabled = true;
                    }
                    else
                    {
                        cmbPMReception.SelectedIndex = 2;
                        cmbPMReception.Enabled = false;
                    }
                    PMTransaction_Class_obj.pmsuppliercocid = Convert.ToInt64(CmbDetails.SelectedValue);
                    DataSet ds = new DataSet();
                    ds = PMTransaction_Class_obj.Select_PMFGDetails();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        PMMaster_Class_obj.pmcodeid = Convert.ToInt64(ds.Tables[0].Rows[0]["PMCodeID"]);//Use this datset assign PMCodeID for use of to show test for specific PMcode ID
                        PMTransaction_Class_obj.pmfamilyid = Convert.ToInt64(ds.Tables[0].Rows[0]["PMFamilyID"]);
                        PMTransaction_Class_obj.cocapplicable = Convert.ToString(ds.Tables[0].Rows[0]["COCApplicable"]);
                        PMTransaction_Class_obj.cocfrequency = Convert.ToChar(ds.Tables[0].Rows[0]["COCFrequency"]);

                        if (ds.Tables[0].Rows[0]["CDCVersion"] is System.DBNull)
                        {
                            PMTransaction_Class_obj.cdcversion = "";
                        }
                        else
                        {
                            PMTransaction_Class_obj.cdcversion = ds.Tables[0].Rows[0]["CDCVersion"].ToString();
                        }
                    }
                    else
                    {
                        PMTransaction_Class_obj.pmfamilyid = 0;
                    }

                    DataSet dsPeriodic = new DataSet();
                    dsPeriodic = PMTransaction_Class_obj.Select_PeriodicTestingDone_PMSupplierCOCID();

                    if (dsPeriodic.Tables[0].Rows.Count > 0)
                    {
                        lblPeriodicDone.Text = "";

                    }
                    else
                    {
                        lblPeriodicDone.Text = "Periodic Testing is NOT DONE in this year";

                    }

                    //No of batches
                    //Calculated from the PMsupplierCOCID(PMCode + Supplier) only
                    long cnt = PMTransaction_Class_obj.Select_tblPMTransaction_NoBatches();
                    cnt = cnt + 1;
                    txtNoofBatches.Text = Convert.ToString(cnt);


                    //GET CONTROL TYPE FROM STP_Decide_ControlType STORED PROCEDURE
                    //2/5 LOGIC
                    txtControltype.Text = PMTransaction_Class_obj.Decide_ControlType_PM();
                    PMTransaction_Class_obj.type = txtControltype.Text.Trim();

                    if (PMTransaction_Class_obj.cocapplicable == "N")
                    {
                        PMTransaction_Class_obj.transcoc = "N";
                        PMTransaction_Class_obj.analysisdone = 1;
                    }
                    else if (PMTransaction_Class_obj.cocapplicable == "Y")
                    {
                        PMTransaction_Class_obj.transcoc = "Y";

                        if (PMTransaction_Class_obj.type == "Reinforce")
                        {
                            PMTransaction_Class_obj.analysisdone = 1;
                        }
                        else if (PMTransaction_Class_obj.type == "Normal")
                        {
                            //Get Normal Count
                            PMTransaction_Class_obj.count = PMTransaction_Class_obj.Decide_TopNormalCount_PM();

                            if (PMTransaction_Class_obj.count % PMTransaction_Class_obj.cocfrequency == (PMTransaction_Class_obj.cocfrequency - 1))
                            {
                                PMTransaction_Class_obj.analysisdone = 1;
                            }
                            else
                            {
                                PMTransaction_Class_obj.analysisdone = 0;
                            }
                        }
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
                        //cmbPMReception.SelectedIndex = 2;
                        //cmbPMReception.Enabled = false;

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

            lblDisplay.Text = txtQtySampled.Text.ToString() + " " + "Samples are Collected From " + NoOfShippers.ToString() + " " + "Shippers" + " " + "of" + " " + noofpallets.ToString() + " " + "Pallets";
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
                lblDisplay.Text = txtQtySampled.Text.ToString() + " " + "Samples are Collected From " + NoOfShippers.ToString() + " " + "Shippers" + " " + "of" + " " + noofpallets.ToString() + " " + "Pallets";
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
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
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
            //RdoAWD.Visible = false;
            //RdoTreatment.Visible = false;
            //chkRejectComments.Visible = false;
            for (int i = 0; i < chkRejectComments.Items.Count; i++)
            {
                if (chkRejectComments.GetItemChecked(i) == true)
                {
                    chkRejectComments.SetItemChecked(i, false);
                }
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
                    Dt = PMMaster_Class_obj.Select_tblPMCodeFamilyTestRelation_PMCodeID();

                    if (Dt.Rows.Count > 0)
                    {
                        PMTransaction_Class_obj.pmcodeid = PMMaster_Class_obj.pmcodeid;
                        DataSet ds = new DataSet();
                        ds = PMTransaction_Class_obj.Select_View_PMFGMethodDetails_TestNo_TestName_PMCodeID();
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                dgAllTests.Rows.Add();

                                dgAllTests["TestNo", dgAllTests.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestNo"];
                                dgAllTests["TestMethod", dgAllTests.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestName"];
                                PMTransaction_Class_obj.testname = dgAllTests["TestMethod", dgAllTests.Rows.Count - 1].Value.ToString();

                                dgAllTests["TestDesc", dgAllTests.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestDesc"];

                                dsInspMethod = PMTransaction_Class_obj.Select_View_PMFGMethodDetails_InspectionMethod();

                                DataGridViewComboBoxCell combo = new DataGridViewComboBoxCell();
                                combo.DisplayMember = dsInspMethod.Tables[0].Columns["InspectionMethod"].ToString();
                                combo.Items.Add(dsInspMethod.Tables[0].Rows[0][0].ToString());
                                //for (int row = 0; row < dsInspMethod.Tables[0].Rows.Count; row++)
                                //{
                                //    combo.Items.Add(dsInspMethod.Tables[0].Rows[row][0].ToString());
                                //}
                                dgAllTests.Rows[i].Cells["InspectionMethod"] = combo;

                                DataSet dsReading;
                                dsReading = new DataSet();
                                PMTransaction_Class_obj.inspectionmethod = dsInspMethod.Tables[0].Rows[0][0].ToString();
                                PMTransaction_Class_obj.fgmethodno = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_FGMethodNo();

                                combo.Value = dsInspMethod.Tables[0].Rows[0][0].ToString();
                                dsAll = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_All();
                                DisplayDataGridView_All(dsAll, dgAllTests.Rows.Count - 1);
                                //for (int row = 0; row < dsInspMethod.Tables[0].Rows.Count; row++)
                                //{
                                //    dsReading = new DataSet();
                                //    PMTransaction_Class_obj.inspectionmethod = dsInspMethod.Tables[0].Rows[row][0].ToString();
                                //    PMTransaction_Class_obj.fgmethodno = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_FGMethodNo();

                                //    combo.Value = dsInspMethod.Tables[0].Rows[row][0].ToString();
                                //    dsAll = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_All();
                                //    DisplayDataGridView_All(dsAll, dgAllTests.Rows.Count - 1);
                                //}
                            }
                        }

                    }
                    else
                    {
                        DataSet ds = new DataSet();
                        ds = PMTransaction_Class_obj.Select_View_PMFGMethodDetails_TestNo_TestName();

                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                dgAllTests.Rows.Add();
                                dgAllTests["TestNo", dgAllTests.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestNo"];
                                dgAllTests["TestMethod", dgAllTests.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestName"];
                                PMTransaction_Class_obj.testname = dgAllTests["TestMethod", dgAllTests.Rows.Count - 1].Value.ToString();

                                dgAllTests["TestDesc", dgAllTests.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestDesc"];

                                dsInspMethod = PMTransaction_Class_obj.Select_View_PMFGMethodDetails_InspectionMethod();

                                DataGridViewComboBoxCell combo = new DataGridViewComboBoxCell();
                                combo.DisplayMember = dsInspMethod.Tables[0].Columns["InspectionMethod"].ToString();
                                combo.Items.Add(dsInspMethod.Tables[0].Rows[0][0].ToString());
                                //for (int row = 0; row < dsInspMethod.Tables[0].Rows.Count; row++)
                                //{
                                //    combo.Items.Add(dsInspMethod.Tables[0].Rows[row][0].ToString());
                                //}
                                dgAllTests.Rows[i].Cells["InspectionMethod"] = combo;

                                DataSet dsReading;
                                dsReading = new DataSet();
                                PMTransaction_Class_obj.inspectionmethod = dsInspMethod.Tables[0].Rows[0][0].ToString();
                                PMTransaction_Class_obj.fgmethodno = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_FGMethodNo();

                                combo.Value = dsInspMethod.Tables[0].Rows[0][0].ToString();
                                dsAll = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_All();
                                DisplayDataGridView_All(dsAll, dgAllTests.Rows.Count - 1);
                                //for (int row = 0; row < dsInspMethod.Tables[0].Rows.Count; row++)
                                //{
                                //    dsReading = new DataSet();
                                //    PMTransaction_Class_obj.inspectionmethod = dsInspMethod.Tables[0].Rows[row][0].ToString();
                                //    PMTransaction_Class_obj.fgmethodno = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_FGMethodNo();

                                //    combo.Value = dsInspMethod.Tables[0].Rows[row][0].ToString();
                                //    dsAll = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_All();
                                //    DisplayDataGridView_All(dsAll, dgAllTests.Rows.Count - 1);
                                //}
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
                    DataTable Dt = new DataTable();
                    Dt = PMMaster_Class_obj.Select_tblPMCodeFamilyTestRelation_PMCodeID();

                    if (Dt.Rows.Count > 0)
                    {
                        PMTransaction_Class_obj.pmcodeid = PMMaster_Class_obj.pmcodeid;
                        DataSet ds = new DataSet();
                        ds = PMTransaction_Class_obj.Select_View_PMFGMethodDetails_TestNo_TestName_PMCodeID();
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                dgAllTestsP.Rows.Add();
                                dgAllTestsP["TestNoP", dgAllTestsP.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestNo"];
                                dgAllTestsP["TestMethodP", dgAllTestsP.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestName"];
                                PMTransaction_Class_obj.testname = dgAllTestsP["TestMethodP", dgAllTestsP.Rows.Count - 1].Value.ToString();

                                dgAllTestsP["TestDescP", dgAllTestsP.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestDesc"];

                                dsInspMethod = PMTransaction_Class_obj.Select_View_PMFGMethodDetails_InspectionMethod();

                                DataGridViewComboBoxCell combo = new DataGridViewComboBoxCell();
                                combo.DisplayMember = dsInspMethod.Tables[0].Columns["InspectionMethod"].ToString();
                                combo.Items.Add(dsInspMethod.Tables[0].Rows[0][0].ToString());
                                //for (int row = 0; row < dsInspMethod.Tables[0].Rows.Count; row++)
                                //{
                                //    combo.Items.Add(dsInspMethod.Tables[0].Rows[row][0].ToString());
                                //}
                                dgAllTestsP.Rows[i].Cells["InspectionMethodP"] = combo;

                                DataSet dsReading;
                                dsReading = new DataSet();
                                PMTransaction_Class_obj.inspectionmethod = dsInspMethod.Tables[0].Rows[0][0].ToString();
                                PMTransaction_Class_obj.fgmethodno = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_FGMethodNo();

                                combo.Value = dsInspMethod.Tables[0].Rows[0][0].ToString();
                                dsAll = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_All();
                                DisplayDataGridView_All_Periodic(dsAll, dgAllTestsP.Rows.Count - 1);
                                //for (int row = 0; row < dsInspMethod.Tables[0].Rows.Count; row++)
                                //{
                                //    dsReading = new DataSet();
                                //    PMTransaction_Class_obj.inspectionmethod = dsInspMethod.Tables[0].Rows[row][0].ToString();
                                //    PMTransaction_Class_obj.fgmethodno = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_FGMethodNo();

                                //    combo.Value = dsInspMethod.Tables[0].Rows[row][0].ToString();
                                //    dsAll = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_All();
                                //    DisplayDataGridView_All_Periodic(dsAll, dgAllTestsP.Rows.Count - 1);
                                //}
                            }
                        }

                    }
                    else
                    {
                        DataSet ds = new DataSet();
                        ds = PMTransaction_Class_obj.Select_View_PMFGMethodDetails_TestNo_TestName();
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                dgAllTestsP.Rows.Add();
                                dgAllTestsP["TestNoP", dgAllTestsP.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestNo"];
                                dgAllTestsP["TestMethodP", dgAllTestsP.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestName"];
                                PMTransaction_Class_obj.testname = dgAllTestsP["TestMethodP", dgAllTestsP.Rows.Count - 1].Value.ToString();

                                dgAllTestsP["TestDescP", dgAllTestsP.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestDesc"];

                                dsInspMethod = PMTransaction_Class_obj.Select_View_PMFGMethodDetails_InspectionMethod();

                                DataGridViewComboBoxCell combo = new DataGridViewComboBoxCell();
                                combo.DisplayMember = dsInspMethod.Tables[0].Columns["InspectionMethod"].ToString();
                                combo.Items.Add(dsInspMethod.Tables[0].Rows[0][0].ToString());
                                //for (int row = 0; row < dsInspMethod.Tables[0].Rows.Count; row++)
                                //{
                                //    combo.Items.Add(dsInspMethod.Tables[0].Rows[row][0].ToString());
                                //}
                                dgAllTestsP.Rows[i].Cells["InspectionMethodP"] = combo;

                                DataSet dsReading;
                                dsReading = new DataSet();
                                PMTransaction_Class_obj.inspectionmethod = dsInspMethod.Tables[0].Rows[0][0].ToString();
                                PMTransaction_Class_obj.fgmethodno = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_FGMethodNo();

                                combo.Value = dsInspMethod.Tables[0].Rows[0][0].ToString();
                                dsAll = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_All();
                                DisplayDataGridView_All_Periodic(dsAll, dgAllTestsP.Rows.Count - 1);
                                //for (int row = 0; row < dsInspMethod.Tables[0].Rows.Count; row++)
                                //{
                                //    dsReading = new DataSet();
                                //    PMTransaction_Class_obj.inspectionmethod = dsInspMethod.Tables[0].Rows[row][0].ToString();
                                //    PMTransaction_Class_obj.fgmethodno = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_FGMethodNo();

                                //    combo.Value = dsInspMethod.Tables[0].Rows[row][0].ToString();
                                //    dsAll = PMTransaction_Class_obj.Select_PMFGTestMethodMaster_All();
                                //    DisplayDataGridView_All_Periodic(dsAll, dgAllTestsP.Rows.Count - 1);
                                //}
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

        private void DisplayDataGridView_All(DataSet dsAll, int rowIndex)
        {

            if (dsAll.Tables[0].Rows.Count > 0)
            {

                dgAllTests["Frequency", rowIndex].Value = dsAll.Tables[0].Rows[0]["frequency"];

                dgAllTests["LotSize", rowIndex].Value = dsAll.Tables[0].Rows[0]["lotsize"];

                dgAllTests["SampleSizeStandard", rowIndex].Value = dsAll.Tables[0].Rows[0]["samplesize"];

                //Set to blank
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
                    dgAllTestsP["AQLM1ReadingP", rowIndex].Value = "";

                    dgAllTestsP["AQLM1ReadingP", rowIndex].ReadOnly = false;
                    dgAllTestsP["AQLM1ReadingP", rowIndex].Style.BackColor = Color.White;
                }
            }
        }

        ComboBox cmb;
        private void dgAllTests_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgAllTests.CurrentCell.RowIndex < 0 || (dgAllTests.CurrentCell.ColumnIndex != dgAllTests.Columns["InspectionMethod"].Index
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
                    if (txtLotNo.Text == "")
                    {
                        MessageBox.Show("Please Enter Lot No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtLotNo.Focus();
                        return;
                    }
                    if (cmbType.Text == "--Select--")
                    {
                        MessageBox.Show("Select Regular/NewLaunch", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cmbType.Focus();
                        return;
                    }//chnaged by Sanjiv on 6-May 2014 for
                    //If new laungh-Ask for 1st reception date

                    if (cmbType.Text == "Launch" && cmbPMReception.Text != "Yes")
                    {
                        MessageBox.Show("Select 1st Reception Yes", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        cmbPMReception.Focus();
                        return;
                    }
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
                            MessageBox.Show("Please Enter No of Pallets", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    PMTransaction_Class_obj.pmsuppliercocid = Convert.ToInt64(CmbDetails.SelectedValue.ToString());
                    PMTransaction_Class_obj.plantlotno = txtLotNo.Text.ToString().Trim();
                    //PMTransaction_Class_obj.analysisdone 

                    DataSet dsP = new DataSet();
                    dsP = PMTransaction_Class_obj.Select_PMTransaction_PMTest_PMSupplierCOCID_PlantLotNo();
                    if (dsP.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("LotNo already exists", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    DataSet ds2 = new DataSet();
                    ds2 = PMTransaction_Class_obj.Select_PMTransaction_PMSupplierCOCID_PlantLotNo();
                    if (ds2.Tables[0].Rows.Count > 0)
                    {
                        PMTransaction_Class_obj.pmtransid = Convert.ToInt64(ds2.Tables[0].Rows[0]["PMTransID"]);
                    }
                    else
                    {
                        //PMTransaction_Class_obj.type   
                        //PMTransaction_Class_obj.transcoc
                        PMTransaction_Class_obj.pmtransid = 0;
                        PMTransaction_Class_obj.pmtransid = PMTransaction_Class_obj.Insert_PMTransaction();
                    }

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

                        PMTransaction_Class_obj.pmsamplingid = PMTransaction_Class_obj.Insert_PMSampling();

                        //---------Insert tblPMDetails                         
                        PMTransaction_Class_obj.specificationno = txtSpecificationNo.Text.ToString().Trim();
                        PMTransaction_Class_obj.challanno = txtChallanNo.Text.ToString().Trim();
                        PMTransaction_Class_obj.mrr = txtMRR.Text.ToString().Trim();
                        if (cmbSupplierReportReceived.SelectedIndex == 1)
                            PMTransaction_Class_obj.srr = Convert.ToString("N");
                        else if (cmbSupplierReportReceived.SelectedIndex == 2)
                            PMTransaction_Class_obj.srr = Convert.ToString("Y");
                        else
                            PMTransaction_Class_obj.srr = Convert.ToString("");

                        if (cmbType.SelectedIndex == 1)
                            PMTransaction_Class_obj.launchregular = Convert.ToString("L");
                        else if (cmbType.SelectedIndex == 2)
                            PMTransaction_Class_obj.launchregular = Convert.ToString("R");
                        else
                            PMTransaction_Class_obj.launchregular = Convert.ToString("");

                        if (cmbPMReception.SelectedIndex == 1)
                            PMTransaction_Class_obj.firstpmreception = Convert.ToString("N");
                        else if (cmbPMReception.SelectedIndex == 2)
                            PMTransaction_Class_obj.firstpmreception = Convert.ToString("Y");
                        else
                            PMTransaction_Class_obj.firstpmreception = Convert.ToString("");

                        PMTransaction_Class_obj.noofbatches = Convert.ToInt32(txtNoofBatches.Text.Trim());

                        bool b = PMTransaction_Class_obj.Insert_PMDetails();

                        //--------Insert tblPMTest                         

                        PMTransaction_Class_obj.accepteddate = Convert.ToString(DtpAcceptedDate.Value);
                        PMTransaction_Class_obj.receiptdate = Convert.ToString(DtpReceiptDate.Value);
                        PMTransaction_Class_obj.quantity = Convert.ToInt64(txtQuantity.Text.ToString());

                        PMTransaction_Class_obj.loginid = FrmMain.LoginID;

                        PMTransaction_Class_obj.pmtestid = 0;
                        PMTransaction_Class_obj.pmtestid = PMTransaction_Class_obj.Insert_PMTest();

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
                            PMTransaction_Class_obj.fromAnalysisReanalysis = 1; //This Flag shows records only in modification                          
                            PMTransaction_Class_obj.loginid = FrmMain.LoginID;

                            PMTransaction_Class_obj.pmchangeid = PMTransaction_Class_obj.Insert_PMStatus();

                            //IF Lot Rejected then update cocapplicable to 'N' for that PMCode and Supplier
                            if (PMTransaction_Class_obj.cocapplicable == "Y" && PMTransaction_Class_obj.status == "R")
                            {
                                if (MessageBox.Show("Lot is rejected.\nRemove from COC?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                                {
                                    PMTransaction_Class_obj.pmsuppliercocid = Convert.ToInt64(CmbDetails.SelectedValue.ToString());
                                    PMTransaction_Class_obj.cocapplicable = "N";
                                    PMTransaction_Class_obj.Update_tblPMSupplierCOC_COCApplicable();


                                }
                            }
                            //...........................................................

                            //....select coc status from tblPMTransaction - get second last record
                            //... insert in tblPMCOCHistory PMTranID,COCStatus,date
                            //........................... 
                            DataSet dsStatus = new DataSet();
                            // get coc from tblPMTransaction
                            dsStatus = PMTransaction_Class_obj.CheckCOCStatus_tblPMTransaction();
                            if (dsStatus.Tables[0].Rows.Count > 0)
                            {
                                //If tblPMTransaction-coc  dosent match with  tblPMSupplier-coc then insert
                                if (dsStatus.Tables[0].Rows[0]["TransCOC"].ToString() != PMTransaction_Class_obj.cocapplicable)
                                {
                                    PMTransaction_Class_obj.Insert_tblPMCOCHistory();
                                }
                            }
                            //else
                            //{
                            //    PMTransaction_Class_obj.Insert_tblPMCOCHistory();
                            //}

                            if (PMTransaction_Class_obj.pmchangeid != 0)
                            {
                                //----------Inser Defect
                                // If accept Automatically close the defect status
                                if (RdoAccept.Checked == true)
                                {
                                    for (int d = 0; d < dgDefect.Rows.Count; d++)
                                    {
                                        if (!dgDefect.Rows[d].IsNewRow)
                                        {
                                            dgDefect["DefectStatus", d].Value = "Close";
                                        }
                                    }
                                }
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
                            }
                        }
                    }

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
                                    PMTransaction_Class_obj.pmsuppliercocid = Convert.ToInt64(CmbDetails.SelectedValue.ToString());
                                    PMTransaction_Class_obj.cocapplicable = "Y";
                                    PMTransaction_Class_obj.Update_tblPMSupplierCOC_COCApplicable();
                                    PMTransaction_Class_obj.Insert_tblPMCOCHistory();

                                }
                            }
                        }


                    }
                }
                if (MessageBox.Show("Record Saved Successfully..!\n\nPrint Protocol?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                {
                    BtnProtocol_Click(sender, e);
                }

                BtnReset_Click(sender, e);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            Bind_Details();
            resetall();
        }

        private void txtLotNo_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtLotNo.Text = textInfo.ToTitleCase(txtLotNo.Text);
            PMTransaction_Class_obj.pmsuppliercocid = Convert.ToInt64(CmbDetails.SelectedValue);
            PMTransaction_Class_obj.plantlotno = txtLotNo.Text;
            DataSet dsDefect = PMTransaction_Class_obj.Select_PMTransaction_PMSupplierCOCID_PlantLotNo();
            if (dsDefect.Tables[0].Rows.Count > 0)
            {
                PMTransaction_Class_obj.pmtransid = Convert.ToInt64(dsDefect.Tables[0].Rows[0]["PMTransID"].ToString());
                dsDefect = PMTransaction_Class_obj.Select_STP_Select_PMDefect_PMTransID();
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

                        dgDefect["QualityDecision", d].Value = Convert.ToString(dsDefect.Tables[0].Rows[d]["QualityDecision"]);


                        DataSet dsDefStatus = PMTransaction_Class_obj.Select_tblSupplierCorrectiveNote_PMTrans_Status();
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
                    }
                }
                ///
            }

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
            try
            {
                if (cmbDefectObserved.SelectedItem.ToString() != "Yes")
                {
                    dgDefect.Enabled = false;
                    dgDefect.Rows.Clear();
                    txtNoOfDefect.Enabled = false;
                    txtNoOfDefect.Text = "";
                }
                else
                {
                    dgDefect.Enabled = true;
                    txtNoOfDefect.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
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

        private void BtnProtocol_Click(object sender, EventArgs e)
        {
            try
            {
                if (CmbDetails.Text == "--Select--")
                {
                    MessageBox.Show("Please Select Details", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CmbDetails.Focus();
                    return;
                }

                if (txtLotNo.Text == "")
                {
                    MessageBox.Show("Please Enter Plant Lot No", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtLotNo.Focus();
                    return;
                }

                PMTransaction_Class_obj.pmsuppliercocid = Convert.ToInt64(CmbDetails.SelectedValue.ToString());
                PMTransaction_Class_obj.plantlotno = txtLotNo.Text.ToString().Trim();

                DataSet ds2 = new DataSet();
                ds2 = PMTransaction_Class_obj.Select_PMTransaction_PMSupplierCOCID_PlantLotNo();
                if (ds2.Tables[0].Rows.Count > 0)
                {
                    PMTransaction_Class_obj.pmtransid = Convert.ToInt64(ds2.Tables[0].Rows[0]["PMTransID"]);
                }
                else
                {
                    PMTransaction_Class_obj.pmtransid = 0;
                    PMTransaction_Class_obj.pmtransid = PMTransaction_Class_obj.Insert_PMTransaction();
                }

                string ProtocolNo = "PM" + PMTransaction_Class_obj.pmtransid.ToString().PadLeft(6, '0');

                DataSet ds = new DataSet();
                ds = PMTransaction_Class_obj.Select_View_PMProtocol_Report();

                DataTable dt = new DataTable();
                dt.Columns.Add("TestMethod");
                dt.Columns.Add("Frequency");
                dt.Columns.Add("InspectionMethod");
                dt.Columns.Add("LotSize");
                dt.Columns.Add("SampleSizeStandard");
                dt.Columns.Add("SampleSizeReading");
                dt.Columns.Add("AQLStandard");
                dt.Columns.Add("AQLReading");
                dt.Columns.Add("AQLzStandard");
                dt.Columns.Add("AQLzReading");
                dt.Columns.Add("AQLcStandard");
                dt.Columns.Add("AQLcReading");
                dt.Columns.Add("AQLMStandard");
                dt.Columns.Add("AQLMReading");
                dt.Columns.Add("AQLM1Standard");
                dt.Columns.Add("AQLM1Reading");

                DataRow dr;
                for (int i = 0; i < dgAllTests.Rows.Count; i++)
                {
                    dr = dt.NewRow();
                    dr["TestMethod"] = dgAllTests["TestMethod", i].Value;
                    dr["Frequency"] = dgAllTests["Frequency", i].Value;
                    dr["InspectionMethod"] = dgAllTests["InspectionMethod", i].Value;
                    dr["LotSize"] = dgAllTests["LotSize", i].Value;
                    dr["SampleSizeStandard"] = dgAllTests["SampleSizeStandard", i].Value;
                    dr["SampleSizeReading"] = dgAllTests["SampleSizeReading", i].Value;
                    dr["AQLStandard"] = dgAllTests["AQLStandard", i].Value;
                    dr["AQLReading"] = dgAllTests["AQLReading", i].Value;
                    dr["AQLzStandard"] = dgAllTests["AQLzStandard", i].Value;
                    dr["AQLzReading"] = dgAllTests["AQLzReading", i].Value;
                    dr["AQLcStandard"] = dgAllTests["AQLcStandard", i].Value;
                    dr["AQLcReading"] = dgAllTests["AQLcReading", i].Value;
                    dr["AQLMStandard"] = dgAllTests["AQLMStandard", i].Value;
                    dr["AQLMReading"] = dgAllTests["AQLMReading", i].Value;
                    dr["AQLM1Standard"] = dgAllTests["AQLM1Standard", i].Value;
                    dr["AQLM1Reading"] = dgAllTests["AQLM1Reading", i].Value;
                    dt.Rows.InsertAt(dr, i);
                }
                for (int i = 0; i < dgAllTestsP.Rows.Count; i++)
                {
                    dr = dt.NewRow();
                    dr["TestMethod"] = dgAllTestsP["TestMethodP", i].Value;
                    dr["Frequency"] = dgAllTestsP["FrequencyP", i].Value;
                    dr["InspectionMethod"] = dgAllTestsP["InspectionMethodP", i].Value;
                    dr["LotSize"] = dgAllTestsP["LotSizeP", i].Value;
                    dr["SampleSizeStandard"] = dgAllTestsP["SampleSizeStandardP", i].Value;
                    dr["SampleSizeReading"] = dgAllTestsP["SampleSizeReadingP", i].Value;
                    dr["AQLStandard"] = dgAllTestsP["AQLStandardP", i].Value;
                    dr["AQLReading"] = dgAllTestsP["AQLReadingP", i].Value;
                    dr["AQLzStandard"] = dgAllTestsP["AQLzStandardP", i].Value;
                    dr["AQLzReading"] = dgAllTestsP["AQLzReadingP", i].Value;
                    dr["AQLcStandard"] = dgAllTestsP["AQLcStandardP", i].Value;
                    dr["AQLcReading"] = dgAllTestsP["AQLcReadingP", i].Value;
                    dr["AQLMStandard"] = dgAllTestsP["AQLMStandardP", i].Value;
                    dr["AQLMReading"] = dgAllTestsP["AQLMReadingP", i].Value;
                    dr["AQLM1Standard"] = dgAllTestsP["AQLM1StandardP", i].Value;
                    dr["AQLM1Reading"] = dgAllTestsP["AQLM1ReadingP", i].Value;
                    dt.Rows.InsertAt(dr, i);
                }
                QTMS.Reports_Forms.FrmPMProtocol fm = new QTMS.Reports_Forms.FrmPMProtocol("PMProtocol", ds, CmbDetails.Text.ToString(), txtLotNo.Text.ToString(), dt, txtQuantity.Text.ToString(), DtpAcceptedDate.Value.ToShortDateString(), ProtocolNo, txtMRR.Text.ToString(), txtSpecificationNo.Text.ToString(), txtControltype.Text.ToString(), txtChallanNo.Text.ToString());
                fm.ShowDialog();

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

        private void dgDefect_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgDefect.CurrentRow != null)
                {
                    if (!dgDefect.CurrentRow.IsNewRow)
                    {
                        if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
                        {
                            dgDefect.CurrentRow.Cells["ActionTaken"].Value = "Other";
                            dgDefect.CurrentRow.Cells["QualityDecision"].Value = "Other";
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                //throw;
            }
        }
        // For Dimension Parameter
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
                        long supplierCOCID = 0;
                        PMTestMaster_Class_obj.testno = Convert.ToInt64(dgAllTests["TestNo", e.RowIndex].Value);
                        ds = PMTestMaster_Class_obj.Select_PMFGTestMaster_TestNo();

                        if (ds.Tables[0].Rows[0]["DimensionTest"].ToString() != "")
                        {
                            if (Convert.ToBoolean(ds.Tables[0].Rows[0]["DimensionTest"]) == true)
                            {
                                if (CmbDetails.SelectedValue != null)
                                    supplierCOCID = Convert.ToInt64(CmbDetails.SelectedValue);
                                //PMTransaction_Class_obj.plantlotno = txtLotNo.Text.ToString().Trim();
                                //DataSet ds2=new DataSet();
                                //ds2 = PMTransaction_Class_obj.Select_PMTransaction_PMSupplierCOCID_PlantLotNo();
                                //if (ds2.Tables[0].Rows.Count > 0)
                                //{
                                //    PMTransaction_Class_obj.pmtransid = Convert.ToInt64(ds2.Tables[0].Rows[0]["PMTransID"]);
                                //}
                                PMTransaction_Class_obj.pmsuppliercocid = Convert.ToInt64(CmbDetails.SelectedValue.ToString());
                                PMTransaction_Class_obj.plantlotno = txtLotNo.Text.ToString().Trim();

                                DataSet ds2 = new DataSet();
                                ds2 = PMTransaction_Class_obj.Select_PMTransaction_PMSupplierCOCID_PlantLotNo();
                                if (ds2.Tables[0].Rows.Count > 0)
                                {
                                    PMTransaction_Class_obj.pmtransid = Convert.ToInt64(ds2.Tables[0].Rows[0]["PMTransID"]);
                                }
                                else
                                {
                                    PMTransaction_Class_obj.pmtransid = 0;
                                    PMTransaction_Class_obj.pmtransid = PMTransaction_Class_obj.Insert_PMTransaction();
                                }

                                string ProtocolNo = "PM" + PMTransaction_Class_obj.pmtransid.ToString().PadLeft(6, '0');

                                FrmDimensionTransaction obj = new FrmDimensionTransaction(supplierCOCID, PMTransaction_Class_obj.pmcodeid, PMTestMaster_Class_obj.testno, Convert.ToInt64(dgAllTests["SampleSizeStandard", e.RowIndex].Value), RdoAccept);
                                obj.ProtocolNo = ProtocolNo;
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
                    long supplierCOCID = 0;
                    PMTestMaster_Class_obj.testno = Convert.ToInt64(dgAllTestsP["TestNoP", e.RowIndex].Value);
                    ds = PMTestMaster_Class_obj.Select_PMFGTestMaster_TestNo();

                    if (ds.Tables[0].Rows[0]["DimensionTest"].ToString() != "")
                    {
                        if (Convert.ToBoolean(ds.Tables[0].Rows[0]["DimensionTest"]) == true)
                        {
                            if (CmbDetails.SelectedValue != null)
                                supplierCOCID = Convert.ToInt64(CmbDetails.SelectedValue);
                            //PMTransaction_Class_obj.plantlotno = txtLotNo.Text.ToString().Trim();
                            //DataSet ds2=new DataSet();
                            //ds2 = PMTransaction_Class_obj.Select_PMTransaction_PMSupplierCOCID_PlantLotNo();
                            //if (ds2.Tables[0].Rows.Count > 0)
                            //{
                            long a = PMTransaction_Class_obj.pmtransid;//= Convert.ToInt64(ds2.Tables[0].Rows[0]["PMTransID"]);
                            //}
                            FrmDimensionTransaction obj = new FrmDimensionTransaction(supplierCOCID, PMTransaction_Class_obj.pmcodeid, PMTestMaster_Class_obj.testno, Convert.ToInt64(dgAllTestsP["SampleSizeStandardP", e.RowIndex].Value));
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

        private void txtQuantity_Leave(object sender, EventArgs e)
        {
            txtQuantity_KeyPress(sender, new KeyPressEventArgs(Convert.ToChar(Keys.Enter)));
        }
    }
}





