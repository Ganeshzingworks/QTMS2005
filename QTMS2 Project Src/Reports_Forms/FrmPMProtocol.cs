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
    public partial class FrmPMProtocol : Form
    {
        public string rptName;
        public DataSet ds; 
        public string Details;
        public string Quantity;
        public string LotNo;
        public string InspDate;
        public string ProtocolNo;        
        public string mrrNo;
        public string specNo;
        public string controlType;
        public string challanNo;

        public DataTable dt = new DataTable();

        public FrmPMProtocol(String RptName,DataSet ds,string Details,string LotNo,DataTable dt,string Quantity,string InspDate,string ProtocolNo,string mrrno, string specno, string controltype,string challanno)
        {
            this.ds = ds;
            this.Details = Details;
            this.LotNo = LotNo;
            this.dt = dt;
            this.Quantity = Quantity;
            this.InspDate = InspDate;
            this.ProtocolNo = ProtocolNo;      
            this.mrrNo = mrrno;
            this.specNo = specno;
            this.controlType = controltype;
            this.challanNo = challanno;
            InitializeComponent();
        }

        private void FrmPMProtocol_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                Painter.Paint(this);

                toolStrip1.Items.Add(rptName);
                toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);
      


                Reports.PMProtocol_Report PMProtocol = new QTMS.Reports.PMProtocol_Report();

                ParameterFields ParaFields = new ParameterFields();                

                ParameterField ParaDetails = new ParameterField();
                ParameterDiscreteValue DetailsDiscrete = new ParameterDiscreteValue();
                ParaDetails.Name = "Details";
                DetailsDiscrete.Value = Details;
                ParaDetails.CurrentValues.Add(DetailsDiscrete);
                ParaFields.Add(ParaDetails);
                
                ParameterField ParaLotNo = new ParameterField();
                ParameterDiscreteValue LotNoDiscrete = new ParameterDiscreteValue();
                ParaLotNo.Name = "LotNo";
                LotNoDiscrete.Value = LotNo;
                ParaLotNo.CurrentValues.Add(LotNoDiscrete);
                ParaFields.Add(ParaLotNo);

                ParameterField ParaQuantity = new ParameterField();
                ParameterDiscreteValue QuantityDiscrete = new ParameterDiscreteValue();
                ParaQuantity.Name = "Quantity";
                QuantityDiscrete.Value = Quantity;
                ParaQuantity.CurrentValues.Add(QuantityDiscrete);
                ParaFields.Add(ParaQuantity);
                
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

               
                ParameterField ParaMRRNO = new ParameterField();
                ParameterDiscreteValue MRRNODiscrete = new ParameterDiscreteValue();
                ParaMRRNO.Name = "MRRNo";
                MRRNODiscrete.Value = mrrNo;
                ParaMRRNO.CurrentValues.Add(MRRNODiscrete);
                ParaFields.Add(ParaMRRNO);

                ParameterField ParaSpecNo = new ParameterField();
                ParameterDiscreteValue SpecNoDiscrete = new ParameterDiscreteValue();
                ParaSpecNo.Name = "SpecificationNo";
                SpecNoDiscrete.Value = specNo;
                ParaSpecNo.CurrentValues.Add(SpecNoDiscrete);
                ParaFields.Add(ParaSpecNo);

                ParameterField ParaControlType = new ParameterField();
                ParameterDiscreteValue ControlTypeDiscrete = new ParameterDiscreteValue();
                ParaControlType.Name = "ControlType";
                ControlTypeDiscrete.Value = controlType;
                ParaControlType.CurrentValues.Add(ControlTypeDiscrete);
                ParaFields.Add(ParaControlType);

                ParameterField ParaChallanNo = new ParameterField();
                ParameterDiscreteValue ChallanNoDiscrete = new ParameterDiscreteValue();
                ParaChallanNo.Name = "ChallanNo";
                ChallanNoDiscrete.Value = challanNo;
                ParaChallanNo.CurrentValues.Add(ChallanNoDiscrete);
                ParaFields.Add(ParaChallanNo);

                ReportViewer.ParameterFieldInfo = ParaFields;

                PMProtocol.SetDataSource(ds.Tables[0]);
                PMProtocol.Subreports["PMProtocol_SubReport"].SetDataSource(dt);
                ReportViewer.ReportSource = PMProtocol;
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