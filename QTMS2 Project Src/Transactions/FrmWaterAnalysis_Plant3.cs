using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Threading;
using QTMS.Tools;

namespace QTMS.Transactions
{
    public partial class FrmWaterAnalysis_Plant3 : Form
    {
        public FrmWaterAnalysis_Plant3()
        {
            InitializeComponent();
        }
        # region Varibles
        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        BusinessFacade.Transactions.WaterAnalysis_Class WaterAnalysis_Class_Obj = new BusinessFacade.Transactions.WaterAnalysis_Class();
        BusinessFacade.UserManagement_Class UserManagement_Class_Obj = new BusinessFacade.UserManagement_Class();

        # endregion
        private static FrmWaterAnalysis_Plant3 frmWaterAnalysis_Plant3_Obj = null;
        public static FrmWaterAnalysis_Plant3 GetInstance()
        {
            if (frmWaterAnalysis_Plant3_Obj == null)
            {
                frmWaterAnalysis_Plant3_Obj = new FrmWaterAnalysis_Plant3();
            }
            return frmWaterAnalysis_Plant3_Obj;
        }
        private void FrmWaterAnalysis_Plant3_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            Bind_InspectedBy();
            BtnReset_Click(sender, e);
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
        private void DtpSamplingDate_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                reset();

                if (DtpSamplingDate.Checked == true)
                {
                    // Micro Water analysis done on Monday & Friday Only so water analysis entry blocked for other days
                    if (Convert.ToString(DtpSamplingDate.Value.DayOfWeek) == "Monday" || Convert.ToString(DtpSamplingDate.Value.DayOfWeek) == "Friday")
                    {
                        //lblNorms.Visible = true;
                        txtNorms.Enabled = true;
                        //lblAmountOfWaterFiltered.Visible = true;
                        txtAmtWaterFiltered.Enabled = true;
                        //lblMediaLotNo.Visible = true;
                        txtMediaLotNo.Enabled = true;
                        pnlMicroSamplingDetails.Enabled = true;
                    }
                    else
                    {
                        //lblNorms.Visible = true;
                        txtNorms.Enabled = false;
                        //lblAmountOfWaterFiltered.Visible = true;
                        txtAmtWaterFiltered.Enabled = false;
                        //lblMediaLotNo.Visible = true;
                        txtMediaLotNo.Enabled = false;
                        pnlMicroSamplingDetails.Enabled = false;
                    }

                    #region Water Analysis
                    DataSet ds = new DataSet();
                    WaterAnalysis_Class_Obj.dateofsampling = DtpSamplingDate.Value.ToShortDateString();
                    ds = WaterAnalysis_Class_Obj.Select_tblWaterAnalysis_DateOfsampling();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        WaterAnalysis_Class_Obj.wano = Convert.ToInt64(ds.Tables[0].Rows[0]["WANo"]);

                        txtMediaLotNo.Text = ds.Tables[0].Rows[0]["MediaLotNo"].ToString();
                        txtNorms.Text = ds.Tables[0].Rows[0]["Norms"].ToString();
                        txtAmtWaterFiltered.Text = ds.Tables[0].Rows[0]["AmtWaterFiltered"].ToString();
                        //DtpSamplingDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["DateOfSampling"]);

                        if (ds.Tables[0].Rows[0]["Status"].ToString() == "C")
                        {
                            RdoConfirming.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["Status"].ToString() == "N")
                        {
                            RdoNonConfirming.Checked = true;
                        }
                        else if (ds.Tables[0].Rows[0]["Status"].ToString() == "H")
                        {
                            RdoHold.Checked = true;
                        }

                        txtComment.Text = ds.Tables[0].Rows[0]["Comment"].ToString();
                        cmbInspectedBy.SelectedValue = Convert.ToInt32(ds.Tables[0].Rows[0]["InspectedBy"]);

                        DataSet dsSamp;
                        for (int i = 1; i <= 4; i++)
                        {
                            if (i == 1)
                            {
                                WaterAnalysis_Class_Obj.samplingpoint = 1;
                                dsSamp = new DataSet();
                                dsSamp = WaterAnalysis_Class_Obj.Select_tblWaterAnalysisSampling_WANo_SamplingPoint();
                                if (dsSamp.Tables[0].Rows.Count > 0)
                                {
                                    if (dsSamp.Tables[0].Rows[0]["StartTime"] is DBNull)
                                    {

                                    }
                                    else
                                    {
                                        DtpStartTime1.Value = Convert.ToDateTime(dsSamp.Tables[0].Rows[0]["StartTime"]);
                                    }
                                    if (dsSamp.Tables[0].Rows[0]["FinishTime"] is DBNull)
                                    {

                                    }
                                    else
                                    {
                                        DtpFinishTime1.Value = Convert.ToDateTime(dsSamp.Tables[0].Rows[0]["FinishTime"]);
                                    }
                                    if (dsSamp.Tables[0].Rows[0]["AnalysisDate"] is DBNull)
                                    {

                                    }
                                    else
                                    {
                                        DtpAnalysisDate1.Value = Convert.ToDateTime(dsSamp.Tables[0].Rows[0]["AnalysisDate"]);
                                    }
                                    if (dsSamp.Tables[0].Rows[0]["AnalysisTime"] is DBNull)
                                    {

                                    }
                                    else
                                    {
                                        DtpAnalysisTime1.Value = Convert.ToDateTime(dsSamp.Tables[0].Rows[0]["AnalysisTime"]);
                                    }
                                    if (dsSamp.Tables[0].Rows[0]["ResultDate"] is DBNull)
                                    {

                                    }
                                    else
                                    {
                                        DtpResultDate1.Value = Convert.ToDateTime(dsSamp.Tables[0].Rows[0]["ResultDate"]);
                                    }
                                    if (dsSamp.Tables[0].Rows[0]["ResultTime"] is DBNull)
                                    {

                                    }
                                    else
                                    {
                                        DtpResultTime1.Value = Convert.ToDateTime(dsSamp.Tables[0].Rows[0]["ResultTime"]);
                                    }
                                    if (dsSamp.Tables[0].Rows[0]["Result"] is DBNull)
                                    {

                                    }
                                    else
                                    {
                                        cmbResult1.Text = dsSamp.Tables[0].Rows[0]["Result"].ToString();
                                    }
                                    if (dsSamp.Tables[0].Rows[0]["CFUML"].ToString() == "0")
                                    {

                                    }
                                    else
                                    {
                                        txtCFUML1.Text = dsSamp.Tables[0].Rows[0]["CFUML"].ToString();
                                    }
                                    txtIncubTemp.Text = dsSamp.Tables[0].Rows[0]["IncubTemp"].ToString();
                                }
                            }
                            if (i == 2)
                            {
                                WaterAnalysis_Class_Obj.samplingpoint = 2;
                                dsSamp = new DataSet();
                                dsSamp = WaterAnalysis_Class_Obj.Select_tblWaterAnalysisSampling_WANo_SamplingPoint();
                                if (dsSamp.Tables[0].Rows.Count > 0)
                                {
                                    if (dsSamp.Tables[0].Rows[0]["StartTime"] is DBNull)
                                    {

                                    }
                                    else
                                    {
                                        DtpStartTime2.Value = Convert.ToDateTime(dsSamp.Tables[0].Rows[0]["StartTime"]);
                                    }
                                    if (dsSamp.Tables[0].Rows[0]["FinishTime"] is DBNull)
                                    {

                                    }
                                    else
                                    {
                                        DtpFinishTime2.Value = Convert.ToDateTime(dsSamp.Tables[0].Rows[0]["FinishTime"]);
                                    }
                                    if (dsSamp.Tables[0].Rows[0]["AnalysisDate"] is DBNull)
                                    {

                                    }
                                    else
                                    {
                                        DtpAnalysisDate2.Value = Convert.ToDateTime(dsSamp.Tables[0].Rows[0]["AnalysisDate"]);
                                    }
                                    if (dsSamp.Tables[0].Rows[0]["AnalysisTime"] is DBNull)
                                    {

                                    }
                                    else
                                    {
                                        DtpAnalysisTime2.Value = Convert.ToDateTime(dsSamp.Tables[0].Rows[0]["AnalysisTime"]);
                                    }
                                    if (dsSamp.Tables[0].Rows[0]["ResultDate"] is DBNull)
                                    {

                                    }
                                    else
                                    {
                                        DtpResultDate2.Value = Convert.ToDateTime(dsSamp.Tables[0].Rows[0]["ResultDate"]);
                                    }
                                    if (dsSamp.Tables[0].Rows[0]["ResultTime"] is DBNull)
                                    {

                                    }
                                    else
                                    {
                                        DtpResultTime2.Value = Convert.ToDateTime(dsSamp.Tables[0].Rows[0]["ResultTime"]);
                                    }
                                    if (dsSamp.Tables[0].Rows[0]["Result"] is DBNull)
                                    {

                                    }
                                    else
                                    {
                                        cmbResult2.Text = dsSamp.Tables[0].Rows[0]["Result"].ToString();
                                    }
                                    if (dsSamp.Tables[0].Rows[0]["CFUML"].ToString() == "0")
                                    {

                                    }
                                    else
                                    {
                                        txtCFUML2.Text = dsSamp.Tables[0].Rows[0]["CFUML"].ToString();
                                    }
                                    txtIncubTemp.Text = dsSamp.Tables[0].Rows[0]["IncubTemp"].ToString();
                                }
                            }
                            if (i == 3)
                            {
                                WaterAnalysis_Class_Obj.samplingpoint = 3;
                                dsSamp = new DataSet();
                                dsSamp = WaterAnalysis_Class_Obj.Select_tblWaterAnalysisSampling_WANo_SamplingPoint();
                                if (dsSamp.Tables[0].Rows.Count > 0)
                                {
                                    if (dsSamp.Tables[0].Rows[0]["StartTime"] is DBNull)
                                    {

                                    }
                                    else
                                    {
                                        DtpStartTime3.Value = Convert.ToDateTime(dsSamp.Tables[0].Rows[0]["StartTime"]);
                                    }
                                    if (dsSamp.Tables[0].Rows[0]["FinishTime"] is DBNull)
                                    {

                                    }
                                    else
                                    {
                                        DtpFinishTime3.Value = Convert.ToDateTime(dsSamp.Tables[0].Rows[0]["FinishTime"]);
                                    }
                                    if (dsSamp.Tables[0].Rows[0]["AnalysisDate"] is DBNull)
                                    {

                                    }
                                    else
                                    {
                                        DtpAnalysisDate3.Value = Convert.ToDateTime(dsSamp.Tables[0].Rows[0]["AnalysisDate"]);
                                    }
                                    if (dsSamp.Tables[0].Rows[0]["AnalysisTime"] is DBNull)
                                    {

                                    }
                                    else
                                    {
                                        DtpAnalysisTime3.Value = Convert.ToDateTime(dsSamp.Tables[0].Rows[0]["AnalysisTime"]);
                                    }
                                    if (dsSamp.Tables[0].Rows[0]["ResultDate"] is DBNull)
                                    {

                                    }
                                    else
                                    {
                                        DtpResultDate3.Value = Convert.ToDateTime(dsSamp.Tables[0].Rows[0]["ResultDate"]);
                                    }
                                    if (dsSamp.Tables[0].Rows[0]["ResultTime"] is DBNull)
                                    {

                                    }
                                    else
                                    {
                                        DtpResultTime3.Value = Convert.ToDateTime(dsSamp.Tables[0].Rows[0]["ResultTime"]);
                                    }
                                    if (dsSamp.Tables[0].Rows[0]["Result"] is DBNull)
                                    {

                                    }
                                    else
                                    {
                                        cmbResult3.Text = dsSamp.Tables[0].Rows[0]["Result"].ToString();
                                    }
                                    if (dsSamp.Tables[0].Rows[0]["CFUML"].ToString() == "0")
                                    {

                                    }
                                    else
                                    {
                                        txtCFUML3.Text = dsSamp.Tables[0].Rows[0]["CFUML"].ToString();
                                    }
                                    txtIncubTemp.Text = dsSamp.Tables[0].Rows[0]["IncubTemp"].ToString();
                                }
                            }
                            if (i == 4)
                            {
                                WaterAnalysis_Class_Obj.samplingpoint = 4;
                                dsSamp = new DataSet();
                                dsSamp = WaterAnalysis_Class_Obj.Select_tblWaterAnalysisSampling_WANo_SamplingPoint();
                                if (dsSamp.Tables[0].Rows.Count > 0)
                                {
                                    if (dsSamp.Tables[0].Rows[0]["StartTime"] is DBNull)
                                    {

                                    }
                                    else
                                    {
                                        DtpStartTime4.Value = Convert.ToDateTime(dsSamp.Tables[0].Rows[0]["StartTime"]);
                                    }
                                    if (dsSamp.Tables[0].Rows[0]["FinishTime"] is DBNull)
                                    {

                                    }
                                    else
                                    {
                                        DtpFinishTime4.Value = Convert.ToDateTime(dsSamp.Tables[0].Rows[0]["FinishTime"]);
                                    }
                                    if (dsSamp.Tables[0].Rows[0]["AnalysisDate"] is DBNull)
                                    {

                                    }
                                    else
                                    {
                                        DtpAnalysisDate4.Value = Convert.ToDateTime(dsSamp.Tables[0].Rows[0]["AnalysisDate"]);
                                    }
                                    if (dsSamp.Tables[0].Rows[0]["AnalysisTime"] is DBNull)
                                    {

                                    }
                                    else
                                    {
                                        DtpAnalysisTime4.Value = Convert.ToDateTime(dsSamp.Tables[0].Rows[0]["AnalysisTime"]);
                                    }
                                    if (dsSamp.Tables[0].Rows[0]["ResultDate"] is DBNull)
                                    {

                                    }
                                    else
                                    {
                                        DtpResultDate4.Value = Convert.ToDateTime(dsSamp.Tables[0].Rows[0]["ResultDate"]);
                                    }
                                    if (dsSamp.Tables[0].Rows[0]["ResultTime"] is DBNull)
                                    {

                                    }
                                    else
                                    {
                                        DtpResultTime4.Value = Convert.ToDateTime(dsSamp.Tables[0].Rows[0]["ResultTime"]);
                                    }
                                    if (dsSamp.Tables[0].Rows[0]["Result"] is DBNull)
                                    {

                                    }
                                    else
                                    {
                                        cmbResult4.Text = dsSamp.Tables[0].Rows[0]["Result"].ToString();
                                    }
                                    if (dsSamp.Tables[0].Rows[0]["CFUML"].ToString() == "0")
                                    {

                                    }
                                    else
                                    {
                                        txtCFUML4.Text = dsSamp.Tables[0].Rows[0]["CFUML"].ToString();
                                    }
                                    txtIncubTemp.Text = dsSamp.Tables[0].Rows[0]["IncubTemp"].ToString();
                                }
                            }
                        }
                    }

                    #endregion

                    #region Physico Chemical Water Analysis
                    DataSet dsPhyChemWA = new DataSet();
                    WaterAnalysis_Class_Obj.phyChemSamplingDate = Convert.ToDateTime(DtpSamplingDate.Value.ToShortDateString());
                    dsPhyChemWA = WaterAnalysis_Class_Obj.Select_tblPhysicoChemicalWaterAnalysis_DateOfsampling();
                    foreach (DataRow dr in dsPhyChemWA.Tables[0].Rows)
                    {
                        txtPHNorms.Text = Convert.ToString(dr["PHNorms"]);
                        txtPHResult.Text = Convert.ToString(dr["PHResult"]);
                        txtConductivity.Text = Convert.ToString(dr["Conductivity"]);
                        txtConductivityResult.Text = Convert.ToString(dr["ConductivityResult"]);
                        txtAspectNorms.Text = Convert.ToString(dr["AspectNorms"]);
                        cmbAspectResult.Text = Convert.ToString(dr["AspectResult"]);
                        txtOdorNorms.Text = Convert.ToString(dr["OdorNorms"]);
                        cmbOdorResult.Text = Convert.ToString(dr["OdorResult"]);
                        txtColorNorms.Text = Convert.ToString(dr["ColorNorms"]);
                        cmbColorResult.Text = Convert.ToString(dr["ColorResult"]);


                        if (Convert.ToString(dr["Status"]) == "C")
                        {
                            RdoConfirming.Checked = true;
                        }
                        else if (Convert.ToString(dr["Status"]) == "N")
                        {
                            RdoNonConfirming.Checked = true;
                        }
                        else if (Convert.ToString(dr["Status"]) == "H")
                        {
                            RdoHold.Checked = true;
                        }

                        txtComment.Text = Convert.ToString(dr["Comment"]);
                        cmbInspectedBy.SelectedValue = Convert.ToInt32(dr["InspectedBy"]);

                    }
                    #endregion

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void BtnReset_Click(object sender, EventArgs e)
        {
            DtpSamplingDate.Value = Comman_Class_Obj.Select_ServerDate();
            DtpSamplingDate.Checked = false;
            reset();  
        }
        public void reset()
        {
            txtMediaLotNo.Text = "";
            txtNorms.Text = "≤0.1 CFU/ML";
            txtAmtWaterFiltered.Text = "200 ML";

            DtpStartTime1.Value = Comman_Class_Obj.Select_ServerDate();
            DtpStartTime1.Checked = false;
            DtpStartTime2.Value = DtpStartTime1.Value;
            DtpStartTime2.Checked = false;
            DtpStartTime3.Value = DtpStartTime1.Value;
            DtpStartTime3.Checked = false;
            DtpStartTime4.Value = DtpStartTime1.Value;
            DtpStartTime4.Checked = false;

            DtpFinishTime1.Value = DtpStartTime1.Value.AddHours(1);
            DtpFinishTime1.Checked = false;
            DtpFinishTime2.Value = DtpStartTime2.Value.AddHours(1);
            DtpFinishTime2.Checked = false;
            DtpFinishTime3.Value = DtpStartTime3.Value.AddHours(1);
            DtpFinishTime3.Checked = false;
            DtpFinishTime4.Value = DtpStartTime4.Value.AddHours(1);
            DtpFinishTime4.Checked = false;

            DtpAnalysisDate1.Value = DtpStartTime1.Value;
            DtpAnalysisDate1.Checked = false;
            DtpAnalysisDate2.Value = DtpStartTime1.Value;
            DtpAnalysisDate2.Checked = false;
            DtpAnalysisDate3.Value = DtpStartTime1.Value;
            DtpAnalysisDate3.Checked = false;
            DtpAnalysisDate4.Value = DtpStartTime1.Value;
            DtpAnalysisDate4.Checked = false;

            DtpAnalysisTime1.Value = DtpStartTime1.Value;
            DtpAnalysisTime1.Checked = false;
            DtpAnalysisTime2.Value = DtpStartTime1.Value;
            DtpAnalysisTime2.Checked = false;
            DtpAnalysisTime3.Value = DtpStartTime1.Value;
            DtpAnalysisTime3.Checked = false;
            DtpAnalysisTime4.Value = DtpStartTime1.Value;
            DtpAnalysisTime4.Checked = false;

            DtpResultDate1.Value = DtpAnalysisTime1.Value.AddDays(3);
            DtpResultDate1.Checked = false;
            DtpResultDate2.Value = DtpAnalysisTime2.Value.AddDays(3);
            DtpResultDate2.Checked = false;
            DtpResultDate3.Value = DtpAnalysisTime3.Value.AddDays(3);
            DtpResultDate3.Checked = false;
            DtpResultDate4.Value = DtpAnalysisTime4.Value.AddDays(3);
            DtpResultDate4.Checked = false;

            DtpResultTime1.Value = DtpAnalysisTime1.Value;
            DtpResultTime1.Checked = false;
            DtpResultTime2.Value = DtpAnalysisTime2.Value;
            DtpResultTime2.Checked = false;
            DtpResultTime3.Value = DtpAnalysisTime3.Value;
            DtpResultTime3.Checked = false;
            DtpResultTime4.Value = DtpAnalysisTime4.Value;
            DtpResultTime4.Checked = false;

            cmbResult1.Text = "--Select--";
            cmbResult2.Text = "--Select--";
            cmbResult3.Text = "--Select--";
            cmbResult4.Text = "--Select--";

            txtCFUML1.Text = "";
            txtCFUML2.Text = "";
            txtCFUML3.Text = "";
            txtCFUML4.Text = "";

            txtIncubTemp.Text = "32 ± 2";
            RdoConfirming.Checked = true;
            txtComment.Text = "";

            cmbInspectedBy.Text = "--Select--";

            // Physico chemical water analysis
            txtPHNorms.Text = "";
            txtPHResult.Text = "";
            txtConductivity.Text = "";
            txtConductivityResult.Text = "";
            txtAspectNorms.Text = "";
            cmbAspectResult.Text = "OK";
            txtOdorNorms.Text = "";
            cmbOdorResult.Text = "OK";
            txtColorNorms.Text = "";
            cmbColorResult.Text = "OK";
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (DtpSamplingDate.Checked != true)
                {
                    MessageBox.Show("Select date of sampling", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DtpSamplingDate.Focus();
                    return;
                }


                //if (txtPHNorms.Text.Trim() == "")
                //{
                //    MessageBox.Show("Enter PH Norms value", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtPHNorms.Focus();
                //    return;
                //}
                //if (txtPHResult.Text.Trim() == "")
                //{
                //    MessageBox.Show("Enter PH Results value", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtPHResult.Focus();
                //    return;
                //}
                //if (txtConductivity.Text.Trim() == "")
                //{
                //    MessageBox.Show("Enter Conductivity value", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtConductivity.Focus();
                //    return;
                //}
                //if (txtConductivityResult.Text.Trim() == "")
                //{
                //    MessageBox.Show("Enter Conductivity Results value", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtConductivityResult.Focus();
                //    return;
                //}
                //if (txtAspectNorms.Text.Trim() == "")
                //{
                //    MessageBox.Show("Enter Aspect Norms value", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtAspectNorms.Focus();
                //    return;
                //}
                //if (cmbAspectResult.Text.Trim() == "")
                //{
                //    MessageBox.Show("Enter Aspect Result value", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    cmbAspectResult.Focus();
                //    return;
                //}
                //if (txtOdorNorms.Text.Trim() == "")
                //{
                //    MessageBox.Show("Enter Odor Norms value", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtOdorNorms.Focus();
                //    return;
                //}
                //if (cmbOdorResult.Text.Trim() == "")
                //{
                //    MessageBox.Show("Enter Odor Result value", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    cmbOdorResult.Focus();
                //    return;
                //}
                //if (txtColorNorms.Text.Trim() == "")
                //{
                //    MessageBox.Show("Enter Color Norms value", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    txtColorNorms.Focus();
                //    return;
                //}
                //if (cmbColorResult.Text.Trim() == "")
                //{
                //    MessageBox.Show("Enter Color Result value", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    cmbColorResult.Focus();
                //    return;
                //}

                if (cmbInspectedBy.Text == "--Select--")
                {
                    MessageBox.Show("Select Inspected By", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbInspectedBy.Focus();
                    return;
                }

                if (RdoConfirming.Checked == true)
                {
                    if (MessageBox.Show("CONFIRMING ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                    {
                        return;
                    }
                }
                else if (RdoNonConfirming.Checked == true)
                {
                    if (MessageBox.Show("NON CONFIRMING ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                    {
                        return;
                    }
                }
                else if (RdoHold.Checked == true)
                {
                    if (MessageBox.Show("HOLD ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                    {
                        return;
                    }
                }

                if (Convert.ToString(DtpSamplingDate.Value.DayOfWeek) == "Monday" || Convert.ToString(DtpSamplingDate.Value.DayOfWeek) == "Friday")
                {
                    if (txtMediaLotNo.Text.Trim() == "")
                    {
                        MessageBox.Show("Enter Media Lot No", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMediaLotNo.Focus();
                        return;
                    }
                }

                WaterAnalysis_Class_Obj.medialotno = txtMediaLotNo.Text.Trim();
                WaterAnalysis_Class_Obj.norms = txtNorms.Text.Trim();
                WaterAnalysis_Class_Obj.amtofwatersampled = txtAmtWaterFiltered.Text.Trim();
                WaterAnalysis_Class_Obj.dateofsampling = DtpSamplingDate.Value.ToShortDateString();

                if (RdoConfirming.Checked == true)
                {
                    WaterAnalysis_Class_Obj.status = 'C';
                }
                else if (RdoNonConfirming.Checked == true)
                {
                    WaterAnalysis_Class_Obj.status = 'N';
                }
                else if (RdoHold.Checked == true)
                {
                    WaterAnalysis_Class_Obj.status = 'H';
                }
                WaterAnalysis_Class_Obj.comment = txtComment.Text.Trim();

                WaterAnalysis_Class_Obj.loginid = Convert.ToInt32(FrmMain.LoginID);

                WaterAnalysis_Class_Obj.inspectedby = Convert.ToInt32(cmbInspectedBy.SelectedValue);

                // Physicochemical water analysis
                WaterAnalysis_Class_Obj.phnorms = Convert.ToString(txtPHNorms.Text);
                WaterAnalysis_Class_Obj.phresult = Convert.ToString(txtPHResult.Text);
                WaterAnalysis_Class_Obj.conductivity = Convert.ToString(txtConductivity.Text);
                WaterAnalysis_Class_Obj.conductivityresult = Convert.ToString(txtConductivityResult.Text);
                WaterAnalysis_Class_Obj.aspectnorm = Convert.ToString(txtAspectNorms.Text);
                WaterAnalysis_Class_Obj.aspectresult = Convert.ToString(cmbAspectResult.Text);
                WaterAnalysis_Class_Obj.odornorms = Convert.ToString(txtOdorNorms.Text);
                WaterAnalysis_Class_Obj.odorresult = Convert.ToString(cmbOdorResult.Text);
                WaterAnalysis_Class_Obj.colornorms = Convert.ToString(txtColorNorms.Text);
                WaterAnalysis_Class_Obj.colorresult = Convert.ToString(cmbColorResult.Text);


                #region Physico Chemical water analysis
                //Physico Chemical water analysis on daily
                DataSet dsPhyChem = new DataSet();
                WaterAnalysis_Class_Obj.phyChemSamplingDate = Convert.ToDateTime(DtpSamplingDate.Value.ToShortDateString());
                dsPhyChem = WaterAnalysis_Class_Obj.Select_tblPhysicoChemicalWaterAnalysis_DateOfsampling();
                if (dsPhyChem.Tables[0].Rows.Count > 0)
                {
                    WaterAnalysis_Class_Obj.phyChemWA = Convert.ToInt64(dsPhyChem.Tables[0].Rows[0]["PhyChemWA"]);
                    if (MessageBox.Show("Record already Exists of Physico Chemical Water analysis.\n\nUpdate?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                    {
                        WaterAnalysis_Class_Obj.Update_tblPhysicoChemicalWaterAnalysis();
                    }
                }
                else
                {
                    bool flag = WaterAnalysis_Class_Obj.Insert_tblPhysicoChemicalWaterAnalysis();
                }

                #endregion

                #region Micro Water Ananlysis
                // Micro Water analysis done on Monday & Friday Only
                if (Convert.ToString(DtpSamplingDate.Value.DayOfWeek) == "Monday" || Convert.ToString(DtpSamplingDate.Value.DayOfWeek) == "Friday")
                {
                    DataSet ds = new DataSet();
                    //ds = WaterAnalysis_Class_Obj.Select_tblWaterAnalysis_MediaLotNo();
                    ds = WaterAnalysis_Class_Obj.Select_tblWaterAnalysis_DateOfsampling();
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        WaterAnalysis_Class_Obj.wano = Convert.ToInt64(ds.Tables[0].Rows[0]["WANo"]);
                        if (MessageBox.Show("Record already Exists of Micro water analysis.\n\nUpdate?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
                        {
                            WaterAnalysis_Class_Obj.Update_tblWaterAnalysis();
                        }
                    }
                    else
                    {
                        WaterAnalysis_Class_Obj.wano = WaterAnalysis_Class_Obj.Insert_tblWaterAnalysis();
                    }

                    DataSet dsSamp;
                    for (int i = 1; i <= 4; i++)
                    {
                        if (i == 1)
                        {
                            WaterAnalysis_Class_Obj.samplingpoint = 1;

                            if (DtpStartTime1.Checked == true)
                            {
                                WaterAnalysis_Class_Obj.starttime = DtpStartTime1.Value.ToLongTimeString();
                            }
                            else
                            {
                                WaterAnalysis_Class_Obj.starttime = null;
                            }
                            if (DtpFinishTime1.Checked == true)
                            {
                                WaterAnalysis_Class_Obj.finishtime = DtpFinishTime1.Value.ToLongTimeString();
                            }
                            else
                            {
                                WaterAnalysis_Class_Obj.finishtime = null;
                            }
                            if (DtpAnalysisDate1.Checked == true)
                            {
                                WaterAnalysis_Class_Obj.analysisdate = DtpAnalysisDate1.Value.ToShortDateString();
                            }
                            else
                            {
                                WaterAnalysis_Class_Obj.analysisdate = null;
                            }
                            if (DtpAnalysisTime1.Checked == true)
                            {
                                WaterAnalysis_Class_Obj.analysistime = DtpAnalysisTime1.Value.ToLongTimeString();
                            }
                            else
                            {
                                WaterAnalysis_Class_Obj.analysistime = null;
                            }
                            if (DtpResultDate1.Checked == true)
                            {
                                WaterAnalysis_Class_Obj.resultdate = DtpResultDate1.Value.ToShortDateString();
                            }
                            else
                            {
                                WaterAnalysis_Class_Obj.resultdate = null;
                            }
                            if (DtpResultTime1.Checked == true)
                            {
                                WaterAnalysis_Class_Obj.resulttime = DtpResultTime1.Value.ToLongTimeString();
                            }
                            else
                            {
                                WaterAnalysis_Class_Obj.resulttime = null;
                            }
                            if (cmbResult1.Text == "--Select--")
                            {
                                WaterAnalysis_Class_Obj.result = null;
                            }
                            else
                            {
                                WaterAnalysis_Class_Obj.result = cmbResult1.Text.Trim();
                            }
                            if (txtCFUML1.Text.Trim() == "")
                            {
                                WaterAnalysis_Class_Obj.cfuml = 0;
                            }
                            else
                            {
                                WaterAnalysis_Class_Obj.cfuml = Convert.ToDouble(txtCFUML1.Text.Trim());
                            }
                            WaterAnalysis_Class_Obj.incubtemp = txtIncubTemp.Text.Trim();
                        }
                        else if (i == 2)
                        {
                            WaterAnalysis_Class_Obj.samplingpoint = 2;

                            if (DtpStartTime2.Checked == true)
                            {
                                WaterAnalysis_Class_Obj.starttime = DtpStartTime2.Value.ToLongTimeString();
                            }
                            else
                            {
                                WaterAnalysis_Class_Obj.starttime = null;
                            }
                            if (DtpFinishTime2.Checked == true)
                            {
                                WaterAnalysis_Class_Obj.finishtime = DtpFinishTime2.Value.ToLongTimeString();
                            }
                            else
                            {
                                WaterAnalysis_Class_Obj.finishtime = null;
                            }
                            if (DtpAnalysisDate2.Checked == true)
                            {
                                WaterAnalysis_Class_Obj.analysisdate = DtpAnalysisDate2.Value.ToShortDateString();
                            }
                            else
                            {
                                WaterAnalysis_Class_Obj.analysisdate = null;
                            }
                            if (DtpAnalysisTime2.Checked == true)
                            {
                                WaterAnalysis_Class_Obj.analysistime = DtpAnalysisTime2.Value.ToLongTimeString();
                            }
                            else
                            {
                                WaterAnalysis_Class_Obj.analysistime = null;
                            }
                            if (DtpResultDate2.Checked == true)
                            {
                                WaterAnalysis_Class_Obj.resultdate = DtpResultDate2.Value.ToShortDateString();
                            }
                            else
                            {
                                WaterAnalysis_Class_Obj.resultdate = null;
                            }
                            if (DtpResultTime2.Checked == true)
                            {
                                WaterAnalysis_Class_Obj.resulttime = DtpResultTime2.Value.ToLongTimeString();
                            }
                            else
                            {
                                WaterAnalysis_Class_Obj.resulttime = null;
                            }
                            if (cmbResult2.Text == "--Select--")
                            {
                                WaterAnalysis_Class_Obj.result = null;
                            }
                            else
                            {
                                WaterAnalysis_Class_Obj.result = cmbResult2.Text.Trim();
                            }
                            if (txtCFUML2.Text.Trim() == "")
                            {
                                WaterAnalysis_Class_Obj.cfuml = 0;
                            }
                            else
                            {
                                WaterAnalysis_Class_Obj.cfuml = Convert.ToDouble(txtCFUML2.Text.Trim());
                            }
                            WaterAnalysis_Class_Obj.incubtemp = txtIncubTemp.Text.Trim();
                        }
                        else if (i == 3)
                        {
                            WaterAnalysis_Class_Obj.samplingpoint = 3;

                            if (DtpStartTime3.Checked == true)
                            {
                                WaterAnalysis_Class_Obj.starttime = DtpStartTime3.Value.ToLongTimeString();
                            }
                            else
                            {
                                WaterAnalysis_Class_Obj.starttime = null;
                            }
                            if (DtpFinishTime3.Checked == true)
                            {
                                WaterAnalysis_Class_Obj.finishtime = DtpFinishTime3.Value.ToLongTimeString();
                            }
                            else
                            {
                                WaterAnalysis_Class_Obj.finishtime = null;
                            }
                            if (DtpAnalysisDate3.Checked == true)
                            {
                                WaterAnalysis_Class_Obj.analysisdate = DtpAnalysisDate3.Value.ToShortDateString();
                            }
                            else
                            {
                                WaterAnalysis_Class_Obj.analysisdate = null;
                            }
                            if (DtpAnalysisTime3.Checked == true)
                            {
                                WaterAnalysis_Class_Obj.analysistime = DtpAnalysisTime3.Value.ToLongTimeString();
                            }
                            else
                            {
                                WaterAnalysis_Class_Obj.analysistime = null;
                            }
                            if (DtpResultDate3.Checked == true)
                            {
                                WaterAnalysis_Class_Obj.resultdate = DtpResultDate3.Value.ToShortDateString();
                            }
                            else
                            {
                                WaterAnalysis_Class_Obj.resultdate = null;
                            }
                            if (DtpResultTime3.Checked == true)
                            {
                                WaterAnalysis_Class_Obj.resulttime = DtpResultTime3.Value.ToLongTimeString();
                            }
                            else
                            {
                                WaterAnalysis_Class_Obj.resulttime = null;
                            }
                            if (cmbResult3.Text == "--Select--")
                            {
                                WaterAnalysis_Class_Obj.result = null;
                            }
                            else
                            {
                                WaterAnalysis_Class_Obj.result = cmbResult3.Text.Trim();
                            }
                            if (txtCFUML3.Text.Trim() == "")
                            {
                                WaterAnalysis_Class_Obj.cfuml = 0;
                            }
                            else
                            {
                                WaterAnalysis_Class_Obj.cfuml = Convert.ToDouble(txtCFUML3.Text.Trim());
                            }
                            WaterAnalysis_Class_Obj.incubtemp = txtIncubTemp.Text.Trim();
                        }
                        else if (i == 4)
                        {
                            WaterAnalysis_Class_Obj.samplingpoint = 4;

                            if (DtpStartTime4.Checked == true)
                            {
                                WaterAnalysis_Class_Obj.starttime = DtpStartTime4.Value.ToLongTimeString();
                            }
                            else
                            {
                                WaterAnalysis_Class_Obj.starttime = null;
                            }
                            if (DtpFinishTime4.Checked == true)
                            {
                                WaterAnalysis_Class_Obj.finishtime = DtpFinishTime4.Value.ToLongTimeString();
                            }
                            else
                            {
                                WaterAnalysis_Class_Obj.finishtime = null;
                            }
                            if (DtpAnalysisDate4.Checked == true)
                            {
                                WaterAnalysis_Class_Obj.analysisdate = DtpAnalysisDate4.Value.ToShortDateString();
                            }
                            else
                            {
                                WaterAnalysis_Class_Obj.analysisdate = null;
                            }
                            if (DtpAnalysisTime4.Checked == true)
                            {
                                WaterAnalysis_Class_Obj.analysistime = DtpAnalysisTime4.Value.ToLongTimeString();
                            }
                            else
                            {
                                WaterAnalysis_Class_Obj.analysistime = null;
                            }
                            if (DtpResultDate4.Checked == true)
                            {
                                WaterAnalysis_Class_Obj.resultdate = DtpResultDate4.Value.ToShortDateString();
                            }
                            else
                            {
                                WaterAnalysis_Class_Obj.resultdate = null;
                            }
                            if (DtpResultTime4.Checked == true)
                            {
                                WaterAnalysis_Class_Obj.resulttime = DtpResultTime4.Value.ToLongTimeString();
                            }
                            else
                            {
                                WaterAnalysis_Class_Obj.resulttime = null;
                            }
                            if (cmbResult4.Text == "--Select--")
                            {
                                WaterAnalysis_Class_Obj.result = null;
                            }
                            else
                            {
                                WaterAnalysis_Class_Obj.result = cmbResult4.Text.Trim();
                            }
                            if (txtCFUML4.Text.Trim() == "")
                            {
                                WaterAnalysis_Class_Obj.cfuml = 0;
                            }
                            else
                            {
                                WaterAnalysis_Class_Obj.cfuml = Convert.ToDouble(txtCFUML4.Text.Trim());
                            }
                            WaterAnalysis_Class_Obj.incubtemp = txtIncubTemp.Text.Trim();
                        }

                        dsSamp = new DataSet();
                        dsSamp = WaterAnalysis_Class_Obj.Select_tblWaterAnalysisSampling_WANo_SamplingPoint();
                        if (dsSamp.Tables[0].Rows.Count > 0)
                        {
                            WaterAnalysis_Class_Obj.samplingno = Convert.ToInt64(dsSamp.Tables[0].Rows[0]["SamplingNo"]);
                            WaterAnalysis_Class_Obj.Update_tblWaterAnalysisSampling();
                        }
                        else
                        {
                            WaterAnalysis_Class_Obj.samplingno = WaterAnalysis_Class_Obj.Insert_tblWaterAnalysisSampling();
                        }
                    }//end of for
                }
                #endregion

                MessageBox.Show("Record Saved Succesfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
                BtnReset_Click(sender, e);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void txtIncubTemp_KeyPress(object sender, KeyPressEventArgs e)
        {
            // only 0-9 allowed
            if (Convert.ToInt32(e.KeyChar) != 8)
            {
                if ((Convert.ToInt32(e.KeyChar) >= 48) && (Convert.ToInt32(e.KeyChar) <= 57))
                {

                }
                else
                { e.Handled = true; }
            }
        }

        private void txtIncubTemp_Enter(object sender, EventArgs e)
        {
            txtIncubTemp.Text = Convert.ToString(32);
        }

        private void DtpStartTime1_ValueChanged(object sender, EventArgs e)
        {
            //Set Finish time = start time + 1 hourr
            DtpFinishTime1.Value = DtpStartTime1.Value.AddHours(1);
        }

        private void DtpStartTime2_ValueChanged(object sender, EventArgs e)
        {
            //Set Finish time = start time + 1 hourr
            DtpFinishTime2.Value = DtpStartTime2.Value.AddHours(1);
        }

        private void DtpStartTime3_ValueChanged(object sender, EventArgs e)
        {
            //Set Finish time = start time + 1 hourr
            DtpFinishTime3.Value = DtpStartTime3.Value.AddHours(1);
        }

        private void DtpStartTime4_ValueChanged(object sender, EventArgs e)
        {
            //Set Finish time = start time + 1 hourr
            DtpFinishTime4.Value = DtpStartTime4.Value.AddHours(1);
        }

        private void DtpAnalysisDate1_ValueChanged(object sender, EventArgs e)
        {
            //Set Result Date = Analysis Date + 3 days
            DtpResultDate1.Value = DtpAnalysisDate1.Value.AddDays(3);
        }

        private void DtpAnalysisDate2_ValueChanged(object sender, EventArgs e)
        {
            //Set Result Date = Analysis Date + 3 days
            DtpResultDate2.Value = DtpAnalysisDate2.Value.AddDays(3);
        }

        private void DtpAnalysisDate3_ValueChanged(object sender, EventArgs e)
        {
            //Set Result Date = Analysis Date + 3 days
            DtpResultDate3.Value = DtpAnalysisDate3.Value.AddDays(3);
        }

        private void DtpAnalysisDate4_ValueChanged(object sender, EventArgs e)
        {
            //Set Result Date = Analysis Date + 3 days
            DtpResultDate4.Value = DtpAnalysisDate4.Value.AddDays(3);
        }

        private void DtpAnalysisTime1_ValueChanged(object sender, EventArgs e)
        {
            DtpResultTime1.Value = DtpAnalysisTime1.Value;
        }

        private void DtpAnalysisTime2_ValueChanged(object sender, EventArgs e)
        {
            DtpResultTime2.Value = DtpAnalysisTime2.Value;
        }

        private void DtpAnalysisTime3_ValueChanged(object sender, EventArgs e)
        {
            DtpResultTime3.Value = DtpAnalysisTime3.Value;
        }

        private void DtpAnalysisTime4_ValueChanged(object sender, EventArgs e)
        {
            DtpResultTime4.Value = DtpAnalysisTime4.Value;
        }
        private void cmbResult1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Set CFL/ML = 200/Result value

            if (cmbResult1.Text == "--Select--")
            {
                txtCFUML1.Text = "";
            }
            else
            {
                txtCFUML1.Text = (Convert.ToDecimal(cmbResult1.Text) / 200).ToString();
            }
        }

        private void cmbResult2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Set CFL/ML = 200/Result value

            if (cmbResult2.Text == "--Select--")
            {
                txtCFUML2.Text = "";
            }
            else
            {
                txtCFUML2.Text = (Convert.ToDecimal(cmbResult2.Text) / 200).ToString();
            }
        }

        private void cmbResult3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Set CFL/ML = 200/Result value

            if (cmbResult3.Text == "--Select--")
            {
                txtCFUML3.Text = "";
            }
            else
            {
                txtCFUML3.Text = (Convert.ToDecimal(cmbResult3.Text) / 200).ToString();
            }
        }

        private void cmbResult4_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //Set CFL/ML = 200/Result value

            if (cmbResult4.Text == "--Select--")
            {
                txtCFUML4.Text = "";
            }
            else
            {
                txtCFUML4.Text = (Convert.ToDecimal(cmbResult4.Text) / 200).ToString();
            }
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}