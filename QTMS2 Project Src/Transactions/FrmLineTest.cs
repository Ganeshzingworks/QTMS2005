/********************************************************
*Author: Vijay Tomake
*Date: 
*Description: Transaction form to enter Line Sampling Details
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
    public partial class FrmLineTest : Form
    {

        public class Line
        {
            public long L_fno;
            public long L_tlfid;
            public long L_tankno;
            public string L_samptestdesc;
            public char Done;
        }

        public FrmLineTest(FrmLineTest.Line Line_Obj)
        {
            InitializeComponent();

            LineTesting_Class_Obj.fno = Line_Obj.L_fno;
            LineTesting_Class_Obj.tlfid = Line_Obj.L_tlfid;
            LineTesting_Class_Obj.tankno =Line_Obj.L_tankno;            
            LineTesting_Class_Obj.sampletestdesc = Line_Obj.L_samptestdesc;
            Done = Line_Obj.Done;
        }

        BusinessFacade.Transactions.LineTesting_Class LineTesting_Class_Obj = new BusinessFacade.Transactions.LineTesting_Class();
        char Done;

        /// <summary>
        /// form load method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmLineTest_Load(object sender, EventArgs e)
        {
            Painter.Paint(this);

            // insert record into TblFillTankSamp with Result = ""
            // After testing modify the result
            LineTesting_Class_Obj.sampletestresult = "";

            DataSet ds1 = new DataSet();
            //Select FillTankSampNo from TankNo, TLFID, SampTestDesc
            ds1 = LineTesting_Class_Obj.Select_tblFillTankSamp_FillTankSampNo_SampTestResult();
            if (ds1.Tables[0].Rows.Count > 0)
            {
                LineTesting_Class_Obj.filltanksampno = Convert.ToInt64(ds1.Tables[0].Rows[0]["FillTankSampNo"]);
                if (ds1.Tables[0].Rows[0]["SampTestResult"].ToString() == "A")
                {
                    RdoAccepted.Checked = true;
                }
                else if (ds1.Tables[0].Rows[0]["SampTestResult"].ToString() == "R")
                {
                    RdoRejected.Checked = true;
                }
            }
            else 
            {
                //Insert TankNo, TLFID, SampTestDesc , SampTestResult = "" 
                LineTesting_Class_Obj.filltanksampno = LineTesting_Class_Obj.INSERT_tblFillTankSamp();

                //Keep by dafault accepted Checked
                RdoAccepted.Checked = true;
            }

            //--------- Select Line Tests applicable to formula

            DataSet ds = new DataSet();
            if (Done == 'N') // if tesing not done earlier then display applicable tests 
            {
                ds = LineTesting_Class_Obj.SELECT_tblLineTestMethodMaster_FNo();
            }
            else if (Done == 'Y') // if testing done earlier then display the previous tests and results
            {
                ds = LineTesting_Class_Obj.Select_tblLineTestMethodDetails_Tests();
            }

            if (ds.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    dgTest.Rows.Add();
                    dgTest["LineMethodNo", dgTest.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["LineMethodNo"].ToString();
                    dgTest["Test", dgTest.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["Details"].ToString();
                    dgTest["Min", dgTest.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["NormsMin"].ToString();
                    dgTest["Max", dgTest.Rows.Count - 1].Value = ds.Tables[0].Rows[i]["NormsMax"].ToString();
                }
            }


            //---------Select NormsReading for each test from TankNo, TLFID, SampTestDesc, LineMethodNo
            DataSet ds_Reading;
            for (int i = 0; i < dgTest.Rows.Count; i++)
            {
                ds_Reading = new DataSet();                
                LineTesting_Class_Obj.linemethodno = Convert.ToInt64(dgTest["LineMethodNo", i].Value);
                ds_Reading = LineTesting_Class_Obj.Select_tblLineTestMethodDetails_NormsReading();
                if (ds_Reading.Tables[0].Rows.Count > 0)
                {
                    dgTest["Reading", i].Value = ds_Reading.Tables[0].Rows[0]["NormsReading"].ToString();
                }
                else
                {
                    dgTest["Reading", i].Value = "";
                }
            }

        }

        /// <summary>
        /// Saves the sampling details
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSave_Click(object sender, EventArgs e)
        {
            //check whether reading field is empty or not
            for (int i = 0; i < dgTest.Rows.Count; i++)
            {
                if (dgTest["Reading", i].Value == null || dgTest["Reading", i].Value.ToString() == "")
                {
                    MessageBox.Show("Fill all the Readings...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgTest.Focus();
                    return;
                }
            }

            if (RdoAccepted.Checked == false && RdoRejected.Checked == false)
            {
                MessageBox.Show("Select Accept/Reject option ...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RdoAccepted.Focus();
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

            DataSet ds; 
            for (int i = 0; i < dgTest.Rows.Count; i++)
            {
                //FillTankSampNo
                LineTesting_Class_Obj.linemethodno = Convert.ToInt64(dgTest["LineMethodNo",i].Value);
                LineTesting_Class_Obj.normsreading = Convert.ToString(dgTest["Reading", i].Value);

                //Select linetestdetailno from FillTankSampNo, LineMethodNo
                ds = new DataSet();
                ds = LineTesting_Class_Obj.Select_tblLineTestMethodDetails_LineTestDetailNo();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //update the sampling details
                    LineTesting_Class_Obj.linetestdetailno = Convert.ToInt64(ds.Tables[0].Rows[0]["LineTestDetailNo"]);
                    LineTesting_Class_Obj.Update_tblLineTestMethodDetails();
                }
                else
                {
                    //insert the sampling details
                    LineTesting_Class_Obj.linetestdetailno = LineTesting_Class_Obj.Insert_tblLineTestMethodDetails();
                }                
            }

            //update SampTestesult in tblFillTankSamp
            if (RdoAccepted.Checked == true)
            {
                LineTesting_Class_Obj.sampletestresult = "A";
            }
            else if (RdoRejected.Checked == true)
            {
                LineTesting_Class_Obj.sampletestresult = "R";
            }

            //update the sampling result 
            LineTesting_Class_Obj.Update_tblFillTankSamp_SampTestResult();


            MessageBox.Show("Test Details saved Successfully..!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        /// Edit control showing event for test grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgTest_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgTest.CurrentCell.RowIndex < 0
                || (dgTest.CurrentCell.ColumnIndex != dgTest.Columns["Reading"].Index))
            {
                return;
            }
            else if (dgTest.CurrentCell.ColumnIndex == dgTest.Columns["Reading"].Index)
            {
                dgTest.EditingControl.KeyPress += new KeyPressEventHandler(EditingControl_KeyPress);
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
        /// cell validating event for test grid
        /// if the reading is out of Min-Max norms then Make the cell RED
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgTest_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgTest.Columns["Reading"].Index)
            {
                return;
            }
            else
            {
                if (dgTest.CurrentCell.EditedFormattedValue.ToString().Trim() != "")
                {
                    if (dgTest["Max", dgTest.CurrentCell.RowIndex].Value.ToString().Trim() == "" && dgTest["Min", dgTest.CurrentCell.RowIndex].Value.ToString().Trim() == "")
                    {
                        dgTest.CurrentCell.Style.BackColor = Color.Red;
                        return;
                    }

                    if (dgTest["Max", dgTest.CurrentCell.RowIndex].Value != null && dgTest["Max", dgTest.CurrentCell.RowIndex].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dgTest.CurrentCell.EditedFormattedValue) > Convert.ToDouble(dgTest["Max", dgTest.CurrentCell.RowIndex].Value))
                        {
                            dgTest.CurrentCell.Style.BackColor = Color.Red;
                            return;
                        }
                        else
                        {
                            dgTest.CurrentCell.Style.BackColor = Color.White;
                        }
                    }

                    if (dgTest["Min", dgTest.CurrentCell.RowIndex].Value != null && dgTest["Min", dgTest.CurrentCell.RowIndex].Value.ToString() != "")
                    {
                        if (Convert.ToDouble(dgTest.CurrentCell.EditedFormattedValue) < Convert.ToDouble(dgTest["Min", dgTest.CurrentCell.RowIndex].Value))
                        {
                            dgTest.CurrentCell.Style.BackColor = Color.Red;
                            return;
                        }
                        else
                        {
                            dgTest.CurrentCell.Style.BackColor = Color.White;
                        }
                    }
                }
                else
                {
                    dgTest.CurrentCell.Style.BackColor = Color.White;
                }

            }
        }

        /// <summary>
        /// cell validated event for test grid
        /// if reading is out of norms the set status rejected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgTest_CellValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex != dgTest.Columns["Reading"].Index)
            {
                return;
            }
            else
            {
                for (int i = 0; i < dgTest.Rows.Count; i++)
                {
                    if (dgTest["Reading", i].Style.BackColor == Color.Red)
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

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       
    }
}