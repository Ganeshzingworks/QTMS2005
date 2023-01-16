using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BusinessFacade.Transactions;
using QTMS.Tools;
namespace QTMS.Transactions
{
    public partial class FrmConsumerComplaintHistoryTest : Form
    {
        public class DetailHistory
        {
            public long D_FGPhyCheNo;
            
        }

        public FrmConsumerComplaintHistoryTest(FrmConsumerComplaintHistoryTest.DetailHistory DetailHistory)
        {
            InitializeComponent();
            ConsumerComplaint_Class_obj.fgphycheno = DetailHistory.D_FGPhyCheNo;            
        }

        BusinessFacade.Transactions.ConsumerComplaint_Class ConsumerComplaint_Class_obj = new ConsumerComplaint_Class();        

        private void FrmConsumerComplaintTest_Load(object sender, EventArgs e)
        {
            Painter.Paint(this);

            DataSet dsTests = new DataSet();
            dsTests = ConsumerComplaint_Class_obj.Select_tblFGPhysicochemicalTestMethodDetails_FGPhyCheNo();
            if (dsTests.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsTests.Tables[0].Rows.Count; i++)
                {
                    if (dsTests.Tables[0].Rows[i]["TestType"].ToString() == "Identification")
                    {
                        dgIdTest.Rows.Add();
                        dgIdTest["FGPhyMethodNo", dgIdTest.Rows.Count - 1].Value = dsTests.Tables[0].Rows[i]["FGPhyMethodNo"].ToString();
                        dgIdTest["Test", dgIdTest.Rows.Count - 1].Value = dsTests.Tables[0].Rows[i]["Details"].ToString();
                        dgIdTest["Min", dgIdTest.Rows.Count - 1].Value = dsTests.Tables[0].Rows[i]["NormsMin"].ToString();
                        dgIdTest["Max", dgIdTest.Rows.Count - 1].Value = dsTests.Tables[0].Rows[i]["NormsMax"].ToString();

                        dgIdTest["Reading", dgIdTest.Rows.Count - 1].Value = dsTests.Tables[0].Rows[i]["NormsReading"].ToString();                        
                    }
                    else if (dsTests.Tables[0].Rows[i]["TestType"].ToString() == "Control")
                    {
                        dgConTest.Rows.Add();
                        dgConTest["FGPhyMethodNoCon", dgConTest.Rows.Count - 1].Value = dsTests.Tables[0].Rows[i]["FGPhyMethodNo"].ToString();
                        dgConTest["TestCon", dgConTest.Rows.Count - 1].Value = dsTests.Tables[0].Rows[i]["Details"].ToString();
                        dgConTest["MinCon", dgConTest.Rows.Count - 1].Value = dsTests.Tables[0].Rows[i]["NormsMin"].ToString();
                        dgConTest["MaxCon", dgConTest.Rows.Count - 1].Value = dsTests.Tables[0].Rows[i]["NormsMax"].ToString();

                        dgConTest["ReadingCon", dgConTest.Rows.Count - 1].Value = dsTests.Tables[0].Rows[i]["NormsReading"].ToString();                        
                    }
                }
            }           

        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }




    }
}