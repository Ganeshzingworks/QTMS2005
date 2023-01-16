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
    public partial class FrmCompatTest : Form
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
        public FrmCompatTest(FrmCompatTest.Detail Detail)
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
        char Done;
        string NormsMin, NormsMax;

        /// <summary>
        /// loads the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmFGPhysicoChemicalTest_Load(object sender, EventArgs e)
        {
            Painter.Paint(this);

            //Changes Form Name
            this.Text = this.Text + "Deformation";
            GetNorms();
            Bind_InspectedBy();  
            ShowTest();
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

        public void GetNorms()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = FinishedGoodTest_Class_Obj.Select_GetNorms_TestNo_FNo_FormulaType();
                foreach (DataRow dr in dt.Rows)
                {
                    NormsMin = Convert.ToString(dr["NormsMin"]);
                    NormsMax = Convert.ToString(dr["NormsMax"]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
                               

                DataSet ds = new DataSet();
                CompatibilityMaster_Class_Obj.formulaNo = this.FNo;
                CompatibilityMaster_Class_Obj.testNo = this.testNo;
                ds = CompatibilityMaster_Class_Obj.Select_CompatibilityTestDetails();
                if(ds.Tables[0].Rows.Count>0)
                    dgObs.AllowUserToAddRows = false;

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    flgRowAdded = true;
                    dgObs.Rows.Add();
                    dgObs["SampleNo", dgObs.Rows.Count - 1].Value = dgObs.Rows.Count;
                    dgObs["Min", dgObs.Rows.Count - 1].Value = NormsMin;
                    dgObs["Max", dgObs.Rows.Count - 1].Value = NormsMax;
                    dgObs["TareWeight", dgObs.Rows.Count - 1].Value = dr["TareWt"];
                    dgObs["Temp", dgObs.Rows.Count - 1].Value = dr["Temp"];
                    dgObs["Days0", dgObs.Rows.Count - 1].Value = dr["Days0"];
                    dgObs["Days7", dgObs.Rows.Count - 1].Value = dr["Days7"];
                    dgObs["Days30", dgObs.Rows.Count - 1].Value = dr["Days30"];
                    dgObs["Days60", dgObs.Rows.Count - 1].Value = dr["Days60"];
                    dgObs["Yrs3", dgObs.Rows.Count - 1].Value = dr["Days3Yrs"];
                    dgObs["Yrs4", dgObs.Rows.Count - 1].Value = dr["Days4Yrs"];
                    
                    dgObs["Loss7Days", dgObs.Rows.Count - 1].Value = Math.Round(Convert.ToDouble((100*((Convert.ToDouble(dr["Days0"])- Convert.ToDouble(dr["Days7"]))/(Convert.ToDouble(dr["Days0"]) - Convert.ToDouble(dr["TareWt"]))))), 2);
                    dgObs["Loss30Days", dgObs.Rows.Count - 1].Value = Math.Round(Convert.ToDouble((100 * ((Convert.ToDouble(dr["Days0"]) - Convert.ToDouble(dr["Days30"])) / (Convert.ToDouble(dr["Days0"]) - Convert.ToDouble(dr["TareWt"]))))), 2);
                    dgObs["Loss60Days", dgObs.Rows.Count - 1].Value = Math.Round(Convert.ToDouble((100 * ((Convert.ToDouble(dr["Days0"]) - Convert.ToDouble(dr["Days60"])) / (Convert.ToDouble(dr["Days0"]) - Convert.ToDouble(dr["TareWt"]))))), 2);
                    dgObs["Loss3Yrs", dgObs.Rows.Count - 1].Value = Math.Round(Convert.ToDouble((100 * ((Convert.ToDouble(dr["Days0"]) - Convert.ToDouble(dr["Days3Yrs"])) / (Convert.ToDouble(dr["Days0"]) - Convert.ToDouble(dr["TareWt"]))))), 2);
                    dgObs["Loss4Yrs", dgObs.Rows.Count - 1].Value = Math.Round(Convert.ToDouble((100 * ((Convert.ToDouble(dr["Days0"]) - Convert.ToDouble(dr["Days4Yrs"])) / (Convert.ToDouble(dr["Days0"]) - Convert.ToDouble(dr["TareWt"]))))), 2);

                    if (Convert.ToString(dr["Status"]).Trim() == "A")
                        RdoAccepted.Checked = true;
                    else
                        RdoRejected.Checked = true;

                    cmbInspectedBy.SelectedValue = dr["InspectedBy"];


                    loss7days += Convert.ToDouble(dgObs["Loss7Days", dgObs.Rows.Count - 1].Value);
                    loss30days += Convert.ToDouble(dgObs["Loss30Days", dgObs.Rows.Count - 1].Value);
                    loss60days += Convert.ToDouble(dgObs["Loss60Days", dgObs.Rows.Count - 1].Value);
                    loss3Yrs += Convert.ToDouble(dgObs["Loss3Yrs", dgObs.Rows.Count - 1].Value);
                    loss4Yrs += Convert.ToDouble(dgObs["Loss4Yrs", dgObs.Rows.Count - 1].Value);
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

                dgObs.AllowUserToAddRows = true;
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
                for (int i = 0; i < dgObs.Rows.Count-1; i++)
                {                   
                    if (dgObs[col, i].Value == null || dgObs[col, i].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Fill all the Test Reading up to 0 Days", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgObs.Focus();
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
            CompatibilityMaster_Class_Obj.testStatus = "T";
            CompatibilityMaster_Class_Obj.formulaNo = this.FNo;
            CompatibilityMaster_Class_Obj.testNo = this.testNo;

            CompatibilityMaster_Class_Obj.Delete_CompatibilityTestDetails();

            for (int i = 0; i < dgObs.Rows.Count-1; i++)
            {
                CompatibilityMaster_Class_Obj.bottleJar = Convert.ToDouble(dgObs["Min", i].Value);
                CompatibilityMaster_Class_Obj.capPlug = Convert.ToDouble(dgObs["Max", i].Value);
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

            MessageBox.Show("Test Details saved Successfully..!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();

        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
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
            try
            {
                if (!flgRowAdded)
                {
                    dgObs["SampleNo", e.RowIndex - 1].Value = dgObs.Rows.Count - 1;
                    dgObs["Min", e.RowIndex - 1].Value = NormsMin;
                    dgObs["Max", e.RowIndex - 1].Value = NormsMax;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }       

        private void dgObs_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgObs.CurrentCell.RowIndex >= 0 && (dgObs.CurrentCell.ReadOnly != true))
            {
                dgObs.EditingControl.KeyPress += new KeyPressEventHandler(EditingControl_KeyPress);
            }
        }

        private void dgObs_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 1)
            {
                return;
            }
            else
            {
                if (dgObs.CurrentCell.EditedFormattedValue.ToString().Trim() != "")
                {
                    //        if (dgObs.CurrentCell.ColumnIndex == dgObs.Columns["BottleJar"].Index || dgObs.CurrentCell.ColumnIndex == dgObs.Columns["CapPlug"].Index)
                    //        {
                    //            if (dgObs["BottleJar", e.RowIndex].Value != null && dgObs["CapPlug", e.RowIndex].Value != null &&
                    //                dgObs["BottleJar", e.RowIndex].Value.ToString() != "" && dgObs["CapPlug", e.RowIndex].Value.ToString() != "")
                    //            {
                    //                dgObs["TareWt", e.RowIndex].Value = Convert.ToDouble(dgObs["BottleJar", e.RowIndex].Value) + Convert.ToDouble(dgObs["CapPlug", e.RowIndex].Value);
                    //                return;
                    //            }
                    //        }
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
            double loss7days = 0 ;
            double loss30days = 0;
            double loss60days = 0;
            double loss3Yrs = 0;
            double loss4Yrs = 0;
            int avgCnt = 0;
            for (int row = 0; row < dgObs.Rows.Count -1; row++)
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

            //for (int col = 0; col < dgObs.Columns.Count; col++)
            //{
            //    if (dgObs.Columns[col].Name.Contains("Loss7Days"))
            //    {
                    

            //    }
            //}
        }

    }
}