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
    public partial class FrmRMTransactionTest : Form
    {
        public class Detail
        {
            public long RMCodeID;
            public long RMTransID;
            public char MethodType;
            public string TestType;
            public char Done;
        }


        bool _IsAlligned;
        public bool IsAlligned
        {
            get { return _IsAlligned; }
            set { _IsAlligned = value; }
        }

        string _TypeofControl = String.Empty;
        public string TypeofControl
        {
            get { return _TypeofControl; }
            set { _TypeofControl = value; }
        }
        private string _TypeofTest;

        public string TypeofTest
        {
            get { return _TypeofTest; }
            set { _TypeofTest = value; }
        }
	
	
        public FrmRMTransactionTest(FrmRMTransactionTest.Detail Detail)
        {
            InitializeComponent();
            RMTransaction_Class_Obj.rmtransid = Detail.RMTransID;
            RMTransaction_Class_Obj.methodtype = Detail.MethodType;
            RMTransaction_Class_Obj.testtype = Detail.TestType;
            RMTransaction_Class_Obj.rmcodeid = Detail.RMCodeID;
            Done = Detail.Done;
        }

        #region variables
        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        BusinessFacade.Transactions.RMTransaction_Class RMTransaction_Class_Obj = new BusinessFacade.Transactions.RMTransaction_Class();
        char Done;
        #endregion

        delegate bool Del(string MaxVal, string MinVal, string ReadingVal);
        private void FrmRMTransactionTest_Load(object sender, EventArgs e)
        {
            Painter.Paint(this);

            try
            {
                dgRMTest.Rows.Clear();

                if (Done == 'Y')
                {
                    DataSet ds = new DataSet();
                    ds = RMTransaction_Class_Obj.Select_RMPhysicochemicalTestMethodDetails_RMTransID();
                    if (ds.Tables[0].Rows.Count > 0 && dgRMTest.Rows.Count == 0)
                    {
                        ///This Annonymous Function Validates Max and Min 
                        ///Value against Reading and set Cell Back Color As per validation
                        #region This Annonymous Function Validates Max and Min 
                        Del d = delegate(string MaxVal, string MinVal, string ReadingVal)
                                    {
                                        bool b = false;
                                        if (string.IsNullOrEmpty(MaxVal)
                                            && string.IsNullOrEmpty(MinVal))
                                        {
                                            b = false;
                                        }
                                        else
                                            b = true;
                                        if (!string.IsNullOrEmpty(MaxVal) && !string.IsNullOrEmpty(ReadingVal))
                                        {
                                            if (Convert.ToDouble(ReadingVal) > Convert.ToDouble(MaxVal))
                                            {
                                                b = false;
                                                //dgRMTest["Reading", dgRMTest.Rows.Count - 1].Style.BackColor = Color.Red;
                                            }
                                            else
                                            {
                                                b = true;
                                                //dgRMTest["Reading", dgRMTest.Rows.Count - 1].Style.BackColor = Color.White;
                                            }
                                        }

                                        if (!string.IsNullOrEmpty(MinVal) && !string.IsNullOrEmpty(ReadingVal))
                                        {
                                            if (Convert.ToDouble(ReadingVal) < Convert.ToDouble(MinVal))
                                            {
                                                b = false;
                                                //dgRMTest["Reading", dgRMTest.Rows.Count - 1].Style.BackColor = Color.Red;
                                            }
                                            else
                                            {
                                                b = true;
                                                //dgRMTest["Reading", dgRMTest.Rows.Count - 1].Style.BackColor = Color.White;
                                            }
                                        }
                                        return b;
                                    }; 
                        #endregion

                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            dgRMTest.Rows.Add();
                            dgRMTest["MethodNo", dgRMTest.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["RMPhyMethodNo"].ToString();
                            dgRMTest["DescNo", dgRMTest.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["DescNo"].ToString();
                            //dgRMTest["ParaDesc", dgRMTest.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["ParaName"].ToString()+ "-" + ds.Tables[0].Rows[i]["DescName"].ToString();
                            dgRMTest["ParaName", dgRMTest.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["ParaName"].ToString();
                            dgRMTest["DescName", dgRMTest.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["DescName"].ToString();
                            dgRMTest["Min", dgRMTest.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["NormsMin"].ToString();
                            dgRMTest["Max", dgRMTest.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["NormsMax"].ToString();
                            dgRMTest["Reading", dgRMTest.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["NormsReading"].ToString();

                            bool b = d.Invoke(Convert.ToString(dgRMTest["Max", dgRMTest.Rows.Count - 1].Value),
                                Convert.ToString(dgRMTest["Min", dgRMTest.Rows.Count - 1].Value),
                                Convert.ToString(dgRMTest["Reading", dgRMTest.Rows.Count - 1].Value));
                            if (b)
                            {
                                dgRMTest["Reading", dgRMTest.Rows.Count - 1].Style.BackColor = Color.White;
                            }
                            else
                            {
                                dgRMTest["Reading", dgRMTest.Rows.Count - 1].Style.BackColor = Color.Red;
                            }
                            dgRMTest["SupplierResult", dgRMTest.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["SupplierResult"].ToString();
                        }
                    }
                }
                else if (Done == 'N')
                {
                    DataSet ds = new DataSet();
                    ds = RMTransaction_Class_Obj.Select_tblRMPhysicochemicalTestMethodMaster_RMCodeID_TestType();
                    if (ds.Tables[0].Rows.Count > 0 && dgRMTest.Rows.Count == 0)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            dgRMTest.Rows.Add();
                            dgRMTest["MethodNo", dgRMTest.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["RMPhyMethodNo"].ToString();
                            dgRMTest["DescNo", dgRMTest.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["DescNo"].ToString();
                            //dgRMTest["ParaDesc", dgRMTest.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["ParaName"].ToString()+ "-" + ds.Tables[0].Rows[i]["DescName"].ToString();
                            dgRMTest["ParaName", dgRMTest.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["ParaName"].ToString();
                            dgRMTest["DescName", dgRMTest.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["DescName"].ToString();
                            dgRMTest["Min", dgRMTest.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["NormsMin"].ToString();
                            dgRMTest["Max", dgRMTest.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["NormsMax"].ToString();

                        }
                    }

                    //DataSet ds_Reading;
                    //for (int i = 0; i < dgRMTest.Rows.Count; i++)
                    //{
                    //    ds_Reading = new DataSet();
                    //    RMTransaction_Class_Obj.rmphymethodno = Convert.ToInt64(dgRMTest["MethodNo", i].Value);
                    //    ds_Reading = RMTransaction_Class_Obj.Select_tblRMPhysicochemicalTestMethodDetails_RMTransID_RMPhyMethodNo();
                    //    //ds_Reading = RMTransaction_Class_Obj.Select_tblRMPhysicochemicalTestMethodDetails_RMTransID_TestType_ParaName_DescName();
                    //    if (ds_Reading.Tables[0].Rows.Count > 0)
                    //    {
                    //        dgRMTest["Reading", i].Value = ds_Reading.Tables[0].Rows[0]["NormsReading"].ToString();
                    //    }
                    //    else
                    //    {
                    //        dgRMTest["Reading", i].Value = "";
                    //    }
                    //}
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

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidateGrid)
                {
                    //for (int i = 0; i < dgRMTest.Rows.Count; i++)
                    //{
                    //    if (dgRMTest["Reading", i].Value == null || dgRMTest["Reading", i].Value.ToString() == "")
                    //    {
                    //        MessageBox.Show("Fill all the Readings...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //        dgRMTest.Focus();
                    //        return;
                    //    }
                    //}
                    //for (int i = 0; i < dgRMTest.Rows.Count; i++)
                    //{
                    //    if (dgRMTest["SupplierResult", i].Value == null || dgRMTest["SupplierResult", i].Value.ToString() == "")
                    //    {
                    //        MessageBox.Show("Fill all the Supplier Result...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //        dgRMTest.Focus();
                    //        return;
                    //    }
                    //}
                    //Delete previous records
                    RMTransaction_Class_Obj.Delete_tblRMPhysicochemicalTestMethodDetails_RMtransID();

                    //DataSet ds_Reading;
                    for (int i = 0; i < dgRMTest.Rows.Count; i++)
                    {
                        RMTransaction_Class_Obj.rmphymethodno = Convert.ToInt64(dgRMTest["MethodNo", i].Value.ToString());
                        RMTransaction_Class_Obj.normsreading = Convert.ToString(dgRMTest["Reading", i].Value);

                        RMTransaction_Class_Obj.normsmin = dgRMTest["Min", i].Value.ToString();
                        RMTransaction_Class_Obj.normsmax = dgRMTest["Max", i].Value.ToString();
                        RMTransaction_Class_Obj.suppresult = Convert.ToString(dgRMTest["SupplierResult", i].Value);
                        RMTransaction_Class_Obj.rmphydetailno = RMTransaction_Class_Obj.Insert_RMPhysicochemicalTestMethodDetails();

                        //ds_Reading = new DataSet();
                        //ds_Reading = RMTransaction_Class_Obj.Select_tblRMPhysicochemicalTestMethodDetails_RMTransID_RMPhyMethodNo();
                        ////ds_Reading = RMTransaction_Class_Obj.Select_tblRMPhysicochemicalTestMethodDetails_RMTransID_TestType_ParaName_DescName();                    
                        //if (ds_Reading.Tables[0].Rows.Count > 0)
                        //{
                        //    RMTransaction_Class_Obj.rmphydetailno = Convert.ToInt64(ds_Reading.Tables[0].Rows[0]["RMPhyDetailNo"]);
                        //    RMTransaction_Class_Obj.Update_tblRMPhysicochemicalTestMethodDetails();
                        //}
                        //else
                        //{
                        //    RMTransaction_Class_Obj.rmphydetailno = RMTransaction_Class_Obj.Insert_RMPhysicochemicalTestMethodDetails();
                        //}
                    }
                    MessageBox.Show("Test Details Saved Successfully", "Sucess", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BtnExit_Click(sender, e);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// This Property vslidate grid values against Type of Control and 
        /// </summary>
        private bool ValidateGrid
        {
            get
            {
                bool _Valid = false;
                if (!string.IsNullOrEmpty(TypeofTest))
                {
                    if (TypeofTest.Equals("Identification", StringComparison.CurrentCultureIgnoreCase))
                    {
                        /// Change on 22/Feb/2013
                        ///Validate Grid Alligned with Full Control and Reduced
                        ///Non Alligned With Full and Reduced all 4 conditions Loreal Result Must be Filled
                        ///
                        for (int i = 0; i < dgRMTest.Rows.Count; i++)
                        {
                            if (!string.IsNullOrEmpty(Convert.ToString(dgRMTest.Rows[i].Cells["Reading"].Value)))
                            {
                                _Valid = true;
                            }
                            else
                            {
                                _Valid = false;
                                break;
                            }
                        }
                        if (_Valid == false)
                        {
                            MessageBox.Show("In Identification Test Loreal Result Must Be Filled");
                        }
                    }
                    else
                    {
                        #region Validate Grid As per Control Test
                        if (!string.IsNullOrEmpty(TypeofControl))
                        {
                            if (TypeofControl.Equals("Full Control", StringComparison.CurrentCultureIgnoreCase))
                            {
                                ///Validate Grid Alligned with Full Control Change on 22/Feb/2013
                                ///Alligned With Full=All Compulsary

                                /// 
                                if (IsAlligned)
                                {
                                    for (int i = 0; i < dgRMTest.Rows.Count; i++)
                                    {
                                        if (!string.IsNullOrEmpty(Convert.ToString(dgRMTest.Rows[i].Cells["Reading"].Value))
                                            && !string.IsNullOrEmpty(Convert.ToString(dgRMTest.Rows[i].Cells["SupplierResult"].Value)))
                                        {
                                            _Valid = true;
                                        }
                                        else
                                        {
                                            _Valid = false;
                                            break;
                                        }
                                    }
                                    if (_Valid == false)
                                    {
                                        MessageBox.Show("In Control Test Alligned with Full Control Both Result Must Be Filled");
                                    }
                                }
                                else
                                {
                                    ///Validate Grid NonAlligned with Full Control Change on 22/Feb/2013
                                    ///Non Allign With Full=loreal Compulsary /// Previously Both Compulsary
                                    for (int i = 0; i < dgRMTest.Rows.Count; i++)
                                    {
                                        if (!string.IsNullOrEmpty(Convert.ToString(dgRMTest.Rows[i].Cells["Reading"].Value)))
                                        {
                                            _Valid = true;
                                        }
                                        else
                                        {
                                            _Valid = false;
                                            break;
                                        }
                                    }
                                    if (_Valid == false)
                                    {
                                        MessageBox.Show("In Control Test Full control With Non Alligned Loreal Result Must Be Filled");
                                    }
                                }
                            }
                            else
                            {
                                ///Validate Grid Alligned with Redused Control
                                ///Alligned With Redused Control=Supplier Compulsary
                                ///Non Allign With Redused Control=Either One
                                if (IsAlligned)
                                {
                                    for (int i = 0; i < dgRMTest.Rows.Count; i++)
                                    {
                                        if (!string.IsNullOrEmpty(Convert.ToString(dgRMTest.Rows[i].Cells["SupplierResult"].Value)))
                                        {
                                            _Valid = true;
                                        }
                                        else
                                        {
                                            _Valid = false;
                                            break;
                                        }
                                    }
                                    if (_Valid == false)
                                    {
                                        MessageBox.Show("In Control Test Aligned with Reduced control Supplier Result Must Be Filled");
                                    }
                                }
                                else
                                {
                                    for (int i = 0; i < dgRMTest.Rows.Count; i++)
                                    {
                                        if (!string.IsNullOrEmpty(Convert.ToString(dgRMTest.Rows[i].Cells["Reading"].Value))
                                        || !string.IsNullOrEmpty(Convert.ToString(dgRMTest.Rows[i].Cells["SupplierResult"].Value)))
                                        {
                                            _Valid = true;
                                        }
                                        else
                                        {
                                            _Valid = false;
                                            break;
                                        }
                                    }
                                    if (_Valid == false)
                                    {
                                        MessageBox.Show("In Control Test Non Aligned with Reduced Control Either One Result Must Be Filled");
                                    }
                                }

                            }
                        }
                        else
                        {
                            MessageBox.Show("Please Select Proper Type Of Control");
                        }
                        #endregion
                    }
                }                
                return _Valid;
            }
        }

        private void dgRMTest_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgRMTest.CurrentCell.RowIndex < 0  || (dgRMTest.CurrentCell.ColumnIndex != dgRMTest.Columns["Reading"].Index))
            {
                return;
            }
            else if (dgRMTest.CurrentCell.ColumnIndex == dgRMTest.Columns["Reading"].Index)
            {
                dgRMTest.EditingControl.KeyPress += new KeyPressEventHandler(EditingControl_KeyPress);
            }
        }

        void EditingControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, comma, period, enter and tab
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&
                 e.KeyChar != 44 && e.KeyChar != 46 && e.KeyChar != 13 &&
                 e.KeyChar != 9 && e.KeyChar != 45)
            {
                e.Handled = true;
            }
        }

        private void btnProtocol_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DataSet dspres = new DataSet();
                DataSet dsfdapres = new DataSet();

                if (RMTransaction_Class_Obj.methodtype == 'R')
                {
                    ds = RMTransaction_Class_Obj.Select_View_RMProtocol_Phy_Report();
                    dspres = RMTransaction_Class_Obj.Select_View_RMProtocol_Pres_Report();
                }
                else if (RMTransaction_Class_Obj.methodtype == 'F')
                {
                    ds = RMTransaction_Class_Obj.Select_View_RMProtocol_Phy_Report();
                    dspres = RMTransaction_Class_Obj.Select_View_RMProtocol_Pres_Report();

                }
                else if (RMTransaction_Class_Obj.methodtype == 'D')
                {
                    ds = RMTransaction_Class_Obj.Select_View_RMProtocol_FDAPhy_Report();
                    dspres = RMTransaction_Class_Obj.Select_View_RMProtocol_FDAPres_Report();
                }
                if (ds.Tables[0].Rows.Count > 0)
                {
                    QTMS.Reports_Forms.FrmRMProtocolTests pro = new QTMS.Reports_Forms.FrmRMProtocolTests(RMTransaction_Class_Obj.methodtype.ToString(), ds.Tables[0], dspres.Tables[0]);
                    pro.Show();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgRMTest_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgRMTest.Columns["Reading"].Index)
            {
                return;
            }
            else
            {
                if (dgRMTest.CurrentCell.EditedFormattedValue.ToString().Trim() != "")
                {
                    if (dgRMTest["Max", dgRMTest.CurrentCell.RowIndex].Value.ToString().Trim() == "" && dgRMTest["Min", dgRMTest.CurrentCell.RowIndex].Value.ToString().Trim() == "")
                    {
                        dgRMTest.CurrentCell.Style.BackColor = Color.Red;
                        return;
                    }

                    if (dgRMTest["Max", dgRMTest.CurrentCell.RowIndex].Value != null && dgRMTest["Max", dgRMTest.CurrentCell.RowIndex].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dgRMTest.CurrentCell.EditedFormattedValue) > Convert.ToDouble(dgRMTest["Max", dgRMTest.CurrentCell.RowIndex].Value))
                        {
                            dgRMTest.CurrentCell.Style.BackColor = Color.Red;
                            return;
                        }
                        else
                        {
                            dgRMTest.CurrentCell.Style.BackColor = Color.White;
                        }
                    }

                    if (dgRMTest["Min", dgRMTest.CurrentCell.RowIndex].Value != null && dgRMTest["Min", dgRMTest.CurrentCell.RowIndex].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dgRMTest.CurrentCell.EditedFormattedValue) < Convert.ToDouble(dgRMTest["Min", dgRMTest.CurrentCell.RowIndex].Value))
                        {
                            dgRMTest.CurrentCell.Style.BackColor = Color.Red;
                            return;
                        }
                        else
                        {
                            dgRMTest.CurrentCell.Style.BackColor = Color.White;
                        }
                    }
                }
                else
                {
                    dgRMTest.CurrentCell.Style.BackColor = Color.White;
                }

            }
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}