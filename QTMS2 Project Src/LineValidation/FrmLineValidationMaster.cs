using BusinessFacade;
using QTMS.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QTMS.LineValidation
{
    public partial class FrmLineValidationMaster : Form
    {
        private DateTimePicker cellDateTimePicker = new DateTimePicker();
        LineMaster_Class LayoutLineMaster_Class_Obj = new LineMaster_Class();
        LayoutLineValidationTransaction_Class LayoutLineValidationTransaction_Class_Obj = new LayoutLineValidationTransaction_Class();
        List<LayoutLineValidationTransaction_Class> ListLayoutLineValidationTransaction_Class = new List<LayoutLineValidationTransaction_Class>();
        public FrmLineValidationMaster()
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

        private void FrmLineValidationMaster_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Normal;
                Bind_LineDescription();
                this.cellDateTimePicker.CustomFormat = "dd-MMM-yyyy";
                this.cellDateTimePicker.Format = DateTimePickerFormat.Custom;
                LayoutLineValidationTransaction_Class_Obj.loginuser = FrmMain.LoginID;

                //dtpLTCDate.MinDate = dtpLTDDate.MinDate = dtpSTCDate.MinDate = dtpSTDDate.MinDate = DateTime.Now;
                dtpFromDate.CustomFormat = dtpToDate.CustomFormat = dtpLTCDate.CustomFormat = dtpLTDDate.CustomFormat = dtpSTCDate.CustomFormat = dtpSTDDate.CustomFormat = "dd-MMM-yyyy";
                dtpFromDate.Format = dtpToDate.Format = dtpLTCDate.Format = dtpLTDDate.Format = dtpSTCDate.Format = dtpSTDDate.Format = DateTimePickerFormat.Custom;
                dtpFromDate.Value = dtpToDate.Value = DateTime.Now;
                Painter.Paint(this);
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
                DataSet ds = LayoutLineMaster_Class_Obj.Select_LineMaster();
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
                BindLineDescriptionTransaction();
            else
                ResetDescriptionTransaction();
            //if (cbLineDescription.SelectedIndex > 0)
            //    BindLineDescriptionTransactionGrid();
            //else
            //    BindLineDescriptionTransactionDefault();
        }

        private void BindLineDescriptionTransaction()
        {
            ListLayoutLineValidationTransaction_Class = new List<LayoutLineValidationTransaction_Class>();
            DataSet ds = LayoutLineValidationTransaction_Class_Obj.Select_LayoutLineTransactionMasterByLineDescriptionId(Convert.ToInt64(cbLineDescription.SelectedValue));
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    int index = 1;
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        LayoutLineValidationTransaction_Class Obj = new LayoutLineValidationTransaction_Class();
                        if (index == 1)
                        {
                            txtSTCMin.Text = Convert.ToString(item["MinVal"]);
                            txtSTCMax.Text = Convert.ToString(item["MaxVal"]);
                            //txtSTCValue.Text = Convert.ToString(item["Value"]);
                            STCvaliddummydateforFrom.Text = Convert.ToString(item["ValidFrom"]);

                            if (Convert.ToString(item["ValidTo"]) == "")
                            {
                                Obj.validTo = Convert.ToDateTime(item["ValidFrom"]);
                                dtpSTCDate.Value = Convert.ToDateTime(item["ValidFrom"]).Date;
                            }
                            else
                            {
                                Obj.validTo = Convert.ToDateTime(item["ValidTo"]);
                                dtpSTCDate.Value = Convert.ToDateTime(item["ValidTo"]);
                            }
                        }
                        else if (index == 2)
                        {
                            txtSTDMin.Text = Convert.ToString(item["MinVal"]);
                            txtSTDMax.Text = Convert.ToString(item["MaxVal"]);
                            //txtSTDValue.Text = Convert.ToString(item["Value"]);
                            STDvaliddummydateforFrom.Text = Convert.ToString(item["ValidFrom"]);

                            if (Convert.ToString(item["ValidTo"]) == "")
                            {
                                Obj.validTo = Convert.ToDateTime(item["ValidFrom"]);
                                dtpSTDDate.Value = Convert.ToDateTime(item["ValidFrom"]).Date;
                            }
                            else
                            {
                                Obj.validTo = Convert.ToDateTime(item["ValidTo"]);
                                dtpSTDDate.Value = Convert.ToDateTime(item["ValidTo"]);
                            }
                        }
                        else if (index == 3)
                        {
                            txtLTCMin.Text = Convert.ToString(item["MinVal"]);
                            txtLTCMax.Text = Convert.ToString(item["MaxVal"]);
                            //txtLTCValue.Text = Convert.ToString(item["Value"]);
                            LTCvaliddummydateforFrom.Text = Convert.ToString(item["ValidFrom"]);

                            if (Convert.ToString(item["ValidTo"]) == "")
                            {
                                Obj.validTo = Convert.ToDateTime(item["ValidFrom"]);
                                dtpLTCDate.Value = Convert.ToDateTime(item["ValidFrom"]).Date;
                            }
                            else
                            {
                                Obj.validTo = Convert.ToDateTime(item["ValidTo"]);
                                dtpLTCDate.Value = Convert.ToDateTime(item["ValidTo"]);
                            }
                        }
                        else if (index == 4)
                        {
                            txtLTDMin.Text = Convert.ToString(item["MinVal"]);
                            txtLTDMax.Text = Convert.ToString(item["MaxVal"]);
                            //txtLTDValue.Text = Convert.ToString(item["Value"]);
                            LTDvaliddummydateforFrom.Text = Convert.ToString(item["ValidFrom"]);

                            if (Convert.ToString(item["ValidTo"]) == "")
                            {
                                Obj.validTo = Convert.ToDateTime(item["ValidFrom"]);
                                dtpLTDDate.Value = Convert.ToDateTime(item["ValidFrom"]).Date;
                            }
                            else
                            {
                                Obj.validTo = Convert.ToDateTime(item["ValidTo"]);
                                dtpLTDDate.Value = Convert.ToDateTime(item["ValidTo"]);
                            }
                        }
                        else
                        {
                            MessageBox.Show("getting wrong", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        //Obj.validTo = Convert.ToDateTime(item["ValidFrom"]);
                        Obj.validTo = Convert.ToDateTime(item["ValidTo"]);

                        dtpFromDate.Value = Convert.ToDateTime(item["ValidFrom"]).Date;
                        dtpToDate.Value = Convert.ToDateTime(item["ValidTo"]);

                        Obj.lineDescription = Convert.ToInt64(cbLineDescription.SelectedValue);
                        Obj.minValue = Convert.ToString(item["MinVal"]);
                        Obj.maxValue = Convert.ToString(item["MaxVal"]);
                        Obj.value = Convert.ToString(item["Value"]);
                        Obj.name = Convert.ToString(item["Name"]);
                        Obj.parameter = Convert.ToString(item["Parameter"]);
                        Obj.id = Convert.ToInt64(item["Id"]);
                        Obj.validFrom = Convert.ToDateTime(item["ValidFrom"]);

                        index++;
                        ListLayoutLineValidationTransaction_Class.Add(Obj);
                    }
                }
                else
                    ResetDescriptionTransaction();
            }
            else
                ResetDescriptionTransaction();
        }

        private void ResetDescriptionTransaction()
        {
            EmptyTextBoxes(panelFill);
            ResetDtp();
        }

        private void ResetDtp()
        {
            dtpLTCDate.Value = dtpLTDDate.Value = dtpSTCDate.Value = dtpSTDDate.Value = DateTime.Now;
        }

        public static void EmptyTextBoxes(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    ((TextBox)(c)).Text = string.Empty;
                }
            }
        }

        private void BindLineDescriptionTransactionGrid()
        {
            DataSet ds = LayoutLineValidationTransaction_Class_Obj.Select_LayoutLineTransactionMasterByLineDescriptionId(Convert.ToInt64(cbLineDescription.SelectedValue));
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgvLineDescriptionTransaction.DataSource = null;
                    dgvLineDescriptionTransaction.Rows.Clear();
                    int serialno = 1;
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        DataGridViewRow dr1 = new DataGridViewRow();
                        dr1.CreateCells(dgvLineDescriptionTransaction);  //
                        dr1.Cells[0].Value = serialno;
                        dr1.Cells[1].Value = Convert.ToString(item["Name"]);
                        dr1.Cells[2].Value = Convert.ToString(item["Parameter"]);
                        dr1.Cells[3].Value = Convert.ToString(item["MinVal"]);
                        dr1.Cells[4].Value = Convert.ToString(item["MaxVal"]);
                        dr1.Cells[5].Value = Convert.ToString(item["Value"]);
                        dr1.Cells[6].Value = Convert.ToString(item["ValidFrom"]) != string.Empty ? Convert.ToDateTime(item["ValidFrom"]).ToString("dd-MMM-yyyy") : "";
                        dr1.Cells[7].Value = Convert.ToString(item["ValidTo"]) != string.Empty ? Convert.ToDateTime(item["ValidTo"]).ToString("dd-MMM-yyyy") : "";
                        dr1.Cells[8].Value = Convert.ToString(item["Id"]);
                        dr1.Cells[9].Value = Convert.ToString(item["ValidFrom"]);
                        serialno++;
                        dgvLineDescriptionTransaction.Rows.Add(dr1);
                    }
                }
                else
                    BindLineDescriptionTransactionDefault();
            }
            else
                BindLineDescriptionTransactionDefault();
        }

        private void BindLineDescriptionTransactionDefault()
        {
            dgvLineDescriptionTransaction.DataSource = null;
            dgvLineDescriptionTransaction.Rows.Clear();
            dgvLineDescriptionTransaction.AutoGenerateColumns = false;
            DataGridViewRow dr1 = new DataGridViewRow();
            dr1.CreateCells(dgvLineDescriptionTransaction);  //
            dr1.Cells[0].Value = "1";
            dr1.Cells[1].Value = "Short Term Colorant";
            dr1.Cells[2].Value = "CpK";
            dr1.Cells[4].Value = DateTime.Now.ToString("dd-MMM-yyyy");
            dr1.Cells[5].Value = null;
            dr1.Cells[6].Value = "0";
            dgvLineDescriptionTransaction.Rows.Add(dr1);
            DataGridViewRow dr2 = new DataGridViewRow();
            dr2.CreateCells(dgvLineDescriptionTransaction);  //
            dr2.Cells[0].Value = "2";
            dr2.Cells[1].Value = "Short Term Developer";
            dr2.Cells[2].Value = "CpK";
            dr2.Cells[4].Value = DateTime.Now.ToString("dd-MMM-yyyy");
            dr2.Cells[5].Value = null;
            dr2.Cells[6].Value = "0";
            dgvLineDescriptionTransaction.Rows.Add(dr2);
            DataGridViewRow dr3 = new DataGridViewRow();
            dr3.CreateCells(dgvLineDescriptionTransaction);  //
            dr3.Cells[0].Value = "3";
            dr3.Cells[1].Value = "Long Term Colorant";
            dr3.Cells[2].Value = "PpK";
            dr3.Cells[4].Value = DateTime.Now.ToString("dd-MMM-yyyy");
            dr3.Cells[5].Value = null;
            dr3.Cells[6].Value = "0";
            dgvLineDescriptionTransaction.Rows.Add(dr3);
            DataGridViewRow dr4 = new DataGridViewRow();
            dr4.CreateCells(dgvLineDescriptionTransaction);  //
            dr4.Cells[0].Value = "4";
            dr4.Cells[1].Value = "Long Term Developer";
            dr4.Cells[2].Value = "PpK";
            dr4.Cells[4].Value = DateTime.Now.ToString("dd-MMM-yyyy");
            dr4.Cells[5].Value = null;
            dr4.Cells[6].Value = "0";
            dgvLineDescriptionTransaction.Rows.Add(dr4);
        }

        private void BtnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbLineDescription.SelectedIndex > 0)
                {
                    bool b = false;
                    int index = 1;

                    if (!IsValid())
                        return;
                    if (!CheckMinMaxValue())
                        return;
                    if(ListLayoutLineValidationTransaction_Class.Count == 0)
                    {
                        LayoutLineValidationTransaction_Class Obj = new LayoutLineValidationTransaction_Class();

                        Obj.minValue = txtSTCMin.Text.Trim();
                        Obj.minValue = txtSTCMax.Text.Trim();
                        //Obj.validFrom = dtpSTCDate.Value;
                        Obj.validFrom = dtpFromDate.Value;
                        Obj.id = 0;
                        Obj.lineDescription = Convert.ToInt64(cbLineDescription.SelectedValue);
                        Obj.name = lblSTC.Text;
                        Obj.parameter = "CpK";
                        //Obj.value = Convert.ToString(item.Cells["Value"].Value);
                        ListLayoutLineValidationTransaction_Class.Add(Obj);

                        Obj = new LayoutLineValidationTransaction_Class();
                        Obj.minValue = txtSTDMin.Text.Trim();
                        Obj.minValue = txtSTDMax.Text.Trim();
                        //Obj.validFrom = dtpSTCDate.Value;
                        Obj.validFrom = dtpFromDate.Value;
                        Obj.id = 0;
                        Obj.lineDescription = Convert.ToInt64(cbLineDescription.SelectedValue);
                        Obj.name = lblSTD.Text;
                        Obj.parameter = "CpK";
                        //Obj.value = Convert.ToString(item.Cells["Value"].Value);
                        ListLayoutLineValidationTransaction_Class.Add(Obj);

                        Obj = new LayoutLineValidationTransaction_Class();
                        Obj.minValue = txtLTCMin.Text.Trim();
                        Obj.minValue = txtLTCMax.Text.Trim();
                        //Obj.validFrom = dtpLTCDate.Value;
                        Obj.validFrom = dtpFromDate.Value;
                        Obj.id = 0;
                        Obj.lineDescription = Convert.ToInt64(cbLineDescription.SelectedValue);
                        Obj.name = lblLTC.Text;
                        Obj.parameter = "PpK";
                        //Obj.value = Convert.ToString(item.Cells["Value"].Value);
                        ListLayoutLineValidationTransaction_Class.Add(Obj);

                        Obj = new LayoutLineValidationTransaction_Class();
                        Obj.minValue = txtLTDMin.Text.Trim();
                        Obj.minValue = txtLTDMax.Text.Trim();
                        //Obj.validFrom = dtpLTCDate.Value;
                        Obj.validFrom = dtpFromDate.Value;
                        Obj.id = 0;
                        Obj.lineDescription = Convert.ToInt64(cbLineDescription.SelectedValue);
                        Obj.name = lblLTD.Text;
                        Obj.parameter = "PpK";
                        //Obj.value = Convert.ToString(item.Cells["Value"].Value);
                        ListLayoutLineValidationTransaction_Class.Add(Obj);

                    }

                    foreach (LayoutLineValidationTransaction_Class item in ListLayoutLineValidationTransaction_Class)
                    {
                        try
                        {
                            string msg = "";
                            if (index == 1)
                            {
                                item.minValue = txtSTCMin.Text;
                                item.maxValue = txtSTCMax.Text;
                                //item.value = txtSTCValue.Text;
                            }
                            else if (index == 2)
                            {
                                item.minValue = txtSTDMin.Text;
                                item.maxValue = txtSTDMax.Text;
                                //item.value = txtSTDValue.Text;
                            }
                            else if (index == 3)
                            {
                                item.minValue = txtLTCMin.Text;
                                item.maxValue = txtLTCMax.Text;
                                //item.value = txtLTCValue.Text;
                            }
                            else if (index == 4)
                            {
                                item.minValue = txtLTDMin.Text;
                                item.maxValue = txtLTDMax.Text;
                                //item.value = txtLTDValue.Text;
                            }

                            //if (index == 1 || index == 2)
                            //{
                            //    if (index == 1)
                            //        msg = "Please enter the limits of short term colorant as CpK ≥ 1.67";
                            //    else
                            //        msg = "Please enter the limits of short term developer as CpK ≥ 1.67";
                            //    if (Convert.ToDecimal(item.value) == 0)
                            //    {
                            //        if (index == 1)
                            //            msg = "Please enter the short term colorant as CpK is mandatory";
                            //        else
                            //            msg = "Please enter the short term developer as CpK is mandatory";
                            //    }
                            //    if (Convert.ToDecimal(item.value) < Convert.ToDecimal(1.67))
                            //    {
                            //        MessageBox.Show(msg, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //        return;
                            //    }
                            //}
                            //else if (index == 3 || index == 4)
                            //{
                            //    if (index == 1)
                            //        msg = "Please enter the limits of long term colorant as PpK ≥ 1.33";
                            //    else
                            //        msg = "Please enter the limits of long term developer as PpK ≥ 1.33";
                            //    if (Convert.ToDecimal(item.value) == 0)
                            //    {
                            //        if (index == 1)
                            //            msg = "Please enter the long term colorant as PpK is mandatory";
                            //        else
                            //            msg = "Please enter the long term developer as PpK is mandatory";
                            //    }
                            //    if (Convert.ToDecimal(item.value) < Convert.ToDecimal(1.33))
                            //    {
                            //        MessageBox.Show(msg, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //        return;
                            //    }
                            //}
                        }
                        catch (Exception)
                        {
                            //MessageBox.Show("Please check value text,only decimal value is allowed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //return;
                        }
                        //if (string.IsNullOrEmpty(Convert.ToString(item.value)))
                        //{
                        //    MessageBox.Show("Please check value text,is mandatory", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //    return;
                        //}
                        //if (index == 1)
                        //{
                        //    if (dtpSTCDate.Value.Date < DateTime.Now.Date)
                        //    {
                        //        MessageBox.Show("Please check till date, is greater or equal to current date", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //        dtpSTCDate.Focus();
                        //        return;
                        //    }
                        //}
                        //else if (index == 2)
                        //{
                        //    if (dtpSTDDate.Value.Date < DateTime.Now.Date)
                        //    {
                        //        MessageBox.Show("Please check till date, is greater or equal to current date", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //        dtpSTDDate.Focus();
                        //        return;
                        //    }
                        //}
                        //else if (index == 3)
                        //{
                        //    if (dtpLTCDate.Value.Date < DateTime.Now.Date)
                        //    {
                        //        MessageBox.Show("Please check till date, is greater or equal to current date", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //        dtpLTCDate.Focus();
                        //        return;
                        //    }
                        //}
                        //else if (index == 4)
                        //{
                        //    if (dtpLTDDate.Value.Date < DateTime.Now.Date)
                        //    {
                        //        MessageBox.Show("Please check till date, is greater or equal to current date", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //        dtpLTDDate.Focus();
                        //        return;
                        //    }
                        //}
                        index++;
                    }

                    index = 1;
                    foreach (LayoutLineValidationTransaction_Class item in ListLayoutLineValidationTransaction_Class)
                    {
                        LayoutLineValidationTransaction_Class_Obj.id = item.id;
                        LayoutLineValidationTransaction_Class_Obj.lineDescription = item.lineDescription;
                        LayoutLineValidationTransaction_Class_Obj.name = item.name;
                        LayoutLineValidationTransaction_Class_Obj.parameter = item.parameter;
                        LayoutLineValidationTransaction_Class_Obj.minValue = item.minValue;
                        LayoutLineValidationTransaction_Class_Obj.maxValue = item.maxValue;
                        LayoutLineValidationTransaction_Class_Obj.value = item.value;
                        if (LayoutLineValidationTransaction_Class_Obj.id == 0)
                        {
                            //if (index == 1)
                            //{
                            //    LayoutLineValidationTransaction_Class_Obj.validFrom = dtpSTCDate.Value;
                            //}
                            //else if (index == 2)
                            //{
                            //    LayoutLineValidationTransaction_Class_Obj.validFrom = dtpSTDDate.Value;
                            //}
                            //else if (index == 3)
                            //{
                            //    LayoutLineValidationTransaction_Class_Obj.validFrom = dtpLTCDate.Value;
                            //}
                            //else if (index == 4)
                            //{
                            //    LayoutLineValidationTransaction_Class_Obj.validFrom = dtpLTDDate.Value;
                            //}

                            //LayoutLineValidationTransaction_Class_Obj.validTo = null;


                            LayoutLineValidationTransaction_Class_Obj.validFrom = dtpFromDate.Value;
                            LayoutLineValidationTransaction_Class_Obj.validTo = dtpToDate.Value;
                        }
                        else
                        {
                            //if (index == 1)
                            //{
                            //    LayoutLineValidationTransaction_Class_Obj.validFrom = Convert.ToDateTime(STCvaliddummydateforFrom.Text);
                            //    LayoutLineValidationTransaction_Class_Obj.validTo = dtpSTCDate.Value;
                            //}
                            //else if (index == 2)
                            //{
                            //    LayoutLineValidationTransaction_Class_Obj.validFrom = Convert.ToDateTime(STCvaliddummydateforFrom.Text);
                            //    LayoutLineValidationTransaction_Class_Obj.validTo = dtpSTDDate.Value;
                            //}
                            //else if (index == 3)
                            //{
                            //    LayoutLineValidationTransaction_Class_Obj.validFrom = Convert.ToDateTime(STCvaliddummydateforFrom.Text);
                            //    LayoutLineValidationTransaction_Class_Obj.validTo = dtpLTCDate.Value;
                            //}
                            //else if (index == 4)
                            //{
                            //    LayoutLineValidationTransaction_Class_Obj.validFrom = Convert.ToDateTime(STCvaliddummydateforFrom.Text);
                            //    LayoutLineValidationTransaction_Class_Obj.validTo = dtpLTDDate.Value;
                            //}
                            ////LayoutLineValidationTransaction_Class_Obj.validFrom = Convert.ToDateTime(item.Cells["validdummydateforFrom"].Value);
                            ////LayoutLineValidationTransaction_Class_Obj.validTo = Convert.ToDateTime(item.Cells["ValidTo"].Value);


                            LayoutLineValidationTransaction_Class_Obj.validFrom = dtpFromDate.Value;
                            LayoutLineValidationTransaction_Class_Obj.validTo = dtpToDate.Value;
                        }
                        if (LayoutLineValidationTransaction_Class_Obj.id == 0)
                            b = LayoutLineValidationTransaction_Class_Obj.Insert_LayoutLineValidationTransaction();
                        else
                        {
                            //b = LayoutLineValidationTransaction_Class_Obj.Update_LayoutLineValidationTransaction();
                            LayoutLineValidationTransaction_Class_Obj.id = 0;
                            //if (index == 1)
                            //{
                            //    LayoutLineValidationTransaction_Class_Obj.validFrom = dtpSTCDate.Value;
                            //}
                            //else if (index == 2)
                            //{
                            //    LayoutLineValidationTransaction_Class_Obj.validFrom = dtpSTDDate.Value;
                            //}
                            //else if (index == 3)
                            //{
                            //    LayoutLineValidationTransaction_Class_Obj.validFrom = dtpLTCDate.Value;
                            //}
                            //else if (index == 4)
                            //{
                            //    LayoutLineValidationTransaction_Class_Obj.validFrom = dtpLTDDate.Value;
                            //}
                            ////LayoutLineValidationTransaction_Class_Obj.validFrom = Convert.ToDateTime(item.Cells["ValidTo"].Value);

                            //LayoutLineValidationTransaction_Class_Obj.validTo = null;


                            LayoutLineValidationTransaction_Class_Obj.validFrom = dtpFromDate.Value;
                            LayoutLineValidationTransaction_Class_Obj.validTo = dtpToDate.Value;

                            b = LayoutLineValidationTransaction_Class_Obj.Insert_LayoutLineValidationTransaction();
                        }
                        index++;
                    }
                    if (b == true)
                    {
                        MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BindLineDescriptionTransactionDefault();
                        cbLineDescription.SelectedIndex = 0;
                        cbLineDescription.Focus();
                        dtpFromDate.Value = dtpToDate.Value = DateTime.Now;
                    }

                    #region By datagrid
                    //foreach (DataGridViewRow item in dgvLineDescriptionTransaction.Rows)
                    //{
                    //    try
                    //    {
                    //        string msg = "";
                    //        if (index == 1 || index == 2)
                    //        {
                    //            if (index == 1)
                    //                msg = "Please enter the limits of short term colorant as CpK ≥ 1.67";
                    //            else
                    //                msg = "Please enter the limits of short term developer as CpK ≥ 1.67";
                    //            if (Convert.ToDecimal(item.Cells["Value"].Value) == 0)
                    //            {
                    //                if (index == 1)
                    //                    msg = "Please enter the short term colorant as CpK is mandatory";
                    //                else
                    //                    msg = "Please enter the short term developer as CpK is mandatory";
                    //            }
                    //            if (Convert.ToDecimal(item.Cells["Value"].Value) < Convert.ToDecimal(1.67))
                    //            {
                    //                MessageBox.Show(msg, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //                return;
                    //            }
                    //        }
                    //        else if (index == 3 || index == 4)
                    //        {
                    //            if (index == 1)
                    //                msg = "Please enter the limits of long term colorant as PpK ≥ 1.33";
                    //            else
                    //                msg = "Please enter the limits of long term developer as PpK ≥ 1.33";
                    //            if (Convert.ToDecimal(item.Cells["Value"].Value) == 0)
                    //            {
                    //                if (index == 1)
                    //                    msg = "Please enter the long term colorant as PpK is mandatory";
                    //                else
                    //                    msg = "Please enter the long term developer as PpK is mandatory";
                    //            }
                    //            if (Convert.ToDecimal(item.Cells["Value"].Value) < Convert.ToDecimal(1.33))
                    //            {
                    //                MessageBox.Show(msg, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //                return;
                    //            }
                    //        }
                    //        Convert.ToDecimal(item.Cells["Value"].Value);
                    //    }
                    //    catch (Exception)
                    //    {
                    //        MessageBox.Show("Please check value text,only decimal value is allowed", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //        return;
                    //    }
                    //    if (string.IsNullOrEmpty(Convert.ToString(item.Cells["Value"].Value)))
                    //    {
                    //        MessageBox.Show("Please check value text,is mandatory", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //        return;
                    //    }
                    //    if (Convert.ToDateTime(item.Cells["ValidTo"].Value).Date < DateTime.Now.Date)
                    //    {
                    //        MessageBox.Show("Please check till date, is greater or equal to current date", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //        return;
                    //    }
                    //    index++;
                    //}
                    //foreach (DataGridViewRow item in dgvLineDescriptionTransaction.Rows)
                    //{
                    //    LayoutLineValidationTransaction_Class_Obj.id = Convert.ToInt64(item.Cells["Id"].Value);
                    //    LayoutLineValidationTransaction_Class_Obj.lineDescription = Convert.ToInt64(cbLineDescription.SelectedValue);
                    //    LayoutLineValidationTransaction_Class_Obj.name = Convert.ToString(item.Cells["NameColumn"].Value);
                    //    LayoutLineValidationTransaction_Class_Obj.parameter = Convert.ToString(item.Cells["Parameter"].Value);
                    //    LayoutLineValidationTransaction_Class_Obj.minValue = Convert.ToString(item.Cells["MinValue"].Value);
                    //    LayoutLineValidationTransaction_Class_Obj.maxValue = Convert.ToString(item.Cells["MaxValue"].Value);
                    //    LayoutLineValidationTransaction_Class_Obj.value = Convert.ToString(item.Cells["Value"].Value);
                    //    if (LayoutLineValidationTransaction_Class_Obj.id == 0)
                    //    {
                    //        LayoutLineValidationTransaction_Class_Obj.validFrom = Convert.ToDateTime(item.Cells["ValidTo"].Value);
                    //        LayoutLineValidationTransaction_Class_Obj.validTo = null;
                    //    }
                    //    else
                    //    {
                    //        LayoutLineValidationTransaction_Class_Obj.validFrom = Convert.ToDateTime(item.Cells["validdummydateforFrom"].Value);
                    //        LayoutLineValidationTransaction_Class_Obj.validTo = Convert.ToDateTime(item.Cells["ValidTo"].Value);
                    //    }
                    //    if (LayoutLineValidationTransaction_Class_Obj.id == 0)
                    //        b = LayoutLineValidationTransaction_Class_Obj.Insert_LayoutLineValidationTransaction();
                    //    else
                    //    {
                    //        b = LayoutLineValidationTransaction_Class_Obj.Update_LayoutLineValidationTransaction();
                    //        LayoutLineValidationTransaction_Class_Obj.id = 0;
                    //        LayoutLineValidationTransaction_Class_Obj.validFrom = Convert.ToDateTime(item.Cells["ValidTo"].Value);
                    //        LayoutLineValidationTransaction_Class_Obj.validTo = null;
                    //        b = LayoutLineValidationTransaction_Class_Obj.Insert_LayoutLineValidationTransaction();
                    //    }
                    //}
                    //if (b == true)
                    //{
                    //    MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //    BindLineDescriptionTransactionDefault();
                    //    cbLineDescription.SelectedIndex = 0;
                    //    cbLineDescription.Focus();
                    //}
                    #endregion
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

        private bool CheckMinMaxValue()
        {
            if (Convert.ToDecimal(txtSTCMin.Text.Trim()) > Convert.ToDecimal(txtSTCMax.Text.Trim()))
            {
                MessageBox.Show("Please enter valid min and max value of short term colorant", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSTCMax.Focus();
                return false;
            }
            if (Convert.ToDecimal(txtSTDMin.Text.Trim()) > Convert.ToDecimal(txtSTDMax.Text.Trim()))
            {
                MessageBox.Show("Please enter valid min and max value of short term developer", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSTDMax.Focus();
                return false;
            }
            if (Convert.ToDecimal(txtLTCMin.Text.Trim()) > Convert.ToDecimal(txtLTCMax.Text.Trim()))
            {
                MessageBox.Show("Please enter valid min and max value of long term colorant", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLTCMax.Focus();
                return false;
            }
            if (Convert.ToDecimal(txtLTDMin.Text.Trim()) > Convert.ToDecimal(txtLTDMax.Text.Trim()))
            {
                MessageBox.Show("Please enter valid min and max value of long term developer", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLTDMax.Focus();
                return false;
            }
            return true;
        }

        private bool IsValid()
        {
            if (string.IsNullOrEmpty(txtSTCMin.Text.Trim()))
            {
                MessageBox.Show("Please enter min value of short term colorant", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSTCMin.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtSTCMax.Text.Trim()))
            {
                MessageBox.Show("Please enter max value of short term colorant", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSTCMax.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtSTDMin.Text.Trim()))
            {
                MessageBox.Show("Please enter min value of short term developer", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSTDMin.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtSTDMax.Text.Trim()))
            {
                MessageBox.Show("Please enter max value of short term developer", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtSTDMax.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtLTCMin.Text.Trim()))
            {
                MessageBox.Show("Please enter min value of long term colorant", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLTCMin.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtLTCMax.Text.Trim()))
            {
                MessageBox.Show("Please enter max value of long term colorant", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLTCMax.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtLTDMin.Text.Trim()))
            {
                MessageBox.Show("Please enter min value of long term developer", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLTDMin.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(txtLTDMax.Text.Trim()))
            {
                MessageBox.Show("Please enter max value of long term developer", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtLTDMax.Focus();
                return false;
            }
            return true;
        }

        private void dgvLineDescriptionTransaction_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // If any cell is clicked on the Second column which is our date Column  
            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            {
                //Initialized a new DateTimePicker Control  
                cellDateTimePicker = new DateTimePicker();

                //Adding DateTimePicker control into DataGridView   
                dgvLineDescriptionTransaction.Controls.Add(cellDateTimePicker);
                cellDateTimePicker.MinDate = DateTime.Now;
                cellDateTimePicker.CustomFormat = "dd-MMM-yyyy";
                cellDateTimePicker.Format = DateTimePickerFormat.Custom;

                // It returns the retangular area that represents the Display area for a cell  
                Rectangle oRectangle = dgvLineDescriptionTransaction.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                //Setting area for DateTimePicker Control  
                cellDateTimePicker.Size = new Size(oRectangle.Width, oRectangle.Height);

                // Setting Location  
                cellDateTimePicker.Location = new Point(oRectangle.X, oRectangle.Y);

                // An event attached to dateTimePicker Control which is fired when DateTimeControl is closed  
                cellDateTimePicker.CloseUp += new EventHandler(oDateTimePicker_CloseUp);

                try
                {
                    //cellDateTimePicker.MinDate = Convert.ToDateTime(dgvLineDescriptionTransaction.Rows[e.RowIndex].Cells[4].Value);
                    cellDateTimePicker.Text = dgvLineDescriptionTransaction.SelectedCells[0].Value.ToString();
                }
                catch (Exception ex)
                {
                }

                // An event attached to dateTimePicker Control which is fired when any date is selected  
                cellDateTimePicker.TextChanged += new EventHandler(dateTimePicker_OnTextChange);

                // Now make it visible  
                cellDateTimePicker.Visible = true;
            }
            if (e.ColumnIndex == 4 && e.RowIndex >= 0)
            {

            }
        }

        private void oDateTimePicker_CloseUp(object sender, EventArgs e)
        {
            // Hiding the control after use   
            cellDateTimePicker.Visible = false;
        }

        private void dateTimePicker_OnTextChange(object sender, EventArgs e)
        {

            // Saving the 'Selected Date on Calendar' into DataGridView current cell  
            dgvLineDescriptionTransaction.CurrentCell.Value = (cellDateTimePicker.Text);
        }

        private static FrmLineValidationMaster frm = null;
        public static FrmLineValidationMaster GetInstance()
        {
            if (frm == null)
            {
                frm = new FrmLineValidationMaster();
            }
            return frm;
        }

        private void txtSTCMin_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtSTCMin.Text.Trim()))
                    Convert.ToDecimal(txtSTCMin.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter decimal value", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSTCMin.Text = string.Empty;
                txtSTCMin.Focus();
                return;
            }
        }

        private void txtSTCMax_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtSTCMax.Text.Trim()))
                    Convert.ToDecimal(txtSTCMax.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter decimal value", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSTCMax.Text = string.Empty;
                txtSTCMax.Focus();
                return;
            }
        }

        private void txtSTDMin_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtSTDMin.Text.Trim()))
                    Convert.ToDecimal(txtSTDMin.Text);
            }
            catch (Exception ex)
            {
                if (!string.IsNullOrEmpty(txtSTCMin.Text.Trim()))
                    MessageBox.Show("Please enter decimal value", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSTDMin.Text = string.Empty;
                txtSTDMin.Focus();
                return;
            }
        }

        private void txtSTDMax_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtSTDMax.Text.Trim()))
                    Convert.ToDecimal(txtSTDMax.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter decimal value", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtSTDMax.Text = string.Empty;
                txtSTDMax.Focus();
                return;
            }
        }

        private void txtLTCMin_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtLTCMin.Text.Trim()))
                    Convert.ToDecimal(txtLTCMin.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter decimal value", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLTCMin.Text = string.Empty;
                txtLTCMin.Focus();
                return;
            }
        }

        private void txtLTCMax_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtLTCMax.Text.Trim()))
                    Convert.ToDecimal(txtLTCMax.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter decimal value", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLTCMax.Text = string.Empty;
                txtLTCMax.Focus();
                return;
            }
        }

        private void txtLTDMin_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtLTDMin.Text.Trim()))
                    Convert.ToDecimal(txtLTDMin.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter decimal value", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLTDMin.Text = string.Empty;
                txtLTDMin.Focus();
                return;
            }
        }

        private void txtLTDMax_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtLTDMax.Text.Trim()))
                    Convert.ToDecimal(txtLTDMax.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please enter decimal value", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtLTDMax.Text = string.Empty;
                txtLTDMax.Focus();
                return;
            }
        }
    }
}
