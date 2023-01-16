using BusinessFacade;
using QTMS.Tools;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace QTMS.LineValidation
{
    public partial class FrmLineTransactionModification : Form
    {
        LineMaster_Class LayoutLineMaster_Class_Obj = new LineMaster_Class();
        DateTime _year = DateTime.Now; 
        LineTransactionMaster_Class LineTransactionMaster_Class_Obj = new LineTransactionMaster_Class();
        LineTransaction_Class LineTransaction_Class_Obj = new LineTransaction_Class();
        private string shairedpath;
        private bool isForModify;
        public long _lineDescriptionId = 0;
        public long riskAnalysisTransactionId;

        public FrmLineTransactionModification()
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
                ds = LayoutLineMaster_Class_Obj.Select_LineTransactionModificationList();
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
            DataSet ds = LineTransactionMaster_Class_Obj.Select_LayoutLineTransactionForModification(Convert.ToInt64(cbLineDescription.SelectedValue), dtpDate.Value, LineTransactionMaster_Class_Obj.loginuser);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
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

                            _lineDescriptionId = Convert.ToInt64(item["LayoutLineDescriptionId"]);

                            BindQualityRiskAnalysisGrid(Convert.ToInt32(item["LineTransactionMasterId"]));
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
                            dr1.Cells[2].Value = Convert.ToString(item["Parameter"]) + " >= " + Convert.ToString(item["MinVal"]);
                            dr1.Cells[3].Value = Convert.ToDateTime(item["TransactionDate"]).ToString("dd-MM-yyyy");// Convert.ToString(item["Parameter"]);
                            dr1.Cells[4].Value = Convert.ToDateTime(item["DueDate"]).ToString("dd-MM-yyyy");
                            _year = Convert.ToDateTime(item["TransactionDate"]);
                            dgvLineTransaction.Columns[3].DefaultCellStyle.Format = "dd-MM-yyyy";
                            dgvLineTransaction.Columns[4].DefaultCellStyle.Format = "dd-MM-yyyy";
                            dr1.Cells[5].Value = Convert.ToString(item["MinVal"]);

                            dr1.Cells[7].Value = "";
                            dr1.Cells[8].Value = Convert.ToString(item["Result"]);
                            dr1.Cells[9].Value = "Upload";
                            dr1.Cells[10].Value = dr1.Cells[15].Value = Convert.ToString(item["AttachedFileName"]); //Convert.ToString(item["Status"]);
                            dr1.Cells[11].Value = "Upload";
                            dr1.Cells[14].Value = Convert.ToString(item["AttachedFilePath"]);
                            dr1.Cells[15].Value = Convert.ToString(item["AttachedFileName"]);
                            dr1.Cells[12].Value = dr1.Cells[16].Value = Convert.ToString(item["ActionPlanFileName"]);
                            dr1.Cells[17].Value = Convert.ToString(item["ActionPlanFilePath"]);
                            dr1.Cells[13].Value = Convert.ToString(item["Id"]);
                            if (!string.IsNullOrEmpty(Convert.ToString(item["Result"])))
                            {
                                dr1.Cells[11].Value = "Upload";
                            }
                            else
                            {
                                dr1.Cells[11].Value = "";
                            }
                            serialno++;
                            dgvLineTransaction.Rows.Add(dr1);
                        }
                    }
                    if (ds.Tables[0].Rows.Count == 4)
                    {
                        riskAnalysisTransactionId = 0;
                        txtQualityRiskAnalysis.Text = string.Empty;
                    }
                    BindQualityRiskAnalysisGrid(Convert.ToInt64(cbLineDescription.SelectedValue));
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

        private void BindLineDescriptionTransactionDefault()
        {
            lblQualityRiskFileName.Text = _QualityRiskUploadFilePath = string.Empty;
            dtpDate.Value = DateTime.Now;
            dgvLineTransaction.DataSource = null;
            dgvLineTransaction.Rows.Clear();
            dgvLineTransaction.AutoGenerateColumns = false;
            dgvLineTransaction.Visible = false;
            dgvQualityRiskAnalysis.DataSource = null; dgvQualityRiskAnalysis.Refresh();
            dgvQualityRiskAnalysis.Rows.Clear();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
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
                            msg = "Please enter result value of " + parameter + " , is mandatory";
                        }
                        else
                        {
                            allParameterDoneCount = allParameterDoneCount + 1;
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
                        LineTransaction_Class_Obj.dueDate = DateTime.Parse(Convert.ToString(item.Cells["DueDate"].Value), usDtfi);
                        //LineTransaction_Class_Obj.transactionDate = Convert.ToDateTime(item.Cells["TransactionDate"].Value);
                        //LineTransaction_Class_Obj.dueDate = Convert.ToDateTime(item.Cells["DueDate"].Value);
                        LineTransaction_Class_Obj.actionPlanFileName = Convert.ToString(item.Cells["ActionPlanUploadFileName"].Value);
                        LineTransaction_Class_Obj.actionPlanFilePath = Convert.ToString(item.Cells["ActionPlanUploadFilePath"].Value).Replace("\\\\", "\\");

                        if (!string.IsNullOrEmpty(_QualityRiskUploadFilePath))
                        {
                            LineTransaction_Class_Obj.qualityRiskAnalysisFilePath = _QualityRiskUploadFilePath.Replace("\\\\", "\\");
                        }
                        b = LineTransaction_Class_Obj.Update_LineTransaction();
                    }
                    if (b == true)
                    {
                        if (allParameterDoneCount == 4)
                        {
                            LineTransactionMaster_Class_Obj.allParameterDone = 1;
                        }
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
                        MessageBox.Show("Record Modified Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        LineTransactionMaster_Class_Obj.id = Convert.ToInt64(cbLineDescription.SelectedValue);
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
                                LineTransaction_Class_Obj.Insert_LineQualityRiskAnalysisFileMaster(LineTransactionMaster_Class_Obj.id, Convert.ToString(item.Cells["QualityRiskAnalysisFilePath"].Value),Convert.ToString(item.Cells["QualityRiskAnalysisFileName"].Value));
                            }
                            catch (Exception ex)
                            {

                            }
                        }
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
        }

        private void dgvLineTransaction_CellClick(object sender, DataGridViewCellEventArgs e)
        {
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

                // It returns the retangular area that represents the Display area for a cell  
                Rectangle oRectangle = dgvLineTransaction.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                //Setting area for DateTimePicker Control  
                oDateTimePicker.Size = new Size(oRectangle.Width, oRectangle.Height);
                

                oDateTimePicker.MinDate = new DateTime(_year.Year, 1, 1);
                oDateTimePicker.MaxDate = new DateTime(_year.Year, 12, 31);

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

        private static FrmLineTransactionModification frm = null;
        public static FrmLineTransactionModification GetInstance()
        {
            if (frm == null)
            {
                frm = new FrmLineTransactionModification();
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
                            item.Cells["ActionPlanRequiredRowNo"].Value = item.Cells["MinVal"].RowIndex;
                            item.Cells["ActionPlanUpload"].Value = "Upload";
                        }
                        else
                        {
                            item.Cells[17].Value = item.Cells[16].Value = item.Cells[12].Value = string.Empty;
                            item.Cells["Result"].Style.BackColor = item.Cells["MinVal"].Style.BackColor;
                            item.Cells["ActionPlanRequiredRowNo"].Value = "";
                            item.Cells["ActionPlanUpload"].Value = "";
                        }
                    }
                    catch (Exception ex)
                    {
                        item.Cells[17].Value = item.Cells[16].Value = item.Cells[12].Value = string.Empty;
                        item.Cells["Result"].Style.BackColor = item.Cells["MinVal"].Style.BackColor;
                        item.Cells["ActionPlanRequiredRowNo"].Value = "";
                        item.Cells["ActionPlanUpload"].Value = "";
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

                        DataGridViewRow dr1 = new DataGridViewRow();
                        dr1.CreateCells(dgvQualityRiskAnalysis);  //
                        dr1.Cells[0].Value = "0";
                        dr1.Cells[1].Value = System.IO.Path.GetFileName(_QualityRiskUploadFilePath);
                        dr1.Cells[2].Value = System.IO.Path.GetFileName(_QualityRiskUploadFilePath);
                        dr1.Cells[3].Value = _QualityRiskUploadFilePath.Replace("\\\\", "\\");
                        dr1.Cells[4].Value = "Delete";
                        dgvQualityRiskAnalysis.Rows.Add(dr1);
                        MessageBox.Show("Layout file upload successfully ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            if (DialogResult.OK == new FrmLineTransactionRejectionMaster(0, _lineDescriptionId).ShowDialog()) 
            {
                //FrmLineTransactionRejectionMaster frm = new FrmLineTransactionRejectionMaster(0);
                //frm.Show();
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
    }
}
