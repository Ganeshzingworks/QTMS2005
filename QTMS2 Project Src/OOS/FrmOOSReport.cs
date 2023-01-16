using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QTMS.Tools;
using CrystalDecisions.Shared;

namespace QTMS.OOS
{
    public partial class FrmOOSReport : Form
    {
        public string rptName;
        public long ID; 
        public FrmOOSReport(string RptName,long id)
        {
            this.rptName = RptName;
            this.ID = id;
            InitializeComponent();
        }

        # region Varibles
        BusinessFacade.Transactions.OOS OOS_Obj = new BusinessFacade.Transactions.OOS();
        # endregion

        private void FrmOOSReport_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            toolStrip1.Items.Add(rptName);
            toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);

            Bind_Details();
            BusinessFacade.Transactions.Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
            if (ID != -1)
            {
                cmbDetails.SelectedValue = ID;
                BtnShow_Click(sender, e);
            }
        }

        public void Bind_Details()
        {
            try
            {
                DataSet ds = new DataSet();
                DataRow dr;
                ds = OOS_Obj.Select_tblOOS();
                dr = ds.Tables[0].NewRow();
                dr["OOSRequestNo"] = "--Select--";
                dr["OOSid"] = "0";
                ds.Tables[0].Rows.InsertAt(dr, 0);
                cmbDetails.DataSource = ds.Tables[0];
                cmbDetails.DisplayMember = "OOSRequestNo";
                cmbDetails.ValueMember = "OOSid";
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

        private void BtnShow_Click(object sender, EventArgs e)
        {
            RptOOSDetails OOSReport = new RptOOSDetails();

            DataTable dt_OOSDetails = new DataTable();
            DataTable dt_LabError = new DataTable();
            DataTable dt_Chromotography = new DataTable();
            DataTable dt_LabErrorIndetified = new DataTable();
            DataTable dt_Resampling = new DataTable();
            DataTable dt_MI = new DataTable();

            if (cmbDetails.SelectedIndex == 0 || cmbDetails.Text == "--Select--")
            {
                MessageBox.Show("Please Select OOS Request No...!", "Message");
                return;
            }
            pictureBox1.Visible = true;
            //Report_Class_Obj.fgtestno = Convert.ToInt64(cmbDetails.SelectedValue);
            OOS_Obj.oosid = Convert.ToInt64(cmbDetails.SelectedValue);

            dt_OOSDetails = OOS_Obj.Select_OOSDetails_Report();
            dt_LabError = OOS_Obj.Select_tblOOS_LabDetails_Report();
            dt_Chromotography = OOS_Obj.Select_tblOOS_Chromatography_Report();
            dt_LabErrorIndetified = OOS_Obj.Select_tblOOS_LabErrorIdentified_Report();
            dt_Resampling = OOS_Obj.Select_tblOOS_Resampling_Report();
            dt_MI = OOS_Obj.Select_tblOOS_MI_Parameters_Report();

            if (dt_OOSDetails.Rows.Count > 0)
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

                OOSReport.SetDataSource(dt_OOSDetails);

                OOSReport.Subreports["RptOOS_LabError"].SetDataSource(dt_LabError);
                //OOSReport.Subreports["Chromatography"].SetDataSource(dt_Chromotography);
                OOSReport.Subreports["tblOOS_LabErrorIdentified"].SetDataSource(dt_LabErrorIndetified);
                OOSReport.Subreports["Resampling"].SetDataSource(dt_Resampling);
                OOSReport.Subreports["MI"].SetDataSource(dt_MI);

                ReportViewer.ReportSource = OOSReport;
                ReportViewer.Show();



            }
            else
            {
                MessageBox.Show("This OOS requried tab information not done.", "Message");
                
            }
            pictureBox1.Visible = false;
        }
    }
}