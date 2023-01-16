using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QTMS.Tools;
using BusinessFacade;
using BusinessFacade.Transactions;

namespace QTMS.Forms
{
    public partial class FrmTankSelection : Form
    {
        /// <summary>
        /// Created By - Avinash S
        /// Created On - 19-Nov-2018
        /// </summary>
        public FrmTankSelection()
        {
            InitializeComponent();
        }
        # region Varibles
        LineMaster_Class LineMaster_Class_Obj = new LineMaster_Class();
        FinishedGoodMaster_Class FinishedGoodMaster_Class_Obj = new FinishedGoodMaster_Class();
        TankMaster_Class TankMaster_Class_Obj = new TankMaster_Class();
        Comman_Class Comman_Class_Obj = new Comman_Class();
        #endregion
        private void FrmTankSelection_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            //this.WindowState = FormWindowState.Normal;
            Painter.Paint(this);

            Bind_LineNo();
            Bind_FGCode();
            DtpTrackCode.Value = DtpLotDate.Value= Comman_Class_Obj.Select_ServerDate();
            txtSamplingTime.Text = new Comman_Class().Select_ServerDate().ToString("HH:mm tt");

            dgTest.AutoGenerateColumns = false;
            DgvTankInformation.AutoGenerateColumns = false;
            dgTest.DataSource = TankMaster_Class_Obj.Select_tblTankSelection();

            // EnableDisableControls(false);
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
            FGds.Tables[0].Rows.InsertAt(dr, 0);

            if (FGds.Tables[0].Rows.Count > 0)
            {

                CmbFgCode.DataSource = FGds.Tables[0];
                CmbFgCode.DisplayMember = "FGCode";
                CmbFgCode.ValueMember = "FGNo";
            }
        }
        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            CmbFgCode.Text = "--Select--";
            CmbLineNo.Text = "--Select--";
            DtpTrackCode.Value = DtpLotDate.Value = Comman_Class_Obj.Select_ServerDate();
            txtBatchCode.Text = txtFormulaNo.Text = txtMfgWo.Text = txtPkgWoNo.Text = txtTankNo.Text = txtSamplingTime.Text = txtMRP.Text = lbltanlDescription.Text = lbltype.Text = string.Empty;
            //dgv.Rows.Clear();
            txtSamplingTime.Text = new Comman_Class().Select_ServerDate().ToString("HH:mm tt");
            rdbSTS.Checked = rdbRetainer.Checked = rdbPhysico.Checked = rdbMicro.Checked = rdbLSD.Checked = rdbFSD.Checked = rdbFIS.Checked = rdbCM.Checked = rdb30Min.Checked = rdbtankconnection.Checked = false;
            TankMaster_Class_Obj.tankno = TankMaster_Class_Obj.fno = TankMaster_Class_Obj.id = 0;
            DgvTankInformation.DataSource = null;
        }

        private void txtFormulaNo_Leave(object sender, EventArgs e)
        {
            //if (CmbFgCode.SelectedValue == null || CmbFgCode.Text == "--Select--")
            //{
            //    MessageBox.Show("Select FG Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    txtFormulaNo.Text = string.Empty;
            //    CmbFgCode.Focus();
            //    return;
            //}

            //TankMaster_Class_Obj.fgno = Convert.ToInt64(CmbFgCode.SelectedValue);
            //TankMaster_Class_Obj.formulano = txtFormulaNo.Text.Trim();
            //DataSet Ds = TankMaster_Class_Obj.FG_Formula_Exist();
            //if (Ds.Tables[0].Rows.Count > 0)
            //{
            //    TankMaster_Class_Obj.fno = Convert.ToInt64(Ds.Tables[0].Rows[0]["FNo"]);
            //    lbltype.Text = Convert.ToString(Ds.Tables[0].Rows[0]["Type"]);
            //    lbltype.ForeColor = Color.Red;
            //    lbltype.Visible = true;
            //    txtTankNo.Focus();
            //}
            //else
            //{
            //    MessageBox.Show("FG Code :- " +CmbFgCode.Text+" Formula No. :- "+txtFormulaNo.Text+" Record not present.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    txtFormulaNo.Text = lbltype.Text = string.Empty;
            //}
        }

        private void txtTankNo_Leave(object sender, EventArgs e)
        {

            //dgv.Rows.Add();
            //dgv["FormulaNo", dgv.Rows.Count - 1].Value = txtFormulaNo.Text.Trim();
            //dgv["TankNo", dgv.Rows.Count - 1].Value = txtTankNo.Text.Trim();

            if (txtTankNo.Text.Trim() != string.Empty && txtFormulaNo.Text.Trim() != string.Empty)
            {
                DataSet Ds = new DataSet();
                TankMaster_Class_Obj.barcodevalue = txtTankNo.Text.Trim();
                Ds = TankMaster_Class_Obj.Select_Tank_By_BarcodeValue();
                if (Ds.Tables[0].Rows.Count > 0)
                {

                    TankMaster_Class_Obj.tankno = Convert.ToInt64(Ds.Tables[0].Rows[0]["TankNo"]);
                    lbltanlDescription.Text = Ds.Tables[0].Rows[0]["TkDesc"].ToString();

                    TankMaster_Class_Obj.mfgwo = txtMfgWo.Text.Trim();
                    DataTable Dt = TankMaster_Class_Obj.GetTank_ByTransaction();
                    if (Dt.Rows.Count == 0)
                    {
                        MessageBox.Show("Tank not present in bulk transaction.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTankNo.Text = lbltanlDescription.Text = string.Empty;
                        TankMaster_Class_Obj.tankno = 0;
                        txtTankNo.Focus();
                    }

                    //dgv.Rows.Add();
                    //dgv["FNo", dgv.Rows.Count - 1].Value = TankMaster_Class_Obj.fno.ToString();
                    //dgv["TankNo", dgv.Rows.Count - 1].Value = Ds.Tables[0].Rows[0]["TankNo"].ToString();
                    //dgv["FormulaNo", dgv.Rows.Count - 1].Value = txtFormulaNo.Text.Trim();
                    //dgv["TkDesc", dgv.Rows.Count - 1].Value = Ds.Tables[0].Rows[0]["TkDesc"].ToString();
                    txtMRP.Focus();
                }
                else
                {
                    MessageBox.Show("Barcode value :- " + txtTankNo.Text + "  tank not present.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTankNo.Text = lbltanlDescription.Text = string.Empty;
                    TankMaster_Class_Obj.tankno = 0;
                    txtTankNo.Focus();
                }

            }

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            tmrformula.Stop();
            //txtFormulaNo_Leave(sender, e);

            if (CmbFgCode.SelectedValue == null || CmbFgCode.Text == "--Select--")
            {
                MessageBox.Show("Select FG Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFormulaNo.Text = string.Empty;
                CmbFgCode.Focus();
                return;
            }
            if (txtFormulaNo.Text.Trim() != string.Empty)
            {
                TankMaster_Class_Obj.fgno = Convert.ToInt64(CmbFgCode.SelectedValue);
                string Str = txtFormulaNo.Text.Trim();
                Str = Str.Replace('b', ' ');
                Str = Str.Replace('B', ' ');
                TankMaster_Class_Obj.formulano = Str.Trim();
                DataSet Ds = TankMaster_Class_Obj.FG_Formula_Exist();
                if (Ds.Tables[0].Rows.Count > 0)
                {
                    TankMaster_Class_Obj.fno = Convert.ToInt64(Ds.Tables[0].Rows[0]["FNo"]);
                    lbltype.Text = Convert.ToString(Ds.Tables[0].Rows[0]["Type"]);
                    lbltype.ForeColor = Color.Red;
                    lbltype.Visible = true;
                    txtTankNo.Focus();
                }
                else
                {
                    MessageBox.Show("FG Code :- " + CmbFgCode.Text + " Formula No. :- " + txtFormulaNo.Text + " Record not present.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtFormulaNo.Text = lbltype.Text = string.Empty;
                    TankMaster_Class_Obj.fno = 0;
                }
            }
        }

        //private void txtFormulaNo_TextChanged(object sender, EventArgs e)
        //{
        //    tmrformula.Stop();
        //    tmrformula.Start();
        //}

        private void tmrtank_Tick(object sender, EventArgs e)
        {
            tmrtank.Stop();
            //txtTankNo_Leave(sender, e);
            if (txtTankNo.Text.Trim() != string.Empty && txtFormulaNo.Text.Trim() != string.Empty)
            {
                DataSet Ds = new DataSet();
                TankMaster_Class_Obj.barcodevalue = txtTankNo.Text.Trim();
                Ds = TankMaster_Class_Obj.Select_Tank_By_BarcodeValue();
                if (Ds.Tables[0].Rows.Count > 0)
                {
                    //dgv.Rows.Add();
                    //dgv["FNo", dgv.Rows.Count - 1].Value = TankMaster_Class_Obj.fno.ToString();
                    //dgv["TankNo", dgv.Rows.Count - 1].Value = Ds.Tables[0].Rows[0]["TankNo"].ToString();
                    //dgv["FormulaNo", dgv.Rows.Count - 1].Value = txtFormulaNo.Text.Trim();
                    //dgv["TkDesc", dgv.Rows.Count - 1].Value = Ds.Tables[0].Rows[0]["TkDesc"].ToString();
                }
                else
                {
                    MessageBox.Show("Barcode value :- " + txtTankNo.Text + "  tank not present.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }


            }
            txtTankNo.Text = string.Empty;
            txtTankNo.Focus();
        }

        //private void txtTankNo_TextChanged(object sender, EventArgs e)
        //{
        //    tmrtank.Stop();
        //    tmrtank.Start();
        //}

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0 && e.ColumnIndex == 4)
                {
                    //dgv.Rows.RemoveAt(e.RowIndex);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (CmbLineNo.SelectedValue == null || CmbLineNo.Text == "--Select--")
            {
                MessageBox.Show("Select Line No.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CmbLineNo.Focus();
                return;
            }
            if (CmbFgCode.SelectedValue == null || CmbFgCode.Text == "--Select--")
            {
                MessageBox.Show("Select FG Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CmbFgCode.Focus();
                return;
            }
            if (txtMfgWo.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Enter Mfg Wo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMfgWo.Focus();
                return;
            }

            //if (dgv.Rows.Count > 0)
            if (TankMaster_Class_Obj.tankno != 0 && TankMaster_Class_Obj.fno != 0)
            {
                TankMaster_Class_Obj.lno = Convert.ToInt32(CmbLineNo.SelectedValue);
                TankMaster_Class_Obj.fgno = Convert.ToInt64(CmbFgCode.SelectedValue);
                TankMaster_Class_Obj.trackcode = DtpTrackCode.Value.ToShortDateString();
                TankMaster_Class_Obj.pkgwo = txtPkgWoNo.Text.Trim();
                //TankMaster_Class_Obj.lotno = txtLotNo.Text.Trim();
                TankMaster_Class_Obj.lotno = DtpLotDate.Value.ToString("dd-MMM-yyyy");
                TankMaster_Class_Obj.batchcode = txtBatchCode.Text.Trim();
                TankMaster_Class_Obj.mfgwo = txtMfgWo.Text.Trim();
                TankMaster_Class_Obj.createdby = GlobalVariables.uid;

                #region Sampling
                if (rdbPhysico.Checked)
                    TankMaster_Class_Obj.sampling = "Physico";
                else if (rdbRetainer.Checked)
                    TankMaster_Class_Obj.sampling = "Retainer";
                else if (rdbMicro.Checked)
                    TankMaster_Class_Obj.sampling = "Micro";
                else if (rdbtankconnection.Checked)
                    TankMaster_Class_Obj.sampling = "Tank connection";
                #endregion
                #region Sampling Details
                if (rdb30Min.Checked)
                    TankMaster_Class_Obj.samplingdetails = "30Min";
                else if (rdbCM.Checked)
                    TankMaster_Class_Obj.samplingdetails = "CM";
                else if (rdbFIS.Checked)
                    TankMaster_Class_Obj.samplingdetails = "FIS";
                else if (rdbFSD.Checked)
                    TankMaster_Class_Obj.samplingdetails = "FSD";
                else if (rdbLSD.Checked)
                    TankMaster_Class_Obj.samplingdetails = "LSD";
                else if (rdbSTS.Checked)
                    TankMaster_Class_Obj.samplingdetails = "STS";
                #endregion

                TankMaster_Class_Obj.samplingtime = new Comman_Class().Select_ServerDate().ToString("HH:mm tt");
                TankMaster_Class_Obj.mrp = txtMRP.Text.Trim();

                //for (int i = 0; i < dgv.Rows.Count; i++)
                //{
                //    TankMaster_Class_Obj.tankno = Convert.ToInt64(dgv.Rows[i].Cells[0].Value);
                //    TankMaster_Class_Obj.fno = Convert.ToInt64(dgv.Rows[i].Cells[1].Value);
                //    TankMaster_Class_Obj.id = TankMaster_Class_Obj.Insert_TankSelection();
                //}

                TankMaster_Class_Obj.id = TankMaster_Class_Obj.Insert_TankSelection();
                MessageBox.Show("Record Saved Successfully !!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                QTMS.Reports_Forms.FrmTankLabelPrint pro = new QTMS.Reports_Forms.FrmTankLabelPrint(TankMaster_Class_Obj.id);
                pro.ShowDialog();

                BtnReset_Click(sender, e);

                dgTest.DataSource = TankMaster_Class_Obj.Select_tblTankSelection();
            }
            else
            {
                MessageBox.Show("Please scan formula & tank no.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPkgWoNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                DtpLotDate.Focus();
            }
        }

        private void txtLotNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                txtBatchCode.Focus();
            }
        }

        private void txtBatchCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                txtMfgWo.Focus();
            }
        }

        private void txtMfgWo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                txtFormulaNo.Focus();
            }
        }

        private void txtFormulaNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                if (CmbFgCode.SelectedValue == null || CmbFgCode.Text == "--Select--")
                {
                    MessageBox.Show("Select FG Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtFormulaNo.Text = string.Empty;
                    CmbFgCode.Focus();
                    return;
                }
                if (txtFormulaNo.Text.Trim() != string.Empty)
                {
                    TankMaster_Class_Obj.fgno = Convert.ToInt64(CmbFgCode.SelectedValue);
                    string Str = txtFormulaNo.Text.Trim();
                    Str = Str.Replace('b', ' ');
                    Str = Str.Replace('B', ' ');
                    TankMaster_Class_Obj.formulano = Str.Trim();
                    DataSet Ds = TankMaster_Class_Obj.FG_Formula_Exist();
                    if (Ds.Tables[0].Rows.Count > 0)
                    {
                        TankMaster_Class_Obj.fno = Convert.ToInt64(Ds.Tables[0].Rows[0]["FNo"]);
                        lbltype.Text = Convert.ToString(Ds.Tables[0].Rows[0]["Type"]);
                        lbltype.ForeColor = Color.Red;
                        lbltype.Visible = true;
                        txtTankNo.Focus();

                        TankMaster_Class_Obj.mfgwo = txtMfgWo.Text.Trim();
                        DataSet DsTankDetails = TankMaster_Class_Obj.GetTankDetails_ByTankSelection();
                        DgvTankInformation.AutoGenerateColumns = false;
                        DgvTankInformation.DataSource = DsTankDetails.Tables[0];
                    }
                    else
                    {
                        MessageBox.Show("FG Code :- " + CmbFgCode.Text + " Formula No. :- " + txtFormulaNo.Text + " Record not present.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtFormulaNo.Text = lbltype.Text = string.Empty;
                        txtFormulaNo.Focus();
                        DgvTankInformation.DataSource = null;
                    }
                }
            }

        }

        private void txtTankNo_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == (char)Keys.Enter)
            {
                if (txtTankNo.Text.Trim() != string.Empty && txtFormulaNo.Text.Trim() != string.Empty)
                {
                    DataSet Ds = new DataSet();
                    TankMaster_Class_Obj.barcodevalue = txtTankNo.Text.Trim();
                    Ds = TankMaster_Class_Obj.Select_Tank_By_BarcodeValue();
                    if (Ds.Tables[0].Rows.Count > 0)
                    {
                        TankMaster_Class_Obj.tankno = Convert.ToInt64(Ds.Tables[0].Rows[0]["TankNo"]);
                        lbltanlDescription.Text = Ds.Tables[0].Rows[0]["TkDesc"].ToString();

                        TankMaster_Class_Obj.mfgwo = txtMfgWo.Text.Trim();
                        DataTable Dt = TankMaster_Class_Obj.GetTank_ByTransaction();
                        if (Dt.Rows.Count == 0)
                        {
                            MessageBox.Show("Tank not present in bulk transaction.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtTankNo.Text = lbltanlDescription.Text = string.Empty;
                            TankMaster_Class_Obj.tankno = 0;
                            txtTankNo.Focus();
                        }

                        //dgv.Rows.Add();
                        //dgv["FNo", dgv.Rows.Count - 1].Value = TankMaster_Class_Obj.fno.ToString();
                        //dgv["TankNo", dgv.Rows.Count - 1].Value = Ds.Tables[0].Rows[0]["TankNo"].ToString();
                        //dgv["FormulaNo", dgv.Rows.Count - 1].Value = txtFormulaNo.Text.Trim();
                        //dgv["TkDesc", dgv.Rows.Count - 1].Value = Ds.Tables[0].Rows[0]["TkDesc"].ToString();
                        txtMRP.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Barcode value :- " + txtTankNo.Text + "  tank not present.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtTankNo.Text = lbltanlDescription.Text = string.Empty;
                        TankMaster_Class_Obj.tankno = 0;
                        txtTankNo.Focus();
                    }

                }
            }

        }

        private void txtFormulaNo_Leave_1(object sender, EventArgs e)
        {
            if (CmbFgCode.SelectedValue == null || CmbFgCode.Text == "--Select--")
            {
                MessageBox.Show("Select FG Code", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFormulaNo.Text = string.Empty;
                CmbFgCode.Focus();
                return;
            }
            if (txtFormulaNo.Text.Trim() != string.Empty)
            {
                TankMaster_Class_Obj.fgno = Convert.ToInt64(CmbFgCode.SelectedValue);
                string Str = txtFormulaNo.Text.Trim();
                Str = Str.Replace('b', ' ');
                Str = Str.Replace('B', ' ');
                TankMaster_Class_Obj.formulano = Str.Trim();
                DataSet Ds = TankMaster_Class_Obj.FG_Formula_Exist();
                if (Ds.Tables[0].Rows.Count > 0)
                {
                    TankMaster_Class_Obj.fno = Convert.ToInt64(Ds.Tables[0].Rows[0]["FNo"]);
                    lbltype.Text = Convert.ToString(Ds.Tables[0].Rows[0]["Type"]);
                    lbltype.ForeColor = Color.Red;
                    lbltype.Visible = true;
                    txtTankNo.Focus();

                    TankMaster_Class_Obj.mfgwo = txtMfgWo.Text.Trim();
                    DataSet DsTankDetails = TankMaster_Class_Obj.GetTankDetails_ByTankSelection();
                    DgvTankInformation.AutoGenerateColumns = false;
                    DgvTankInformation.DataSource = DsTankDetails.Tables[0];

                }
                else
                {
                    MessageBox.Show("FG Code :- " + CmbFgCode.Text + " Formula No. :- " + txtFormulaNo.Text + " Record not present.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtFormulaNo.Text = lbltype.Text = string.Empty;
                    txtFormulaNo.Focus();
                    DgvTankInformation.DataSource = null;
                    //DgvTankInformation.Rows.Clear();
                }
            }
        }

        public void EnableDisableControls(bool flag)
        {
            txtPkgWoNo.Enabled = flag;
            DtpLotDate.Enabled = flag;
            txtBatchCode.Enabled = flag;
            txtMfgWo.Enabled = flag;
            txtFormulaNo.Enabled = flag;
            txtTankNo.Enabled = flag;
            txtSamplingTime.Enabled = flag;
            txtMRP.Enabled = flag;
        }
        /*
        private void dgTest_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            TankMaster_Class_Obj.id = Convert.ToInt64(dgTest.Rows[e.RowIndex].Cells[0].Value);

            DataTable dt = TankMaster_Class_Obj.Select_tblTankSelection_ByID();
            if (dt.Rows.Count > 0)
            {
                CmbLineNo.SelectedValue = Convert.ToInt64(dt.Rows[0]["LNo"].ToString());
                CmbFgCode.SelectedValue = Convert.ToInt64(dt.Rows[0]["FgNo"].ToString());
                DtpTrackCode.Text = dt.Rows[0]["TrackCode"].ToString();
                txtPkgWoNo.Text = dt.Rows[0]["PkgWo"].ToString();
                txtLotNo.Text = dt.Rows[0]["LotNo"].ToString();
                txtBatchCode.Text = dt.Rows[0]["BatchCode"].ToString();
                txtMfgWo.Text = dt.Rows[0]["MfgWo"].ToString();
                txtFormulaNo.Text = dt.Rows[0]["FormulaNo"].ToString();
                txtTankNo.Text = dt.Rows[0]["BarcodeValue"].ToString();
                txtSamplingTime.Text = dt.Rows[0]["SamplingTime"].ToString();
                txtMRP.Text = dt.Rows[0]["MRP"].ToString();

                TankMaster_Class_Obj.fno = Convert.ToInt64(dt.Rows[0]["Fno"].ToString());
                TankMaster_Class_Obj.tankno = Convert.ToInt64(dt.Rows[0]["TankNo"].ToString());

                if (dt.Rows[0]["Sampling"].ToString() == "Retainer")
                    rdbRetainer.Checked = true;
                else if (dt.Rows[0]["Sampling"].ToString() == "Micro")
                    rdbMicro.Checked = true;
                else if (dt.Rows[0]["Sampling"].ToString() == "Physico")
                    rdbPhysico.Checked = true;


                if (dt.Rows[0]["SamplingDetails"].ToString() == "30Min")
                    rdb30Min.Checked = true;
                else if (dt.Rows[0]["SamplingDetails"].ToString() == "CM")
                    rdbCM.Checked = true;
                else if (dt.Rows[0]["SamplingDetails"].ToString() == "FIS")
                    rdbFIS.Checked = true;
                else if (dt.Rows[0]["SamplingDetails"].ToString() == "FSD")
                    rdbFSD.Checked = true;
                else if (dt.Rows[0]["SamplingDetails"].ToString() == "LSD")
                    rdbLSD.Checked = true;
                else if (dt.Rows[0]["SamplingDetails"].ToString() == "STS")
                    rdbSTS.Checked = true;

            }

        }
        */
        private void dgTest_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            TankMaster_Class_Obj.id = Convert.ToInt64(dgTest.Rows[e.RowIndex].Cells[0].Value);

            DataTable dt = TankMaster_Class_Obj.Select_tblTankSelection_ByID();
            if (dt.Rows.Count > 0)
            {
                CmbLineNo.SelectedValue = Convert.ToInt64(dt.Rows[0]["LNo"].ToString());
                CmbFgCode.SelectedValue = Convert.ToInt64(dt.Rows[0]["FgNo"].ToString());
                DtpTrackCode.Text = dt.Rows[0]["TrackCode"].ToString();
                txtPkgWoNo.Text = dt.Rows[0]["PkgWo"].ToString();
                try
                {
                    //txtLotNo.Text = dt.Rows[0]["LotNo"].ToString();
                    DtpLotDate.Text = dt.Rows[0]["LotNo"].ToString();
                }
                catch (Exception ex)
                {  }
               

                txtBatchCode.Text = dt.Rows[0]["BatchCode"].ToString();
                txtMfgWo.Text = dt.Rows[0]["MfgWo"].ToString();
                txtFormulaNo.Text = dt.Rows[0]["FormulaNo"].ToString();
                txtTankNo.Text = dt.Rows[0]["BarcodeValue"].ToString();
                txtSamplingTime.Text = dt.Rows[0]["SamplingTime"].ToString();
                txtMRP.Text = dt.Rows[0]["MRP"].ToString();

                TankMaster_Class_Obj.fno = Convert.ToInt64(dt.Rows[0]["Fno"].ToString());
                TankMaster_Class_Obj.tankno = Convert.ToInt64(dt.Rows[0]["TankNo"].ToString());

                if (dt.Rows[0]["Sampling"].ToString() == "Retainer")
                    rdbRetainer.Checked = true;
                else if (dt.Rows[0]["Sampling"].ToString() == "Micro")
                    rdbMicro.Checked = true;
                else if (dt.Rows[0]["Sampling"].ToString() == "Physico")
                    rdbPhysico.Checked = true;
                else if (dt.Rows[0]["Sampling"].ToString() == "Tank connection")
                    rdbtankconnection.Checked = true;


                if (dt.Rows[0]["SamplingDetails"].ToString() == "30Min")
                    rdb30Min.Checked = true;
                else if (dt.Rows[0]["SamplingDetails"].ToString() == "CM")
                    rdbCM.Checked = true;
                else if (dt.Rows[0]["SamplingDetails"].ToString() == "FIS")
                    rdbFIS.Checked = true;
                else if (dt.Rows[0]["SamplingDetails"].ToString() == "FSD")
                    rdbFSD.Checked = true;
                else if (dt.Rows[0]["SamplingDetails"].ToString() == "LSD")
                    rdbLSD.Checked = true;
                else if (dt.Rows[0]["SamplingDetails"].ToString() == "STS")
                    rdbSTS.Checked = true;

            }
        }



    }
}