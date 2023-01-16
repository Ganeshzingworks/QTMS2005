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
    public partial class FrmOEEProtocol : Form
    {
        private string _UsedFor;
        public string rptName;
        public DataTable dt = new DataTable();
        public string MfgWo;
        public string FormulaNo;
        public string UsedFor
        {
            get { return _UsedFor; }
            set { _UsedFor = value;}
        }

        public FrmOEEProtocol(string RptName, DataTable dt)//, string MfgWo)//, string MfgWo, string CompletedOn, string Supplier, string BatchSize, string InspDate, string ProtocolNo, string InspectedBy)
        {
            this.rptName = RptName;
            this.dt = dt;
            MfgWo = string.Empty;
            FormulaNo = string.Empty;
            //string [] Str= MfgWo.Split(Convert.ToChar ("-"));
            //if (Str.Length == 2)
            //{
            //    this.FormulaNo = Str[0];
            //    this.MfgWo = Str[1];
            //}
            //else if (Str.Length > 2)
            //{
            //    this.FormulaNo = Str[0] +" - "+ Str[1];
            //    this.MfgWo = Str[2];
            //}
            
            InitializeComponent();
        }        

        private void FrmProtocol_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                Painter.Paint(this);

                toolStrip1.Items.Add(rptName);
                toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);

                switch (this.UsedFor)
                {
                    case "Protocol":
                        Reports.OEEProtocol OEEProtocolObj = new QTMS.Reports.OEEProtocol();

                        ParameterFields ParaFields = new ParameterFields();

                        ParameterField ParaMfgWo = new ParameterField();
                        ParameterDiscreteValue MfgWoDiscrete = new ParameterDiscreteValue();
                        ParaMfgWo.Name = "MfgWo";
                        MfgWoDiscrete.Value = MfgWo;
                        ParaMfgWo.CurrentValues.Add(MfgWoDiscrete);
                        ParaFields.Add(ParaMfgWo);

                        ParameterField ParaCompletedOn = new ParameterField();
                        ParameterDiscreteValue CompletedOnDescrete = new ParameterDiscreteValue();
                        ParaCompletedOn.Name = "FormulaNo";
                        CompletedOnDescrete.Value = FormulaNo;
                        ParaCompletedOn.CurrentValues.Add(CompletedOnDescrete);
                        ParaFields.Add(ParaCompletedOn);

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
                        #endregion

                        ReportViewer.ParameterFieldInfo = ParaFields;

                        OEEProtocolObj.SetDataSource(dt);
                        ReportViewer.ReportSource = OEEProtocolObj;
                        ReportViewer.Show();
                        break;
                    case "Graph":
                        Reports.OEEActivity_Report OEEActivity_ReportObj = new QTMS.Reports.OEEActivity_Report();

                        OEEActivity_ReportObj.SetDataSource(dt);
                        ReportViewer.ReportSource = OEEActivity_ReportObj;
                        ReportViewer.Show();
                        break;
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