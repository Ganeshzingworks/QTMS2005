/********************************************************
*Author: Vijay Tomake
*Date: 
*Description: 
*Revision:
********************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using BusinessFacade;
using System.Globalization;
using System.Threading;
using QTMS.Tools;




namespace QTMS.Transactions
{
    public partial class FrmCompatWeight : Form
    {
        public class Detail
        {
            public int testNo;
            public long FNo;
            public string formulaType;
        }

        public int testNo;
        public long FNo;
        public string formulaType;
        bool flgRowAdded = false;

        public FrmCompatWeight(FrmCompatWeight.Detail Detail)
        {
            InitializeComponent();
            FinishedGoodTest_Class_Obj.testno = Detail.testNo;
            FinishedGoodTest_Class_Obj.fno = Detail.FNo;
            FinishedGoodTest_Class_Obj.formulaType = Detail.formulaType;
            this.FNo = Detail.FNo;
            this.testNo = Detail.testNo;
            this.formulaType = Detail.formulaType;
        }

        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        BusinessFacade.Transactions.FinishedGoodTest_Class FinishedGoodTest_Class_Obj = new BusinessFacade.Transactions.FinishedGoodTest_Class();
        BusinessFacade.CompatibilityMaster_Class CompatibilityMaster_Class_Obj = new BusinessFacade.CompatibilityMaster_Class();
        BusinessFacade.UserManagement_Class UserManagement_Class_Obj = new BusinessFacade.UserManagement_Class();        

        /// <summary>
        /// loads the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmFGPhysicoChemicalTest_Load(object sender, EventArgs e)
        {
            Painter.Paint(this);

            //Changes Form Name
            this.Text = this.Text + "Weight";  

            Bind_InspectedBy();
            ShowTest();
            //cmbPeriod.Text = "--Select--";

            dgAvgLoss["LossSampleNo", 0].Value = "Avg LOSS";
        }
                
        /// <summary>
        /// Binds users to combo box
        /// </summary>
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

        private void ShowTest()
        {
            try
            {
                double loss7days = 0;
                double loss30days = 0;
                double loss60days = 0;
                double loss3Yrs = 0;
                double loss4Yrs = 0;
                int avgCnt = 0;

                double loss7daysD = 0;
                double loss30daysD = 0;
                double loss60daysD = 0;
                double loss3YrsD = 0;
                double loss4YrsD = 0;
                int avgCntD = 0;

                DataSet ds = new DataSet();
                CompatibilityMaster_Class_Obj.formulaNo = this.FNo;
                CompatibilityMaster_Class_Obj.testNo = this.testNo;
                ds = CompatibilityMaster_Class_Obj.Select_CompatibilityTestDetails();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dgObs.AllowUserToAddRows = false;
                    dgDeformation.AllowUserToAddRows = false;
                }
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    flgRowAdded = true;
                    if (Convert.ToString(dr["TestStatus"]).Trim() == "W")
                    {
                        dgObs.Rows.Add();
                        dgObs["SampleNo", dgObs.Rows.Count - 1].Value = dgObs.Rows.Count;                        
                        dgObs["BottleJar", dgObs.Rows.Count - 1].Value = dr["BottleJar"];
                        dgObs["CapPlug", dgObs.Rows.Count - 1].Value = dr["CapPlug"];
                        dgObs["TareWeight", dgObs.Rows.Count - 1].Value = dr["TareWt"];
                        dgObs["Temp", dgObs.Rows.Count - 1].Value = dr["Temp"];
                        dgObs["Days0", dgObs.Rows.Count - 1].Value = dr["Days0"];
                        dgObs["Days7", dgObs.Rows.Count - 1].Value = dr["Days7"];
                        dgObs["Days30", dgObs.Rows.Count - 1].Value = dr["Days30"];
                        dgObs["Days60", dgObs.Rows.Count - 1].Value = dr["Days60"];
                        dgObs["Yrs3", dgObs.Rows.Count - 1].Value = dr["Days3Yrs"];
                        dgObs["Yrs4", dgObs.Rows.Count - 1].Value = dr["Days4Yrs"];

                        dgObs["Loss7Days", dgObs.Rows.Count - 1].Value = Math.Round(Convert.ToDouble((100 * ((Convert.ToDouble(dr["Days0"]) - Convert.ToDouble(dr["Days7"])) / (Convert.ToDouble(dr["Days0"]) - Convert.ToDouble(dr["TareWt"]))))), 2);
                        dgObs["Loss30Days", dgObs.Rows.Count - 1].Value = Math.Round(Convert.ToDouble((100 * ((Convert.ToDouble(dr["Days0"]) - Convert.ToDouble(dr["Days30"])) / (Convert.ToDouble(dr["Days0"]) - Convert.ToDouble(dr["TareWt"]))))), 2);
                        dgObs["Loss60Days", dgObs.Rows.Count - 1].Value = Math.Round(Convert.ToDouble((100 * ((Convert.ToDouble(dr["Days0"]) - Convert.ToDouble(dr["Days60"])) / (Convert.ToDouble(dr["Days0"]) - Convert.ToDouble(dr["TareWt"]))))), 2);
                        dgObs["Loss3Yrs", dgObs.Rows.Count - 1].Value = Math.Round(Convert.ToDouble((100 * ((Convert.ToDouble(dr["Days0"]) - Convert.ToDouble(dr["Days3Yrs"])) / (Convert.ToDouble(dr["Days0"]) - Convert.ToDouble(dr["TareWt"]))))), 2);
                        dgObs["Loss4Yrs", dgObs.Rows.Count - 1].Value = Math.Round(Convert.ToDouble((100 * ((Convert.ToDouble(dr["Days0"]) - Convert.ToDouble(dr["Days4Yrs"])) / (Convert.ToDouble(dr["Days0"]) - Convert.ToDouble(dr["TareWt"]))))), 2);

                        loss7days += Convert.ToDouble(dgObs["Loss7Days", dgObs.Rows.Count - 1].Value);
                        loss30days += Convert.ToDouble(dgObs["Loss30Days", dgObs.Rows.Count - 1].Value);
                        loss60days += Convert.ToDouble(dgObs["Loss60Days", dgObs.Rows.Count - 1].Value);
                        loss3Yrs += Convert.ToDouble(dgObs["Loss3Yrs", dgObs.Rows.Count - 1].Value);
                        loss4Yrs += Convert.ToDouble(dgObs["Loss4Yrs", dgObs.Rows.Count - 1].Value);
                        avgCnt = avgCnt + 1;
                    }
                    else if (Convert.ToString(dr["TestStatus"]).Trim() == "D")
                    {
                        dgDeformation.Rows.Add();
                        dgDeformation["DSampleNo", dgDeformation.Rows.Count - 1].Value = dgDeformation.Rows.Count;
                        //dgDeformation["DMin", dgDeformation.Rows.Count - 1].Value = NormsMin;
                        //dgDeformation["DMax", dgDeformation.Rows.Count - 1].Value = NormsMax;
                        dgDeformation["DBottleJar", dgDeformation.Rows.Count - 1].Value = dr["BottleJar"];
                        dgDeformation["DCapPlug", dgDeformation.Rows.Count - 1].Value = dr["CapPlug"];
                        dgDeformation["DTareWeight", dgDeformation.Rows.Count - 1].Value = dr["TareWt"];
                        dgDeformation["DTemp", dgDeformation.Rows.Count - 1].Value = dr["Temp"];
                        dgDeformation["DDays0", dgDeformation.Rows.Count - 1].Value = dr["Days0"];
                        dgDeformation["DDays7", dgDeformation.Rows.Count - 1].Value = dr["Days7"];
                        dgDeformation["DDays30", dgDeformation.Rows.Count - 1].Value = dr["Days30"];
                        dgDeformation["DDays60", dgDeformation.Rows.Count - 1].Value = dr["Days60"];
                        dgDeformation["DYrs3", dgDeformation.Rows.Count - 1].Value = dr["Days3Yrs"];
                        dgDeformation["DYrs4", dgDeformation.Rows.Count - 1].Value = dr["Days4Yrs"];

                        dgDeformation["DLoss7Days", dgDeformation.Rows.Count - 1].Value = Math.Round(Convert.ToDouble((100 * ((Convert.ToDouble(dr["Days0"]) - Convert.ToDouble(dr["Days7"])) / (Convert.ToDouble(dr["Days0"]) - Convert.ToDouble(dr["TareWt"]))))), 2);
                        dgDeformation["DLoss30Days", dgDeformation.Rows.Count - 1].Value = Math.Round(Convert.ToDouble((100 * ((Convert.ToDouble(dr["Days0"]) - Convert.ToDouble(dr["Days30"])) / (Convert.ToDouble(dr["Days0"]) - Convert.ToDouble(dr["TareWt"]))))), 2);
                        dgDeformation["DLoss60Days", dgDeformation.Rows.Count - 1].Value = Math.Round(Convert.ToDouble((100 * ((Convert.ToDouble(dr["Days0"]) - Convert.ToDouble(dr["Days60"])) / (Convert.ToDouble(dr["Days0"]) - Convert.ToDouble(dr["TareWt"]))))), 2);
                        dgDeformation["DLoss3Yrs", dgDeformation.Rows.Count - 1].Value = Math.Round(Convert.ToDouble((100 * ((Convert.ToDouble(dr["Days0"]) - Convert.ToDouble(dr["Days3Yrs"])) / (Convert.ToDouble(dr["Days0"]) - Convert.ToDouble(dr["TareWt"]))))), 2);
                        dgDeformation["DLoss4Yrs", dgDeformation.Rows.Count - 1].Value = Math.Round(Convert.ToDouble((100 * ((Convert.ToDouble(dr["Days0"]) - Convert.ToDouble(dr["Days4Yrs"])) / (Convert.ToDouble(dr["Days0"]) - Convert.ToDouble(dr["TareWt"]))))), 2);

                        loss7daysD += Convert.ToDouble(dgDeformation["DLoss7Days", dgDeformation.Rows.Count - 1].Value);
                        loss30daysD += Convert.ToDouble(dgDeformation["DLoss30Days", dgDeformation.Rows.Count - 1].Value);
                        loss60daysD += Convert.ToDouble(dgDeformation["DLoss60Days", dgDeformation.Rows.Count - 1].Value);
                        loss3YrsD += Convert.ToDouble(dgDeformation["DLoss3Yrs", dgDeformation.Rows.Count - 1].Value);
                        loss4YrsD += Convert.ToDouble(dgDeformation["DLoss4Yrs", dgDeformation.Rows.Count - 1].Value);
                        avgCntD = avgCntD + 1;
                    }

                    if (avgCnt > 0)
                    {
                        dgAvgLoss["AvgLoss7Days", 0].Value = Convert.ToString(loss7days / avgCnt);
                        dgAvgLoss["AvgLoss30Days", 0].Value = Convert.ToString(loss30days / avgCnt);
                        dgAvgLoss["AvgLoss60Days", 0].Value = Convert.ToString(loss60days / avgCnt);
                        dgAvgLoss["AvgLoss3Yrs", 0].Value = Convert.ToString(loss3Yrs / avgCnt);
                        dgAvgLoss["AvgLoss4Yrs", 0].Value = Convert.ToString(loss4Yrs / avgCnt);
                    }
                    if (avgCntD > 0)
                    {
                        dgDAvgLoss["AvgLoss7Daysd", 0].Value = Convert.ToString(loss7daysD / avgCntD);
                        dgDAvgLoss["AvgLoss30Daysd", 0].Value = Convert.ToString(loss30daysD / avgCntD);
                        dgDAvgLoss["AvgLoss60Daysd", 0].Value = Convert.ToString(loss60daysD / avgCntD);
                        dgDAvgLoss["AvgLoss3Yrsd", 0].Value = Convert.ToString(loss3YrsD / avgCntD);
                        dgDAvgLoss["AvgLoss4Yrsd", 0].Value = Convert.ToString(loss4YrsD / avgCntD);
                    }
                    if (Convert.ToString(dr["Status"]).Trim() == "A")
                        RdoAccepted.Checked = true;
                    else
                        RdoRejected.Checked = true;

                    cmbInspectedBy.SelectedValue = dr["InspectedBy"];                    
                }
                dgObs.AllowUserToAddRows = true;
                dgDeformation.AllowUserToAddRows = true;
                flgRowAdded = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Saves the Method details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            for (int col = 0; col < 6; col++)
            {
                for (int i = 0; i < dgObs.Rows.Count - 1; i++)
                {
                    if (dgObs[col, i].Value == null || dgObs[col, i].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Fill all the Test Reading up to 0 Days", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgObs.Focus();
                        return;
                    }
                }
            }

            for (int col = 0; col < 6; col++)
            {
                for (int i = 0; i < dgDeformation.Rows.Count - 1; i++)
                {
                    if (dgDeformation[col, i].Value == null || dgDeformation[col, i].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Fill all the Test Reading up to 0 Days", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgDeformation.Focus();
                        return;
                    }
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
            if (cmbInspectedBy.SelectedValue == null || cmbInspectedBy.Text == "--Select--")
            {
                MessageBox.Show("Please Select Inspected By", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbInspectedBy.Focus();
                return;
            }

            if (RdoAccepted.Checked == true)
            {
                CompatibilityMaster_Class_Obj.status = Convert.ToString("A");
            }
            else if (RdoRejected.Checked == true)
            {
                CompatibilityMaster_Class_Obj.status = Convert.ToString("R");
            }

            CompatibilityMaster_Class_Obj.inspectedBy = Convert.ToInt32(cmbInspectedBy.SelectedValue);

            CompatibilityMaster_Class_Obj.loginid = FrmMain.LoginID;

            //Status is used for the test is weight, deformation & Other test.If Test is Weight then use Char 'W', Test is Deformation then use Char 'D' & Test is other Test then Use 'T'.
            
            CompatibilityMaster_Class_Obj.formulaNo = this.FNo;
            CompatibilityMaster_Class_Obj.testNo = 0;

            CompatibilityMaster_Class_Obj.Delete_CompatibilityTestDetails();

            for (int i = 0; i < dgObs.Rows.Count - 1; i++)
            {
                CompatibilityMaster_Class_Obj.testStatus = "W";
                CompatibilityMaster_Class_Obj.bottleJar = Convert.ToDouble(dgObs["BottleJar", i].Value);
                CompatibilityMaster_Class_Obj.capPlug = Convert.ToDouble(dgObs["CapPlug", i].Value);
                CompatibilityMaster_Class_Obj.tarewt = Convert.ToDouble(dgObs["TareWeight", i].Value);
                CompatibilityMaster_Class_Obj.temp = Convert.ToString(dgObs["Temp", i].Value);
                CompatibilityMaster_Class_Obj.days0 = Convert.ToDouble(dgObs["Days0", i].Value);
                CompatibilityMaster_Class_Obj.days7 = Convert.ToDouble(dgObs["Days7", i].Value);
                CompatibilityMaster_Class_Obj.days30 = Convert.ToDouble(dgObs["Days30", i].Value);
                CompatibilityMaster_Class_Obj.days60 = Convert.ToDouble(dgObs["Days60", i].Value);
                CompatibilityMaster_Class_Obj.yrs3 = Convert.ToDouble(dgObs["Yrs3", i].Value);
                CompatibilityMaster_Class_Obj.yrs4 = Convert.ToDouble(dgObs["Yrs4", i].Value);


                bool flag = CompatibilityMaster_Class_Obj.Insert_CompatibilityTestDetails();
            }
            for (int i = 0; i < dgDeformation.Rows.Count - 1; i++)
            {
                CompatibilityMaster_Class_Obj.testStatus = "D";
                CompatibilityMaster_Class_Obj.bottleJar = Convert.ToDouble(dgDeformation["DBottleJar", i].Value);
                CompatibilityMaster_Class_Obj.capPlug = Convert.ToDouble(dgDeformation["DCapPlug", i].Value);
                CompatibilityMaster_Class_Obj.tarewt = Convert.ToDouble(dgDeformation["DTareWeight", i].Value);
                CompatibilityMaster_Class_Obj.temp = Convert.ToString(dgDeformation["DTemp", i].Value);
                CompatibilityMaster_Class_Obj.days0 = Convert.ToDouble(dgDeformation["DDays0", i].Value);
                CompatibilityMaster_Class_Obj.days7 = Convert.ToDouble(dgDeformation["DDays7", i].Value);
                CompatibilityMaster_Class_Obj.days30 = Convert.ToDouble(dgDeformation["DDays30", i].Value);
                CompatibilityMaster_Class_Obj.days60 = Convert.ToDouble(dgDeformation["DDays60", i].Value);
                CompatibilityMaster_Class_Obj.yrs3 = Convert.ToDouble(dgDeformation["DYrs3", i].Value);
                CompatibilityMaster_Class_Obj.yrs4 = Convert.ToDouble(dgDeformation["DYrs4", i].Value);


                bool flag = CompatibilityMaster_Class_Obj.Insert_CompatibilityTestDetails();
            }
            MessageBox.Show("Test Details saved Successfully..!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();

        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgTest_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgObs.CurrentCell.RowIndex >= 0 && (dgObs.CurrentCell.ReadOnly != true))
            {
                dgObs.EditingControl.KeyPress += new KeyPressEventHandler(EditingControl_KeyPress);
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
      

        private void dgObs_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (!flgRowAdded)
            {
                dgObs["SampleNo", e.RowIndex - 1].Value = dgObs.Rows.Count - 1;
            }
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgDeformation_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (!flgRowAdded)
            {
                //dgDeformation["DSampleNo", e.RowIndex - 1].Value = dgDeformation.Rows.Count - 1;
            }
        }

        private void dgDeformation_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 1)
            {
                return;
            }
            else
            {
                if (dgDeformation.CurrentCell.EditedFormattedValue.ToString().Trim() != "")
                {
                    //        if (dgDeformation.CurrentCell.ColumnIndex == dgDeformation.Columns["BottleJar"].Index || dgDeformation.CurrentCell.ColumnIndex == dgDeformation.Columns["CapPlug"].Index)
                    //        {
                    //            if (dgDeformation["BottleJar", e.RowIndex].Value != null && dgDeformation["CapPlug", e.RowIndex].Value != null &&
                    //                dgDeformation["BottleJar", e.RowIndex].Value.ToString() != "" && dgDeformation["CapPlug", e.RowIndex].Value.ToString() != "")
                    //            {
                    //                dgDeformation["TareWt", e.RowIndex].Value = Convert.ToDouble(dgDeformation["BottleJar", e.RowIndex].Value) + Convert.ToDouble(dgDeformation["CapPlug", e.RowIndex].Value);
                    //                return;
                    //            }
                    //        }
                    // 7 days Loss
                    if (dgDeformation.Columns.Contains("DDays0") && dgDeformation.Columns.Contains("DDays7"))
                    {
                        if (dgDeformation.CurrentCell.ColumnIndex == dgDeformation.Columns["DDays0"].Index || dgDeformation.CurrentCell.ColumnIndex == dgDeformation.Columns["DDays7"].Index)
                        {
                            if ( dgDeformation["DDays0", e.RowIndex].Value != null && dgDeformation["DDays7", e.RowIndex].Value != null &&
                                  dgDeformation["DDays0", e.RowIndex].Value.ToString() != "" && dgDeformation["DDays7", e.RowIndex].Value.ToString() != "")
                            {
                                dgDeformation["DLoss7Days", e.RowIndex].Value =
                                    100
                                    * ((Convert.ToDouble(dgDeformation["DDays7", e.RowIndex].Value) - Convert.ToDouble(dgDeformation["DDays0", e.RowIndex].Value))
                                        / (Convert.ToDouble(dgDeformation["DDays0", e.RowIndex].Value) )
                                      );
                                dgDeformation["DLoss7Days", e.RowIndex].Value = Math.Round(Convert.ToDouble(dgDeformation["DLoss7Days", e.RowIndex].Value), 2);
                                return;
                            }
                        }
                    }
                    // 30 days
                    if (dgDeformation.Columns.Contains("DDays0") && dgDeformation.Columns.Contains("DDays30"))
                    {
                        if (dgDeformation.CurrentCell.ColumnIndex == dgDeformation.Columns["DDays0"].Index || dgDeformation.CurrentCell.ColumnIndex == dgDeformation.Columns["DDays30"].Index)
                        {
                            if ( dgDeformation["DDays0", e.RowIndex].Value != null && dgDeformation["DDays30", e.RowIndex].Value != null &&
                                 dgDeformation["DDays0", e.RowIndex].Value.ToString() != "" && dgDeformation["DDays30", e.RowIndex].Value.ToString() != "")
                            {
                                dgDeformation["DLoss30Days", e.RowIndex].Value =
                                    100
                                    * (( Convert.ToDouble(dgDeformation["DDays30", e.RowIndex].Value) - Convert.ToDouble(dgDeformation["DDays0", e.RowIndex].Value))
                                        / (Convert.ToDouble(dgDeformation["DDays0", e.RowIndex].Value) )
                                      );
                                dgDeformation["DLoss30Days", e.RowIndex].Value = Math.Round(Convert.ToDouble(dgDeformation["DLoss30Days", e.RowIndex].Value), 2);
                                return;
                            }
                        }
                    }
                    // 60 days
                    if (dgDeformation.Columns.Contains("DDays0") && dgDeformation.Columns.Contains("DDays60"))
                    {
                        if (dgDeformation.CurrentCell.ColumnIndex == dgDeformation.Columns["DDays0"].Index || dgDeformation.CurrentCell.ColumnIndex == dgDeformation.Columns["DDays60"].Index)
                        {
                            if ( dgDeformation["DDays0", e.RowIndex].Value != null && dgDeformation["DDays60", e.RowIndex].Value != null &&
                                 dgDeformation["DDays0", e.RowIndex].Value.ToString() != "" && dgDeformation["DDays60", e.RowIndex].Value.ToString() != "")
                            {
                                dgDeformation["DLoss60Days", e.RowIndex].Value =
                                    100
                                    * ((Convert.ToDouble(dgDeformation["DDays60", e.RowIndex].Value) - Convert.ToDouble(dgDeformation["DDays0", e.RowIndex].Value))
                                        / (Convert.ToDouble(dgDeformation["DDays0", e.RowIndex].Value) )
                                      );
                                dgDeformation["DLoss60Days", e.RowIndex].Value = Math.Round(Convert.ToDouble(dgDeformation["DLoss60Days", e.RowIndex].Value), 2);
                                return;
                            }
                        }
                    }
                    // 3 yrs
                    if (dgDeformation.Columns.Contains("DDays0") && dgDeformation.Columns.Contains("DYrs3"))
                    {
                        if (dgDeformation.CurrentCell.ColumnIndex == dgDeformation.Columns["DDays0"].Index || dgDeformation.CurrentCell.ColumnIndex == dgDeformation.Columns["DYrs3"].Index)
                        {
                            if ( dgDeformation["DDays0", e.RowIndex].Value != null && dgDeformation["DYrs3", e.RowIndex].Value != null &&
                                 dgDeformation["DDays0", e.RowIndex].Value.ToString() != "" && dgDeformation["DYrs3", e.RowIndex].Value.ToString() != "")
                            {
                                dgDeformation["DLoss3Yrs", e.RowIndex].Value =
                                    100
                                    * ((Convert.ToDouble(dgDeformation["DYrs3", e.RowIndex].Value) - Convert.ToDouble(dgDeformation["DDays0", e.RowIndex].Value))
                                        / (Convert.ToDouble(dgDeformation["DDays0", e.RowIndex].Value) )
                                      );
                                dgDeformation["DLoss3Yrs", e.RowIndex].Value = Math.Round(Convert.ToDouble(dgDeformation["DLoss3Yrs", e.RowIndex].Value), 2);
                                return;
                            }
                        }
                    }
                    // 4 yrs
                    if (dgDeformation.Columns.Contains("DDays0") && dgDeformation.Columns.Contains("DYrs4"))
                    {
                        if (dgDeformation.CurrentCell.ColumnIndex == dgDeformation.Columns["DDays0"].Index || dgDeformation.CurrentCell.ColumnIndex == dgDeformation.Columns["DYrs4"].Index)
                        {
                            if ( dgDeformation["DDays0", e.RowIndex].Value != null && dgDeformation["DYrs4", e.RowIndex].Value != null &&
                                 dgDeformation["DDays0", e.RowIndex].Value.ToString() != "" && dgDeformation["DYrs4", e.RowIndex].Value.ToString() != "")
                            {
                                dgDeformation["DLoss4Yrs", e.RowIndex].Value =
                                    100
                                    * ((Convert.ToDouble(dgDeformation["DYrs4", e.RowIndex].Value) - Convert.ToDouble(dgDeformation["DDays0", e.RowIndex].Value))
                                        / (Convert.ToDouble(dgDeformation["DDays0", e.RowIndex].Value))
                                      );
                                dgDeformation["DLoss4Yrs", e.RowIndex].Value = Math.Round(Convert.ToDouble(dgDeformation["DLoss4Yrs", e.RowIndex].Value), 2);
                                return;
                            }
                        }
                    }
                }
            }
        }

        private void dgDeformation_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgDeformation.CurrentCell.RowIndex >= 0 && (dgDeformation.CurrentCell.ReadOnly != true))
            {
                dgDeformation.EditingControl.KeyPress += new KeyPressEventHandler(EditingControl_KeyPress);
            }
        }

        private void dgObs_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 1 || dgObs.Columns[e.ColumnIndex].ReadOnly == true)
            {
                return;
            }
            else
            {
                if (dgObs.CurrentCell.EditedFormattedValue.ToString().Trim() != "")//No value entered
                {
                    if (dgObs.CurrentCell.ColumnIndex == dgObs.Columns["BottleJar"].Index || dgObs.CurrentCell.ColumnIndex == dgObs.Columns["CapPlug"].Index)
                    {
                        if (dgObs["BottleJar", e.RowIndex].Value != null && dgObs["CapPlug", e.RowIndex].Value != null &&
                            dgObs["BottleJar", e.RowIndex].Value.ToString() != "" && dgObs["CapPlug", e.RowIndex].Value.ToString() != "")
                        {
                            dgObs["TareWeight", e.RowIndex].Value = Convert.ToDouble(dgObs["BottleJar", e.RowIndex].Value) + Convert.ToDouble(dgObs["CapPlug", e.RowIndex].Value);
                            return;
                        }
                    }
                    //else
                    //{
                    //    return;
                    //}
                    // 7 days Loss

                    if (dgObs.Columns.Contains("Days0") && dgObs.Columns.Contains("Days7"))
                    {
                        if (dgObs.CurrentCell.ColumnIndex == dgObs.Columns["Days0"].Index || dgObs.CurrentCell.ColumnIndex == dgObs.Columns["Days7"].Index)
                        {
                            if (dgObs["TareWeight", e.RowIndex].Value != null && dgObs["Days0", e.RowIndex].Value != null && dgObs["Days7", e.RowIndex].Value != null &&
                                dgObs["TareWeight", e.RowIndex].Value.ToString() != "" && dgObs["Days0", e.RowIndex].Value.ToString() != "" && dgObs["Days7", e.RowIndex].Value.ToString() != "")
                            {
                                dgObs["Loss7Days", e.RowIndex].Value =
                                    100
                                    * ((Convert.ToDouble(dgObs["Days0", e.RowIndex].Value) - Convert.ToDouble(dgObs["Days7", e.RowIndex].Value))
                                        / (Convert.ToDouble(dgObs["Days0", e.RowIndex].Value) - Convert.ToDouble(dgObs["TareWeight", e.RowIndex].Value))
                                      );
                                dgObs["Loss7Days", e.RowIndex].Value = Math.Round(Convert.ToDouble(dgObs["Loss7Days", e.RowIndex].Value), 2);
                                return;
                            }
                        }
                    }
                    // 30 days
                    if (dgObs.Columns.Contains("Days0") && dgObs.Columns.Contains("Days30"))
                    {
                        if (dgObs.CurrentCell.ColumnIndex == dgObs.Columns["Days0"].Index || dgObs.CurrentCell.ColumnIndex == dgObs.Columns["Days30"].Index)
                        {
                            if (dgObs["TareWeight", e.RowIndex].Value != null && dgObs["Days0", e.RowIndex].Value != null && dgObs["Days30", e.RowIndex].Value != null &&
                                dgObs["TareWeight", e.RowIndex].Value.ToString() != "" && dgObs["Days0", e.RowIndex].Value.ToString() != "" && dgObs["Days30", e.RowIndex].Value.ToString() != "")
                            {
                                dgObs["Loss30Days", e.RowIndex].Value =
                                    100
                                    * ((Convert.ToDouble(dgObs["Days0", e.RowIndex].Value) - Convert.ToDouble(dgObs["Days30", e.RowIndex].Value))
                                        / (Convert.ToDouble(dgObs["Days0", e.RowIndex].Value) - Convert.ToDouble(dgObs["TareWeight", e.RowIndex].Value))
                                      );
                                dgObs["Loss30Days", e.RowIndex].Value = Math.Round(Convert.ToDouble(dgObs["Loss30Days", e.RowIndex].Value), 2);
                                return;
                            }
                        }
                    }
                    // 60 days
                    if (dgObs.Columns.Contains("Days0") && dgObs.Columns.Contains("Days60"))
                    {
                        if (dgObs.CurrentCell.ColumnIndex == dgObs.Columns["Days0"].Index || dgObs.CurrentCell.ColumnIndex == dgObs.Columns["Days60"].Index)
                        {
                            if (dgObs["TareWeight", e.RowIndex].Value != null && dgObs["Days0", e.RowIndex].Value != null && dgObs["Days60", e.RowIndex].Value != null &&
                                dgObs["TareWeight", e.RowIndex].Value.ToString() != "" && dgObs["Days0", e.RowIndex].Value.ToString() != "" && dgObs["Days60", e.RowIndex].Value.ToString() != "")
                            {
                                dgObs["Loss60Days", e.RowIndex].Value =
                                    100
                                    * ((Convert.ToDouble(dgObs["Days0", e.RowIndex].Value) - Convert.ToDouble(dgObs["Days60", e.RowIndex].Value))
                                        / (Convert.ToDouble(dgObs["Days0", e.RowIndex].Value) - Convert.ToDouble(dgObs["TareWeight", e.RowIndex].Value))
                                      );
                                dgObs["Loss60Days", e.RowIndex].Value = Math.Round(Convert.ToDouble(dgObs["Loss60Days", e.RowIndex].Value), 2);
                                return;
                            }
                        }
                    }
                    // 3 yrs
                    if (dgObs.Columns.Contains("Days0") && dgObs.Columns.Contains("Yrs3"))
                    {
                        if (dgObs.CurrentCell.ColumnIndex == dgObs.Columns["Days0"].Index || dgObs.CurrentCell.ColumnIndex == dgObs.Columns["Yrs3"].Index)
                        {
                            if (dgObs["TareWeight", e.RowIndex].Value != null && dgObs["Days0", e.RowIndex].Value != null && dgObs["Yrs3", e.RowIndex].Value != null &&
                                dgObs["TareWeight", e.RowIndex].Value.ToString() != "" && dgObs["Days0", e.RowIndex].Value.ToString() != "" && dgObs["Yrs3", e.RowIndex].Value.ToString() != "")
                            {
                                dgObs["Loss3Yrs", e.RowIndex].Value =
                                    100
                                    * ((Convert.ToDouble(dgObs["Days0", e.RowIndex].Value) - Convert.ToDouble(dgObs["Yrs3", e.RowIndex].Value))
                                        / (Convert.ToDouble(dgObs["Days0", e.RowIndex].Value) - Convert.ToDouble(dgObs["TareWeight", e.RowIndex].Value))
                                      );
                                dgObs["Loss3Yrs", e.RowIndex].Value = Math.Round(Convert.ToDouble(dgObs["Loss3Yrs", e.RowIndex].Value), 2);
                                return;
                            }
                        }
                    }
                    // 4 yrs
                    if (dgObs.Columns.Contains("Days0") && dgObs.Columns.Contains("Yrs4"))
                    {
                        if (dgObs.CurrentCell.ColumnIndex == dgObs.Columns["Days0"].Index || dgObs.CurrentCell.ColumnIndex == dgObs.Columns["Yrs4"].Index)
                        {
                            if (dgObs["TareWeight", e.RowIndex].Value != null && dgObs["Days0", e.RowIndex].Value != null && dgObs["Yrs4", e.RowIndex].Value != null &&
                                dgObs["TareWeight", e.RowIndex].Value.ToString() != "" && dgObs["Days0", e.RowIndex].Value.ToString() != "" && dgObs["Yrs4", e.RowIndex].Value.ToString() != "")
                            {
                                dgObs["Loss4Yrs", e.RowIndex].Value =
                                    100
                                    * ((Convert.ToDouble(dgObs["Days0", e.RowIndex].Value) - Convert.ToDouble(dgObs["Yrs4", e.RowIndex].Value))
                                        / (Convert.ToDouble(dgObs["Days0", e.RowIndex].Value) - Convert.ToDouble(dgObs["TareWeight", e.RowIndex].Value))
                                      );
                                dgObs["Loss4Yrs", e.RowIndex].Value = Math.Round(Convert.ToDouble(dgObs["Loss4Yrs", e.RowIndex].Value), 2);
                                return;
                            }
                        }
                    }
                }
            }
           
        }

        private void dgObs_Leave(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                CompatibilityMaster_Class_Obj.formulaNo = this.FNo;
                CompatibilityMaster_Class_Obj.testNo = this.testNo;
                ds = CompatibilityMaster_Class_Obj.Select_CompatibilityTestDetails();
                if (ds.Tables[0].Rows.Count <= 0)
                {
                    dgDeformation.Rows.Clear();
                }
                
                dgDeformation.AllowUserToAddRows = false;
                for (int i = 0; i < dgObs.Rows.Count; i++)
                {
                    if (dgObs.Rows[i].IsNewRow)
                    {
                        if (Convert.ToString(dgObs["BottleJar", i-1].Value) != "")
                        {
                            dgDeformation.Rows.Add();
                            dgDeformation["DSampleNo", dgDeformation.Rows.Count - 1].Value = dgObs["SampleNo", i - 1].Value;
                            dgDeformation["DBottleJar", dgDeformation.Rows.Count - 1].Value = dgObs["BottleJar", i - 1].Value;
                            dgDeformation["DCapPlug", dgDeformation.Rows.Count - 1].Value = dgObs["CapPlug", i - 1].Value;
                            dgDeformation["DTareWeight", dgDeformation.Rows.Count - 1].Value = dgObs["TareWeight", i - 1].Value;
                            dgDeformation["DTemp", dgDeformation.Rows.Count - 1].Value = dgObs["Temp", i - 1].Value;
                        }
                    }
                }

                double loss7days = 0;
                double loss30days = 0;
                double loss60days = 0;
                double loss3Yrs = 0;
                double loss4Yrs = 0;
                int avgCnt = 0;
                for (int row = 0; row < dgObs.Rows.Count - 1; row++)
                {
                    loss7days += Convert.ToDouble(dgObs["Loss7Days", row].Value);
                    loss30days += Convert.ToDouble(dgObs["Loss30Days", row].Value);
                    loss60days += Convert.ToDouble(dgObs["Loss60Days", row].Value);
                    loss3Yrs += Convert.ToDouble(dgObs["Loss3Yrs", row].Value);
                    loss4Yrs += Convert.ToDouble(dgObs["Loss4Yrs", row].Value);
                    avgCnt = avgCnt + 1;
                }
                if (avgCnt > 0)
                {
                    dgAvgLoss["AvgLoss7Days", 0].Value = Convert.ToString(loss7days / avgCnt);
                    dgAvgLoss["AvgLoss30Days", 0].Value = Convert.ToString(loss30days / avgCnt);
                    dgAvgLoss["AvgLoss60Days", 0].Value = Convert.ToString(loss60days / avgCnt);
                    dgAvgLoss["AvgLoss3Yrs", 0].Value = Convert.ToString(loss3Yrs / avgCnt);
                    dgAvgLoss["AvgLoss4Yrs", 0].Value = Convert.ToString(loss4Yrs / avgCnt);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }

        private void dgDeformation_Leave(object sender, EventArgs e)
        {
            double loss7daysD = 0;
            double loss30daysD = 0;
            double loss60daysD = 0;
            double loss3YrsD = 0;
            double loss4YrsD = 0;
            int avgCntD = 0;
            for (int row = 0; row < dgDAvgLoss.Rows.Count-1; row++)
            {
                loss7daysD += Convert.ToDouble(dgDAvgLoss["Loss7Daysd", row].Value);
                loss30daysD += Convert.ToDouble(dgDAvgLoss["Loss30Daysd", row].Value);
                loss60daysD += Convert.ToDouble(dgDAvgLoss["Loss60Daysd", row].Value);
                loss3YrsD += Convert.ToDouble(dgDAvgLoss["Loss3Yrsd", row].Value);
                loss4YrsD += Convert.ToDouble(dgDAvgLoss["Loss4Yrsd", row].Value);
                avgCntD = avgCntD + 1;
            }
            if (avgCntD > 0)
            {
                dgDAvgLoss["AvgLoss7Daysd", 0].Value = Convert.ToString(loss7daysD / avgCntD);
                dgDAvgLoss["AvgLoss30Daysd", 0].Value = Convert.ToString(loss30daysD / avgCntD);
                dgDAvgLoss["AvgLoss60Daysd", 0].Value = Convert.ToString(loss60daysD / avgCntD);
                dgDAvgLoss["AvgLoss3Yrsd", 0].Value = Convert.ToString(loss3YrsD / avgCntD);
                dgDAvgLoss["AvgLoss4Yrsd", 0].Value = Convert.ToString(loss4YrsD / avgCntD);
            }
        }
       

    }
}