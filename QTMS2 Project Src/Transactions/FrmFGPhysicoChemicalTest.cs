/********************************************************
*Author: Vijay Tomake
*Date: 
*Description: Transaction form to enter finished good Physico chemical details
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
using QTMS.OOS;


namespace QTMS.Transactions
{
    public partial class FrmFGPhysicoChemicalTest : Form
    {
        public class Detail
        {
            public long D_fgtlfid;
            public long D_fno;
            public long D_pkgtechno;
            public string D_type;
            public string D_mfgwo;
            public string D_FormulaNo;
            public string D_phychestatus;
            public char Done;
        }

        public FrmFGPhysicoChemicalTest(FrmFGPhysicoChemicalTest.Detail Detail)
        {
            InitializeComponent();
            FinishedGoodTest_Class_Obj.fgtlfid = Detail.D_fgtlfid;
            FinishedGoodTest_Class_Obj.fno = Detail.D_fno;
            FinishedGoodTest_Class_Obj.pkgtechno = Detail.D_pkgtechno;
            FinishedGoodTest_Class_Obj.type = Detail.D_type;
            FinishedGoodTest_Class_Obj.mfgwo = Detail.D_mfgwo;
            FinishedGoodTest_Class_Obj.formulano = Detail.D_FormulaNo;
            FinishedGoodTest_Class_Obj.phychestatus = Detail.D_phychestatus;
            Done = Detail.Done;
        }

        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        BusinessFacade.Transactions.FinishedGoodTest_Class FinishedGoodTest_Class_Obj = new BusinessFacade.Transactions.FinishedGoodTest_Class();
        BusinessFacade.TankMaster_Class TankMaster_Class_Obj = new TankMaster_Class();
        BusinessFacade.UserManagement_Class UserManagement_Class_Obj = new BusinessFacade.UserManagement_Class();
        char Done;

        /// <summary>
        /// loads the form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmFGPhysicoChemicalTest_Load(object sender, EventArgs e)
        {
            Painter.Paint(this);

            //Changes Form Name
            this.Text = this.Text + " " + FinishedGoodTest_Class_Obj.formulano + "-" + FinishedGoodTest_Class_Obj.mfgwo;

            txtFormulaNo.Text = FinishedGoodTest_Class_Obj.formulano;
            txtMfgWo.Text = FinishedGoodTest_Class_Obj.mfgwo;

            DtpPhyDate.Value = Comman_Class_Obj.Select_ServerDate();

            Bind_InspectedBy();

            // insert record into tblFinishedGoodTestDetails with status = "";
            // After testing modify the status
            FinishedGoodTest_Class_Obj.status = "";

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

            //Set status selected
            if (FinishedGoodTest_Class_Obj.phychestatus == "A")
            {
                RdoAccepted.Checked = true;
            }
            else if (FinishedGoodTest_Class_Obj.phychestatus == "R")
            {
                RdoRejected.Checked = true;
            }
            else if (FinishedGoodTest_Class_Obj.phychestatus == "H")
            {
                RdoHold.Checked = true;
            }

            //Bink Tank Details
            Bind_Tank();

            //Display assigned tanks to Formula & mfgwo
            DataSet dsTk = new DataSet();
            dsTk = FinishedGoodTest_Class_Obj.Select_TankDetails_Formula_MfgWo();
            LstTank.DataSource = dsTk.Tables[0];
            LstTank.DisplayMember = dsTk.Tables[0].Columns["TkDesc"].ToString();

            //Get FMID 
            FinishedGoodTest_Class_Obj.fmid = FinishedGoodTest_Class_Obj.Select_tblTransFM_FMID();

            //Display tests applicable to Formula
            DataSet dsTests = new DataSet();
            DataSet dsDetails;
            //FinishedGoodTest_Class_Obj.fno            
            if (Done == 'N')
            {
                dsTests = FinishedGoodTest_Class_Obj.Select_tblFGPhysicochemicalTestMethodMaster_FNo();
            }
            else if (Done == 'Y')
            {
                dsTests = FinishedGoodTest_Class_Obj.Select_tblFGPhysicochemicalTestMethodDetails_FGTLFID_FMID_Tests();
            }

            if (dsTests.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsTests.Tables[0].Rows.Count; i++)
                {
                    if (dsTests.Tables[0].Rows[i]["TestType"].ToString() == "Identification")
                    {
                        dgIdTest.Rows.Add();
                        dgIdTest["FGPhyMethodNo", dgIdTest.Rows.Count - 1].Value = dsTests.Tables[0].Rows[i]["FGPhyMethodNo"].ToString();
                        dgIdTest["Test", dgIdTest.Rows.Count - 1].Value = dsTests.Tables[0].Rows[i]["Details"].ToString();
                        dgIdTest["Min", dgIdTest.Rows.Count - 1].Value = dsTests.Tables[0].Rows[i]["NormsMin"].ToString();
                        dgIdTest["Max", dgIdTest.Rows.Count - 1].Value = dsTests.Tables[0].Rows[i]["NormsMax"].ToString();

                        dsDetails = new DataSet();
                        FinishedGoodTest_Class_Obj.fgphymethodno = Convert.ToInt64(dgIdTest["FGPhyMethodNo", dgIdTest.Rows.Count - 1].Value);
                        dsDetails = FinishedGoodTest_Class_Obj.Select_tblFGPhysicochemicalTestMethodDetails_FGTLFID_FMID();
                        if (dsDetails.Tables[0].Rows.Count > 0)
                        {
                            DtpPhyDate.Value = Convert.ToDateTime(dsDetails.Tables[0].Rows[0]["PhyDate"]);
                            cmbInspectedBy.SelectedValue = Convert.ToInt32(dsDetails.Tables[0].Rows[0]["LoginID"]);
                            for (int r = 0; r < dsDetails.Tables[0].Rows.Count; r++)
                            {
                                if (!dgIdTest.Columns.Contains(dsDetails.Tables[0].Rows[r]["TankNo"].ToString()))
                                {
                                    dgIdTest.Columns.Add(dsDetails.Tables[0].Rows[r]["TankNo"].ToString(), dsDetails.Tables[0].Rows[r]["TkDesc"].ToString());
                                    dgConTest.Columns.Add(dsDetails.Tables[0].Rows[r]["TankNo"].ToString(), dsDetails.Tables[0].Rows[r]["TkDesc"].ToString());
                                }
                                dgIdTest[dsDetails.Tables[0].Rows[r]["TankNo"].ToString(), dgIdTest.Rows.Count - 1].Value = dsDetails.Tables[0].Rows[r]["NormsReading"].ToString();
                            }

                        }

                    }
                    else if (dsTests.Tables[0].Rows[i]["TestType"].ToString() == "Control")
                    {
                        dgConTest.Rows.Add();
                        dgConTest["FGPhyMethodNoCon", dgConTest.Rows.Count - 1].Value = dsTests.Tables[0].Rows[i]["FGPhyMethodNo"].ToString();
                        dgConTest["TestCon", dgConTest.Rows.Count - 1].Value = dsTests.Tables[0].Rows[i]["Details"].ToString();
                        dgConTest["MinCon", dgConTest.Rows.Count - 1].Value = dsTests.Tables[0].Rows[i]["NormsMin"].ToString();
                        dgConTest["MaxCon", dgConTest.Rows.Count - 1].Value = dsTests.Tables[0].Rows[i]["NormsMax"].ToString();

                        dsDetails = new DataSet();
                        FinishedGoodTest_Class_Obj.fgphymethodno = Convert.ToInt64(dgConTest["FGPhyMethodNoCon", dgConTest.Rows.Count - 1].Value);
                        dsDetails = FinishedGoodTest_Class_Obj.Select_tblFGPhysicochemicalTestMethodDetails_FGTLFID_FMID();
                        if (dsDetails.Tables[0].Rows.Count > 0)
                        {
                            for (int r = 0; r < dsDetails.Tables[0].Rows.Count; r++)
                            {
                                if (!dgConTest.Columns.Contains(dsDetails.Tables[0].Rows[r]["TankNo"].ToString()))
                                {
                                    dgIdTest.Columns.Add(dsDetails.Tables[0].Rows[r]["TankNo"].ToString(), dsDetails.Tables[0].Rows[r]["TkDesc"].ToString());
                                    dgConTest.Columns.Add(dsDetails.Tables[0].Rows[r]["TankNo"].ToString(), dsDetails.Tables[0].Rows[r]["TkDesc"].ToString());
                                }
                                dgConTest[dsDetails.Tables[0].Rows[r]["TankNo"].ToString(), dgConTest.Rows.Count - 1].Value = dsDetails.Tables[0].Rows[r]["NormsReading"].ToString();
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// BInd tanks to combo box
        /// </summary>
        public void Bind_Tank()
        {
            try
            {
                DataSet ds = new DataSet();
                DataRow dr;
                ds = TankMaster_Class_Obj.Select_TankMaster();
                dr = ds.Tables[0].NewRow();
                dr["TkDesc"] = "--Select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    CmbTank.DataSource = ds.Tables[0];
                    CmbTank.DisplayMember = "TkDesc";
                    CmbTank.ValueMember = "TankNo";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

        /// <summary>
        /// Saves the Method details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (GlobalVariables.City == "BADDI")
            {
                //bool Identification = false;
                for (int col = 4; col < dgIdTest.Columns.Count; col++)
                {
                    for (int i = 0; i < dgIdTest.Rows.Count; i++)
                    {
                        if (dgIdTest[col, i].Value == null || dgIdTest[col, i].Value.ToString().Trim() == "")
                        {
                            MessageBox.Show("Fill all the Identification Test Reading", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgIdTest.Focus();
                            return;
                        }
                        //else
                        //    Identification = true;

                    }
                }
                //bool Control = false;
                for (int col = 4; col < dgIdTest.Columns.Count; col++)
                {
                    for (int i = 0; i < dgConTest.Rows.Count; i++)
                    {
                        if (dgConTest[col, i].Value == null || dgConTest[col, i].Value.ToString().Trim() == "")
                        {
                            MessageBox.Show("Fill all the Control Test Reading", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgConTest.Focus();
                            return;
                        }
                        //else
                        //    Control = true;
                    }
                }
            }
            else
            {

                bool Identification = false;
                for (int col = 4; col < dgIdTest.Columns.Count; col++)
                {
                    for (int i = 0; i < dgIdTest.Rows.Count; i++)
                    {
                        if (dgIdTest[col, i].Value == null || dgIdTest[col, i].Value.ToString().Trim() == "")
                        {
                            //MessageBox.Show("Fill all the Identification Test Reading", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //dgIdTest.Focus();
                            //return;
                        }
                        else
                            Identification = true;

                    }
                }
                bool Control = false;
                for (int col = 4; col < dgIdTest.Columns.Count; col++)
                {
                    for (int i = 0; i < dgConTest.Rows.Count; i++)
                    {
                        if (dgConTest[col, i].Value == null || dgConTest[col, i].Value.ToString().Trim() == "")
                        {
                            //MessageBox.Show("Fill all the Control Test Reading", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //dgConTest.Focus();
                            //return;
                        }
                        else
                            Control = true;
                    }
                }

                if (Identification == false)
                {
                    MessageBox.Show("Fill any tank Identification Test Reading", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgIdTest.Focus();
                    return;
                }
                if (Control == false)
                {
                    MessageBox.Show("Fill any tank Control Test Reading", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgConTest.Focus();
                    return;
                }
            }
            

            if (RdoAccepted.Checked == false && RdoRejected.Checked == false && RdoHold.Checked == false)
            {
                MessageBox.Show("Select Accept/Reject/Hold option ...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //RdoAccepted.Focus();
                return;
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
            if (dgIdTest.Columns.Count <= 4)
            {
                MessageBox.Show("Please add at least one tank");
                CmbTank.Focus();
                return;

            }
            if (cmbInspectedBy.SelectedValue == null || cmbInspectedBy.Text == "--Select--")
            {
                MessageBox.Show("Please Select Inspected By", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbInspectedBy.Focus();
                return;
            }

            if (RdoAccepted.Checked == true)
            {
                FinishedGoodTest_Class_Obj.phychestatus = Convert.ToString("A");
            }
            else if (RdoRejected.Checked == true)
            {
                FinishedGoodTest_Class_Obj.phychestatus = Convert.ToString("R");
            }
            else if (RdoHold.Checked == true)
            {
                FinishedGoodTest_Class_Obj.phychestatus = Convert.ToString("H");
            }
            FinishedGoodTest_Class_Obj.inspectedby = Convert.ToInt32(cmbInspectedBy.SelectedValue);

            FinishedGoodTest_Class_Obj.loginid = FrmMain.LoginID;

            FinishedGoodTest_Class_Obj.phydate = DtpPhyDate.Value.ToShortDateString();

            DataSet ds = new DataSet();
            ds = FinishedGoodTest_Class_Obj.Select_tblFinishedGoodPhyCheDetails_FGTLFID();
            if (ds.Tables[0].Rows.Count > 0)
            {
                //update physico chemical result
                //FinishedGoodTest_Class_Obj.fgphycheno = Convert.ToInt64(ds.Tables[0].Rows[0]["FGPhyCheNo"].ToString());
                FinishedGoodTest_Class_Obj.fgphycheno = FinishedGoodTest_Class_Obj.Update_tblFinishedGoodPhyCheDetails();
            }
            else
            {
                //insert physico chemical result 
                //--------- Insert  FGTestNo, FMID, PhyCheStatus into tblFinishedGoodPhyCheDetails
                FinishedGoodTest_Class_Obj.fgphycheno = FinishedGoodTest_Class_Obj.Insert_tblFinishedGoodPhyCheDetails();
            }

            //Delete already added details
            FinishedGoodTest_Class_Obj.Delete_tblFGPhysicochemicalTestMethodDetails_FGPhyCheNo();

            //Insert identification tests tblFGPhysicochemicalTestMethodDetails
            for (int col = 4; col < dgIdTest.Columns.Count; col++)
            {
                for (int i = 0; i < dgIdTest.Rows.Count; i++)
                {
                    FinishedGoodTest_Class_Obj.fgphymethodno = Convert.ToInt64(dgIdTest["FGPhyMethodNo", i].Value);
                    FinishedGoodTest_Class_Obj.tankno = Convert.ToInt16(dgIdTest.Columns[col].Name);
                    if (dgIdTest["Min", i].Value == null)
                    {
                        FinishedGoodTest_Class_Obj.normmin = "";
                    }
                    else
                    {
                        FinishedGoodTest_Class_Obj.normmin = dgIdTest["Min", i].Value.ToString();
                    }

                    if (dgIdTest["Max", i].Value == null)
                    {
                        FinishedGoodTest_Class_Obj.normmax = "";
                    }
                    else
                    {
                        FinishedGoodTest_Class_Obj.normmax = dgIdTest["Max", i].Value.ToString();
                    }
                    if (dgIdTest[col, i].Value == null || dgIdTest[col, i].Value.ToString().Trim() == "")
                    {
                        FinishedGoodTest_Class_Obj.reading = "";
                    }
                    else
                    {
                        FinishedGoodTest_Class_Obj.reading = dgIdTest[col, i].Value.ToString();
                    }
                    FinishedGoodTest_Class_Obj.Insert_tblFGPhysicochemicalTestMethodDetails();
                }
            }

            //Insert Control tests tblFGPhysicochemicalTestMethodDetails

            for (int col = 4; col < dgIdTest.Columns.Count; col++)
            {
                for (int i = 0; i < dgConTest.Rows.Count; i++)
                {
                    FinishedGoodTest_Class_Obj.fgphymethodno = Convert.ToInt64(dgConTest["FGPhyMethodNoCon", i].Value);
                    FinishedGoodTest_Class_Obj.tankno = Convert.ToInt16(dgIdTest.Columns[col].Name);
                    if (dgConTest["MinCon", i].Value == null)
                    {
                        FinishedGoodTest_Class_Obj.normmin = "";
                    }
                    else
                    {
                        FinishedGoodTest_Class_Obj.normmin = dgConTest["MinCon", i].Value.ToString();
                    }

                    if (dgConTest["MaxCon", i].Value == null)
                    {
                        FinishedGoodTest_Class_Obj.normmax = "";
                    }
                    else
                    {
                        FinishedGoodTest_Class_Obj.normmax = dgConTest["MaxCon", i].Value.ToString();
                    }
                    if (dgConTest[col, i].Value == null || dgConTest[col, i].Value.ToString().Trim() == "")
                    {
                        FinishedGoodTest_Class_Obj.reading = "";
                    }
                    else
                    {
                        FinishedGoodTest_Class_Obj.reading = dgConTest[col, i].Value.ToString();
                    }

                    FinishedGoodTest_Class_Obj.Insert_tblFGPhysicochemicalTestMethodDetails();
                }
            }


            if (MessageBox.Show("Test Details saved Successfully..!\n\nPrint Protocol?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes))
            {
                btnProtocol_Click(sender, e);
            }

            this.Close();

        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgTest_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgIdTest.CurrentCell.RowIndex >= 0
                || (dgIdTest.CurrentCell.ColumnIndex >= 4))
            {
                dgIdTest.EditingControl.KeyPress += new KeyPressEventHandler(EditingControl_KeyPress);
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

        private void dgConTest_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgConTest.CurrentCell.RowIndex >= 0
                || (dgConTest.CurrentCell.ColumnIndex >= 4))
            {
                dgConTest.EditingControl.KeyPress += new KeyPressEventHandler(EditingControl_KeyPress);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (CmbTank.Text == "--Select--")
            {
                MessageBox.Show("Select Tank...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                CmbTank.Focus();
                return;
            }
            else
            {
                for (int i = 4; i < dgIdTest.Columns.Count; i++)
                {
                    if (dgIdTest.Columns[i].Name == CmbTank.SelectedValue.ToString())
                    {
                        MessageBox.Show("This Tank already Exists...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.None);
                        CmbTank.Focus();
                        return;
                    }
                }

                dgIdTest.Columns.Add(CmbTank.SelectedValue.ToString(), CmbTank.Text);
                dgConTest.Columns.Add(CmbTank.SelectedValue.ToString(), CmbTank.Text);

                CmbTank.Text = "--Select--";
            }
        }

        private void btnProtocol_Click(object sender, EventArgs e)
        {
            if (cmbInspectedBy.SelectedValue == null || cmbInspectedBy.Text == "--Select--")
            {
                MessageBox.Show("Please Select Inspected By", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbInspectedBy.Focus();
                return;
            }

            string ProtocolNo = "FGB" + FinishedGoodTest_Class_Obj.fgtestno.ToString().PadLeft(6, '0');

            DataSet ds = new DataSet();
            ds = FinishedGoodTest_Class_Obj.Select_View_Protocol_FGPackingDetails_PhyChe();

            DataTable dt = new DataTable();
            string[] TankName = new string[6];
            int T = 1;
            foreach (DataGridViewColumn col in dgIdTest.Columns)
            {
                if (col.Index > 3)
                {
                    TankName[T-1] = col.HeaderText;
                    dt.Columns.Add(T.ToString());
                    T++;
                    
                }
                else
                    dt.Columns.Add(col.HeaderText);
            }

            foreach (DataGridViewRow row in dgIdTest.Rows)
            {
                DataRow dRow = dt.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                dt.Rows.Add(dRow);
            }

            T = 1;
            DataTable dt1 = new DataTable();
            foreach (DataGridViewColumn col in dgConTest.Columns)
            {
                if (col.Index > 3)
                {
                    //TankName[T - 1] = col.HeaderText;
                    dt1.Columns.Add(T.ToString());
                    T++;

                }
                else
                    dt1.Columns.Add(col.HeaderText);
            }

            foreach (DataGridViewRow row in dgConTest.Rows)
            {
                DataRow dRow = dt1.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                dt1.Rows.Add(dRow);
            }


            /*
            DataTable dt = new DataTable();
            dt.Columns.Add("Test");
            dt.Columns.Add("Min");
            dt.Columns.Add("Max");

            DataRow dr;
            for (int i = 0; i < dgIdTest.Rows.Count; i++)
            {
                dr = dt.NewRow();
                dr["Test"] = dgIdTest["Test", i].Value;
                dr["Min"] = dgIdTest["Min", i].Value;
                dr["Max"] = dgIdTest["Max", i].Value;
                dt.Rows.InsertAt(dr, i);
            }

            DataTable dt1 = new DataTable();
            dt1.Columns.Add("Test");
            dt1.Columns.Add("Min");
            dt1.Columns.Add("Max");

            DataRow dr1;
            for (int i = 0; i < dgConTest.Rows.Count; i++)
            {
                dr1 = dt1.NewRow();
                dr1["Test"] = dgConTest["TestCon", i].Value;
                dr1["Min"] = dgConTest["MinCon", i].Value;
                dr1["Max"] = dgConTest["MaxCon", i].Value;
                dt1.Rows.InsertAt(dr1, i);
            }
            */
            /*
            DataTable dt = new DataTable();
            dt.Columns.Add("Test");
            dt.Columns.Add("Min");
            dt.Columns.Add("Max");
            dt.Columns.Add("Tank");
            dt.Columns.Add("Result");

            int row = 0;
            DataRow dr;
            for (int i = 0; i < dgIdTest.Rows.Count; i++)
            {
                if (dgIdTest.Columns.Count > 4)
                {
                    for (int j = 4; j < dgIdTest.Columns.Count; j++)
                    {
                        dr = dt.NewRow();
                        dr["Test"] = dgIdTest["Test", i].Value;
                        dr["Min"] = dgIdTest["Min", i].Value;
                        dr["Max"] = dgIdTest["Max", i].Value;

                        dr["Tank"] = dgIdTest.Columns[j].HeaderText;
                        dr["Result"] = dgIdTest[j, i].Value;

                        dt.Rows.InsertAt(dr, row);
                        row++;
                    }
                }
                else
                {
                    dr = dt.NewRow();
                    dr["Test"] = dgIdTest["Test", i].Value;
                    dr["Min"] = dgIdTest["Min", i].Value;
                    dr["Max"] = dgIdTest["Max", i].Value;
                    dt.Rows.InsertAt(dr, row);
                    row++;
                }

                
            }

            row = 0;
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("Test");
            dt1.Columns.Add("Min");
            dt1.Columns.Add("Max");
            dt1.Columns.Add("Tank");
            dt1.Columns.Add("Result");

            DataRow dr1;
            for (int i = 0; i < dgConTest.Rows.Count; i++)
            {
                if (dgConTest.Columns.Count > 4)
                {
                    for (int j = 4; j < dgConTest.Columns.Count; j++)
                    {
                        dr1 = dt1.NewRow();
                        dr1["Test"] = dgConTest["TestCon", i].Value;
                        dr1["Min"] = dgConTest["MinCon", i].Value;
                        dr1["Max"] = dgConTest["MaxCon", i].Value;

                        dr1["Tank"] = dgConTest.Columns[j].HeaderText;
                        dr1["Result"] = dgConTest[j, i].Value;

                        dt1.Rows.InsertAt(dr1, row);
                        row++;
                    }
                }
                else
                {
                    dr1 = dt1.NewRow();
                    dr1["Test"] = dgConTest["TestCon", i].Value;
                    dr1["Min"] = dgConTest["MinCon", i].Value;
                    dr1["Max"] = dgConTest["MaxCon", i].Value;
                    dt1.Rows.InsertAt(dr1, row);
                    row++;
                }
            }
            */

            string PT1 = TankName[0];
            string PT2 = TankName[1];
            string PT3 = TankName[2];
            string PT4 = TankName[3];
            string PT5 = TankName[4];
            string PT6 = TankName[5];


            QTMS.Reports_Forms.FrmProtocol_FGPhysicoChemical fm = new QTMS.Reports_Forms.FrmProtocol_FGPhysicoChemical("FG PhysicoChemical Protocol", ds, dt, dt1, txtFormulaNo.Text.Trim(), txtMfgWo.Text.Trim(), ProtocolNo, cmbInspectedBy.Text.Trim(),PT1,PT2,PT3,PT4,PT5,PT6);
            fm.ShowDialog();
        }

        private void dgIdTest_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 4)
            {
                return;
            }
            else
            {
                string TankNo = dgIdTest.Columns[e.ColumnIndex].Name;

                if (dgIdTest.CurrentCell.EditedFormattedValue.ToString().Trim() != "")
                {
                    if (dgIdTest["Max", dgIdTest.CurrentCell.RowIndex].Value.ToString().Trim() == "" && dgIdTest["Min", dgIdTest.CurrentCell.RowIndex].Value.ToString().Trim() == "")
                    {
                        dgIdTest.CurrentCell.Style.BackColor = Color.Red;
                        if (GlobalVariables.City == "BADDI")
                            OOS_Begin(dgIdTest["FGPhyMethodNo", dgIdTest.CurrentCell.RowIndex].Value.ToString().Trim(), dgIdTest["Test", dgIdTest.CurrentCell.RowIndex].Value.ToString().Trim(), TankNo);
                        return;
                    }

                    if (dgIdTest["Max", dgIdTest.CurrentCell.RowIndex].Value != null && dgIdTest["Max", dgIdTest.CurrentCell.RowIndex].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dgIdTest.CurrentCell.EditedFormattedValue) > Convert.ToDouble(dgIdTest["Max", dgIdTest.CurrentCell.RowIndex].Value))
                        {
                            dgIdTest.CurrentCell.Style.BackColor = Color.Red;
                            if (GlobalVariables.City == "BADDI")
                                OOS_Begin(dgIdTest["FGPhyMethodNo", dgIdTest.CurrentCell.RowIndex].Value.ToString().Trim(), dgIdTest["Test", dgIdTest.CurrentCell.RowIndex].Value.ToString().Trim(), TankNo);
                            return;
                        }
                        else
                        {
                            dgIdTest.CurrentCell.Style.BackColor = Color.White;
                        }
                    }

                    if (dgIdTest["Min", dgIdTest.CurrentCell.RowIndex].Value != null && dgIdTest["Min", dgIdTest.CurrentCell.RowIndex].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dgIdTest.CurrentCell.EditedFormattedValue) < Convert.ToDouble(dgIdTest["Min", dgIdTest.CurrentCell.RowIndex].Value))
                        {
                            dgIdTest.CurrentCell.Style.BackColor = Color.Red;
                            if (GlobalVariables.City == "BADDI")
                                OOS_Begin(dgIdTest["FGPhyMethodNo", dgIdTest.CurrentCell.RowIndex].Value.ToString().Trim(), dgIdTest["Test", dgIdTest.CurrentCell.RowIndex].Value.ToString().Trim(), TankNo);
                            return;
                        }
                        else
                        {
                            dgIdTest.CurrentCell.Style.BackColor = Color.White;
                        }
                    }
                }
                else
                {
                    dgIdTest.CurrentCell.Style.BackColor = Color.White;
                }

            }
        }

        private void dgIdTest_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 4)
            {
                return;
            }
            else
            {
                for (int i = 0; i < dgIdTest.Rows.Count; i++)
                {
                    for (int j = 4; j < dgIdTest.Columns.Count; j++)
                    {
                        if (dgIdTest[j, i].Style.BackColor == Color.Red)
                        {
                            RdoRejected.Checked = true;
                            return;
                        }
                        else
                        {
                            RdoAccepted.Checked = true;
                        }
                    }
                }

                for (int i = 0; i < dgConTest.Rows.Count; i++)
                {
                    for (int j = 4; j < dgConTest.Columns.Count; j++)
                    {
                        if (dgConTest[j, i].Style.BackColor == Color.Red)
                        {
                            RdoRejected.Checked = true;
                            return;
                        }
                        else
                        {
                            RdoAccepted.Checked = true;
                        }
                    }
                }
            }
        }

        private void dgConTest_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 4)
            {
                return;
            }
            else
            {
                string TankNo = dgConTest.Columns[e.ColumnIndex].Name;
                if (dgConTest.CurrentCell.EditedFormattedValue.ToString().Trim() != "")
                {
                    if (dgConTest["MaxCon", dgConTest.CurrentCell.RowIndex].Value.ToString().Trim() == "" && dgConTest["MinCon", dgConTest.CurrentCell.RowIndex].Value.ToString().Trim() == "")
                    {
                        dgConTest.CurrentCell.Style.BackColor = Color.Red;
                        if (GlobalVariables.City == "BADDI")
                            OOS_Begin(dgConTest["FGPhyMethodNoCon", dgConTest.CurrentCell.RowIndex].Value.ToString().Trim(), dgConTest["TestCon", dgConTest.CurrentCell.RowIndex].Value.ToString().Trim(), TankNo);
                        return;
                    }

                    if (dgConTest["MaxCon", dgConTest.CurrentCell.RowIndex].Value != null && dgConTest["MaxCon", dgConTest.CurrentCell.RowIndex].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dgConTest.CurrentCell.EditedFormattedValue) > Convert.ToDouble(dgConTest["MaxCon", dgConTest.CurrentCell.RowIndex].Value))
                        {
                            dgConTest.CurrentCell.Style.BackColor = Color.Red;
                            if (GlobalVariables.City == "BADDI")
                                OOS_Begin(dgConTest["FGPhyMethodNoCon", dgConTest.CurrentCell.RowIndex].Value.ToString().Trim(), dgConTest["TestCon", dgConTest.CurrentCell.RowIndex].Value.ToString().Trim(), TankNo);
                            return;
                        }
                        else
                        {
                            dgConTest.CurrentCell.Style.BackColor = Color.White;
                        }
                    }

                    if (dgConTest["MinCon", dgConTest.CurrentCell.RowIndex].Value != null && dgConTest["MinCon", dgConTest.CurrentCell.RowIndex].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dgConTest.CurrentCell.EditedFormattedValue) < Convert.ToDouble(dgConTest["MinCon", dgConTest.CurrentCell.RowIndex].Value))
                        {
                            dgConTest.CurrentCell.Style.BackColor = Color.Red;
                            if (GlobalVariables.City == "BADDI")
                                OOS_Begin(dgConTest["FGPhyMethodNoCon", dgConTest.CurrentCell.RowIndex].Value.ToString().Trim(), dgConTest["TestCon", dgConTest.CurrentCell.RowIndex].Value.ToString().Trim(), TankNo);
                            return;
                        }
                        else
                        {
                            dgConTest.CurrentCell.Style.BackColor = Color.White;
                        }
                    }
                }
                else
                {
                    dgConTest.CurrentCell.Style.BackColor = Color.White;
                }

            }
        }

        private void dgConTest_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 4)
            {
                return;
            }
            else
            {
                for (int i = 0; i < dgIdTest.Rows.Count; i++)
                {
                    for (int j = 4; j < dgIdTest.Columns.Count; j++)
                    {
                        if (dgIdTest[j, i].Style.BackColor == Color.Red)
                        {
                            RdoRejected.Checked = true;
                            return;
                        }
                        else
                        {
                            RdoAccepted.Checked = true;
                        }
                    }
                }

                for (int i = 0; i < dgConTest.Rows.Count; i++)
                {
                    for (int j = 4; j < dgConTest.Columns.Count; j++)
                    {
                        if (dgConTest[j, i].Style.BackColor == Color.Red)
                        {
                            RdoRejected.Checked = true;
                            return;
                        }
                        else
                        {
                            RdoAccepted.Checked = true;
                        }
                    }
                }
            }
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OOS_Begin(string BulkMethodNo, string testname, string TankNo)
        {

            FrmOOSDetails.Detail detail_Obj = new FrmOOSDetails.Detail();

            detail_Obj.D_formname = "FG";
            //detail_Obj.D_productname = txtDescription.Text.Trim();
            detail_Obj.D_mfgwo = txtMfgWo.Text.Trim();
            detail_Obj.D_bulkmethodno = Convert.ToInt64(BulkMethodNo);
            detail_Obj.D_testname = testname;
            detail_Obj.D_fno = FinishedGoodTest_Class_Obj.fno;
            detail_Obj.D_tankno = Convert.ToInt32(BulkMethodNo);

            FormulaNoMaster_Class FormulaNoMaster_Class_Obj = new FormulaNoMaster_Class();

            DataSet ds = new DataSet();
            FormulaNoMaster_Class_Obj.fno = FinishedGoodTest_Class_Obj.fno;
            ds = FormulaNoMaster_Class_Obj.SELECT_TblBulkMaster_tblblkfamilyMaster();

            if (ds.Tables[0].Rows.Count > 0)
            {
                detail_Obj.D_productname = Convert.ToString(ds.Tables[0].Rows[0]["bulkdesc"]);
            }


            if (txtMfgWo.Text.StartsWith("WO") && txtMfgWo.Text.Length == 12)
            {
                detail_Obj.D_batchnumber = "B82" + txtMfgWo.Text.Substring(txtMfgWo.Text.Length - 5);
            }

            FrmOOSDetails frmOOS = new FrmOOSDetails(detail_Obj);
            frmOOS.ShowDialog();


        }


    }
}