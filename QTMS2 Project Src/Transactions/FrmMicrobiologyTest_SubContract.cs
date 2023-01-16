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
    public partial class FrmMicrobiologyTest_SubContract : Form
    {
        public FrmMicrobiologyTest_SubContract(long TLFID,Boolean micro)
        {
            InitializeComponent();
            FinishedGoodTest_SubContract_Class_Obj.TLFID = TLFID;
            FinishedGoodTest_SubContract_Class_Obj.micro = micro;
        }
        # region Varibles
        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        BusinessFacade.Transactions.Microbiologytest_Class Microbiologytest_Class_Obj = new BusinessFacade.Transactions.Microbiologytest_Class();
        BusinessFacade.UserManagement_Class UserManagement_Class_Obj = new BusinessFacade.UserManagement_Class();

        BusinessFacade.SubContractor_Class.FinishedGoodTest_SubContract_Class FinishedGoodTest_SubContract_Class_Obj =
            new BusinessFacade.SubContractor_Class.FinishedGoodTest_SubContract_Class();

        // this flag is used to determine whether fuction is called at Load or Value change 

        private DataSet dsTLFIDs;
        DataSet ds;
        private DataSet ds1;
        # endregion
        private void FrmMicrobiologyTest_SubContract_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            Painter.Paint(this);

            Bind_InspectedBy();
            BtnReset_Click(sender, e);

            //------------Displays all dates and time From database

            DataSet ds2 = new DataSet();
            //Microbiologytest_Class_Obj.tlfid = Convert.ToInt64(dsTLFIDs.Tables[0].Rows[0]["TLFID"].ToString());
            ds2 = FinishedGoodTest_SubContract_Class_Obj.Select_tblMicrobiologytest_SubContract_Status();
            if (ds2.Tables[0].Rows.Count > 0)
            {

                if (ds2.Tables[0].Rows[0]["ClearDate"].ToString() != "")
                {
                    DtpClearDate.Value = Convert.ToDateTime(ds2.Tables[0].Rows[0]["ClearDate"].ToString());
                }
                if (ds2.Tables[0].Rows[0]["MediaLotNo"].ToString() != "")
                {
                    txtMediaLotNo.Text = ds2.Tables[0].Rows[0]["MediaLotNo"].ToString();
                }
                if (ds2.Tables[0].Rows[0]["Innoc_Broth_Date"].ToString() != "")
                {
                    DtpBroth_Innoc_Date.Value = Convert.ToDateTime(ds2.Tables[0].Rows[0]["Innoc_Broth_Date"].ToString());
                }
                if (ds2.Tables[0].Rows[0]["Innoc_Broth_Time"].ToString() != "")
                {
                    DtpBroth_Innoc_Time.Value = Convert.ToDateTime(ds2.Tables[0].Rows[0]["Innoc_Broth_Time"].ToString());
                }
                if (ds2.Tables[0].Rows[0]["Innoc_Agar_Date"].ToString() != "")
                {
                    DtpAgar_Innoc_Date.Value = Convert.ToDateTime(ds2.Tables[0].Rows[0]["Innoc_Agar_Date"].ToString());
                }
                if (ds2.Tables[0].Rows[0]["Innoc_Agar_Time"].ToString() != "")
                {
                    DtpAgar_Innoc_Time.Value = Convert.ToDateTime(ds2.Tables[0].Rows[0]["Innoc_Agar_Time"].ToString());
                }
                if (ds2.Tables[0].Rows[0]["Inccubation_Broth_Date"].ToString() != "")
                {
                    DtpBroth_Inncubation_Date.Value = Convert.ToDateTime(ds2.Tables[0].Rows[0]["Inccubation_Broth_Date"].ToString());
                }
                if (ds2.Tables[0].Rows[0]["Inccubation_Broth_Time"].ToString() != "")
                {
                    DtpBroth_Inncubation_Time.Value = Convert.ToDateTime(ds2.Tables[0].Rows[0]["Inccubation_Broth_Time"].ToString());
                }
                if (ds2.Tables[0].Rows[0]["Inccubation_Agar_Date"].ToString() != "")
                {
                    DtpAgar_Inncubation_Date.Value = Convert.ToDateTime(ds2.Tables[0].Rows[0]["Inccubation_Agar_Date"].ToString());
                }
                if (ds2.Tables[0].Rows[0]["Inccubation_Agar_Time"].ToString() != "")
                {
                    DtpAgar_Inncubation_Time.Value = Convert.ToDateTime(ds2.Tables[0].Rows[0]["Inccubation_Agar_Time"].ToString());
                }
                if (ds2.Tables[0].Rows[0]["Inccubation_Other_Date"].ToString() != "")
                {
                    DtpOther_Inncubation_Date.Value = Convert.ToDateTime(ds2.Tables[0].Rows[0]["Inccubation_Other_Date"].ToString());
                }
                if (ds2.Tables[0].Rows[0]["Inccubation_Other_time"].ToString() != "")
                {
                    DtpOther_Inncubation_Time.Value = Convert.ToDateTime(ds2.Tables[0].Rows[0]["Inccubation_Other_time"].ToString());
                }
                if (ds2.Tables[0].Rows[0]["Result_Broth_Date"].ToString() != "")
                {
                    DtpBroth_Result_Date.Value = Convert.ToDateTime(ds2.Tables[0].Rows[0]["Result_Broth_Date"].ToString());
                }
                if (ds2.Tables[0].Rows[0]["Result_Broth_Time"].ToString() != "")
                {
                    DtpBroth_Result_Time.Value = Convert.ToDateTime(ds2.Tables[0].Rows[0]["Result_Broth_Time"].ToString());
                }
                if (ds2.Tables[0].Rows[0]["Result_Agar_Date"].ToString() != "")
                {
                    DtpAgar_Result_Date.Value = Convert.ToDateTime(ds2.Tables[0].Rows[0]["Result_Agar_Date"].ToString());
                }
                if (ds2.Tables[0].Rows[0]["Result_Agar_Time"].ToString() != "")
                {
                    DtpAgar_Result_Time.Value = Convert.ToDateTime(ds2.Tables[0].Rows[0]["Result_Agar_Time"].ToString());
                }
                if (ds2.Tables[0].Rows[0]["Result_Other_Date"].ToString() != "")
                {
                    DtpOther_Result_Date.Value = Convert.ToDateTime(ds2.Tables[0].Rows[0]["Result_Other_Date"].ToString());
                }
                if (ds2.Tables[0].Rows[0]["Result_Other_Time"].ToString() != "")
                {
                    DtpOther_Result_Time.Value = Convert.ToDateTime(ds2.Tables[0].Rows[0]["Result_Other_Time"].ToString());
                }
                if (ds2.Tables[0].Rows[0]["Remarks_Broth"].ToString() == "Presence Of Bactorial Growth")
                {
                    cmbRemarks_Broth.SelectedIndex = 1;
                }
                else if (ds2.Tables[0].Rows[0]["Remarks_Broth"].ToString() == "Absence Of Bactorial Growth")
                {
                    cmbRemarks_Broth.SelectedIndex = 2;
                }
                else
                {
                    cmbRemarks_Broth.SelectedIndex = 0;
                }


                if (ds2.Tables[0].Rows[0]["Remarks_Agar"].ToString() == "Presence Of Bactorial Growth")
                {
                    cmbRemarks_Agar.SelectedIndex = 1;
                }
                else if (ds2.Tables[0].Rows[0]["Remarks_Agar"].ToString() == "Absence Of Bactorial Growth")
                {
                    cmbRemarks_Agar.SelectedIndex = 2;
                }
                else
                {
                    cmbRemarks_Agar.SelectedIndex = 0;
                }


                if (ds2.Tables[0].Rows[0]["Remarks_Other"].ToString() == "Presence Of Fungal Growth")
                {
                    cmbRemarks_Other.SelectedIndex = 1;
                }
                else if (ds2.Tables[0].Rows[0]["Remarks_Other"].ToString() == "<100 MOULDS & YEAST IN Gm TESTED")
                {
                    cmbRemarks_Other.SelectedIndex = 2;
                }
                else
                {
                    cmbRemarks_Other.SelectedIndex = 0;
                }


                txtBroth_Inncub_Temp.Text = ds2.Tables[0].Rows[0]["Inccub_Broth_Temp"].ToString();
                txtAgar_Inncub_Temp.Text = ds2.Tables[0].Rows[0]["Inccub_Agar_Temp"].ToString();
                txtOther_Inncub_Temp.Text = ds2.Tables[0].Rows[0]["Inccub_Other_Temp"].ToString();

                txtTotalTime_Broth.Text = ds2.Tables[0].Rows[0]["TotalTime_Broth"].ToString();
                txtTotalTime_Agar.Text = ds2.Tables[0].Rows[0]["TotalTime_Agar"].ToString();
                txtTotalTime_Other.Text = ds2.Tables[0].Rows[0]["TotalTime_Other"].ToString();

                if (ds2.Tables[0].Rows[0]["Status"].ToString() == "A")
                {
                    RdoAccepted.Checked = true;
                }
                else if (ds2.Tables[0].Rows[0]["Status"].ToString() == "R")
                {
                    RdoRejected.Checked = true;
                }
                else if (ds2.Tables[0].Rows[0]["Status"].ToString() == "H")
                {
                    RdoHold.Checked = true;
                }
                else if (ds2.Tables[0].Rows[0]["Status"].ToString() == "D")
                {
                    RdoAcceptedwithDerrogation.Checked = true;
                }

                if (ds2.Tables[0].Rows[0]["SampleToRetainer"].ToString() == "Y")
                {
                    chkSampleToRetainer.Checked = true;
                }
                else if (ds2.Tables[0].Rows[0]["SampleToRetainer"].ToString() == "N")
                {
                    chkSampleToRetainer.Checked = false;
                }

                //if (ds2.Tables[0].Rows[0]["BpcNonBpc"].ToString() == "B")
                //{
                //    RdoBpc.Checked = true;
                //}
                //if (ds2.Tables[0].Rows[0]["BpcNonBpc"].ToString() == "N")
                //{
                //    RdoNonBpc.Checked = true;
                //}

                //txtCommentNonBpc.Text = ds2.Tables[0].Rows[0]["NonBpcComments"].ToString();
                //txtcomments.Text = ds2.Tables[0].Rows[0]["Comment"].ToString();
                txtComment.Text = ds2.Tables[0].Rows[0]["Comment"].ToString();
                cmbInspectedBy.SelectedValue = ds2.Tables[0].Rows[0]["InspectedBy"].ToString();
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
        public void set_Todays_date_Time()
        {
            DtpClearDate.Value = Comman_Class_Obj.Select_ServerDate();

            DtpBroth_Innoc_Time.Value = DtpClearDate.Value;
            DtpAgar_Innoc_Time.Value = DtpClearDate.Value;

            DtpBroth_Inncubation_Time.Value = DtpClearDate.Value;
            DtpAgar_Inncubation_Time.Value = DtpClearDate.Value;
            DtpOther_Inncubation_Time.Value = DtpClearDate.Value;

            DtpBroth_Result_Time.Value = DtpClearDate.Value;
            DtpAgar_Result_Time.Value = DtpClearDate.Value;
            DtpOther_Result_Time.Value = DtpClearDate.Value;
        }
        public string Calculate_total_time(DateTime StartDate, DateTime StartTime, DateTime EndDate, DateTime EndTime)
        {
            DateTime Start = new DateTime(StartDate.Year, StartDate.Month, StartDate.Day, StartTime.Hour, StartTime.Minute, StartTime.Second);
            DateTime End = new DateTime(EndDate.Year, EndDate.Month, EndDate.Day, EndTime.Hour, EndTime.Minute, EndTime.Second);
            TimeSpan dateDiff = End - Start;
            return (Convert.ToString((dateDiff.Days * 24) + dateDiff.Hours));
        }
        private void BtnReset_Click(object sender, EventArgs e)
        {
            txtMediaLotNo.Text = "";
            dgDetails.Rows.Clear();
            set_Todays_date_Time();
            txtComment.Text = "";
            // dataGridView.Rows.Clear();

            txtBroth_Inncub_Temp.Text = "32.5 ± 2.5";
            txtAgar_Inncub_Temp.Text = "32.5 ± 2.5";
            txtOther_Inncub_Temp.Text = "22.5 ± 2.5";
            txtTotalTime_Broth.Text = "";
            txtTotalTime_Agar.Text = "";
            txtTotalTime_Other.Text = "";
            cmbRemarks_Broth.Text = "--Select--";
            cmbRemarks_Agar.Text = "--Select--";
            cmbRemarks_Other.Text = "--Select--";

            RdoAccepted.Checked = true;
            chkSampleToRetainer.Checked = false;
            //RdoBpc.Checked = true;
            //txtcomments.Text = "";
            //txtCommentNonBpc.Text = "";
            cmbInspectedBy.Text = "--Select--";

            cmbDetails.Focus();
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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbDetails.Text == "--Select--")
                {
                    MessageBox.Show("Select Formula No", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    cmbDetails.Focus();
                    return;
                }

                //if (RdoNonBpc.Checked == true)
                //{
                //    if (txtCommentNonBpc.Text == "")
                //    {
                //        MessageBox.Show("Enter Non BPC Comment", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //        txtCommentNonBpc.Focus();
                //        return;
                //    }
                //}
                if (cmbInspectedBy.SelectedValue == null || cmbInspectedBy.Text == "--Select--")
                {
                    MessageBox.Show("Please Select Inspected By", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cmbInspectedBy.Focus();
                    return;
                }
                //if record on hold then dates are not compulsory
                if (RdoHold.Checked != true)
                {
                    if (DtpBroth_Innoc_Date.Checked != true ||
                       DtpAgar_Innoc_Date.Checked != true ||
                       DtpBroth_Inncubation_Date.Checked != true ||
                       DtpAgar_Inncubation_Date.Checked != true ||
                       DtpOther_Inncubation_Date.Checked != true ||
                       DtpBroth_Result_Date.Checked != true ||
                       DtpAgar_Result_Date.Checked != true ||
                       DtpOther_Result_Date.Checked != true
                        )
                    {
                        MessageBox.Show("Select the dates", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (DtpBroth_Result_Date.Value.Date < DtpBroth_Inncubation_Date.Value.Date)
                    {
                        MessageBox.Show("result date prior to start date");
                        txtTotalTime_Broth.Text = "";
                        return;
                    }

                    if (DtpAgar_Result_Date.Value.Date < DtpAgar_Inncubation_Date.Value.Date)
                    {
                        MessageBox.Show("result date prior to start date");
                        txtTotalTime_Agar.Text = "";
                        return;
                    }

                    if (DtpOther_Result_Date.Value.Date < DtpOther_Inncubation_Date.Value.Date)
                    {
                        MessageBox.Show("result date prior to start date");
                        txtTotalTime_Other.Text = "";
                        return;
                    }


                    if (txtTotalTime_Agar.Text == "")
                    {
                        MessageBox.Show("Enter Agar Total Time", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtTotalTime_Agar.Focus();
                        return;
                    }
                    if (txtTotalTime_Broth.Text == "")
                    {
                        MessageBox.Show("Enter Broth Total Time", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtTotalTime_Broth.Focus();
                        return;
                    }
                    if (txtTotalTime_Other.Text == "")
                    {
                        MessageBox.Show("Enter Other Total Time", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtTotalTime_Other.Focus();
                        return;
                    }
                }

                if (RdoAccepted.Checked == true)
                {
                    if (MessageBox.Show("ACCEPT ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                    {
                        return;
                    }
                }
                if (RdoRejected.Checked == true)
                {
                    if (MessageBox.Show("REJECT ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                    {
                        return;
                    }
                }
                if (RdoHold.Checked == true)
                {
                    if (MessageBox.Show("HOLD ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                    {
                        return;
                    }
                }
                if (RdoAcceptedwithDerrogation.Checked == true)
                {
                    if (MessageBox.Show("ACCEPT WITH DERROGATION ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                    {
                        return;
                    }
                }

                //for (int t = 0; t < dsTLFIDs.Tables[0].Rows.Count; t++)
                {
                    // Microbiologytest_Class_Obj.tlfid = Convert.ToInt64(dsTLFIDs.Tables[0].Rows[t]["TLFID"]);

                    // Innoc Date & Time
                    if (DtpBroth_Innoc_Date.Checked == true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.innoc_broth_date = DtpBroth_Innoc_Date.Value.ToShortDateString();
                        FinishedGoodTest_SubContract_Class_Obj.innoc_broth_time = DtpBroth_Innoc_Time.Value.ToLongTimeString();
                    }
                    else
                    {
                        FinishedGoodTest_SubContract_Class_Obj.innoc_broth_date = "";
                        FinishedGoodTest_SubContract_Class_Obj.innoc_broth_time = "";
                    }


                    if (DtpAgar_Innoc_Date.Checked == true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.innoc_agar_date = DtpAgar_Innoc_Date.Value.ToShortDateString();
                        FinishedGoodTest_SubContract_Class_Obj.innoc_agar_time = DtpAgar_Innoc_Time.Value.ToLongTimeString();
                    }
                    else
                    {
                        FinishedGoodTest_SubContract_Class_Obj.innoc_agar_date = "";
                        FinishedGoodTest_SubContract_Class_Obj.innoc_agar_time = "";
                    }

                    //===========================================
                    //Inncubation Date & Time
                    // Broth
                    if (DtpBroth_Inncubation_Date.Checked == true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.inccubation_broth_date = DtpBroth_Inncubation_Date.Value.ToShortDateString();
                        FinishedGoodTest_SubContract_Class_Obj.inccubation_broth_time = DtpBroth_Inncubation_Time.Value.ToLongTimeString();
                    }
                    else
                    {
                        FinishedGoodTest_SubContract_Class_Obj.inccubation_broth_date = "";
                        FinishedGoodTest_SubContract_Class_Obj.inccubation_broth_time = "";
                    }

                    // Agar
                    if (DtpAgar_Inncubation_Date.Checked == true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.Inccubation_Agar_Date = DtpAgar_Inncubation_Date.Value.ToShortDateString();
                        FinishedGoodTest_SubContract_Class_Obj.Inccubation_Agar_Time = DtpAgar_Inncubation_Time.Value.ToLongTimeString();
                    }
                    else
                    {
                        FinishedGoodTest_SubContract_Class_Obj.Inccubation_Agar_Date = "";
                        FinishedGoodTest_SubContract_Class_Obj.Inccubation_Agar_Time = "";
                    }

                    // Other
                    if (DtpOther_Inncubation_Date.Checked == true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.Inccubation_Other_Date = DtpOther_Inncubation_Date.Value.ToShortDateString();
                        FinishedGoodTest_SubContract_Class_Obj.inccubation_other_time = DtpOther_Inncubation_Time.Value.ToLongTimeString();
                    }
                    else
                    {
                        FinishedGoodTest_SubContract_Class_Obj.Inccubation_Other_Date = "";
                        FinishedGoodTest_SubContract_Class_Obj.inccubation_other_time = "";
                    }

                    // Inncub Temp
                    if (txtBroth_Inncub_Temp.Text == "32.5 ± 2.5")
                    {
                        FinishedGoodTest_SubContract_Class_Obj.Inccub_Broth_Temp = Convert.ToString(32.5);
                    }
                    else
                    {
                        FinishedGoodTest_SubContract_Class_Obj.Inccub_Broth_Temp = txtBroth_Inncub_Temp.Text;
                    }
                    if (txtAgar_Inncub_Temp.Text == "32.5 ± 2.5")
                    {
                        //FinishedGoodTest_SubContract_Class_Obj.inccub_agar_temp = Convert.ToString(22.5);
                        FinishedGoodTest_SubContract_Class_Obj.Inccub_Agar_Temp = Convert.ToString(32.5);
                    }
                    else
                    {
                        FinishedGoodTest_SubContract_Class_Obj.Inccub_Agar_Temp = txtAgar_Inncub_Temp.Text;
                    }
                    if (txtOther_Inncub_Temp.Text == "22.5 ± 2.5")
                    {
                        FinishedGoodTest_SubContract_Class_Obj.Inccub_Other_Temp = Convert.ToString(22.5);
                    }
                    else
                    {
                        FinishedGoodTest_SubContract_Class_Obj.Inccub_Other_Temp = txtOther_Inncub_Temp.Text;
                    }

                    // Result Date & Time
                    // Broth
                    if (DtpBroth_Result_Date.Checked == true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.Result_Broth_Date = DtpBroth_Result_Date.Value.ToShortDateString();
                        FinishedGoodTest_SubContract_Class_Obj.Result_Broth_Time = DtpBroth_Result_Time.Value.ToLongTimeString();
                    }
                    else
                    {
                        FinishedGoodTest_SubContract_Class_Obj.Result_Broth_Date = "";
                        FinishedGoodTest_SubContract_Class_Obj.Result_Broth_Time = "";
                    }

                    // Agar
                    if (DtpAgar_Result_Date.Checked == true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.Result_Agar_Date = DtpAgar_Result_Date.Value.ToShortDateString();
                        FinishedGoodTest_SubContract_Class_Obj.Result_Agar_Time = DtpAgar_Result_Time.Value.ToLongTimeString();
                    }
                    else
                    {
                        FinishedGoodTest_SubContract_Class_Obj.Result_Agar_Date = "";
                        FinishedGoodTest_SubContract_Class_Obj.Result_Agar_Time = "";
                    }

                    // Other
                    if (DtpOther_Result_Date.Checked == true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.Result_Other_Date = DtpOther_Result_Date.Value.ToShortDateString();
                        FinishedGoodTest_SubContract_Class_Obj.Result_Other_Time = DtpOther_Result_Time.Value.ToLongTimeString();
                    }
                    else
                    {
                        FinishedGoodTest_SubContract_Class_Obj.Result_Other_Date = "";
                        FinishedGoodTest_SubContract_Class_Obj.Result_Other_Time = "";
                    }

                    // Total Time

                    FinishedGoodTest_SubContract_Class_Obj.TotalTime_Broth = txtTotalTime_Broth.Text;
                    FinishedGoodTest_SubContract_Class_Obj.TotalTime_Agar = txtTotalTime_Agar.Text;
                    FinishedGoodTest_SubContract_Class_Obj.TotalTime_Other = txtTotalTime_Other.Text;

                    // Remarks
                    if (cmbRemarks_Broth.Text != "--Select--")
                    {
                        FinishedGoodTest_SubContract_Class_Obj.Remarks_Broth = cmbRemarks_Broth.Text;
                    }
                    else
                    {
                        FinishedGoodTest_SubContract_Class_Obj.Remarks_Broth = "";
                    }
                    if (cmbRemarks_Agar.Text != "--Select--")
                    {
                        FinishedGoodTest_SubContract_Class_Obj.Remarks_Agar = cmbRemarks_Agar.Text;
                    }
                    else
                    {
                        FinishedGoodTest_SubContract_Class_Obj.Remarks_Agar = "";
                    }
                    if (cmbRemarks_Other.Text != "--Select--")
                    {
                        FinishedGoodTest_SubContract_Class_Obj.Remarks_Other = cmbRemarks_Other.Text;
                    }
                    else
                    {
                        FinishedGoodTest_SubContract_Class_Obj.Remarks_Other = "";
                    }

                    if (RdoAccepted.Checked == true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.microstatus = Convert.ToChar("A");
                    }
                    else if (RdoRejected.Checked == true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.microstatus = Convert.ToChar("R");
                    }
                    else if (RdoHold.Checked == true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.microstatus = Convert.ToChar("H");
                    }
                    else if (RdoAcceptedwithDerrogation.Checked == true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.microstatus = Convert.ToChar("D");
                    }

                    if (chkSampleToRetainer.Checked == true)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.sampletoretainer = Convert.ToChar("Y");
                    }
                    else if (chkSampleToRetainer.Checked == false)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.sampletoretainer = Convert.ToChar("N");
                    }
                    //if (RdoBpc.Checked == true)
                    //{
                    //    FinishedGoodTest_SubContract_Class_Obj.bpcnonbpc = Convert.ToChar("B");
                    //    FinishedGoodTest_SubContract_Class_Obj.nonbpccomments = "";
                    //}
                    //else if (RdoNonBpc.Checked == true)
                    //{
                    //    FinishedGoodTest_SubContract_Class_Obj.bpcnonbpc = Convert.ToChar("N");
                    //    FinishedGoodTest_SubContract_Class_Obj.nonbpccomments = txtCommentNonBpc.Text;
                    //}
                    FinishedGoodTest_SubContract_Class_Obj.comments = txtComment.Text; //txtcomments.Text;
                    FinishedGoodTest_SubContract_Class_Obj.cleardate = DtpClearDate.Value.ToShortDateString();

                    FinishedGoodTest_SubContract_Class_Obj.medialotno = txtMediaLotNo.Text;

                    FinishedGoodTest_SubContract_Class_Obj.inspectedby = Convert.ToInt32(cmbInspectedBy.SelectedValue);

                    FinishedGoodTest_SubContract_Class_Obj.loginid = FrmMain.LoginID;

                    // Insert in tblMicrobiologytest OR update if already Exists for TLFID
                    bool b = false;
                    b = FinishedGoodTest_SubContract_Class_Obj.Insert_tblMicrobiologytest_SubContract();
                }


                //--------- Set MicroDone = 1 if not hold 
                //--------- By keeping hold user can again open record to enter details 
                //if (RdoHold.Checked != true)
                //{
                //    for (int t = 0; t < dsTLFIDs.Tables[0].Rows.Count; t++)
                //    {
                //        Microbiologytest_Class_Obj.tlfid = Convert.ToInt64(dsTLFIDs.Tables[0].Rows[t]["TLFID"]);

                //        Microbiologytest_Class_Obj.microdone = true;
                //        bool a = Microbiologytest_Class_Obj.Update_tblTransTLF_MicroDone();
                //    }
                MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                //else if (RdoHold.Checked == true)
                //{
                //    MessageBox.Show("Record On Hold", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                // BtnReset_Click(sender, e);
                //Bind_Details();
                //cmbDetails.Focus();
                // return;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtBroth_Inncub_Temp_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtAgar_Inncub_Temp_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtOther_Inncub_Temp_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTotalTime_Broth_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTotalTime_Agar_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtTotalTime_Other_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cmbRemarks_Broth_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            cmbRemarks_Broth.Text = textInfo.ToTitleCase(cmbRemarks_Broth.Text);

        }

        private void cmbRemarks_Agar_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            cmbRemarks_Agar.Text = textInfo.ToTitleCase(cmbRemarks_Agar.Text);
        }

        private void cmbRemarks_Other_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            cmbRemarks_Other.Text = textInfo.ToTitleCase(cmbRemarks_Other.Text);
        }

        private void txtcomments_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            //txtcomments.Text = textInfo.ToTitleCase(txtcomments.Text);
        }

        private void txtBroth_Inncub_Temp_Enter(object sender, EventArgs e)
        {
            txtBroth_Inncub_Temp.Text = Convert.ToString(32.5);
        }

        private void txtAgar_Inncub_Temp_Enter(object sender, EventArgs e)
        {
            //txtAgar_Inncub_Temp.Text = Convert.ToString(22.5);
            txtAgar_Inncub_Temp.Text = Convert.ToString(32.5);
        }

        private void txtOther_Inncub_Temp_Enter(object sender, EventArgs e)
        {
            txtOther_Inncub_Temp.Text = Convert.ToString(22.5);
        }

        private void DtpBroth_Inncubation_Date_ValueChanged(object sender, EventArgs e)
        {
            if (DtpBroth_Innoc_Date.Checked == false)
            {
                MessageBox.Show("Select Broth Inncubation Date and Time", "Error");
                DtpBroth_Inncubation_Date.Checked = false;
                DtpBroth_Innoc_Date.Focus();
            }
        }

        private void DtpAgar_Inncubation_Date_ValueChanged(object sender, EventArgs e)
        {
            if (DtpAgar_Innoc_Date.Checked == false)
            {
                MessageBox.Show("Select Agar Inncubation Date and Time", "Error");
                DtpAgar_Inncubation_Date.Checked = false;
                DtpAgar_Innoc_Date.Focus();
            }
        }

        private void DtpBroth_Result_Date_ValueChanged(object sender, EventArgs e)
        {
            if (DtpBroth_Inncubation_Date.Checked == false)
            {
                MessageBox.Show("Select Broth start Inncubation Date and Time", "Error");
                DtpBroth_Result_Date.Checked = false;
                DtpBroth_Inncubation_Date.Focus();
                return;
            }
            txtTotalTime_Broth.Text = Calculate_total_time(DtpBroth_Inncubation_Date.Value, DtpBroth_Inncubation_Time.Value, DtpBroth_Result_Date.Value, DtpBroth_Result_Time.Value);
        }

        private void DtpAgar_Result_Date_ValueChanged(object sender, EventArgs e)
        {
            if (DtpAgar_Inncubation_Date.Checked == false)
            {
                MessageBox.Show("Select Agar start Inncubation Date and Time", "Error");
                DtpAgar_Result_Date.Checked = false;
                DtpAgar_Inncubation_Date.Focus();
                return;
            }
            txtTotalTime_Agar.Text = Calculate_total_time(DtpAgar_Inncubation_Date.Value, DtpAgar_Inncubation_Time.Value, DtpAgar_Result_Date.Value, DtpAgar_Result_Time.Value);
        }

        private void DtpOther_Result_Date_ValueChanged(object sender, EventArgs e)
        {
            if (DtpOther_Inncubation_Date.Checked == false)
            {
                MessageBox.Show("Select Other start Inncubation Date and Time", "Error");
                DtpOther_Result_Date.Checked = false;
                DtpOther_Inncubation_Date.Focus();
                return;
            }
            txtTotalTime_Other.Text = Calculate_total_time(DtpOther_Inncubation_Date.Value, DtpOther_Inncubation_Time.Value, DtpOther_Result_Date.Value, DtpOther_Result_Time.Value);
        }

        private void DtpBroth_Result_Time_ValueChanged(object sender, EventArgs e)
        {
            txtTotalTime_Broth.Text = Calculate_total_time(DtpBroth_Inncubation_Date.Value, DtpBroth_Inncubation_Time.Value, DtpBroth_Result_Date.Value, DtpBroth_Result_Time.Value);
        }

        private void DtpAgar_Result_Time_ValueChanged(object sender, EventArgs e)
        {
            txtTotalTime_Agar.Text = Calculate_total_time(DtpAgar_Inncubation_Date.Value, DtpAgar_Inncubation_Time.Value, DtpAgar_Result_Date.Value, DtpAgar_Result_Time.Value);
        }

        private void DtpOther_Result_Time_ValueChanged(object sender, EventArgs e)
        {
            txtTotalTime_Other.Text = Calculate_total_time(DtpOther_Inncubation_Date.Value, DtpOther_Inncubation_Time.Value, DtpOther_Result_Date.Value, DtpOther_Result_Time.Value);
        }

        private void DtpBroth_Innoc_Date_ValueChanged(object sender, EventArgs e)
        {
            //DtpBroth_Innoc_Date.Value = DtpClearDate.Value.AddDays(0);
            DtpBroth_Inncubation_Date.Value = DtpBroth_Innoc_Date.Value.AddDays(0);
            DtpBroth_Result_Date.Value = DtpBroth_Innoc_Date.Value.AddDays(1);

            DtpAgar_Innoc_Date.Value = DtpBroth_Innoc_Date.Value.AddDays(1);
            DtpAgar_Inncubation_Date.Value = DtpBroth_Innoc_Date.Value.AddDays(1);
            DtpAgar_Result_Date.Value = DtpBroth_Innoc_Date.Value.AddDays(3);

            DtpOther_Inncubation_Date.Value = DtpBroth_Innoc_Date.Value.AddDays(3);
            DtpOther_Result_Date.Value = DtpBroth_Innoc_Date.Value.AddDays(8);
        }
    }
}