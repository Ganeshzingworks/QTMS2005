using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using DataFacade;
namespace BusinessFacade.Transactions
{
    public class OEEDetailProcessingReport
    {
        #region Properties
        private string StartDate;

        public string startdate
        {
            get { return StartDate; }
            set { StartDate = value; }
        }
        private string EndDate;

        public string enddate
        {
            get { return EndDate; }
            set { EndDate = value; }
        }
        #endregion

        #region Functions
        public DataTable Select_Report_OEEMFGActivityDetails_Analysis()
        {
            try
            {
                
                string str = ConfigurationSettings.AppSettings["connectionstring"];
                SqlConnection con = new SqlConnection(str);

                SqlCommand cmd = new SqlCommand("STP_SELECT_OEEProcess_Report", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.SmallDateTime, 4, "StartDate"));
                cmd.Parameters.Add(new SqlParameter("@EndDate", SqlDbType.SmallDateTime, 4, "EndDate"));
                cmd.Parameters[0].Value = startdate;
                cmd.Parameters[1].Value = enddate;
                DataSet ds = new DataSet();
                SqlDataAdapter sqlAdpt = new SqlDataAdapter(cmd);
                sqlAdpt.Fill(ds);
                return ds.Tables[0];

                //SqlParameter[] myparam = new SqlParameter[2];
                //myparam[0] = ModHelper.CreateParameter("@StartDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, startdate);
                //myparam[1] = ModHelper.CreateParameter("@EndDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, enddate);
                //return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_OEEProcess_Report", myparam).Tables[0];//STP_Select_DetailedProcessing_Analysis_Report  old stored procedure
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable OEEDetailProcessingTable()
        {
            try
            {
                Transactions.OEEAct_CatRelation OEEAct_CatRelationObj = new Transactions.OEEAct_CatRelation();

                DataTable Dt = new DataTable();
                Dt = Select_Report_OEEMFGActivityDetails_Analysis();
                if (Dt.Rows.Count > 0)
                {                    
                    string FirstCol = "", SecondCol = "";

                    for (int i = 0; i < 4; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                FirstCol = "SMT";// Standard Manufacturing time
                                break;
                            case 1:
                                FirstCol = "Batch";// No of batches
                                break;
                            case 3:
                                FirstCol = "TCOT";// Total Change Over Time
                                break;
                            case 4:
                                FirstCol = "PT";// Processing time
                                break;
                        }
                        for (int j = 0; j < 6; j++)
                        {
                            switch (j)
                            {
                                case 0:
                                    SecondCol = "251 - 500 kg";
                                    break;
                                case 1:
                                    SecondCol = "501 kg - 1500 kg";
                                    break;
                                case 2:
                                    SecondCol = "1501 kg - 2500 kg";
                                    break;
                                case 3:
                                    SecondCol = "2501 kg - 5000 kg";
                                    break;
                                case 4:
                                    SecondCol = "5001 kg - 10000 kg";
                                    break;
                                case 5:
                                    SecondCol = "10001 kg - 20000 kg";
                                    break;
                               
                            }
                            Dt.Columns.Add(FirstCol+SecondCol);
                        }
                        FirstCol = "";
                        SecondCol = "";
                    }

                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        int batchSize = Convert.ToInt32(Dt.Rows[i]["BatchSize"].ToString());
                        if (batchSize >250 && batchSize <= 500)
                            Dt.Rows[i]["SMT251 - 500 kg"] = (Dt.Rows[i]["TargetMTime"]);
                        else if (batchSize >500 && batchSize <= 1500)
                            Dt.Rows[i]["SMT501 kg - 1500 kg"] = (Dt.Rows[i]["TargetMTime"]);
                        else if (batchSize > 1501 && batchSize <= 2500)
                            Dt.Rows[i]["SMT1501 kg - 2500 kg"] = (Dt.Rows[i]["TargetMTime"]);
                        else if (batchSize > 2501 && batchSize <= 5000)
                            Dt.Rows[i]["SMT2501 kg - 5000 kg"] = (Dt.Rows[i]["TargetMTime"]);
                        else if (batchSize > 5001 && batchSize <= 10000)
                            Dt.Rows[i]["SMT5001 kg - 10000 kg"] = (Dt.Rows[i]["TargetMTime"]);
                        else if (batchSize > 10001 && batchSize <= 20000)
                            Dt.Rows[i]["SMT10001 kg - 20000 kg"] = (Dt.Rows[i]["TargetMTime"]);                                              
                    }
                    
                    DataTable DtActivity = new DataTable();
                    //Get list of active activities from tbl activity master
                    DtActivity = OEEAct_CatRelationObj.Select_ActivityMaster();

                    //Add Activities as columnname to each FMID wise records from detail tbl
                    for (int i = 0; i < DtActivity.Rows.Count; i++)
                    {
                        if (Dt.Columns.Contains(DtActivity.Rows[i][0].ToString().Trim()))
                        {
                        }
                        else//Activity not in detail tbl but in activity master
                        {
                            Dt.Columns.Add(DtActivity.Rows[i][0].ToString().Trim(), "System.Int64".GetType());
                        }
                    }

                    //Set time for each FMID and activity compbination
                    for (int i = 0; i < Dt.Rows.Count; i++)//loop for FMID
                    {
                        OEEAct_CatRelationObj.fmid = Convert.ToInt64(Dt.Rows[i]["FMID"]);
                        for (int j = 0; j < DtActivity.Rows.Count; j++)//loop for activities
                        {
                            OEEAct_CatRelationObj.Activity = DtActivity.Rows[j][0].ToString().Trim();
                            //Get sum of time and set as details
                            Dt.Rows[i][OEEAct_CatRelationObj.Activity] = OEEAct_CatRelationObj.Get_OEEMFGActivityDetails_ActivityTime();
                        }
                    }

                   

                        #region Category wise calculations
                        if (Dt.Columns.Contains("Total waitaing") || Dt.Columns.Contains("total Manufacturing time") || Dt.Columns.Contains("Std Processing Time") || Dt.Columns.Contains("Processing time") || Dt.Columns.Contains("total Occupation time"))
                        {

                        }
                        else
                        {
                            Dt.Columns.Add("Total waitaing", "System.Int64".GetType());
                            Dt.Columns.Add("total Manufacturing time", "System.Int64".GetType());
                            Dt.Columns.Add("Std Processing Time", "System.Int64".GetType());//from TechFamTMTmaster
                            Dt.Columns.Add("Processing time", "System.Int64".GetType());
                            Dt.Columns.Add("total Occupation time", "System.Int64".GetType());
                        }
                    DataTable DtCategories = new DataTable();
                    DtCategories = OEEAct_CatRelationObj.Select_OEECategoryMaster();

                    for (int i = 0; i < Dt.Rows.Count; i++)
                    {
                        BusinessFacade.Transactions.OEETransactionTest_Class OEETransactionTest_Class_Obj = new BusinessFacade.Transactions.OEETransactionTest_Class();
                        OEEAct_CatRelationObj.fmid = Convert.ToInt64(Dt.Rows[i]["FMID"]);

                        //Waiting time 
                        OEEAct_CatRelationObj.Category = DtCategories.Rows[3][1].ToString().Trim();
                        Dt.Rows[i]["Total waitaing"] = OEEAct_CatRelationObj.Select_OEEMFGActivityDetails_Category();

                        //TManufacrng Time
                        OEEAct_CatRelationObj.Category = DtCategories.Rows[0][1].ToString().Trim();
                        Dt.Rows[i]["total Manufacturing time"] = OEEAct_CatRelationObj.Select_OEEMFGActivityDetails_Category();

                        //Std time //from TechFamTMTmaster
                        OEETransactionTest_Class_Obj.techFamNo = Convert.ToInt64(Dt.Rows[i]["TechFamNo"]);
                        OEETransactionTest_Class_Obj.batchsize = Convert.ToInt64(Dt.Rows[i]["BatchSize"]);

                        Dt.Rows[i]["Std Processing Time"] = OEETransactionTest_Class_Obj.Select_OEETechFamTMTMaster_TMT();

                        //TPT
                        OEEAct_CatRelationObj.Category = DtCategories.Rows[1][1].ToString().Trim();
                        Dt.Rows[i]["Processing time"] = OEEAct_CatRelationObj.Select_OEEMFGActivityDetails_Category();

                        //TOT
                        OEEAct_CatRelationObj.Category = DtCategories.Rows[2][1].ToString().Trim();
                        Dt.Rows[i]["total Occupation time"] = OEEAct_CatRelationObj.Select_OEEMFGActivityDetails_Category();
                    }
                    #endregion
                    
                }
                return Dt;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
        #endregion
    }
}
