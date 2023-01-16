using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using DataFacade;
using System.Configuration;

namespace BusinessFacade.Transactions
{
    public class OEEAct_CatRelation
    {
        # region Variables
        private long CategoryID;
        private long ActivityID;
        private long FMID;
        private string activity;
        private string category;
        private string startDate;        
        private string endDate;
        private long VesselNo;       
        private long TechFamNo;
        private bool MonthWise;        
        # endregion

        # region Properties
        public long vesselno
        {
            get { return VesselNo; }
            set { VesselNo = value; }
        }

        public long techfamno
        {
            get { return TechFamNo; }
            set { TechFamNo = value; }
        }

        public string StartDate
        {
            get { return startDate; }
            set { startDate = value; }
        }
        public string EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }
        public string Category
        {
            get { return category; }
            set { category = value; }
        }

        public long categoryid
        {
            get
            {
                return CategoryID;
            }
            set
            {
                CategoryID = value;
            }
        }

        public long activityid
        {
            get
            {
                return ActivityID;
            }
            set
            {
                ActivityID = value;
            }
        }

        public long fmid
        {
            get { return FMID; }
            set { FMID = value; }
        }

        public string Activity
        {
            get { return activity; }
            set { activity = value; }
        }

        public bool monthwise
        {
            get { return MonthWise; }
            set { MonthWise = value; }
        }
        # endregion

        # region Functions

        public long Select_OEEMFGActivityDetails_Category()
        {
            DataTable Dt = new DataTable();
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                myparam[1] = ModHelper.CreateParameter("@Category", SqlDbType.NVarChar, 50, ParameterDirection.Input, Category);
                Dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Select_tblOEEMFGActivityDetails_Category", myparam).Tables[0];
                
                #region Return Processed Data as per selected category
                if (Dt.Rows.Count == 0)
                {
                    return 0;//For no record 
                }
                else if (Dt.Rows.Count == 1)
                {
                    return Convert.ToInt64(Dt.Rows[0]["diff"]);
                }
                else if (Dt.Rows.Count > 2)
                {
                    DateTime MaxEndTime = Convert.ToDateTime(Dt.Rows[0]["EndTime"]);//set max End time always in this variable
                    for (int i = 0; i < Dt.Rows.Count - 1; i++)//up to second last record as last record overlapflag is always 0
                    {
                        #region GetMax EndTime Up to i(th) record
                        DateTime CurrentEndTime = Convert.ToDateTime(Dt.Rows[i]["EndTime"]);
                        DateTime NextStartTime = Convert.ToDateTime(Dt.Rows[i + 1]["StartTime"]);
                        if (CurrentEndTime > MaxEndTime)
                        {
                            MaxEndTime = CurrentEndTime;
                            //else MaxEndTime is maximum up to i th record
                        }
                        #endregion

                        #region Check Whether i(th) record is overlap to i+1(th) record
                        if (MaxEndTime >= NextStartTime)//then i th record is overlaping to next ie i+1
                        {
                            Dt.Rows[i]["OverlapFlag"] = 1;//current record is overlap to next record
                            //else keep as it is ie 0
                        }
                        #endregion
                    }
                }

                //Overlap 
                #region Total time calculation
                long TotalTime = 0;
                Int16 PrevOverlapFlag=0;
                DateTime MaxEndTimeOverlap = Convert.ToDateTime(Dt.Rows[0]["EndTime"]);//Need to compare 
                DateTime MinStartTime = Convert.ToDateTime(Dt.Rows[0]["StartTime"]);//Its already sorted ascending, then also we are again comparing 

                for (int i = 0; i < Dt.Rows.Count - 1; i++)//loop up to second last record.
                {
                    Int16 OverlapFlag=Convert.ToInt16(Dt.Rows[i]["OverlapFlag"]);
                    if (OverlapFlag == 0 && PrevOverlapFlag == 0)//process is completely independent
                    {
                        TotalTime =TotalTime + Convert.ToInt64(Dt.Rows[i]["diff"]);
                        //PrevOverlapFlag = 0;//its already
                    }
                    else if (OverlapFlag == 0 && PrevOverlapFlag == 1) //link of overlapped processes ends here.
                    {
                        MaxEndTimeOverlap = GetMax(Convert.ToDateTime(Dt.Rows[i]["EndTime"]), MaxEndTimeOverlap);
                        TimeSpan Substract = MaxEndTimeOverlap.Subtract(MinStartTime);
                        TotalTime = TotalTime + Convert.ToInt64(Substract.TotalMinutes);
                        PrevOverlapFlag = 0;
                    }
                    else if (OverlapFlag == 1 && PrevOverlapFlag == 0)//process is overlap to next process
                    {
                        MaxEndTimeOverlap = Convert.ToDateTime(Dt.Rows[i]["EndTime"]);
                        MinStartTime = Convert.ToDateTime(Dt.Rows[i]["StartTime"]);
                        PrevOverlapFlag = 1;
                    }
                    else if (OverlapFlag == 1 && PrevOverlapFlag == 1)
                    {
                        MaxEndTimeOverlap = GetMax(Convert.ToDateTime(Dt.Rows[i]["EndTime"]), MaxEndTimeOverlap);
                        PrevOverlapFlag = 1;
                    }
                }

                //Calculations for last record
                if (PrevOverlapFlag == 0)//Means current record is independent of previous 
                {
                    TotalTime = TotalTime + Convert.ToInt64(Dt.Rows[Dt.Rows.Count - 1]["diff"]);
                }
                else if (PrevOverlapFlag == 1)//current record is overlap with previous links
                {
                    MaxEndTimeOverlap = GetMax(Convert.ToDateTime(Dt.Rows[Dt.Rows.Count - 1]["EndTime"]), MaxEndTimeOverlap);
                    TimeSpan Substract = MaxEndTimeOverlap.Subtract(MinStartTime);
                  
                    TotalTime = TotalTime + Convert.ToInt64(Substract.TotalMinutes);

                }

                #endregion
                return TotalTime; 
                #endregion
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private DateTime GetMax(DateTime dateTime1, DateTime dateTime2)
        {
            try
            {
                if (dateTime1 > dateTime2)
                    return dateTime1;
                else
                    return dateTime2;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable Select_Report_OEEMFGActivityDetails_Analysis()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[5];
                myparam[0] = ModHelper.CreateParameter("@StartDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, StartDate);
                myparam[1] = ModHelper.CreateParameter("@EndDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, EndDate);
                myparam[2] = ModHelper.CreateParameter("@VesselNo", SqlDbType.BigInt, 8, ParameterDirection.Input, vesselno);
                myparam[3] = ModHelper.CreateParameter("@TechFamNo", SqlDbType.BigInt, 8, ParameterDirection.Input, techfamno);
                myparam[4] = ModHelper.CreateParameter("@MonthWise", SqlDbType.Bit, 8, ParameterDirection.Input,monthwise);
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_Report_tblOEEMFGActivityDetails_Analysis",myparam).Tables[0];
            }
            catch (Exception)
            {
                
                throw;
            }
        }
        public DataTable Select_Report_OEEMFGActivityDetails_Analysis2()
        {
            try
            {
                //SqlParameter[] myparam = new SqlParameter[5];
                //myparam[0] = ModHelper.CreateParameter("@StartDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, StartDate);
                //myparam[1] = ModHelper.CreateParameter("@EndDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, EndDate);
                //myparam[2] = ModHelper.CreateParameter("@VesselNo", SqlDbType.BigInt, 8, ParameterDirection.Input, vesselno);
                //myparam[3] = ModHelper.CreateParameter("@TechFamNo", SqlDbType.BigInt, 8, ParameterDirection.Input, techfamno);
                //myparam[4] = ModHelper.CreateParameter("@MonthWise", SqlDbType.Bit, 8, ParameterDirection.Input, monthwise);
                //return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_Report_tblOEEMFGActivityDetails_Analysis2", myparam).Tables[0];

                SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["connectionstring"]);
                con.Open();
                try
                {
                    DataSet ds = new DataSet();

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "STP_Select_Report_tblOEEMFGActivityDetails_Analysis2";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.Parameters.Add("@StartDate", SqlDbType.SmallDateTime, 4).Value = StartDate;
                    cmd.Parameters.Add("@EndDate", SqlDbType.SmallDateTime, 4).Value = EndDate;
                    cmd.Parameters.Add("@VesselNo", SqlDbType.BigInt, 8).Value = vesselno;
                    cmd.Parameters.Add("@TechFamNo", SqlDbType.BigInt, 8).Value = techfamno;
                    cmd.Parameters.Add("@MonthWise", SqlDbType.Bit, 8).Value = monthwise;
                    
                    cmd.CommandTimeout = 0;
                    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                    adpt.Fill(ds);

                    return ds.Tables[0];
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable Select_Report_OEEMFGActivityDetails_Analysis2__DailyPUR()
        {
            try
            {
                //SqlParameter[] myparam = new SqlParameter[5];
                //myparam[0] = ModHelper.CreateParameter("@StartDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, StartDate);
                //myparam[1] = ModHelper.CreateParameter("@EndDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, EndDate);
                //myparam[2] = ModHelper.CreateParameter("@VesselNo", SqlDbType.BigInt, 8, ParameterDirection.Input, vesselno);
                //myparam[3] = ModHelper.CreateParameter("@TechFamNo", SqlDbType.BigInt, 8, ParameterDirection.Input, techfamno);
                //myparam[4] = ModHelper.CreateParameter("@MonthWise", SqlDbType.Bit, 8, ParameterDirection.Input, monthwise);
                //return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_Report_tblOEEMFGActivityDetails_Analysis2", myparam).Tables[0];

                SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["connectionstring"]);
                con.Open();
                try
                {
                    DataSet ds = new DataSet();

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "STP_Select_Report_tblOEEMFGActivityDetails_Analysis2_DailyPUR";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    cmd.Parameters.Add("@StartDate", SqlDbType.SmallDateTime, 4).Value = StartDate;                    
                    cmd.Parameters.Add("@VesselNo", SqlDbType.BigInt, 8).Value = vesselno;
                    cmd.Parameters.Add("@TechFamNo", SqlDbType.BigInt, 8).Value = techfamno;                    

                    cmd.CommandTimeout = 0;
                    SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                    adpt.Fill(ds);

                    return ds.Tables[0];
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    con.Close();
                }


            }
            catch (Exception)
            {

                throw;
            }
        }

        public long Get_OEEMFGActivityDetails_ActivityTime()
        {
            try
            {
                DataTable Dt = new DataTable();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                myparam[1] = ModHelper.CreateParameter("@Activity", SqlDbType.NVarChar, 100, ParameterDirection.Input, Activity);
                Dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Get_tblOEEMFGActivityDetails_ActivityTime", myparam).Tables[0];
                if (Dt.Rows.Count > 0)
                {
                    if (Dt.Rows[0][0] == DBNull.Value || Dt.Rows[0][0].ToString().Trim().Equals(""))
                    {
                        return 0;
                    }
                    else
                    {
                        return Convert.ToInt64(Dt.Rows[0][0]);
                    }
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }      
        # endregion

        public DataTable Select_ActivityMaster()
        {
            try
            {
                //return SqlHelper.ExecuteDataset(CommandType.Text, "SELECT DISTINCT dbo.tblOEEActivityMaster.Activity,tblOEEMFGActivityDetails.fmid,datediff(n,starttime,endtime) as diff,tblbulkmaster.formulano ,mfgwo FROM         dbo.tblOEEActivityMaster LEFT OUTER JOIN                       dbo.tblOEEMFGActivityDetails ON dbo.tblOEEActivityMaster.ActivityID = dbo.tblOEEMFGActivityDetails.ActivityID LEFT OUTER JOIN tbltransfm on tblOEEMFGActivityDetails.fmid=tbltransfm.fmid LEFT OUTER JOIN tblbulkmaster on tblbulkmaster.fno=tbltransfm.fno WHERE     (dbo.tblOEEActivityMaster.Active = 1)").Tables[0];
                return SqlHelper.ExecuteDataset(CommandType.Text, "select Activity from tblOEEActivityMaster where active=1").Tables[0];
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable Select_OEECategoryMaster()
        {
            try
            {
                //return SqlHelper.ExecuteDataset(CommandType.Text, "SELECT DISTINCT dbo.tblOEEActivityMaster.Activity,tblOEEMFGActivityDetails.fmid,datediff(n,starttime,endtime) as diff,tblbulkmaster.formulano ,mfgwo FROM         dbo.tblOEEActivityMaster LEFT OUTER JOIN                       dbo.tblOEEMFGActivityDetails ON dbo.tblOEEActivityMaster.ActivityID = dbo.tblOEEMFGActivityDetails.ActivityID LEFT OUTER JOIN tbltransfm on tblOEEMFGActivityDetails.fmid=tbltransfm.fmid LEFT OUTER JOIN tblbulkmaster on tblbulkmaster.fno=tbltransfm.fno WHERE     (dbo.tblOEEActivityMaster.Active = 1)").Tables[0];
                return SqlHelper.ExecuteDataset(CommandType.Text, "select * from tblOEECategoryMaster").Tables[0];
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
