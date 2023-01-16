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
using BusinessFacade;


namespace QTMS.Reports_Forms
{
    public partial class FrmAdjustmentReport : Form
    {
        public string rptName;
        public bool flagExistfno = false, flagExistBatchSize = false;
        public FrmAdjustmentReport(string RptName)
        {
            this.rptName = RptName;            
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            toolStrip1.Items.Add(rptName);
            toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);

            flagExistfno = false;
            
            Bind_FormulaNo();
            BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        }
        public FrmAdjustmentReport(string RptName, long fno)
        {
            this.rptName = RptName;
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            toolStrip1.Items.Add(rptName);
            toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);

            flagExistfno = true;
            Bind_FormulaNo();
            BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
            CmbFormulaNo.SelectedValue = fno;
            //CmbFormulaNo_SelectionChangeCommitted(sender,e);
            //BtnShow_Click(sender,e);
        }
        public FrmAdjustmentReport(string RptName, DataSet ds,long fno, int batchsize)
        {
            this.rptName = RptName;
            InitializeComponent();

            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            toolStrip1.Items.Add(rptName);
            toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);

            flagExistfno = true;
            Bind_FormulaNo();
            BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
            CmbFormulaNo.SelectedValue = fno;
           
            ShowReport(ds);
            CmbBatchSize.Text = Convert.ToString(batchsize);
            flagExistBatchSize = false;
            //CmbFormulaNo_SelectionChangeCommitted(sender,e);
            //BtnShow_Click(sender,e);
        }
        private void ShowReport(DataSet ds)
        {
            Reports.AdjustmentHistory_Report Adjustment = new QTMS.Reports.AdjustmentHistory_Report();
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


                Adjustment.SetDataSource(ds.Tables[0]);

                ReportViewer.ParameterFieldInfo = param1Fields;
                ReportViewer.ReportSource = Adjustment;
                ReportViewer.Show();
            }
        }
        # region Varibles
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();
        FormulaNoMaster_Class FormulaNoMaster_Class_Obj = new FormulaNoMaster_Class();

        # endregion

        private void FrmAdjustmentReport_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            toolStrip1.Items.Add(rptName);
            toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);


            Bind_FormulaNo();
            BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();            
        }

        public void Bind_FormulaNo()
        {
            DataSet ds = new DataSet();
            DataRow dr;
            ds = FormulaNoMaster_Class_Obj.SELECT_TblBulkMaster_Active();
            dr = ds.Tables[0].NewRow();
            dr["FormulaNo"] = "--Select--";
            dr["FNo"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                CmbFormulaNo.DataSource = ds.Tables[0];
                CmbFormulaNo.ValueMember = "FNo";
                CmbFormulaNo.DisplayMember = "FormulaNo";
            }
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            try
            {                             
                Reports.AdjustmentHistory_Report Adjustment = new QTMS.Reports.AdjustmentHistory_Report();

                DataSet ds = new DataSet();             

                if (CmbFormulaNo.SelectedIndex == 0 || CmbFormulaNo.Text == "--Select--")
                {
                    MessageBox.Show("Please Select Formula ...!", "Message");
                    return;
                }
                if (CmbBatchSize.Text.Trim() == "")
                {
                    MessageBox.Show("Sorry Record Not Found...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                //Report_Class_Obj.adjid = Convert.ToInt64(CmbBatchSize.SelectedValue);
                Report_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue);
                Report_Class_Obj.batchsize = Convert.ToInt32(CmbBatchSize.Text.Trim());
                switch (rptName)
                {
                    case "Adjustment":
                        ds = Report_Class_Obj.Select_tblAdjustment_AdjID_Report();                       
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

                    switch (rptName)
                    {
                        case "Adjustment":

                            Adjustment.SetDataSource(ds.Tables[0]);

                            ReportViewer.ParameterFieldInfo = param1Fields;
                            ReportViewer.ReportSource = Adjustment;
                            ReportViewer.Show();
                            break; 
                    }
                }
                else
                {
                    MessageBox.Show("Sorry Record Not Found...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ReportViewer.ReportSource = null;
                    return;
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

        private void CmbFormulaNo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            try
            {
                CmbBatchSize.DataSource = null;
                DataSet ds = new DataSet();
                Report_Class_Obj.fno = Convert.ToInt64(CmbFormulaNo.SelectedValue);
                ds = Report_Class_Obj.Select_tblAdjustment_BatchSize();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    CmbBatchSize.DataSource = ds.Tables[0];
                    CmbBatchSize.DisplayMember = "BatchSize";
                    //CmbBatchSize.ValueMember = "";
                    //CmbBatchSize.Text = CmbBatchSize.DisplayMember;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);                
            }
        }

        private void CmbFormulaNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (CmbFormulaNo.Text.Trim() != "--Select--" && CmbFormulaNo.Text.Trim() != "")
            //{
            //    CmbFormulaNo_SelectionChangeCommitted(sender, e);
            //}
        }

        private void CmbFormulaNo_SelectedValueChanged(object sender, EventArgs e)
        {

            if (CmbFormulaNo.Text.Trim() != "System.Data.DataRowView" && CmbFormulaNo.Text.Trim() != "" && flagExistfno == true )
            {
                CmbFormulaNo_SelectionChangeCommitted(sender, e);
                //if (flagExistBatchSize == false && CmbBatchSize.Text.Trim() != "System.Data.DataRowView")
                //{
                //    BtnShow_Click(sender, e);
                //    flagExistfno = false;
                //}
            }
        } 
       
    }
}