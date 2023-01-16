using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QTMS.Tools;
using BusinessFacade;

namespace QTMS.Forms
{
    public partial class FrmDimension : Form
    {

        #region Variable
        PMFamilyMaster_Class PMFamilyMaster_Class_obj = new PMFamilyMaster_Class();
        #endregion

        public FrmDimension(long PMCOdeID, long familyID, long pmTestNo)
        {
            PMFamilyMaster_Class_obj.pmCodeID = PMCOdeID;
            PMFamilyMaster_Class_obj.pmfamilyid = familyID;
            PMFamilyMaster_Class_obj.testNo = pmTestNo;
            InitializeComponent();
        }
        public FrmDimension(long familyID, long pmTestNo)
        {
            PMFamilyMaster_Class_obj.pmfamilyid = familyID;
            PMFamilyMaster_Class_obj.testNo = pmTestNo;
            InitializeComponent();
        }
        private void FrmDimension_Load(object sender, EventArgs e)
        {
            Painter.Paint(this);
            Bind_Grid();
            dgReadings.DefaultCellStyle.ForeColor = Color.Black;
            dgReadings.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgReadings.DefaultCellStyle.SelectionBackColor = Color.White;

        }

        public void Bind_Grid()
        {
            try
            {
                DataTable dt = new DataTable();
                // Check norms exist or not
                dt = PMFamilyMaster_Class_obj.Select_DimensionParaRelation_PMFamilyIDTestNo_Updated();
                // if norms exist execute if loop & norms not exist then execute else loop
                if (dt.Rows.Count > 0)
                {
                    dgReadings.DataSource = dt;
                }
                else
                {
                    dt = PMFamilyMaster_Class_obj.Select_DimensionParaRelation_PMFamilyID();
                    //dgReadings.AutoGenerateColumns = false;
                    dgReadings.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void DrawGrid(int col, int row)
        {
            //for (int i = 0; i < col; i++)
            //{
            //    dgReadings.Columns.Add(i.ToString(), i.ToString());
            //    dgReadings.Columns[i].Width = dgReadings.Width / col;

            //}
            //for (int j = 0; j < row; j++)
            //{
            //    dgReadings.Rows.Add();
            //}
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void BtnSave_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        for (int i = 0; i < dgReadings.Columns.Count; i++)
        //        {
        //            for (int j = 0; j < dgReadings.Rows.Count; j++)
        //            {
        //                if (dgReadings[i, j].Value == null || dgReadings[i, j].Value.ToString().Trim() == "")
        //                {
        //                    MessageBox.Show("Enter all Norms", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //                    dgReadings.Focus();
        //                    return;
        //                }
        //            }
        //        }

        //        for (int i = 0; i < dgReadings.Rows.Count; i++)
        //        {
        //            DimensionParameter_Class DimensionParameter_Class_obj = new DimensionParameter_Class();
        //            //bool flag = false;
        //            //PMFamily & Testno get in constructor
        //            DimensionParameter_Class_obj.pmfamilyid = PMFamilyMaster_Class_obj.pmfamilyid;
        //            DimensionParameter_Class_obj.testNo = PMFamilyMaster_Class_obj.testNo;
        //            DimensionParameter_Class_obj.dimensionParaID = Convert.ToInt32(dgReadings["DimensionParaID", i].Value);
        //            DimensionParameter_Class_obj.normsMin = Convert.ToDouble(dgReadings["NormsMin", i].Value);
        //            DimensionParameter_Class_obj.normsMax = Convert.ToDouble(dgReadings["NormsMax", i].Value);
        //            GlobalVariables.lstDimensionNorm.Add(DimensionParameter_Class_obj);


        //            //PMFamilyMaster_Class_obj.dimensionParaID = Convert.ToInt32(dgReadings["DimensionParaID", i].Value);
        //            //PMFamilyMaster_Class_obj.normsMin = Convert.ToInt32(dgReadings["Min", i].Value);
        //            //PMFamilyMaster_Class_obj.normsMax = Convert.ToInt32(dgReadings["Max", i].Value);
        //            ////Check Exist norms in table tblPMFamilyDimensionMethodMaster 
        //            //DataTable dt = new DataTable();
        //            //dt = PMFamilyMaster_Class_obj.Select_DimensionParaRelation_PMFamilyIDTestNodimensionParaID();
        //            //if(dt.Rows.Count>0)
        //            //    flag = PMFamilyMaster_Class_obj.Update_PMFamilyDimensionMethodMaster();
        //            //else
        //            //    flag = PMFamilyMaster_Class_obj.Insert_PMFamilyDimensionMethodMaster();

        //        }

        //        //MessageBox.Show("Norms saved Successfully..!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //        this.Close();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //    //DataSet ds;          

        //    //if(RdoAccepted.Checked == true)
        //    //{
        //    //    FinishedGoodTest_Class_Obj.wastatus = 'A';
        //    //}
        //    //else if (RdoRejected.Checked == true)
        //    //{
        //    //    FinishedGoodTest_Class_Obj.wastatus = 'R';
        //    //}
        //    //else if (RdoRejected.Checked == true)
        //    //{
        //    //    FinishedGoodTest_Class_Obj.wastatus = 'H';
        //    //}
        //    //FinishedGoodTest_Class_Obj.inspectedby = Convert.ToInt32(cmbInspectedBy.SelectedValue);
        //    //FinishedGoodTest_Class_Obj.loginid = FrmMain.LoginID;           

        //    //ds = new DataSet();
        //    //ds = FinishedGoodTest_Class_Obj.Select_tblWAStatus_WATransID();
        //    //if (ds.Tables[0].Rows.Count > 0)
        //    //{
        //    //    FinishedGoodTest_Class_Obj.statusid = Convert.ToInt64(ds.Tables[0].Rows[0]["StatusID"]);
        //    //    FinishedGoodTest_Class_Obj.Update_tblWAStatus();
        //    //}
        //    //else
        //    //{
        //    //    FinishedGoodTest_Class_Obj.statusid = FinishedGoodTest_Class_Obj.Insert_tblWAStatus();
        //    //}

        //    //FinishedGoodTest_Class_Obj.Delete_tblWAObs();

        //    //for (int i = 0; i < dgReadings.Columns.Count; i++)
        //    //{
        //    //    for (int j = 0; j < dgReadings.Rows.Count; j++)
        //    //    {
        //    //        if (dgReadings[i, j].Value != null && dgReadings[i, j].Value.ToString().Trim() != "")
        //    //        {
        //    //            FinishedGoodTest_Class_Obj.obs = Convert.ToDouble(dgReadings[i, j].Value);
        //    //            FinishedGoodTest_Class_Obj.Insert_tblWAObs();
        //    //        }
        //    //    }
        //    //}

        //    //FinishedGoodTest_Class_Obj.Update_tblWATrans_WADone();

        //    //MessageBox.Show("Observations saved Successfully..!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //    //this.Close();
        //}

        private void dgReadings_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgReadings.CurrentCell.RowIndex < 0)
            {
                return;
            }
            else
            {
                dgReadings.EditingControl.KeyPress += new KeyPressEventHandler(EditingControl_KeyPress);
            }
        }

        void EditingControl_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace,  period, enter and tab
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&
                 e.KeyChar != 46 &&
                 e.KeyChar != 13 &&
                 e.KeyChar != 9)
            {
                e.Handled = true;
            }
        }


        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnExit_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSave_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < dgReadings.Columns.Count; i++)
            {
                for (int j = 0; j < dgReadings.Rows.Count; j++)
                {
                    if (dgReadings[i, j].Value == null || dgReadings[i, j].Value.ToString().Trim() == "")
                    {
                        MessageBox.Show("Enter all Norms", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dgReadings.Focus();
                        return;
                    }
                }
            }

            for (int i = 0; i < dgReadings.Rows.Count; i++)
            {
                DimensionParameter_Class DimensionParameter_Class_obj = new DimensionParameter_Class();
                //bool flag = false;
                //PMFamily & Testno get in constructor
                DimensionParameter_Class_obj.pmfamilyid = PMFamilyMaster_Class_obj.pmfamilyid;
                DimensionParameter_Class_obj.testNo = PMFamilyMaster_Class_obj.testNo;
                DimensionParameter_Class_obj.dimensionParaID = Convert.ToInt32(dgReadings["DimensionParaID", i].Value);
                DimensionParameter_Class_obj.normsMin = Convert.ToDouble(dgReadings["NormsMin", i].Value);
                DimensionParameter_Class_obj.normsMax = Convert.ToDouble(dgReadings["NormsMax", i].Value);
                GlobalVariables.lstDimensionNorm.Add(DimensionParameter_Class_obj);
            }
            MessageBox.Show("Observations saved Successfully..!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }
    }
}