using BusinessFacade;
using CrystalDecisions.Shared;
using QTMS.Tools;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace QTMS.Reports_Forms.LineValidation
{
    public partial class FrmLineTransactionReport : Form
    {
        LineMaster_Class LayoutLineMaster_Class_Obj = new LineMaster_Class();
        public FrmLineTransactionReport()
        {
            InitializeComponent();
        }
        #region Varibles
        string rptName;
        BusinessFacade.Transactions.Report_Class Report_Class_Obj = new BusinessFacade.Transactions.Report_Class();

        //Reports.LineTransactionReport LineTransactionReport = new QTMS.Reports.LineTransactionReport(); 
        Reports.LineTransactionReportNew LineTransactionReport = new QTMS.Reports.LineTransactionReportNew();

        #endregion 

        private void Bind_LineDescription()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = LayoutLineMaster_Class_Obj.Select_LineMaster();
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

        private void FrmLineTransactionReport_Load(object sender, EventArgs e)
        {
            Painter.Paint(this);

            dtpFromDate.Value = dtpToDate.Value = DateTime.Now;
            dtpFromDate.Checked = dtpToDate.Checked = false;
            Bind_LineDescription();
            toolStrip1.Items.Add(rptName);
            toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);


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

                if (dtpFromDate.Checked == true)
                {
                    if (dtpToDate.Checked != true)
                    {
                        MessageBox.Show("Please select to date", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                if (dtpToDate.Checked == true)
                {
                    if (dtpFromDate.Checked != true)
                    {
                        MessageBox.Show("Please select from date", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                
                if (dtpFromDate.Value.Date > dtpToDate.Value.Date)
                {
                    MessageBox.Show("Please select valid from date to date", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    BindLineTransactionReport();
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BindLineTransactionReport()
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
                FromDateDescrete.Value = dtpFromDate.Value.Date.ToString("dd-MMM-yyyy");
                FromDate.CurrentValues.Add(FromDateDescrete);
                param1Fields.Add(FromDate);


                ParameterField ToDate = new ParameterField();
                ParameterDiscreteValue ToDateDescrete = new ParameterDiscreteValue();
                ToDate.Name = "ToDate";
                ToDateDescrete.Value = dtpToDate.Value.ToString("dd-MMM-yyyy");
                ToDate.CurrentValues.Add(ToDateDescrete);
                param1Fields.Add(ToDate);

                if (dtpFromDate.Checked == false)
                {
                    FromDateDescrete.Value = "";
                    ToDateDescrete.Value = "";
                }
                #endregion

                ReportViewer.ParameterFieldInfo = param1Fields;
                DataSet ds = new DataSet();
                DataSet ds1 = new DataSet();

                ////By Old
                //ds = Report_Class_Obj.Select_LineTransaction_Report(Convert.ToInt32(cbLineDescription.SelectedValue), dtpFromDate.Value, dtpToDate.Value);


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
                ////New
                ds = Report_Class_Obj.Select_LineTransaction_ReportNew(Convert.ToInt32(cbLineDescription.SelectedValue),Report_Class_Obj.fromDate, Report_Class_Obj.toDate);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    string FilePath, FileName = string.Empty;

                    foreach (DataRow item in ds.Tables[0].Rows)
                    {
                        try
                        {
                            FilePath = Convert.ToString(item["AttachedFilePath"]);
                            if (File.Exists(@"" + FilePath.Replace("\\", "\\\\")))
                                FileName = Path.GetFileName(FilePath);


                            if (File.Exists(@"" + FilePath.Replace("\\", "\\\\")))
                            {
                                if (!Directory.Exists(@"" + Application.StartupPath + "\\Files\\"))
                                    Directory.CreateDirectory(@"" + Application.StartupPath + "\\Files\\");
                                File.Copy(@"" + FilePath.Replace("\\", "\\\\"), @"" + Application.StartupPath + "\\Files\\" + FileName, true);
                                if (File.Exists(@"" + Application.StartupPath + "\\Files\\" + FileName))
                                    item["AttachedFilePath"] = @"" + Application.StartupPath + "\\Files\\" + FileName;
                            }
                            else
                            {

                            }
                        }
                        catch (Exception ex)
                        {
                            //MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        try
                        {
                            FilePath = Convert.ToString(item["ActionPlanFilePath"]);
                            if (File.Exists(@"" + FilePath.Replace("\\", "\\\\")))
                                FileName = Path.GetFileName(FilePath);


                            if (File.Exists(@"" + FilePath.Replace("\\", "\\\\")))
                            {
                                if (!Directory.Exists(@"" + Application.StartupPath + "\\Files\\"))
                                    Directory.CreateDirectory(@"" + Application.StartupPath + "\\Files\\");
                                File.Copy(@"" + FilePath.Replace("\\", "\\\\"), @"" + Application.StartupPath + "\\Files\\" + FileName, true);
                                if (File.Exists(@"" + Application.StartupPath + "\\Files\\" + FileName))
                                    item["ActionPlanFilePath"] = @"" + Application.StartupPath + "\\Files\\" + FileName;
                            }
                            else
                            {

                            }
                        }
                        catch (Exception ex)
                        {
                            //MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }



                    LineTransactionReport.SetDataSource(ds.Tables[0]);
                    ReportViewer.ReportSource = LineTransactionReport;
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

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private static FrmLineTransactionReport frm = null;
        public static FrmLineTransactionReport GetInstance()
        {
            if (frm == null)
            {
                frm = new FrmLineTransactionReport();
            }            
            return frm;
        }

        private void ReportViewer_Load(object sender, EventArgs e)
        {

        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbLineDescription_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
