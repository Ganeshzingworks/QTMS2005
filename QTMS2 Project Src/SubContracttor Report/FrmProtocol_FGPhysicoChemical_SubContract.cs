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
    public partial class FrmProtocol_FGPhysicoChemical_SubContract : Form
    {
        public string rptName;
        public string FormulaNo;
        public string MfgWo;
        public string ProtocolNo;
        public string InspectedBy;
        public DataSet ds = new DataSet();
        public DataTable dtIdentefication_SubContract = new DataTable();
        public DataTable dtControl_SubContract = new DataTable();

        public FrmProtocol_FGPhysicoChemical_SubContract(string RptName, DataSet ds, DataTable dt, DataTable dt1, string FormulaNo, string MfgWo, string ProtocolNo, string InspectedBy)
        {
            this.rptName = RptName;
            this.ds = ds;
            this.dtIdentefication_SubContract = dt;
            this.dtControl_SubContract = dt1;
            this.FormulaNo = FormulaNo;
            this.MfgWo = MfgWo;
            this.ProtocolNo = ProtocolNo;
            this.InspectedBy = InspectedBy;
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


                QTMS.SubContracttor_Report.Protocol_FGPhysicoChemical_SubContract FGPhysicoChemicalProtocol = new QTMS.SubContracttor_Report.Protocol_FGPhysicoChemical_SubContract();
                //Reports.Protocol_FGPhysicoChemical FGPhysicoChemicalProtocol = new QTMS.Reports.Protocol_FGPhysicoChemical();

                ParameterFields ParaFields = new ParameterFields();

                ParameterField ParaFormulaNo = new ParameterField();
                ParameterDiscreteValue FormulaNoDiscrete = new ParameterDiscreteValue();
                ParaFormulaNo.Name = "FormulaNo";
                FormulaNoDiscrete.Value = FormulaNo;
                ParaFormulaNo.CurrentValues.Add(FormulaNoDiscrete);
                ParaFields.Add(ParaFormulaNo);

                ParameterField ParaMfgWo = new ParameterField();
                ParameterDiscreteValue MfgWoDiscrete = new ParameterDiscreteValue();
                ParaMfgWo.Name = "MfgWo";
                MfgWoDiscrete.Value = MfgWo;
                ParaMfgWo.CurrentValues.Add(MfgWoDiscrete);
                ParaFields.Add(ParaMfgWo);

                ParameterField ParaProtocolNo = new ParameterField();
                ParameterDiscreteValue ProtocolNoDiscrete = new ParameterDiscreteValue();
                ParaProtocolNo.Name = "ProtocolNo";
                ProtocolNoDiscrete.Value = ProtocolNo;
                ParaProtocolNo.CurrentValues.Add(ProtocolNoDiscrete);
                ParaFields.Add(ParaProtocolNo);

                ParameterField ParaInspectedBy = new ParameterField();
                ParameterDiscreteValue InspectedByDiscrete = new ParameterDiscreteValue();
                ParaInspectedBy.Name = "InspectedBy";
                InspectedByDiscrete.Value = InspectedBy;
                ParaInspectedBy.CurrentValues.Add(InspectedByDiscrete);
                ParaFields.Add(ParaInspectedBy);

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

                FGPhysicoChemicalProtocol.SetDataSource(ds.Tables[0]);
                FGPhysicoChemicalProtocol.Subreports["FGPhysicoChemicalSubreport"].SetDataSource(dtIdentefication_SubContract);
                FGPhysicoChemicalProtocol.Subreports["FGPhysicoChemicalConSubreport"].SetDataSource(dtControl_SubContract);
                ReportViewer.ReportSource = FGPhysicoChemicalProtocol;
                ReportViewer.Show();
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