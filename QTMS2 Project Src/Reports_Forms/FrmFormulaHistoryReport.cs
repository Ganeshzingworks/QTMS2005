using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using QTMS.Tools;


namespace QTMS.Reports_Forms
{
    public partial class FrmFormulaHistoryReport : Form
    {
        public string rptName;

        public FrmFormulaHistoryReport(string RptName)
        {
            this.rptName = RptName;
            InitializeComponent();
        }
        # region Varibles
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();
        BusinessFacade.Transactions.BulktestDetailstransaction_Class BulktestDetailstransaction_Class_Qbj = new BusinessFacade.Transactions.BulktestDetailstransaction_Class();
        //BusinessFacade.FormulaNoMaster_Class FormulaNoMaster_Class_Obj = new BusinessFacade.FormulaNoMaster_Class();

        Reports.FormulaHistory_Report FormulaHistory = new QTMS.Reports.FormulaHistory_Report();
        
        # endregion

        private void FrmFormulaHistoryReport_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            toolStrip1.Items.Add(rptName);
            toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);
      

            BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
            DtpDateFrom.Value = Comman_Class_Obj.Select_ServerDate();
            DtpDateTo.Value = Comman_Class_Obj.Select_ServerDate();
            DtpDateFrom.Checked = false;
            DtpDateTo.Checked = false;
            cmbFormulaType.SelectedIndex = 0;
            Bind_Formula();            
        }

        public void Bind_Formula()
        {
            DataRow dr;
            DataSet ds = new DataSet();
            ds = BulktestDetailstransaction_Class_Qbj.Select_tblTransFM_tblBulkTestTransaction();
            dr = ds.Tables[0].NewRow();
            dr["FormulaNo"] = "--Select--";
            dr["FNo"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            cmbFormulaNo.DataSource = ds.Tables[0];
            cmbFormulaNo.DisplayMember = "FormulaNo";
            cmbFormulaNo.ValueMember = "FNo";
        }

        private void cmbFormulaNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                if (cmbFormulaNo.SelectedValue != null && cmbFormulaNo.SelectedValue.ToString() != "")
                {
                    DataRow dr;
                    DataSet ds = new DataSet();
                    BulktestDetailstransaction_Class_Qbj.fno = Convert.ToInt64(cmbFormulaNo.SelectedValue);
                    ds = BulktestDetailstransaction_Class_Qbj.Select_tblBulkTestTransaction_BatchSize();
                    dr = ds.Tables[0].NewRow();
                    dr["BatchSize"] = "--ALL--";                   
                    ds.Tables[0].Rows.InsertAt(dr, 0);
                    cmbBactSize.DataSource = ds.Tables[0];
                    cmbBactSize.DisplayMember = "BatchSize";                    
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbFormulaNo.SelectedValue == null || cmbFormulaNo.Text == "--Select--")
                {
                    MessageBox.Show("Select Formula No...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cmbFormulaNo.Focus();
                    return;
                }

                if (cmbBactSize.SelectedValue == null)
                {
                    MessageBox.Show("Select BatchSize...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    cmbBactSize.Focus();
                    return;
                }
                pictureBox1.Visible = true;
                DataSet ds = new DataSet();

                if (DtpDateFrom.Checked == true)
                {
                    Report_Class_Obj.fromdate = DtpDateFrom.Value.ToShortDateString();
                }
                else
                {
                    Report_Class_Obj.fromdate = Convert.ToDateTime("1/1/1900 12:00:00 AM").ToShortDateString();
                }

                if (DtpDateTo.Checked == true)
                {
                    Report_Class_Obj.todate = DtpDateTo.Value.ToShortDateString();
                }
                else
                {
                    Report_Class_Obj.todate = Convert.ToDateTime("6/6/2079 11:59:59 PM").ToShortDateString();
                }

                Report_Class_Obj.fno = Convert.ToInt64(cmbFormulaNo.SelectedValue);

                if (cmbBactSize.Text.Trim() == "--ALL--")
                {
                    Report_Class_Obj.batchsize = 0;
                }
                else
                {
                    Report_Class_Obj.batchsize = Convert.ToInt32(cmbBactSize.Text);
                }

                if (cmbFormulaType.Text == "Validated")
                {
                    Report_Class_Obj.formulatype = "Validated";
                }
                else if (cmbFormulaType.Text == "NonValidated")
                {
                    Report_Class_Obj.formulatype = "NonValidated";
                }

                switch (rptName)
                {
                    case "FormulaHistory":
                        ds = Report_Class_Obj.Select_VIEW_FormulaHistory_Report();
                        break;

                   
                }


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
                    ReportViewer.ParameterFieldInfo = param1Fields;

                    switch (rptName)
                    {
                        case "FormulaHistory":
                            FormulaHistory.SetDataSource(ds.Tables[0]);
                            ReportViewer.ReportSource = FormulaHistory;                            
                            ReportViewer.Show();
                            break;                        
                    }
                }
                else
                {
                    pictureBox1.Visible = false;
                    MessageBox.Show("Sorry Record Not Found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                pictureBox1.Visible = false;
            }
            catch (Exception ex)
            {
                pictureBox1.Visible = false;
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

       





    }
}