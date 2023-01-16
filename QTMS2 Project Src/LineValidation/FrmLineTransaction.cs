using BusinessFacade;
using QTMS.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace QTMS.LineValidation
{
    public partial class FrmLineTransaction : Form
    {
        LineMaster_Class LayoutLineMaster_Class_Obj = new LineMaster_Class();
        LineTransactionMaster_Class LineTransactionMaster_Class_Obj = new LineTransactionMaster_Class();
        LineTransaction_Class LineTransaction_Class_Obj = new LineTransaction_Class();
        private string shairedpath;
        private bool isForModify;
        public long riskAnalysisTransactionId;

        public FrmLineTransaction()
        {
            InitializeComponent();
        }

        public FrmLineTransaction(bool isForModify)
        {
            InitializeComponent();
            this.isForModify = isForModify;
            if (this.isForModify)
            {
                this.toolStripLabel1.Text = this.Text = "Line Modification";
                lblDate.Visible = dtpDate.Visible = false;
            }
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
                _validToDate.CustomFormat = _validFromDate.CustomFormat = "dd-MMM-yyyy";
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
                if (this.isForModify)
                {
                    ds = LayoutLineMaster_Class_Obj.Select_LineTransactionModificationList();
                }
                else
                {
                    ds = LayoutLineMaster_Class_Obj.Select_LineMaster();
                }
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
            if (this.isForModify)
            {
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
                                break;
                            }
                            else
                            {
                                DataGridViewRow dr1 = new DataGridViewRow();
                                dr1.CreateCells(dgvLineTransaction);

                                dr1.Cells[0].Value = serialno;
                                dr1.Cells[1].Value = Convert.ToString(item["Name"]);
                                dr1.Cells[2].Value = Convert.ToString(item["Parameter"]);
                                dr1.Cells[3].Value = Convert.ToString(item["MinVal"]);
                                dr1.Cells[4].Value = Convert.ToString(item["MaxVal"]);
                                //Is for value //dr1.Cells[2].Value = Convert.ToString(item["Parameter"] + " " + item["Value"]);
                                dr1.Cells[6].Value = Convert.ToString(item["Result"]);
                                dr1.Cells[7].Value = "Upload";
                                dr1.Cells[9].Value = Convert.ToString(item["Id"]);
                                dr1.Cells[10].Value = Convert.ToString(item["AttachedFilePath"]);
                                dr1.Cells[8].Value = dr1.Cells[11].Value = Convert.ToString(item["AttachedFileName"]);
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
            else
            {
                //DataSet dsForCheckRecord = LineTransactionMaster_Class_Obj.Select_IsTransactionExist(Convert.ToInt64(cbLineDescription.SelectedValue), dtpDate.Value, LineTransactionMaster_Class_Obj.loginuser);
                //if (dsForCheckRecord.Tables.Count > 0)
                {
                  //  if ((Convert.ToInt32(dsForCheckRecord.Tables[0].Rows[0][0])) == 0)
                    {
                        DataSet ds = LineTransactionMaster_Class_Obj.Select_LayoutLineTransactionMasterByLineDescriptionId(Convert.ToInt64(cbLineDescription.SelectedValue));
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
                                        _validFromDate.Value = Convert.ToDateTime(item["ValidFrom"]);
                                        _validToDate.Value = Convert.ToDateTime(item["ValidTo"]); 
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
                                        dr1.Cells[2].Value = Convert.ToString(item["Parameter"]);
                                        dr1.Cells[3].Value = Convert.ToString(item["MinVal"]);
                                        dr1.Cells[4].Value = Convert.ToString(item["MaxVal"]);
                                        //Is for value //dr1.Cells[2].Value = Convert.ToString(item["Parameter"] + " " + item["Value"]);
                                        dr1.Cells[6].Value = "";
                                        dr1.Cells[7].Value = "Upload";
                                        dr1.Cells[9].Value = Convert.ToString(item["Id"]);

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
                    //else
                    //{
                    //    BindLineDescriptionTransactionDefault();
                    //    MessageBox.Show("Record already exist", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //}
                }
            }
        }

        private void BindLineDescriptionTransactionDefault()
        {
            dgvLineTransaction.DataSource = null;
            dgvLineTransaction.Rows.Clear();
            dgvLineTransaction.AutoGenerateColumns = false;
            dgvLineTransaction.Visible = false;
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
                    int index = 1;
                    foreach (DataGridViewRow item in dgvLineTransaction.Rows)
                    {
                        if (index == 1)
                            parameter = "short term colorant";
                        else if(index == 2)
                            parameter = "short term developer";
                        else if (index == 3)
                            parameter = "long term colorant";
                        else
                            parameter = "long term developer";
                        if (Convert.ToString(item.Cells["Result"].Value) == "")
                        {
                            msg = "Please enter result value of "+ parameter +" , is mandatory";
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
                        if (msg != "")
                        {
                            MessageBox.Show(msg, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        index++;
                    }
                    if (!(dtpDate.Value.Date >= _validFromDate.Value.Date && dtpDate.Value.Date <= _validToDate.Value.Date))
                    {
                        MessageBox.Show("Please select date between " + _validFromDate.Value.ToString("dd-MMM-yyyy") + " and " + _validToDate.Value.ToString("dd-MMM-yyyy") + " according to master", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (this.isForModify)
                    {
                        foreach (DataGridViewRow item in dgvLineTransaction.Rows)
                        {
                            LineTransaction_Class_Obj.id = Convert.ToInt64(item.Cells["Id"].Value);
                            LineTransaction_Class_Obj.name = Convert.ToString(item.Cells["NameColumn"].Value);
                            LineTransaction_Class_Obj.parameter = Convert.ToString(item.Cells["Parameter"].Value);
                            LineTransaction_Class_Obj.minValue = Convert.ToString(item.Cells["MinVal"].Value);
                            LineTransaction_Class_Obj.maxValue = Convert.ToString(item.Cells["MaxVal"].Value);
                            //LineTransaction_Class_Obj.value = Convert.ToString(item.Cells["Value"].Value);
                            LineTransaction_Class_Obj.result = Convert.ToString(item.Cells["Result"].Value);
                            LineTransaction_Class_Obj.status = Convert.ToString(item.Cells[7].Value); //Convert.ToString(item.Cells["Status"].Value);
                            LineTransaction_Class_Obj.attachedFileName = Convert.ToString(item.Cells["AttachedFileName"].Value);
                            LineTransaction_Class_Obj.attachedFilePath = Convert.ToString(item.Cells["AttachedFilePath"].Value).Replace("\\\\", "\\");
                            LineTransaction_Class_Obj.qualityRiskAnalysis = txtQualityRiskAnalysis.Text.Trim();
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
                            //if (LineTransactionMaster_Class_Obj.id == 0)
                            //    b = LineTransaction_Class_Obj.Insert_LineTransaction();
                            //else
                            //{
                                b = LineTransaction_Class_Obj.Update_LineTransaction();
                            //}
                            MessageBox.Show("Record Modified Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BindLineDescriptionTransactionDefault();
                            cbLineDescription.SelectedIndex = 0;
                            txtQualityRiskAnalysis.Text = string.Empty;
                        }
                    }
                    else
                    {
                        DataSet dsforTransactionMasterId = new DataSet();
                        LineTransaction_Class_Obj.lineTransactionMasterId = 0;
                        foreach (DataGridViewRow item in dgvLineTransaction.Rows)
                        {
                            LineTransaction_Class_Obj.id = LineTransactionMaster_Class_Obj.id = 0; //Convert.ToInt64(item.Cells["Id"].Value);
                            LineTransaction_Class_Obj.layoutLineValidationTransactionId = LineTransactionMaster_Class_Obj.layoutLineValidationTransactionId = Convert.ToInt64(item.Cells["Id"].Value);
                            LineTransaction_Class_Obj.lineDescription = LineTransactionMaster_Class_Obj.lineDescription = Convert.ToInt64(cbLineDescription.SelectedValue);
                            LineTransaction_Class_Obj.qualityRiskAnalysis = txtQualityRiskAnalysis.Text.Trim();
                            LineTransactionMaster_Class_Obj.date = dtpDate.Value;

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
                                    LineTransaction_Class_Obj.maxValue = Convert.ToString(item.Cells["MaxVal"].Value);
                                    //LineTransaction_Class_Obj.value = Convert.ToString(item.Cells["Value"].Value);
                                    LineTransaction_Class_Obj.result = Convert.ToString(item.Cells["Result"].Value);
                                    LineTransaction_Class_Obj.status = Convert.ToString(item.Cells[7].Value); //Convert.ToString(item.Cells["Status"].Value);
                                    LineTransaction_Class_Obj.attachedFileName = Convert.ToString(item.Cells["AttachedFileName"].Value);
                                    LineTransaction_Class_Obj.attachedFilePath = Convert.ToString(item.Cells["AttachedFilePath"].Value).Replace("\\\\", "\\");
                                    LineTransaction_Class_Obj.qualityRiskAnalysis = txtQualityRiskAnalysis.Text.Trim();
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
                            LineTransaction_Class_Obj.minValue =  LineTransaction_Class_Obj.maxValue = LineTransaction_Class_Obj.result = string.Empty;
                            LineTransaction_Class_Obj.status = LineTransaction_Class_Obj.attachedFileName = LineTransaction_Class_Obj.attachedFilePath = string.Empty;
                            LineTransaction_Class_Obj.qualityRiskAnalysis = txtQualityRiskAnalysis.Text.Trim();
                            if (LineTransactionMaster_Class_Obj.id == 0)
                                b = LineTransaction_Class_Obj.Insert_LineTransaction();
                            else
                            {
                                b = LineTransactionMaster_Class_Obj.Update_LineTransactionMaster();
                            }
                            MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BindLineDescriptionTransactionDefault();
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
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void dgvLineTransaction_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // If any cell is clicked on the Second column which is our date Column  
            if (e.ColumnIndex == 7 && e.RowIndex >= 0)
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
                        dgvLineTransaction.Rows[e.RowIndex].Cells[10].Value = shairedpath + "\\Transaction\\" + Path.GetFileName(openFileDialog1.FileName);
                        dgvLineTransaction.Rows[e.RowIndex].Cells[8].Value = dgvLineTransaction.Rows[e.RowIndex].Cells[11].Value = Path.GetFileName(openFileDialog1.FileName);
                        if (!Directory.Exists(shairedpath))
                            Directory.CreateDirectory(shairedpath);
                        if (!Directory.Exists(shairedpath + "\\Transaction\\"))
                            Directory.CreateDirectory(shairedpath + "\\Transaction\\");
                        File.Copy(openFileDialog1.FileName, shairedpath + "\\Transaction\\" + Path.GetFileName(openFileDialog1.FileName), true);
                        //}
                    }
                    else
                    {
                        dgvLineTransaction.Rows[e.RowIndex].Cells[10].Value = dgvLineTransaction.Rows[e.RowIndex].Cells[8].Value = dgvLineTransaction.Rows[e.RowIndex].Cells[11].Value = string.Empty;
                    }
                }
                catch (Exception ex)
                {
                    throw;
                }

            }

            if (e.ColumnIndex == 8 && e.RowIndex >= 0)
            {
                string FilePath = string.Empty, FileName = string.Empty, LayoutFilePath = string.Empty;
                try
                {
                    LayoutFilePath = FilePath = Convert.ToString(dgvLineTransaction.Rows[e.RowIndex].Cells[10].Value);
                    if (LayoutFilePath != string.Empty)
                    {
                        if (File.Exists(@"" + LayoutFilePath.Replace("\\", "\\\\")))
                            FileName = Convert.ToString(dgvLineTransaction.Rows[e.RowIndex].Cells[8].Value);


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


        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            if (cbLineDescription.SelectedIndex > 0)
                BindLineDescriptionTransactionGrid();
            else
                BindLineDescriptionTransactionDefault();
        }

        private static FrmLineTransaction frm = null;
        public static FrmLineTransaction GetInstance(bool isForModify)
        {
            if (frm == null)
            {
                frm = new FrmLineTransaction(isForModify);
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
            foreach (DataGridViewRow item in dgvLineTransaction.Rows)
            {
                if (Convert.ToString(item.Cells["MinVal"].Value) == "" || Convert.ToString(item.Cells["Result"].Value) == "" || Convert.ToString(item.Cells["MaxVal"].Value) == "")
                {

                }
                else
                {
                    if ((Convert.ToDecimal(item.Cells["MinVal"].Value) > Convert.ToDecimal(item.Cells["Result"].Value)) || (Convert.ToDecimal(item.Cells["MaxVal"].Value) < Convert.ToDecimal(item.Cells["Result"].Value)))
                    {
                        item.Cells["Result"].Style.BackColor = Color.Red;
                    }
                    else
                    {
                        item.Cells["Result"].Style.BackColor = item.Cells["MinVal"].Style.BackColor;
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

        private System.Windows.Forms.DateTimePicker _validFromDate=new System.Windows.Forms.DateTimePicker();

        private System.Windows.Forms.DateTimePicker _validToDate =new System.Windows.Forms.DateTimePicker();
    }
}
