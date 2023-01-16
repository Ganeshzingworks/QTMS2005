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
    public partial class FrmPreservativeTestProtocol : Form
    {
    
        public DataTable dt = new DataTable();      
        public string InspDate;
        public string ProtocolNo;
        public string InspectedBy;
        public string VerifiedBy;
      
        public FrmPreservativeTestProtocol(string InspDate,DataTable dt,string ProtocolNo,string InspectedBy,string VerifiedBy)
        {   
            this.dt = dt;
            this.InspDate = InspDate;
            this.ProtocolNo = ProtocolNo;
            this.InspectedBy = InspectedBy;
            this.VerifiedBy = VerifiedBy;

            InitializeComponent();
        }

        private void FrmPreservativeTestProtocol_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                Painter.Paint(this);
                    

                Reports.PreservativeTest_Protocol PresTestProtocol = new QTMS.Reports.PreservativeTest_Protocol();
                ParameterFields ParaFields = new ParameterFields();

                ParameterField ParaProtocolNo = new ParameterField();
                ParameterDiscreteValue ProtocolNoDiscrete = new ParameterDiscreteValue();
                ParaProtocolNo.Name = "ProtocolNo";
                ProtocolNoDiscrete.Value = ProtocolNo;
                ParaProtocolNo.CurrentValues.Add(ProtocolNoDiscrete);
                ParaFields.Add(ParaProtocolNo);

                ParameterField ParaInspDate = new ParameterField();
                ParameterDiscreteValue InspDateDiscrete = new ParameterDiscreteValue();
                ParaInspDate.Name = "InspDate";
                InspDateDiscrete.Value = InspDate;
                ParaInspDate.CurrentValues.Add(InspDateDiscrete);
                ParaFields.Add(ParaInspDate);

                ParameterField ParaVerifiedBy = new ParameterField();
                ParameterDiscreteValue VerifiedByDiscrete = new ParameterDiscreteValue();
                ParaVerifiedBy.Name = "VerifiedBy";
                VerifiedByDiscrete.Value = VerifiedBy;
                ParaVerifiedBy.CurrentValues.Add(VerifiedByDiscrete);
                ParaFields.Add(ParaVerifiedBy);


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

                PresTestProtocol.SetDataSource(dt);
                ReportViewer.ReportSource = PresTestProtocol;
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