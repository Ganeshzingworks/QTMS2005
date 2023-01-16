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
    public partial class FrmMicrobiologyTestSubContract : Form
    {
        public FrmMicrobiologyTestSubContract()
        {            
            InitializeComponent();
        }

        # region Varibles        
        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();       
        BusinessFacade.Transactions.Microbiologytest_Class Microbiologytest_Class_Obj = new BusinessFacade.Transactions.Microbiologytest_Class();
        BusinessFacade.UserManagement_Class UserManagement_Class_Obj = new BusinessFacade.UserManagement_Class();

        // this flag is used to determine whether fuction is called at Load or Value change 
        
        private DataSet dsTLFIDs;
        DataSet ds;
        private DataSet ds1;
        # endregion

        private static FrmMicrobiologyTestSubContract frmMicrobiologyTest_Obj = null;

        public static FrmMicrobiologyTestSubContract GetInstance()
        {
            if (frmMicrobiologyTest_Obj == null)
            {
                frmMicrobiologyTest_Obj = new FrmMicrobiologyTestSubContract();
            }
            return frmMicrobiologyTest_Obj;
        }

        private void FrmMicrobiologyTest_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);


            Bind_Details();
            Bind_InspectedBy();
            BtnReset_Click(sender, e);
        }

        public void set_Todays_date_Time()
        {
            DtpClearDate.Value = Comman_Class_Obj.Select_ServerDate();

            //DtpBroth_Innoc_Date.Value = DtpClearDate.Value;
            //DtpBroth_Innoc_Date.Checked = false;
            //DtpAgar_Innoc_Date.Value = DtpClearDate.Value;
            //DtpAgar_Innoc_Date.Checked = false;

            //DtpBroth_Inncubation_Date.Value = DtpClearDate.Value;
            //DtpBroth_Inncubation_Date.Checked = false;
            //DtpAgar_Inncubation_Date.Value = DtpClearDate.Value;
            //DtpAgar_Inncubation_Date.Checked = false;
            //DtpOther_Inncubation_Date.Value = DtpClearDate.Value;
            //DtpOther_Inncubation_Date.Checked = false;


            //DtpBroth_Result_Date.Value = DtpClearDate.Value;
            //DtpBroth_Result_Date.Checked = false;
            //DtpAgar_Result_Date.Value = DtpClearDate.Value;
            //DtpAgar_Result_Date.Checked = false;
            //DtpOther_Result_Date.Value = DtpClearDate.Value;
            //DtpOther_Result_Date.Checked = false;

            DtpBroth_Innoc_Time.Value = DtpClearDate.Value;
            DtpAgar_Innoc_Time.Value = DtpClearDate.Value;

            DtpBroth_Inncubation_Time.Value = DtpClearDate.Value;
            DtpAgar_Inncubation_Time.Value = DtpClearDate.Value;
            DtpOther_Inncubation_Time.Value = DtpClearDate.Value;

            DtpBroth_Result_Time.Value = DtpClearDate.Value;
            DtpAgar_Result_Time.Value = DtpClearDate.Value;
            DtpOther_Result_Time.Value = DtpClearDate.Value;
        }

        public string Calculate_total_time(DateTime StartDate,DateTime StartTime,DateTime EndDate,DateTime EndTime)
        {
            DateTime Start = new DateTime(StartDate.Year, StartDate.Month, StartDate.Day, StartTime.Hour, StartTime.Minute, StartTime.Second);
            DateTime End = new DateTime(EndDate.Year, EndDate.Month, EndDate.Day, EndTime.Hour, EndTime.Minute, EndTime.Second);
            TimeSpan dateDiff = End - Start;
            return (Convert.ToString((dateDiff.Days * 24) +  dateDiff.Hours)); 
        }       

        public void Bind_Details()
        {
            try
            {
                DataSet ds = new DataSet();
                DataRow dr;                
                ds = Microbiologytest_Class_Obj.Select_PendingMicrobiologyDetails();
                dr = ds.Tables[0].NewRow();
                dr["Details"] = "--Select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    cmbDetails.DataSource = ds.Tables[0];
                    cmbDetails.ValueMember = "DetailsNo";
                    cmbDetails.DisplayMember = "Details";
                }              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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
            RdoBpc.Checked = true;
            txtcomments.Text = "";
            txtCommentNonBpc.Text = "";
            cmbInspectedBy.Text = "--Select--";
            
            cmbDetails.Focus(); 
        }

        private void cmbDetails_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {

                BtnReset_Click(sender,e);

                if (cmbDetails.SelectedValue != null && cmbDetails.SelectedValue.ToString() != "")
                {
                    
                    //splits FGNo,TrackCode,LNo  from DetailsNo("203-07/29/2008-78")
                    string[] DNo = cmbDetails.SelectedValue.ToString().Split('-');
                    Microbiologytest_Class_Obj.fgno = Convert.ToInt64(DNo[0]);
                    Microbiologytest_Class_Obj.trackcode = DNo[1];
                    Microbiologytest_Class_Obj.lno = Convert.ToInt32(DNo[2]);

                    dsTLFIDs = new DataSet();
                    dsTLFIDs = Microbiologytest_Class_Obj.Select_MicrobiologyDetails_DetailsNo();

                    dgDetails.Rows.Clear();
                    for (int t = 0; t < dsTLFIDs.Tables[0].Rows.Count; t++)
                    {
                        Microbiologytest_Class_Obj.tlfid = Convert.ToInt64(dsTLFIDs.Tables[0].Rows[t]["TLFID"]);

                        ds = new DataSet();                        
                        ds = Microbiologytest_Class_Obj.Select_MicrobiologyDetails_TLFID();
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            dgDetails.Rows.Add();

                            dgDetails["Details_FormulaNo",dgDetails.Rows.Count - 1].Value = Convert.ToString(dsTLFIDs.Tables[0].Rows[t]["FormulaNo"]);
                            dgDetails["Details_MfgWo", dgDetails.Rows.Count - 1].Value = Convert.ToString(dsTLFIDs.Tables[0].Rows[t]["MfgWo"]);

                            dgDetails["Details_Description", dgDetails.Rows.Count - 1].Value = Convert.ToString(ds.Tables[0].Rows[0]["bulkdesc"]);
                            dgDetails["Details_TechnicalFamily", dgDetails.Rows.Count - 1].Value = Convert.ToString(ds.Tables[0].Rows[0]["familydesc"]);
                            dgDetails["Details_Norms", dgDetails.Rows.Count - 1].Value = Convert.ToString(ds.Tables[0].Rows[0]["MicroNorms"]);// Show transaction level saved micro norms
                        }
                    }

                    // ---------------Now Show Tanks in Grid from tblBulkTankDetail
                    // ---------------Also show details from tblMicrobiologytest_SampleDetails in same query

                    //dataGridView.Rows.Clear();
                    for (int t = 0; t < dsTLFIDs.Tables[0].Rows.Count; t++)
                    {
                        Microbiologytest_Class_Obj.tlfid = Convert.ToInt64(dsTLFIDs.Tables[0].Rows[t]["TLFID"]);

                        ds1 = new DataSet();
                        ds1 = Microbiologytest_Class_Obj.Select_Microbiology_Tank();                        
                        //for (int i = 0; i < ds1.Tables[0].Rows.Count; i++)
                        //{
                        //    dataGridView.Rows.Add();

                        //    dataGridView["TLFID", dataGridView.Rows.Count - 1].Value = Convert.ToString(dsTLFIDs.Tables[0].Rows[t]["TLFID"]);
                        //    dataGridView["FormulaNo", dataGridView.Rows.Count - 1].Value = Convert.ToString(dsTLFIDs.Tables[0].Rows[t]["FormulaNo"]);
                        //    dataGridView["MfgWo", dataGridView.Rows.Count - 1].Value = Convert.ToString(dsTLFIDs.Tables[0].Rows[t]["MfgWo"]);

                        //    dataGridView["BulkTankDetailNo", dataGridView.Rows.Count-1].Value = Convert.ToString(ds1.Tables[0].Rows[i]["BulkTankDetailNo"]);
                        //    dataGridView["TankNo", dataGridView.Rows.Count - 1].Value = Convert.ToString(ds1.Tables[0].Rows[i]["TankNo"]);
                        //    dataGridView["TkDesc", dataGridView.Rows.Count - 1].Value = Convert.ToString(ds1.Tables[0].Rows[i]["TkDesc"]);
                        //    dataGridView["FSD", dataGridView.Rows.Count - 1].Value = Convert.ToString(ds1.Tables[0].Rows[i]["FSD"]);
                        //    dataGridView["STS", dataGridView.Rows.Count - 1].Value = Convert.ToString(ds1.Tables[0].Rows[i]["STS"]);
                        //    dataGridView["LBK", dataGridView.Rows.Count - 1].Value = Convert.ToString(ds1.Tables[0].Rows[i]["LBK"]);
                        //    dataGridView["EST", dataGridView.Rows.Count - 1].Value = Convert.ToString(ds1.Tables[0].Rows[i]["EST"]);
                        //    dataGridView["LSD", dataGridView.Rows.Count - 1].Value = Convert.ToString(ds1.Tables[0].Rows[i]["LSD"]);
                        //    dataGridView["CM1", dataGridView.Rows.Count - 1].Value = Convert.ToString(ds1.Tables[0].Rows[i]["CM1"]);
                        //    dataGridView["CM2", dataGridView.Rows.Count - 1].Value = Convert.ToString(ds1.Tables[0].Rows[i]["CM2"]);
                        //    dataGridView["CM3", dataGridView.Rows.Count - 1].Value = Convert.ToString(ds1.Tables[0].Rows[i]["CM3"]);
                        //    dataGridView["CM4", dataGridView.Rows.Count - 1].Value = Convert.ToString(ds1.Tables[0].Rows[i]["CM4"]);
                        //    dataGridView["CM5", dataGridView.Rows.Count - 1].Value = Convert.ToString(ds1.Tables[0].Rows[i]["CM5"]);
                        //}
                    }

                    //------------Displays all dates and time From database

                    DataSet ds2 = new DataSet();
                    Microbiologytest_Class_Obj.tlfid = Convert.ToInt64(dsTLFIDs.Tables[0].Rows[0]["TLFID"].ToString());
                    ds2 = Microbiologytest_Class_Obj.Select_tblMicrobiologytest_TLFID();
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

                        if (ds2.Tables[0].Rows[0]["BpcNonBpc"].ToString() == "B")
                        {
                            RdoBpc.Checked = true;
                        }
                        if (ds2.Tables[0].Rows[0]["BpcNonBpc"].ToString() == "N")
                        {
                            RdoNonBpc.Checked = true;
                        }

                        txtCommentNonBpc.Text = ds2.Tables[0].Rows[0]["NonBpcComments"].ToString();
                        //txtcomments.Text = ds2.Tables[0].Rows[0]["Comment"].ToString();
                        txtComment.Text = ds2.Tables[0].Rows[0]["Comment"].ToString();
                    }
                }
                else
                {
                    
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

        private void dataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Only 0-9 and dot(.) allowed
            if ((Convert.ToInt32(e.KeyChar) != 8) && (Convert.ToInt32(e.KeyChar) != 46))
            {
                if ((Convert.ToInt32(e.KeyChar) >= 48) && (Convert.ToInt32(e.KeyChar) <= 57))
                {
                    
                }
                else
                { e.Handled = true; }
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

                for (int t = 0; t < dsTLFIDs.Tables[0].Rows.Count; t++)
                {
                    Microbiologytest_Class_Obj.tlfid = Convert.ToInt64(dsTLFIDs.Tables[0].Rows[t]["TLFID"]);

                    // Innoc Date & Time
                    if (DtpBroth_Innoc_Date.Checked == true)
                    {
                        Microbiologytest_Class_Obj.innoc_broth_date = DtpBroth_Innoc_Date.Value.ToShortDateString();
                        Microbiologytest_Class_Obj.innoc_broth_time = DtpBroth_Innoc_Time.Value.ToLongTimeString();
                    }
                    else
                    {
                        Microbiologytest_Class_Obj.innoc_broth_date = "";
                        Microbiologytest_Class_Obj.innoc_broth_time = "";
                    }


                    if (DtpAgar_Innoc_Date.Checked == true)
                    {
                        Microbiologytest_Class_Obj.innoc_agar_date = DtpAgar_Innoc_Date.Value.ToShortDateString();
                        Microbiologytest_Class_Obj.innoc_agar_time = DtpAgar_Innoc_Time.Value.ToLongTimeString();
                    }
                    else
                    {
                        Microbiologytest_Class_Obj.innoc_agar_date = "";
                        Microbiologytest_Class_Obj.innoc_agar_time = "";
                    }

                    //===========================================
                    //Inncubation Date & Time
                    // Broth
                    if (DtpBroth_Inncubation_Date.Checked == true)
                    {
                        Microbiologytest_Class_Obj.inccubation_broth_date = DtpBroth_Inncubation_Date.Value.ToShortDateString();
                        Microbiologytest_Class_Obj.inccubation_broth_time = DtpBroth_Inncubation_Time.Value.ToLongTimeString();
                    }
                    else
                    {
                        Microbiologytest_Class_Obj.inccubation_broth_date = "";
                        Microbiologytest_Class_Obj.inccubation_broth_time = "";
                    }

                    // Agar
                    if (DtpAgar_Inncubation_Date.Checked == true)
                    {
                        Microbiologytest_Class_Obj.inccubation_agar_date = DtpAgar_Inncubation_Date.Value.ToShortDateString();
                        Microbiologytest_Class_Obj.inccubation_agar_time = DtpAgar_Inncubation_Time.Value.ToLongTimeString();
                    }
                    else
                    {
                        Microbiologytest_Class_Obj.inccubation_agar_date = "";
                        Microbiologytest_Class_Obj.inccubation_agar_time = "";
                    }

                    // Other
                    if (DtpOther_Inncubation_Date.Checked == true)
                    {
                        Microbiologytest_Class_Obj.inccubation_other_date = DtpOther_Inncubation_Date.Value.ToShortDateString();
                        Microbiologytest_Class_Obj.inccubation_other_time = DtpOther_Inncubation_Time.Value.ToLongTimeString();
                    }
                    else
                    {
                        Microbiologytest_Class_Obj.inccubation_other_date = "";
                        Microbiologytest_Class_Obj.inccubation_other_time = "";
                    }

                    // Inncub Temp
                    if (txtBroth_Inncub_Temp.Text == "32.5 ± 2.5")
                    {
                        Microbiologytest_Class_Obj.inccub_broth_temp = Convert.ToString(32.5);
                    }
                    else
                    {
                        Microbiologytest_Class_Obj.inccub_broth_temp = txtBroth_Inncub_Temp.Text;
                    }
                    if (txtAgar_Inncub_Temp.Text == "32.5 ± 2.5")
                    {
                        //Microbiologytest_Class_Obj.inccub_agar_temp = Convert.ToString(22.5);
                        Microbiologytest_Class_Obj.inccub_agar_temp = Convert.ToString(32.5);
                    }
                    else
                    {
                        Microbiologytest_Class_Obj.inccub_agar_temp = txtAgar_Inncub_Temp.Text;
                    }
                    if (txtOther_Inncub_Temp.Text == "22.5 ± 2.5")
                    {
                        Microbiologytest_Class_Obj.inccub_other_temp = Convert.ToString(22.5);
                    }
                    else
                    {
                        Microbiologytest_Class_Obj.inccub_other_temp = txtOther_Inncub_Temp.Text;
                    }

                    // Result Date & Time
                    // Broth
                    if (DtpBroth_Result_Date.Checked == true)
                    {
                        Microbiologytest_Class_Obj.result_broth_date = DtpBroth_Result_Date.Value.ToShortDateString();
                        Microbiologytest_Class_Obj.result_broth_time = DtpBroth_Result_Time.Value.ToLongTimeString();
                    }
                    else
                    {
                        Microbiologytest_Class_Obj.result_broth_date = "";
                        Microbiologytest_Class_Obj.result_broth_time = "";
                    }

                    // Agar
                    if (DtpAgar_Result_Date.Checked == true)
                    {
                        Microbiologytest_Class_Obj.result_agar_date = DtpAgar_Result_Date.Value.ToShortDateString();
                        Microbiologytest_Class_Obj.result_agar_time = DtpAgar_Result_Time.Value.ToLongTimeString();
                    }
                    else
                    {
                        Microbiologytest_Class_Obj.result_agar_date = "";
                        Microbiologytest_Class_Obj.result_agar_time = "";
                    }

                    // Other
                    if (DtpOther_Result_Date.Checked == true)
                    {
                        Microbiologytest_Class_Obj.result_other_date = DtpOther_Result_Date.Value.ToShortDateString();
                        Microbiologytest_Class_Obj.result_other_time = DtpOther_Result_Time.Value.ToLongTimeString();
                    }
                    else
                    {
                        Microbiologytest_Class_Obj.result_other_date = "";
                        Microbiologytest_Class_Obj.result_other_time = "";
                    }

                    // Total Time

                    Microbiologytest_Class_Obj.totaltime_broth = txtTotalTime_Broth.Text;
                    Microbiologytest_Class_Obj.totaltime_agar = txtTotalTime_Agar.Text;
                    Microbiologytest_Class_Obj.totaltime_other = txtTotalTime_Other.Text;

                    // Remarks
                    if (cmbRemarks_Broth.Text != "--Select--")
                    {
                        Microbiologytest_Class_Obj.remarks_broth = cmbRemarks_Broth.Text;
                    }
                    else
                    {
                        Microbiologytest_Class_Obj.remarks_broth = "";
                    }
                    if (cmbRemarks_Agar.Text != "--Select--")
                    {
                        Microbiologytest_Class_Obj.remarks_agar = cmbRemarks_Agar.Text;
                    }
                    else
                    {
                        Microbiologytest_Class_Obj.remarks_agar = "";
                    }
                    if (cmbRemarks_Other.Text != "--Select--")
                    {
                        Microbiologytest_Class_Obj.remarks_other = cmbRemarks_Other.Text;
                    }
                    else
                    {
                        Microbiologytest_Class_Obj.remarks_other = "";
                    }

                    if (RdoAccepted.Checked == true)
                    {
                        Microbiologytest_Class_Obj.status = Convert.ToChar("A");
                    }
                    else if (RdoRejected.Checked == true)
                    {
                        Microbiologytest_Class_Obj.status = Convert.ToChar("R");
                    }
                    else if (RdoHold.Checked == true)
                    {
                        Microbiologytest_Class_Obj.status = Convert.ToChar("H");
                    }
                    else if (RdoAcceptedwithDerrogation.Checked == true)
                    {
                        Microbiologytest_Class_Obj.status = Convert.ToChar("D");
                    }

                    if (chkSampleToRetainer.Checked == true)
                    {
                        Microbiologytest_Class_Obj.sampletoretainer = Convert.ToChar("Y");
                    }
                    else if (chkSampleToRetainer.Checked == false)
                    {
                        Microbiologytest_Class_Obj.sampletoretainer = Convert.ToChar("N");
                    }
                    if (RdoBpc.Checked == true)
                    {
                        Microbiologytest_Class_Obj.bpcnonbpc = Convert.ToChar("B");
                        Microbiologytest_Class_Obj.nonbpccomments = "";
                    }
                    else if (RdoNonBpc.Checked == true)
                    {
                        Microbiologytest_Class_Obj.bpcnonbpc = Convert.ToChar("N");
                        Microbiologytest_Class_Obj.nonbpccomments = txtCommentNonBpc.Text;
                    }
                    Microbiologytest_Class_Obj.comments = txtComment.Text; //txtcomments.Text;
                    Microbiologytest_Class_Obj.cleardate = DtpClearDate.Value.ToShortDateString();

                    Microbiologytest_Class_Obj.medialotno = txtMediaLotNo.Text;

                    Microbiologytest_Class_Obj.inspectedby = Convert.ToInt32(cmbInspectedBy.SelectedValue);

                    Microbiologytest_Class_Obj.loginid = FrmMain.LoginID;

                    // Insert in tblMicrobiologytest OR update if already Exists for TLFID
                    bool b = false;
                    b = Microbiologytest_Class_Obj.Insert_tblMicrobiologytest();
                }
                                
                // Insert in tblMicrobiologytest_SampleDetails OR update if already Exists for BulkTankDetailNo & TLFID
                //for (int i = 0; i < dataGridView.Rows.Count; i++)
                //{
                //    Microbiologytest_Class_Obj.tlfid = Convert.ToInt64(dataGridView["TLFID", i].Value);
                //    Microbiologytest_Class_Obj.bulktankdetailno = Convert.ToInt64(dataGridView["BulkTankDetailNo", i].Value);
                                           
                //    if (dataGridView["FSD", i].Value == null)
                //    {
                //        Microbiologytest_Class_Obj.fsd = "";
                //    }
                //    else
                //    {
                //        Microbiologytest_Class_Obj.fsd = Convert.ToString(dataGridView["FSD", i].Value.ToString());
                //    }
                //    if (dataGridView["STS", i].Value == null)
                //    {
                //        Microbiologytest_Class_Obj.sts = "";
                //    }
                //    else
                //    {
                //        Microbiologytest_Class_Obj.sts = Convert.ToString(dataGridView["STS", i].Value.ToString());
                //    }
                //    if (dataGridView["LBK", i].Value == null)
                //    {
                //        Microbiologytest_Class_Obj.lbk = "";
                //    }
                //    else
                //    {
                //        Microbiologytest_Class_Obj.lbk = Convert.ToString(dataGridView["LBK", i].Value.ToString());
                //    }
                //    if (dataGridView["EST", i].Value == null)
                //    {
                //        Microbiologytest_Class_Obj.est = "";
                //    }
                //    else
                //    {
                //        Microbiologytest_Class_Obj.est = Convert.ToString(dataGridView["EST", i].Value.ToString());
                //    }
                //    if (dataGridView["LSD", i].Value == null)
                //    {
                //        Microbiologytest_Class_Obj.lsd = "";
                //    }
                //    else
                //    {
                //        Microbiologytest_Class_Obj.lsd = Convert.ToString(dataGridView["LSD", i].Value.ToString());
                //    }
                //    if (dataGridView["CM1", i].Value == null)
                //    {
                //        Microbiologytest_Class_Obj.cm1 = "";
                //    }
                //    else
                //    {
                //        Microbiologytest_Class_Obj.cm1 = Convert.ToString(dataGridView["CM1", i].Value.ToString());
                //    }
                //    if (dataGridView["CM2", i].Value == null)
                //    {
                //        Microbiologytest_Class_Obj.cm2 = "";
                //    }
                //    else
                //    {
                //        Microbiologytest_Class_Obj.cm2 = Convert.ToString(dataGridView["CM2", i].Value.ToString());
                //    }

                //    if (dataGridView["CM3", i].Value == null)
                //    {
                //        Microbiologytest_Class_Obj.cm3 = "";
                //    }
                //    else
                //    {
                //        Microbiologytest_Class_Obj.cm3 = Convert.ToString(dataGridView["CM3", i].Value.ToString());
                //    }

                //    if (dataGridView["CM4", i].Value == null)
                //    {
                //        Microbiologytest_Class_Obj.cm4 = "";
                //    }
                //    else
                //    {
                //        Microbiologytest_Class_Obj.cm4 = Convert.ToString(dataGridView["CM4", i].Value.ToString());
                //    }

                //    if (dataGridView["CM5", i].Value == null)
                //    {
                //        Microbiologytest_Class_Obj.cm5 = "";
                //    }
                //    else
                //    {
                //        Microbiologytest_Class_Obj.cm5 = Convert.ToString(dataGridView["CM5", i].Value.ToString());
                //    }
                //    Microbiologytest_Class_Obj.Insert_tblMicrobiologytest_SampleDetails();
                //}
                

                //--------- Set MicroDone = 1 if not hold 
                //--------- By keeping hold user can again open record to enter details 
                if (RdoHold.Checked != true)
                {
                    for (int t = 0; t < dsTLFIDs.Tables[0].Rows.Count; t++)
                    {
                        Microbiologytest_Class_Obj.tlfid = Convert.ToInt64(dsTLFIDs.Tables[0].Rows[t]["TLFID"]);

                        Microbiologytest_Class_Obj.microdone = true;
                        bool a = Microbiologytest_Class_Obj.Update_tblTransTLF_MicroDone();
                    }
                    MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (RdoHold.Checked == true)
                {
                    MessageBox.Show("Record On Hold", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                BtnReset_Click(sender, e);
                Bind_Details();
                cmbDetails.Focus();
                return;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
               
        private void RdoBpc_CheckedChanged(object sender, EventArgs e)
        {
            if (RdoBpc.Checked == true)
            {
                txtCommentNonBpc.Enabled = false;
                txtCommentNonBpc.Text = "";
            }
            else
            {
                txtCommentNonBpc.Enabled = true;
                txtCommentNonBpc.Focus();
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

        private void txtCommentNonBpc_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtCommentNonBpc.Text = textInfo.ToTitleCase(txtCommentNonBpc.Text);	
        }

        private void txtcomments_Leave(object sender, EventArgs e)
        {
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
            TextInfo textInfo = cultureInfo.TextInfo;
            txtcomments.Text = textInfo.ToTitleCase(txtcomments.Text);	
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

        private void DtpClearDate_ValueChanged(object sender, EventArgs e)
        {
            //DtpBroth_Innoc_Date.Value = DtpClearDate.Value.AddDays(0);
            //DtpBroth_Inncubation_Date.Value = DtpClearDate.Value.AddDays(0);
            //DtpBroth_Result_Date.Value = DtpClearDate.Value.AddDays(1);

            //DtpAgar_Innoc_Date.Value = DtpClearDate.Value.AddDays(1);
            //DtpAgar_Inncubation_Date.Value = DtpClearDate.Value.AddDays(1);
            //DtpAgar_Result_Date.Value = DtpClearDate.Value.AddDays(3);

            //DtpOther_Inncubation_Date.Value = DtpClearDate.Value.AddDays(3);
            //DtpOther_Result_Date.Value = DtpClearDate.Value.AddDays(8);
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

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbDetails_SelectedIndexChanged(object sender, EventArgs e)
        {

        }   
        
    }
}