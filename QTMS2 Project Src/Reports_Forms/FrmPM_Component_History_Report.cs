using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessFacade;
using BusinessFacade.Transactions;
using QTMS.Tools;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace QTMS.Reports_Forms
{
    public partial class FrmPM_Component_History_Report : Form
    {
        # region Varibles
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();
       //RMCodeMaster_Class RMCodeMaster_Class_Obj = new RMCodeMaster_Class();
        PMMaster_Class PMMaster_Class_obj = new PMMaster_Class();
        BusinessFacade.Transactions.PMTransaction_Class pmTransaction_Class_Obj = new PMTransaction_Class();
        PMMaster_Class pmMaster_Obj = new PMMaster_Class();
        # endregion

        public FrmPM_Component_History_Report()
        {
            InitializeComponent();
        }

        private void PM_Component_History_Report_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

           // toolStrip1.Items.Add(rptName);
            toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);

            BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
            DtpDateFrom.Value = Comman_Class_Obj.Select_ServerDate();
            DtpDateTo.Value = Comman_Class_Obj.Select_ServerDate();
            DtpDateFrom.Checked = false;
            DtpDateTo.Checked = false;
            //Bind_PMCode();
            Bind_Supplier();
        }

        public void Bind_PMCode()
        {
            try
            {
                DataRow dr;
                DataSet ds = new DataSet();
                ds = PMMaster_Class_obj.Select_PMMaster();
                dr = ds.Tables[0].NewRow();
                dr["PMCode"] = "--All--";
                dr["PMCodeID"] = "0";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmbPMCode.DataSource = ds.Tables[0];
                cmbPMCode.DisplayMember = "PMCode";
                cmbPMCode.ValueMember = "PMCodeID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void Bind_Supplier()
        {
            try
            {
                DataRow dr;
                DataSet ds = new DataSet();
                ds = PMMaster_Class_obj.Select_PMSupplierMaster();
                dr = ds.Tables[0].NewRow();
                dr["PMSupplierName"] = "--All--";
                ds.Tables[0].Rows.InsertAt(dr, 0);

                cmbSupplier.DataSource = ds.Tables[0];
                cmbSupplier.DisplayMember = "PMSupplierName";
                cmbSupplier.ValueMember = "PMSupplierID";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbSupplier_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                cmbPMCode.DataSource = null;
                if (cmbSupplier.SelectedValue != null && cmbSupplier.SelectedValue.ToString() != "" && cmbSupplier.SelectedValue.ToString() != "0")
                {
                    DataRow dr;
                    DataSet DSPMsupplier = new DataSet();
                    pmMaster_Obj.pmsuppliecoid = Convert.ToInt32(cmbSupplier.SelectedValue);

                    DSPMsupplier = pmMaster_Obj.Select_PMSupplier_STP_Select_PMSupplierMaster_By_PMCode();
                    dr = DSPMsupplier.Tables[0].NewRow();
                    dr["PMCode"] = "--All--";
                    dr["PMCodeId"] = "0";
                    DSPMsupplier.Tables[0].Rows.InsertAt(dr, 0);
                    cmbPMCode.DataSource = DSPMsupplier.Tables[0];
                    cmbPMCode.DisplayMember = "PMCode";
                    cmbPMCode.ValueMember = "PMCodeId";
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
                Reports.PM_Component_historyReport rptObj = null;
                DataSet ds = new DataSet();

                if (DtpDateFrom.Checked == true)
                {
                    System.Globalization.CultureInfo enUS = System.Globalization.CultureInfo.CurrentCulture;

                    String fromdate = Convert.ToDateTime(DtpDateFrom.Value.ToShortDateString(), enUS).ToString("MM/dd/yyyy");

                    Report_Class_Obj.fromdate = fromdate;
                }
                else
                {
                    Report_Class_Obj.fromdate = Convert.ToDateTime("1/1/1900 12:00:00 AM").ToShortDateString();
                }

                if (DtpDateTo.Checked == true)
                {

                    System.Globalization.CultureInfo enUS = System.Globalization.CultureInfo.CurrentCulture;

                    String todate = Convert.ToDateTime(DtpDateTo.Value.ToShortDateString(), enUS).ToString("MM/dd/yyyy");

                    Report_Class_Obj.todate = todate;
                    //                    Report_Class_Obj.todate = DtpDateTo.Value.ToShortDateString();
                }
                else
                {
                    Report_Class_Obj.todate = Convert.ToDateTime("6/6/2079 11:59:59 PM").ToShortDateString();
                }
                if (cmbPMCode.SelectedIndex<0)
                {
                    MessageBox.Show("Please Select PM Code");
                    return;
                }
                if (cmbPMCode.SelectedValue.ToString() == "0")
                {
                    //MessageBox.Show("Please select the PM Code", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //return;
                    Report_Class_Obj.pmcode = "--All--";
                }
                else
                {
                    Report_Class_Obj.pmcode = ((DataRowView)cmbPMCode.SelectedItem).Row.ItemArray[0].ToString();
                }

                if (cmbSupplier.SelectedValue==null || cmbSupplier.SelectedValue.ToString()=="" || cmbSupplier.SelectedValue.ToString()=="0")
                {
                    Report_Class_Obj.suppliername = "--All--";
                
                }
                else
                {
                    Report_Class_Obj.suppliername = ((DataRowView)cmbSupplier.SelectedItem).Row.ItemArray[1].ToString();
                }

                ds = Report_Class_Obj.Select_View_PMComponentHistory_Report();
                if (ds.Tables.Count == 0)
                {
                    MessageBox.Show("No record Found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
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

                    param1Fields.Add(FromDate);
                    param1Fields.Add(ToDate);
                    ReportViewer.ParameterFieldInfo = param1Fields;

                    rptObj = new QTMS.Reports.PM_Component_historyReport();
                    rptObj.SetDataSource(ds.Tables[0]);
                    ReportViewer.ReportSource = rptObj;
                    ReportViewer.Show();

                }
                else
                {
                    MessageBox.Show("No record Found", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        


    }
}