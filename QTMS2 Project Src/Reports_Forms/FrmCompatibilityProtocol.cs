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
    public partial class FrmCompatibilityProtocol : Form
    {
        public string rptName;
        public DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        DataSet dsTestNo = new DataSet();
        DataSet dsWD = new DataSet();
        DataSet dsTest = new DataSet();
        public long FNo;
        public string ProtocolNo;
        public string InspectedBy;
        BusinessFacade.CompatibilityMaster_Class CompatibilityMaster_Class_Obj = new BusinessFacade.CompatibilityMaster_Class();

        public FrmCompatibilityProtocol(string RptName, long FNO, string protocolNo,string inspectedBy)
        {
            this.rptName = RptName;
            this.FNo = FNO;
            this.ProtocolNo = protocolNo;
            this.InspectedBy = inspectedBy;
            InitializeComponent();
        }
        
        private void FrmCompatibilityProtocol_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                Painter.Paint(this);

                toolStrip1.Items.Add(rptName);
                toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);

                CompatibilityMaster_Class_Obj.formulaNo = this.FNo;
                ds = CompatibilityMaster_Class_Obj.Select_Compatibility_FNo();

                dsWD = CompatibilityMaster_Class_Obj.Select_CompatibilityTestDetailsReport_FNo_WeightDeformation();

                dsTest = CompatibilityMaster_Class_Obj.Select_CompatibilityTestDetailsReport_FNo_OtherTest();


                Reports.Protocol_Compatibility CompatibilityProtocol = new QTMS.Reports.Protocol_Compatibility();

                ParameterFields ParaFields = new ParameterFields();
                
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

                CompatibilityProtocol.SetDataSource(ds.Tables[0]);
                CompatibilityProtocol.Subreports["WeightDeformationTest"].SetDataSource(dsWD.Tables[0]);
                CompatibilityProtocol.Subreports["OtherTest"].SetDataSource(dsTest.Tables[0]);
                ReportViewer.ReportSource = CompatibilityProtocol;
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