using System;
using System.Collections.Generic;
using System.Text;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;

namespace BusinessFacade
{
    public class SatbilityTest_Class
    {

       # region Variables

       private int LoginID;
       private long FormulaNo;
       private long FNo;
       private long FMID;
       private string BulkDesc;
       private int NoBatches = 0;
       private string LunchDate;
       private string CompletedDay;
       private string CompletedOn;
       private string TestType;
       private long FGPhyMethodNo;
       private string NormsMin;
       private string NormsMax;
       private string Reading;
       private string Remark = "";
       private string ReadingType;
       private string PendingFor;
       private string InspDate="";
       private string MfgDate = "";
       private int BatchSize=0;
       private string InitialValue;
       private string FinalValue;
       private string MicroNorms;
       private int VerifiedBy;
       private int InspectedBy;
       private string FileName; 

      


       public long formulano
       {
           get { return FormulaNo; }
           set { FormulaNo = value; }
       }
       public long fno
       {
           get { return FNo; }
           set { FNo = value; }
       }
       public long fmid
       {
           get { return FMID; }
           set { FMID = value; }
       }
       public string bulkdesc
        {
            get { return BulkDesc; }
            set { BulkDesc = value; }
        }
       public int noofbatches
        {
            get { return NoBatches; }
            set { NoBatches = value; }
        }
       public string completedon
       {
           get { return CompletedOn; }
           set { CompletedOn = value; }
       }
       public string lunchdate
       {
           get { return LunchDate; }
           set { LunchDate = value; }
       }
       public string completedday
       {
           get { return CompletedDay; }
           set { CompletedDay = value; }
       } 
       public string readingtype
        {
           get { return ReadingType; }
           set { ReadingType = value; }
       }
       public int inspectedby
       {
           get { return InspectedBy; }
           set { InspectedBy = value; }
       }
       public int verifiedby
       {
           get { return VerifiedBy; }
           set { VerifiedBy = value; }
       }
       public int loginid
       {
           get { return LoginID; }
           set { LoginID = value; }
       }
       public string pendingfor
        {
            get { return PendingFor; }
            set { PendingFor = value; }
        }
       public int batchsize
       {
           get { return BatchSize; }
           set { BatchSize = value; }
       }
       public string remark
       {
           get { return Remark; }
           set { Remark = value; }
       }
       public string reading
       {
           get { return Reading; }
           set { Reading = value; }
       }
       public string testtype
       {
           get { return TestType; }
           set { TestType = value; }
       }
       public string initialvalue
       {
           get { return InitialValue; }
           set { InitialValue = value; }
       }
       public string finalvalue
       {
           get { return FinalValue; }
           set { FinalValue = value; }
       }
       public long fgphymethodno
       {
           get { return FGPhyMethodNo; }
           set { FGPhyMethodNo = value; }
       }
       public string normmin
       {
           get { return NormsMin; }
           set { NormsMin = value; }
       }
       public string normmax
       {
           get { return NormsMax; }
           set { NormsMax = value; }
       }
       public string filename
       {
           get { return FileName; }
           set { FileName = value; }
       }
        

        # endregion


       public DataSet SELECT_StabilityReminder_FormulaNo_Active()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_StabilityReminder_FormulaNo_Active");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet SELECT_StabilityReminder_Active()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myaparam = new SqlParameter[1];
               myaparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_StabilityReminder_Active", myaparam);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }

       }

        public DataSet SELECT_StabilityTest_FormulaNo_For_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_StabilityTest_FormulaNo_For_Report");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet SELECT_View_StabilityTest_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_View_StabilityTest_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SELECT_tblBulkPhysicochemicalTestMethodDetails_ForSatbilityTest_FMID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myaparam = new SqlParameter[1];
                myaparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblBulkPhysicochemicalTestMethodDetailsForSatbilityTest_FMID", myaparam);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SELECT_tblFGPhysicochemicalTestMethodMaster_FNo_StabilityTest()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myaparam = new SqlParameter[1];
                myaparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblFGPhysicochemicalTestMethodMaster_FNo_StabilityTest", myaparam);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool INSERT_tblStabilityTestDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[9];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.Int, 8, ParameterDirection.Input, fmid);
                myparam[1] = ModHelper.CreateParameter("@FGPhyMethodNo", SqlDbType.Int, 8, ParameterDirection.Input, fgphymethodno);
                myparam[2] = ModHelper.CreateParameter("@NormsReading", SqlDbType.VarChar, 50, ParameterDirection.Input, reading);
                myparam[3] = ModHelper.CreateParameter("@Remark", SqlDbType.VarChar, 200, ParameterDirection.Input, remark);
                myparam[4] = ModHelper.CreateParameter("@NormsMin", SqlDbType.VarChar, 50, ParameterDirection.Input, normmin);// newly added at transaction level for save norms
                myparam[5] = ModHelper.CreateParameter("@NormsMax", SqlDbType.VarChar, 50, ParameterDirection.Input, normmax);
                myparam[6] = ModHelper.CreateParameter("@TestType", SqlDbType.VarChar, 50, ParameterDirection.Input, testtype);
                myparam[7] = ModHelper.CreateParameter("@CompletedDay", SqlDbType.VarChar, 50, ParameterDirection.Input, completedday);
                myparam[8] = ModHelper.CreateParameter("@ReadingType", SqlDbType.VarChar, 50, ParameterDirection.Input, readingtype);
                
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_INSERT_tblStabilityTestDetails", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet STP_SELECT_StabilityTest_History()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myaparam = new SqlParameter[2];
                myaparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myaparam[1] = ModHelper.CreateParameter("@CompleteDday", SqlDbType.VarChar, 50, ParameterDirection.Input, completedday);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_StabilityTest_History", myaparam);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet STP_Update_tblStabilityTestReminder()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myaparam = new SqlParameter[3];
                myaparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myaparam[1] = ModHelper.CreateParameter("@PendingFor", SqlDbType.VarChar, 50, ParameterDirection.Input, completedday);
                myaparam[2] = ModHelper.CreateParameter("@FileName", SqlDbType.VarChar, 50, ParameterDirection.Input, filename);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Update_tblStabilityTestReminder", myaparam);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update_tblStabilityTestDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[6];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.Int, 8, ParameterDirection.Input, fmid);
                myparam[1] = ModHelper.CreateParameter("@FGPhyMethodNo", SqlDbType.Int, 8, ParameterDirection.Input, fgphymethodno);
                myparam[2] = ModHelper.CreateParameter("@NormsReading", SqlDbType.VarChar, 50, ParameterDirection.Input, reading);
                myparam[3] = ModHelper.CreateParameter("@Remark", SqlDbType.VarChar, 200, ParameterDirection.Input, remark);
                myparam[4] = ModHelper.CreateParameter("@CompletedDay", SqlDbType.VarChar, 50, ParameterDirection.Input, completedday);
                myparam[5] = ModHelper.CreateParameter("@ReadingType", SqlDbType.VarChar, 50, ParameterDirection.Input, readingtype);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_StabilityTest_Details", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SELECT_StabilityTest_For_Update()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.Int, 8, ParameterDirection.Input, fmid);
                myparam[1] = ModHelper.CreateParameter("@CompletedDay", SqlDbType.VarChar, 50, ParameterDirection.Input, completedday);
               
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_StabilityTest_For_Update", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet STP_Update_tblStabilityTestReminder_PdfFileName()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myaparam = new SqlParameter[2];
                myaparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                myaparam[1] = ModHelper.CreateParameter("@FileName", SqlDbType.VarChar, 50,ParameterDirection.Input, filename);

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Update_tblStabilityTestReminder_PdfFileName", myaparam);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SELECT_StabilityTrace_BindFormula()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_StabilityTrace_Forumula");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool Send_Email_StabilityTrace(int fmid,string emailid)
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@fm_id", SqlDbType.Int, 8, ParameterDirection.Input, fmid);
                myparam[1] = ModHelper.CreateParameter("@toemailid", SqlDbType.VarChar, 250, ParameterDirection.Input, emailid);


                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Email_StabilityTrace", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
