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
    public partial class FrmFGBulkRejectionDetailReport : Form
    {
        BusinessFacade.Transactions.BulktestDetailstransaction_Class BulktestDetailstransaction_Class_Obj = new BusinessFacade.Transactions.BulktestDetailstransaction_Class();
        public string rptName;
        public FrmFGBulkRejectionDetailReport(string RptName)
        {
            this.rptName = RptName;
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            Painter.Paint(this);

            toolStrip1.Items.Add(rptName);
            toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);
        }

        private void FrmFGBulkRejectionDetailReport_Load(object sender, EventArgs e)
        {
            Bind_Details();
        }

        public void Bind_Details()
        {
            DataSet ds = new DataSet();
            DataRow dr;
            ds = BulktestDetailstransaction_Class_Obj.Select_ModificationBulkTestDetails();
            dr = ds.Tables[0].NewRow();
            dr["Details"] = "--Select--";
            dr["BulkNo"] = "0";
            ds.Tables[0].Rows.InsertAt(dr, 0);
            if (ds.Tables[0].Rows.Count > 0)
            {
                cmbDetails.DataSource = ds.Tables[0];
                cmbDetails.ValueMember = "BulkNo";
                cmbDetails.DisplayMember = "Details";
            }
        }

        private void BtnShow_Click(object sender, EventArgs e)
        {
            try
            {
                Reports.BulkRejectionDetailReport BulkRejection = new Reports.BulkRejectionDetailReport();

                DataSet ds = new DataSet();

                if (cmbDetails.SelectedIndex == 0 || cmbDetails.Text == "--Select--")
                {
                    MessageBox.Show("Please Select Formula ...!", "Message");
                    return;
                }

                pictureBox1.Visible = true;
                BulktestDetailstransaction_Class_Obj.bulkno = Convert.ToInt32(cmbDetails.SelectedValue);
                switch (rptName)
                {
                    case "BulkRejectionDetails":
                        ds = BulktestDetailstransaction_Class_Obj.Select_View_BulkRejection_Report();
                        break;
                }

                if (ds.Tables[0].Rows.Count > 0)
                {
                    string strQual = "";
                    string strManf = "";
                    if (chkQuality.Checked == true)
                    {
                        strQual = "T";
                    }
                    else { strQual = "F"; }

                    if (chkManfctr.Checked == true)
                    {
                        strManf = "T";
                    }
                    else { strManf = "F"; }

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

                    ParameterField Qual = new ParameterField();
                    ParameterDiscreteValue QualDescrete = new ParameterDiscreteValue();
                    Qual.Name = "Qual";
                    QualDescrete.Value = strQual;
                    Qual.CurrentValues.Add(QualDescrete);
                    param1Fields.Add(Qual);

                    ParameterField Manf = new ParameterField();
                    ParameterDiscreteValue strManfDescrete = new ParameterDiscreteValue();
                    Manf.Name = "Manf";
                    strManfDescrete.Value = strManf;
                    Manf.CurrentValues.Add(strManfDescrete);
                    param1Fields.Add(Manf);
                    #endregion

                    switch (rptName)
                    {
                        case "BulkRejectionDetails":

                            BulkRejection.SetDataSource(ds.Tables[0]);

                            ReportViewer.ParameterFieldInfo = param1Fields;
                            ReportViewer.ReportSource = BulkRejection;
                            ReportViewer.Show();
                            break;
                    }
                }
                else
                {
                    pictureBox1.Visible = false;
                    MessageBox.Show("Sorry Record Not Found...!", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    ReportViewer.ReportSource = null;
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