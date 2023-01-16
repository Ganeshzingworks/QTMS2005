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
    public partial class FrmProtocol_FGPacking : Form
    {
        public string rptName;
        public string Quantity;
        public string ProtocolNo;
        public string InspectedBy;
        public DataSet ds = new DataSet();
        public DataTable dt = new DataTable();

        public FrmProtocol_FGPacking(string RptName, DataSet ds, DataTable dt, string Quantity, string ProtocolNo, string InspectedBy)
        {
            this.rptName = RptName;
            this.ds = ds;
            this.dt = dt;
            this.Quantity = Quantity;
            this.ProtocolNo = ProtocolNo;
            if (InspectedBy == "--Select--")
                this.InspectedBy = "";
            else
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
      


                Reports.Protocol_FGPacking FGPackingProtocol = new QTMS.Reports.Protocol_FGPacking();

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
                FGPackingProtocol.Subreports[0].SetDataSource(dt);
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