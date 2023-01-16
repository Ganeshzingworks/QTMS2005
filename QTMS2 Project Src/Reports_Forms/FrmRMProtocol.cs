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
    public partial class FrmRMProtocol : Form
    {
        public string rptName;
        public DataTable dt = new DataTable();
        public DataTable dtSpl = new DataTable();
        public string Supplier;
        public string PlantLotNo;
        public string SupplierLotNo;
        public string MethodType;
        public string ValidityDate;
        public string ReceiptDate;
        public string QuantityReceived;
        public string QuantitySampled;
        public string ActualNoSegments;
        public string NoOfSegments;
        public string ProtocolNo;
        public string MicroStatus;
        public string InspDate;
        public string AgentName;
        public string RetainerLocation;
        string Alligned = String.Empty;

        public FrmRMProtocol(string RptName, DataTable dt, DataTable dtSpl, string Supplier, string PlantLotNo, string SupplierLotNo, string MethodType, string ValidityDate, string ReceiptDate, string QuantityReceived, string QuantitySampled, string ActualNoSegments, string NoOfSegments, string ProtocolNo, string MicroStatus, string InspDate, string AgentName, string RetainerLocation,string Alligned)
        {
            this.rptName = RptName;
            this.dt = dt;
            this.dtSpl = dtSpl;
            this.Supplier = Supplier;
            this.PlantLotNo = PlantLotNo;
            this.SupplierLotNo = SupplierLotNo;
            this.MethodType = MethodType;
            this.ValidityDate = ValidityDate;
            this.ReceiptDate = ReceiptDate;
            this.QuantityReceived = QuantityReceived;
            this.QuantitySampled = QuantitySampled;
            this.ActualNoSegments = ActualNoSegments;
            this.NoOfSegments = NoOfSegments;
            this.ProtocolNo = ProtocolNo;
            this.MicroStatus = MicroStatus;
            this.InspDate = InspDate;
            this.AgentName = AgentName;
            this.RetainerLocation = RetainerLocation;
            this.Alligned = Alligned;
            InitializeComponent();        
        }

        private void FrmRMProtocol_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                Painter.Paint(this);

                toolStrip1.Items.Add(rptName);
                toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);
      

                Reports.RM_Protocol_Report RMProtocol = new QTMS.Reports.RM_Protocol_Report(); 

                ParameterFields ParaFields = new ParameterFields();

                ParameterField ParaSupplier = new ParameterField();
                ParameterDiscreteValue SupplierDiscrete = new ParameterDiscreteValue();
                ParaSupplier.Name = "Supplier";
                SupplierDiscrete.Value = Supplier;
                ParaSupplier.CurrentValues.Add(SupplierDiscrete);
                ParaFields.Add(ParaSupplier);

                ParameterField ParaPlantLotNo = new ParameterField();
                ParameterDiscreteValue PlantLotNoDiscrete = new ParameterDiscreteValue();
                ParaPlantLotNo.Name = "PlantLotNo";
                PlantLotNoDiscrete.Value = PlantLotNo;
                ParaPlantLotNo.CurrentValues.Add(PlantLotNoDiscrete);
                ParaFields.Add(ParaPlantLotNo);

                ParameterField ParaSupplierLotNo = new ParameterField();
                ParameterDiscreteValue SupplierLotNoDiscrete = new ParameterDiscreteValue();
                ParaSupplierLotNo.Name = "SupplierLotNo";
                SupplierLotNoDiscrete.Value = SupplierLotNo;
                ParaSupplierLotNo.CurrentValues.Add(SupplierLotNoDiscrete);
                ParaFields.Add(ParaSupplierLotNo);

                ParameterField ParaMethodType = new ParameterField();
                ParameterDiscreteValue MethodTypeDiscrete = new ParameterDiscreteValue();
                ParaMethodType.Name = "MethodType";
                MethodTypeDiscrete.Value = MethodType;
                ParaMethodType.CurrentValues.Add(MethodTypeDiscrete);
                ParaFields.Add(ParaMethodType);

                ParameterField ParaValidityDate = new ParameterField();
                ParameterDiscreteValue ValidityDateDescrete = new ParameterDiscreteValue();
                ParaValidityDate.Name = "ValidityDate";
                ValidityDateDescrete.Value = ValidityDate;
                ParaValidityDate.CurrentValues.Add(ValidityDateDescrete);
                ParaFields.Add(ParaValidityDate);

                ParameterField ParaReceiptDate = new ParameterField();
                ParameterDiscreteValue ReceiptDateDiscrete = new ParameterDiscreteValue();
                ParaReceiptDate.Name = "ReceiptDate";
                ReceiptDateDiscrete.Value = ReceiptDate;
                ParaReceiptDate.CurrentValues.Add(ReceiptDateDiscrete);
                ParaFields.Add(ParaReceiptDate);

                ParameterField ParaQuantityReceived = new ParameterField();
                ParameterDiscreteValue QuantityReceivedDiscrete = new ParameterDiscreteValue();
                ParaQuantityReceived.Name = "QuantityReceived";
                QuantityReceivedDiscrete.Value = QuantityReceived;
                ParaQuantityReceived.CurrentValues.Add(QuantityReceivedDiscrete);
                ParaFields.Add(ParaQuantityReceived);

                ParameterField ParaQuantitySampled = new ParameterField();
                ParameterDiscreteValue QuantitySampledDiscrete = new ParameterDiscreteValue();
                ParaQuantitySampled.Name = "QuantitySampled";
                QuantitySampledDiscrete.Value = QuantitySampled;
                ParaQuantitySampled.CurrentValues.Add(QuantitySampledDiscrete);
                ParaFields.Add(ParaQuantitySampled);

                ParameterField ParaActualNoSegments = new ParameterField();
                ParameterDiscreteValue ActualNoSegmentsDiscrete = new ParameterDiscreteValue();
                ParaActualNoSegments.Name = "ActualNoSegments";
                ActualNoSegmentsDiscrete.Value = ActualNoSegments;
                ParaActualNoSegments.CurrentValues.Add(ActualNoSegmentsDiscrete);
                ParaFields.Add(ParaActualNoSegments);

                ParameterField ParaNoOfSegments = new ParameterField();
                ParameterDiscreteValue NoOfSegmentsDiscrete = new ParameterDiscreteValue();
                ParaNoOfSegments.Name = "NoOfSegments";
                NoOfSegmentsDiscrete.Value = NoOfSegments;
                ParaNoOfSegments.CurrentValues.Add(NoOfSegmentsDiscrete);
                ParaFields.Add(ParaNoOfSegments);

                ParameterField ParaProtocolNo = new ParameterField();
                ParameterDiscreteValue ProtocolNoDiscrete = new ParameterDiscreteValue();
                ParaProtocolNo.Name = "ProtocolNo";
                ProtocolNoDiscrete.Value = ProtocolNo;
                ParaProtocolNo.CurrentValues.Add(ProtocolNoDiscrete);
                ParaFields.Add(ParaProtocolNo);

                ParameterField ParaMicroStatus = new ParameterField();
                ParameterDiscreteValue MicroStatusDiscrete = new ParameterDiscreteValue();
                ParaMicroStatus.Name = "MicroStatus";
                MicroStatusDiscrete.Value = MicroStatus;
                ParaMicroStatus.CurrentValues.Add(MicroStatusDiscrete);
                ParaFields.Add(ParaMicroStatus);

                ParameterField ParaInspDate = new ParameterField();
                ParameterDiscreteValue InspDateDiscrete = new ParameterDiscreteValue();
                ParaInspDate.Name = "InspDate";
                InspDateDiscrete.Value = InspDate;
                ParaInspDate.CurrentValues.Add(InspDateDiscrete);
                ParaFields.Add(ParaInspDate);

                ParameterField ParaAgentName = new ParameterField();
                ParameterDiscreteValue AgentNameDiscrete = new ParameterDiscreteValue();
                ParaAgentName.Name = "AgentName";
                AgentNameDiscrete.Value = AgentName;
                ParaAgentName.CurrentValues.Add(AgentNameDiscrete);
                ParaFields.Add(ParaAgentName);

                ParameterField ParaRetainerLocation = new ParameterField();
                ParameterDiscreteValue RetainerLocationDiscrete = new ParameterDiscreteValue();
                ParaRetainerLocation.Name = "RetainerLocation";
                RetainerLocationDiscrete.Value = RetainerLocation;
                ParaRetainerLocation.CurrentValues.Add(RetainerLocationDiscrete);
                ParaFields.Add(ParaRetainerLocation);

                ParameterField ParaAlligned = new ParameterField();
                ParameterDiscreteValue RetainerAlligned = new ParameterDiscreteValue();
                ParaAlligned.Name = "Alligned";
                RetainerAlligned.Value = Alligned;
                ParaAlligned.CurrentValues.Add(RetainerAlligned);
                ParaFields.Add(ParaAlligned);

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

                RMProtocol.SetDataSource(dt);
                RMProtocol.Subreports[0].SetDataSource(dtSpl);
                ReportViewer.ReportSource = RMProtocol;
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