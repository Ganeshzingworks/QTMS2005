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
    public partial class FrmProtocol_FGPacking_SubContract : Form
    {
        public string rptName;
        public string Quantity;
        public string ProtocolNo;
        public string InspectedBy;
        public DataSet ds = new DataSet();
        public DataTable dt_Loreal = new DataTable();
        public DataTable dt_Supplier = new DataTable();

        public FrmProtocol_FGPacking_SubContract(string RptName, DataSet ds, DataTable dt_Loreal, DataTable dt_Supplier, string Quantity, string ProtocolNo, string InspectedBy)
        {
            this.rptName = RptName;
            this.ds = ds;
            this.dt_Loreal = dt_Loreal;
            this.dt_Supplier = dt_Supplier;
            this.Quantity = Quantity;
            this.ProtocolNo = ProtocolNo;
            if (InspectedBy == "--Select--")
                this.InspectedBy = "";
            else
                this.InspectedBy = InspectedBy;
            InitializeComponent();
        }

        private void FrmProtocol_FGPacking_SubContract_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                Painter.Paint(this);

                toolStrip1.Items.Add(rptName);
                toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);



                SubContracttor_Report.Protocol_FGPacking_SubContract FGPackingProtocol = new QTMS.SubContracttor_Report.Protocol_FGPacking_SubContract();

                ParameterFields ParaFields = new ParameterFields();

                ParameterField ParaQuantity = new ParameterField();
                ParameterDiscreteValue QuantityDiscrete = new ParameterDiscreteValue();
                ParaQuantity.Name = "Quantity";
                QuantityDiscrete.Value = Quantity;
                ParaQuantity.CurrentValues.Add(QuantityDiscrete);
                ParaFields.Add(ParaQuantity);

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

                FGPackingProtocol.SetDataSource(ds.Tables[0]);
                FGPackingProtocol.Subreports[0].SetDataSource(dt_Loreal);
                FGPackingProtocol.Subreports[1].SetDataSource(dt_Supplier);
                ReportViewer.ReportSource = FGPackingProtocol;
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