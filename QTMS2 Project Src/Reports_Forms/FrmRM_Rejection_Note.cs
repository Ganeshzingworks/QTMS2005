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
using System.IO;
using System.Net.Mail;
using System.Web.UI;
using System.Collections;
using BusinessFacade;

namespace QTMS.Reports_Forms
{
    public partial class FrmRM_Rejection_Note : Form
    {
        public string rptName;
        
        public FrmRM_Rejection_Note(string RptName)
        {
            this.rptName = RptName;     
            InitializeComponent();
        }
        public FrmRM_Rejection_Note()
        {
            InitializeComponent();
        }  

        # region Varibles
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();
        //Reports.RejectionNote_PM RejectionNote_PM = new QTMS.Reports.RejectionNote_PM();
        //Reports.DefectNote_PM DefectNote_PM = new QTMS.Reports.DefectNote_PM();
        //BusinessFacade.Transactions.UserData UserDataObj = new BusinessFacade.Transactions.UserData();
        //GroupMaster_Class GroupMaster_Class_Obj = new GroupMaster_Class();
        //bool flgDefectRejectionNote = false;
        //ArrayList lstReason = new ArrayList();

        //string PMDesc, PMLotNo, PMCode, challanNo, qty, mrr = string.Empty;

        #endregion

        private void FrmPMAnalysis_Report_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);
            toolStrip1.Items.Add("RM Rejection Note");
            toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);
            BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();            
            Bind_Details();
        }

        public void Bind_Details()
        {
            DataRow dr;
            DataSet ds = new DataSet();
            ds = Report_Class_Obj.Select_STP_Get_RM_Transaction_RMCodeDetails();
            dr = ds.Tables[0].NewRow();
            dr["RMCode"] = "--Select--";
            dr["RMCodeId"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            cmbDetails.DataSource = ds.Tables[0];
            cmbDetails.DisplayMember = "RMCode";
            cmbDetails.ValueMember = "RMCodeId";
        }
        QTMS.Reports.RM_Rejection_Note_Report rptRejectionNote = new QTMS.Reports.RM_Rejection_Note_Report();
        public void Bind_Supplier()
        {
            DataRow dr;
            DataSet ds = new DataSet();
            Report_Class_Obj.rmcodeid = Convert.ToInt32(cmbDetails.SelectedValue);
            ds = Report_Class_Obj.Select_STP_Get_RM_Rejection_SupplierDetails();
            dr = ds.Tables[0].NewRow();
            dr["RMSupplierId"] = "0";
            dr["RMSupplierName"] = "--Select--";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            cmbSupplier.DataSource = ds.Tables[0];
            cmbSupplier.DisplayMember = "RMSupplierName";
            cmbSupplier.ValueMember = "RMSupplierId";
        }
        private void BtnShow_Click(object sender, EventArgs e)
        {
            //if (cmbDetails.SelectedIndex>0 && cmbSupplier.SelectedIndex>0)
            {

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


                //Report_Class_Obj.rmsupplierid = Convert.ToInt32(cmbSupplier.SelectedValue);
                //Report_Class_Obj.rmcodeid = Convert.ToInt32(cmbDetails.SelectedValue);
                DataSet ds = Report_Class_Obj.Select_STP_RM_Rejection_Note_Details();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ParameterFields ParaFields = new ParameterFields();

                    #region CompanyName and Address
                    ParameterField CompanyName = new ParameterField();
                    ParameterDiscreteValue CompanyNameDescrete = new ParameterDiscreteValue();
                    CompanyName.Name = "CompanyName";
                    CompanyNameDescrete.Value = GlobalVariables.companyName;
                    CompanyName.CurrentValues.Add(CompanyNameDescrete);
                    ParaFields.Add(CompanyName);

                    ParameterField CompanyAddress = new ParameterField();
                    ParameterDiscreteValue CompanyAddressDescrete = new ParameterDiscreteValue();
                    CompanyAddress.Name = "CompanyAddress";
                    CompanyAddressDescrete.Value = GlobalVariables.companyAddress;
                    CompanyAddress.CurrentValues.Add(CompanyAddressDescrete);
                    ParaFields.Add(CompanyAddress);

                    ParameterField FromDate = new ParameterField();
                    ParameterDiscreteValue FromDateDescrete = new ParameterDiscreteValue();
                    FromDate.Name = "FromDate";
                    if (DtpDateFrom.Checked == true)
                    {
                        FromDateDescrete.Value = DtpDateFrom.Value.ToShortDateString();
                    }
                    else
                    {
                        FromDateDescrete.Value = "";
                    }
                    //FromDateDescrete.Value = GlobalVariables.companyAddress;
                    FromDate.CurrentValues.Add(FromDateDescrete);
                    ParaFields.Add(FromDate);

                    ParameterField ToDate = new ParameterField();
                    ParameterDiscreteValue ToDateDescrete = new ParameterDiscreteValue();
                    ToDate.Name = "ToDate";
                    if (DtpDateTo.Checked == true)
                    {
                        ToDateDescrete.Value = DtpDateTo.Value.ToShortDateString();
                    }
                    else
                    {
                        ToDateDescrete.Value = "";
                    }
                    //FromDateDescrete.Value = GlobalVariables.companyAddress;
                    ToDate.CurrentValues.Add(ToDateDescrete);
                    ParaFields.Add(ToDate);
                    #endregion

                    #region CompanyName and Address
                    ParameterField RMCodeId = new ParameterField();
                    ParameterDiscreteValue RMCodeIdDescrete = new ParameterDiscreteValue();
                    RMCodeId.Name = "@RMCode";
                    RMCodeIdDescrete.Value = Convert.ToInt32(cmbDetails.SelectedValue);                    
                    RMCodeId.CurrentValues.Add(RMCodeIdDescrete);
                    ParaFields.Add(RMCodeId);

                    ParameterField RMSupplierId = new ParameterField();
                    ParameterDiscreteValue RMSupplierDescrete = new ParameterDiscreteValue();
                    RMSupplierId.Name = "@RMSupplierId";
                    RMSupplierDescrete.Value = Convert.ToInt32(cmbSupplier.SelectedValue);                    
                    RMSupplierId.CurrentValues.Add(RMSupplierDescrete);
                    ParaFields.Add(RMSupplierId);

                    ReportViewer.ParameterFieldInfo = ParaFields;
                    #endregion

                    #region From date to date
                    //ParameterFields param1Fields = new ParameterFields();
                    //ParameterField FromDate = new ParameterField();
                    //ParameterField ToDate = new ParameterField();
                    //ParameterDiscreteValue FromDateDescrete = new ParameterDiscreteValue();
                    //ParameterDiscreteValue ToDateDescrete = new ParameterDiscreteValue();
                    //FromDate.Name = "FromDate";
                    //if (DtpDateFrom.Checked == true)
                    //{
                    //    FromDateDescrete.Value = DtpDateFrom.Value.ToShortDateString();
                    //}
                    //else
                    //{
                    //    FromDateDescrete.Value = "";
                    //}
                    //FromDate.CurrentValues.Add(FromDateDescrete);

                    //ToDate.Name = "ToDate";
                    //if (DtpDateTo.Checked == true)
                    //{
                    //    ToDateDescrete.Value = DtpDateTo.Value.ToShortDateString();
                    //}
                    //else
                    //{
                    //    ToDateDescrete.Value = "";
                    //}
                    //ToDate.CurrentValues.Add(ToDateDescrete);

                    //param1Fields.Add(FromDate);
                    //param1Fields.Add(ToDate);
                    #endregion


                    rptRejectionNote.SetDataSource(ds.Tables[0]);
                    //RMTestMethodMaster.Subreports["RMPhyChe"].SetDataSource(dt1);
                    //RMTestMethodMaster.Subreports["RMPres"].SetDataSource(dt2);
                    //RMTestMethodMaster.Subreports["RMFDAPhyChe"].SetDataSource(dt3);
                    //RMTestMethodMaster.Subreports["RMFDAPres"].SetDataSource(dt4);
                    ReportViewer.ReportSource = rptRejectionNote;
                    ReportViewer.Show();
                }
                else
                {
                    MessageBox.Show("Record Not Found....");
                }                
            }
            //else
            //{
            //    MessageBox.Show("Please Select RM Code And Supplier ");
            //}
            
        }

        private void cmbDetails_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Bind_Supplier();
        }
        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
          
       
    }
}