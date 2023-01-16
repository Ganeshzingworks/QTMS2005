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
    public partial class FrmReagentDetails : Form
    {
        Reagent_Report_Class Reagent_Report_Class_obj = new Reagent_Report_Class();
        ReagentTransaction_Class ReagentTransaction_Class_objRpt = new ReagentTransaction_Class();
        public FrmReagentDetails()
        {
            InitializeComponent();
        }

        private static FrmReagentDetails FrmReagentDetails_Obj = null;
        internal static FrmReagentDetails GetInstance()
        {
            if (FrmReagentDetails_Obj == null)
            {
                FrmReagentDetails_Obj = new Reports_Forms.FrmReagentDetails();
            }
            return FrmReagentDetails_Obj;
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (cmbRACode.Text == "--Select--")
                {
                    MessageBox.Show("Please Select RACode", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (DtpDateFrom.Checked == true)
                {
                    System.Globalization.CultureInfo enUS = System.Globalization.CultureInfo.CurrentCulture;

                    String fromdate = Convert.ToDateTime(DtpDateFrom.Value.ToShortDateString(), enUS).ToString("MM/dd/yyyy");

                    Reagent_Report_Class_obj.fromdate = fromdate;
                }
                else
                {
                    Reagent_Report_Class_obj.fromdate = Convert.ToDateTime("1/1/1900 12:00:00 AM").ToShortDateString();
                }

                if (DtpDateTo.Checked == true)
                {

                    System.Globalization.CultureInfo enUS = System.Globalization.CultureInfo.CurrentCulture;

                    String todate = Convert.ToDateTime(DtpDateTo.Value.ToShortDateString(), enUS).ToString("MM/dd/yyyy");

                    Reagent_Report_Class_obj.todate = todate;
                    //                    Report_Class_Obj.todate = DtpDateTo.Value.ToShortDateString();
                }
                else
                {
                    Reagent_Report_Class_obj.todate = Convert.ToDateTime("6/6/2079 11:59:59 PM").ToShortDateString();
                }




                DataSet ds = new DataSet();

                long PMsuppliercocid = Convert.ToInt64(cmbRACode.SelectedValue);

                ds = Reagent_Report_Class_obj.GenerateReagent_Details_Report();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ParameterFields param1Fields = new ParameterFields();

                    ParameterField FromDate = new ParameterField();
                    ParameterField ToDate = new ParameterField();
                    ParameterDiscreteValue FromDateDescrete = new ParameterDiscreteValue();
                    ParameterDiscreteValue ToDateDescrete = new ParameterDiscreteValue();
                    FromDate.Name = "FromDate";
                    if (DtpDateFrom.Checked == true)
                    {
                        FromDateDescrete.Value = DtpDateFrom.Value.ToShortDateString();
                    }
                    else
                    {
                        FromDateDescrete.Value = "";
                    }
                    FromDate.CurrentValues.Add(FromDateDescrete);

                    ToDate.Name = "ToDate";
                    if (DtpDateTo.Checked == true)
                    {
                        ToDateDescrete.Value = DtpDateTo.Value.ToShortDateString();
                    }
                    else
                    {
                        ToDateDescrete.Value = "";
                    }
                    ToDate.CurrentValues.Add(ToDateDescrete);

                    param1Fields.Add(FromDate);
                    param1Fields.Add(ToDate);

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

                    //ReagentDetails_Report objReagentDetails_Report = new ReagentDetails_Report();
                    ReagentDetails_Report_New objReagentDetails_Report = new ReagentDetails_Report_New();

                    objReagentDetails_Report.SetDataSource(ds.Tables[0]);
                    ReportViewer.ParameterFieldInfo = param1Fields;
                    ReportViewer.ReportSource = objReagentDetails_Report;
                    ReportViewer.Show();
                }
                else
                {
                    ReportViewer.ReportSource = null;
                    MessageBox.Show("Sorry Record Not Found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmReagentDetails_Load(object sender, EventArgs e)
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
                dr["RACode"] = "--Select--";
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
                    Reagent_Report_Class_obj.reagentid = Convert.ToInt64(cmbRACode.SelectedValue.ToString());
                }
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