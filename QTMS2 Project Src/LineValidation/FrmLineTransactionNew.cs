using BusinessFacade;
using QTMS.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace QTMS.LineValidation
{
    public partial class FrmLineTransactionNew : Form
    {
        LineMaster_Class LayoutLineMaster_Class_Obj = new LineMaster_Class();
        LineTransactionMaster_Class LineTransactionMaster_Class_Obj = new LineTransactionMaster_Class();
        LineTransaction_Class LineTransaction_Class_Obj = new LineTransaction_Class();
        private string shairedpath;
        private bool isForModify;
        public long riskAnalysisTransactionId;

        public FrmLineTransactionNew()
        {
            InitializeComponent();
        }


        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmLineTransaction_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Normal;
                Painter.Paint(this);
                Bind_LineDescription();
                dtpDate.Value = DateTime.Now;
                LayoutLineMaster_Class_Obj.loginuser = FrmMain.LoginID;
                LineTransaction_Class_Obj.loginuser = FrmMain.LoginID;
                LineTransactionMaster_Class_Obj.loginuser = FrmMain.LoginID;
                shairedpath = ConfigurationManager.AppSettings["shairedpath"].ToString();

                _validToDate.Value = _validFromDate.Value = DateTime.Now;
                _validToDate.Format = _validFromDate.Format = DateTimePickerFormat.Custom;
                _validToDate.CustomFormat = _validFromDate.CustomFormat = "yyyy";
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        private void Bind_LineDescription()
        {
            try
            {
                DataSet ds = new DataSet();
                //if (this.isForModify)
                //{
                //    ds = LayoutLineMaster_Class_Obj.Select_LineTransactionModificationList();
                //}
                //else
                //{
                ds = LayoutLineMaster_Class_Obj.Select_LineMaster();
                //}
                DataRow dr = ds.Tables[0].NewRow();
                dr["LNo"] = "0";
                dr["LineDesc"] = "--Select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cbLineDescription.DataSource = ds.Tables[0];
                cbLineDescription.DisplayMember = "LineDesc";
                cbLineDescription.ValueMember = "LNo";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbLineDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLineDescription.SelectedIndex > 0)
                BindLineDescriptionTransactionGrid();
            else
                BindLineDescriptionTransactionDefault();
        }

        private void BindLineDescriptionTransactionGrid()
        {
            lblQualityRiskFileName.Text = _QualityRiskUploadFilePath = string.Empty;
            dgvQualityRiskAnalysis.DataSource = null; dgvQualityRiskAnalysis.Refresh();
            dgvQualityRiskAnalysis.Rows.Clear();
            isForModify = false;
            DataSet dsForCheckRecord = LineTransactionMaster_Class_Obj.Select_IsTransactionExist(Convert.ToInt64(cbLineDescription.SelectedValue), dtpDate.Value, LineTransactionMaster_Class_Obj.loginuser);
            if (dsForCheckRecord.Tables.Count > 0)
            {
                if ((Convert.ToInt32(dsForCheckRecord.Tables[0].Rows[0][0])) == 0)
                {
                    //DataSet ds = LineTransactionMaster_Class_Obj.Select_LayoutLineTransactionMasterByLineDescriptionId(Convert.ToInt64(cbLineDescription.SelectedValue));
                    DataSet ds = LineTransactionMaster_Class_Obj.Select_LayoutLineTransactionMasterForAllTransaction();

                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            dgvLineTransaction.DataSource = null;
                            dgvLineTransaction.Rows.Clear();
                            int serialno = 1;
                            foreach (DataRow item in ds.Tables[0].Rows)
                            {
                                if (serialno == 1)
                                {
                                    //_validFromDate.Value = Convert.ToDateTime(item["ValidFrom"]);
                                    //_validToDate.Value = Convert.ToDateTime(item["ValidTo"]);
                                }
                                if (serialno > 4)
                                {
                                    riskAnalysisTransactionId = Convert.ToInt32(item["Id"]);
                                    txtQualityRiskAnalysis.Text = Convert.ToString(item["QualityRiskAnalysis"]);
                                    break;
                                }
                                else
                                {
                                    DataGridViewRow dr1 = new DataGridViewRow();
                                    dr1.CreateCells(dgvLineTransaction);  //
                                    dr1.Cells[0].Value = serialno;
                                    dr1.Cells[1].Value = Convert.ToString(item["Name"]);
                                    dr1.Cells[2].Value = Convert.ToString(item["Parameter"]) + " >= " + Convert.ToString(item["MinVal"]);
                                    dr1.Cells[3].Value = dtpDate.Value.ToString("dd-MM-yyyy");// Convert.ToString(item["Parameter"]);
                                    dr1.Cells[4].Value = dtpDate.Value.AddYears(1).ToString("dd-MM-yyyy");
                                    dgvLineTransaction.Columns[3].DefaultCellStyle.Format = "dd-MM-yyyy";
                                    dgvLineTransaction.Columns[4].DefaultCellStyle.Format = "dd-MM-yyyy";
                                    dr1.Cells[5].Value = Convert.ToString(item["MinVal"]);
                                    //dr1.Cells[4].Value = Convert.ToString(item["MaxVal"]);
                                    //Is for value //dr1.Cells[2].Value = Convert.ToString(item["Parameter"] + " " + item["Value"]);
                                    dr1.Cells[7].Value = dr1.Cells[8].Value = "";
                                    dr1.Cells[9].Value = "Upload";
                                    dr1.Cells[10].Value = dr1.Cells[12].Value = "";
                                    dr1.Cells[11].Value = "";
                                    dr1.Cells[13].Value = Convert.ToString(item["Id"]);
                                    dr1.Cells[14].Value = dr1.Cells[15].Value = "";
                                    dr1.Cells[17].Value = dr1.Cells[16].Value = "";

                                    serialno++;
                                    dgvLineTransaction.Rows.Add(dr1);
                                }
                            }
                            if (ds.Tables[0].Rows.Count == 4)
                            {
                                riskAnalysisTransactionId = 0;
                                txtQualityRiskAnalysis.Text = string.Empty;
                            }
                            dgvLineTransaction.Visible = true;
                        }
                        else
                        {
                            BindLineDescriptionTransactionDefault();
                            MessageBox.Show("Record not found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        BindLineDescriptionTransactionDefault();
                        MessageBox.Show("Record not found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                //Bind Line Description Transaction Grid For Remaining Parameter (dsForCheckRecord.Tables[0].Rows[0][1]) is allparameter done
                else if ((Convert.ToInt32(dsForCheckRecord.Tables[0].Rows[0][1])) == 0)
                {
                    //_validationMasterId, (dsForCheckRecord.Tables[0].Rows[0][2]) is validation master id
                    _validationMasterId = (Convert.ToInt64(dsForCheckRecord.Tables[0].Rows[0][2]));
                    BindLineDescriptionTransactionGridForRemainingParameter(_validationMasterId, dtpDate.Value, LineTransactionMaster_Class_Obj.loginuser);
                    BindQualityRiskAnalysisGrid(_validationMasterId);
                }
                else
                {

                    BindLineDescriptionTransactionDefault();
                    MessageBox.Show("Record already exist", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void BindLineDescriptionTransactionDefault()
        {
            txtQualityRiskAnalysis.Text = lblQualityRiskFileName.Text = _QualityRiskUploadFilePath = string.Empty;
            dgvLineTransaction.DataSource = null;
            dgvLineTransaction.Rows.Clear();
            dgvLineTransaction.AutoGenerateColumns = false;
            dgvLineTransaction.Visible = false;
            dgvQualityRiskAnalysis.DataSource = null; dgvQualityRiskAnalysis.Refresh();
            dgvQualityRiskAnalysis.Rows.Clear();
        }


        private void BindLineDescriptionTransactionGridForRemainingParameter(long id, DateTime dt, long userdId)
        {
            lblQualityRiskFileName.Text = _QualityRiskUploadFilePath = string.Empty;
            DataSet ds = LineTransactionMaster_Class_Obj.Select_LayoutLineTransactionForModification(id, dt, userdId);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    isForModify = true;
                    dgvLineTransaction.DataSource = null;
                    dgvLineTransaction.Rows.Clear();
                    int serialno = 1;
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        if (serialno > 4)
                        {
                            riskAnalysisTransactionId = Convert.ToInt32(item["Id"]);
                            txtQualityRiskAnalysis.Text = Convert.ToString(item["QualityRiskAnalysis"]);
                            _QualityRiskUploadFilePath = Convert.ToString(item["QualityRiskAnalysisFilePath"]);
                            try
                            {
                                lblQualityRiskFileName.Text = Path.GetFileName(_QualityRiskUploadFilePath);
                            }
                            catch (Exception)
                            { }
                            break;
                        }
                        else
                        {
                            DataGridViewRow dr1 = new DataGridViewRow();
                            dr1.CreateCells(dgvLineTransaction);  //
                            dr1.Cells[0].Value = serialno;
                            dr1.Cells[1].Value = Convert.ToString(item["Name"]);
                            dr1.Cells[2].Value = Convert.ToString(item["Parameter"]);
                            dr1.Cells[3].Value = Convert.ToDateTime(item["TransactionDate"]).ToString("dd -MM-yyyy");// Convert.ToString(item["Parameter"]);
                            dr1.Cells[4].Value = Convert.ToDateTime(item["DueDate"]).ToString("dd -MM-yyyy");
                            dgvLineTransaction.Columns[3].DefaultCellStyle.Format = "dd-MM-yyyy";
                            dgvLineTransaction.Columns[4].DefaultCellStyle.Format = "dd-MM-yyyy";
                            dr1.Cells[5].Value = Convert.ToString(item["MinVal"]);

                            dr1.Cells[7].Value = "";
                            dr1.Cells[8].Value = Convert.ToString(item["Result"]);

                            dr1.Cells[9].Value = "Upload";
                            dr1.Cells[10].Value = dr1.Cells[15].Value = Convert.ToString(item["AttachedFileName"]);// Convert.ToString(item["Status"]);
                            dr1.Cells[11].Value = "Upload";
                            dr1.Cells[14].Value = Convert.ToString(item["AttachedFilePath"]);
                            dr1.Cells[15].Value = Convert.ToString(item["AttachedFileName"]);
                            dr1.Cells[12].Value = dr1.Cells[16].Value = Convert.ToString(item["ActionPlanFileName"]);
                            dr1.Cells[17].Value = Convert.ToString(item["ActionPlanFilePath"]);
                            dr1.Cells[13].Value = Convert.ToString(item["Id"]);


                            dgvLineTransaction.Rows.Add(dr1);
                            if (!string.IsNullOrEmpty(Convert.ToString(item["Result"])))
                            {
                                for (int a = 0; a <= 17; a++)
                                {
                                    dr1.Cells[a].ReadOnly = true;
                                }
                                dr1.Cells[11].Value = "Upload";
                                dgvLineTransaction.Rows[serialno - 1].ReadOnly = true;
                                dgvLineTransaction.Rows[serialno - 1].DefaultCellStyle.BackColor = Color.Silver;
                            }
                            else
                            {
                                dr1.Cells[11].Value = "";
                            }

                            serialno++;
                        }
                    }
                    if (ds.Tables[0].Rows.Count == 4)
                    {
                        riskAnalysisTransactionId = 0;
                        txtQualityRiskAnalysis.Text = string.Empty;
                    }
                    dgvLineTransaction.Visible = true;
                    UpdateTextBoxColorToRedOnMinMaxVal();
                }
                else
                {
                    BindLineDescriptionTransactionDefault();
                    MessageBox.Show("Record not found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                BindLineDescriptionTransactionDefault();
                MessageBox.Show("Record not found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (isForModify)
                {
                    #region Is For Modify
                    try
                    {
                        if (cbLineDescription.SelectedIndex > 0)
                        {
                            bool b = false;
                            string msg = "";
                            string parameter = "";
                            int stindexofblank = 0;
                            int stindexofnotblank = 0;
                            int allParameterDoneCount = 0;
                            //int ltindexofblank = 0;
                            int index = 1;
                            UpdateTextBoxColorToRedOnMinMaxVal();
                            foreach (DataGridViewRow item in dgvLineTransaction.Rows)
                            {
                                if (index == 1)
                                    parameter = "short term colorant";
                                else if (index == 2)
                                    parameter = "short term developer";
                                else if (index == 3)
                                    parameter = "long term colorant";
                                else
                                    parameter = "long term developer";
                                if (Convert.ToString(item.Cells["Result"].Value) == "")
                                {

                                    //if(stindexofblank == 1)
                                    if (stindexofnotblank == 1 && index == 2)
                                    {
                                        msg = "Please enter result value of " + parameter + " , is mandatory";
                                    }
                                    if (stindexofnotblank == 3 && index == 4)
                                    {
                                        msg = "Please enter result value of " + parameter + " , is mandatory";
                                    }

                                    stindexofblank = index;
                                    //if (stindexofblank == 1 && index == 2)
                                    //{
                                    //    msg = string.Empty;
                                    //    //msg = "Please enter result value of " + parameter + " , is mandatory";
                                    //}
                                    //else
                                    //{
                                    //    msg = string.Empty;
                                    //}
                                    //stindexofblank = index;
                                }
                                else
                                {
                                    allParameterDoneCount = allParameterDoneCount + 1;
                                    stindexofnotblank = index;
                                    if (stindexofblank == 1 && index == 2)
                                    {
                                        msg = "Please enter result value of " + "short term colorant" + " , is mandatory";
                                    }
                                    if (stindexofblank == 3 && index == 4)
                                    {
                                        msg = "Please enter result value of " + "long term colorant" + " , is mandatory";
                                    }
                                }

                                if (string.IsNullOrEmpty(msg))
                                {

                                    if (stindexofblank == 4 && stindexofnotblank == 0)
                                    {
                                        msg = "Please enter result value of at least one CpK or PpK , is mandatory";
                                    }
                                }

                                try
                                {
                                    if (!string.IsNullOrEmpty(Convert.ToString(item.Cells["Result"].Value).Trim()))
                                        Convert.ToDecimal(Convert.ToString(item.Cells["Result"].Value));
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Please enter decimal value of " + parameter, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    item.Cells["Result"].Value = "";
                                    return;
                                }
                                if (Convert.ToString(item.Cells["ActionPlanRequiredRowNo"].Value) != "")
                                {
                                    if (Convert.ToString(item.Cells["ActionPlanUploadFileName"].Value) == "")
                                    {
                                        msg = "Please upload action plan file of " + parameter + " , is mandatory";
                                    }
                                }
                                if (msg != "")
                                {
                                    MessageBox.Show(msg, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                                index++;
                            }
                            foreach (DataGridViewRow item in dgvLineTransaction.Rows)
                            {
                                LineTransaction_Class_Obj.id = Convert.ToInt64(item.Cells["Id"].Value);
                                LineTransaction_Class_Obj.name = Convert.ToString(item.Cells["NameColumn"].Value);
                                LineTransaction_Class_Obj.parameter = Convert.ToString(item.Cells["Parameter"].Value);
                                LineTransaction_Class_Obj.minValue = Convert.ToString(item.Cells["MinVal"].Value);
                                //LineTransaction_Class_Obj.value = Convert.ToString(item.Cells["Value"].Value);
                                LineTransaction_Class_Obj.result = Convert.ToString(item.Cells["Result"].Value);
                                LineTransaction_Class_Obj.status = Convert.ToString(item.Cells[7].Value); //Convert.ToString(item.Cells["Status"].Value);
                                LineTransaction_Class_Obj.attachedFileName = Convert.ToString(item.Cells["AttachedFileName"].Value);
                                LineTransaction_Class_Obj.attachedFilePath = Convert.ToString(item.Cells["AttachedFilePath"].Value).Replace("\\\\", "\\");
                                LineTransaction_Class_Obj.qualityRiskAnalysis = txtQualityRiskAnalysis.Text.Trim();

                                DateTimeFormatInfo usDtfi = new CultureInfo("en-IN", false).DateTimeFormat;
                                LineTransaction_Class_Obj.transactionDate = DateTime.Parse(Convert.ToString(item.Cells["TransactionDate"].Value), usDtfi);
                                //LineTransaction_Class_Obj.transactionDate = Convert.ToDateTime(item.Cells["TransactionDate"].Value);
                                //LineTransaction_Class_Obj.dueDate = Convert.ToDateTime(item.Cells["DueDate"].Value);
                                LineTransaction_Class_Obj.dueDate = DateTime.Parse(Convert.ToString(item.Cells["DueDate"].Value), usDtfi);
                                LineTransaction_Class_Obj.actionPlanFileName = Convert.ToString(item.Cells["ActionPlanUploadFileName"].Value);
                                LineTransaction_Class_Obj.actionPlanFilePath = Convert.ToString(item.Cells["ActionPlanUploadFilePath"].Value).Replace("\\\\", "\\");

                                if (!string.IsNullOrEmpty(_QualityRiskUploadFilePath))
                                {
                                    LineTransaction_Class_Obj.qualityRiskAnalysisFilePath = _QualityRiskUploadFilePath.Replace("\\\\", "\\");
                                }
                                if (allParameterDoneCount == 4)
                                {
                                    LineTransactionMaster_Class_Obj.allParameterDone = 1;
                                }
                                b = LineTransaction_Class_Obj.Update_LineTransaction();
                            }
                            if (b == true)
                            {
                                LineTransaction_Class_Obj.id = riskAnalysisTransactionId;
                                LineTransaction_Class_Obj.name = "Quality Risk Analysis";
                                LineTransaction_Class_Obj.parameter = txtQualityRiskAnalysis.Text.Trim();
                                LineTransaction_Class_Obj.minValue = LineTransaction_Class_Obj.maxValue = LineTransaction_Class_Obj.result = string.Empty;
                                LineTransaction_Class_Obj.status = LineTransaction_Class_Obj.attachedFileName = LineTransaction_Class_Obj.attachedFilePath = string.Empty;
                                LineTransaction_Class_Obj.qualityRiskAnalysis = txtQualityRiskAnalysis.Text.Trim();

                                if (!string.IsNullOrEmpty(_QualityRiskUploadFilePath))
                                {
                                    LineTransaction_Class_Obj.qualityRiskAnalysisFilePath = _QualityRiskUploadFilePath.Replace("\\\\", "\\");
                                }
                                //if (LineTransactionMaster_Class_Obj.id == 0)
                                //    b = LineTransaction_Class_Obj.Insert_LineTransaction();
                                //else
                                //{
                                b = LineTransaction_Class_Obj.Update_LineTransaction();
                                //}

                                LineTransactionMaster_Class_Obj.id = _validationMasterId; //Convert.ToInt64(cbLineDescription.SelectedValue);
                                LineTransactionMaster_Class_Obj.qualityRiskAnalysis = LineTransaction_Class_Obj.qualityRiskAnalysis = txtQualityRiskAnalysis.Text.Trim();
                                if (!string.IsNullOrEmpty(_QualityRiskUploadFilePath))
                                {
                                    LineTransactionMaster_Class_Obj.qualityRiskAnalysisFileName = Path.GetFileName(_QualityRiskUploadFilePath);
                                    LineTransactionMaster_Class_Obj.qualityRiskAnalysisFilePath = _QualityRiskUploadFilePath.Replace("\\\\", "\\");
                                }
                                b = LineTransactionMaster_Class_Obj.Update_LineTransactionMaster();

                                b = LineTransaction_Class_Obj.Delete_LineQualityRiskAnalysisFileMaster(LineTransactionMaster_Class_Obj.id);
                                foreach (DataGridViewRow item in dgvQualityRiskAnalysis.Rows)
                                {
                                    try
                                    {
                                        LineTransaction_Class_Obj.Insert_LineQualityRiskAnalysisFileMaster(LineTransactionMaster_Class_Obj.id, Convert.ToString(item.Cells["QualityRiskAnalysisFilePath"].Value), Convert.ToString(item.Cells["QualityRiskAnalysisFileName"].Value));
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }
                                MessageBox.Show("Record Modified Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                BindLineDescriptionTransactionDefault();
                                cbLineDescription.SelectedIndex = 0;
                                txtQualityRiskAnalysis.Text = string.Empty;
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please select Line Description", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            cbLineDescription.Focus();
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                    #endregion
                }
                else
                {
                    #region Is For Create Transaction
                    if (cbLineDescription.SelectedIndex > 0)
                    {
                        bool b = false;
                        string msg = "";
                        string parameter = "";
                        int stindexofblank = 0;
                        int stindexofnotblank = 0;
                        int allParameterDoneCount = 0;
                        //int ltindexofblank = 0;
                        int index = 1;
                        UpdateTextBoxColorToRedOnMinMaxVal();
                        foreach (DataGridViewRow item in dgvLineTransaction.Rows)
                        {
                            if (index == 1)
                                parameter = "short term colorant";
                            else if (index == 2)
                                parameter = "short term developer";
                            else if (index == 3)
                                parameter = "long term colorant";
                            else
                                parameter = "long term developer";
                            if (Convert.ToString(item.Cells["Result"].Value) == "")
                            {

                                //if(stindexofblank == 1)
                                if (stindexofnotblank == 1 && index == 2)
                                {
                                    msg = "Please enter result value of " + parameter + " , is mandatory";
                                }
                                if (stindexofnotblank == 3 && index == 4)
                                {
                                    msg = "Please enter result value of " + parameter + " , is mandatory";
                                }

                                stindexofblank = index;
                                //if (stindexofblank == 1 && index == 2)
                                //{
                                //    msg = string.Empty;
                                //    //msg = "Please enter result value of " + parameter + " , is mandatory";
                                //}
                                //else
                                //{
                                //    msg = string.Empty;
                                //}
                                //stindexofblank = index;
                            }
                            else
                            {
                                allParameterDoneCount = allParameterDoneCount + 1;
                                stindexofnotblank = index;
                                if (stindexofblank == 1 && index == 2)
                                {
                                    msg = "Please enter result value of " + "short term colorant" + " , is mandatory";
                                }
                                if (stindexofblank == 3 && index == 4)
                                {
                                    msg = "Please enter result value of " + "long term colorant" + " , is mandatory";
                                }
                            }

                            if (string.IsNullOrEmpty(msg))
                            {

                                if (stindexofblank == 4 && stindexofnotblank == 0)
                                {
                                    msg = "Please enter result value of at least one CpK or PpK , is mandatory";
                                }
                            }

                            try
                            {
                                if (!string.IsNullOrEmpty(Convert.ToString(item.Cells["Result"].Value).Trim()))
                                    Convert.ToDecimal(Convert.ToString(item.Cells["Result"].Value));
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Please enter decimal value of " + parameter, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                item.Cells["Result"].Value = "";
                                return;
                            }
                            if (Convert.ToString(item.Cells["ActionPlanRequiredRowNo"].Value) != "")
                            {
                                if (Convert.ToString(item.Cells["ActionPlanUploadFileName"].Value) == "")
                                {
                                    msg = "Please upload action plan file of " + parameter + " , is mandatory";
                                }
                            }
                            if (msg != "")
                            {
                                MessageBox.Show(msg, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            index++;
                        }
                        //if (!(dtpDate.Value.Date >= _validFromDate.Value.Date && dtpDate.Value.Date <= _validToDate.Value.Date))
                        //{
                        //    MessageBox.Show("Please select date between " + _validFromDate.Value.ToString("dd-MMM-yyyy") + " and " + _validToDate.Value.ToString("dd-MMM-yyyy") + " according to master", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //    return;
                        //}
                        {
                            DataSet dsforTransactionMasterId = new DataSet();
                            LineTransaction_Class_Obj.lineTransactionMasterId = 0;
                            foreach (DataGridViewRow item in dgvLineTransaction.Rows)
                            {
                                LineTransaction_Class_Obj.id = LineTransactionMaster_Class_Obj.id = 0; //Convert.ToInt64(item.Cells["Id"].Value);
                                LineTransaction_Class_Obj.layoutLineValidationTransactionId = LineTransactionMaster_Class_Obj.layoutLineValidationTransactionId = Convert.ToInt64(item.Cells["Id"].Value);
                                LineTransaction_Class_Obj.lineDescription = LineTransactionMaster_Class_Obj.lineDescription = Convert.ToInt64(cbLineDescription.SelectedValue);
                                LineTransactionMaster_Class_Obj.qualityRiskAnalysis = LineTransaction_Class_Obj.qualityRiskAnalysis = txtQualityRiskAnalysis.Text.Trim();
                                LineTransactionMaster_Class_Obj.date = dtpDate.Value;
                                if (allParameterDoneCount == 4)
                                {
                                    LineTransactionMaster_Class_Obj.allParameterDone = 1;
                                }
                                if (!string.IsNullOrEmpty(_QualityRiskUploadFilePath))
                                {
                                    LineTransactionMaster_Class_Obj.qualityRiskAnalysisFileName = Path.GetFileName(_QualityRiskUploadFilePath);
                                    LineTransactionMaster_Class_Obj.qualityRiskAnalysisFilePath = _QualityRiskUploadFilePath.Replace("\\\\", "\\");
                                    LineTransaction_Class_Obj.qualityRiskAnalysisFilePath = _QualityRiskUploadFilePath.Replace("\\\\", "\\");
                                }


                                if (LineTransactionMaster_Class_Obj.id == 0)
                                {
                                    if (LineTransaction_Class_Obj.lineTransactionMasterId == 0)
                                        b = LineTransactionMaster_Class_Obj.Insert_LineTransactionMaster(out dsforTransactionMasterId);
                                }
                                else
                                {
                                    b = LineTransactionMaster_Class_Obj.Update_LineTransactionMaster();
                                    //LineTransactionMaster_Class_Obj.id = 0;
                                    //LineTransactionMaster_Class_Obj.validFrom = Convert.ToDateTime(item.Cells["ValidTo"].Value);
                                    //LineTransactionMaster_Class_Obj.validTo = null;
                                    //b = LineTransactionMaster_Class_Obj.Insert_LayoutLineValidationTransaction();
                                }

                                if (b == true)
                                {
                                    if (dsforTransactionMasterId.Tables.Count > 0)
                                    {
                                        LineTransaction_Class_Obj.lineTransactionMasterId = Convert.ToInt64(dsforTransactionMasterId.Tables[0].Rows[0][0]);
                                        LineTransaction_Class_Obj.name = Convert.ToString(item.Cells["NameColumn"].Value);
                                        LineTransaction_Class_Obj.parameter = Convert.ToString(item.Cells["Parameter"].Value);
                                        LineTransaction_Class_Obj.minValue = Convert.ToString(item.Cells["MinVal"].Value);
                                        //LineTransaction_Class_Obj.maxValue = Convert.ToString(item.Cells["MaxVal"].Value);
                                        ////LineTransaction_Class_Obj.value = Convert.ToString(item.Cells["Value"].Value);
                                        LineTransaction_Class_Obj.result = Convert.ToString(item.Cells["Result"].Value);
                                        LineTransaction_Class_Obj.status = Convert.ToString(item.Cells[7].Value); //Convert.ToString(item.Cells["Status"].Value);
                                        LineTransaction_Class_Obj.attachedFileName = Convert.ToString(item.Cells["AttachedFileName"].Value);
                                        LineTransaction_Class_Obj.attachedFilePath = Convert.ToString(item.Cells["AttachedFilePath"].Value).Replace("\\\\", "\\");
                                        LineTransaction_Class_Obj.qualityRiskAnalysis = txtQualityRiskAnalysis.Text.Trim();
                                        DateTimeFormatInfo usDtfi = new CultureInfo("en-IN", false).DateTimeFormat;
                                        LineTransaction_Class_Obj.transactionDate = DateTime.Parse(Convert.ToString(item.Cells["TransactionDate"].Value), usDtfi);
                                        LineTransaction_Class_Obj.dueDate = DateTime.Parse(Convert.ToString(item.Cells["DueDate"].Value), usDtfi);
                                        //LineTransaction_Class_Obj.transactionDate = Convert.ToDateTime(item.Cells["TransactionDate"].Value);
                                        //LineTransaction_Class_Obj.dueDate = Convert.ToDateTime(item.Cells["DueDate"].Value);

                                        LineTransaction_Class_Obj.actionPlanFileName = Convert.ToString(item.Cells["ActionPlanUploadFileName"].Value);
                                        LineTransaction_Class_Obj.actionPlanFilePath = Convert.ToString(item.Cells["ActionPlanUploadFilePath"].Value).Replace("\\\\", "\\");
                                        if (LineTransactionMaster_Class_Obj.id == 0)
                                            b = LineTransaction_Class_Obj.Insert_LineTransaction();
                                        else
                                        {
                                            b = LineTransactionMaster_Class_Obj.Update_LineTransactionMaster();
                                        }
                                    }
                                }
                            }
                            if (b == true)
                            {
                                LineTransactionMaster_Class_Obj.id = riskAnalysisTransactionId;
                                LineTransaction_Class_Obj.name = "Quality Risk Analysis";
                                LineTransaction_Class_Obj.parameter = txtQualityRiskAnalysis.Text.Trim();
                                LineTransaction_Class_Obj.minValue = LineTransaction_Class_Obj.maxValue = LineTransaction_Class_Obj.result = string.Empty;
                                LineTransaction_Class_Obj.status = LineTransaction_Class_Obj.attachedFileName = LineTransaction_Class_Obj.attachedFilePath = string.Empty;
                                LineTransaction_Class_Obj.qualityRiskAnalysis = txtQualityRiskAnalysis.Text.Trim();
                                if (!string.IsNullOrEmpty(_QualityRiskUploadFilePath))
                                {
                                    LineTransaction_Class_Obj.qualityRiskAnalysisFilePath = _QualityRiskUploadFilePath.Replace("\\\\", "\\");
                                }
                                if (LineTransactionMaster_Class_Obj.id == 0)
                                    b = LineTransaction_Class_Obj.Insert_LineTransaction();
                                else
                                {
                                    b = LineTransactionMaster_Class_Obj.Update_LineTransactionMaster();
                                }
                                b = LineTransaction_Class_Obj.Delete_LineQualityRiskAnalysisFileMaster(LineTransaction_Class_Obj.lineTransactionMasterId);
                                foreach (DataGridViewRow item in dgvQualityRiskAnalysis.Rows)
                                {
                                    try
                                    {
                                        LineTransaction_Class_Obj.Insert_LineQualityRiskAnalysisFileMaster(LineTransaction_Class_Obj.lineTransactionMasterId, Convert.ToString(item.Cells["QualityRiskAnalysisFilePath"].Value), Convert.ToString(item.Cells["QualityRiskAnalysisFileName"].Value));
                                    }
                                    catch (Exception ex)
                                    {

                                    }
                                }
                                MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                BindLineDescriptionTransactionDefault();
                                cbLineDescription.SelectedIndex = 0;
                                txtQualityRiskAnalysis.Text = string.Empty;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please select Line Description", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        cbLineDescription.Focus();
                        return;
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void dgvLineTransaction_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex != 10 && e.ColumnIndex != 12)
            {
                if (dgvLineTransaction.Rows[e.RowIndex].Cells["Result"].ReadOnly)
                    return;
            }
            if (e.RowIndex >= 0 && e.ColumnIndex == 11)
            {
                if (Convert.ToString(dgvLineTransaction.Rows[e.RowIndex].Cells["Result"].Value) == "")
                {
                    dgvLineTransaction.Rows[e.RowIndex].Cells[17].Value = dgvLineTransaction.Rows[e.RowIndex].Cells[16].Value = dgvLineTransaction.Rows[e.RowIndex].Cells[12].Value = string.Empty;
                    return;
                }
                else
                {
                    try
                    {
                        if ((Convert.ToDecimal(dgvLineTransaction.Rows[e.RowIndex].Cells["MinVal"].Value) < Convert.ToDecimal(dgvLineTransaction.Rows[e.RowIndex].Cells["Result"].Value)))
                        {
                            dgvLineTransaction.Rows[e.RowIndex].Cells[17].Value = dgvLineTransaction.Rows[e.RowIndex].Cells[16].Value = dgvLineTransaction.Rows[e.RowIndex].Cells[12].Value = string.Empty;
                            return;
                        }
                    }
                    catch (Exception ex)
                    {
                        dgvLineTransaction.Rows[e.RowIndex].Cells[17].Value = dgvLineTransaction.Rows[e.RowIndex].Cells[16].Value = dgvLineTransaction.Rows[e.RowIndex].Cells[12].Value = string.Empty;
                        return;
                    }
                }
            }
            // If any cell is clicked on the Second column which is our date Column  
            if (e.ColumnIndex == 3 && e.RowIndex >= 0)
            {
                //Initialized a new DateTimePicker Control  
                oDateTimePicker = new DateTimePicker();

                //Adding DateTimePicker control into DataGridView   
                dgvLineTransaction.Controls.Add(oDateTimePicker);

                // Setting the format (i.e. 2014-10-10)  
                oDateTimePicker.Format = DateTimePickerFormat.Custom;

                oDateTimePicker.CustomFormat = "dd-MM-yyyy";

                oDateTimePicker.MinDate = new DateTime(dtpDate.Value.Year,1,1);
                oDateTimePicker.MaxDate = new DateTime(dtpDate.Value.Year, 12, 31);

                // It returns the retangular area that represents the Display area for a cell  
                Rectangle oRectangle = dgvLineTransaction.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                //Setting area for DateTimePicker Control  
                oDateTimePicker.Size = new Size(oRectangle.Width, oRectangle.Height);

                // Setting Location  
                oDateTimePicker.Location = new Point(oRectangle.X, oRectangle.Y);

                // An event attached to dateTimePicker Control which is fired when DateTimeControl is closed  
                oDateTimePicker.CloseUp += new EventHandler(oDateTimePicker_CloseUp);

                // An event attached to dateTimePicker Control which is fired when any date is selected  
                oDateTimePicker.TextChanged += new EventHandler(dateTimePicker_OnTextChange);

                // Now make it visible  
                oDateTimePicker.Visible = true;

            }
            if (e.ColumnIndex == 9 && e.RowIndex >= 0)
            {
                try
                {
                    DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
                    if (result == DialogResult.OK) // result.
                    {
                        //if (!(System.IO.Path.GetExtension(openFileDialog1.FileName) == ".pdf" || System.IO.Path.GetExtension(openFileDialogTrainingFile.FileName) == ".ppt"))
                        //{
                        //    MessageBox.Show("Please select valid pdf or ppt file ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        //    return;
                        //}
                        //else
                        //{
                        dgvLineTransaction.Rows[e.RowIndex].Cells[14].Value = shairedpath + "\\Transaction\\" + Path.GetFileName(openFileDialog1.FileName);
                        dgvLineTransaction.Rows[e.RowIndex].Cells[15].Value = dgvLineTransaction.Rows[e.RowIndex].Cells[10].Value = Path.GetFileName(openFileDialog1.FileName);
                        if (!Directory.Exists(shairedpath))
                            Directory.CreateDirectory(shairedpath);
                        if (!Directory.Exists(shairedpath + "\\Transaction\\"))
                            Directory.CreateDirectory(shairedpath + "\\Transaction\\");
                        File.Copy(openFileDialog1.FileName, shairedpath + "\\Transaction\\" + Path.GetFileName(openFileDialog1.FileName), true);
                        //}
                    }
                    else
                    {
                        dgvLineTransaction.Rows[e.RowIndex].Cells[10].Value = dgvLineTransaction.Rows[e.RowIndex].Cells[14].Value = dgvLineTransaction.Rows[e.RowIndex].Cells[15].Value = string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }

            }

            if (e.ColumnIndex == 10 && e.RowIndex >= 0)
            {
                string FilePath = string.Empty, FileName = string.Empty, LayoutFilePath = string.Empty;
                try
                {
                    LayoutFilePath = FilePath = Convert.ToString(dgvLineTransaction.Rows[e.RowIndex].Cells[14].Value);
                    if (LayoutFilePath != string.Empty)
                    {
                        if (File.Exists(@"" + LayoutFilePath.Replace("\\", "\\\\")))
                            FileName = Convert.ToString(dgvLineTransaction.Rows[e.RowIndex].Cells[15].Value);


                        if (File.Exists(@"" + LayoutFilePath.Replace("\\", "\\\\")))
                        {
                            if (!Directory.Exists(@"" + Application.StartupPath + "\\Files\\"))
                                Directory.CreateDirectory(@"" + Application.StartupPath + "\\Files\\");
                            File.Copy(@"" + FilePath.Replace("\\", "\\\\"), @"" + Application.StartupPath + "\\Files\\" + FileName, true);
                            //MessageBox.Show(@"" + Application.StartupPath + "\\Files\\" + FileName, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (File.Exists(@"" + Application.StartupPath + "\\Files\\" + FileName))
                                System.Diagnostics.Process.Start(@"" + Application.StartupPath + "\\Files\\" + FileName);
                            //if (Directory.Exists(@"" + Application.StartupPath))
                            //    System.Diagnostics.Process.Start(@"" + Application.StartupPath);
                        }
                        else
                        {

                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            if (e.ColumnIndex == 11 && e.RowIndex >= 0)
            {
                try
                {
                    DialogResult result = openFileDialog2.ShowDialog(); // Show the dialog.
                    if (result == DialogResult.OK) // result.
                    {
                        dgvLineTransaction.Rows[e.RowIndex].Cells[17].Value = shairedpath + "\\ActionPlanUpload\\" + Path.GetFileName(openFileDialog2.FileName);
                        dgvLineTransaction.Rows[e.RowIndex].Cells[16].Value = dgvLineTransaction.Rows[e.RowIndex].Cells[12].Value = Path.GetFileName(openFileDialog2.FileName);
                        if (!Directory.Exists(shairedpath))
                            Directory.CreateDirectory(shairedpath);
                        if (!Directory.Exists(shairedpath + "\\ActionPlanUpload\\"))
                            Directory.CreateDirectory(shairedpath + "\\ActionPlanUpload\\");
                        File.Copy(openFileDialog2.FileName, shairedpath + "\\ActionPlanUpload\\" + Path.GetFileName(openFileDialog2.FileName), true);
                        //}
                    }
                    else
                    {
                        dgvLineTransaction.Rows[e.RowIndex].Cells[17].Value = dgvLineTransaction.Rows[e.RowIndex].Cells[16].Value = dgvLineTransaction.Rows[e.RowIndex].Cells[12].Value = string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }

            }


            if (e.ColumnIndex == 12 && e.RowIndex >= 0)
            {
                string FilePath = string.Empty, FileName = string.Empty, LayoutFilePath = string.Empty;
                try
                {
                    LayoutFilePath = FilePath = Convert.ToString(dgvLineTransaction.Rows[e.RowIndex].Cells[17].Value);
                    if (LayoutFilePath != string.Empty)
                    {
                        if (File.Exists(@"" + LayoutFilePath.Replace("\\", "\\\\")))
                            FileName = Convert.ToString(dgvLineTransaction.Rows[e.RowIndex].Cells[16].Value);


                        if (File.Exists(@"" + LayoutFilePath.Replace("\\", "\\\\")))
                        {
                            if (!Directory.Exists(@"" + Application.StartupPath + "\\Files\\"))
                                Directory.CreateDirectory(@"" + Application.StartupPath + "\\Files\\");
                            File.Copy(@"" + FilePath.Replace("\\", "\\\\"), @"" + Application.StartupPath + "\\Files\\" + FileName, true);
                            //MessageBox.Show(@"" + Application.StartupPath + "\\Files\\" + FileName, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (File.Exists(@"" + Application.StartupPath + "\\Files\\" + FileName))
                                System.Diagnostics.Process.Start(@"" + Application.StartupPath + "\\Files\\" + FileName);
                            //if (Directory.Exists(@"" + Application.StartupPath))
                            //    System.Diagnostics.Process.Start(@"" + Application.StartupPath);
                        }
                        else
                        {

                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dateTimePicker_OnTextChange(object sender, EventArgs e)
        {
            // Saving the 'Selected Date on Calendar' into DataGridView current cell  
            dgvLineTransaction.CurrentCell.Value = oDateTimePicker.Text.ToString();
            dgvLineTransaction.Rows[dgvLineTransaction.CurrentCell.RowIndex].Cells[dgvLineTransaction.CurrentCell.ColumnIndex + 1].Value = oDateTimePicker.Value.AddYears(1).ToString("dd-MM-yyyy");
        }

        private void oDateTimePicker_CloseUp(object sender, EventArgs e)
        {
            // Hiding the control after use   
            oDateTimePicker.Visible = false;
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            if (cbLineDescription.SelectedIndex > 0)
                BindLineDescriptionTransactionGrid();
            else
                BindLineDescriptionTransactionDefault();
        }

        private static FrmLineTransactionNew frm = null;
        public static FrmLineTransactionNew GetInstance()
        {
            if (frm == null)
            {
                frm = new FrmLineTransactionNew();
            }
            return frm;
        }

        private void dgvLineTransaction_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

        }

        private void dgvLineTransaction_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            UpdateTextBoxColorToRedOnMinMaxVal();
        }

        private void UpdateTextBoxColorToRedOnMinMaxVal()
        {
            #region Old By Min Max value
            //foreach (DataGridViewRow item in dgvLineTransaction.Rows)
            //{
            //    if (Convert.ToString(item.Cells["MinVal"].Value) == "" || Convert.ToString(item.Cells["Result"].Value) == "" || Convert.ToString(item.Cells["MaxVal"].Value) == "")
            //    {

            //    }
            //    else
            //    {
            //        if ((Convert.ToDecimal(item.Cells["MinVal"].Value) > Convert.ToDecimal(item.Cells["Result"].Value)) || (Convert.ToDecimal(item.Cells["MaxVal"].Value) < Convert.ToDecimal(item.Cells["Result"].Value)))
            //        {
            //            item.Cells["Result"].Style.BackColor = Color.Red;
            //        }
            //        else
            //        {
            //            item.Cells["Result"].Style.BackColor = item.Cells["MinVal"].Style.BackColor;
            //        }
            //    }
            //}
            #endregion
            foreach (DataGridViewRow item in dgvLineTransaction.Rows)
            {
                if (Convert.ToString(item.Cells["MinVal"].Value) == "" || Convert.ToString(item.Cells["Result"].Value) == "")
                {
                    item.Cells[17].Value = item.Cells[16].Value = item.Cells[12].Value = string.Empty;
                }
                else
                {
                    try
                    {
                        if ((Convert.ToDecimal(item.Cells["MinVal"].Value) > Convert.ToDecimal(item.Cells["Result"].Value)))
                        {
                            item.Cells["Result"].Style.BackColor = Color.Red;
                            item.Cells["ActionPlanUpload"].ReadOnly = true;
                            item.Cells["ActionPlanRequiredRowNo"].Value = item.Cells["MinVal"].RowIndex;
                            item.Cells["ActionPlanUpload"].Value = "Upload";
                        }
                        else
                        {
                            item.Cells[17].Value = item.Cells[16].Value = item.Cells[12].Value = string.Empty;
                            item.Cells["Result"].Style.BackColor = item.Cells["MinVal"].Style.BackColor;
                            item.Cells["ActionPlanUpload"].ReadOnly = false;
                            item.Cells["ActionPlanRequiredRowNo"].Value = "";
                            item.Cells["ActionPlanUpload"].Value = "";
                        }
                    }
                    catch (Exception ex)
                    {
                        item.Cells[17].Value = item.Cells[16].Value = item.Cells[12].Value = string.Empty;
                        item.Cells["Result"].Style.BackColor = item.Cells["MinVal"].Style.BackColor;
                        item.Cells["ActionPlanUpload"].ReadOnly = false;
                        item.Cells["ActionPlanUpload"].Value = "";
                        item.Cells["ActionPlanRequiredRowNo"].Value = "";
                    }

                }
            }
        }

        private void dgvLineTransaction_Click(object sender, EventArgs e)
        {
            UpdateTextBoxColorToRedOnMinMaxVal();
        }

        private void dgvLineTransaction_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            UpdateTextBoxColorToRedOnMinMaxVal();
        }

        private System.Windows.Forms.DateTimePicker _validFromDate = new System.Windows.Forms.DateTimePicker();

        private System.Windows.Forms.DateTimePicker _validToDate = new System.Windows.Forms.DateTimePicker();
        private string _QualityRiskUploadFilePath;
        private DateTimePicker oDateTimePicker;
        private long _validationMasterId;

        private void lblQualityRiskFileName_Click(object sender, EventArgs e)
        {
            string FilePath = string.Empty, FileName = string.Empty, LayoutFilePath = string.Empty;
            try
            {
                LayoutFilePath = FilePath = _QualityRiskUploadFilePath;
                if (LayoutFilePath != string.Empty)
                {
                    if (File.Exists(@"" + LayoutFilePath.Replace("\\", "\\\\")))
                        FileName = Path.GetFileName(_QualityRiskUploadFilePath);


                    if (File.Exists(@"" + LayoutFilePath.Replace("\\", "\\\\")))
                    {
                        if (!Directory.Exists(@"" + Application.StartupPath + "\\Files\\"))
                            Directory.CreateDirectory(@"" + Application.StartupPath + "\\Files\\");
                        File.Copy(@"" + FilePath.Replace("\\", "\\\\"), @"" + Application.StartupPath + "\\Files\\" + FileName, true);
                        //MessageBox.Show(@"" + Application.StartupPath + "\\Files\\" + FileName, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (File.Exists(@"" + Application.StartupPath + "\\Files\\" + FileName))
                            System.Diagnostics.Process.Start(@"" + Application.StartupPath + "\\Files\\" + FileName);
                        //if (Directory.Exists(@"" + Application.StartupPath))
                        //    System.Diagnostics.Process.Start(@"" + Application.StartupPath);
                    }
                    else
                    {

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAddLayout_Click(object sender, EventArgs e)
        {

        }

        private void btnQualityRiskUpload_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = openFileDialogQualityRiskUpload.ShowDialog(); // Show the dialog.
                if (result == DialogResult.OK) // result.
                {
                    _QualityRiskUploadFilePath = string.Empty;
                    if (!(System.IO.Path.GetExtension(openFileDialogQualityRiskUpload.FileName) == ".xls" || System.IO.Path.GetExtension(openFileDialogQualityRiskUpload.FileName) == ".xlsx"))
                    {
                        //MessageBox.Show("Please select valid jpg, jpeg, png file ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        MessageBox.Show("Please select valid excel file ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        if (!System.IO.Directory.Exists(shairedpath))
                            System.IO.Directory.CreateDirectory(shairedpath);
                        if (!System.IO.Directory.Exists(shairedpath + "\\QualityRiskUpload\\"))
                            System.IO.Directory.CreateDirectory(shairedpath + "\\QualityRiskUpload\\");
                        lblQualityRiskFileName.Text = System.IO.Path.GetFileName(openFileDialogQualityRiskUpload.FileName);
                        File.Copy(openFileDialogQualityRiskUpload.FileName, shairedpath + "\\QualityRiskUpload\\" + System.IO.Path.GetFileName(openFileDialogQualityRiskUpload.FileName), true);
                        _QualityRiskUploadFilePath = shairedpath + "\\QualityRiskUpload\\" + System.IO.Path.GetFileName(openFileDialogQualityRiskUpload.FileName);
                        MessageBox.Show("Quality risk analysis file upload successfully ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        DataGridViewRow dr1 = new DataGridViewRow();
                        dr1.CreateCells(dgvQualityRiskAnalysis);  //
                        dr1.Cells[0].Value = "0";
                        dr1.Cells[1].Value = System.IO.Path.GetFileName(_QualityRiskUploadFilePath);
                        dr1.Cells[2].Value = System.IO.Path.GetFileName(_QualityRiskUploadFilePath);
                        dr1.Cells[3].Value = _QualityRiskUploadFilePath.Replace("\\\\", "\\");
                        dr1.Cells[4].Value = "Delete";
                        dgvQualityRiskAnalysis.Rows.Add(dr1);
                    }
                }
                else
                {
                    lblQualityRiskFileName.Text = _QualityRiskUploadFilePath = string.Empty;
                }



            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void btnAddRejection_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == new FrmLineTransactionRejectionMaster(0, Convert.ToInt64(cbLineDescription.SelectedValue)).ShowDialog())
            {
                //FrmLineTransactionRejectionMaster frm = new FrmLineTransactionRejectionMaster(0);
                //frm.Show();
            }
        }

        private void dgvQualityRiskAnalysis_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //e.ColumnIndex == 1 for file type view
                if (e.ColumnIndex == 1 && e.RowIndex >= 0)
                {
                    string FilePath = string.Empty, FileName = string.Empty;
                    try
                    {
                        FilePath = Convert.ToString(dgvQualityRiskAnalysis.Rows[e.RowIndex].Cells["QualityRiskAnalysisFilePath"].Value);
                        if (File.Exists(@"" + FilePath.Replace("\\", "\\\\")))
                            FileName = Convert.ToString(dgvQualityRiskAnalysis.Rows[e.RowIndex].Cells["QualityRiskAnalysisFileName"].Value);

                        if (File.Exists(@"" + FilePath.Replace("\\", "\\\\")))
                        {
                            if (!Directory.Exists(@"" + Application.StartupPath + "\\Files\\"))
                                Directory.CreateDirectory(@"" + Application.StartupPath + "\\Files\\");
                            File.Copy(@"" + FilePath.Replace("\\", "\\\\"), @"" + Application.StartupPath + "\\Files\\" + FileName, true);
                            //MessageBox.Show(@"" + Application.StartupPath + "\\Files\\" + FileName, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (File.Exists(@"" + Application.StartupPath + "\\Files\\" + FileName))
                                System.Diagnostics.Process.Start(@"" + Application.StartupPath + "\\Files\\" + FileName);
                            //if (Directory.Exists(@"" + Application.StartupPath))
                            //    System.Diagnostics.Process.Start(@"" + Application.StartupPath);
                        }
                        else
                        {

                        }

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                // If any cell is clicked on delete
                if (e.ColumnIndex == 4 && e.RowIndex >= 0)
                {
                    //long id = Convert.ToInt64(dgvQualityRiskAnalysis.Rows[e.RowIndex].Cells["tid"].Value.ToString());
                    dgvQualityRiskAnalysis.Rows.RemoveAt(e.RowIndex);
                    dgvQualityRiskAnalysis.Refresh(); // if needed
                }
            }
            catch (Exception ex)
            {
            }
        }


        private void BindQualityRiskAnalysisGrid(long LineTransactionMasterId) 
        {
            DataSet ds = LineTransaction_Class_Obj.Select_LineQualityRiskAnalysisFiles(LineTransactionMasterId);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgvQualityRiskAnalysis.DataSource = null;
                    dgvQualityRiskAnalysis.Rows.Clear();
                    string _UploadFilePath = ""; 
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        DataGridViewRow dr1 = new DataGridViewRow();
                        dr1.CreateCells(dgvQualityRiskAnalysis);  //

                        dr1.Cells[0].Value = Convert.ToString(item["Id"]);
                        _UploadFilePath = Convert.ToString(item["QualityRiskAnalysisFilePath"]);
                        try
                        {
                            dr1.Cells[1].Value = dr1.Cells[2].Value = Convert.ToString(item["QualityRiskAnalysisFileName"]); 
                            dr1.Cells[3].Value = _UploadFilePath;
                            dr1.Cells[4].Value = "Delete";
                        }
                        catch (Exception)
                        { }
                        dgvQualityRiskAnalysis.Rows.Add(dr1);
                    }
                }
                else
                {
                    dgvQualityRiskAnalysis.DataSource = null; dgvQualityRiskAnalysis.Refresh();
                    dgvQualityRiskAnalysis.Rows.Clear();
                }
            }
            else
            {
                dgvQualityRiskAnalysis.DataSource = null; dgvQualityRiskAnalysis.Refresh();
                dgvQualityRiskAnalysis.Rows.Clear();
            }
        }
    }
}
