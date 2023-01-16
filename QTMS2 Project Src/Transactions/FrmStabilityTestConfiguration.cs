using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QTMS.Tools;
using BusinessFacade;
using BusinessFacade.Transactions;

namespace QTMS.Transactions
{
    /// <summary>
    /// By Vijay Chavan 20-02-2021 
    /// </summary>
    public partial class FrmStabilityTestConfiguration : Form
    {
        public FrmStabilityTestConfiguration()
        {
            InitializeComponent();
        }
        #region Varibles

        BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        SatbilityTestConfiguration_Class SatbilityTestConfi_Class_Obj = new SatbilityTestConfiguration_Class();

        #endregion


        private static FrmStabilityTestConfiguration frmStabilityTestConfiguration_Obj = null;
        public static FrmStabilityTestConfiguration GetInstance()
        {
            if (frmStabilityTestConfiguration_Obj == null)
            {
                frmStabilityTestConfiguration_Obj = new FrmStabilityTestConfiguration();
            }
            return frmStabilityTestConfiguration_Obj;
        }

        /// <summary>
        /// Form load method 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmStabilityTestConfiguration_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);
            DtpWeekDate.Value = Comman_Class_Obj.Select_ServerDate();
           // DtpWeekDate.MinDate = DateTime.Now;
            Bind_FormulaNo();
        }

        public void Bind_FormulaNo()
        {
            DataSet ds = new DataSet();
            DataRow dr;
            ds = SatbilityTestConfi_Class_Obj.SELECT_NewLunch_FormulaNo();
            dr = ds.Tables[0].NewRow();
            dr["FormulaNo"] = "--Select--";
            // dr["FNo"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                CmbFormulaNo.DataSource = ds.Tables[0];
                CmbFormulaNo.ValueMember = "FNo";
                CmbFormulaNo.DisplayMember = "FormulaNo";
            }

        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            CmbFormulaNo.Text = "--Select--";
            DtpWeekDate.Value = Comman_Class_Obj.Select_ServerDate();
            txtDescription.Text = "";
            txtMfgWoNo.Text = "";
            txtTechnicalFamily.Text = "";
            DtpInspectedDate.Value = Comman_Class_Obj.Select_ServerDate();
            DtpCompletedDate.Value = Comman_Class_Obj.Select_ServerDate();
              //dgTest.Rows.Clear();
              
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {           
            if (CmbFormulaNo.Text == "--Select--")
            {
                MessageBox.Show("Select Formula No", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                CmbFormulaNo.Focus();
                return;
            }
                DataSet ds = new DataSet();
                SatbilityTestConfi_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue.ToString());
                ds = SatbilityTestConfi_Class_Obj.SELECT_StabilityTestConfi_NewLunch_FormulaNoDetails();

                if (DtpWeekDate.Value < Convert.ToDateTime(ds.Tables[0].Rows[0]["CompletedOn"].ToString()))
                {
                    MessageBox.Show("Week 1 Date Should not be Less than the Completion Date ", "Warnning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    DtpWeekDate.Focus();
                    return;
                }

             //string Formulano = CmbFormulaNo.SelectedText;

            DialogResult dr = MessageBox.Show("Formula No is " + CmbFormulaNo.Text + " and Week1 is " + DtpWeekDate.Value.ToShortDateString() + "\n\n Insert ??", "", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
             if (dr == DialogResult.Yes)
             {
                 SatbilityTestConfi_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue.ToString());
                 SatbilityTestConfi_Class_Obj.week1date = DtpWeekDate.Value.ToShortDateString();
                 
                 SatbilityTestConfi_Class_Obj.Insert_tblStabilityTestConfiguration_Details();
                 MessageBox.Show("Record Saved Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                 BtnReset_Click(sender, e);
                 
             }
             else
             {
                 // If 'No', do something here.
             }

         }
         catch (Exception ex)
         {

             MessageBox.Show(ex.Message);
         }
         
          
        }

        private void CmbFormulaNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                DtpWeekDate.Value = Comman_Class_Obj.Select_ServerDate();
                txtDescription.Text = "";
                txtMfgWoNo.Text = "";
                txtTechnicalFamily.Text = "";
                DtpInspectedDate.Value = Comman_Class_Obj.Select_ServerDate();
                DtpCompletedDate.Value = Comman_Class_Obj.Select_ServerDate();

                SatbilityTestConfi_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue.ToString());
                DataSet dsFNo = new DataSet();
                dsFNo = SatbilityTestConfi_Class_Obj.Check_StabilityTestConfi_NewLunch_Week1Date();

                DataSet ds = new DataSet();
                ds = SatbilityTestConfi_Class_Obj.SELECT_StabilityTestConfi_NewLunch_FormulaNoDetails();
                SatbilityTestConfi_Class_Obj.formulano = Convert.ToString(CmbFormulaNo.SelectedText.ToString());
               

                if (dsFNo.Tables[0].Rows.Count > 0)
                {
                    DateTime SetDate = Convert.ToDateTime(dsFNo.Tables[0].Rows[0]["Week1Date"].ToString());
                   // SatbilityTestConfi_Class_Obj.formulano = Convert.ToString(CmbFormulaNo.SelectedText.ToString());
                   //CmbFormulaNo.Text;

                  //  if (MessageBox.Show("For the Selected Formula No Date of Week1 is already set as " + SetDate.ToShortDateString() + " !", "Message", MessageBoxButtons.OK, MessageBoxIcon.Question).Equals(DialogResult.OK))
                 //   {
                        DtpWeekDate.Value = Convert.ToDateTime(dsFNo.Tables[0].Rows[0]["Week1Date"].ToString());
                        txtMfgWoNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["MfgWo"]);
                        txtDescription.Text = Convert.ToString(ds.Tables[0].Rows[0]["bulkdesc"]);
                        txtTechnicalFamily.Text = Convert.ToString(ds.Tables[0].Rows[0]["FamilyDesc"]);
                        if (ds.Tables[0].Rows[0]["InspDate"] is DBNull)
                        {
                            DtpInspectedDate.Value = Comman_Class_Obj.Select_ServerDate();
                        }
                        else
                        {
                            DtpInspectedDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["InspDate"].ToString());
                        }
                        DtpCompletedDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["CompletedOn"].ToString());
                        BtnSave.Enabled = false;
                        DtpWeekDate.Enabled = false;
                       
                       // return;
                        MessageBox.Show("For the Selected Formula No Date of Week 1 is already set as " + SetDate.ToShortDateString() + " ", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   // }

                }
                else
                {
                    txtMfgWoNo.Text = Convert.ToString(ds.Tables[0].Rows[0]["MfgWo"]);
                    txtDescription.Text = Convert.ToString(ds.Tables[0].Rows[0]["bulkdesc"]);
                    txtTechnicalFamily.Text = Convert.ToString(ds.Tables[0].Rows[0]["FamilyDesc"]);
                    if (ds.Tables[0].Rows[0]["InspDate"] is DBNull)
                    {
                        DtpInspectedDate.Value = Comman_Class_Obj.Select_ServerDate();
                    }
                    else
                    {
                        DtpInspectedDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["InspDate"].ToString());
                    }
                    DtpCompletedDate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["CompletedOn"].ToString());
                    BtnSave.Enabled = true;
                    DtpWeekDate.Enabled = true;
                }


               

               

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

     
    
    }
}