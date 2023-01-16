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
    public partial class FrmProtocol : Form
    {
        public string rptName;
        public DataTable dt = new DataTable();
        public string MfgWo;
        public string CompletedOn;
        public string Supplier;
        public string BatchSize;
        public string InspDate;
        public string ProtocolNo;
        public string InspectedBy;
        public string VerifiedBy;
        public string DWP;
        public FrmProtocol(string RptName, DataTable dt, string MfgWo, string CompletedOn, string Supplier, string BatchSize, string InspDate, string ProtocolNo, string InspectedBy, string VerifiedBy, String dwp)
        {
            this.rptName = RptName;
            this.dt = dt;
            this.MfgWo = MfgWo;
            this.CompletedOn = CompletedOn;
            this.Supplier = Supplier;
            this.BatchSize = BatchSize;
            this.InspDate = InspDate;
            this.ProtocolNo = ProtocolNo;
            this.InspectedBy = InspectedBy;
            this.VerifiedBy = VerifiedBy;
            this.DWP = dwp;
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
      


                Reports.Protocol_Bulk BulkProtocol = new QTMS.Reports.Protocol_Bulk();

                ParameterFields ParaFields = new ParameterFields();

                ParameterField ParaMfgWo = new ParameterField();
                ParameterDiscreteValue MfgWoDiscrete = new ParameterDiscreteValue();
                ParaMfgWo.Name = "MfgWo";
                MfgWoDiscrete.Value = MfgWo;
                ParaMfgWo.CurrentValues.Add(MfgWoDiscrete);
                ParaFields.Add(ParaMfgWo);

                ParameterField ParaCompletedOn = new ParameterField();
                ParameterDiscreteValue CompletedOnDescrete = new ParameterDiscreteValue();
                ParaCompletedOn.Name = "CompletedOn";
                CompletedOnDescrete.Value = CompletedOn;
                ParaCompletedOn.CurrentValues.Add(CompletedOnDescrete);
                ParaFields.Add(ParaCompletedOn);
                                
                ParameterField ParaSupplier = new ParameterField();
                ParameterDiscreteValue SupplierDiscrete = new ParameterDiscreteValue();
                ParaSupplier.Name = "Supplier";
                SupplierDiscrete.Value = Supplier;
                ParaSupplier.CurrentValues.Add(SupplierDiscrete);
                ParaFields.Add(ParaSupplier);

                ParameterField ParaBatchSize = new ParameterField();
                ParameterDiscreteValue BatchSizeDiscrete = new ParameterDiscreteValue();
                ParaBatchSize.Name = "BatchSize";
                BatchSizeDiscrete.Value = BatchSize;
                ParaBatchSize.CurrentValues.Add(BatchSizeDiscrete);
                ParaFields.Add(ParaBatchSize);

                ParameterField ParaInspDate = new ParameterField();
                ParameterDiscreteValue InspDateDiscrete = new ParameterDiscreteValue();
                ParaInspDate.Name = "InspDate";
                InspDateDiscrete.Value = InspDate;
                ParaInspDate.CurrentValues.Add(InspDateDiscrete);
                ParaFields.Add(ParaInspDate);

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

                ParameterField ParaVerifiedBy = new ParameterField();
                ParameterDiscreteValue VerifiedByDiscrete = new ParameterDiscreteValue();
                ParaVerifiedBy.Name = "VerifiedBy";
                VerifiedByDiscrete.Value = VerifiedBy;
                ParaVerifiedBy.CurrentValues.Add(VerifiedByDiscrete);
                ParaFields.Add(ParaVerifiedBy);

                ParameterField ParaDWP = new ParameterField();
                ParameterDiscreteValue DWPDiscrete = new ParameterDiscreteValue();
                ParaDWP.Name = "DWP";
                DWPDiscrete.Value = DWP;
                ParaDWP.CurrentValues.Add(DWPDiscrete);
                ParaFields.Add(ParaDWP);


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

                BulkProtocol.SetDataSource(dt);
                ReportViewer.ReportSource = BulkProtocol;
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