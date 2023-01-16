using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using QTMS.Tools;

namespace QTMS.Forms
{
    public partial class FrmShowTitrationResults : Form
    {
        BusinessFacade.Transactions.AdjustmentTransaction AdjustmentTransaction_Class_obj = new BusinessFacade.Transactions.AdjustmentTransaction();
        public FrmShowTitrationResults()
        {
            InitializeComponent();
        }

        private void FrmShowTitrationResults_Load(object sender, EventArgs e)
        {
            //this.WindowState = FormWindowState.Normal;
            //Painter.Paint(this);
            FillResult();
            getResults();
        }

        public void FillResult()
        {
            try
            {
                DataTable dtResults = AdjustmentTransaction_Class_obj.Select_LabxResults();
                DataTable dt = new DataTable();
                string strCon = ConfigurationManager.ConnectionStrings["ConnectionString1"].ConnectionString;
                SqlConnection con = new SqlConnection(strCon);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select  dbo.ReTSample.Note as WorkOrder,dbo.ReTSeries.MethodID as MethodName,dbo.ReTSample.SampleId2 as Identification,CAST (CAST (substring(dbo.ReTFResult.Value,5,len(dbo.ReTFResult.Value)) AS float(50)) AS decimal(24, 3)) as Result,unit as Unit, CONVERT(varchar,dbo.ReTFResult.LastChange,120) as LastChangeDate FROM dbo.ReTFResult INNER JOIN dbo.ReTSample ON dbo.ReTFResult.FID_Sample = dbo.ReTSample.PID_Sample INNER JOIN dbo.ReTSeries ON dbo.ReTFResult.FID_Series = dbo.ReTSeries.PID_Series AND dbo.ReTSample.FID_Series = dbo.ReTSeries.PID_Series AND dbo.ReTSample.Note not in('##') AND dbo.ReTSample.Note not in('')"; // where dbo.ReTSample.Note LIKE 'WO%'//AND dbo.ReTSample.Note not in('##') AND dbo.ReTSample.Note not in('')
                cmd.CommandType = CommandType.Text;
                cmd.Connection = con;
                cmd.CommandTimeout = 0;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                DataTable dtFlag = AdjustmentTransaction_Class_obj.STP_Select_LabxResults_Flag();
                bool IsInserted = false;
                if (dtFlag.Rows.Count == 0)
                {
                    //If dtFlag has no rows then all records will be inserted for first time to QTMS database from LABX.
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        AdjustmentTransaction_Class_obj.workorder = dt.Rows[i]["WorkOrder"].ToString();
                        AdjustmentTransaction_Class_obj.methodna = dt.Rows[i]["MethodName"].ToString();
                        AdjustmentTransaction_Class_obj.ident = dt.Rows[i]["Identification"].ToString();
                        AdjustmentTransaction_Class_obj.result = dt.Rows[i]["Result"].ToString();
                        AdjustmentTransaction_Class_obj.unit = dt.Rows[i]["Unit"].ToString();
                        AdjustmentTransaction_Class_obj.lastchange = dt.Rows[i]["LastChangeDate"].ToString();
                        AdjustmentTransaction_Class_obj.lflag = 1;
                        IsInserted = AdjustmentTransaction_Class_obj.Insert_tblLabXResults_First();
                    }
                }
                else if (dtFlag.Rows.Count > 0)
                {
                    //If dtFlag has rows then all new records will be inserted to QTMS database from LABX.
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        AdjustmentTransaction_Class_obj.workorder = dt.Rows[i]["WorkOrder"].ToString();//.Rows[0]["UserPass"].ToString();
                        AdjustmentTransaction_Class_obj.methodna = dt.Rows[i]["MethodName"].ToString();
                        AdjustmentTransaction_Class_obj.ident = dt.Rows[i]["Identification"].ToString();
                        AdjustmentTransaction_Class_obj.result = dt.Rows[i]["Result"].ToString();
                        AdjustmentTransaction_Class_obj.unit = dt.Rows[i]["Unit"].ToString();
                        AdjustmentTransaction_Class_obj.lastchange = dt.Rows[i]["LastChangeDate"].ToString();
                        IsInserted = AdjustmentTransaction_Class_obj.Insert_tblLabXResults();
                    }
                }
            }
            catch (Exception ex)
            {
               // throw ex;
            }
        }

        public void getResults()
        {
            DataTable dtResults = AdjustmentTransaction_Class_obj.Select_LabxResults();
            dgReadings.DataSource = dtResults;
        }

        private void toolStripButtonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //dta = AdjustmentTransaction_Class_obj.Select_tblAdjustment_Details();
        //DataTable dtResult = FillResult();

        //foreach(DataRow dr in dt.Rows)
        //{
        //    if(!string.IsNullOrEmpty(Convert.ToString(dr["WorkOrder"])))
        //    {
        //        DataView dv = new DataView(dta);
        //        dv.Sort = "mfgwo";
        //        int index = dv.Find((dr["WorkOrder"]));
        //        if(index>0)
        //        {                        
        //            dgReadings.Rows.Add();
        //            dgReadings["mfgwo",dgReadings.Rows.Count-1].Value = Convert.ToString(dr["WorkOrder"]);
        //        }
        //    }
        //}
        //if (icount > 0)
        //{
        //    dgReadings.DataSource = dt;
        //}
        //else
        //{
        //    MessageBox.Show("Sorry There is No Records");
        //}
    }
}