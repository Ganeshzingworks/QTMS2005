
/********************************************************
*Author:Manish K
*Date: 
*Description: 
*Revision:
********************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;
using BusinessFacade;

namespace BusinessFacade.Scoop_Class 
{
    public class SCOOPTestMethodMaster_Class
    {
      #region variable
        private Int64 FGNo, SCPTestMethodID, SamplingPointId, TestNo;
        private int LNo, Frequency, SampleSize, AQLM, AQLC, AQLZ, AQLM1,AQL;
      
        bool Del;
      #endregion

        #region Properties

        public int aql
        {
            get { return AQL; }
            set { AQL = value; }

        }

        public Int64 fgNo
        {
            get { return FGNo; }
            set { FGNo = value;}
        }
        public int lno
        {

            get { return LNo; }
            set { LNo = value; }
        }
        public int frequency
        {
            get { return Frequency; }
            set { Frequency = value;}
        }
        public int sampleSize
        {
            get { return SampleSize; }
            set { SampleSize = value; }
        }
        public int aqlm
        {
            get { return AQLM; }
            set { AQLM = value; }

        }
        public int aqlc
        {
            get { return AQLC; }
            set { AQLC = value; }

        }
        public int aqlz
        {
            get { return AQLZ; }
            set { AQLZ = value; }
        }
        public int aqlm1
        {
            get { return AQLM1; }
            set { AQLM1 = value; }
        }
        public Int64 scpTestMethodID
        {
            get { return SCPTestMethodID; }
            set { SCPTestMethodID = value; }
        }
        public Int64 samplingPointId
        {
            get { return SamplingPointId; }
            set { SamplingPointId = value;}
        }
        public bool del
        {

            get { return Del; }
            set { Del = value; }
        }
        public Int64 testNo
        {
            get { return TestNo; }
            set { TestNo = value; }
        }
        #endregion

        #region Functions

        //public DataSet Select_ScoopTestForFGNo()
        //{
        //    DataSet ds = new DataSet();
        //    SqlParameter[] myparam = new SqlParameter[1];
        //    myparam[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgNo);
        //    ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SelectUPTestForFGNo", myparam);
        //    return ds;
        //}

        public DataSet Select_ScoopTestMethodForFGNo() //<-------------------------------------------- SELECT TEST METHODS FOR UP
        {
            DataSet ds = new DataSet();
            SqlParameter[] myparam = new SqlParameter[1];
            myparam[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgNo);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SelectUPTestMethodForFGNo", myparam);
            return ds;
        }

        public bool Insert_tblSCOOPtestMethodMaster()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[12];
                myparam[0] = ModHelper.CreateParameter("@LNo", SqlDbType.Int, 4, ParameterDirection.Input, lno);
                myparam[1] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgNo);
                myparam[2] = ModHelper.CreateParameter("@SamplingPointId", SqlDbType.BigInt, 8, ParameterDirection.Input, samplingPointId);
                myparam[3] = ModHelper.CreateParameter("@TestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, testNo);
                myparam[4] = ModHelper.CreateParameter("@Frequency", SqlDbType.Int, 4, ParameterDirection.Input, frequency);
                myparam[5] = ModHelper.CreateParameter("@SampleSize", SqlDbType.Int, 4, ParameterDirection.Input, sampleSize);
                myparam[6] = ModHelper.CreateParameter("@AQLM", SqlDbType.Int, 4, ParameterDirection.Input, aqlm);
                myparam[7] = ModHelper.CreateParameter("@AQLC", SqlDbType.Int, 4, ParameterDirection.Input, aqlz);
                myparam[8] = ModHelper.CreateParameter("@AQLZ", SqlDbType.Int, 4, ParameterDirection.Input, aqlc);
                myparam[9] = ModHelper.CreateParameter("@AQLM1", SqlDbType.Int, 4, ParameterDirection.Input, aqlm1);
                myparam[10] = ModHelper.CreateParameter("@Del", SqlDbType.Bit, 1, ParameterDirection.Input, del);
                myparam[11] = ModHelper.CreateParameter("@AQL", SqlDbType.Int, 4, ParameterDirection.Input, aql);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblSCOOPtestMethodMaster", myparam);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
           
        }

        public DataSet select_tblSCOOPtestMethodMaster_LineFG()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@LNo", SqlDbType.Int, 4, ParameterDirection.Input, lno);
                myparam[1] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgNo);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_select_tblSCOOPtestMethodMaster_LineFG", myparam);
                return ds;
            } 
            catch (Exception)
            {
                
                throw;
            }
        
        }

        public bool Update_tblSCOOPtestMethodMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[12];
                myparam[0] = ModHelper.CreateParameter("@LNo", SqlDbType.Int, 4, ParameterDirection.Input, lno);
                myparam[1] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgNo);
                myparam[2] = ModHelper.CreateParameter("@SamplingPointId", SqlDbType.BigInt, 8, ParameterDirection.Input, samplingPointId);
                myparam[3] = ModHelper.CreateParameter("@TestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, testNo);
                myparam[4] = ModHelper.CreateParameter("@Frequency", SqlDbType.Int, 4, ParameterDirection.Input, frequency);
                myparam[5] = ModHelper.CreateParameter("@SampleSize", SqlDbType.Int, 4, ParameterDirection.Input, sampleSize);
                myparam[6] = ModHelper.CreateParameter("@AQLM", SqlDbType.Int, 4, ParameterDirection.Input, aqlm);
                myparam[7] = ModHelper.CreateParameter("@AQLC", SqlDbType.Int, 4, ParameterDirection.Input, aqlz);
                myparam[8] = ModHelper.CreateParameter("@AQLZ", SqlDbType.Int, 4, ParameterDirection.Input, aqlc);
                myparam[9] = ModHelper.CreateParameter("@AQLM1", SqlDbType.Int, 4, ParameterDirection.Input, aqlm1);
                myparam[10] = ModHelper.CreateParameter("@Del", SqlDbType.Bit, 1, ParameterDirection.Input,del);
                myparam[11] = ModHelper.CreateParameter("@AQL", SqlDbType.Int, 4, ParameterDirection.Input, aql);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblSCOOPtestMethodMaster", myparam);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        
        }

        public bool Delete_tblSCOOPtestMethodMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@LNo", SqlDbType.Int, 4, ParameterDirection.Input, lno);
                myparam[1] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgNo);
                myparam[2] = ModHelper.CreateParameter("@SamplingPointId", SqlDbType.BigInt, 8, ParameterDirection.Input, samplingPointId);
                myparam[3] = ModHelper.CreateParameter("@TestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, testNo);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblSCOOPtestMethodMaster", myparam);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public DataSet select_STP_Select_NoSampleForFGLine()
        {

            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgNo);
                myparam[1] = ModHelper.CreateParameter("@LNo", SqlDbType.BigInt, 4, ParameterDirection.Input,lno);
                ds=SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_NoSampleForFGLine", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet select_TestForSamplPoint_tblSCOOPtestMethodMaster()
        {

            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgNo);
                myparam[1] = ModHelper.CreateParameter("@LNo", SqlDbType.BigInt, 4, ParameterDirection.Input, lno);
                myparam[2] = ModHelper.CreateParameter("@SamplingPointId", SqlDbType.BigInt, 8, ParameterDirection.Input, samplingPointId);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_TestForSamplPoint_tblSCOOPtestMethodMaster", myparam);
                return ds;
            }
            catch (Exception)
            {
                
                throw;
            }
        
        }


        #endregion
    }
}
