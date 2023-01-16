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
    public partial class FrmRMMicrobiologyTest : Form
    {
        public FrmRMMicrobiologyTest()
        {            
            InitializeComponent();
        }

        # region Varibles        
        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        BusinessFacade.Transactions.RMMicrobiologytest_Class RMMicrobiologytest_Class_Obj = new BusinessFacade.Transactions.RMMicrobiologytest_Class();
        BusinessFacade.Transactions.Microbiologytest_Class Microbiologytest_Class_Obj = new BusinessFacade.Transactions.Microbiologytest_Class();
        BusinessFacade.UserManagement_Class UserManagement_Class_Obj = new BusinessFacade.UserManagement_Class();

        // this flag is used to determine whether fuction is called at Load or Value change 

        private DataTable DtRMCodeID;
        
        # endregion

        private static FrmRMMicrobiologyTest FrmRMMicrobiologyTest_Obj = null;
        public static FrmRMMicrobiologyTest GetInstance()
        {
            if (FrmRMMicrobiologyTest_Obj == null)
            {
                FrmRMMicrobiologyTest_Obj = new FrmRMMicrobiologyTest();
            }
            return FrmRMMicrobiologyTest_Obj;
        }

        private void FrmRMMicrobiologyTest_Load(object sender, EventArgs e)
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
                DataTable dt = new DataTable();
                DataRow dr;                
                dt = RMMicrobiologytest_Class_Obj.select_PendingRMMicrobiologyDetails();
                dr = dt.NewRow();
                dr["Details"] = "--Select--";
                dt.Rows.InsertAt(dr, 0);
                if (dt.Rows.Count > 0)
                {
                    cmbDetails.DataSource = dt;
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
            set_Todays_date_Time();
            cmbMethodName.Text = "--Select--";
            txtBroth_Inncub_Temp.Text = "32.5 ± 2.5";
            txtAgar_Inncub_Temp.Text = "22.5 ± 2.5";
            txtOther_Inncub_Temp.Text = "22.5 ± 2.5";
            txtTotalTime_Broth.Text = "";
            txtTotalTime_Agar.Text = "";
            txtTotalTime_Other.Text = "";
            txtDescription.Text = "";
            cmbRemarks_Broth.Text = "--Select--";
            cmbRemarks_Agar.Text = "--Select--";
            cmbRemarks_Other.Text = "--Select--";
                        
            RdoAccepted.Checked = true;
            chkSampleToRetainer.Checked = false; 
           
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
                    //splits RMCodeID,ReceiptDate,Plantlotno  from DetailsNo("203-07/29/2008-78")
                    string[] DNo = cmbDetails.SelectedValue.ToString().Split('-');
                    RMMicrobiologytest_Class_Obj.RMCodeID = Convert.ToInt64(DNo[0]);
                    RMMicrobiologytest_Class_Obj.ReceiptDate = DNo[1];
                    RMMicrobiologytest_Class_Obj.PlantLotNo = DNo[2];
                    DtRMCodeID = new DataTable();
                    DtRMCodeID = RMMicrobiologytest_Class_Obj.select_RMMicrobiologyDetails_RMCodeID();
                    if (DtRMCodeID.Rows.Count > 0)
                    {
                        txtDescription.Text = Convert.ToString(DtRMCodeID.Rows[0]["RMINCIName"]);
                        txtNorms.Text = Convert.ToString(DtRMCodeID.Rows[0]["MicroNorms"]);
                    }
                    //------------Displays all dates and time From database
                    RMMicrobiologytest_Class_Obj.RMDetailID = Convert.ToInt64(DtRMCodeID.Rows[0]["RMDetailID"]);
                    DataTable dt = new DataTable();
                    dt = RMMicrobiologytest_Class_Obj.Select_tblRMMicrobiologytest_RMDetailsID();
                    if (dt.Rows.Count > 0)
                    {

                        if (dt.Rows[0]["ClearDate"].ToString() != "")
                        {
                            DtpClearDate.Value = Convert.ToDateTime(dt.Rows[0]["ClearDate"].ToString());
                        }
                        if (dt.Rows[0]["MediaLotNo"].ToString() != "")
                        {
                            txtMediaLotNo.Text = dt.Rows[0]["MediaLotNo"].ToString();
                        }
                        switch (dt.Rows[0]["MethodName"].ToString())
                        {
                            case "F1":
                                cmbMethodName.SelectedIndex = 0;
                                break;
                            case "F2":
                                cmbMethodName.SelectedIndex = 1;
                                break;
                            case "F4":
                                cmbMethodName.SelectedIndex = 2;
                                break;
                            case "F5":
                                cmbMethodName.SelectedIndex = 3;
                                break;
                            default:
                                break;
                        }
                        if (dt.Rows[0]["MethodName"].ToString() != "" && dt.Rows[0]["MethodName"] != null)
                        {
                            cmbMethodName.Text = dt.Rows[0]["MethodName"].ToString();
                        }
                        if (dt.Rows[0]["Innoc_Broth_Date"].ToString() != "")
                        {
                            DtpBroth_Innoc_Date.Value = Convert.ToDateTime(dt.Rows[0]["Innoc_Broth_Date"].ToString());
                        }
                        if (dt.Rows[0]["Innoc_Broth_Time"].ToString() != "")
                        {
                            DtpBroth_Innoc_Time.Value = Convert.ToDateTime(dt.Rows[0]["Innoc_Broth_Time"].ToString());
                        }
                        if (dt.Rows[0]["Innoc_Agar_Date"].ToString() != "")
                        {
                            DtpAgar_Innoc_Date.Value = Convert.ToDateTime(dt.Rows[0]["Innoc_Agar_Date"].ToString());
                        }
                        if (dt.Rows[0]["Innoc_Agar_Time"].ToString() != "")
                        {
                            DtpAgar_Innoc_Time.Value = Convert.ToDateTime(dt.Rows[0]["Innoc_Agar_Time"].ToString());
                        }
                        if (dt.Rows[0]["Inccubation_Broth_Date"].ToString() != "")
                        {
                            DtpBroth_Inncubation_Date.Value = Convert.ToDateTime(dt.Rows[0]["Inccubation_Broth_Date"].ToString());
                        }
                        if (dt.Rows[0]["Inccubation_Broth_Time"].ToString() != "")
                        {
                            DtpBroth_Inncubation_Time.Value = Convert.ToDateTime(dt.Rows[0]["Inccubation_Broth_Time"].ToString());
                        }
                        if (dt.Rows[0]["Inccubation_Agar_Date"].ToString() != "")
                        {
                            DtpAgar_Inncubation_Date.Value = Convert.ToDateTime(dt.Rows[0]["Inccubation_Agar_Date"].ToString());
                        }
                        if (dt.Rows[0]["Inccubation_Agar_Time"].ToString() != "")
                        {
                            DtpAgar_Inncubation_Time.Value = Convert.ToDateTime(dt.Rows[0]["Inccubation_Agar_Time"].ToString());
                        }
                        if (dt.Rows[0]["Inccubation_Other_Date"].ToString() != "")
                        {
                            DtpOther_Inncubation_Date.Value = Convert.ToDateTime(dt.Rows[0]["Inccubation_Other_Date"].ToString());
                        }
                        if (dt.Rows[0]["Inccubation_Other_time"].ToString() != "")
                        {
                            DtpOther_Inncubation_Time.Value = Convert.ToDateTime(dt.Rows[0]["Inccubation_Other_time"].ToString());
                        }


                        //Show data of Dilution D1
                        if (dt.Rows[0]["DilutionD1Innoc_Broth_Date"].ToString() != "")
                        {
                            DtpBroth_DilutionD1Innoc_Date.Value = Convert.ToDateTime(dt.Rows[0]["DilutionD1Innoc_Broth_Date"].ToString());
                        }
                        if (dt.Rows[0]["DilutionD1Innoc_Broth_Time"].ToString() != "")
                        {
                            DtpBroth_DilutionD1Innoc_Time.Value = Convert.ToDateTime(dt.Rows[0]["DilutionD1Innoc_Broth_Time"].ToString());
                        }
                        if (dt.Rows[0]["DilutionD1Innoc_Agar_Date"].ToString() != "")
                        {
                            DtpAgar_DilutionD1Innoc_Date.Value = Convert.ToDateTime(dt.Rows[0]["DilutionD1Innoc_Agar_Date"].ToString());
                        }
                        if (dt.Rows[0]["DilutionD1Innoc_Agar_Time"].ToString() != "")
                        {
                            DtpAgar_DilutionD1Innoc_Time.Value = Convert.ToDateTime(dt.Rows[0]["DilutionD1Innoc_Agar_Time"].ToString());
                        }
                        if (dt.Rows[0]["DilutionD1Innoc_Other_Date"].ToString() != "")
                        {
                            DtpOther_DilutionD1Innoc_Date.Value = Convert.ToDateTime(dt.Rows[0]["DilutionD1Innoc_Other_Date"].ToString());
                        }
                        if (dt.Rows[0]["DilutionD1Innoc_Other_time"].ToString() != "")
                        {
                            DtpOther_DilutionD1Innoc_Time.Value = Convert.ToDateTime(dt.Rows[0]["DilutionD1Innoc_Other_time"].ToString());
                        }



                        //show data for dilution D2
                        if (dt.Rows[0]["DilutionD2Innoc_Broth_Date"].ToString() != "")
                        {
                            DtpBroth_DilutionD2Innoc_Date.Value = Convert.ToDateTime(dt.Rows[0]["DilutionD2Innoc_Broth_Date"].ToString());
                        }
                        if (dt.Rows[0]["DilutionD2Innoc_Broth_Time"].ToString() != "")
                        {
                            DtpBroth_DilutionD2Innoc_Time.Value = Convert.ToDateTime(dt.Rows[0]["DilutionD2Innoc_Broth_Time"].ToString());
                        }
                        if (dt.Rows[0]["DilutionD2Innoc_Agar_Date"].ToString() != "")
                        {
                            DtpAgar_DilutionD2Innoc_Date.Value = Convert.ToDateTime(dt.Rows[0]["DilutionD2Innoc_Agar_Date"].ToString());
                        }
                        if (dt.Rows[0]["DilutionD2Innoc_Agar_Time"].ToString() != "")
                        {
                            DtpAgar_DilutionD2Innoc_Time.Value = Convert.ToDateTime(dt.Rows[0]["DilutionD2Innoc_Agar_Time"].ToString());
                        }
                        if (dt.Rows[0]["DilutionD2Innoc_Other_Date"].ToString() != "")
                        {
                            DtpOther_DilutionD2Innoc_Date.Value = Convert.ToDateTime(dt.Rows[0]["DilutionD2Innoc_Other_Date"].ToString());
                        }
                        if (dt.Rows[0]["DilutionD2Innoc_Other_time"].ToString() != "")
                        {
                            DtpOther_DilutionD2Innoc_Time.Value = Convert.ToDateTime(dt.Rows[0]["DilutionD2Innoc_Other_time"].ToString());
                        }


                        // Show Data for Dilution D3
                        if (dt.Rows[0]["DilutionD3Innoc_Broth_Date"].ToString() != "")
                        {
                            DtpBroth_DilutionD3Innoc_Date.Value = Convert.ToDateTime(dt.Rows[0]["DilutionD3Innoc_Broth_Date"].ToString());
                        }
                        if (dt.Rows[0]["DilutionD3Innoc_Broth_Time"].ToString() != "")
                        {
                            DtpBroth_DilutionD3Innoc_Time.Value = Convert.ToDateTime(dt.Rows[0]["DilutionD3Innoc_Broth_Time"].ToString());
                        }
                        if (dt.Rows[0]["DilutionD3Innoc_Agar_Date"].ToString() != "")
                        {
                            DtpAgar_DilutionD3Innoc_Date.Value = Convert.ToDateTime(dt.Rows[0]["DilutionD3Innoc_Agar_Date"].ToString());
                        }
                        if (dt.Rows[0]["DilutionD3Innoc_Agar_Time"].ToString() != "")
                        {
                            DtpAgar_DilutionD3Innoc_Time.Value = Convert.ToDateTime(dt.Rows[0]["DilutionD3Innoc_Agar_Time"].ToString());
                        }
                        if (dt.Rows[0]["DilutionD3Innoc_Other_Date"].ToString() != "")
                        {
                            DtpOther_DilutionD3Innoc_Date.Value = Convert.ToDateTime(dt.Rows[0]["DilutionD3Innoc_Other_Date"].ToString());
                        }
                        if (dt.Rows[0]["DilutionD3Innoc_Other_time"].ToString() != "")
                        {
                            DtpOther_DilutionD3Innoc_Time.Value = Convert.ToDateTime(dt.Rows[0]["DilutionD3Innoc_Other_time"].ToString());
                        }



                        if (dt.Rows[0]["Result_Broth_Date"].ToString() != "")
                        {
                            DtpBroth_Result_Date.Value = Convert.ToDateTime(dt.Rows[0]["Result_Broth_Date"].ToString());
                        }
                        if (dt.Rows[0]["Result_Broth_Time"].ToString() != "")
                        {
                            DtpBroth_Result_Time.Value = Convert.ToDateTime(dt.Rows[0]["Result_Broth_Time"].ToString());
                        }
                        if (dt.Rows[0]["Result_Agar_Date"].ToString() != "")
                        {
                            DtpAgar_Result_Date.Value = Convert.ToDateTime(dt.Rows[0]["Result_Agar_Date"].ToString());
                        }
                        if (dt.Rows[0]["Result_Agar_Time"].ToString() != "")
                        {
                            DtpAgar_Result_Time.Value = Convert.ToDateTime(dt.Rows[0]["Result_Agar_Time"].ToString());
                        }
                        if (dt.Rows[0]["Result_Other_Date"].ToString() != "")
                        {
                            DtpOther_Result_Date.Value = Convert.ToDateTime(dt.Rows[0]["Result_Other_Date"].ToString());
                        }
                        if (dt.Rows[0]["Result_Other_Time"].ToString() != "")
                        {
                            DtpOther_Result_Time.Value = Convert.ToDateTime(dt.Rows[0]["Result_Other_Time"].ToString());
                        }
                        if (dt.Rows[0]["Remarks_Broth"].ToString() == "Presence Of Bactorial Growth")
                        {
                            cmbRemarks_Broth.SelectedIndex = 1;
                        }
                        else if (dt.Rows[0]["Remarks_Broth"].ToString() == "Absence Of Bactorial Growth")
                        {
                            cmbRemarks_Broth.SelectedIndex = 2;
                        }
                        else
                        {
                            cmbRemarks_Broth.SelectedIndex = 0;
                        }


                        if (dt.Rows[0]["Remarks_Agar"].ToString() == "Presence Of Bactorial Growth")
                        {
                            cmbRemarks_Agar.SelectedIndex = 1;
                        }
                        else if (dt.Rows[0]["Remarks_Agar"].ToString() == "Absence Of Bactorial Growth")
                        {
                            cmbRemarks_Agar.SelectedIndex = 2;
                        }
                        else
                        {
                            cmbRemarks_Agar.SelectedIndex = 0;
                        }


                        if (dt.Rows[0]["Remarks_Other"].ToString() == "Presence Of Fungal Growth")
                        {
                            cmbRemarks_Other.SelectedIndex = 1;
                        }
                        else if (dt.Rows[0]["Remarks_Other"].ToString() == "<100 MOULDS & YEAST IN Gm TESTED")
                        {
                            cmbRemarks_Other.SelectedIndex = 2;
                        }
                        else
                        {
                            cmbRemarks_Other.SelectedIndex = 0;
                        }


                        txtBroth_Inncub_Temp.Text = dt.Rows[0]["Inccub_Broth_Temp"].ToString();
                        txtAgar_Inncub_Temp.Text = dt.Rows[0]["Inccub_Agar_Temp"].ToString();
                        txtOther_Inncub_Temp.Text = dt.Rows[0]["Inccub_Other_Temp"].ToString();

                        txtTotalTime_Broth.Text = dt.Rows[0]["TotalTime_Broth"].ToString();
                        txtTotalTime_Agar.Text = dt.Rows[0]["TotalTime_Agar"].ToString();
                        txtTotalTime_Other.Text = dt.Rows[0]["TotalTime_Other"].ToString();

                        if (dt.Rows[0]["Status"].ToString() == "A")
                        {
                            RdoAccepted.Checked = true;
                        }
                        else if (dt.Rows[0]["Status"].ToString() == "R")
                        {
                            RdoRejected.Checked = true;
                        }
                        else if (dt.Rows[0]["Status"].ToString() == "H")
                        {
                            RdoHold.Checked = true;
                        }
                        else if (dt.Rows[0]["Status"].ToString() == "D")
                        {
                            RdoAcceptedwithDerrogation.Checked = true;
                        }

                        if (dt.Rows[0]["SampleToRetainer"].ToString() == "Y")
                        {
                            chkSampleToRetainer.Checked = true;
                        }
                        else if (dt.Rows[0]["SampleToRetainer"].ToString() == "N")
                        {
                            chkSampleToRetainer.Checked = false;
                        }
                        cmbInspectedBy.SelectedValue = Convert.ToInt32(dt.Rows[0]["InspectedBy"]);
                        
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

        private bool IsValid()
        {
            if (cmbDetails.Text == "--Select--")
            {
                MessageBox.Show("Select Formula No", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbDetails.Focus();
                return false;
            }
            if (cmbInspectedBy.SelectedValue == null || cmbInspectedBy.Text == "--Select--")
            {
                MessageBox.Show("Please Select Inspected By", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbInspectedBy.Focus();
                return false;
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
                    return false;
                }

                if (DtpBroth_Result_Date.Value.Date < DtpBroth_Inncubation_Date.Value.Date)
                {
                    MessageBox.Show("result date prior to start date");
                    txtTotalTime_Broth.Text = "";
                    return false;
                }

                if (DtpAgar_Result_Date.Value.Date < DtpAgar_Inncubation_Date.Value.Date)
                {
                    MessageBox.Show("result date prior to start date");
                    txtTotalTime_Agar.Text = "";
                    return false;
                }

                if (DtpOther_Result_Date.Value.Date < DtpOther_Inncubation_Date.Value.Date)
                {
                    MessageBox.Show("result date prior to start date");
                    txtTotalTime_Other.Text = "";
                    return false;
                }


                if (txtTotalTime_Agar.Text == "")
                {
                    MessageBox.Show("Enter Agar Total Time", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTotalTime_Agar.Focus();
                    return false;
                }
                if (txtTotalTime_Broth.Text == "")
                {
                    MessageBox.Show("Enter Broth Total Time", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTotalTime_Broth.Focus();
                    return false;
                }
                if (txtTotalTime_Other.Text == "")
                {
                    MessageBox.Show("Enter Other Total Time", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtTotalTime_Other.Focus();
                    return false;
                }
            }
            if (RdoAccepted.Checked == true)
            {
                if (MessageBox.Show("ACCEPT ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                {
                    return false;
                }
            }
            if (RdoRejected.Checked == true)
            {
                if (MessageBox.Show("REJECT ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                {
                    return false;
                }
            }
            if (RdoHold.Checked == true)
            {
                if (MessageBox.Show("HOLD ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                {
                    return false;
                }
            }
            if (RdoAcceptedwithDerrogation.Checked == true)
            {
                if (MessageBox.Show("ACCEPT WITH DERROGATION ?", "Status", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.No))
                {
                    return false; 
                }
            }
            return true;
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsValid())
                {
                    for (int i = 0; i < DtRMCodeID.Rows.Count; i++)
                    {
                        RMMicrobiologytest_Class_Obj.RMDetailID = Convert.ToInt64(DtRMCodeID.Rows[0]["RMDetailID"]);
                        // Innoc Date & Time
                        if (DtpBroth_Innoc_Date.Checked == true)
                        {
                            RMMicrobiologytest_Class_Obj.Innoc_Broth_Date = DtpBroth_Innoc_Date.Value;
                            RMMicrobiologytest_Class_Obj.Innoc_Broth_Time = DtpBroth_Innoc_Time.Value.ToLongTimeString();
                        }
                        else
                        {
                            RMMicrobiologytest_Class_Obj.Innoc_Broth_Date = Convert.ToDateTime("1 / 1 / 1900");
                            RMMicrobiologytest_Class_Obj.Innoc_Broth_Time = "";
                        }


                        if (DtpAgar_Innoc_Date.Checked == true)
                        {
                            RMMicrobiologytest_Class_Obj.Innoc_Agar_Date = DtpAgar_Innoc_Date.Value;
                            RMMicrobiologytest_Class_Obj.Innoc_Agar_Time = DtpAgar_Innoc_Time.Value.ToLongTimeString();
                        }
                        else
                        {
                            RMMicrobiologytest_Class_Obj.Innoc_Agar_Date = Convert.ToDateTime("1 / 1 / 1900");
                            RMMicrobiologytest_Class_Obj.Innoc_Agar_Time = "";
                        }

                        //===========================================
                        //Inncubation Date & Time
                        // Broth
                        if (DtpBroth_Inncubation_Date.Checked == true)
                        {
                            RMMicrobiologytest_Class_Obj.Inccubation_Broth_Date = DtpBroth_Inncubation_Date.Value;
                            RMMicrobiologytest_Class_Obj.Inccubation_Broth_Time = DtpBroth_Inncubation_Time.Value.ToLongTimeString();
                        }
                        else
                        {
                            RMMicrobiologytest_Class_Obj.Inccubation_Broth_Date = Convert.ToDateTime("1 / 1 / 1900");
                            RMMicrobiologytest_Class_Obj.Inccubation_Broth_Time = "";
                        }

                        // Agar
                        if (DtpAgar_Inncubation_Date.Checked == true)
                        {
                            RMMicrobiologytest_Class_Obj.Inccubation_Agar_Date = DtpAgar_Inncubation_Date.Value;
                            RMMicrobiologytest_Class_Obj.Inccubation_Agar_Time = DtpAgar_Inncubation_Time.Value.ToLongTimeString();
                        }
                        else
                        {
                            RMMicrobiologytest_Class_Obj.Inccubation_Agar_Date = Convert.ToDateTime("1 / 1 / 1900");
                            RMMicrobiologytest_Class_Obj.Inccubation_Agar_Time = "";
                        }

                        // Other
                        if (DtpOther_Inncubation_Date.Checked == true)
                        {
                            RMMicrobiologytest_Class_Obj.Inccubation_Other_Date = DtpOther_Inncubation_Date.Value;
                            RMMicrobiologytest_Class_Obj.Inccubation_Other_Time = DtpOther_Inncubation_Time.Value.ToLongTimeString();
                        }
                        else
                        {
                            RMMicrobiologytest_Class_Obj.Inccubation_Other_Date = Convert.ToDateTime("1 / 1 / 1900");
                            RMMicrobiologytest_Class_Obj.Inccubation_Other_Time = "";
                        }

                        //===========================================
                        //Dilution D1 Date & Time
                        // Broth
                        if (DtpBroth_DilutionD1Innoc_Date.Checked == true)
                        {
                            RMMicrobiologytest_Class_Obj.DilutionD1Innoc_Broth_Date = DtpBroth_DilutionD1Innoc_Date.Value;
                            RMMicrobiologytest_Class_Obj.DilutionD1Innoc_Broth_Time = DtpBroth_DilutionD1Innoc_Time.Value.ToLongTimeString();
                        }
                        else
                        {
                            RMMicrobiologytest_Class_Obj.DilutionD1Innoc_Broth_Date = Convert.ToDateTime("1 / 1 / 1900");
                            RMMicrobiologytest_Class_Obj.DilutionD1Innoc_Broth_Time = "";
                        }

                        // Agar
                        if (DtpAgar_DilutionD1Innoc_Date.Checked == true)
                        {
                            RMMicrobiologytest_Class_Obj.DilutionD1Innoc_Agar_Date = DtpAgar_DilutionD1Innoc_Date.Value;
                            RMMicrobiologytest_Class_Obj.DilutionD1Innoc_Agar_Time = DtpAgar_DilutionD1Innoc_Time.Value.ToLongTimeString();
                        }
                        else
                        {
                            RMMicrobiologytest_Class_Obj.DilutionD1Innoc_Agar_Date = Convert.ToDateTime("1 / 1 / 1900");
                            RMMicrobiologytest_Class_Obj.DilutionD1Innoc_Agar_Time = "";
                        }

                        // Other
                        if (DtpOther_Inncubation_Date.Checked == true)
                        {
                            RMMicrobiologytest_Class_Obj.DilutionD1Innoc_Other_Date = DtpOther_DilutionD1Innoc_Date.Value;
                            RMMicrobiologytest_Class_Obj.DilutionD1Innoc_Other_Time = DtpOther_DilutionD1Innoc_Time.Value.ToLongTimeString();
                        }
                        else
                        {
                            RMMicrobiologytest_Class_Obj.DilutionD1Innoc_Other_Date = Convert.ToDateTime("1 / 1 / 1900");
                            RMMicrobiologytest_Class_Obj.DilutionD1Innoc_Other_Time = "";
                        }



                        //===========================================
                        //Dilution D2 Date & Time
                        // Broth
                        if (DtpBroth_DilutionD2Innoc_Date.Checked == true)
                        {
                            RMMicrobiologytest_Class_Obj.DilutionD2Innoc_Broth_Date = DtpBroth_DilutionD2Innoc_Date.Value;
                            RMMicrobiologytest_Class_Obj.DilutionD2Innoc_Broth_Time = DtpBroth_DilutionD2Innoc_Time.Value.ToLongTimeString();
                        }
                        else
                        {
                            RMMicrobiologytest_Class_Obj.DilutionD2Innoc_Broth_Date = Convert.ToDateTime("1 / 1 / 1900");
                            RMMicrobiologytest_Class_Obj.DilutionD2Innoc_Broth_Time = "";
                        }

                        // Agar
                        if (DtpAgar_DilutionD2Innoc_Date.Checked == true)
                        {
                            RMMicrobiologytest_Class_Obj.DilutionD2Innoc_Agar_Date = DtpAgar_DilutionD2Innoc_Date.Value;
                            RMMicrobiologytest_Class_Obj.DilutionD2Innoc_Agar_Time = DtpAgar_DilutionD2Innoc_Time.Value.ToLongTimeString();
                        }
                        else
                        {
                            RMMicrobiologytest_Class_Obj.DilutionD2Innoc_Agar_Date = Convert.ToDateTime("1 / 1 / 1900");
                            RMMicrobiologytest_Class_Obj.DilutionD2Innoc_Agar_Time = "";
                        }

                        // Other
                        if (DtpOther_DilutionD2Innoc_Date.Checked == true)
                        {
                            RMMicrobiologytest_Class_Obj.DilutionD2Innoc_Other_Date = DtpOther_DilutionD2Innoc_Date.Value;
                            RMMicrobiologytest_Class_Obj.DilutionD2Innoc_Other_Time = DtpOther_DilutionD2Innoc_Time.Value.ToLongTimeString();
                        }
                        else
                        {
                            RMMicrobiologytest_Class_Obj.DilutionD2Innoc_Other_Date = Convert.ToDateTime("1 / 1 / 1900");
                            RMMicrobiologytest_Class_Obj.DilutionD2Innoc_Other_Time = "";
                        }

                        //===========================================
                        //Dilution D2 Date & Time
                        // Broth
                        if (DtpBroth_DilutionD3Innoc_Date.Checked == true)
                        {
                            RMMicrobiologytest_Class_Obj.DilutionD3Innoc_Broth_Date = DtpBroth_DilutionD2Innoc_Date.Value;
                            RMMicrobiologytest_Class_Obj.DilutionD3Innoc_Broth_Time = DtpBroth_DilutionD2Innoc_Time.Value.ToLongTimeString();
                        }
                        else
                        {
                            RMMicrobiologytest_Class_Obj.DilutionD3Innoc_Broth_Date = Convert.ToDateTime("1 / 1 / 1900");
                            RMMicrobiologytest_Class_Obj.DilutionD3Innoc_Broth_Time = "";
                        }

                        // Agar
                        if (DtpAgar_DilutionD3Innoc_Date.Checked == true)
                        {
                            RMMicrobiologytest_Class_Obj.DilutionD3Innoc_Agar_Date = DtpAgar_DilutionD3Innoc_Date.Value;
                            RMMicrobiologytest_Class_Obj.DilutionD3Innoc_Agar_Time = DtpAgar_DilutionD3Innoc_Time.Value.ToLongTimeString();
                        }
                        else
                        {
                            RMMicrobiologytest_Class_Obj.DilutionD3Innoc_Agar_Date = Convert.ToDateTime("1 / 1 / 1900");
                            RMMicrobiologytest_Class_Obj.DilutionD3Innoc_Agar_Time = "";
                        }

                        // Other
                        if (DtpOther_DilutionD3Innoc_Date.Checked == true)
                        {
                            RMMicrobiologytest_Class_Obj.DilutionD3Innoc_Other_Date = DtpOther_DilutionD3Innoc_Date.Value;
                            RMMicrobiologytest_Class_Obj.DilutionD3Innoc_Other_Time = DtpOther_DilutionD3Innoc_Time.Value.ToLongTimeString();
                        }
                        else
                        {
                            RMMicrobiologytest_Class_Obj.DilutionD3Innoc_Other_Date = Convert.ToDateTime("1 / 1 / 1900");
                            RMMicrobiologytest_Class_Obj.DilutionD3Innoc_Other_Time = "";
                        }





                        // Inncub Temp
                        if (txtBroth_Inncub_Temp.Text == "32.5 ± 2.5")
                        {
                            RMMicrobiologytest_Class_Obj.Inccub_Broth_Temp = Convert.ToString(32.5);
                        }
                        else
                        {
                            RMMicrobiologytest_Class_Obj.Inccub_Broth_Temp = txtBroth_Inncub_Temp.Text;
                        }
                        if (txtAgar_Inncub_Temp.Text == "22.5 ± 2.5")
                        {
                            RMMicrobiologytest_Class_Obj.Inccub_Agar_Temp = Convert.ToString(22.5);
                        }
                        else
                        {
                            RMMicrobiologytest_Class_Obj.Inccub_Agar_Temp = txtAgar_Inncub_Temp.Text;
                        }
                        if (txtOther_Inncub_Temp.Text == "22.5 ± 2.5")
                        {
                            RMMicrobiologytest_Class_Obj.Inccub_Other_Temp = Convert.ToString(22.5);
                        }
                        else
                        {
                            RMMicrobiologytest_Class_Obj.Inccub_Other_Temp = txtOther_Inncub_Temp.Text;
                        }

                        // Result Date & Time
                        // Broth
                        if (DtpBroth_Result_Date.Checked == true)
                        {
                            RMMicrobiologytest_Class_Obj.Result_Broth_Date = DtpBroth_Result_Date.Value;
                            RMMicrobiologytest_Class_Obj.Result_Broth_Time = DtpBroth_Result_Time.Value.ToLongTimeString();
                        }
                        else
                        {
                            RMMicrobiologytest_Class_Obj.Result_Broth_Date = Convert.ToDateTime("1 / 1 / 1900");
                            RMMicrobiologytest_Class_Obj.Result_Broth_Time = "";
                        }

                        // Agar
                        if (DtpAgar_Result_Date.Checked == true)
                        {
                            RMMicrobiologytest_Class_Obj.Result_Agar_Date = DtpAgar_Result_Date.Value;
                            RMMicrobiologytest_Class_Obj.Result_Agar_Time = DtpAgar_Result_Time.Value.ToLongTimeString();
                        }
                        else
                        {
                            RMMicrobiologytest_Class_Obj.Result_Agar_Date = Convert.ToDateTime("1 / 1 / 1900");
                            RMMicrobiologytest_Class_Obj.Result_Agar_Time = "";
                        }

                        // Other
                        if (DtpOther_Result_Date.Checked == true)
                        {
                            RMMicrobiologytest_Class_Obj.Result_Other_Date = DtpOther_Result_Date.Value;
                            RMMicrobiologytest_Class_Obj.Result_Other_Time = DtpOther_Result_Time.Value.ToLongTimeString();
                        }
                        else
                        {
                            RMMicrobiologytest_Class_Obj.Result_Other_Date = Convert.ToDateTime("1 / 1 / 1900");
                            RMMicrobiologytest_Class_Obj.Result_Other_Time = "";
                        }

                        // Total Time

                        RMMicrobiologytest_Class_Obj.TotalTime_Broth = txtTotalTime_Broth.Text;
                        RMMicrobiologytest_Class_Obj.TotalTime_Agar = txtTotalTime_Agar.Text;
                        RMMicrobiologytest_Class_Obj.TotalTime_Other = txtTotalTime_Other.Text;

                        // Remarks
                        if (cmbRemarks_Broth.Text != "--Select--")
                        {
                            RMMicrobiologytest_Class_Obj.Remarks_Broth = cmbRemarks_Broth.Text;
                        }
                        else
                        {
                            RMMicrobiologytest_Class_Obj.Remarks_Broth = "";
                        }
                        if (cmbRemarks_Agar.Text != "--Select--")
                        {
                            RMMicrobiologytest_Class_Obj.Remarks_Agar = cmbRemarks_Agar.Text;
                        }
                        else
                        {
                            RMMicrobiologytest_Class_Obj.Remarks_Agar = "";
                        }
                        if (cmbRemarks_Other.Text != "--Select--")
                        {
                            RMMicrobiologytest_Class_Obj.Remarks_Other = cmbRemarks_Other.Text;
                        }
                        else
                        {
                            RMMicrobiologytest_Class_Obj.Remarks_Other = "";
                        }

                        if (RdoAccepted.Checked == true)
                        {
                            RMMicrobiologytest_Class_Obj.Status = Convert.ToChar("A");
                        }
                        else if (RdoRejected.Checked == true)
                        {
                            RMMicrobiologytest_Class_Obj.Status = Convert.ToChar("R");
                        }
                        else if (RdoHold.Checked == true)
                        {
                            RMMicrobiologytest_Class_Obj.Status = Convert.ToChar("H");
                        }
                        else if (RdoAcceptedwithDerrogation.Checked == true)
                        {
                            RMMicrobiologytest_Class_Obj.Status = Convert.ToChar("D");
                        }

                        if (chkSampleToRetainer.Checked == true)
                        {
                            RMMicrobiologytest_Class_Obj.SampleToRetainer = Convert.ToChar("Y");
                        }
                        else if (chkSampleToRetainer.Checked == false)
                        {
                            RMMicrobiologytest_Class_Obj.SampleToRetainer = Convert.ToChar("N");
                        }
                        RMMicrobiologytest_Class_Obj.ClearDate = Convert.ToDateTime(DtpClearDate.Value.ToShortDateString());
                        RMMicrobiologytest_Class_Obj.MediaLotNo = txtMediaLotNo.Text.Trim();
                        RMMicrobiologytest_Class_Obj.MethodName = cmbMethodName.Text.Trim();
                        RMMicrobiologytest_Class_Obj.InspectedBy = Convert.ToInt32(cmbInspectedBy.SelectedValue);
                        RMMicrobiologytest_Class_Obj.micronorm = txtNorms.Text.Trim();
                        RMMicrobiologytest_Class_Obj.LoginID = FrmMain.LoginID;
                        // Insert in tblRMMicrobiologytest OR update if already Exists for RMDetailsID
                        bool b = RMMicrobiologytest_Class_Obj.Insert_tblRMMicrobiologytest();

                    }
                    if (RdoHold.Checked != true)
                    {
                        for (int t = 0; t < DtRMCodeID.Rows.Count; t++)
                        {
                            RMMicrobiologytest_Class_Obj.RMDetailID = Convert.ToInt64(DtRMCodeID.Rows[0]["RMDetailID"]);

                            RMMicrobiologytest_Class_Obj.MicroDone = true;
                            bool a = RMMicrobiologytest_Class_Obj.Update_tblRMDetails_MicroDone();
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

         private void txtBroth_Inncub_Temp_Enter(object sender, EventArgs e)
        {
            txtBroth_Inncub_Temp.Text = Convert.ToString(32);  
        }
        private void txtAgar_Inncub_Temp_Enter(object sender, EventArgs e)
        {
            txtAgar_Inncub_Temp.Text = Convert.ToString(32);
        }

        private void txtOther_Inncub_Temp_Enter(object sender, EventArgs e)
        {
            txtOther_Inncub_Temp.Text = Convert.ToString(25);
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