using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessFacade.Transactions;
using QTMS.Tools;
namespace QTMS.Transactions
{
    public partial class FrmConsumerComplaintTest : Form
    {
        public class Detail
        {           
            public long D_FNo;
            public long D_OdsID;
            public char Done;
        }

        public FrmConsumerComplaintTest(FrmConsumerComplaintTest.Detail Detail)
        {            
            InitializeComponent();
            ConsumerComplaint_Class_obj.fno = Detail.D_FNo;
            ConsumerComplaint_Class_obj.obsid = Detail.D_OdsID;
            Done = Detail.Done;
        }

        BusinessFacade.Transactions.ConsumerComplaint_Class ConsumerComplaint_Class_obj = new ConsumerComplaint_Class();
        char Done;

        private void FrmConsumerComplaintTest_Load(object sender, EventArgs e)
        {
            Painter.Paint(this);

            DataSet dsTests = new DataSet();            
            if (Done == 'N')
            {
                dsTests = ConsumerComplaint_Class_obj.Select_tblFGPhysicochemicalTestMethodMaster_FNo();
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
                        }
                        else if (dsTests.Tables[0].Rows[i]["TestType"].ToString() == "Control")
                        {
                            dgConTest.Rows.Add();
                            dgConTest["FGPhyMethodNoCon", dgConTest.Rows.Count - 1].Value = dsTests.Tables[0].Rows[i]["FGPhyMethodNo"].ToString();
                            dgConTest["TestCon", dgConTest.Rows.Count - 1].Value = dsTests.Tables[0].Rows[i]["Details"].ToString();
                            dgConTest["MinCon", dgConTest.Rows.Count - 1].Value = dsTests.Tables[0].Rows[i]["NormsMin"].ToString();
                            dgConTest["MaxCon", dgConTest.Rows.Count - 1].Value = dsTests.Tables[0].Rows[i]["NormsMax"].ToString();                            
                        }
                    }
                }
            }
            else if (Done == 'Y')
            {
                dsTests = ConsumerComplaint_Class_obj.Select_tblComplaintPhysicoChemicalTestMethodDetails_ObsID();
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

                            dgIdTest["Reading", dgIdTest.Rows.Count - 1].Value = dsTests.Tables[0].Rows[i]["NormsReading"].ToString();

                            //add retainer reading column if retainer readings already exists 
                            if (dsTests.Tables[0].Rows[i]["RetainerReading"] is System.DBNull)
                            {

                            }
                            else
                            {
                                if (!dgIdTest.Columns.Contains("Retainer"))
                                {
                                    dgIdTest.Columns.Add("Retainer", "Retainer Readings");
                                    dgIdTest.Columns["Retainer"].Width = 70;
                                }
                                dgIdTest["Retainer", dgIdTest.Rows.Count - 1].Value = dsTests.Tables[0].Rows[i]["RetainerReading"].ToString();
                            }
                        }
                        else if (dsTests.Tables[0].Rows[i]["TestType"].ToString() == "Control")
                        {
                            dgConTest.Rows.Add();
                            dgConTest["FGPhyMethodNoCon", dgConTest.Rows.Count - 1].Value = dsTests.Tables[0].Rows[i]["FGPhyMethodNo"].ToString();
                            dgConTest["TestCon", dgConTest.Rows.Count - 1].Value = dsTests.Tables[0].Rows[i]["Details"].ToString();
                            dgConTest["MinCon", dgConTest.Rows.Count - 1].Value = dsTests.Tables[0].Rows[i]["NormsMin"].ToString();
                            dgConTest["MaxCon", dgConTest.Rows.Count - 1].Value = dsTests.Tables[0].Rows[i]["NormsMax"].ToString();

                            dgConTest["ReadingCon", dgConTest.Rows.Count - 1].Value = dsTests.Tables[0].Rows[i]["NormsReading"].ToString();

                            //add retainer reading column if retainer readings already exists 
                            if (dsTests.Tables[0].Rows[i]["RetainerReading"] is System.DBNull)
                            {

                            }
                            else
                            {
                                if (!dgConTest.Columns.Contains("Retainer"))
                                {
                                    dgConTest.Columns.Add("Retainer", "Retainer Readings");
                                    dgConTest.Columns["Retainer"].Width = 70;
                                }
                                dgConTest["Retainer", dgConTest.Rows.Count - 1].Value = dsTests.Tables[0].Rows[i]["RetainerReading"].ToString();
                            }
                        }
                    }
                }
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
                //Delete previous records
                ConsumerComplaint_Class_obj.Delete_tblComplaintPhysicoChemicalTestMethodDetails_ObsID();

                for (int i = 0; i < dgIdTest.Rows.Count; i++)
                {
                    if (dgIdTest["Reading", i].Value != null && dgIdTest["Reading", i].Value.ToString().Trim() != "")
                    {
                        ConsumerComplaint_Class_obj.fgphymethodno = Convert.ToInt64(dgIdTest["FGPhyMethodNo", i].Value);
                        ConsumerComplaint_Class_obj.normsmin = dgIdTest["Min", i].Value.ToString();
                        ConsumerComplaint_Class_obj.normsmax = dgIdTest["Max", i].Value.ToString();
                        ConsumerComplaint_Class_obj.normsreading = dgIdTest["Reading", i].Value.ToString();

                        if (dgIdTest.Columns.Contains("Retainer") && dgIdTest["Retainer", i].Value != null)
                        {
                            ConsumerComplaint_Class_obj.retainerreading = dgIdTest["Retainer", i].Value.ToString();
                        }
                        else
                        {
                            ConsumerComplaint_Class_obj.retainerreading = null;
                        }
                        
                        ConsumerComplaint_Class_obj.Insert_tblComplaintPhysicoChemicalTestMethodDetails();
                    }
                }
                for (int i = 0; i < dgConTest.Rows.Count; i++)
                {
                    if (dgConTest["ReadingCon", i].Value != null && dgConTest["ReadingCon", i].Value.ToString().Trim() != "")
                    {
                        ConsumerComplaint_Class_obj.fgphymethodno = Convert.ToInt64(dgConTest["FGPhyMethodNoCon", i].Value);
                        ConsumerComplaint_Class_obj.normsmin = dgConTest["MinCon", i].Value.ToString();
                        ConsumerComplaint_Class_obj.normsmax = dgConTest["MaxCon", i].Value.ToString();
                        ConsumerComplaint_Class_obj.normsreading = dgConTest["ReadingCon", i].Value.ToString();

                        if (dgConTest.Columns.Contains("Retainer") && dgConTest["Retainer", i].Value != null)
                        {
                            ConsumerComplaint_Class_obj.retainerreading = dgConTest["Retainer", i].Value.ToString();
                        }
                        else
                        {
                            ConsumerComplaint_Class_obj.retainerreading = null;
                        }

                        ConsumerComplaint_Class_obj.Insert_tblComplaintPhysicoChemicalTestMethodDetails();
                    }
                }
            
                               
                MessageBox.Show("Test Details Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgIdTest_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (dgIdTest.CurrentCell.RowIndex >= 0
                            || (dgIdTest.CurrentCell.ColumnIndex >= 3))
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
                || (dgConTest.CurrentCell.ColumnIndex >= 3))
            {
                dgConTest.EditingControl.KeyPress += new KeyPressEventHandler(EditingControl_KeyPress);
            }
        }

        private void btnRetainer_Click(object sender, EventArgs e)
        {
            //Add Readings columns to grid to save retainer readings

            if (!dgIdTest.Columns.Contains("Retainer"))
            {
                dgIdTest.Columns.Add("Retainer", "Retainer Readings");
                dgIdTest.Columns["Retainer"].Width = 70;
            }
            if (!dgConTest.Columns.Contains("Retainer"))
            {
                dgConTest.Columns.Add("Retainer", "Retainer Readings");
                dgConTest.Columns["Retainer"].Width = 70;
            }
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       


    }
}