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
using BusinessFacade.Transactions;


namespace QTMS.Reports_Forms
{
    public partial class FrmAOCProtocol : Form
    {
        public string rptName;
        public DataTable dt = new DataTable();
        DataSet ds = new DataSet();
        DataSet dsTestNo = new DataSet();
        DataSet dsWD = new DataSet();
        DataSet dsTest = new DataSet();
        public long FNo;
        public long FGNo;
        public long FGLotNo;
        BusinessFacade.CompatibilityMaster_Class CompatibilityMaster_Class_Obj = new BusinessFacade.CompatibilityMaster_Class();

        public FrmAOCProtocol(string RptName,long FGNO, long FNO, long FGLotNo)
        {
            this.rptName = RptName;
            this.FGLotNo = FGLotNo;
            this.FGNo = FGNO;
            this.FNo = FNO;
           
            InitializeComponent();
        }
        
        private void FrmAOCProtocol_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Maximized;
                Painter.Paint(this);

                toolStrip1.Items.Add(rptName);
                toolStrip1.Font = new Font("Tahoma", 9, FontStyle.Regular);

                AOCSheet_Class AOCSheet_Class_Obj = new AOCSheet_Class();

                AOCSheet_Class_Obj.fgno = this.FGNo;
                AOCSheet_Class_Obj.fno = this.FNo;
                AOCSheet_Class_Obj.fmid = this.FGLotNo;
                              
                DataSet ds = new DataSet();
                ds = AOCSheet_Class_Obj.Select_tblAOCSheet_FGNo_FNo_FMID();


                Reports.Protocol_AOCSheet AOCSheetProtocol = new QTMS.Reports.Protocol_AOCSheet();
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //ParameterFields ParaFields = new ParameterFields();


                    //#region CompanyName and Address
                    //ParameterField CompanyName = new ParameterField();
                    //ParameterDiscreteValue CompanyNameDescrete = new ParameterDiscreteValue();
                    //CompanyName.Name = "CompanyName";
                    //CompanyNameDescrete.Value = GlobalVariables.companyName;
                    //CompanyName.CurrentValues.Add(CompanyNameDescrete);
                    //ParaFields.Add(CompanyName);

                    //ParameterField CompanyAddress = new ParameterField();
                    //ParameterDiscreteValue CompanyAddressDescrete = new ParameterDiscreteValue();
                    //CompanyAddress.Name = "CompanyAddress";
                    //CompanyAddressDescrete.Value = GlobalVariables.companyAddress;
                    //CompanyAddress.CurrentValues.Add(CompanyAddressDescrete);
                    //ParaFields.Add(CompanyAddress);
                    //#endregion

                    //ReportViewer.ParameterFieldInfo = ParaFields;

                    AOCSheetProtocol.SetDataSource(ds.Tables[0]);
                    ReportViewer.ReportSource = AOCSheetProtocol;
                    ReportViewer.Show();
                                      
                   
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