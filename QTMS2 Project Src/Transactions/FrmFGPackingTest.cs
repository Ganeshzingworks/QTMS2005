/********************************************************
*Author: Vijay Tomake
*Date: 
*Description: Transaction form to enter finished good packing details
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
using System.Configuration;
using System.IO;
using System.Diagnostics;


namespace QTMS.Transactions
{
    public partial class FrmFGPackingTest : Form
    {
        public class Detail
        {
            public long D_fgtlfid;
            public long D_fno;
            public long D_pkgtechno;
            public string D_type;
            public string D_mfgwo;
            public int D_Quantity;
            public string D_pkgstatus;
            public long D_fgno;
            public char Done;
        }

        public FrmFGPackingTest(FrmFGPackingTest.Detail Detail)
        {
            InitializeComponent();
            FinishedGoodTest_Class_Obj.fgtlfid = Detail.D_fgtlfid;
            FinishedGoodTest_Class_Obj.fno = Detail.D_fno;
            FinishedGoodTest_Class_Obj.pkgtechno = Detail.D_pkgtechno;
            FinishedGoodTest_Class_Obj.type = Detail.D_type;
            FinishedGoodTest_Class_Obj.quantity = Detail.D_Quantity;
            FinishedGoodTest_Class_Obj.pkgstatus = Detail.D_pkgstatus;
            FinishedGoodTest_Class_Obj.fgno = Detail.D_fgno;
            Done = Detail.Done;
        }

        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        BusinessFacade.Transactions.FinishedGoodTest_Class FinishedGoodTest_Class_Obj = new BusinessFacade.Transactions.FinishedGoodTest_Class();
        BusinessFacade.UserManagement_Class UserManagement_Class_Obj = new BusinessFacade.UserManagement_Class();
        FGTestMaster_Class FGTestMaster_Class_Obj = null;
        FinishedGoodMaster_Class FinishedGoodMaster_Class_obj = new FinishedGoodMaster_Class();

        char Done;

        /// <summary>
        /// form load method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmFGPackingTest_Load(object sender, EventArgs e)
        {
            Painter.Paint(this);

            Bind_InspectedBy();

            // insert record into tblFinishedGoodTestDetails with status = "";
            // After testing modify the status
            FinishedGoodTest_Class_Obj.status = "";

            DataSet dsPhy = new DataSet();
            dsPhy = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodPackingDetails_FGTLFID();
            if (dsPhy.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(dsPhy.Tables[0].Rows[0]["FGPackingfilepath"]) != "")
                {
                    FinishedGoodTest_Class_Obj.FGPackingfilepath = Convert.ToString(dsPhy.Tables[0].Rows[0]["FGPackingfilepath"]);
                    txtBMR.Text = System.IO.Path.GetFileName(FinishedGoodTest_Class_Obj.FGPackingfilepath);
                }
            }


            DataSet ds1 = new DataSet();
            //Select FGTestNo from FGTLFID
            ds1 = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodDetails_FGTLFID();
            if (ds1.Tables[0].Rows.Count > 0)
            {
                FinishedGoodTest_Class_Obj.fgtestno = Convert.ToInt64(ds1.Tables[0].Rows[0]["FGTestNo"]);                
            }
            else
            {
                //Insert Status = "", ControlType, CurrentFlag=1 into tblFinishedGoodDetails
                FinishedGoodTest_Class_Obj.currentflag = 1;
                FinishedGoodTest_Class_Obj.fgtestno = FinishedGoodTest_Class_Obj.INSERT_FinishedGood_Status();
            }

            //Select status
            if (FinishedGoodTest_Class_Obj.pkgstatus == "A")
            {
                RdoAccepted.Checked = true;
            }
            else if (FinishedGoodTest_Class_Obj.pkgstatus == "R")
            {
                RdoRejected.Checked = true;
            }
            else if (FinishedGoodTest_Class_Obj.pkgstatus == "H")
            {
                RdoHold.Checked = true;
            }
            else
            {
                // RdoAccepted.Checked = true;
            }

            //Display quantity in text box
            if (FinishedGoodTest_Class_Obj.quantity != 0)
            {
                txtQuantity.Text = FinishedGoodTest_Class_Obj.quantity.ToString();
                FillTestGrid();
            }
            else
            {
                txtQuantity.Text = "";
            }
            txtQuantity.Focus();

            DataSet DsScoop = new DataSet();
            DsScoop = FinishedGoodTest_Class_Obj.Select_tblLineMaster_ScoopApplicable();
            if (DsScoop.Tables[0].Rows.Count > 0)
            {
                FinishedGoodTest_Class_Obj.scoopapplicable = Convert.ToBoolean(DsScoop.Tables[0].Rows[0]["ScoopApplicable"]);

            }
        }

        /// <summary>
        /// bind users to combo box
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

        /// <summary>
        /// saves the fg packing details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (txtQuantity.Text == "")
            {
                MessageBox.Show("Please Enter Quantity", "Warning");
                txtQuantity.Focus();
                return;
            }
            for (int col = 4; col < dataGridView.Columns.Count; col++)
            {
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    if (dataGridView[col, i].Value == null || dataGridView[col, i].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Fill all the Reading", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGridView.Focus();
                        return;
                    }
                }
            }
            for (int i = 0; i < dgWA.Rows.Count; i++)
            {
                if (dgWA["WA", i].Value == null || dgWA["WA", i].Value.ToString().Trim() == "")
                {
                    MessageBox.Show("Fill all the WA", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgWA.Focus();
                    return;
                }
            }
            if (RdoAccepted.Checked == false && RdoRejected.Checked == false && RdoHold.Checked == false)
            {
                MessageBox.Show("Select Accept/Reject/Hold option ...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //RdoAccepted.Focus();
                return;
            }
            if (cmbInspectedBy.SelectedValue == null || cmbInspectedBy.Text == "--Select--")
            {
                MessageBox.Show("Please Select Inspected By", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbInspectedBy.Focus();
                return;
            }

            for (int i = 0; i < dgWA.Rows.Count; i++)
            {
                if (dgWA["WA", i].Value.ToString() != "A" && dgWA["WA", i].Value.ToString() != "R")
                {
                    MessageBox.Show("Weighing Analysis is pending ...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RdoAccepted.Focus();
                    return;
                }
            }


            if (FinishedGoodTest_Class_Obj.fgtlfid != 0)
            {
                ///Insert FGTestNo,Quantity,PkgStatus into tblFinishedGoodPackingDetails

                FinishedGoodTest_Class_Obj.quantity = Convert.ToInt32(txtQuantity.Text.Trim());
                if (RdoAccepted.Checked == true)
                {
                    FinishedGoodTest_Class_Obj.pkgstatus = Convert.ToString("A");
                }
                else if (RdoRejected.Checked == true)
                {
                    FinishedGoodTest_Class_Obj.pkgstatus = Convert.ToString("R");
                }
                else if (RdoHold.Checked == true)
                {
                    FinishedGoodTest_Class_Obj.pkgstatus = Convert.ToString("H");
                }
                FinishedGoodTest_Class_Obj.inspectedby = Convert.ToInt32(cmbInspectedBy.SelectedValue);

                FinishedGoodTest_Class_Obj.loginid = FrmMain.LoginID;

                if (txtBMR.Text != "")
                {
                    if (FinishedGoodTest_Class_Obj.FGPackingfilepath == null)
                    {
                        string path = ConfigurationManager.AppSettings["FGPackingfilepath"].ToString();
                        path = path + "\\" + FinishedGoodTest_Class_Obj.filename;

                        if (!File.Exists(path))
                        {
                            //File.Create(path);
                            File.Copy(FinishedGoodTest_Class_Obj.filepath, path);
                        }
                        else
                        {
                            File.Delete(path);
                            File.Copy(FinishedGoodTest_Class_Obj.filepath, path);
                        }

                        FinishedGoodTest_Class_Obj.FGPackingfilepath = path;
                    }
                }



                DataSet ds = new DataSet();
                ds = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodPackingDetails_FGTLFID();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //update the fg packing status
                    //FinishedGoodTest_Class_Obj.fgpackingno = Convert.ToInt64(ds.Tables[0].Rows[0]["FGpackingNo"].ToString());
                    FinishedGoodTest_Class_Obj.fgpackingno = FinishedGoodTest_Class_Obj.Update_tblFinishedGoodPackingDetails();
                }
                else
                {
                    //insert the fg packing status
                    FinishedGoodTest_Class_Obj.fgpackingno = FinishedGoodTest_Class_Obj.Insert_tblFinishedGoodPackingDetails();
                }

                //Delete already added details
                FinishedGoodTest_Class_Obj.Delete_tblFinishedGoodTest_TestMethodDetails_FGPackingNo();

                //SAVE recod in tblFinishedGoodTest_TestMethodDetails
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    //FinishedGoodTest_Class_Obj.pkgtechno = 
                    FinishedGoodTest_Class_Obj.testname = dataGridView["TestMethod", i].Value.ToString();
                    FinishedGoodTest_Class_Obj.inspectionmethod = dataGridView["InspectionMethod", i].Value.ToString();
                    FinishedGoodTest_Class_Obj.frequency = dataGridView["Frequency", i].Value.ToString();
                    //FinishedGoodTest_Class_Obj.type 
                    FinishedGoodTest_Class_Obj.lotsize = dataGridView["LotSize", i].Value.ToString();

                    FinishedGoodTest_Class_Obj.fgmethodno = Convert.ToInt64(dataGridView["FGMethodNo", i].Value.ToString());

                    //if (Done == 'N')
                    //{
                    //    FinishedGoodTest_Class_Obj.fgmethodno = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodDetails_FGMethodNo();
                    //}
                    //else if (Done == 'Y')
                    //{
                    //    FinishedGoodTest_Class_Obj.fgmethodno = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodTestMethodDetails_FGMethodNo();
                    //}
                    //Add standard value to transaction table
                    if (dataGridView["SampleSizeStandard", i].Value.ToString() == "")
                    {
                        FinishedGoodTest_Class_Obj.samplesize = 0;
                    }
                    else
                    {
                        FinishedGoodTest_Class_Obj.samplesize = Convert.ToInt32(dataGridView["SampleSizeStandard", i].Value);
                    }
                    FinishedGoodTest_Class_Obj.aql = dataGridView["AQLStandard", i].Value.ToString();
                    FinishedGoodTest_Class_Obj.aqlz = dataGridView["AQLzStandard", i].Value.ToString();
                    FinishedGoodTest_Class_Obj.aqlc = dataGridView["AQLcStandard", i].Value.ToString();
                    FinishedGoodTest_Class_Obj.aqlm = dataGridView["AQLMStandard", i].Value.ToString();
                    FinishedGoodTest_Class_Obj.aqlm1 = dataGridView["AQLM1Standard", i].Value.ToString();


                    if (dataGridView["SampleSizeReading", i].Value.ToString() == "")
                    {
                        FinishedGoodTest_Class_Obj.samplesizereading = 0;
                    }
                    else
                    {
                        FinishedGoodTest_Class_Obj.samplesizereading = Convert.ToInt32(dataGridView["SampleSizeReading", i].Value);
                    }
                    FinishedGoodTest_Class_Obj.aqlreading = dataGridView["AQLReading", i].Value.ToString();
                    FinishedGoodTest_Class_Obj.aqlzreading = dataGridView["AQLZReading", i].Value.ToString();
                    FinishedGoodTest_Class_Obj.aqlcreading = dataGridView["AQLCReading", i].Value.ToString();
                    FinishedGoodTest_Class_Obj.aqlmreading = dataGridView["AQLMReading", i].Value.ToString();
                    FinishedGoodTest_Class_Obj.aqlm1reading = dataGridView["AQLM1Reading", i].Value.ToString();

                    //inserts the fg packing method details
                    FinishedGoodTest_Class_Obj.Insert_tblFinishedGoodTest_TestMethodDetails();
                }
            }

            if (MessageBox.Show("Test Details saved Successfully..!\n\nPrint Protocol?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
            {
                //display protocol
                btnProtocol_Click(sender, e);
            }

            this.Close();
        }

        /// <summary>
        /// close the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// key press event for quantity text box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                FillTestGrid();
                dataGridView.Focus();
            }
            else if (Convert.ToInt32(e.KeyChar) != 8)
            {
                if ((Convert.ToInt32(e.KeyChar) >= 48) && (Convert.ToInt32(e.KeyChar) <= 57))
                {

                }
                else
                {
                    e.Handled = true;
                }
            }
            else
            {

            }
        }

        /// <summary>
        /// fill the test grid according to quantity lot size
        /// </summary>
        private void FillTestGrid()
        {
            try
            {
                if (txtQuantity.Text == "")
                {
                    MessageBox.Show("Please Enter Quantity", "Warning");
                    txtQuantity.Focus();
                    return;
                }
                else
                {
                    dataGridView.Rows.Clear();


                    if ((Convert.ToInt64(txtQuantity.Text) < 81))
                    {
                        MessageBox.Show("Quantity Less Than 81", "Warning");
                        txtQuantity.Text = "";
                        txtQuantity.Focus();
                        return;
                    }
                    else if ((Convert.ToInt64(txtQuantity.Text) >= 81) && (Convert.ToInt64(txtQuantity.Text) <= 35000))
                    {
                        FinishedGoodTest_Class_Obj.lotsize = "81-35000";
                    }
                    else if ((Convert.ToInt64(txtQuantity.Text) >= 35001) && (Convert.ToInt64(txtQuantity.Text) <= 500000))
                    {
                        FinishedGoodTest_Class_Obj.lotsize = "35001-500000";
                    }
                    else
                    {
                        MessageBox.Show("Quantity greater Than 500000", "Warning");
                        txtQuantity.Text = "";
                        txtQuantity.Focus();
                        return;
                    }


                    DataSet ds = new DataSet();
                    DataSet dsInspMethod = new DataSet();
                    DataSet dsAll = new DataSet();
                    DataTable dt = new DataTable();

                    if (Done == 'N') // if testing not done earlier then display applicable tests 
                    {
                        FinishedGoodMaster_Class_obj.fgno = FinishedGoodTest_Class_Obj.fgno;
                        dt = FinishedGoodMaster_Class_obj.STP_SELECT_tblFGCodeFamilyTestRelation_FGNo();
                        if (dt.Rows.Count > 1)
                        {
                            ds = FinishedGoodTest_Class_Obj.Select_VIEW_FinishedGoodDetails1_TestNo_TestName1();
                        }
                        else
                        {
                            ds = FinishedGoodTest_Class_Obj.Select_VIEW_FinishedGoodDetails_TestNo_TestName();

                        }

                    }

                    else if (Done == 'Y') // if testing done earlier then display the earlier tests and readings
                    {

                        FinishedGoodMaster_Class_obj.fgno = FinishedGoodTest_Class_Obj.fgno;
                        dt = FinishedGoodMaster_Class_obj.STP_SELECT_tblFGCodeFamilyTestRelation_FGNo();
                        if (dt.Rows.Count > 1)
                        {
                            ds = FinishedGoodTest_Class_Obj.Select_VIEW_FinishedGoodDetails1_TestNo_TestName1();
                        }
                        else
                        {
                            ds = FinishedGoodTest_Class_Obj.Select_VIEW_FinishedGoodTestMethodDetails_TestNo_TestName();
                        }
                    }


                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            dataGridView.Rows.Add();

                            //---------Test method---------- 
                            dataGridView["TestMethod", dataGridView.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["Method"];
                            FinishedGoodTest_Class_Obj.testname = dataGridView["TestMethod", dataGridView.Rows.Count - 1].Value.ToString();

                            dataGridView["TestDesc", dataGridView.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestDesc"];

                            //---------Inspection method-----------
                            if (Done == 'N')
                            {
                                dsInspMethod = FinishedGoodTest_Class_Obj.Select_VIEW_FinishedGoodDetails_InspectionMethod();
                            }
                            else if (Done == 'Y')
                            {
                                dsInspMethod = FinishedGoodTest_Class_Obj.Select_VIEW_FinishedGoodTestMethodDetails_InspectionMethod();
                            }

                            DataGridViewComboBoxCell combo = new DataGridViewComboBoxCell();
                            combo.DisplayMember = dsInspMethod.Tables[0].Columns["InspectionMethod"].ToString();
                            for (int row = 0; row < dsInspMethod.Tables[0].Rows.Count; row++)
                            {
                                combo.Items.Add(dsInspMethod.Tables[0].Rows[row]["InspectionMethod"].ToString());

                                //set FGMethodNo as per InspMethod 
                                dataGridView["FGMethodNo", dataGridView.Rows.Count - 1].Value = Convert.ToInt64(dsInspMethod.Tables[0].Rows[row]["FGMethodNo"].ToString());

                            }
                            dataGridView.Rows[i].Cells["InspectionMethod"] = combo;

                            DataSet dsReading;
                            for (int row = 0; row < dsInspMethod.Tables[0].Rows.Count; row++)
                            {
                                dsReading = new DataSet();
                                FinishedGoodTest_Class_Obj.inspectionmethod = dsInspMethod.Tables[0].Rows[row]["InspectionMethod"].ToString();

                                FinishedGoodTest_Class_Obj.fgmethodno = Convert.ToInt64(dsInspMethod.Tables[0].Rows[row]["FGMethodNo"].ToString());

                                //if (Done == 'N')
                                //{
                                //    FinishedGoodTest_Class_Obj.fgmethodno = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodDetails_FGMethodNo();
                                //}
                                //else if (Done == 'Y')
                                //{
                                //    FinishedGoodTest_Class_Obj.fgmethodno = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodTestMethodDetails_FGMethodNo();
                                //}
                                
                                dsReading = FinishedGoodTest_Class_Obj.STP_Select_tblFinishedGoodTest_TestMethodDetails_FGTLFID_FGMethodNo();
                                if (dsReading.Tables[0].Rows.Count > 0)
                                {
                                    //Set selected Text in combobox
                                    combo.Value = FinishedGoodTest_Class_Obj.inspectionmethod;

                                    if (Done == 'N')
                                    {
                                        dsAll = FinishedGoodTest_Class_Obj.Select_VIEW_FinishedGoodDetails_All();
                                    }
                                    else if (Done == 'Y')
                                    {
                                        dsAll = FinishedGoodTest_Class_Obj.Select_VIEW_FinishedGoodTestMethodDetails_All();// Changes in this query for show norms from transaction
                                    }

                                    DisplayDataGridView_All(dsAll, dataGridView.Rows.Count - 1);

                                    if (dsReading.Tables[0].Rows.Count > 0)
                                    {
                                        if (dsReading.Tables[0].Rows[0]["SampleSizeReading"].ToString() == "0")
                                        {
                                            dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["SampleSizeReading"].Value = "";
                                        }
                                        else
                                        {
                                            dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["SampleSizeReading"].Value = dsReading.Tables[0].Rows[0]["SampleSizeReading"].ToString();
                                        }

                                        if (dsReading.Tables[0].Rows[0]["AQLReading"].ToString() != "N/A")
                                        {
                                            dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["AQLReading"].Value = dsReading.Tables[0].Rows[0]["AQLReading"].ToString();
                                        }
                                        else
                                            dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["AQLReading"].Value = "N/A";
                                        if (dsReading.Tables[0].Rows[0]["AQLzReading"].ToString() != "N/A")
                                        {
                                            dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["AQLzReading"].Value = dsReading.Tables[0].Rows[0]["AQLzReading"].ToString();
                                        }
                                        else
                                            dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["AQLzReading"].Value = "N/A";

                                        if (dsReading.Tables[0].Rows[0]["AQLcReading"].ToString() != "N/A")
                                        {
                                            dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["AQLcReading"].Value = dsReading.Tables[0].Rows[0]["AQLcReading"].ToString();
                                        }
                                        else
                                            dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["AQLcReading"].Value = "N/A";
                                        if (dsReading.Tables[0].Rows[0]["AQLMReading"].ToString() != "N/A")
                                        {
                                            dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["AQLMReading"].Value = dsReading.Tables[0].Rows[0]["AQLMReading"].ToString();
                                        }
                                        else
                                            dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["AQLMReading"].Value = "N/A";

                                        if (dsReading.Tables[0].Rows[0]["AQLM1Reading"].ToString() != "N/A")
                                        {
                                            dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["AQLM1Reading"].Value = dsReading.Tables[0].Rows[0]["AQLM1Reading"].ToString();
                                        }
                                        else
                                            dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["AQLM1Reading"].Value = "N/A";
                                    }

                                    break;
                                }
                                else
                                {
                                    //Set selected Text in combobox
                                    combo.Value = dsInspMethod.Tables[0].Rows[row]["InspectionMethod"].ToString();

                                    if (Done == 'N')
                                    {
                                        dsAll = FinishedGoodTest_Class_Obj.Select_VIEW_FinishedGoodDetails_All();
                                    }
                                    else if (Done == 'Y')
                                    {
                                        dsAll = FinishedGoodTest_Class_Obj.Select_VIEW_FinishedGoodTestMethodDetails_All();
                                    }

                                    DisplayDataGridView_All(dsAll, dataGridView.Rows.Count - 1);
                                }

                            }

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        ///  fill the datagridview
        /// </summary>
        /// <param name="dsAll"></param>
        /// <param name="rowIndex"></param>
        private void DisplayDataGridView_All(DataSet dsAll, int rowIndex)
        {

            if (dsAll.Tables[0].Rows.Count > 0)
            {
                dataGridView["FGMethodNo", rowIndex].Value = dsAll.Tables[0].Rows[0]["FGMethodNo"];

                dataGridView["Frequency", rowIndex].Value = dsAll.Tables[0].Rows[0]["frequency"];

                dataGridView["LotSize", rowIndex].Value = dsAll.Tables[0].Rows[0]["lotsize"];

                dataGridView["SampleSizeStandard", rowIndex].Value = dsAll.Tables[0].Rows[0]["samplesize"];

                //Set to blank
                dataGridView["SampleSizeReading", rowIndex].Value = "";

                //dataGridView 5 --> editable for sample size reading                        


                if (Convert.ToString(dsAll.Tables[0].Rows[0]["aql"]) == "")
                {
                    dataGridView["AQLStandard", rowIndex].Value = "N/A";
                    dataGridView["AQLReading", rowIndex].Value = "N/A";

                    dataGridView["AQLReading", rowIndex].ReadOnly = true;
                    dataGridView["AQLReading", rowIndex].Style.BackColor = Color.FromKnownColor(KnownColor.LightGray);
                }
                else
                {
                    dataGridView["AQLStandard", rowIndex].Value = dsAll.Tables[0].Rows[0]["aql"];
                    dataGridView["AQLReading", rowIndex].Value = "";

                    dataGridView["AQLReading", rowIndex].ReadOnly = false;
                    dataGridView["AQLReading", rowIndex].Style.BackColor = Color.White;
                }

                if (Convert.ToString(dsAll.Tables[0].Rows[0]["aqlz"]) == "")
                {
                    dataGridView["AQLzStandard", rowIndex].Value = "N/A";
                    dataGridView["AQLzReading", rowIndex].Value = "N/A";

                    dataGridView["AQLzReading", rowIndex].ReadOnly = true;
                    dataGridView["AQLzReading", rowIndex].Style.BackColor = Color.FromKnownColor(KnownColor.LightGray);
                }
                else
                {
                    dataGridView["AQLzStandard", rowIndex].Value = dsAll.Tables[0].Rows[0]["aqlz"];
                    dataGridView["AQLzReading", rowIndex].Value = "";

                    dataGridView["AQLzReading", rowIndex].ReadOnly = false;
                    dataGridView["AQLzReading", rowIndex].Style.BackColor = Color.White;
                }

                if (Convert.ToString(dsAll.Tables[0].Rows[0]["aqlc"]) == "")
                {
                    dataGridView["AQLcStandard", rowIndex].Value = "N/A";
                    dataGridView["AQLcReading", rowIndex].Value = "N/A";

                    dataGridView["AQLcReading", rowIndex].ReadOnly = true;
                    dataGridView["AQLcReading", rowIndex].Style.BackColor = Color.FromKnownColor(KnownColor.LightGray);
                }
                else
                {
                    dataGridView["AQLcStandard", rowIndex].Value = dsAll.Tables[0].Rows[0]["aqlc"];
                    dataGridView["AQLcReading", rowIndex].Value = "";

                    dataGridView["AQLcReading", rowIndex].ReadOnly = false;
                    dataGridView["AQLcReading", rowIndex].Style.BackColor = Color.White;
                }

                if (Convert.ToString(dsAll.Tables[0].Rows[0]["aqlm"]) == "")
                {
                    dataGridView["AQLMStandard", rowIndex].Value = "N/A";
                    dataGridView["AQLMReading", rowIndex].Value = "N/A";

                    dataGridView["AQLMReading", rowIndex].ReadOnly = true;
                    dataGridView["AQLMReading", rowIndex].Style.BackColor = Color.FromKnownColor(KnownColor.LightGray);
                }
                else
                {
                    dataGridView["AQLMStandard", rowIndex].Value = dsAll.Tables[0].Rows[0]["aqlm"];
                    dataGridView["AQLMReading", rowIndex].Value = "";

                    dataGridView["AQLMReading", rowIndex].ReadOnly = false;
                    dataGridView["AQLMReading", rowIndex].Style.BackColor = Color.White;
                }

                if (Convert.ToString(dsAll.Tables[0].Rows[0]["aqlm1"]) == "")
                {
                    dataGridView["AQLM1Standard", rowIndex].Value = "N/A";
                    dataGridView["AQLM1Reading", rowIndex].Value = "N/A";

                    dataGridView["AQLM1Reading", rowIndex].ReadOnly = true;
                    dataGridView["AQLM1Reading", rowIndex].Style.BackColor = Color.FromKnownColor(KnownColor.LightGray);
                }
                else
                {
                    dataGridView["AQLM1Standard", rowIndex].Value = dsAll.Tables[0].Rows[0]["aqlm1"];
                    dataGridView["AQLM1Reading", rowIndex].Value = "";

                    dataGridView["AQLM1Reading", rowIndex].ReadOnly = false;
                    dataGridView["AQLM1Reading", rowIndex].Style.BackColor = Color.White;
                }

                //----------------- Weighing Analysis ---------------------------------
                
                //bool b = false;
                DataSet dsFGFormula = new DataSet();
                DataSet dsType = new DataSet();
                DataSet dsWADone;
                DataSet dsTrans;
                DataSet dsRL;

                //Check WA Torque/Weight for this test
                FinishedGoodTest_Class_Obj.testno = Convert.ToInt32(dsAll.Tables[0].Rows[0]["TestNo"]);
                //FinishedGoodTest_Class_Obj.type
                dsType = FinishedGoodTest_Class_Obj.Select_tblWAType_TestNo();

                if (dsType.Tables[0].Rows.Count > 0)
                {
                    FinishedGoodTest_Class_Obj.analysistype = dsType.Tables[0].Rows[0]["AnalysisType"].ToString();

                    if (dsAll.Tables[0].Rows[0]["TorqueMin"] is System.DBNull || Convert.ToString(dsAll.Tables[0].Rows[0]["TorqueMin"]) == "")
                    {
                        FinishedGoodTest_Class_Obj.torquemin = "0";
                    }
                    else
                    {
                        FinishedGoodTest_Class_Obj.torquemin = dsAll.Tables[0].Rows[0]["TorqueMin"].ToString();
                    }
                    if (dsAll.Tables[0].Rows[0]["TorqueMax"] is System.DBNull || Convert.ToString(dsAll.Tables[0].Rows[0]["TorqueMax"]) == "")
                    {
                        FinishedGoodTest_Class_Obj.torquemax = "0";
                    }
                    else
                    {
                        FinishedGoodTest_Class_Obj.torquemax = dsAll.Tables[0].Rows[0]["TorqueMax"].ToString();
                    }

                    //Get distinct fgcode, formula and line for this test for this tlfid
                    //FinishedGoodTest_Class_Obj.fgtlfid
                    //FinishedGoodTest_Class_Obj.testno
                    dsFGFormula = FinishedGoodTest_Class_Obj.Select_tblLinkTLF_FGNo_FNo();
                    for (int i = 0; i < dsFGFormula.Tables[0].Rows.Count; i++)
                    {
                        //FinishedGoodTest_Class_Obj.fgtlfid                       
                        FinishedGoodTest_Class_Obj.mtid = Convert.ToInt64(dsFGFormula.Tables[0].Rows[i]["MTID"]);
                        FinishedGoodTest_Class_Obj.fgno = Convert.ToInt64(dsFGFormula.Tables[0].Rows[i]["FGNo"]);
                        FinishedGoodTest_Class_Obj.fno = Convert.ToInt64(dsFGFormula.Tables[0].Rows[i]["FNo"]);
                        FinishedGoodTest_Class_Obj.lno = Convert.ToInt32(dsFGFormula.Tables[0].Rows[i]["LNo"]);


                        //check whether it contains any new launch formula
                        dsRL = new DataSet();
                        dsRL = FinishedGoodTest_Class_Obj.Select_tblBulkTestTransaction_FlagRL();
                        if (dsRL.Tables[0].Rows.Count > 0)
                        {
                            for (int rl = 0; rl < dsRL.Tables[0].Rows.Count; rl++)
                            {
                                if (Convert.ToChar(dsRL.Tables[0].Rows[rl]["FlagRL"]) == 'L')
                                {
                                    FinishedGoodTest_Class_Obj.flagrl = 'L';
                                    break;
                                }
                                else
                                {
                                    FinishedGoodTest_Class_Obj.flagrl = 'R';
                                }
                            }
                        }

                        //insert fgtlfid , fgcode and formula in transaction table
                        dsTrans = new DataSet();
                        dsTrans = FinishedGoodTest_Class_Obj.Select_tblWATrans_FGFormula();
                        if (dsTrans.Tables[0].Rows.Count > 0)
                        {
                            FinishedGoodTest_Class_Obj.watransid = Convert.ToInt64(dsTrans.Tables[0].Rows[0]["WAtransID"]);
                        }
                        else
                        {
                            FinishedGoodTest_Class_Obj.watransid = FinishedGoodTest_Class_Obj.Insert_tblWATrans();
                        }

                        FinishedGoodTest_Class_Obj.reason = ' ';
                        FinishedGoodTest_Class_Obj.wastatus = ' ';

                        //check whether WA already done?
                        dsWADone = new DataSet();
                        dsWADone = FinishedGoodTest_Class_Obj.Select_tblWAStatus_WATransID();
                        if (dsWADone.Tables[0].Rows.Count > 0)
                        {
                            FinishedGoodTest_Class_Obj.reason = Convert.ToChar(dsWADone.Tables[0].Rows[0]["Reason"]);
                            FinishedGoodTest_Class_Obj.wastatus = Convert.ToChar(dsWADone.Tables[0].Rows[0]["Status"]);
                        }
                        else
                        {

                            //Get Top 5 Count after new launch in Bulk 
                            FinishedGoodTest_Class_Obj.count = FinishedGoodTest_Class_Obj.Decide_Top5Count_WA();
                            if (FinishedGoodTest_Class_Obj.count > 0)
                            {
                                FinishedGoodTest_Class_Obj.reason = 'L';
                            }
                            else
                            {
                                //Get Top 20 Count
                                FinishedGoodTest_Class_Obj.count = FinishedGoodTest_Class_Obj.Decide_Top20Count_WA();
                                if (FinishedGoodTest_Class_Obj.count == 20)
                                {
                                    FinishedGoodTest_Class_Obj.reason = 'C';
                                }
                            }
                        }
                        if (FinishedGoodTest_Class_Obj.reason != ' ')
                        {
                            dgWA.Rows.Add();
                            dgWA["WA", dgWA.Rows.Count - 1].Value = FinishedGoodTest_Class_Obj.wastatus;
                            dgWA["Analysis", dgWA.Rows.Count - 1].Value = FinishedGoodTest_Class_Obj.analysistype;
                            dgWA["WATransID", dgWA.Rows.Count - 1].Value = FinishedGoodTest_Class_Obj.watransid;
                            if (FinishedGoodTest_Class_Obj.reason == 'L')
                            {
                                dgWA["Reason", dgWA.Rows.Count - 1].Value = "New Launch";
                            }
                            else if (FinishedGoodTest_Class_Obj.reason == 'C')
                            {
                                dgWA["Reason", dgWA.Rows.Count - 1].Value = "20th Lot";
                            }
                            dgWA["TestNo", dgWA.Rows.Count - 1].Value = Convert.ToInt32(dsFGFormula.Tables[0].Rows[i]["TestNo"]);
                            dgWA["Test", dgWA.Rows.Count - 1].Value = Convert.ToString(dsFGFormula.Tables[0].Rows[i]["Test"]);
                            dgWA["FGNo", dgWA.Rows.Count - 1].Value = Convert.ToInt64(dsFGFormula.Tables[0].Rows[i]["FGNo"]);
                            dgWA["FGCode", dgWA.Rows.Count - 1].Value = Convert.ToString(dsFGFormula.Tables[0].Rows[i]["FGCode"]);
                            dgWA["FNo", dgWA.Rows.Count - 1].Value = Convert.ToInt64(dsFGFormula.Tables[0].Rows[i]["FNo"]);
                            dgWA["FormulaNo", dgWA.Rows.Count - 1].Value = Convert.ToString(dsFGFormula.Tables[0].Rows[i]["FormulaNo"]);
                            dgWA["LNo", dgWA.Rows.Count - 1].Value = Convert.ToInt64(dsFGFormula.Tables[0].Rows[i]["LNo"]);
                            dgWA["LineDesc", dgWA.Rows.Count - 1].Value = Convert.ToString(dsFGFormula.Tables[0].Rows[i]["LineDesc"]);

                            if (FinishedGoodTest_Class_Obj.type == "Normal")
                            {
                                dgWA["ObsCnt", dgWA.Rows.Count - 1].Value = Convert.ToInt32(dsFGFormula.Tables[0].Rows[i]["Normal"]);
                            }
                            else if (FinishedGoodTest_Class_Obj.type == "Reinforce")
                            {
                                dgWA["ObsCnt", dgWA.Rows.Count - 1].Value = Convert.ToInt32(dsFGFormula.Tables[0].Rows[i]["Reinforce"]);
                            }
                        }
                    }
                }
                dataGridView.ClearSelection();
                dgWA.ClearSelection();
            }
        }

        #region "dataGridView_EditingControlShowing"
        ComboBox cmb;
        /// <summary>
        /// edit control showing event of datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            if (dataGridView.CurrentCell.RowIndex < 0
                || (dataGridView.CurrentCell.ColumnIndex != dataGridView.Columns["InspectionMethod"].Index
                     && dataGridView.CurrentCell.ReadOnly == true))
            {
                return;
            }
            else if (dataGridView.CurrentCell.ColumnIndex == dataGridView.Columns["InspectionMethod"].Index)
            {
                cmb = e.Control as ComboBox;
                cmb.Text = e.Control.Text;
                cmb.TextChanged += new EventHandler(cmb_TextChanged);
                return;
            }
            else if (dataGridView.CurrentCell.ReadOnly == false)
            {
                dataGridView.EditingControl.KeyPress += new KeyPressEventHandler(EditingControl_KeyPress);
            }
        }

        #endregion
        /// <summary>
        /// text chnage event of datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void cmb_TextChanged(object sender, EventArgs e)
        {
            if (dataGridView.CurrentCell.RowIndex < 0 || dataGridView.CurrentCell.ColumnIndex != dataGridView.Columns["InspectionMethod"].Index || cmb.Text == "")
            {
                return;
            }
            else
            {

                DataSet dsAll = new DataSet();

                FinishedGoodTest_Class_Obj.inspectionmethod = cmb.Text; //dataGridView.Rows[dataGridView.CurrentCell.RowIndex].Cells["InspectionMethod"].Value.ToString();
                FinishedGoodTest_Class_Obj.testname = dataGridView["TestMethod", dataGridView.CurrentCell.RowIndex].Value.ToString();
                if (Done == 'N')
                {
                    dsAll = FinishedGoodTest_Class_Obj.Select_VIEW_FinishedGoodDetails_All();
                }
                else if (Done == 'Y')
                {
                    dsAll = FinishedGoodTest_Class_Obj.Select_VIEW_FinishedGoodTestMethodDetails_All();
                }

                DisplayDataGridView_All(dsAll, dataGridView.CurrentCell.RowIndex);

                FinishedGoodTest_Class_Obj.frequency = dsAll.Tables[0].Rows[0]["Frequency"].ToString();

                DataSet dsReading = new DataSet();
                //FinishedGoodTest_Class_Obj.pkgtechno
                //FinishedGoodTest_Class_Obj.testname 
                FinishedGoodTest_Class_Obj.inspectionmethod = cmb.Text;
                //FinishedGoodTest_Class_Obj.type
                //FinishedGoodTest_Class_Obj.lotsize
                FinishedGoodTest_Class_Obj.frequency = dsAll.Tables[0].Rows[0]["Frequency"].ToString();

                FinishedGoodTest_Class_Obj.fgmethodno = Convert.ToInt64(dsAll.Tables[0].Rows[0]["FGMethodNo"].ToString());

                //if (Done == 'N')
                //{
                //    FinishedGoodTest_Class_Obj.fgmethodno = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodDetails_FGMethodNo();
                //}
                //else if (Done == 'Y')
                //{
                //    FinishedGoodTest_Class_Obj.fgmethodno = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodTestMethodDetails_FGMethodNo();
                //}

                //FinishedGoodTest_Class_Obj.inspectionmethod

                dsReading = FinishedGoodTest_Class_Obj.STP_Select_tblFinishedGoodTest_TestMethodDetails_FGTLFID_FGMethodNo();

                if (dsReading.Tables[0].Rows.Count > 0)
                {
                    if (dsReading.Tables[0].Rows[0]["SampleSizeReading"].ToString() == "0")
                    {
                        dataGridView.Rows[dataGridView.CurrentCell.RowIndex].Cells["SampleSizeReading"].Value = "";
                    }
                    else
                    {
                        dataGridView.Rows[dataGridView.CurrentCell.RowIndex].Cells["SampleSizeReading"].Value = dsReading.Tables[0].Rows[0]["SampleSizeReading"].ToString();
                    }

                    if (dsReading.Tables[0].Rows[0]["AQLReading"].ToString() != "N/A")
                    {
                        dataGridView.Rows[dataGridView.CurrentCell.RowIndex].Cells["AQLReading"].Value = dsReading.Tables[0].Rows[0]["AQLReading"].ToString();
                    }
                    if (dsReading.Tables[0].Rows[0]["AQLzReading"].ToString() != "N/A")
                    {
                        dataGridView.Rows[dataGridView.CurrentCell.RowIndex].Cells["AQLzReading"].Value = dsReading.Tables[0].Rows[0]["AQLzReading"].ToString();
                    }
                    if (dsReading.Tables[0].Rows[0]["AQLcReading"].ToString() != "N/A")
                    {
                        dataGridView.Rows[dataGridView.CurrentCell.RowIndex].Cells["AQLcReading"].Value = dsReading.Tables[0].Rows[0]["AQLcReading"].ToString();
                    }
                    if (dsReading.Tables[0].Rows[0]["AQLMReading"].ToString() != "N/A")
                    {
                        dataGridView.Rows[dataGridView.CurrentCell.RowIndex].Cells["AQLMReading"].Value = dsReading.Tables[0].Rows[0]["AQLMReading"].ToString();
                    }
                    if (dsReading.Tables[0].Rows[0]["AQLM1Reading"].ToString() != "N/A")
                    {
                        dataGridView.Rows[dataGridView.CurrentCell.RowIndex].Cells["AQLM1Reading"].Value = dsReading.Tables[0].Rows[0]["AQLM1Reading"].ToString();
                    }
                }
            }

        }

        /// <summary>
        /// key press event for integer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// key press event for datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Convert.ToInt32(e.KeyChar) != 8) && (Convert.ToInt32(e.KeyChar) != 46))
            {
                if ((Convert.ToInt32(e.KeyChar) < 48) || (Convert.ToInt32(e.KeyChar) > 57))
                {

                }
                else
                {
                    e.Handled = true;
                }
            }
        }

        /// <summary>
        /// cell validating event for datagridview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //----------- sample size -----------

            if (e.RowIndex < 0 || e.ColumnIndex != dataGridView.Columns["SampleSizeReading"].Index)
            {
                return;
            }
            else
            {

                if (dataGridView.CurrentCell.EditedFormattedValue.ToString() != "")
                {
                    if (Convert.ToInt64(dataGridView.CurrentCell.EditedFormattedValue) < Convert.ToInt64(dataGridView["SampleSizeStandard", dataGridView.CurrentCell.RowIndex].Value))
                    {
                        MessageBox.Show("Sample Size Reading is less than Sample Size Standard", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        e.Cancel = true;

                    }
                }
            }
        }

        /// <summary>
        /// display the protocol
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnProtocol_Click(object sender, EventArgs e)
        {

            string ProtocolNo = "FGP" + FinishedGoodTest_Class_Obj.fgtestno.ToString().PadLeft(6, '0');

            DataSet ds = new DataSet();
            ds = FinishedGoodTest_Class_Obj.Select_View_Protocol_FGPackingDetails();


            DataTable dt = new DataTable();
            dt.Columns.Add("TestMethod");
            dt.Columns.Add("Frequency");
            dt.Columns.Add("InspectionMethod");
            dt.Columns.Add("LotSize");
            dt.Columns.Add("SampleSizeStandard");
            dt.Columns.Add("SampleSizeReading");
            dt.Columns.Add("AQLStandard");
            dt.Columns.Add("AQLReading");
            dt.Columns.Add("AQLzStandard");
            dt.Columns.Add("AQLzReading");
            dt.Columns.Add("AQLcStandard");
            dt.Columns.Add("AQLcReading");
            dt.Columns.Add("AQLMStandard");
            dt.Columns.Add("AQLMReading");
            dt.Columns.Add("AQLM1Standard");
            dt.Columns.Add("AQLM1Reading");

            DataRow dr;
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                dr = dt.NewRow();
                dr["TestMethod"] = dataGridView["TestMethod", i].Value;
                dr["Frequency"] = dataGridView["Frequency", i].Value;
                dr["InspectionMethod"] = dataGridView["InspectionMethod", i].Value;
                dr["LotSize"] = dataGridView["LotSize", i].Value;
                dr["SampleSizeStandard"] = dataGridView["SampleSizeStandard", i].Value;
                dr["SampleSizeReading"] = dataGridView["SampleSizeReading", i].Value;
                dr["AQLStandard"] = dataGridView["AQLStandard", i].Value;
                dr["AQLReading"] = dataGridView["AQLReading", i].Value;
                dr["AQLzStandard"] = dataGridView["AQLzStandard", i].Value;
                dr["AQLzReading"] = dataGridView["AQLzReading", i].Value;
                dr["AQLcStandard"] = dataGridView["AQLcStandard", i].Value;
                dr["AQLcReading"] = dataGridView["AQLcReading", i].Value;
                dr["AQLMStandard"] = dataGridView["AQLMStandard", i].Value;
                dr["AQLMReading"] = dataGridView["AQLMReading", i].Value;
                dr["AQLM1Standard"] = dataGridView["AQLM1Standard", i].Value;
                dr["AQLM1Reading"] = dataGridView["AQLM1Reading", i].Value;
                dt.Rows.InsertAt(dr, i);
            }

            QTMS.Reports_Forms.FrmProtocol_FGPacking fm = new QTMS.Reports_Forms.FrmProtocol_FGPacking("FG Packing Protocol", ds, dt, txtQuantity.Text.Trim(), ProtocolNo, cmbInspectedBy.Text);
            fm.ShowDialog();

        }

        private void dgWA_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgWA.Columns["WA"].Index)
            {
                return;
            }
            else
            {
                FrmWA.Weighing weighing = new FrmWA.Weighing();
                weighing.WA_WATransID = Convert.ToInt64(dgWA["WATransID", e.RowIndex].Value);
                if (dgWA["Reason", e.RowIndex].Value.ToString() == "New Launch")
                {
                    weighing.WA_Reason = 'L';
                }
                else if (dgWA["Reason", e.RowIndex].Value.ToString() == "20th Lot")
                {
                    weighing.WA_Reason = 'C';
                }

                weighing.WA_ObsCnt = Convert.ToInt32(dgWA["ObsCnt", e.RowIndex].Value.ToString());

                weighing.WA_AnalysisType = dgWA["Analysis", e.RowIndex].Value.ToString();
                weighing.WA_TorqueMin = FinishedGoodTest_Class_Obj.torquemin;
                weighing.WA_TorqueMax = FinishedGoodTest_Class_Obj.torquemax;

                weighing.FNo = Convert.ToInt64(dgWA["FNo", e.RowIndex].Value);
                weighing.LNo = Convert.ToInt64(dgWA["LNo", e.RowIndex].Value);
                weighing.FGNo = Convert.ToInt64(dgWA["FGNo", e.RowIndex].Value);
                weighing.FGTLFID = FinishedGoodTest_Class_Obj.fgtlfid;

                FrmWA frm = new FrmWA(weighing);
                frm.ShowDialog();

                DataSet dsWADone = new DataSet();
                FinishedGoodTest_Class_Obj.watransid = Convert.ToInt64(dgWA["WATransID", e.RowIndex].Value);
                dsWADone = FinishedGoodTest_Class_Obj.Select_tblWAStatus_WATransID();
                if (dsWADone.Tables[0].Rows.Count > 0)
                {
                    dgWA["WA", e.RowIndex].Value = dsWADone.Tables[0].Rows[0]["Status"].ToString();
                }
            }
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnbrowse_Click(object sender, EventArgs e)
        {
            string fileName = "", filePath = "";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                FinishedGoodTest_Class_Obj.filepath = openFileDialog1.FileName;
                FinishedGoodTest_Class_Obj.filename = System.IO.Path.GetFileName(FinishedGoodTest_Class_Obj.filepath);
                txtBMR.Text = FinishedGoodTest_Class_Obj.filename;
                FinishedGoodTest_Class_Obj.FGPackingfilepath = null;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (FinishedGoodTest_Class_Obj.FGPackingfilepath == "" || FinishedGoodTest_Class_Obj.FGPackingfilepath == null)
            {
                MessageBox.Show("No file selected to view", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //File.Open(FinishedGoodTest_SubContract_Class_Obj.bmrfilepath,FileMode.Open);
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            process.StartInfo = startInfo;

            startInfo.FileName = FinishedGoodTest_Class_Obj.FGPackingfilepath;
            process.Start();
        }


    }
}