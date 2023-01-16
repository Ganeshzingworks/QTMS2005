/********************************************************
*Author: Avinash S
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
    public partial class FrmFGPackingTest_SubContract : Form
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
            public string D_Supplier;
            public string D_FGCode;
            public string D_FormulaNo;
            public string D_COC;
            public long D_SupploerID;
            public long D_InspctedBy;
            public char D_flagrl;
            public bool D_Packing;
        }

        public FrmFGPackingTest_SubContract(FrmFGPackingTest_SubContract.Detail Detail)
        {
            InitializeComponent();

            FinishedGoodTest_Class_Obj.fgtlfid = Detail.D_fgtlfid;
            FinishedGoodTest_Class_Obj.fno = Detail.D_fno;
            FinishedGoodTest_Class_Obj.pkgtechno = Detail.D_pkgtechno;
            FinishedGoodTest_Class_Obj.type = Detail.D_type;
            FinishedGoodTest_Class_Obj.quantity = Detail.D_Quantity;
            FinishedGoodTest_Class_Obj.pkgstatus = Detail.D_pkgstatus;
            FinishedGoodTest_Class_Obj.fgno = Detail.D_fgno;

            FinishedGoodTest_SubContract_Class_Obj.fgtlfid = Detail.D_fgtlfid;
            FinishedGoodTest_SubContract_Class_Obj.fno = Detail.D_fno;
            FinishedGoodTest_SubContract_Class_Obj.pkgtechno = Detail.D_pkgtechno;
            FinishedGoodTest_SubContract_Class_Obj.type = Detail.D_type;
            FinishedGoodTest_SubContract_Class_Obj.quantity = Detail.D_Quantity;
            FinishedGoodTest_SubContract_Class_Obj.pkgstatus = Detail.D_pkgstatus;
            FinishedGoodTest_SubContract_Class_Obj.fgno = Detail.D_fgno;
            FinishedGoodTest_SubContract_Class_Obj.supplier = Detail.D_Supplier;
            FinishedGoodTest_SubContract_Class_Obj.fgcode = Detail.D_FGCode;
            FinishedGoodTest_SubContract_Class_Obj.formulano = Detail.D_FormulaNo;
            FinishedGoodTest_SubContract_Class_Obj.FGSupplierID = Detail.D_SupploerID;
            FinishedGoodTest_SubContract_Class_Obj.coc = Detail.D_COC;
            FinishedGoodTest_SubContract_Class_Obj.quantity = Detail.D_Quantity;
            FinishedGoodTest_SubContract_Class_Obj.inspectedby = Detail.D_InspctedBy;
            FinishedGoodTest_SubContract_Class_Obj.flagrl = Detail.D_flagrl;
            FinishedGoodTest_SubContract_Class_Obj.packing = Detail.D_Packing;

            Done = Detail.Done;
        }

        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        BusinessFacade.Transactions.FinishedGoodTest_Class FinishedGoodTest_Class_Obj = new BusinessFacade.Transactions.FinishedGoodTest_Class();
        BusinessFacade.UserManagement_Class UserManagement_Class_Obj = new BusinessFacade.UserManagement_Class();
        FGTestMaster_Class FGTestMaster_Class_Obj = null;
        FinishedGoodMaster_Class FinishedGoodMaster_Class_obj = new FinishedGoodMaster_Class();

        BusinessFacade.SubContractor_Class.FinishedGoodTest_SubContract_Class FinishedGoodTest_SubContract_Class_Obj =
            new BusinessFacade.SubContractor_Class.FinishedGoodTest_SubContract_Class();

        char Done;

        Boolean ChkFlagFirst = false;

        private void FrmFGPackingTest_SubContract_Load(object sender, EventArgs e)
        {
            Painter.Paint(this);

            Bind_InspectedBy();

            // insert record into tblFinishedGoodTestDetails with status = "";
            // After testing modify the status
            FinishedGoodTest_SubContract_Class_Obj.status = "";


            DataSet dsPhy = new DataSet();
            dsPhy = FinishedGoodTest_SubContract_Class_Obj.Select_tblFinishedGoodPackingDetails_FGTLFID_SubContract();
            if (dsPhy.Tables[0].Rows.Count > 0)
            {
                if (Convert.ToString(dsPhy.Tables[0].Rows[0]["FGPackingfilepath"]) != "")
                {
                    FinishedGoodTest_SubContract_Class_Obj.FGPackingfilepath = Convert.ToString(dsPhy.Tables[0].Rows[0]["FGPackingfilepath"]);
                    txtBMR.Text = System.IO.Path.GetFileName(FinishedGoodTest_SubContract_Class_Obj.FGPackingfilepath);
                }
            }



            DataSet ds1 = new DataSet();
            //Select FGTestNo from FGTLFID
            ds1 = FinishedGoodTest_SubContract_Class_Obj.Select_tblFinishedGoodDetails_FGTLFID_SubContract();
            if (ds1.Tables[0].Rows.Count > 0)
            {
                FinishedGoodTest_Class_Obj.fgtestno = Convert.ToInt64(ds1.Tables[0].Rows[0]["FGTestNo"]);
                FinishedGoodTest_SubContract_Class_Obj.fgtestno = Convert.ToInt64(ds1.Tables[0].Rows[0]["FGTestNo"]);
            }
            else
            {
                //Insert Status = "", ControlType, CurrentFlag=1 into tblFinishedGoodDetails
                //FinishedGoodTest_Class_Obj.currentflag = 1;
                //FinishedGoodTest_Class_Obj.fgtestno = FinishedGoodTest_Class_Obj.INSERT_FinishedGood_Status();   

                FinishedGoodTest_SubContract_Class_Obj.currentflag = 1;
                FinishedGoodTest_SubContract_Class_Obj.fgtestno = FinishedGoodTest_SubContract_Class_Obj.INSERT_FinishedGood_Status_SubContract();
            }
            if (FinishedGoodTest_SubContract_Class_Obj.quantity != 0)
            {
                ChkFlagFirst = true;
                //Select status
                if (FinishedGoodTest_SubContract_Class_Obj.pkgstatus == "A")
                {
                    RdoAccepted.Checked = true;
                }
                else if (FinishedGoodTest_SubContract_Class_Obj.pkgstatus == "R")
                {
                    RdoRejected.Checked = true;
                }
                else if (FinishedGoodTest_SubContract_Class_Obj.pkgstatus == "H")
                {
                    RdoHold.Checked = true;
                }

                cmbInspectedBy.SelectedValue = FinishedGoodTest_SubContract_Class_Obj.inspectedby;

                txtQuantity.Text = FinishedGoodTest_SubContract_Class_Obj.quantity.ToString();
                //txtQuantity.ReadOnly = true;

                FillGrid_Loreal_Return();
                FillGrid_Supplier_Return();
            }


            /*
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

                        }*/
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
            if (txtQuantity.Text == "")
            {
                MessageBox.Show("Please Enter Quantity", "Warning");
                txtQuantity.Focus();
                return;
            }
            #region this code for pune
            if (GlobalVariables.City.ToUpper() != "BADDI")
            {
                if (FinishedGoodTest_SubContract_Class_Obj.coc == "Yes")
                {
                    if (FinishedGoodTest_SubContract_Class_Obj.packing == true)
                    {
                        for (int col = 4; col < dataGridView1.Columns.Count; col++)
                        {
                            for (int i = 0; i < dataGridView1.Rows.Count; i++)
                            {
                                if (dataGridView1[col, i].Value == null || dataGridView1[col, i].Value.ToString().Trim() == "")
                                {
                                    MessageBox.Show("Fill all the Supplier Result", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    dataGridView.Focus();
                                    return;
                                }
                            }
                        }
                    }
                }
                else
                {
                    for (int col = 4; col < dataGridView.Columns.Count; col++)
                    {
                        for (int i = 0; i < dataGridView.Rows.Count; i++)
                        {
                            if (dataGridView[col, i].Value == null || dataGridView[col, i].Value.ToString().Trim() == "")
                            {
                                MessageBox.Show("Fill all the L'oreal Result", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                dataGridView.Focus();
                                return;
                            }
                        }
                    }
                }
            }
            #endregion
            #region this code for Baddi
            if (GlobalVariables.City.ToUpper() == "BADDI")
            {
                if (FinishedGoodTest_SubContract_Class_Obj.packing == true)
                {
                    for (int col = 4; col < dataGridView1.Columns.Count; col++)
                    {
                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            if (dataGridView1[col, i].Value == null || dataGridView1[col, i].Value.ToString().Trim() == "")
                            {
                                MessageBox.Show("Fill all the Supplier Result", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                dataGridView.Focus();
                                return;
                            }
                        }
                    }
                }
            }
            #endregion
            /*for (int i = 0; i < dgWA.Rows.Count; i++)
            {
                if (dgWA["WA",i].Value == null || dgWA["WA", i].Value.ToString().Trim() == "")
                {
                    MessageBox.Show("Fill all the WA", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgWA.Focus();
                    return;
                }
            }*/
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
            /*
            for (int i = 0; i < dgWA.Rows.Count; i++)
            {
                if (dgWA["WA", i].Value.ToString() != "A" && dgWA["WA", i].Value.ToString() != "R")
                {
                    MessageBox.Show("Weighing Analysis is pending ...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RdoAccepted.Focus();
                    return;
                }
            }                    
            */

            if (FinishedGoodTest_SubContract_Class_Obj.fgtlfid != 0)
            {
                ///Insert FGTestNo,Quantity,PkgStatus into tblFinishedGoodPackingDetails

                FinishedGoodTest_SubContract_Class_Obj.quantity = Convert.ToInt32(txtQuantity.Text.Trim());
                if (RdoAccepted.Checked == true)
                {
                    FinishedGoodTest_SubContract_Class_Obj.pkgstatus = Convert.ToString("A");
                }
                else if (RdoRejected.Checked == true)
                {
                    FinishedGoodTest_SubContract_Class_Obj.pkgstatus = Convert.ToString("R");
                }
                else if (RdoHold.Checked == true)
                {
                    FinishedGoodTest_SubContract_Class_Obj.pkgstatus = Convert.ToString("H");
                }
                FinishedGoodTest_SubContract_Class_Obj.inspectedby = Convert.ToInt32(cmbInspectedBy.SelectedValue);

                FinishedGoodTest_SubContract_Class_Obj.loginid = FrmMain.LoginID;


                if (txtBMR.Text != "")
                {
                    if (FinishedGoodTest_SubContract_Class_Obj.FGPackingfilepath == null)
                    {
                        string path = ConfigurationManager.AppSettings["FGPackingfilepath_Subcontractor"].ToString();
                        path = path + "\\" + FinishedGoodTest_SubContract_Class_Obj.filename;

                        if (!File.Exists(path))
                        {
                            //File.Create(path);
                            File.Copy(FinishedGoodTest_SubContract_Class_Obj.filepath, path);
                        }
                        else
                        {
                            File.Delete(path);
                            File.Copy(FinishedGoodTest_SubContract_Class_Obj.filepath, path);
                        }

                        FinishedGoodTest_SubContract_Class_Obj.FGPackingfilepath = path;
                    }
                }



                DataSet ds = new DataSet();
                ds = FinishedGoodTest_SubContract_Class_Obj.Select_tblFinishedGoodPackingDetails_FGTLFID_SubContract();//Rember Changes when got fgtlfid
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //update the fg packing status
                    //FinishedGoodTest_Class_Obj.fgpackingno = Convert.ToInt64(ds.Tables[0].Rows[0]["FGpackingNo"].ToString());
                    //FinishedGoodTest_Class_Obj.fgpackingno = FinishedGoodTest_Class_Obj.Update_tblFinishedGoodPackingDetails();
                    FinishedGoodTest_SubContract_Class_Obj.fgpackingno = FinishedGoodTest_SubContract_Class_Obj.Update_tblFinishedGoodPackingDetails_SubContract();
                }
                else
                {
                    //insert the fg packing status
                    //FinishedGoodTest_Class_Obj.fgpackingno = FinishedGoodTest_Class_Obj.Insert_tblFinishedGoodPackingDetails();
                    FinishedGoodTest_SubContract_Class_Obj.fgpackingno = FinishedGoodTest_SubContract_Class_Obj.Insert_tblFinishedGoodPackingDetails_SubContract();
                }

                //Delete already added details
                //FinishedGoodTest_Class_Obj.Delete_tblFinishedGoodTest_TestMethodDetails_FGPackingNo();
                FinishedGoodTest_SubContract_Class_Obj.Delete_tblFinishedGoodTest_TestMethodDetails_FGPackingNo_SubContract();

                //SAVE recod in tblFinishedGoodTest_TestMethodDetails
                for (int i = 0; i < dataGridView.Rows.Count; i++)
                {
                    //FinishedGoodTest_Class_Obj.pkgtechno = 
                    FinishedGoodTest_SubContract_Class_Obj.testname = dataGridView["TestMethod", i].Value.ToString();
                    FinishedGoodTest_SubContract_Class_Obj.inspectionmethod = dataGridView["InspectionMethod", i].Value.ToString();
                    FinishedGoodTest_SubContract_Class_Obj.frequency = dataGridView["Frequency", i].Value.ToString();
                    //FinishedGoodTest_Class_Obj.type 
                    FinishedGoodTest_SubContract_Class_Obj.lotsize = dataGridView["LotSize", i].Value.ToString();

                    //FinishedGoodTest_Class_Obj.fgmethodno = Convert.ToInt64(dataGridView["FGMethodNo", i].Value.ToString());
                    FinishedGoodTest_SubContract_Class_Obj.fgmethodno = Convert.ToInt64(dataGridView["FGMethodNo", i].Value.ToString());

                    //if (Done == 'N')
                    //{
                    //    FinishedGoodTest_Class_Obj.fgmethodno = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodDetails_FGMethodNo();
                    //}
                    //else if (Done == 'Y')
                    //{
                    //    FinishedGoodTest_Class_Obj.fgmethodno = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodTestMethodDetails_FGMethodNo();
                    //}
                    //Add standard value to transaction table
                    if (dataGridView["SampleSizeStandard", i].Value.ToString() == "" || dataGridView["SampleSizeStandard", i].Value == null)
                    {
                        //FinishedGoodTest_Class_Obj.samplesize = 0;
                        FinishedGoodTest_SubContract_Class_Obj.samplesize = 0;
                    }
                    else
                    {
                        //FinishedGoodTest_Class_Obj.samplesize = Convert.ToInt32(dataGridView["SampleSizeStandard", i].Value);
                        FinishedGoodTest_SubContract_Class_Obj.samplesize = Convert.ToInt32(dataGridView["SampleSizeStandard", i].Value);
                    }
                    /* FinishedGoodTest_Class_Obj.aql = dataGridView["AQLStandard", i].Value.ToString();
                     FinishedGoodTest_Class_Obj.aqlz = dataGridView["AQLzStandard", i].Value.ToString();
                     FinishedGoodTest_Class_Obj.aqlc = dataGridView["AQLcStandard", i].Value.ToString();
                     FinishedGoodTest_Class_Obj.aqlm = dataGridView["AQLMStandard", i].Value.ToString();
                     FinishedGoodTest_Class_Obj.aqlm1 = dataGridView["AQLM1Standard", i].Value.ToString();
                     */

                    FinishedGoodTest_SubContract_Class_Obj.aql = dataGridView["AQLStandard", i].Value.ToString();
                    FinishedGoodTest_SubContract_Class_Obj.aqlz = dataGridView["AQLzStandard", i].Value.ToString();
                    FinishedGoodTest_SubContract_Class_Obj.aqlc = dataGridView["AQLcStandard", i].Value.ToString();
                    FinishedGoodTest_SubContract_Class_Obj.aqlm = dataGridView["AQLMStandard", i].Value.ToString();
                    FinishedGoodTest_SubContract_Class_Obj.aqlm1 = dataGridView["AQLM1Standard", i].Value.ToString();

                    if (dataGridView["SampleSizeReading", i].Value.ToString() == "" || dataGridView["SampleSizeReading", i].Value == null)
                    {
                        //FinishedGoodTest_Class_Obj.samplesizereading = 0;
                        FinishedGoodTest_SubContract_Class_Obj.samplesizereading = 0;
                    }
                    else
                    {
                        //FinishedGoodTest_Class_Obj.samplesizereading = Convert.ToInt32(dataGridView["SampleSizeReading", i].Value);
                        FinishedGoodTest_SubContract_Class_Obj.samplesizereading = Convert.ToInt32(dataGridView["SampleSizeReading", i].Value);
                    }
                    /* FinishedGoodTest_Class_Obj.aqlreading = dataGridView["AQLReading", i].Value.ToString();
                     FinishedGoodTest_Class_Obj.aqlzreading = dataGridView["AQLZReading", i].Value.ToString();
                     FinishedGoodTest_Class_Obj.aqlcreading = dataGridView["AQLCReading", i].Value.ToString();
                     FinishedGoodTest_Class_Obj.aqlmreading = dataGridView["AQLMReading", i].Value.ToString();
                     FinishedGoodTest_Class_Obj.aqlm1reading = dataGridView["AQLM1Reading", i].Value.ToString();
                     */

                    FinishedGoodTest_SubContract_Class_Obj.aqlreading = dataGridView["AQLReading", i].Value.ToString();
                    FinishedGoodTest_SubContract_Class_Obj.aqlzreading = dataGridView["AQLZReading", i].Value.ToString();
                    FinishedGoodTest_SubContract_Class_Obj.aqlcreading = dataGridView["AQLCReading", i].Value.ToString();
                    FinishedGoodTest_SubContract_Class_Obj.aqlmreading = dataGridView["AQLMReading", i].Value.ToString();
                    FinishedGoodTest_SubContract_Class_Obj.aqlm1reading = dataGridView["AQLM1Reading", i].Value.ToString();

                    FinishedGoodTest_SubContract_Class_Obj.result = "";
                    //inserts the fg packing method details
                    //FinishedGoodTest_Class_Obj.Insert_tblFinishedGoodTest_TestMethodDetails();
                    FinishedGoodTest_SubContract_Class_Obj.Insert_tblFinishedGoodTest_TestMethodDetails_SubContract();
                }
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    //FinishedGoodTest_Class_Obj.pkgtechno = 
                    FinishedGoodTest_SubContract_Class_Obj.testname = dataGridView1["TestMethod1", i].Value.ToString();
                    FinishedGoodTest_SubContract_Class_Obj.inspectionmethod = dataGridView1["InspectionMethod1", i].Value.ToString();
                    FinishedGoodTest_SubContract_Class_Obj.frequency = dataGridView1["Frequency1", i].Value.ToString();
                    //FinishedGoodTest_Class_Obj.type 
                    FinishedGoodTest_SubContract_Class_Obj.lotsize = dataGridView1["LotSize1", i].Value.ToString();

                    //FinishedGoodTest_Class_Obj.fgmethodno = Convert.ToInt64(dataGridView["FGMethodNo", i].Value.ToString());
                    FinishedGoodTest_SubContract_Class_Obj.fgmethodno = Convert.ToInt64(dataGridView1["FGMethodNo1", i].Value.ToString());

                    //if (Done == 'N')
                    //{
                    //    FinishedGoodTest_Class_Obj.fgmethodno = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodDetails_FGMethodNo();
                    //}
                    //else if (Done == 'Y')
                    //{
                    //    FinishedGoodTest_Class_Obj.fgmethodno = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodTestMethodDetails_FGMethodNo();
                    //}
                    //Add standard value to transaction table
                    if (dataGridView1["SampleSizeStandard1", i].Value.ToString() == "" || dataGridView1["SampleSizeStandard1", i].Value == null)
                    {
                        //FinishedGoodTest_Class_Obj.samplesize = 0;
                        FinishedGoodTest_SubContract_Class_Obj.samplesize = 0;
                    }
                    else
                    {
                        //FinishedGoodTest_Class_Obj.samplesize = Convert.ToInt32(dataGridView["SampleSizeStandard", i].Value);
                        FinishedGoodTest_SubContract_Class_Obj.samplesize = Convert.ToInt32(dataGridView1["SampleSizeStandard1", i].Value);
                    }
                    /* FinishedGoodTest_Class_Obj.aql = dataGridView["AQLStandard", i].Value.ToString();
                     FinishedGoodTest_Class_Obj.aqlz = dataGridView["AQLzStandard", i].Value.ToString();
                     FinishedGoodTest_Class_Obj.aqlc = dataGridView["AQLcStandard", i].Value.ToString();
                     FinishedGoodTest_Class_Obj.aqlm = dataGridView["AQLMStandard", i].Value.ToString();
                     FinishedGoodTest_Class_Obj.aqlm1 = dataGridView["AQLM1Standard", i].Value.ToString();
                     */

                    FinishedGoodTest_SubContract_Class_Obj.aql = dataGridView1["AQLStandard1", i].Value.ToString();
                    FinishedGoodTest_SubContract_Class_Obj.aqlz = dataGridView1["AQLzStandard1", i].Value.ToString();
                    FinishedGoodTest_SubContract_Class_Obj.aqlc = dataGridView1["AQLcStandard1", i].Value.ToString();
                    FinishedGoodTest_SubContract_Class_Obj.aqlm = dataGridView1["AQLMStandard1", i].Value.ToString();
                    FinishedGoodTest_SubContract_Class_Obj.aqlm1 = dataGridView1["AQLM1Standard1", i].Value.ToString();

                    if (dataGridView1["SampleSizeReading1", i].Value.ToString() == "" || dataGridView1["SampleSizeReading1", i].Value == null)
                    {
                        //FinishedGoodTest_Class_Obj.samplesizereading = 0;
                        FinishedGoodTest_SubContract_Class_Obj.samplesizereading = 0;
                    }
                    else
                    {
                        //FinishedGoodTest_Class_Obj.samplesizereading = Convert.ToInt32(dataGridView["SampleSizeReading", i].Value);
                        FinishedGoodTest_SubContract_Class_Obj.samplesizereading = Convert.ToInt32(dataGridView1["SampleSizeReading1", i].Value);
                    }
                    /* FinishedGoodTest_Class_Obj.aqlreading = dataGridView["AQLReading", i].Value.ToString();
                     FinishedGoodTest_Class_Obj.aqlzreading = dataGridView["AQLZReading", i].Value.ToString();
                     FinishedGoodTest_Class_Obj.aqlcreading = dataGridView["AQLCReading", i].Value.ToString();
                     FinishedGoodTest_Class_Obj.aqlmreading = dataGridView["AQLMReading", i].Value.ToString();
                     FinishedGoodTest_Class_Obj.aqlm1reading = dataGridView["AQLM1Reading", i].Value.ToString();
                     */

                    FinishedGoodTest_SubContract_Class_Obj.aqlreading = dataGridView1["AQLReading1", i].Value.ToString();
                    FinishedGoodTest_SubContract_Class_Obj.aqlzreading = dataGridView1["AQLZReading1", i].Value.ToString();
                    FinishedGoodTest_SubContract_Class_Obj.aqlcreading = dataGridView1["AQLCReading1", i].Value.ToString();
                    FinishedGoodTest_SubContract_Class_Obj.aqlmreading = dataGridView1["AQLMReading1", i].Value.ToString();
                    FinishedGoodTest_SubContract_Class_Obj.aqlm1reading = dataGridView1["AQLM1Reading1", i].Value.ToString();

                    FinishedGoodTest_SubContract_Class_Obj.result = "Supplier";
                    //inserts the fg packing method details
                    //FinishedGoodTest_Class_Obj.Insert_tblFinishedGoodTest_TestMethodDetails();
                    FinishedGoodTest_SubContract_Class_Obj.Insert_tblFinishedGoodTest_TestMethodDetails_SubContract();
                }
            }

            if (MessageBox.Show("Test Details saved Successfully..!\n\nPrint Protocol?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
            {
                //display protocol
                btnProtocol_Click(sender, e);
            }

            this.Close();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                dgWA.Rows.Clear();

                if (ChkFlagFirst == false)
                    FillTestGrid();
                else
                {
                    FillGrid_Loreal_Return();
                    FillGrid_Supplier_Return();
                }
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
                    dataGridView1.Rows.Clear();

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
                        FinishedGoodTest_SubContract_Class_Obj.lotsize = "81-35000";
                    }
                    else if ((Convert.ToInt64(txtQuantity.Text) >= 35001) && (Convert.ToInt64(txtQuantity.Text) <= 500000))
                    {
                        FinishedGoodTest_Class_Obj.lotsize = "35001-500000";
                        FinishedGoodTest_SubContract_Class_Obj.lotsize = "35001-500000";
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
                        FinishedGoodMaster_Class_obj.fgno = FinishedGoodTest_SubContract_Class_Obj.fgno;
                        dt = FinishedGoodMaster_Class_obj.STP_SELECT_tblFGCodeFamilyTestRelation_FGNo();
                        if (dt.Rows.Count > 1)
                        {
                            //ds = FinishedGoodTest_Class_Obj.Select_VIEW_FinishedGoodDetails1_TestNo_TestName1();
                            ds = FinishedGoodTest_SubContract_Class_Obj.Select_VIEW_FinishedGoodDetails1_TestNo_TestName1_SubContract();
                        }
                        else
                        {
                            //ds = FinishedGoodTest_Class_Obj.Select_VIEW_FinishedGoodDetails_TestNo_TestName();
                            ds = FinishedGoodTest_SubContract_Class_Obj.Select_VIEW_FinishedGoodDetails_TestNo_TestName_SubContract();

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
                            dataGridView1.Rows.Add();
                            //---------Test method---------- 
                            dataGridView["TestMethod", dataGridView.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["Method"];
                            dataGridView1["TestMethod1", dataGridView1.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["Method"];
                            FinishedGoodTest_Class_Obj.testname = dataGridView["TestMethod", dataGridView.Rows.Count - 1].Value.ToString();

                            dataGridView["TestDesc", dataGridView.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestDesc"];
                            dataGridView1["TestDesc1", dataGridView1.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestDesc"];
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

                            DataGridViewComboBoxCell combo1 = new DataGridViewComboBoxCell();
                            combo1.DisplayMember = dsInspMethod.Tables[0].Columns["InspectionMethod"].ToString();

                            for (int row = 0; row < dsInspMethod.Tables[0].Rows.Count; row++)
                            {
                                combo.Items.Add(dsInspMethod.Tables[0].Rows[row]["InspectionMethod"].ToString());
                                combo1.Items.Add(dsInspMethod.Tables[0].Rows[row]["InspectionMethod"].ToString());

                                //set FGMethodNo as per InspMethod 
                                dataGridView["FGMethodNo", dataGridView.Rows.Count - 1].Value = Convert.ToInt64(dsInspMethod.Tables[0].Rows[row]["FGMethodNo"].ToString());
                                dataGridView1["FGMethodNo1", dataGridView1.Rows.Count - 1].Value = Convert.ToInt64(dsInspMethod.Tables[0].Rows[row]["FGMethodNo"].ToString());

                            }
                            dataGridView.Rows[i].Cells["InspectionMethod"] = combo;
                            dataGridView1.Rows[i].Cells["InspectionMethod1"] = combo1;

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
                                    combo1.Value = FinishedGoodTest_Class_Obj.inspectionmethod;

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
                                            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["SampleSizeReading1"].Value = "";
                                        }
                                        else
                                        {
                                            dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["SampleSizeReading"].Value = dsReading.Tables[0].Rows[0]["SampleSizeReading"].ToString();
                                            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["SampleSizeReading1"].Value = dsReading.Tables[0].Rows[0]["SampleSizeReading"].ToString();
                                        }

                                        if (dsReading.Tables[0].Rows[0]["AQLReading"].ToString() != "N/A")
                                        {
                                            dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["AQLReading"].Value = dsReading.Tables[0].Rows[0]["AQLReading"].ToString();
                                            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["AQLReading1"].Value = dsReading.Tables[0].Rows[0]["AQLReading"].ToString();
                                        }
                                        else
                                        {
                                            dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["AQLReading"].Value = "N/A";
                                            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["AQLReading1"].Value = "N/A";
                                        }
                                        if (dsReading.Tables[0].Rows[0]["AQLzReading"].ToString() != "N/A")
                                        {
                                            dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["AQLzReading"].Value = dsReading.Tables[0].Rows[0]["AQLzReading"].ToString();
                                            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["AQLzReading1"].Value = dsReading.Tables[0].Rows[0]["AQLzReading"].ToString();
                                        }
                                        else
                                        {
                                            dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["AQLzReading"].Value = "N/A";
                                            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["AQLzReading1"].Value = "N/A";
                                        }

                                        if (dsReading.Tables[0].Rows[0]["AQLcReading"].ToString() != "N/A")
                                        {
                                            dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["AQLcReading"].Value = dsReading.Tables[0].Rows[0]["AQLcReading"].ToString();
                                            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["AQLcReading1"].Value = dsReading.Tables[0].Rows[0]["AQLcReading"].ToString();
                                        }
                                        else
                                        {
                                            dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["AQLcReading"].Value = "N/A";
                                            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["AQLcReading1"].Value = "N/A";
                                        }
                                        if (dsReading.Tables[0].Rows[0]["AQLMReading"].ToString() != "N/A")
                                        {
                                            dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["AQLMReading"].Value = dsReading.Tables[0].Rows[0]["AQLMReading"].ToString();
                                            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["AQLMReading1"].Value = dsReading.Tables[0].Rows[0]["AQLMReading"].ToString();
                                        }
                                        else
                                        {
                                            dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["AQLMReading"].Value = "N/A";
                                            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["AQLMReading1"].Value = "N/A";
                                        }
                                        if (dsReading.Tables[0].Rows[0]["AQLM1Reading"].ToString() != "N/A")
                                        {
                                            dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["AQLM1Reading"].Value = dsReading.Tables[0].Rows[0]["AQLM1Reading"].ToString();
                                            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["AQLM1Reading1"].Value = dsReading.Tables[0].Rows[0]["AQLM1Reading"].ToString();
                                        }
                                        else
                                        {
                                            dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["AQLM1Reading"].Value = "N/A";
                                            dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["AQLM1Reading1"].Value = "N/A";
                                        }
                                    }

                                    break;
                                }
                                else
                                {
                                    //Set selected Text in combobox
                                    combo.Value = dsInspMethod.Tables[0].Rows[row]["InspectionMethod"].ToString();
                                    combo1.Value = dsInspMethod.Tables[0].Rows[row]["InspectionMethod"].ToString();

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

        private void DisplayDataGridView_All(DataSet dsAll, int rowIndex)
        {

            if (dsAll.Tables[0].Rows.Count > 0)
            {
                dataGridView["FGMethodNo", rowIndex].Value = dsAll.Tables[0].Rows[0]["FGMethodNo"];
                dataGridView1["FGMethodNo1", rowIndex].Value = dsAll.Tables[0].Rows[0]["FGMethodNo"];

                dataGridView["Frequency", rowIndex].Value = dsAll.Tables[0].Rows[0]["frequency"];
                dataGridView1["Frequency1", rowIndex].Value = dsAll.Tables[0].Rows[0]["frequency"];

                dataGridView["LotSize", rowIndex].Value = dsAll.Tables[0].Rows[0]["lotsize"];
                dataGridView1["LotSize1", rowIndex].Value = dsAll.Tables[0].Rows[0]["lotsize"];

                dataGridView["SampleSizeStandard", rowIndex].Value = dsAll.Tables[0].Rows[0]["samplesize"];
                dataGridView1["SampleSizeStandard1", rowIndex].Value = dsAll.Tables[0].Rows[0]["samplesize"];

                //Set to blank
                dataGridView["SampleSizeReading", rowIndex].Value = "";
                dataGridView1["SampleSizeReading1", rowIndex].Value = "";

                //dataGridView 5 --> editable for sample size reading                        


                if (Convert.ToString(dsAll.Tables[0].Rows[0]["aql"]) == "")
                {
                    dataGridView["AQLStandard", rowIndex].Value = "N/A";
                    dataGridView["AQLReading", rowIndex].Value = "N/A";

                    dataGridView["AQLReading", rowIndex].ReadOnly = true;
                    dataGridView["AQLReading", rowIndex].Style.BackColor = Color.FromKnownColor(KnownColor.LightGray);

                    dataGridView1["AQLStandard1", rowIndex].Value = "N/A";
                    dataGridView1["AQLReading1", rowIndex].Value = "N/A";

                    dataGridView1["AQLReading1", rowIndex].ReadOnly = true;
                    dataGridView1["AQLReading1", rowIndex].Style.BackColor = Color.FromKnownColor(KnownColor.LightGray);
                }
                else
                {
                    dataGridView["AQLStandard", rowIndex].Value = dsAll.Tables[0].Rows[0]["aql"];
                    dataGridView["AQLReading", rowIndex].Value = "";

                    dataGridView["AQLReading", rowIndex].ReadOnly = false;
                    dataGridView["AQLReading", rowIndex].Style.BackColor = Color.White;

                    dataGridView1["AQLStandard1", rowIndex].Value = dsAll.Tables[0].Rows[0]["aql"];
                    dataGridView1["AQLReading1", rowIndex].Value = "";

                    dataGridView1["AQLReading1", rowIndex].ReadOnly = false;
                    dataGridView1["AQLReading1", rowIndex].Style.BackColor = Color.White;
                }

                if (Convert.ToString(dsAll.Tables[0].Rows[0]["aqlz"]) == "")
                {
                    dataGridView["AQLzStandard", rowIndex].Value = "N/A";
                    dataGridView["AQLzReading", rowIndex].Value = "N/A";

                    dataGridView["AQLzReading", rowIndex].ReadOnly = true;
                    dataGridView["AQLzReading", rowIndex].Style.BackColor = Color.FromKnownColor(KnownColor.LightGray);

                    dataGridView1["AQLzStandard1", rowIndex].Value = "N/A";
                    dataGridView1["AQLzReading1", rowIndex].Value = "N/A";

                    dataGridView1["AQLzReading1", rowIndex].ReadOnly = true;
                    dataGridView1["AQLzReading1", rowIndex].Style.BackColor = Color.FromKnownColor(KnownColor.LightGray);
                }
                else
                {
                    dataGridView["AQLzStandard", rowIndex].Value = dsAll.Tables[0].Rows[0]["aqlz"];
                    dataGridView["AQLzReading", rowIndex].Value = "";

                    dataGridView["AQLzReading", rowIndex].ReadOnly = false;
                    dataGridView["AQLzReading", rowIndex].Style.BackColor = Color.White;

                    dataGridView1["AQLzStandard1", rowIndex].Value = dsAll.Tables[0].Rows[0]["aqlz"];
                    dataGridView1["AQLzReading1", rowIndex].Value = "";

                    dataGridView1["AQLzReading1", rowIndex].ReadOnly = false;
                    dataGridView1["AQLzReading1", rowIndex].Style.BackColor = Color.White;
                }

                if (Convert.ToString(dsAll.Tables[0].Rows[0]["aqlc"]) == "")
                {
                    dataGridView["AQLcStandard", rowIndex].Value = "N/A";
                    dataGridView["AQLcReading", rowIndex].Value = "N/A";

                    dataGridView["AQLcReading", rowIndex].ReadOnly = true;
                    dataGridView["AQLcReading", rowIndex].Style.BackColor = Color.FromKnownColor(KnownColor.LightGray);

                    dataGridView1["AQLcStandard1", rowIndex].Value = "N/A";
                    dataGridView1["AQLcReading1", rowIndex].Value = "N/A";

                    dataGridView1["AQLcReading1", rowIndex].ReadOnly = true;
                    dataGridView1["AQLcReading1", rowIndex].Style.BackColor = Color.FromKnownColor(KnownColor.LightGray);
                }
                else
                {
                    dataGridView["AQLcStandard", rowIndex].Value = dsAll.Tables[0].Rows[0]["aqlc"];
                    dataGridView["AQLcReading", rowIndex].Value = "";

                    dataGridView["AQLcReading", rowIndex].ReadOnly = false;
                    dataGridView["AQLcReading", rowIndex].Style.BackColor = Color.White;

                    dataGridView1["AQLcStandard1", rowIndex].Value = dsAll.Tables[0].Rows[0]["aqlc"];
                    dataGridView1["AQLcReading1", rowIndex].Value = "";

                    dataGridView1["AQLcReading1", rowIndex].ReadOnly = false;
                    dataGridView1["AQLcReading1", rowIndex].Style.BackColor = Color.White;
                }

                if (Convert.ToString(dsAll.Tables[0].Rows[0]["aqlm"]) == "")
                {
                    dataGridView["AQLMStandard", rowIndex].Value = "N/A";
                    dataGridView["AQLMReading", rowIndex].Value = "N/A";

                    dataGridView["AQLMReading", rowIndex].ReadOnly = true;
                    dataGridView["AQLMReading", rowIndex].Style.BackColor = Color.FromKnownColor(KnownColor.LightGray);

                    dataGridView1["AQLMStandard1", rowIndex].Value = "N/A";
                    dataGridView1["AQLMReading1", rowIndex].Value = "N/A";

                    dataGridView1["AQLMReading1", rowIndex].ReadOnly = true;
                    dataGridView1["AQLMReading1", rowIndex].Style.BackColor = Color.FromKnownColor(KnownColor.LightGray);
                }
                else
                {
                    dataGridView["AQLMStandard", rowIndex].Value = dsAll.Tables[0].Rows[0]["aqlm"];
                    dataGridView["AQLMReading", rowIndex].Value = "";

                    dataGridView["AQLMReading", rowIndex].ReadOnly = false;
                    dataGridView["AQLMReading", rowIndex].Style.BackColor = Color.White;

                    dataGridView1["AQLMStandard1", rowIndex].Value = dsAll.Tables[0].Rows[0]["aqlm"];
                    dataGridView1["AQLMReading1", rowIndex].Value = "";

                    dataGridView1["AQLMReading1", rowIndex].ReadOnly = false;
                    dataGridView1["AQLMReading1", rowIndex].Style.BackColor = Color.White;
                }

                if (Convert.ToString(dsAll.Tables[0].Rows[0]["aqlm1"]) == "")
                {
                    dataGridView["AQLM1Standard", rowIndex].Value = "N/A";
                    dataGridView["AQLM1Reading", rowIndex].Value = "N/A";

                    dataGridView["AQLM1Reading", rowIndex].ReadOnly = true;
                    dataGridView["AQLM1Reading", rowIndex].Style.BackColor = Color.FromKnownColor(KnownColor.LightGray);

                    dataGridView1["AQLM1Standard1", rowIndex].Value = "N/A";
                    dataGridView1["AQLM1Reading1", rowIndex].Value = "N/A";

                    dataGridView1["AQLM1Reading1", rowIndex].ReadOnly = true;
                    dataGridView1["AQLM1Reading1", rowIndex].Style.BackColor = Color.FromKnownColor(KnownColor.LightGray);
                }
                else
                {
                    dataGridView["AQLM1Standard", rowIndex].Value = dsAll.Tables[0].Rows[0]["aqlm1"];
                    dataGridView["AQLM1Reading", rowIndex].Value = "";

                    dataGridView["AQLM1Reading", rowIndex].ReadOnly = false;
                    dataGridView["AQLM1Reading", rowIndex].Style.BackColor = Color.White;

                    dataGridView1["AQLM1Standard1", rowIndex].Value = dsAll.Tables[0].Rows[0]["aqlm1"];
                    dataGridView1["AQLM1Reading1", rowIndex].Value = "";

                    dataGridView1["AQLM1Reading1", rowIndex].ReadOnly = false;
                    dataGridView1["AQLM1Reading1", rowIndex].Style.BackColor = Color.White;
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
                FinishedGoodTest_SubContract_Class_Obj.testno = Convert.ToInt32(dsAll.Tables[0].Rows[0]["TestNo"]);

                //FinishedGoodTest_Class_Obj.type
                dsType = FinishedGoodTest_Class_Obj.Select_tblWAType_TestNo();

                if (dsType.Tables[0].Rows.Count > 0)
                {
                    FinishedGoodTest_Class_Obj.analysistype = dsType.Tables[0].Rows[0]["AnalysisType"].ToString();
                    FinishedGoodTest_SubContract_Class_Obj.analysistype = dsType.Tables[0].Rows[0]["AnalysisType"].ToString();

                    if (dsAll.Tables[0].Rows[0]["TorqueMin"] is System.DBNull || Convert.ToString(dsAll.Tables[0].Rows[0]["TorqueMin"]) == "")
                    {
                        FinishedGoodTest_Class_Obj.torquemin = "0";
                        FinishedGoodTest_SubContract_Class_Obj.torquemin = "0";
                    }
                    else
                    {
                        FinishedGoodTest_Class_Obj.torquemin = dsAll.Tables[0].Rows[0]["TorqueMin"].ToString();
                        FinishedGoodTest_SubContract_Class_Obj.torquemin = dsAll.Tables[0].Rows[0]["TorqueMin"].ToString();
                    }
                    if (dsAll.Tables[0].Rows[0]["TorqueMax"] is System.DBNull || Convert.ToString(dsAll.Tables[0].Rows[0]["TorqueMax"]) == "")
                    {
                        FinishedGoodTest_Class_Obj.torquemax = "0";
                        FinishedGoodTest_SubContract_Class_Obj.torquemax = "0";
                    }
                    else
                    {
                        FinishedGoodTest_Class_Obj.torquemax = dsAll.Tables[0].Rows[0]["TorqueMax"].ToString();
                        FinishedGoodTest_SubContract_Class_Obj.torquemax = dsAll.Tables[0].Rows[0]["TorqueMax"].ToString();
                    }

                    //Get distinct fgcode, formula and line for this test for this tlfid
                    //FinishedGoodTest_Class_Obj.fgtlfid
                    //FinishedGoodTest_Class_Obj.testno
                    //dsFGFormula = FinishedGoodTest_Class_Obj.Select_tblLinkTLF_FGNo_FNo();
                    dsFGFormula = FinishedGoodTest_SubContract_Class_Obj.SELECT_TblTestMaster_SubContract();
                    for (int i = 0; i < dsFGFormula.Tables[0].Rows.Count; i++)
                    {
                        //FinishedGoodTest_Class_Obj.fgtlfid                       
                        FinishedGoodTest_Class_Obj.mtid = Convert.ToInt64(dsFGFormula.Tables[0].Rows[i]["MTID"]);
                        FinishedGoodTest_SubContract_Class_Obj.mtid = Convert.ToInt64(dsFGFormula.Tables[0].Rows[i]["MTID"]);

                        /*FinishedGoodTest_Class_Obj.fgno = Convert.ToInt64(dsFGFormula.Tables[0].Rows[i]["FGNo"]);
                        FinishedGoodTest_Class_Obj.fno = Convert.ToInt64(dsFGFormula.Tables[0].Rows[i]["FNo"]);
                        FinishedGoodTest_Class_Obj.lno = Convert.ToInt32(dsFGFormula.Tables[0].Rows[i]["LNo"]);*/

                        FinishedGoodTest_Class_Obj.fgno = FinishedGoodTest_SubContract_Class_Obj.fgno;
                        FinishedGoodTest_Class_Obj.fno = FinishedGoodTest_SubContract_Class_Obj.fno;

                        //check whether it contains any new launch formula
                        /*//Commented on 02-09-2014 Open when done

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
                        */
                        FinishedGoodTest_Class_Obj.flagrl = 'L';
                        //FinishedGoodTest_SubContract_Class_Obj.flagrl = 'L';
                        //insert fgtlfid , fgcode and formula in transaction table
                        dsTrans = new DataSet();
                        dsTrans = FinishedGoodTest_SubContract_Class_Obj.Select_tblWATrans_FGFormula_SubContract();
                        if (dsTrans.Tables[0].Rows.Count > 0)
                        {
                            FinishedGoodTest_Class_Obj.watransid = Convert.ToInt64(dsTrans.Tables[0].Rows[0]["WAtransID"]);
                            FinishedGoodTest_SubContract_Class_Obj.watransid = Convert.ToInt64(dsTrans.Tables[0].Rows[0]["WAtransID"]);
                        }
                        else
                        {
                            FinishedGoodTest_SubContract_Class_Obj.watransid = FinishedGoodTest_SubContract_Class_Obj.Insert_tblWATrans_SubContract();
                            //FinishedGoodTest_Class_Obj.watransid = FinishedGoodTest_Class_Obj.Insert_tblWATrans();
                        }

                        FinishedGoodTest_Class_Obj.reason = ' ';
                        FinishedGoodTest_Class_Obj.wastatus = ' ';

                        FinishedGoodTest_SubContract_Class_Obj.reason = ' ';
                        FinishedGoodTest_SubContract_Class_Obj.wastatus = ' ';

                        //check whether WA already done?
                        dsWADone = new DataSet();
                        dsWADone = FinishedGoodTest_SubContract_Class_Obj.Select_tblWAStatus_WATransID_SubContract();
                        if (dsWADone.Tables[0].Rows.Count > 0)
                        {
                            FinishedGoodTest_SubContract_Class_Obj.reason = Convert.ToChar(dsWADone.Tables[0].Rows[0]["Reason"]);
                            FinishedGoodTest_SubContract_Class_Obj.wastatus = Convert.ToChar(dsWADone.Tables[0].Rows[0]["Status"]);
                        }
                        else
                        {

                            //Get Top 5 Count after new launch in Bulk 
                            FinishedGoodTest_SubContract_Class_Obj.count = FinishedGoodTest_SubContract_Class_Obj.Decide_Top5Count_WA_SubContract();
                            if (FinishedGoodTest_SubContract_Class_Obj.count > 0)
                            {
                                FinishedGoodTest_SubContract_Class_Obj.reason = 'L';
                            }
                            else
                            {
                                //Get Top 20 Count
                                FinishedGoodTest_SubContract_Class_Obj.count = FinishedGoodTest_SubContract_Class_Obj.Decide_Top20Count_WA_SubContract();
                                if (FinishedGoodTest_SubContract_Class_Obj.count == 20)
                                {
                                    FinishedGoodTest_SubContract_Class_Obj.reason = 'C';
                                }
                            }
                        }
                        //FinishedGoodTest_SubContract_Class_Obj.reason = 'L';
                        if (FinishedGoodTest_SubContract_Class_Obj.reason != ' ')
                        {
                            dgWA.Rows.Add();
                            dgWA["WA", dgWA.Rows.Count - 1].Value = FinishedGoodTest_SubContract_Class_Obj.wastatus;
                            dgWA["Analysis", dgWA.Rows.Count - 1].Value = FinishedGoodTest_SubContract_Class_Obj.analysistype;
                            dgWA["WATransID", dgWA.Rows.Count - 1].Value = FinishedGoodTest_SubContract_Class_Obj.watransid;
                            if (FinishedGoodTest_SubContract_Class_Obj.reason == 'L')
                            {
                                dgWA["Reason", dgWA.Rows.Count - 1].Value = "New Launch";
                            }
                            else if (FinishedGoodTest_SubContract_Class_Obj.reason == 'C')
                            {
                                dgWA["Reason", dgWA.Rows.Count - 1].Value = "20th Lot";
                            }
                            /*dgWA["TestNo", dgWA.Rows.Count - 1].Value = Convert.ToInt32(dsFGFormula.Tables[0].Rows[i]["TestNo"]);
                            dgWA["Test", dgWA.Rows.Count - 1].Value = Convert.ToString(dsFGFormula.Tables[0].Rows[i]["Test"]);
                            dgWA["FGNo", dgWA.Rows.Count - 1].Value = Convert.ToInt64(dsFGFormula.Tables[0].Rows[i]["FGNo"]);
                            dgWA["FGCode", dgWA.Rows.Count - 1].Value = Convert.ToString(dsFGFormula.Tables[0].Rows[i]["FGCode"]);
                            dgWA["FNo", dgWA.Rows.Count - 1].Value = Convert.ToInt64(dsFGFormula.Tables[0].Rows[i]["FNo"]);
                            dgWA["FormulaNo", dgWA.Rows.Count - 1].Value = Convert.ToString(dsFGFormula.Tables[0].Rows[i]["FormulaNo"]);
                            dgWA["LNo", dgWA.Rows.Count - 1].Value = Convert.ToInt64(dsFGFormula.Tables[0].Rows[i]["LNo"]);
                            dgWA["LineDesc", dgWA.Rows.Count - 1].Value = Convert.ToString(dsFGFormula.Tables[0].Rows[i]["LineDesc"]);
                            */
                            dgWA["TestNo", dgWA.Rows.Count - 1].Value = Convert.ToInt32(dsFGFormula.Tables[0].Rows[i]["TestNo"]);
                            dgWA["Test", dgWA.Rows.Count - 1].Value = Convert.ToString(dsFGFormula.Tables[0].Rows[i]["Test"]);
                            dgWA["FGNo", dgWA.Rows.Count - 1].Value = FinishedGoodTest_SubContract_Class_Obj.fgno;
                            dgWA["FGCode", dgWA.Rows.Count - 1].Value = FinishedGoodTest_SubContract_Class_Obj.fgcode;
                            dgWA["FNo", dgWA.Rows.Count - 1].Value = FinishedGoodTest_SubContract_Class_Obj.fno;
                            dgWA["FormulaNo", dgWA.Rows.Count - 1].Value = FinishedGoodTest_SubContract_Class_Obj.formulano;
                            dgWA["LNo", dgWA.Rows.Count - 1].Value = FinishedGoodTest_SubContract_Class_Obj.FGSupplierID;
                            dgWA["LineDesc", dgWA.Rows.Count - 1].Value = FinishedGoodTest_SubContract_Class_Obj.supplier;

                            if (FinishedGoodTest_SubContract_Class_Obj.type == "Normal")
                            {
                                dgWA["ObsCnt", dgWA.Rows.Count - 1].Value = Convert.ToInt32(dsFGFormula.Tables[0].Rows[i]["Normal"]);
                            }
                            else if (FinishedGoodTest_SubContract_Class_Obj.type == "Reinforce")
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

        private void btnProtocol_Click(object sender, EventArgs e)
        {

            string ProtocolNo = "FGP" + FinishedGoodTest_SubContract_Class_Obj.fgtestno.ToString().PadLeft(6, '0');

            DataSet ds = new DataSet();
            ds = FinishedGoodTest_SubContract_Class_Obj.Select_View_Protocol_FGPackingDetails_SubContract();


            DataTable dt_Loreal = new DataTable();
            dt_Loreal.Columns.Add("TestMethod");
            dt_Loreal.Columns.Add("Frequency");
            dt_Loreal.Columns.Add("InspectionMethod");
            dt_Loreal.Columns.Add("LotSize");
            dt_Loreal.Columns.Add("SampleSizeStandard");
            dt_Loreal.Columns.Add("SampleSizeReading");
            dt_Loreal.Columns.Add("AQLStandard");
            dt_Loreal.Columns.Add("AQLReading");
            dt_Loreal.Columns.Add("AQLzStandard");
            dt_Loreal.Columns.Add("AQLzReading");
            dt_Loreal.Columns.Add("AQLcStandard");
            dt_Loreal.Columns.Add("AQLcReading");
            dt_Loreal.Columns.Add("AQLMStandard");
            dt_Loreal.Columns.Add("AQLMReading");
            dt_Loreal.Columns.Add("AQLM1Standard");
            dt_Loreal.Columns.Add("AQLM1Reading");

            DataRow dr;
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                dr = dt_Loreal.NewRow();
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
                dt_Loreal.Rows.InsertAt(dr, i);
            }

            DataTable dt_Supplier = new DataTable();
            dt_Supplier.Columns.Add("TestMethod");
            dt_Supplier.Columns.Add("Frequency");
            dt_Supplier.Columns.Add("InspectionMethod");
            dt_Supplier.Columns.Add("LotSize");
            dt_Supplier.Columns.Add("SampleSizeStandard");
            dt_Supplier.Columns.Add("SampleSizeReading");
            dt_Supplier.Columns.Add("AQLStandard");
            dt_Supplier.Columns.Add("AQLReading");
            dt_Supplier.Columns.Add("AQLzStandard");
            dt_Supplier.Columns.Add("AQLzReading");
            dt_Supplier.Columns.Add("AQLcStandard");
            dt_Supplier.Columns.Add("AQLcReading");
            dt_Supplier.Columns.Add("AQLMStandard");
            dt_Supplier.Columns.Add("AQLMReading");
            dt_Supplier.Columns.Add("AQLM1Standard");
            dt_Supplier.Columns.Add("AQLM1Reading");

            DataRow dr1;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                dr1 = dt_Supplier.NewRow();
                dr1["TestMethod"] = dataGridView1["TestMethod1", i].Value;
                dr1["Frequency"] = dataGridView1["Frequency1", i].Value;
                dr1["InspectionMethod"] = dataGridView1["InspectionMethod1", i].Value;
                dr1["LotSize"] = dataGridView1["LotSize1", i].Value;
                dr1["SampleSizeStandard"] = dataGridView1["SampleSizeStandard1", i].Value;
                dr1["SampleSizeReading"] = dataGridView1["SampleSizeReading1", i].Value;
                dr1["AQLStandard"] = dataGridView1["AQLStandard1", i].Value;
                dr1["AQLReading"] = dataGridView1["AQLReading1", i].Value;
                dr1["AQLzStandard"] = dataGridView1["AQLzStandard1", i].Value;
                dr1["AQLzReading"] = dataGridView1["AQLzReading1", i].Value;
                dr1["AQLcStandard"] = dataGridView1["AQLcStandard1", i].Value;
                dr1["AQLcReading"] = dataGridView1["AQLcReading1", i].Value;
                dr1["AQLMStandard"] = dataGridView1["AQLMStandard1", i].Value;
                dr1["AQLMReading"] = dataGridView1["AQLMReading1", i].Value;
                dr1["AQLM1Standard"] = dataGridView1["AQLM1Standard1", i].Value;
                dr1["AQLM1Reading"] = dataGridView1["AQLM1Reading1", i].Value;
                dt_Supplier.Rows.InsertAt(dr1, i);
            }

            QTMS.Reports_Forms.FrmProtocol_FGPacking_SubContract fm = new QTMS.Reports_Forms.FrmProtocol_FGPacking_SubContract("FG Packing Protocol", ds, dt_Loreal, dt_Supplier, txtQuantity.Text.Trim(), ProtocolNo, cmbInspectedBy.Text);
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
                FrmWA_SubContract.Weighing weighing = new FrmWA_SubContract.Weighing();
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
                weighing.WA_TorqueMin = FinishedGoodTest_SubContract_Class_Obj.torquemin;
                weighing.WA_TorqueMax = FinishedGoodTest_SubContract_Class_Obj.torquemax;



                FrmWA_SubContract frm = new FrmWA_SubContract(weighing);
                frm.ShowDialog();

                DataSet dsWADone = new DataSet();
                FinishedGoodTest_SubContract_Class_Obj.watransid = Convert.ToInt64(dgWA["WATransID", e.RowIndex].Value);
                dsWADone = FinishedGoodTest_SubContract_Class_Obj.Select_tblWAStatus_WATransID_SubContract();
                if (dsWADone.Tables[0].Rows.Count > 0)
                {
                    dgWA["WA", e.RowIndex].Value = dsWADone.Tables[0].Rows[0]["Status"].ToString();
                    //txtQuantity.Focus();
                    dgWA.Focus();
                }
            }
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dataGridView1.CurrentCell.RowIndex < 0
                || (dataGridView1.CurrentCell.ColumnIndex != dataGridView1.Columns["InspectionMethod1"].Index
                     && dataGridView1.CurrentCell.ReadOnly == true))
            {
                return;
            }
            else if (dataGridView1.CurrentCell.ColumnIndex == dataGridView1.Columns["InspectionMethod1"].Index)
            {
                cmb = e.Control as ComboBox;
                cmb.Text = e.Control.Text;
                cmb.TextChanged += new EventHandler(cmb_TextChanged);
                return;
            }
            else if (dataGridView1.CurrentCell.ReadOnly == false)
            {
                dataGridView1.EditingControl.KeyPress += new KeyPressEventHandler(EditingControl_KeyPress);
            }
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //----------- sample size -----------

            if (e.RowIndex < 0 || e.ColumnIndex != dataGridView1.Columns["SampleSizeReading1"].Index)
            {
                return;
            }
            else
            {

                if (dataGridView1.CurrentCell.EditedFormattedValue.ToString() != "")
                {
                    if (Convert.ToInt64(dataGridView1.CurrentCell.EditedFormattedValue) < Convert.ToInt64(dataGridView1["SampleSizeStandard1", dataGridView1.CurrentCell.RowIndex].Value))
                    {
                        MessageBox.Show("Sample Size Reading is less than Sample Size Standard", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        e.Cancel = true;

                    }
                }
            }
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
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

        #region Avinash 04-09-2014

        private void FillGrid_Loreal_Return()
        {
            dataGridView.Rows.Clear();

            if ((Convert.ToInt64(txtQuantity.Text) >= 81) && (Convert.ToInt64(txtQuantity.Text) <= 35000))
            {
                FinishedGoodTest_Class_Obj.lotsize = "81-35000";
                FinishedGoodTest_SubContract_Class_Obj.lotsize = "81-35000";
            }
            else if ((Convert.ToInt64(txtQuantity.Text) >= 35001) && (Convert.ToInt64(txtQuantity.Text) <= 500000))
            {
                FinishedGoodTest_Class_Obj.lotsize = "35001-500000";
                FinishedGoodTest_SubContract_Class_Obj.lotsize = "35001-500000";
            }

            DataSet ds = new DataSet();
            DataSet dsInspMethod = new DataSet();
            DataSet dsAll = new DataSet();
            DataTable dt = new DataTable();

            FinishedGoodMaster_Class_obj.fgno = FinishedGoodTest_Class_Obj.fgno;
            FinishedGoodTest_SubContract_Class_Obj.fgno = FinishedGoodTest_Class_Obj.fgno;
            dt = FinishedGoodMaster_Class_obj.STP_SELECT_tblFGCodeFamilyTestRelation_FGNo();
            if (dt.Rows.Count > 1)
            {
                //ds = FinishedGoodTest_Class_Obj.Select_VIEW_FinishedGoodDetails1_TestNo_TestName1();
                ds = FinishedGoodTest_SubContract_Class_Obj.Select_VIEW_FinishedGoodDetails1_TestNo_TestName1_SubContract();
            }
            else
            {
                //ds = FinishedGoodTest_Class_Obj.Select_VIEW_FinishedGoodTestMethodDetails_TestNo_TestName();
                ds = FinishedGoodTest_SubContract_Class_Obj.Select_VIEW_FinishedGoodDetails_TestNo_TestName_SubContract();

            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dataGridView.Rows.Add();
                    //---------Test method---------- 
                    dataGridView["TestMethod", dataGridView.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["Method"];
                    FinishedGoodTest_SubContract_Class_Obj.testname = dataGridView["TestMethod", dataGridView.Rows.Count - 1].Value.ToString();
                    dataGridView["TestDesc", dataGridView.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestDesc"];

                    //---------Inspection method-----------
                    //dsInspMethod = FinishedGoodTest_Class_Obj.Select_VIEW_FinishedGoodTestMethodDetails_InspectionMethod();
                    FinishedGoodTest_SubContract_Class_Obj.result = "";
                    dsInspMethod = FinishedGoodTest_SubContract_Class_Obj.Select_VIEW_FinishedGoodTestMethodDetails_InspectionMethod_SubContract();

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
                        FinishedGoodTest_SubContract_Class_Obj.inspectionmethod = dsInspMethod.Tables[0].Rows[row]["InspectionMethod"].ToString();
                        FinishedGoodTest_SubContract_Class_Obj.fgmethodno = Convert.ToInt64(dsInspMethod.Tables[0].Rows[row]["FGMethodNo"].ToString());

                        //dsReading = FinishedGoodTest_Class_Obj.STP_Select_tblFinishedGoodTest_TestMethodDetails_FGTLFID_FGMethodNo();
                        dsReading = FinishedGoodTest_SubContract_Class_Obj.STP_Select_tblFinishedGoodTest_TestMethodDetails_FGTLFID_FGMethodNo_SubContract();
                        if (dsReading.Tables[0].Rows.Count > 0)
                        {
                            //Set selected Text in combobox
                            combo.Value = FinishedGoodTest_SubContract_Class_Obj.inspectionmethod;

                            dsAll = FinishedGoodTest_SubContract_Class_Obj.Select_VIEW_FinishedGoodTestMethodDetails_All_SubContract();// Changes in this query for show norms from transaction
                            DisplayDataGridView_All_Loreal(dsAll, dataGridView.Rows.Count - 1);
                            if (dsReading.Tables[0].Rows.Count > 0)
                            {
                                if (dsReading.Tables[0].Rows[0]["SampleSizeReading"].ToString() == "0")
                                {
                                    dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["SampleSizeReading"].Value = "";
                                    //dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["SampleSizeReading1"].Value = "";
                                }
                                else
                                {
                                    dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["SampleSizeReading"].Value = dsReading.Tables[0].Rows[0]["SampleSizeReading"].ToString();
                                    //dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["SampleSizeReading1"].Value = dsReading.Tables[0].Rows[0]["SampleSizeReading"].ToString();
                                }

                                if (dsReading.Tables[0].Rows[0]["AQLReading"].ToString() != "N/A")
                                {
                                    dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["AQLReading"].Value = dsReading.Tables[0].Rows[0]["AQLReading"].ToString();
                                    //dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["AQLReading1"].Value = dsReading.Tables[0].Rows[0]["AQLReading"].ToString();
                                }
                                else
                                {
                                    dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["AQLReading"].Value = "N/A";
                                    //dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["AQLReading1"].Value = "N/A";
                                }
                                if (dsReading.Tables[0].Rows[0]["AQLzReading"].ToString() != "N/A")
                                {
                                    dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["AQLzReading"].Value = dsReading.Tables[0].Rows[0]["AQLzReading"].ToString();
                                    //dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["AQLzReading1"].Value = dsReading.Tables[0].Rows[0]["AQLzReading"].ToString();
                                }
                                else
                                {
                                    dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["AQLzReading"].Value = "N/A";
                                    //dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["AQLzReading1"].Value = "N/A";
                                }

                                if (dsReading.Tables[0].Rows[0]["AQLcReading"].ToString() != "N/A")
                                {
                                    dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["AQLcReading"].Value = dsReading.Tables[0].Rows[0]["AQLcReading"].ToString();
                                    //dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["AQLcReading1"].Value = dsReading.Tables[0].Rows[0]["AQLcReading"].ToString();
                                }
                                else
                                {
                                    dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["AQLcReading"].Value = "N/A";
                                    //dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["AQLcReading1"].Value = "N/A";
                                }
                                if (dsReading.Tables[0].Rows[0]["AQLMReading"].ToString() != "N/A")
                                {
                                    dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["AQLMReading"].Value = dsReading.Tables[0].Rows[0]["AQLMReading"].ToString();
                                    //dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["AQLMReading1"].Value = dsReading.Tables[0].Rows[0]["AQLMReading"].ToString();
                                }
                                else
                                {
                                    dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["AQLMReading"].Value = "N/A";
                                    //dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["AQLMReading1"].Value = "N/A";
                                }
                                if (dsReading.Tables[0].Rows[0]["AQLM1Reading"].ToString() != "N/A")
                                {
                                    dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["AQLM1Reading"].Value = dsReading.Tables[0].Rows[0]["AQLM1Reading"].ToString();
                                    //dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["AQLM1Reading1"].Value = dsReading.Tables[0].Rows[0]["AQLM1Reading"].ToString();
                                }
                                else
                                {
                                    dataGridView.Rows[dataGridView.Rows.Count - 1].Cells["AQLM1Reading"].Value = "N/A";
                                    //dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["AQLM1Reading1"].Value = "N/A";
                                }
                            }
                            break;
                        }
                        else
                        {
                            //Set selected Text in combobox
                            combo.Value = dsInspMethod.Tables[0].Rows[row]["InspectionMethod"].ToString();
                            dsAll = FinishedGoodTest_SubContract_Class_Obj.Select_VIEW_FinishedGoodTestMethodDetails_All_SubContract();

                            DisplayDataGridView_All_Loreal(dsAll, dataGridView.Rows.Count - 1);
                        }

                    }
                }
            }
        }

        private void FillGrid_Supplier_Return()
        {
            dataGridView1.Rows.Clear();

            if ((Convert.ToInt64(txtQuantity.Text) >= 81) && (Convert.ToInt64(txtQuantity.Text) <= 35000))
            {
                FinishedGoodTest_Class_Obj.lotsize = "81-35000";
                FinishedGoodTest_SubContract_Class_Obj.lotsize = "81-35000";
            }
            else if ((Convert.ToInt64(txtQuantity.Text) >= 35001) && (Convert.ToInt64(txtQuantity.Text) <= 500000))
            {
                FinishedGoodTest_Class_Obj.lotsize = "35001-500000";
                FinishedGoodTest_SubContract_Class_Obj.lotsize = "35001-500000";
            }

            DataSet ds = new DataSet();
            DataSet dsInspMethod = new DataSet();
            DataSet dsAll = new DataSet();
            DataTable dt = new DataTable();

            FinishedGoodMaster_Class_obj.fgno = FinishedGoodTest_Class_Obj.fgno;
            FinishedGoodTest_SubContract_Class_Obj.fgno = FinishedGoodTest_Class_Obj.fgno;
            dt = FinishedGoodMaster_Class_obj.STP_SELECT_tblFGCodeFamilyTestRelation_FGNo();
            if (dt.Rows.Count > 1)
            {
                //ds = FinishedGoodTest_Class_Obj.Select_VIEW_FinishedGoodDetails1_TestNo_TestName1();
                ds = FinishedGoodTest_SubContract_Class_Obj.Select_VIEW_FinishedGoodDetails1_TestNo_TestName1_SubContract();
            }
            else
            {
                //ds = FinishedGoodTest_Class_Obj.Select_VIEW_FinishedGoodTestMethodDetails_TestNo_TestName();
                ds = FinishedGoodTest_SubContract_Class_Obj.Select_VIEW_FinishedGoodDetails_TestNo_TestName_SubContract();
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dataGridView1.Rows.Add();
                    //---------Test method---------- 
                    dataGridView1["TestMethod1", dataGridView1.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["Method"];
                    FinishedGoodTest_SubContract_Class_Obj.testname = dataGridView1["TestMethod1", dataGridView1.Rows.Count - 1].Value.ToString();
                    dataGridView1["TestDesc1", dataGridView1.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["TestDesc"];

                    //---------Inspection method-----------
                    //dsInspMethod = FinishedGoodTest_Class_Obj.Select_VIEW_FinishedGoodTestMethodDetails_InspectionMethod();
                    FinishedGoodTest_SubContract_Class_Obj.result = "Supplier";
                    dsInspMethod = FinishedGoodTest_SubContract_Class_Obj.Select_VIEW_FinishedGoodTestMethodDetails_InspectionMethod_SubContract();

                    DataGridViewComboBoxCell combo1 = new DataGridViewComboBoxCell();
                    combo1.DisplayMember = dsInspMethod.Tables[0].Columns["InspectionMethod"].ToString();

                    for (int row = 0; row < dsInspMethod.Tables[0].Rows.Count; row++)
                    {
                        combo1.Items.Add(dsInspMethod.Tables[0].Rows[row]["InspectionMethod"].ToString());

                        //set FGMethodNo as per InspMethod 
                        dataGridView1["FGMethodNo1", dataGridView1.Rows.Count - 1].Value = Convert.ToInt64(dsInspMethod.Tables[0].Rows[row]["FGMethodNo"].ToString());
                    }
                    dataGridView1.Rows[i].Cells["InspectionMethod1"] = combo1;

                    DataSet dsReading;
                    for (int row = 0; row < dsInspMethod.Tables[0].Rows.Count; row++)
                    {
                        dsReading = new DataSet();
                        FinishedGoodTest_SubContract_Class_Obj.inspectionmethod = dsInspMethod.Tables[0].Rows[row]["InspectionMethod"].ToString();
                        FinishedGoodTest_SubContract_Class_Obj.fgmethodno = Convert.ToInt64(dsInspMethod.Tables[0].Rows[row]["FGMethodNo"].ToString());

                        //dsReading = FinishedGoodTest_Class_Obj.STP_Select_tblFinishedGoodTest_TestMethodDetails_FGTLFID_FGMethodNo();
                        dsReading = FinishedGoodTest_SubContract_Class_Obj.STP_Select_tblFinishedGoodTest_TestMethodDetails_FGTLFID_FGMethodNo_SubContract();
                        if (dsReading.Tables[0].Rows.Count > 0)
                        {
                            //Set selected Text in combobox
                            combo1.Value = FinishedGoodTest_SubContract_Class_Obj.inspectionmethod;

                            dsAll = FinishedGoodTest_SubContract_Class_Obj.Select_VIEW_FinishedGoodTestMethodDetails_All_SubContract();// Changes in this query for show norms from transaction
                            DisplayDataGridView_All_Supplier(dsAll, dataGridView1.Rows.Count - 1);
                            if (dsReading.Tables[0].Rows.Count > 0)
                            {
                                if (dsReading.Tables[0].Rows[0]["SampleSizeReading"].ToString() == "0")
                                {
                                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["SampleSizeReading1"].Value = "";
                                    //dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["SampleSizeReading1"].Value = "";
                                }
                                else
                                {
                                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["SampleSizeReading1"].Value = dsReading.Tables[0].Rows[0]["SampleSizeReading"].ToString();
                                    //dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["SampleSizeReading1"].Value = dsReading.Tables[0].Rows[0]["SampleSizeReading"].ToString();
                                }

                                if (dsReading.Tables[0].Rows[0]["AQLReading"].ToString() != "N/A")
                                {
                                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["AQLReading1"].Value = dsReading.Tables[0].Rows[0]["AQLReading"].ToString();
                                    //dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["AQLReading1"].Value = dsReading.Tables[0].Rows[0]["AQLReading"].ToString();
                                }
                                else
                                {
                                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["AQLReading1"].Value = "N/A";
                                    //dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["AQLReading1"].Value = "N/A";
                                }
                                if (dsReading.Tables[0].Rows[0]["AQLzReading"].ToString() != "N/A")
                                {
                                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["AQLzReading1"].Value = dsReading.Tables[0].Rows[0]["AQLzReading"].ToString();
                                    //dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["AQLzReading1"].Value = dsReading.Tables[0].Rows[0]["AQLzReading"].ToString();
                                }
                                else
                                {
                                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["AQLzReading1"].Value = "N/A";
                                    //dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["AQLzReading1"].Value = "N/A";
                                }

                                if (dsReading.Tables[0].Rows[0]["AQLcReading"].ToString() != "N/A")
                                {
                                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["AQLcReading1"].Value = dsReading.Tables[0].Rows[0]["AQLcReading"].ToString();
                                    //dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["AQLcReading1"].Value = dsReading.Tables[0].Rows[0]["AQLcReading"].ToString();
                                }
                                else
                                {
                                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["AQLcReading1"].Value = "N/A";
                                    //dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["AQLcReading1"].Value = "N/A";
                                }
                                if (dsReading.Tables[0].Rows[0]["AQLMReading"].ToString() != "N/A")
                                {
                                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["AQLMReading1"].Value = dsReading.Tables[0].Rows[0]["AQLMReading"].ToString();
                                    //dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["AQLMReading1"].Value = dsReading.Tables[0].Rows[0]["AQLMReading"].ToString();
                                }
                                else
                                {
                                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["AQLMReading1"].Value = "N/A";
                                    //dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["AQLMReading1"].Value = "N/A";
                                }
                                if (dsReading.Tables[0].Rows[0]["AQLM1Reading"].ToString() != "N/A")
                                {
                                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["AQLM1Reading1"].Value = dsReading.Tables[0].Rows[0]["AQLM1Reading"].ToString();
                                    //dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["AQLM1Reading1"].Value = dsReading.Tables[0].Rows[0]["AQLM1Reading"].ToString();
                                }
                                else
                                {
                                    dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["AQLM1Reading1"].Value = "N/A";
                                    //dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["AQLM1Reading1"].Value = "N/A";
                                }
                            }
                            break;
                        }
                        else
                        {
                            //Set selected Text in combobox
                            combo1.Value = dsInspMethod.Tables[0].Rows[row]["InspectionMethod"].ToString();
                            dsAll = FinishedGoodTest_SubContract_Class_Obj.Select_VIEW_FinishedGoodTestMethodDetails_All_SubContract();

                            DisplayDataGridView_All_Supplier(dsAll, dataGridView1.Rows.Count - 1);
                        }

                    }
                }
            }
        }

        private void DisplayDataGridView_All_Loreal(DataSet dsAll, int rowIndex)
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
                FinishedGoodTest_SubContract_Class_Obj.testno = Convert.ToInt32(dsAll.Tables[0].Rows[0]["TestNo"]);

                //FinishedGoodTest_Class_Obj.type
                dsType = FinishedGoodTest_Class_Obj.Select_tblWAType_TestNo();

                if (dsType.Tables[0].Rows.Count > 0)
                {
                    FinishedGoodTest_Class_Obj.analysistype = dsType.Tables[0].Rows[0]["AnalysisType"].ToString();
                    FinishedGoodTest_SubContract_Class_Obj.analysistype = dsType.Tables[0].Rows[0]["AnalysisType"].ToString();

                    if (dsAll.Tables[0].Rows[0]["TorqueMin"] is System.DBNull || Convert.ToString(dsAll.Tables[0].Rows[0]["TorqueMin"]) == "")
                    {
                        FinishedGoodTest_Class_Obj.torquemin = "0";
                        FinishedGoodTest_SubContract_Class_Obj.torquemin = "0";
                    }
                    else
                    {
                        FinishedGoodTest_Class_Obj.torquemin = dsAll.Tables[0].Rows[0]["TorqueMin"].ToString();
                        FinishedGoodTest_SubContract_Class_Obj.torquemin = dsAll.Tables[0].Rows[0]["TorqueMin"].ToString();
                    }
                    if (dsAll.Tables[0].Rows[0]["TorqueMax"] is System.DBNull || Convert.ToString(dsAll.Tables[0].Rows[0]["TorqueMax"]) == "")
                    {
                        FinishedGoodTest_Class_Obj.torquemax = "0";
                        FinishedGoodTest_SubContract_Class_Obj.torquemax = "0";
                    }
                    else
                    {
                        FinishedGoodTest_Class_Obj.torquemax = dsAll.Tables[0].Rows[0]["TorqueMax"].ToString();
                        FinishedGoodTest_SubContract_Class_Obj.torquemax = dsAll.Tables[0].Rows[0]["TorqueMax"].ToString();
                    }

                    //Get distinct fgcode, formula and line for this test for this tlfid
                    //FinishedGoodTest_Class_Obj.fgtlfid
                    //FinishedGoodTest_Class_Obj.testno
                    //dsFGFormula = FinishedGoodTest_Class_Obj.Select_tblLinkTLF_FGNo_FNo();
                    dsFGFormula = FinishedGoodTest_SubContract_Class_Obj.SELECT_TblTestMaster_SubContract();
                    for (int i = 0; i < dsFGFormula.Tables[0].Rows.Count; i++)
                    {
                        //FinishedGoodTest_Class_Obj.fgtlfid                       
                        FinishedGoodTest_Class_Obj.mtid = Convert.ToInt64(dsFGFormula.Tables[0].Rows[i]["MTID"]);
                        FinishedGoodTest_SubContract_Class_Obj.mtid = Convert.ToInt64(dsFGFormula.Tables[0].Rows[i]["MTID"]);

                        /*FinishedGoodTest_Class_Obj.fgno = Convert.ToInt64(dsFGFormula.Tables[0].Rows[i]["FGNo"]);
                        FinishedGoodTest_Class_Obj.fno = Convert.ToInt64(dsFGFormula.Tables[0].Rows[i]["FNo"]);
                        FinishedGoodTest_Class_Obj.lno = Convert.ToInt32(dsFGFormula.Tables[0].Rows[i]["LNo"]);*/

                        FinishedGoodTest_Class_Obj.fgno = FinishedGoodTest_SubContract_Class_Obj.fgno;
                        FinishedGoodTest_Class_Obj.fno = FinishedGoodTest_SubContract_Class_Obj.fno;

                        //check whether it contains any new launch formula
                        /*//Commented on 02-09-2014 Open when done

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
                        */
                        FinishedGoodTest_Class_Obj.flagrl = 'L';
                        // FinishedGoodTest_SubContract_Class_Obj.flagrl = 'L';
                        //insert fgtlfid , fgcode and formula in transaction table
                        dsTrans = new DataSet();
                        dsTrans = FinishedGoodTest_SubContract_Class_Obj.Select_tblWATrans_FGFormula_SubContract();
                        if (dsTrans.Tables[0].Rows.Count > 0)
                        {
                            FinishedGoodTest_Class_Obj.watransid = Convert.ToInt64(dsTrans.Tables[0].Rows[0]["WAtransID"]);
                            FinishedGoodTest_SubContract_Class_Obj.watransid = Convert.ToInt64(dsTrans.Tables[0].Rows[0]["WAtransID"]);
                        }
                        else
                        {
                            FinishedGoodTest_SubContract_Class_Obj.watransid = FinishedGoodTest_SubContract_Class_Obj.Insert_tblWATrans_SubContract();
                            //FinishedGoodTest_Class_Obj.watransid = FinishedGoodTest_Class_Obj.Insert_tblWATrans();
                        }

                        FinishedGoodTest_Class_Obj.reason = ' ';
                        FinishedGoodTest_Class_Obj.wastatus = ' ';

                        FinishedGoodTest_SubContract_Class_Obj.reason = ' ';
                        FinishedGoodTest_SubContract_Class_Obj.wastatus = ' ';

                        //check whether WA already done?
                        dsWADone = new DataSet();
                        dsWADone = FinishedGoodTest_SubContract_Class_Obj.Select_tblWAStatus_WATransID_SubContract();
                        if (dsWADone.Tables[0].Rows.Count > 0)
                        {
                            FinishedGoodTest_SubContract_Class_Obj.reason = Convert.ToChar(dsWADone.Tables[0].Rows[0]["Reason"]);
                            FinishedGoodTest_SubContract_Class_Obj.wastatus = Convert.ToChar(dsWADone.Tables[0].Rows[0]["Status"]);
                        }
                        else
                        {

                            //Get Top 5 Count after new launch in Bulk 
                            FinishedGoodTest_SubContract_Class_Obj.count = FinishedGoodTest_SubContract_Class_Obj.Decide_Top5Count_WA_SubContract();
                            if (FinishedGoodTest_SubContract_Class_Obj.count > 0)
                            {
                                FinishedGoodTest_SubContract_Class_Obj.reason = 'L';
                            }
                            else
                            {
                                //Get Top 20 Count
                                FinishedGoodTest_SubContract_Class_Obj.count = FinishedGoodTest_SubContract_Class_Obj.Decide_Top20Count_WA_SubContract();
                                if (FinishedGoodTest_SubContract_Class_Obj.count == 20)
                                {
                                    FinishedGoodTest_SubContract_Class_Obj.reason = 'C';
                                }
                            }
                        }
                        //FinishedGoodTest_SubContract_Class_Obj.reason = 'L';
                        if (FinishedGoodTest_SubContract_Class_Obj.reason != ' ')
                        {
                            dgWA.Rows.Add();
                            dgWA["WA", dgWA.Rows.Count - 1].Value = FinishedGoodTest_SubContract_Class_Obj.wastatus;
                            dgWA["Analysis", dgWA.Rows.Count - 1].Value = FinishedGoodTest_SubContract_Class_Obj.analysistype;
                            dgWA["WATransID", dgWA.Rows.Count - 1].Value = FinishedGoodTest_SubContract_Class_Obj.watransid;
                            if (FinishedGoodTest_SubContract_Class_Obj.reason == 'L')
                            {
                                dgWA["Reason", dgWA.Rows.Count - 1].Value = "New Launch";
                            }
                            else if (FinishedGoodTest_SubContract_Class_Obj.reason == 'C')
                            {
                                dgWA["Reason", dgWA.Rows.Count - 1].Value = "20th Lot";
                            }
                            /*dgWA["TestNo", dgWA.Rows.Count - 1].Value = Convert.ToInt32(dsFGFormula.Tables[0].Rows[i]["TestNo"]);
                            dgWA["Test", dgWA.Rows.Count - 1].Value = Convert.ToString(dsFGFormula.Tables[0].Rows[i]["Test"]);
                            dgWA["FGNo", dgWA.Rows.Count - 1].Value = Convert.ToInt64(dsFGFormula.Tables[0].Rows[i]["FGNo"]);
                            dgWA["FGCode", dgWA.Rows.Count - 1].Value = Convert.ToString(dsFGFormula.Tables[0].Rows[i]["FGCode"]);
                            dgWA["FNo", dgWA.Rows.Count - 1].Value = Convert.ToInt64(dsFGFormula.Tables[0].Rows[i]["FNo"]);
                            dgWA["FormulaNo", dgWA.Rows.Count - 1].Value = Convert.ToString(dsFGFormula.Tables[0].Rows[i]["FormulaNo"]);
                            dgWA["LNo", dgWA.Rows.Count - 1].Value = Convert.ToInt64(dsFGFormula.Tables[0].Rows[i]["LNo"]);
                            dgWA["LineDesc", dgWA.Rows.Count - 1].Value = Convert.ToString(dsFGFormula.Tables[0].Rows[i]["LineDesc"]);
                            */
                            dgWA["TestNo", dgWA.Rows.Count - 1].Value = Convert.ToInt32(dsFGFormula.Tables[0].Rows[i]["TestNo"]);
                            dgWA["Test", dgWA.Rows.Count - 1].Value = Convert.ToString(dsFGFormula.Tables[0].Rows[i]["Test"]);
                            dgWA["FGNo", dgWA.Rows.Count - 1].Value = FinishedGoodTest_SubContract_Class_Obj.fgno;
                            dgWA["FGCode", dgWA.Rows.Count - 1].Value = FinishedGoodTest_SubContract_Class_Obj.fgcode;
                            dgWA["FNo", dgWA.Rows.Count - 1].Value = FinishedGoodTest_SubContract_Class_Obj.fno;
                            dgWA["FormulaNo", dgWA.Rows.Count - 1].Value = FinishedGoodTest_SubContract_Class_Obj.formulano;
                            dgWA["LNo", dgWA.Rows.Count - 1].Value = FinishedGoodTest_SubContract_Class_Obj.FGSupplierID;
                            dgWA["LineDesc", dgWA.Rows.Count - 1].Value = FinishedGoodTest_SubContract_Class_Obj.supplier;

                            if (FinishedGoodTest_SubContract_Class_Obj.type == "Normal")
                            {
                                dgWA["ObsCnt", dgWA.Rows.Count - 1].Value = Convert.ToInt32(dsFGFormula.Tables[0].Rows[i]["Normal"]);
                            }
                            else if (FinishedGoodTest_SubContract_Class_Obj.type == "Reinforce")
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

        private void DisplayDataGridView_All_Supplier(DataSet dsAll, int rowIndex)
        {
            if (dsAll.Tables[0].Rows.Count > 0)
            {
                dataGridView1["FGMethodNo1", rowIndex].Value = dsAll.Tables[0].Rows[0]["FGMethodNo"];
                dataGridView1["Frequency1", rowIndex].Value = dsAll.Tables[0].Rows[0]["frequency"];
                dataGridView1["LotSize1", rowIndex].Value = dsAll.Tables[0].Rows[0]["lotsize"];
                dataGridView1["SampleSizeStandard1", rowIndex].Value = dsAll.Tables[0].Rows[0]["samplesize"];
                //Set to blank
                dataGridView1["SampleSizeReading1", rowIndex].Value = "";
                //dataGridView1 5 --> editable for sample size reading
                if (Convert.ToString(dsAll.Tables[0].Rows[0]["aql"]) == "")
                {
                    dataGridView1["AQLStandard1", rowIndex].Value = "N/A";
                    dataGridView1["AQLReading1", rowIndex].Value = "N/A";

                    dataGridView1["AQLReading1", rowIndex].ReadOnly = true;
                    dataGridView1["AQLReading1", rowIndex].Style.BackColor = Color.FromKnownColor(KnownColor.LightGray);

                }
                else
                {
                    dataGridView1["AQLStandard1", rowIndex].Value = dsAll.Tables[0].Rows[0]["aql"];
                    dataGridView1["AQLReading1", rowIndex].Value = "";

                    dataGridView1["AQLReading1", rowIndex].ReadOnly = false;
                    dataGridView1["AQLReading1", rowIndex].Style.BackColor = Color.White;

                }

                if (Convert.ToString(dsAll.Tables[0].Rows[0]["aqlz"]) == "")
                {
                    dataGridView1["AQLzStandard1", rowIndex].Value = "N/A";
                    dataGridView1["AQLzReading1", rowIndex].Value = "N/A";

                    dataGridView1["AQLzReading1", rowIndex].ReadOnly = true;
                    dataGridView1["AQLzReading1", rowIndex].Style.BackColor = Color.FromKnownColor(KnownColor.LightGray);


                }
                else
                {
                    dataGridView1["AQLzStandard1", rowIndex].Value = dsAll.Tables[0].Rows[0]["aqlz"];
                    dataGridView1["AQLzReading1", rowIndex].Value = "";

                    dataGridView1["AQLzReading1", rowIndex].ReadOnly = false;
                    dataGridView1["AQLzReading1", rowIndex].Style.BackColor = Color.White;


                }

                if (Convert.ToString(dsAll.Tables[0].Rows[0]["aqlc"]) == "")
                {
                    dataGridView1["AQLcStandard1", rowIndex].Value = "N/A";
                    dataGridView1["AQLcReading1", rowIndex].Value = "N/A";

                    dataGridView1["AQLcReading1", rowIndex].ReadOnly = true;
                    dataGridView1["AQLcReading1", rowIndex].Style.BackColor = Color.FromKnownColor(KnownColor.LightGray);


                }
                else
                {
                    dataGridView1["AQLcStandard1", rowIndex].Value = dsAll.Tables[0].Rows[0]["aqlc"];
                    dataGridView1["AQLcReading1", rowIndex].Value = "";

                    dataGridView1["AQLcReading1", rowIndex].ReadOnly = false;
                    dataGridView1["AQLcReading1", rowIndex].Style.BackColor = Color.White;


                }

                if (Convert.ToString(dsAll.Tables[0].Rows[0]["aqlm"]) == "")
                {
                    dataGridView1["AQLMStandard1", rowIndex].Value = "N/A";
                    dataGridView1["AQLMReading1", rowIndex].Value = "N/A";

                    dataGridView1["AQLMReading1", rowIndex].ReadOnly = true;
                    dataGridView1["AQLMReading1", rowIndex].Style.BackColor = Color.FromKnownColor(KnownColor.LightGray);


                }
                else
                {
                    dataGridView1["AQLMStandard1", rowIndex].Value = dsAll.Tables[0].Rows[0]["aqlm"];
                    dataGridView1["AQLMReading1", rowIndex].Value = "";

                    dataGridView1["AQLMReading1", rowIndex].ReadOnly = false;
                    dataGridView1["AQLMReading1", rowIndex].Style.BackColor = Color.White;


                }

                if (Convert.ToString(dsAll.Tables[0].Rows[0]["aqlm1"]) == "")
                {
                    dataGridView1["AQLM1Standard1", rowIndex].Value = "N/A";
                    dataGridView1["AQLM1Reading1", rowIndex].Value = "N/A";

                    dataGridView1["AQLM1Reading1", rowIndex].ReadOnly = true;
                    dataGridView1["AQLM1Reading1", rowIndex].Style.BackColor = Color.FromKnownColor(KnownColor.LightGray);


                }
                else
                {
                    dataGridView1["AQLM1Standard1", rowIndex].Value = dsAll.Tables[0].Rows[0]["aqlm1"];
                    dataGridView1["AQLM1Reading1", rowIndex].Value = "";

                    dataGridView1["AQLM1Reading1", rowIndex].ReadOnly = false;
                    dataGridView1["AQLM1Reading1", rowIndex].Style.BackColor = Color.White;


                }
            }
        }

        #endregion

        private void btnbrowse_Click(object sender, EventArgs e)
        {
            string fileName = "", filePath = "";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                FinishedGoodTest_SubContract_Class_Obj.filepath = openFileDialog1.FileName;
                FinishedGoodTest_SubContract_Class_Obj.filename = System.IO.Path.GetFileName(FinishedGoodTest_SubContract_Class_Obj.filepath);
                txtBMR.Text = FinishedGoodTest_SubContract_Class_Obj.filename;
                FinishedGoodTest_SubContract_Class_Obj.FGPackingfilepath = null;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (FinishedGoodTest_SubContract_Class_Obj.FGPackingfilepath == "" || FinishedGoodTest_SubContract_Class_Obj.FGPackingfilepath == null)
            {
                MessageBox.Show("No file selected to view", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            //File.Open(FinishedGoodTest_SubContract_Class_Obj.bmrfilepath,FileMode.Open);
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            process.StartInfo = startInfo;

            startInfo.FileName = FinishedGoodTest_SubContract_Class_Obj.FGPackingfilepath;
            process.Start();
        }


    }
}