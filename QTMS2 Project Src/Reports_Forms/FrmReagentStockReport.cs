using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessFacade.Transactions;
using QTMS.Reports;
using CrystalDecisions.Shared;
using QTMS.Tools;

namespace QTMS.Reports_Forms
{
    public partial class FrmReagentStockReport : Form
    {
        Reagent_Report_Class Reagent_Report_Class_obj = new Reagent_Report_Class();
        ReagentTransaction_Class ReagentTransaction_Class_objRpt = new ReagentTransaction_Class();
        public FrmReagentStockReport()
        {
            InitializeComponent();
        }
        private static FrmReagentStockReport FrmReagentStockReport_Obj = null;
        internal static FrmReagentStockReport GetInstance()
        {
            if (FrmReagentStockReport_Obj == null)
            {
                FrmReagentStockReport_Obj = new Reports_Forms.FrmReagentStockReport();
            }
            return FrmReagentStockReport_Obj;
        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void FrmReagentStockReport_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);
            bind_RACode();
        }

        private void bind_RACode()
        {
            try
            {
                DataRow dr;
                DataSet ds = new DataSet();
                ds = ReagentTransaction_Class_objRpt.Select_tblReagent_RACode();
                dr = ds.Tables[0].NewRow();
                dr["RACode"] = "--ALL--";
                dr["ReagentID"] = "0";
                ds.Tables[0].Rows.InsertAt(dr, 0);

               
                cmbRACode.DataSource = ds.Tables[0];
                cmbRACode.DisplayMember = "RACode";
                cmbRACode.ValueMember = "ReagentID";


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbRACode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {

                if (cmbRACode.SelectedValue != null)
                {
                    Reagent_Report_Class_obj.reagentid  = Convert.ToInt64(cmbRACode.SelectedValue.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                //if (cmbRACode.Text == "--Select--")
                //{
                //    MessageBox.Show("Please Select RACode", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return;
                //}

                DataSet ds = new DataSet();

                long PMsuppliercocid = Convert.ToInt64(cmbRACode.SelectedValue);

                ds = Reagent_Report_Class_obj.GenerateReagentStockReport();

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

                    ReagentAvailableStock_Report objReagentAvailableStock_Report = new ReagentAvailableStock_Report();
                     
                    objReagentAvailableStock_Report.SetDataSource(ds.Tables[0]);
                    ReportViewer.ParameterFieldInfo = param1Fields;
                    ReportViewer.ReportSource = objReagentAvailableStock_Report;
                    ReportViewer.Show();
                }
                else
                {
                    ReportViewer.ReportSource = null;
                }
                 Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbRACode_SelectedIndexChanged(object sender, EventArgs e)
        {
            ReportViewer.ReportSource = null;
        }
    }
}