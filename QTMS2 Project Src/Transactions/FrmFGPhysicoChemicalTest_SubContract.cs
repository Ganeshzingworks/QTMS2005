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
    public partial class FrmFGPhysicoChemicalTest_SubContract : Form
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
            public string D_COC;
            public long D_fmid;
            public long D_inspectedby;
            public long D_SupplierID;
            public bool D_physicochemical;
        }

        public FrmFGPhysicoChemicalTest_SubContract(FrmFGPhysicoChemicalTest_SubContract.Detail Detail)
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

            FinishedGoodTest_SubContract_Class_Obj.fgtlfid = Detail.D_fgtlfid;
            FinishedGoodTest_SubContract_Class_Obj.fno = Detail.D_fno;
            FinishedGoodTest_SubContract_Class_Obj.pkgtechno = Detail.D_pkgtechno;
            FinishedGoodTest_SubContract_Class_Obj.type = Detail.D_type;
            FinishedGoodTest_SubContract_Class_Obj.mfgwo = Detail.D_mfgwo;
            FinishedGoodTest_SubContract_Class_Obj.formulano = Detail.D_FormulaNo;
            FinishedGoodTest_SubContract_Class_Obj.phychestatus = Detail.D_phychestatus;
            FinishedGoodTest_SubContract_Class_Obj.coc = Detail.D_COC;
            FinishedGoodTest_SubContract_Class_Obj.fmid = Detail.D_fmid;
            FinishedGoodTest_SubContract_Class_Obj.inspectedby = Detail.D_inspectedby;
            FinishedGoodTest_SubContract_Class_Obj.physicochemical = Detail.D_physicochemical;
        }
        BusinessFacade.SubContractor_Class.FinishedGoodTest_SubContract_Class FinishedGoodTest_SubContract_Class_Obj =
            new BusinessFacade.SubContractor_Class.FinishedGoodTest_SubContract_Class();
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
        private void FrmFGPhysicoChemicalTest_SubContract_Load(object sender, EventArgs e)
        {
            Painter.Paint(this);

            //Changes Form Name
            this.Text = this.Text + " " + FinishedGoodTest_Class_Obj.formulano + "-" + FinishedGoodTest_Class_Obj.mfgwo;

            txtFormulaNo.Text = FinishedGoodTest_Class_Obj.formulano;
            txtMfgWo.Text = FinishedGoodTest_Class_Obj.mfgwo;

            Bind_InspectedBy();

            if (FinishedGoodTest_SubContract_Class_Obj.type == "Regular")
                BtnSave.Visible = false;

            // insert record into tblFinishedGoodTestDetails with status = "";
            // After testing modify the status
            FinishedGoodTest_SubContract_Class_Obj.status = "";

            DataSet ds1 = new DataSet();
            //Select FGTestNo from FGTLFID
            ds1 = FinishedGoodTest_SubContract_Class_Obj.Select_tblFinishedGoodDetails_FGTLFID_SubContract();
            if (ds1.Tables[0].Rows.Count > 0)
            {
                FinishedGoodTest_SubContract_Class_Obj.fgtestno = Convert.ToInt64(ds1.Tables[0].Rows[0]["FGTestNo"]);

            }
            else
            {
                //Insert Status = "", ControlType, CurrentFlag=1 into tblFinishedGoodDetails
                FinishedGoodTest_SubContract_Class_Obj.currentflag = 1;
                FinishedGoodTest_SubContract_Class_Obj.fgtestno = FinishedGoodTest_SubContract_Class_Obj.INSERT_FinishedGood_Status_SubContract();
            }

            //Set status selected
            if (FinishedGoodTest_SubContract_Class_Obj.phychestatus == "A")
            {
                RdoAccepted.Checked = true;
            }
            else if (FinishedGoodTest_SubContract_Class_Obj.phychestatus == "R")
            {
                RdoRejected.Checked = true;
            }
            else if (FinishedGoodTest_SubContract_Class_Obj.phychestatus == "H")
            {
                RdoHold.Checked = true;
            }

            //Bink Tank Details
            Bind_Tank();

            /*   //Display assigned tanks to Formula & mfgwo
               DataSet dsTk = new DataSet();
               dsTk = FinishedGoodTest_Class_Obj.Select_TankDetails_Formula_MfgWo();
               LstTank.DataSource = dsTk.Tables[0];
               LstTank.DisplayMember = dsTk.Tables[0].Columns["TkDesc"].ToString();

               //Get FMID 
               FinishedGoodTest_Class_Obj.fmid = FinishedGoodTest_Class_Obj.Select_tblTransFM_FMID();
               */
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
                dsTests = FinishedGoodTest_SubContract_Class_Obj.Select_tblFGPhysicochemicalTestMethodDetails_FGTLFID_FMID_Tests_SubContract();
                cmbInspectedBy.SelectedValue = FinishedGoodTest_SubContract_Class_Obj.inspectedby;
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
                        if (Done == 'Y')
                        {
                            dgIdTest["LorealResult", dgIdTest.Rows.Count - 1].Value = dsTests.Tables[0].Rows[i]["LorealResult"].ToString();
                            dgIdTest["SupplierResult", dgIdTest.Rows.Count - 1].Value = dsTests.Tables[0].Rows[i]["SupplierResult"].ToString();
                        }
                        //dsDetails = new DataSet();
                        //FinishedGoodTest_Class_Obj.fgphymethodno = Convert.ToInt64(dgIdTest["FGPhyMethodNo", dgIdTest.Rows.Count - 1].Value);
                        //dsDetails = FinishedGoodTest_Class_Obj.Select_tblFGPhysicochemicalTestMethodDetails_FGTLFID_FMID();
                        //if (dsDetails.Tables[0].Rows.Count > 0)
                        //{
                        //    for (int r = 0; r < dsDetails.Tables[0].Rows.Count; r++)
                        //    {
                        //        if (!dgIdTest.Columns.Contains(dsDetails.Tables[0].Rows[r]["TankNo"].ToString()))
                        //        {
                        //            dgIdTest.Columns.Add(dsDetails.Tables[0].Rows[r]["TankNo"].ToString(), dsDetails.Tables[0].Rows[r]["TkDesc"].ToString());
                        //            dgConTest.Columns.Add(dsDetails.Tables[0].Rows[r]["TankNo"].ToString(), dsDetails.Tables[0].Rows[r]["TkDesc"].ToString());                                    
                        //        }
                        //        dgIdTest[dsDetails.Tables[0].Rows[r]["TankNo"].ToString(), dgIdTest.Rows.Count - 1].Value = dsDetails.Tables[0].Rows[r]["NormsReading"].ToString();
                        //    }

                        //}

                    }
                    else if (dsTests.Tables[0].Rows[i]["TestType"].ToString() == "Control")
                    {
                        dgConTest.Rows.Add();
                        dgConTest["FGPhyMethodNoCon", dgConTest.Rows.Count - 1].Value = dsTests.Tables[0].Rows[i]["FGPhyMethodNo"].ToString();
                        dgConTest["TestCon", dgConTest.Rows.Count - 1].Value = dsTests.Tables[0].Rows[i]["Details"].ToString();
                        dgConTest["MinCon", dgConTest.Rows.Count - 1].Value = dsTests.Tables[0].Rows[i]["NormsMin"].ToString();
                        dgConTest["MaxCon", dgConTest.Rows.Count - 1].Value = dsTests.Tables[0].Rows[i]["NormsMax"].ToString();
                        if (Done == 'Y')
                        {
                            dgConTest["LorealResult1", dgConTest.Rows.Count - 1].Value = dsTests.Tables[0].Rows[i]["LorealResult"].ToString();
                            dgConTest["SupplierResult1", dgConTest.Rows.Count - 1].Value = dsTests.Tables[0].Rows[i]["SupplierResult"].ToString();
                        }

                        //dsDetails = new DataSet();
                        //FinishedGoodTest_Class_Obj.fgphymethodno = Convert.ToInt64(dgConTest["FGPhyMethodNoCon", dgConTest.Rows.Count - 1].Value);
                        //dsDetails = FinishedGoodTest_Class_Obj.Select_tblFGPhysicochemicalTestMethodDetails_FGTLFID_FMID();
                        //if (dsDetails.Tables[0].Rows.Count > 0)
                        //{
                        //    for (int r = 0; r < dsDetails.Tables[0].Rows.Count; r++)
                        //    {
                        //        if (!dgConTest.Columns.Contains(dsDetails.Tables[0].Rows[r]["TankNo"].ToString()))
                        //        {
                        //            dgIdTest.Columns.Add(dsDetails.Tables[0].Rows[r]["TankNo"].ToString(), dsDetails.Tables[0].Rows[r]["TkDesc"].ToString());
                        //            dgConTest.Columns.Add(dsDetails.Tables[0].Rows[r]["TankNo"].ToString(), dsDetails.Tables[0].Rows[r]["TkDesc"].ToString());                                    
                        //        }
                        //        dgConTest[dsDetails.Tables[0].Rows[r]["TankNo"].ToString(), dgConTest.Rows.Count - 1].Value = dsDetails.Tables[0].Rows[r]["NormsReading"].ToString();
                        //    }
                        //}
                    }
                }

                if (Done == 'Y')
                {
                    FillColorGrid();
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
            //for (int col = 4; col < dgIdTest.Columns.Count; col++)
            //{

            #region this code for Baddi
            if (GlobalVariables.City.ToUpper() == "BADDI")
            {
                if (FinishedGoodTest_SubContract_Class_Obj.physicochemical == true)
                {
                    for (int i = 0; i < dgIdTest.Rows.Count; i++)
                    {
                        if (dgIdTest[5, i].Value == null || dgIdTest[5, i].Value.ToString().Trim() == "")
                        {
                            MessageBox.Show("Fill all the Identification Supplier Test Reading", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgIdTest.Focus();
                            return;
                        }
                    }

                    for (int i = 0; i < dgConTest.Rows.Count; i++)
                    {
                        if (dgConTest[5, i].Value == null || dgConTest[5, i].Value.ToString().Trim() == "")
                        {
                            MessageBox.Show("Fill all the Control Supplier Test Reading", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgConTest.Focus();
                            return;
                        }
                    }
                }
            }
            #endregion



            #region this code for pune
            if (GlobalVariables.City.ToUpper() != "BADDI")
            {
                if (FinishedGoodTest_SubContract_Class_Obj.coc == "Yes")
                {
                    if (FinishedGoodTest_SubContract_Class_Obj.physicochemical == true)
                    {
                        for (int i = 0; i < dgIdTest.Rows.Count; i++)
                        {
                            if (dgIdTest[5, i].Value == null || dgIdTest[5, i].Value.ToString().Trim() == "")
                            {
                                MessageBox.Show("Fill all the Identification Supplier Test Reading", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                dgIdTest.Focus();
                                return;
                            }
                        }

                        for (int i = 0; i < dgConTest.Rows.Count; i++)
                        {
                            if (dgConTest[5, i].Value == null || dgConTest[5, i].Value.ToString().Trim() == "")
                            {
                                MessageBox.Show("Fill all the Control Supplier Test Reading", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                dgConTest.Focus();
                                return;
                            }
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < dgIdTest.Rows.Count; i++)
                    {
                        if (dgIdTest[4, i].Value == null || dgIdTest[4, i].Value.ToString().Trim() == "")
                        {
                            MessageBox.Show("Fill all the Identification L'oreal Test Reading", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgIdTest.Focus();
                            return;
                        }
                    }

                    for (int i = 0; i < dgConTest.Rows.Count; i++)
                    {
                        if (dgConTest[4, i].Value == null || dgConTest[4, i].Value.ToString().Trim() == "")
                        {
                            MessageBox.Show("Fill all the Control L'oreal Test Reading", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dgConTest.Focus();
                            return;
                        }
                    }
                }
            }
            #endregion
            //}
            /*for (int col = 4; col < dgIdTest.Columns.Count; col++)
            {
                for (int i = 0; i < dgConTest.Rows.Count; i++)
                {
                    if (dgConTest[col, i].Value == null || dgConTest[col, i].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Fill all the Control Test Reading", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgConTest.Focus();
                        return;
                    }
                }
           }*/

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
                FinishedGoodTest_SubContract_Class_Obj.phychestatus = Convert.ToString("A");
            }
            else if (RdoRejected.Checked == true)
            {
                FinishedGoodTest_SubContract_Class_Obj.phychestatus = Convert.ToString("R");
            }
            else if (RdoHold.Checked == true)
            {
                FinishedGoodTest_SubContract_Class_Obj.phychestatus = Convert.ToString("H");
            }
            FinishedGoodTest_SubContract_Class_Obj.inspectedby = Convert.ToInt32(cmbInspectedBy.SelectedValue);

            FinishedGoodTest_SubContract_Class_Obj.loginid = FrmMain.LoginID;

            DataSet ds = new DataSet();
            ds = FinishedGoodTest_SubContract_Class_Obj.Select_tblFinishedGoodPhyCheDetails_SubContract_FGTLFID();
            if (ds.Tables[0].Rows.Count > 0)
            {
                //update physico chemical result
                //FinishedGoodTest_Class_Obj.fgphycheno = Convert.ToInt64(ds.Tables[0].Rows[0]["FGPhyCheNo"].ToString());
                FinishedGoodTest_SubContract_Class_Obj.fgphycheno = FinishedGoodTest_SubContract_Class_Obj.Update_tblFinishedGoodPhyCheDetails_SubContract();
            }
            else
            {
                //insert physico chemical result 
                //--------- Insert  FGTestNo, FMID, PhyCheStatus into tblFinishedGoodPhyCheDetails
                FinishedGoodTest_SubContract_Class_Obj.fgphycheno = FinishedGoodTest_SubContract_Class_Obj.Insert_tblFinishedGoodPhyCheDetails_SubContract();
            }

            //Delete already added details
            FinishedGoodTest_SubContract_Class_Obj.Delete_tblFGPhysicochemicalTestMethodDetails_FGPhyCheNo_SubContract();

            //Insert identification tests tblFGPhysicochemicalTestMethodDetails
            //for (int col = 4; col < dgIdTest.Columns.Count; col++)
            {
                for (int i = 0; i < dgIdTest.Rows.Count; i++)
                {
                    FinishedGoodTest_SubContract_Class_Obj.fgphymethodno = Convert.ToInt64(dgIdTest["FGPhyMethodNo", i].Value);
                    //FinishedGoodTest_Class_Obj.tankno = Convert.ToInt16(dgIdTest.Columns[col].Name);
                    if (dgIdTest["Min", i].Value == null)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.normmin = "";
                    }
                    else
                    {
                        FinishedGoodTest_SubContract_Class_Obj.normmin = dgIdTest["Min", i].Value.ToString();
                    }

                    if (dgIdTest["Max", i].Value == null)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.normmax = "";
                    }
                    else
                    {
                        FinishedGoodTest_SubContract_Class_Obj.normmax = dgIdTest["Max", i].Value.ToString();
                    }
                    if (dgIdTest["LorealResult", i].Value == null || dgIdTest["LorealResult", i].Value == "")
                    {
                        FinishedGoodTest_SubContract_Class_Obj.lorealresult = "";
                    }
                    else
                    {
                        FinishedGoodTest_SubContract_Class_Obj.lorealresult = dgIdTest["LorealResult", i].Value.ToString();
                    }
                    if (dgIdTest["SupplierResult", i].Value == null || dgIdTest["SupplierResult", i].Value == "")
                    {
                        FinishedGoodTest_SubContract_Class_Obj.supplierresult = "";
                    }
                    else
                    {
                        FinishedGoodTest_SubContract_Class_Obj.supplierresult = dgIdTest["SupplierResult", i].Value.ToString();
                    }
                    //if (dgIdTest[col, i].Value == null || dgIdTest[col, i].Value.ToString().Trim() == "")
                    //{
                    //    FinishedGoodTest_SubContract_Class_Obj.reading = "";
                    //}
                    //else
                    //{
                    //    FinishedGoodTest_SubContract_Class_Obj.reading = dgIdTest[col, i].Value.ToString();
                    //}
                    FinishedGoodTest_SubContract_Class_Obj.Insert_tblFGPhysicochemicalTestMethodDetails_SubContract();
                }
            }

            //Insert Control tests tblFGPhysicochemicalTestMethodDetails

            //for (int col = 4; col < dgIdTest.Columns.Count; col++)
            {
                for (int i = 0; i < dgConTest.Rows.Count; i++)
                {
                    FinishedGoodTest_SubContract_Class_Obj.fgphymethodno = Convert.ToInt64(dgConTest["FGPhyMethodNoCon", i].Value);
                    //FinishedGoodTest_Class_Obj.tankno = Convert.ToInt16(dgIdTest.Columns[col].Name);
                    if (dgConTest["MinCon", i].Value == null)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.normmin = "";
                    }
                    else
                    {
                        FinishedGoodTest_SubContract_Class_Obj.normmin = dgConTest["MinCon", i].Value.ToString();
                    }

                    if (dgConTest["MaxCon", i].Value == null)
                    {
                        FinishedGoodTest_SubContract_Class_Obj.normmax = "";
                    }
                    else
                    {
                        FinishedGoodTest_SubContract_Class_Obj.normmax = dgConTest["MaxCon", i].Value.ToString();
                    }
                    if (dgConTest["LorealResult1", i].Value == null || dgConTest["LorealResult1", i].Value == "")
                    {
                        FinishedGoodTest_SubContract_Class_Obj.lorealresult = "";
                    }
                    else
                    {
                        FinishedGoodTest_SubContract_Class_Obj.lorealresult = dgConTest["LorealResult1", i].Value.ToString();
                    }
                    if (dgConTest["SupplierResult1", i].Value == null || dgConTest["SupplierResult1", i].Value == "")
                    {
                        FinishedGoodTest_SubContract_Class_Obj.supplierresult = "";
                    }
                    else
                    {
                        FinishedGoodTest_SubContract_Class_Obj.supplierresult = dgConTest["SupplierResult1", i].Value.ToString();
                    }
                    //if (dgConTest[col, i].Value == null || dgConTest[col, i].Value.ToString().Trim() == "")
                    //{
                    //    FinishedGoodTest_SubContract_Class_Obj.reading = "";
                    //}
                    //else
                    //{
                    //    FinishedGoodTest_SubContract_Class_Obj.reading = dgConTest[col, i].Value.ToString();
                    //}

                    FinishedGoodTest_SubContract_Class_Obj.Insert_tblFGPhysicochemicalTestMethodDetails_SubContract();
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

            string ProtocolNo = "FGB" + FinishedGoodTest_SubContract_Class_Obj.fgtestno.ToString().PadLeft(6, '0');

            DataSet ds = new DataSet();
            ds = FinishedGoodTest_SubContract_Class_Obj.Select_View_Protocol_FGPackingDetails_PhyChe_SubContract();

            DataTable dt = new DataTable();
            dt.Columns.Add("Test");
            dt.Columns.Add("Min");
            dt.Columns.Add("Max");
            dt.Columns.Add("LorealResult");
            dt.Columns.Add("SupplierResult");

            DataRow dr;
            for (int i = 0; i < dgIdTest.Rows.Count; i++)
            {
                dr = dt.NewRow();
                dr["Test"] = dgIdTest["Test", i].Value;
                dr["Min"] = dgIdTest["Min", i].Value;
                dr["Max"] = dgIdTest["Max", i].Value;
                dr["LorealResult"] = dgIdTest["LorealResult", i].Value;
                dr["SupplierResult"] = dgIdTest["SupplierResult", i].Value;
                dt.Rows.InsertAt(dr, i);
            }

            DataTable dt1 = new DataTable();
            dt1.Columns.Add("Test");
            dt1.Columns.Add("Min");
            dt1.Columns.Add("Max");
            dt1.Columns.Add("LorealResult");
            dt1.Columns.Add("SupplierResult");

            DataRow dr1;
            for (int i = 0; i < dgConTest.Rows.Count; i++)
            {
                dr1 = dt1.NewRow();
                dr1["Test"] = dgConTest["TestCon", i].Value;
                dr1["Min"] = dgConTest["MinCon", i].Value;
                dr1["Max"] = dgConTest["MaxCon", i].Value;
                dr1["LorealResult"] = dgConTest["LorealResult1", i].Value;
                dr1["SupplierResult"] = dgConTest["SupplierResult1", i].Value;
                dt1.Rows.InsertAt(dr1, i);
            }


            QTMS.Reports_Forms.FrmProtocol_FGPhysicoChemical_SubContract fm = new QTMS.Reports_Forms.FrmProtocol_FGPhysicoChemical_SubContract("FG PhysicoChemical Protocol", ds, dt, dt1, txtFormulaNo.Text.Trim(), txtMfgWo.Text.Trim(), ProtocolNo, cmbInspectedBy.Text.Trim());
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
                if (dgIdTest.CurrentCell.EditedFormattedValue.ToString().Trim() != "")
                {
                    if (dgIdTest["Max", dgIdTest.CurrentCell.RowIndex].Value.ToString().Trim() == "" && dgIdTest["Min", dgIdTest.CurrentCell.RowIndex].Value.ToString().Trim() == "")
                    {
                        dgIdTest.CurrentCell.Style.BackColor = Color.Red;
                        return;
                    }

                    if (dgIdTest["Max", dgIdTest.CurrentCell.RowIndex].Value != null && dgIdTest["Max", dgIdTest.CurrentCell.RowIndex].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dgIdTest.CurrentCell.EditedFormattedValue) > Convert.ToDouble(dgIdTest["Max", dgIdTest.CurrentCell.RowIndex].Value))
                        {
                            dgIdTest.CurrentCell.Style.BackColor = Color.Red;
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
                            return;
                        }
                        else
                        {
                            dgIdTest.CurrentCell.Style.BackColor = Color.White;
                        }
                    }

                    if (dgIdTest["LorealResult", dgIdTest.CurrentCell.RowIndex].Value != null && dgIdTest["LorealResult", dgIdTest.CurrentCell.RowIndex].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dgIdTest.CurrentCell.EditedFormattedValue) > Convert.ToDouble(dgIdTest["Max", dgIdTest.CurrentCell.RowIndex].Value) || Convert.ToDouble(dgIdTest.CurrentCell.EditedFormattedValue) < Convert.ToDouble(dgIdTest["Min", dgIdTest.CurrentCell.RowIndex].Value))
                        {
                            dgIdTest.CurrentCell.Style.BackColor = Color.Red;
                            return;
                        }
                        else
                        {
                            dgIdTest.CurrentCell.Style.BackColor = Color.White;
                        }
                    }

                    if (dgIdTest["SupplierResult", dgIdTest.CurrentCell.RowIndex].Value != null && dgIdTest["SupplierResult", dgIdTest.CurrentCell.RowIndex].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dgIdTest.CurrentCell.EditedFormattedValue) > Convert.ToDouble(dgIdTest["Max", dgIdTest.CurrentCell.RowIndex].Value) || Convert.ToDouble(dgIdTest.CurrentCell.EditedFormattedValue) < Convert.ToDouble(dgIdTest["Min", dgIdTest.CurrentCell.RowIndex].Value))
                        {
                            dgIdTest.CurrentCell.Style.BackColor = Color.Red;
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
            try
            {
                if (e.RowIndex < 0 || e.ColumnIndex < 4)
                {
                    return;
                }
                else
                {
                    if (dgConTest.CurrentCell.EditedFormattedValue.ToString().Trim() != "")
                    {
                        if (dgConTest["MaxCon", dgConTest.CurrentCell.RowIndex].Value.ToString().Trim() == "" && dgConTest["MinCon", dgConTest.CurrentCell.RowIndex].Value.ToString().Trim() == "")
                        {
                            dgConTest.CurrentCell.Style.BackColor = Color.Red;
                            return;
                        }

                        if (dgConTest["MaxCon", dgConTest.CurrentCell.RowIndex].Value != null && dgConTest["MaxCon", dgConTest.CurrentCell.RowIndex].Value.ToString() != "")
                        {
                            if (Convert.ToDouble(dgConTest.CurrentCell.EditedFormattedValue) > Convert.ToDouble(dgConTest["MaxCon", dgConTest.CurrentCell.RowIndex].Value))
                            {
                                dgConTest.CurrentCell.Style.BackColor = Color.Red;
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
                                return;
                            }
                            else
                            {
                                dgConTest.CurrentCell.Style.BackColor = Color.White;
                            }
                        }

                        if (dgConTest["LorealResult1", dgConTest.CurrentCell.RowIndex].Value != null && dgConTest["LorealResult1", dgIdTest.CurrentCell.RowIndex].Value.ToString() != "")
                        {
                            if (Convert.ToDouble(dgConTest.CurrentCell.EditedFormattedValue) > Convert.ToDouble(dgConTest["MaxCon", dgConTest.CurrentCell.RowIndex].Value) || Convert.ToDouble(dgConTest.CurrentCell.EditedFormattedValue) < Convert.ToDouble(dgConTest["MinCon", dgConTest.CurrentCell.RowIndex].Value))
                            {
                                dgConTest.CurrentCell.Style.BackColor = Color.Red;
                                return;
                            }
                            else
                            {
                                dgConTest.CurrentCell.Style.BackColor = Color.White;
                            }
                        }

                        if (dgConTest["SupplierResult1", dgConTest.CurrentCell.RowIndex].Value != null && dgConTest["SupplierResult1", dgConTest.CurrentCell.RowIndex].Value.ToString() != "")
                        {
                            if (Convert.ToDouble(dgConTest.CurrentCell.EditedFormattedValue) > Convert.ToDouble(dgConTest["MaxCon", dgConTest.CurrentCell.RowIndex].Value) || Convert.ToDouble(dgConTest.CurrentCell.EditedFormattedValue) < Convert.ToDouble(dgConTest["MinCon", dgConTest.CurrentCell.RowIndex].Value))
                            {
                                dgConTest.CurrentCell.Style.BackColor = Color.Red;
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
            catch (Exception ex)
            { }
        }

        private void dgConTest_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 4)
            {
                return;
            }
            else
            {
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

        public void FillColorGrid()
        {
            for (int i = 0; i < dgIdTest.Rows.Count; i++)
            {
                if (Convert.ToString(dgIdTest["SupplierResult", i].Value) != "")
                {
                    if (Convert.ToDouble(dgIdTest["SupplierResult", i].Value) > Convert.ToDouble(dgIdTest["Max", i].Value) || Convert.ToDouble(dgIdTest["SupplierResult", i].Value) < Convert.ToDouble(dgIdTest["Min", i].Value))
                    {
                        dgIdTest["SupplierResult", i].Style.BackColor = Color.Red;
                    }
                    else
                    {
                        dgIdTest["SupplierResult", i].Style.BackColor = Color.White;
                    }
                }
                if (Convert.ToString(dgIdTest["LorealResult", i].Value) != "")
                {
                    if (Convert.ToDouble(dgIdTest["LorealResult", i].Value) > Convert.ToDouble(dgIdTest["Max", i].Value) || Convert.ToDouble(dgIdTest["LorealResult", i].Value) < Convert.ToDouble(dgIdTest["Min", i].Value))
                    {
                        dgIdTest["LorealResult", i].Style.BackColor = Color.Red;
                    }
                    else
                    {
                        dgIdTest["LorealResult", i].Style.BackColor = Color.White;
                    }
                }
            }

            for (int i = 0; i < dgConTest.Rows.Count; i++)
            {
                if (Convert.ToString(dgConTest["SupplierResult1", i].Value) != "")
                {
                    if (Convert.ToDouble(dgConTest["SupplierResult1", i].Value) > Convert.ToDouble(dgConTest["MaxCon", i].Value) || Convert.ToDouble(dgConTest["SupplierResult1", i].Value) < Convert.ToDouble(dgConTest["MinCon", i].Value))
                    {
                        dgConTest["SupplierResult1", i].Style.BackColor = Color.Red;
                    }
                    else
                    {
                        dgConTest["SupplierResult1", i].Style.BackColor = Color.White;
                    }
                }
                if (Convert.ToString(dgConTest["LorealResult1", i].Value) != "")
                {
                    if (Convert.ToDouble(dgConTest["LorealResult1", i].Value) > Convert.ToDouble(dgConTest["MaxCon", i].Value) || Convert.ToDouble(dgConTest["LorealResult1", i].Value) < Convert.ToDouble(dgConTest["MinCon", i].Value))
                    {
                        dgConTest["LorealResult1", i].Style.BackColor = Color.Red;
                    }
                    else
                    {
                        dgConTest["LorealResult1", i].Style.BackColor = Color.White;
                    }
                }
            }
        }

    }
}