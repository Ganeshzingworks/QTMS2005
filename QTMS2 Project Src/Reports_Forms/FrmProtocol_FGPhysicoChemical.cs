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
    public partial class FrmProtocol_FGPhysicoChemical : Form
    {
        public string rptName;
        public string FormulaNo;
        public string MfgWo;
        public string ProtocolNo;
        public string InspectedBy;
        public DataSet ds = new DataSet();
        public DataTable dt = new DataTable();
        public DataTable dt1 = new DataTable();

        public string PT1;
        public string PT2;
        public string PT3;
        public string PT4;
        public string PT5;
        public string PT6;


        public FrmProtocol_FGPhysicoChemical(string RptName, DataSet ds, DataTable dt, DataTable dt1, string FormulaNo, string MfgWo, string ProtocolNo, string InspectedBy, string PT1,string PT2,string PT3,string PT4,string PT5,string PT6)
        {
            this.rptName = RptName;
            this.ds = ds;
            this.dt = dt;
            this.dt1 = dt1;
            this.FormulaNo = FormulaNo;
            this.MfgWo = MfgWo;
            this.ProtocolNo = ProtocolNo;
            this.InspectedBy = InspectedBy;

            this.PT1 = PT1== null ? "" : PT1;
            this.PT2 = PT2 == null ? "" : PT2;
            this.PT3 = PT3 == null ? "" : PT3;
            this.PT4 = PT4 == null ? "" : PT4;
            this.PT5 = PT5 == null ? "" : PT5;
            this.PT6 = PT6 == null ? "" : PT6;
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
      


                Reports.Protocol_FGPhysicoChemical FGPhysicoChemicalProtocol = new QTMS.Reports.Protocol_FGPhysicoChemical();

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

                #region Add Tanks

                ParameterField ParaPT1 = new ParameterField();
                ParameterDiscreteValue PT1Discrete = new ParameterDiscreteValue();
                ParaPT1.Name = "PT1";
                PT1Discrete.Value = PT1;
                ParaPT1.CurrentValues.Add(PT1Discrete);
                ParaFields.Add(ParaPT1);

                ParameterField ParaPT2 = new ParameterField();
                ParameterDiscreteValue PT2Discrete = new ParameterDiscreteValue();
                ParaPT2.Name = "PT2";
                PT2Discrete.Value = PT2;
                ParaPT2.CurrentValues.Add(PT2Discrete);
                ParaFields.Add(ParaPT2);

                ParameterField ParaPT3 = new ParameterField();
                ParameterDiscreteValue PT3Discrete = new ParameterDiscreteValue();
                ParaPT3.Name = "PT3";
                PT3Discrete.Value = PT3;
                ParaPT3.CurrentValues.Add(PT3Discrete);
                ParaFields.Add(ParaPT3);

                ParameterField ParaPT4 = new ParameterField();
                ParameterDiscreteValue PT4Discrete = new ParameterDiscreteValue();
                ParaPT4.Name = "PT4";
                PT4Discrete.Value = PT4;
                ParaPT4.CurrentValues.Add(PT4Discrete);
                ParaFields.Add(ParaPT4);

                ParameterField ParaPT5 = new ParameterField();
                ParameterDiscreteValue PT5Discrete = new ParameterDiscreteValue();
                ParaPT5.Name = "PT5";
                PT5Discrete.Value = PT5;
                ParaPT5.CurrentValues.Add(PT5Discrete);
                ParaFields.Add(ParaPT5);

                ParameterField ParaPT6 = new ParameterField();
                ParameterDiscreteValue PT6Discrete = new ParameterDiscreteValue();
                ParaPT6.Name = "PT6";
                PT6Discrete.Value = PT6;
                ParaPT6.CurrentValues.Add(PT6Discrete);
                ParaFields.Add(ParaPT6);

                #endregion

                ReportViewer.ParameterFieldInfo = ParaFields;

                FGPhysicoChemicalProtocol.SetDataSource(ds.Tables[0]);

                

                FGPhysicoChemicalProtocol.Subreports["FGPhysicoChemicalSubreport"].SetDataSource(dt);
                FGPhysicoChemicalProtocol.Subreports["FGPhysicoChemicalConSubreport"].SetDataSource(dt1);
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