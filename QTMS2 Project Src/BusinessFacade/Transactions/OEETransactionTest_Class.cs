using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DataFacade;

namespace BusinessFacade.Transactions
{
    public class OEETransactionTest_Class
    {
        # region Variables
        long FMID;
        long ActivityID;
        long TechFamNo;
        long TMTFamilyNo;
        long BatchSize;
        long TargetMTime;            
        bool AllowOverlap;
        bool LastActivity;
        DateTime StartTime;
        DateTime EndTime;
        string Comment;
        long OSID;
        private int OperatorID;
        private long ShiftID;
        private long MAID;
        private DateTime Date;
        private string ActivityName;
        private string Status;
        private string Recipe;
        private long MfgID;
        private long CategoryID;
        private string Cyear;
        private string Vessel;
        private int BYearValue;
        private int TargetCWC;
        private int TargetCIP;
        private int Kgs;
        private string KgsValue;

        bool Active;
        # endregion 

        #region Properties
        public long targetmtime
        {
            get { return TargetMTime; }
            set { TargetMTime = value; }
        }  
        public long categoryid
        {
            get { return CategoryID; }
            set { CategoryID = value; }
        }
        public long mfgid
        {
            get { return MfgID; }
            set { MfgID = value; }
        }
        public string status
        {
            get { return Status; }
            set { Status = value; }
        }
        public string activityName
        {
            get { return ActivityName; }
            set { ActivityName = value; }
        }
        public DateTime date
        {
            get { return Date; }
            set { Date = value; }
        }
        public long maid
        {
            get { return MAID; }
            set { MAID = value; }
        }
        public int operatorid
        {
            get { return OperatorID; }
            set { OperatorID = value; }
        }
        public long shiftid
        {
            get { return ShiftID; }
            set { ShiftID = value; }
        }
        public long fmid
        {
            get { return FMID; }
            set { FMID = value; }
        }
        public long activityid
        {
            get { return ActivityID; }
            set { ActivityID = value; }
        }

        public long techFamNo
        {
            get { return TechFamNo; }
            set { TechFamNo = value; }
        }

        public long tmtfamilyno
        {
            get { return TMTFamilyNo; }
            set { TMTFamilyNo = value; }
        }

        public long batchsize
        {
            get { return BatchSize; }
            set { BatchSize = value; }
        }

        public bool allowoverlap
        {
            get { return AllowOverlap; }
            set { AllowOverlap = value; }
        }

        public bool lastActivity
        {
            get { return LastActivity; }
            set { LastActivity = value; }
        }

        public DateTime starttime
        {
            get { return StartTime; }
            set { StartTime = value; }
        }
        public DateTime endtime
        {
            get { return EndTime; }
            set { EndTime = value; }
        }
        public string comment
        {
            get { return Comment; }
            set { Comment = value; }
        }
        public long osid
        {
            get { return OSID; }
            set { OSID = value; }
        }

        public bool active
        {
            get { return Active; }
            set { Active = value; }
        }

        public string recipe
        {
            get { return Recipe; }
            set { Recipe = value; }
        }

        public int targetcip
        {
            get { return TargetCIP; }
            set { TargetCIP = value; }
        }
        public int targetcwc
        {
            get { return TargetCWC; }
            set { TargetCWC = value; }
        }
        public int byearvalue
        {
            get { return BYearValue; }
            set { BYearValue = value; }
        }
        public string vessel
        {
            get { return Vessel; }
            set { Vessel = value; }
        }
        public string cyear
        {
            get { return Cyear; }
            set { Cyear = value; }
        }
        public int kgs
        {
            get { return Kgs; }
            set { Kgs = value; }
        }
        public string kgsvalue
        {
            get { return KgsValue; }
            set { KgsValue = value; }
        }

        # endregion

        # region Functions

        public DataSet Select_OEEBulkTestDetails()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_OEEBulkTestDetails");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_tblOEEShiftMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblOEEShiftMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_tblOEEActivityMaster()
        {
            try
            {
                return (SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblOEEActivityMaster").Tables[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_tblOEEActivityMaster_All()
        {
            try
            {
                return (SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblOEEActivityMaster_All").Tables[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Select_tblOEEActivityMaster_LastActivity()
        {
            try
            {
                return Convert.ToInt64(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "Select_tblOEEActivityMaster_LastActivity"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }       

        public DataSet STP_Select_tblBulTestTransaction()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 4, ParameterDirection.Input, FMID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblBulTestTransaction",myparam );
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet STP_Select_tblBulTestTransaction_OEEProtocol()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 4, ParameterDirection.Input, FMID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblBulTestTransaction_OEEProtocol", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_OEEMFGActivityDetails_Graph()
        {
            try
            {
                return SqlHelper.ExecuteDataset(CommandType.Text, "select * from View_OEEActivity where FMID=" + this.fmid.ToString()).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_tblOEEMFGActivityDetails()
        {
            try
            {
               return  SqlHelper.ExecuteDataset(CommandType.Text, "select * from tblOEEMFGActivityDetails").Tables[0];                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_OEETechFamTMTMaster(bool GetAllRecords)
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@TMTFamilyNo", SqlDbType.BigInt, 8, ParameterDirection.Input, tmtfamilyno);
                myparam[1] = ModHelper.CreateParameter("@GetAllRecords", SqlDbType.Bit, 1, ParameterDirection.Input, GetAllRecords);
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblOEETechFamTMTMaster",myparam).Tables[0];
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataSet Select_VesselDesc_tblVesselMst(int VesselNo)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@VesselNo", SqlDbType.BigInt, 4, ParameterDirection.Input, VesselNo);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblVesselMster",myparam );
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_OEEActivityDetails()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 4, ParameterDirection.Input, fmid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_OEEActivityDetails", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete_OEEActivityDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 4, ParameterDirection.Input, fmid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_OEEActivityDetails", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete_OEEActivityDetails_MAID()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@MAID", SqlDbType.BigInt, 4, ParameterDirection.Input, maid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_OEEActivityDetails_MAID", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_OEEActivityDetails_MAID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@MAID", SqlDbType.BigInt, 4, ParameterDirection.Input, maid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_OEEActivityDetails_MAID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public DataSet Select_OEEOperatorDetails()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 4, ParameterDirection.Input, fmid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_OEEOperatorDetails", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DateTime Select_OEEActivityDetails_MaxEndTime()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                myparam[1] = ModHelper.CreateParameter("@DATE", SqlDbType.SmallDateTime, 4, ParameterDirection.Output, date);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_OEEActivityDetails_MaxEndTime", myparam);
                return Convert.ToDateTime(myparam[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert_OEEMFGActivityMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@Activity", SqlDbType.NVarChar, 100, ParameterDirection.Input,activityName);
                myparam[1] = ModHelper.CreateParameter("@LastActivity", SqlDbType.Bit, 1, ParameterDirection.Input, lastActivity);
                myparam[2] = ModHelper.CreateParameter("@Kgs", SqlDbType.Int, 4, ParameterDirection.Input, kgs);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblOEEMFGActivityMaster", myparam);
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public long Insert_tblOEEMFGActivityDetail()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[9];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                myparam[1] = ModHelper.CreateParameter("@ActivityID", SqlDbType.BigInt, 8, ParameterDirection.Input, activityid);                
                myparam[2] = ModHelper.CreateParameter("@StartTime", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, starttime);
                myparam[3] = ModHelper.CreateParameter("@EndTime", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, endtime);
                myparam[4] = ModHelper.CreateParameter("@Comment", SqlDbType.VarChar, 100, ParameterDirection.Input, comment);                
                myparam[5] = ModHelper.CreateParameter("@OperatorID", SqlDbType.Int, 4, ParameterDirection.Input, operatorid);                
                myparam[6] = ModHelper.CreateParameter("@ShiftID", SqlDbType.BigInt, 8, ParameterDirection.Input, shiftid);
                myparam[7] = ModHelper.CreateParameter("@KgsValue", SqlDbType.Decimal, 8, ParameterDirection.Input, kgsvalue == "" ? null : kgsvalue);
                myparam[8] = ModHelper.CreateParameter("@MAID", SqlDbType.BigInt, 8, ParameterDirection.Output, maid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblOEEMFGActivityDetails", myparam);                
                return Convert.ToInt64(myparam[6].Value);
            }
            catch (Exception ex)
            {
                throw ex;                
            }            
        }
        public void Update_tblOEEMFGActivityDetail()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[9];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                myparam[1] = ModHelper.CreateParameter("@ActivityID", SqlDbType.BigInt, 8, ParameterDirection.Input, activityid);
                myparam[2] = ModHelper.CreateParameter("@StartTime", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, starttime);
                myparam[3] = ModHelper.CreateParameter("@EndTime", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, endtime);
                myparam[4] = ModHelper.CreateParameter("@Comment", SqlDbType.VarChar, 100, ParameterDirection.Input, comment);
                myparam[5] = ModHelper.CreateParameter("@OperatorID", SqlDbType.Int, 4, ParameterDirection.Input, operatorid);
                myparam[6] = ModHelper.CreateParameter("@ShiftID", SqlDbType.BigInt, 8, ParameterDirection.Input, shiftid);
                myparam[7] = ModHelper.CreateParameter("@KgsValue", SqlDbType.Decimal, 8, ParameterDirection.Input, kgsvalue == "" ? null : kgsvalue);
                myparam[8] = ModHelper.CreateParameter("@MAID", SqlDbType.BigInt, 8, ParameterDirection.Input, maid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblOEEMFGActivityDetails", myparam);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public long Update_tblOEEMFGActivityDetail()
        //{
        //    try
        //    {
        //        SqlParameter[] myparam = new SqlParameter[8];
        //        myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
        //        myparam[1] = ModHelper.CreateParameter("@ActivityID", SqlDbType.BigInt, 8, ParameterDirection.Input, activityid);                
        //        myparam[2] = ModHelper.CreateParameter("@StartTime", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, starttime);
        //        myparam[3] = ModHelper.CreateParameter("@EndTime", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, endtime);
        //        myparam[4] = ModHelper.CreateParameter("@Comment", SqlDbType.VarChar, 100, ParameterDirection.Input, comment);                
        //        myparam[5] = ModHelper.CreateParameter("@OperatorID", SqlDbType.Int, 4, ParameterDirection.Input, operatorid);                
        //        myparam[6] = ModHelper.CreateParameter("@ShiftID", SqlDbType.BigInt, 8, ParameterDirection.Input, shiftid);                
        //        myparam[7] = ModHelper.CreateParameter("@MAID", SqlDbType.BigInt, 8, ParameterDirection.Output, maid);
        //        SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblOEEMFGActivityDetails", myparam);                
        //        return Convert.ToInt64(myparam[6].Value);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;                
        //    }            
        //}

        public long Insert_tblOEEOperatorShiftDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@OperatorID", SqlDbType.BigInt, 4, ParameterDirection.Input, operatorid);
                myparam[1] = ModHelper.CreateParameter("@ShiftID", SqlDbType.BigInt, 8, ParameterDirection.Input, shiftid);
                myparam[2] = ModHelper.CreateParameter("@OSID", SqlDbType.BigInt, 8, ParameterDirection.Output, osid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblOEEOperatorShiftDetails", myparam);
                return Convert.ToInt64(myparam[2].Value);
            }
            catch (Exception ex)
            {
                throw ex;                
            }            
        }

        public long Insert_tblOEEMFGDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                myparam[1] = ModHelper.CreateParameter("@Status", SqlDbType.Char, 1, ParameterDirection.Input, status);
                myparam[2] = ModHelper.CreateParameter("@MfgID", SqlDbType.BigInt, 8, ParameterDirection.Input, mfgid);
                myparam[3] = ModHelper.CreateParameter("@Recipe", SqlDbType.VarChar, 4000, ParameterDirection.Input, recipe);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblOEEMFGDetails", myparam);
                return Convert.ToInt64(myparam[2].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Update_tblOEEMFGDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                myparam[1] = ModHelper.CreateParameter("@Status", SqlDbType.Char, 1, ParameterDirection.Input, status);
                myparam[2] = ModHelper.CreateParameter("@Recipe", SqlDbType.VarChar, 4000, ParameterDirection.Input, recipe);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblOEEMFGDetails", myparam);                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Update_OEEMFGActivityMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@Activity", SqlDbType.NVarChar, 100, ParameterDirection.Input, activityName);
                myparam[1] = ModHelper.CreateParameter("@ActivityId", SqlDbType.BigInt, 8, ParameterDirection.Input, activityid);
                myparam[2] = ModHelper.CreateParameter("@LastActivity", SqlDbType.Bit, 1, ParameterDirection.Input, lastActivity);
                myparam[3] = ModHelper.CreateParameter("@Kgs", SqlDbType.Int, 4, ParameterDirection.Input, kgs);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblOEEMFGActivityMaster", myparam);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void Update_OEETechFamTMTMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@TMTFamilyNo", SqlDbType.Int, 4, ParameterDirection.Input, tmtfamilyno);
                myparam[1] = ModHelper.CreateParameter("@TechFamNo", SqlDbType.Int, 4, ParameterDirection.Input, techFamNo);
                myparam[2] = ModHelper.CreateParameter("@BatchSize", SqlDbType.Int, 4, ParameterDirection.Input,batchsize);
                myparam[3] = ModHelper.CreateParameter("@TargetMTime", SqlDbType.BigInt, 8, ParameterDirection.Input,targetmtime);
                 
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblOEETechFamTMTMaster", myparam);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Insert_OEETechFamTMTMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@TechFamNo", SqlDbType.Int, 4, ParameterDirection.Input, techFamNo);
                myparam[1] = ModHelper.CreateParameter("@BatchSize", SqlDbType.Int, 4, ParameterDirection.Input, batchsize);
                myparam[2] = ModHelper.CreateParameter("@TargetMTime", SqlDbType.BigInt, 8, ParameterDirection.Input, targetmtime);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblOEETechFamTMTMaster", myparam);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet Select_tblOEEMFGDetails()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblOEEMFGDetails", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblOEECategoryMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblOEECategoryMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Insert_tblOEEActivityCategoryRelation()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@ActivityID", SqlDbType.BigInt, 8, ParameterDirection.Input, activityid);
                myparam[1] = ModHelper.CreateParameter("@CategoryID", SqlDbType.BigInt, 8, ParameterDirection.Input, categoryid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblOEEActivityCategoryRelation", myparam);                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_tblOEEActivityCategoryRelation()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@CategoryID", SqlDbType.BigInt, 8, ParameterDirection.Input, categoryid);
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblOEEActivityCategoryRelation", myparam).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete_OEEActivityCategoryRelation()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@CategoryID", SqlDbType.BigInt, 8, ParameterDirection.Input, categoryid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblOEEActivityCategoryRelation", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete_OEEActivityMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@ActivityID", SqlDbType.BigInt, 8, ParameterDirection.Input, activityid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblOEEActivityMaster", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete_OEETechFamTMTMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@TMTFamilyNo", SqlDbType.BigInt, 8, ParameterDirection.Input, tmtfamilyno);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblOEETechFamTMTMaster", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        # endregion       
      
    
        public long Select_OEETechFamTMTMaster_TMT()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@TechFamNo", SqlDbType.Int, 4, ParameterDirection.Input, techFamNo);
                myparam[1] = ModHelper.CreateParameter("@BatchSize", SqlDbType.Int, 4, ParameterDirection.Input, batchsize);
                return Convert.ToInt64(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_Select_tblOEETechFamTMTMaster_TMT", myparam));
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool Select_OEEActivityDetails_ValidClosing()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 4, ParameterDirection.Input, fmid);
                return Convert.ToBoolean(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_Select_OEEActivityDetails_ValidClosing",myparam));
            }
            catch (Exception)
            {
                
                throw;
            }
        }


        public bool InsertUpdate_tblDailyPURExcelUpload()
        {
            try
            {
                bool result = false;
                SqlParameter[] myparam = new SqlParameter[5];
                myparam[0] = ModHelper.CreateParameter("@CYear", SqlDbType.VarChar, 20, ParameterDirection.Input, cyear);
                myparam[1] = ModHelper.CreateParameter("@Vessel", SqlDbType.VarChar, 4000, ParameterDirection.Input, vessel);
                myparam[2] = ModHelper.CreateParameter("@BYearValue", SqlDbType.Int, 8, ParameterDirection.Input, byearvalue);
                myparam[3] = ModHelper.CreateParameter("@TargetCWC", SqlDbType.Int, 8, ParameterDirection.Input, targetcwc);
                myparam[4] = ModHelper.CreateParameter("@TargetCIP", SqlDbType.Int, 8, ParameterDirection.Input, targetcip);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_InsertUpdate_tblDailyPURExcelUpload", myparam);
                result = true;
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_tblOEEActivityMaster_ByActivityID()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@ActivityID", SqlDbType.BigInt, 8, ParameterDirection.Input, activityid);
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblOEEActivityMaster_ByActivityID", myparam).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
