using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessFacade.Transactions;
using CrystalDecisions.Shared;
using QTMS.Reports;
using QTMS.Tools;

namespace QTMS.Reports_Forms
{
    public partial class FrmReagentRorderLevel : Form
    {
        Reagent_Report_Class Reagent_Report_Class_obj = new Reagent_Report_Class();
        public FrmReagentRorderLevel()
        {
            InitializeComponent();
        }
        private static FrmReagentRorderLevel FrmReagentRorderLevel_obj = null;
        internal static FrmReagentRorderLevel GetInstance()
        {
            if (FrmReagentRorderLevel_obj == null)
            {
                FrmReagentRorderLevel_obj = new Reports_Forms.FrmReagentRorderLevel();
            }
            return FrmReagentRorderLevel_obj;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmReagentRorderLevel_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
          //  Painter.Paint(this);
            //txtPercentage.Location.X = 275;
            //txtPercentage.Location.Y  = 27;
            //lblPercentage.Location .X=9;
            //lblPercentage.Location.Y = 29;
            
        }

        private void ShowReport()
        {
            //try
            //{
            //    Cursor.Current = Cursors.WaitCursor;


            //    DataSet ds = new DataSet();

            //    //long PMsuppliercocid = Convert.ToInt64(cmbRACode.SelectedValue);

            //    if (txtPercentage.Text != "")
            //    {
            //        //validation - range 0-100
            //        double percentage = Convert.ToDouble(txtPercentage.Text);

            //        percentage = percentage / 100;

            //        ds = Reagent_Report_Class_obj.SelectReorderLevel(percentage);
            //    }
            //    {
            //        MessageBox.Show("Enter percentage level! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            //    }
             

            //    if (ds.Tables[0].Rows.Count > 0)
            //    {
            //        ParameterFields param1Fields = new ParameterFields();

            //        #region CompanyName and Address
            //        ParameterField CompanyName = new ParameterField();
            //        ParameterDiscreteValue CompanyNameDescrete = new ParameterDiscreteValue();
            //        CompanyName.Name = "CompanyName";
            //        CompanyNameDescrete.Value = GlobalVariables.companyName;
            //        CompanyName.CurrentValues.Add(CompanyNameDescrete);
            //        param1Fields.Add(CompanyName);

            //        ParameterField CompanyAddress = new ParameterField();
            //        ParameterDiscreteValue CompanyAddressDescrete = new ParameterDiscreteValue();
            //        CompanyAddress.Name = "CompanyAddress";
            //        CompanyAddressDescrete.Value = GlobalVariables.companyAddress;
            //        CompanyAddress.CurrentValues.Add(CompanyAddressDescrete);
            //        param1Fields.Add(CompanyAddress);
            //        #endregion

            //        ReagentReorderLevel_Report objReagentReorderLevel_Report = new ReagentReorderLevel_Report();

            //        objReagentReorderLevel_Report.SetDataSource(ds.Tables[0]);
            //        ReportViewer.ParameterFieldInfo = param1Fields;
            //        ReportViewer.ReportSource = objReagentReorderLevel_Report;
            //        ReportViewer.Show();
            //    }
            //    else
            //    {
            //        ReportViewer.ReportSource = null;
            //        MessageBox.Show("No Record Found");
            //    }
            //    Cursor.Current = Cursors.Default;
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;


                DataSet ds = new DataSet();

                //long PMsuppliercocid = Convert.ToInt64(cmbRACode.SelectedValue);

                if (txtPercentage.Text == "")
                {
                    MessageBox.Show("Enter percentage level! ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                {
                   
                    //validation - range 0-100
                    double percentage = Convert.ToDouble(txtPercentage.Text);

                    percentage = percentage / 100;

                    ds = Reagent_Report_Class_obj.SelectReorderLevel(percentage);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ParameterFields param1Fields = new ParameterFields();

                        #region CompanyName and Address
                        ParameterField CompanyName = new ParameterField();
                        ParameterDiscreteValue CompanyNameDescrete = new ParameterDiscreteValue();
                        CompanyName.Name = "CompanyName";
                        CompanyNameDescrete.Value = GlobalVariables.companyName;
                        CompanyName.CurrentValues.Add(CompanyNameDescrete);
                        param1Fields.Add(CompanyName);

                        ParameterField CompanyAddress = new ParameterField();
                        ParameterDiscreteValue CompanyAddressDescrete = new ParameterDiscreteValue();
                        CompanyAddress.Name = "CompanyAddress";
                        CompanyAddressDescrete.Value = GlobalVariables.companyAddress;
                        CompanyAddress.CurrentValues.Add(CompanyAddressDescrete);
                        param1Fields.Add(CompanyAddress);
                        #endregion

                        ReagentReorderLevel_Report objReagentReorderLevel_Report = new ReagentReorderLevel_Report();

                        objReagentReorderLevel_Report.SetDataSource(ds.Tables[0]);
                        ReportViewer.ParameterFieldInfo = param1Fields;
                        ReportViewer.ReportSource = objReagentReorderLevel_Report;
                        ReportViewer.Show();
                    }
                    else
                    {
                        ReportViewer.ReportSource = null;
                        MessageBox.Show("No Record Found");
                    }
                    Cursor.Current = Cursors.Default;
                }


                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtPercentage_KeyPress(object sender, KeyPressEventArgs e)
        {
            //only allow 0 to 9, backspace, enter and tab
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 &&
                  e.KeyChar != 13 &&
                 e.KeyChar != 9)
            {

                e.Handled = true;

            }
            //if (e.KeyChar ==46)
            //{
            //    e.Handled = false ;
            //}
        }

        private void txtPercentage_Leave(object sender, EventArgs e)
        {
            if (txtPercentage.Text != "" && Convert.ToDouble(txtPercentage.Text) > 100)
            {
                MessageBox.Show("Percentage Range must be between 0 to 100", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
        }

         

         
    }
}