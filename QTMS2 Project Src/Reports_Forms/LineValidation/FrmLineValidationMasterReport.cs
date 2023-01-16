using BusinessFacade;
using CrystalDecisions.Shared;
using QTMS.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace QTMS.Reports_Forms.LineValidation
{
    public partial class FrmLineValidationMasterReport : Form
    {
        LineMaster_Class LayoutLineMaster_Class_Obj = new LineMaster_Class();
        LayoutLineValidationTransaction_Class LayoutLineValidationTransaction_Class_Obj = new LayoutLineValidationTransaction_Class();
        List<LayoutLineValidationTransaction_Class> ListLayoutLineValidationTransaction_Class = new List<LayoutLineValidationTransaction_Class>();


        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();

        Reports.LineTransactionMasterReport LineTransactionMasterReport = new QTMS.Reports.LineTransactionMasterReport();
         
        public FrmLineValidationMasterReport()
        {
            InitializeComponent();
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmLineValidationMasterReport_Load(object sender, EventArgs e)
        {
            try
            {
                Painter.Paint(this);

                Bind_LineDescription();
                LayoutLineValidationTransaction_Class_Obj.loginuser = FrmMain.LoginID;
                dtpFromDate.Value = dtpToDate.Value = DateTime.Now;
                dtpFromDate.Checked = dtpToDate.Checked = false;
                toolStrip1.Items.Add(rptName);
                toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        private void Bind_LineDescription()
        {
            try
            {
                DataSet ds = LayoutLineMaster_Class_Obj.Select_LineMaster();
                DataRow dr = ds.Tables[0].NewRow();
                dr["LNo"] = "0";
                dr["LineDesc"] = "--Select--";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cbLineDescription.DataSource = ds.Tables[0];
                cbLineDescription.DisplayMember = "LineDesc";
                cbLineDescription.ValueMember = "LNo";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cbLineDescription_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void BindLineDescriptionTransaction()
        {
            ListLayoutLineValidationTransaction_Class = new List<LayoutLineValidationTransaction_Class>();
            DataSet ds = LayoutLineValidationTransaction_Class_Obj.Select_LayoutLineTransactionMasterByLineDescriptionId(Convert.ToInt64(cbLineDescription.SelectedValue));
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    int index = 1;
                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        LayoutLineValidationTransaction_Class Obj = new LayoutLineValidationTransaction_Class();
                        Obj.lineDescription = Convert.ToInt64(cbLineDescription.SelectedValue);
                        Obj.minValue = Convert.ToString(item["MinVal"]);
                        Obj.maxValue = Convert.ToString(item["MaxVal"]);
                        Obj.value = Convert.ToString(item["Value"]);
                        Obj.name = Convert.ToString(item["Name"]);
                        Obj.parameter = Convert.ToString(item["Parameter"]);
                        Obj.id = Convert.ToInt64(item["Id"]);
                        Obj.validFrom = Convert.ToDateTime(item["ValidFrom"]);
                        Obj.validTo = Convert.ToDateTime(item["ValidTo"]);
                        index++;
                        ListLayoutLineValidationTransaction_Class.Add(Obj);
                    }
                }
                else
                    ResetDescriptionTransaction();
            }
            else
                ResetDescriptionTransaction();
        }

        private void ResetDescriptionTransaction()
        {
            EmptyTextBoxes(panel1);
            ResetDtp();
        }

        private void ResetDtp()
        {
        }

        public static void EmptyTextBoxes(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c.GetType() == typeof(TextBox))
                {
                    ((TextBox)(c)).Text = string.Empty;
                }
            }
        }

        private void BindLineDescriptionTransactionGrid()
        {
            DataSet ds = LayoutLineValidationTransaction_Class_Obj.SelectAll_LayoutLineTransactionMasterByLineDescriptionId(Convert.ToInt64(cbLineDescription.SelectedValue));
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    
                }
                else
                    BindLineDescriptionTransactionDefault();
            }
            else
                BindLineDescriptionTransactionDefault();
        }

        private void BindLineDescriptionTransactionDefault()
        {
            
            MessageBox.Show("Record not found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvLineDescriptionTransaction_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private static FrmLineValidationMasterReport frm = null;
        string rptName;

        public static FrmLineValidationMasterReport GetInstance()
        {
            if (frm == null)
            {
                frm = new FrmLineValidationMasterReport();
            }
            frm.WindowState = FormWindowState.Maximized;
            return frm;
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbLineDescription.SelectedIndex == 0 || cbLineDescription.Text == "--Select--")
                {
                    MessageBox.Show("Please Select Line Description", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cbLineDescription.SelectedIndex <= 0)
                {
                    MessageBox.Show("Please select line discription", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (dtpFromDate.Value.Date > dtpToDate.Value.Date)
                {
                    MessageBox.Show("Please select valid from date to date", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    BindLineTransactionMasterReport();
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BindLineTransactionMasterReport()
        {
            try
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

                ParameterField LineDescription = new ParameterField();
                ParameterDiscreteValue LineDescriptionDescrete = new ParameterDiscreteValue();
                LineDescription.Name = "LineDescription";
                LineDescriptionDescrete.Value = cbLineDescription.Text;
                LineDescription.CurrentValues.Add(LineDescriptionDescrete);
                param1Fields.Add(LineDescription);


                ParameterField FromDate = new ParameterField(); 
                ParameterDiscreteValue FromDateDescrete = new ParameterDiscreteValue();
                FromDate.Name = "FromDate";
                FromDateDescrete.Value = dtpFromDate.Value.Date;
                FromDate.CurrentValues.Add(FromDateDescrete);
                param1Fields.Add(FromDate);


                ParameterField ToDate = new ParameterField();
                ParameterDiscreteValue ToDateDescrete = new ParameterDiscreteValue();
                ToDate.Name = "ToDate";
                ToDateDescrete.Value = dtpToDate.Value.Date; 
                ToDate.CurrentValues.Add(ToDateDescrete);
                param1Fields.Add(ToDate);
                #endregion

                ReportViewer.ParameterFieldInfo = param1Fields;
                DataSet ds = new DataSet();
                DataSet ds1 = new DataSet();
                if (dtpFromDate.Checked == true)
                {
                    Report_Class_Obj.fromDate = dtpFromDate.Value;
                }
                else
                {
                    Report_Class_Obj.fromDate = Convert.ToDateTime("1/1/1900 12:00:00 AM");
                }

                if (dtpToDate.Checked == true)
                {
                    Report_Class_Obj.toDate = dtpToDate.Value;
                }
                else
                {
                    Report_Class_Obj.toDate = Convert.ToDateTime("6/6/2079 11:59:59 PM");
                }
                ds = Report_Class_Obj.Select_LineTransactionMaster_Report(Convert.ToInt32(cbLineDescription.SelectedValue), Report_Class_Obj.fromDate, Report_Class_Obj.toDate);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    LineTransactionMasterReport.SetDataSource(ds.Tables[0]);
                    ReportViewer.ReportSource = LineTransactionMasterReport;
                    ReportViewer.Show();
                }
                else
                {
                    MessageBox.Show("Sorry Record Not Found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void ReportViewer_Load(object sender, EventArgs e)
        {

        }
    }
}
