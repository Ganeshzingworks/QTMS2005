using System;
using System.Collections.Generic;
using System.Text;
using DataFacade;
using System.Data;
using System.Data.SqlClient;

namespace BusinessFacade
{
    public class PMPeriodicTestMaster_Class
    {
        # region Varibles
        private long PMFamilyID; 
        private string InspectionMethod;
        private string Type;
        private int SampleSize;
        private string AQL;
        private string AQLZ;
        private string AQLC;
        private string AQLM;
        private string AQLM1;
        private string Frequency;
        private long TestNo;
        private string TestName;
        private string LotSize;
        private int Del;
        private long CreatedBy;
        private long ModifiedBy;
        # endregion

        #region Properties
        public int del
        {
            get { return Del; }
            set { Del = value; }
        }

        public long pmfamilyid
        {
            get { return PMFamilyID; }
            set { PMFamilyID=value; }
        }
        
        public long testno
        {
            get { return TestNo; }
            set { TestNo = value; }
        }
        public int samplesize
        {
            get { return SampleSize; }
            set { SampleSize = value; }
        }
        public string testname
        {
            get { return TestName; }
            set { TestName = value; }
        }

        public string lotsize
        {
            get { return LotSize; }
            set { LotSize = value; }
        }

        public string inspectionMethod
        {
            get { return InspectionMethod; }
            set { InspectionMethod = value; }
        }
        
        public string type
        {
            get { return Type; }
            set { Type = value; }
        }
        public string aql
        {
            get { return AQL; }
            set { AQL = value; }
        }
        public string aqlz
        {
            get { return AQLZ; }
            set { AQLZ = value; }
        }
        public string aqlc
        {
            get { return AQLC; }
            set { AQLC = value; }
        }
        public string aqlm
        {
            get { return AQLM; }
            set { AQLM = value; }
        }
        public string aqlm1
        {
            get { return AQLM1; }
            set { AQLM1 = value; }
        }


        public string frequency
        {
            get { return Frequency; }
            set { Frequency = value; }
        }
        public long createdby
        {
            get { return CreatedBy; }
            set { CreatedBy = value; }
        }
        public long modifiedby
        {
            get { return ModifiedBy; }
            set { ModifiedBy = value; }
        }
        #endregion

        #region Functions

        public DataSet Select_PMFinishedGoodDetails()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@PMFamilyID", SqlDbType.BigInt, 8, ParameterDirection.Input, PMFamilyID);
                myparam[1] = ModHelper.CreateParameter("@TestName", SqlDbType.VarChar, 50, ParameterDirection.Input, TestName);
                myparam[2] = ModHelper.CreateParameter("@Frequency", SqlDbType.VarChar, 50, ParameterDirection.Input, Frequency);
                myparam[3] = ModHelper.CreateParameter("@InspectionMethod", SqlDbType.VarChar, 50, ParameterDirection.Input, InspectionMethod);


                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_PMFinisnedGoodDetails", myparam);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
     
        public bool Insert_PMFGTestMethodMaster()
        {
            try
            {
                SqlParameter[] myaparam = new SqlParameter[13];
                myaparam[0] = ModHelper.CreateParameter("@PMFamilyID_1", SqlDbType.BigInt, 8, ParameterDirection.Input, PMFamilyID);
                myaparam[1] = ModHelper.CreateParameter("@TestNo_2", SqlDbType.BigInt, 8, ParameterDirection.Input, TestNo);
                myaparam[2] = ModHelper.CreateParameter("@InspectionMethod_3", SqlDbType.VarChar, 50, ParameterDirection.Input, InspectionMethod);
                myaparam[3] = ModHelper.CreateParameter("@Frequency_4", SqlDbType.VarChar, 50, ParameterDirection.Input, Frequency);
                myaparam[4] = ModHelper.CreateParameter("@AQL_5", SqlDbType.VarChar, 50, ParameterDirection.Input, AQL);
                myaparam[5] = ModHelper.CreateParameter("@AQLZ_6", SqlDbType.VarChar, 50, ParameterDirection.Input, AQLZ);
                myaparam[6] = ModHelper.CreateParameter("@AQLC_7", SqlDbType.VarChar, 50, ParameterDirection.Input, AQLC);
                myaparam[7] = ModHelper.CreateParameter("@AQLM_8", SqlDbType.VarChar, 50, ParameterDirection.Input, AQLM);
                myaparam[8] = ModHelper.CreateParameter("@AQLM1_9", SqlDbType.VarChar, 50, ParameterDirection.Input, AQLM1);
                myaparam[9] = ModHelper.CreateParameter("@SampleSize_10", SqlDbType.Int, 4, ParameterDirection.Input, SampleSize);
                myaparam[10]= ModHelper.CreateParameter("@Type_11", SqlDbType.VarChar, 50, ParameterDirection.Input, Type);
                myaparam[11]= ModHelper.CreateParameter("@LotSize_12", SqlDbType.VarChar, 50, ParameterDirection.Input, LotSize);
                myaparam[12] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, createdby);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblPMFGTestMethodMaster", myaparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_Existsin_PMFGTestMethodMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myaparam = new SqlParameter[3];
                myaparam[0] = ModHelper.CreateParameter("@PMFamilyID", SqlDbType.BigInt, 8, ParameterDirection.Input, PMFamilyID);
                myaparam[1] = ModHelper.CreateParameter("@InspectionMethod", SqlDbType.VarChar, 50, ParameterDirection.Input, InspectionMethod);
                myaparam[2] = ModHelper.CreateParameter("@TestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, TestNo);

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_Existsin_tblPMFGTestMethodMaster", myaparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update_tblPMFGTestMaster()
        {
            try
            {
                SqlParameter[] myaparam = new SqlParameter[13];
                myaparam[0] = ModHelper.CreateParameter("@PMFamilyID_1", SqlDbType.BigInt, 8, ParameterDirection.Input, PMFamilyID);
                myaparam[1] = ModHelper.CreateParameter("@TestNo_2", SqlDbType.BigInt, 8, ParameterDirection.Input, TestNo);
                myaparam[2] = ModHelper.CreateParameter("@InspectionMethod_3", SqlDbType.VarChar, 50, ParameterDirection.Input, InspectionMethod);
                myaparam[3] = ModHelper.CreateParameter("@Frequency_4", SqlDbType.VarChar, 50, ParameterDirection.Input, Frequency);
                myaparam[4] = ModHelper.CreateParameter("@AQL_5", SqlDbType.VarChar, 50, ParameterDirection.Input, AQL);
                myaparam[5] = ModHelper.CreateParameter("@AQLZ_6", SqlDbType.VarChar, 50, ParameterDirection.Input, AQLZ);
                myaparam[6] = ModHelper.CreateParameter("@AQLC_7", SqlDbType.VarChar, 50, ParameterDirection.Input, AQLC);
                myaparam[7] = ModHelper.CreateParameter("@AQLM_8", SqlDbType.VarChar, 50, ParameterDirection.Input, AQLM);
                myaparam[8] = ModHelper.CreateParameter("@AQLM1_9", SqlDbType.VarChar, 50, ParameterDirection.Input, AQLM1);
                myaparam[9] = ModHelper.CreateParameter("@SampleSize_10", SqlDbType.Int, 4, ParameterDirection.Input, SampleSize);
                myaparam[10] = ModHelper.CreateParameter("@Type_11", SqlDbType.VarChar, 50, ParameterDirection.Input, Type);
                myaparam[11] = ModHelper.CreateParameter("@LotSize_12", SqlDbType.VarChar, 50, ParameterDirection.Input, LotSize);
                myaparam[12] = ModHelper.CreateParameter("@ModifiedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, modifiedby);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblPMFGTestMaster", myaparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_PMFGTestMethodMaster_PMFamilyID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@PMFamilyID", SqlDbType.BigInt, 8, ParameterDirection.Input, PMFamilyID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblPMFGTestMethodMaster_PMFamilyID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_PMFGTestMaster_PMFGTestMethodMaster_PMFamilyID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@PMFamilyID", SqlDbType.BigInt, 8, ParameterDirection.Input, PMFamilyID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblPMFGTestMaster_tblPMFGTestMethodMaster_PMFamilyID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete_PMFinishedGoodTestDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@PMFamilyID", SqlDbType.BigInt, 8, ParameterDirection.Input, PMFamilyID);
                myparam[1] = ModHelper.CreateParameter("@TestName", SqlDbType.VarChar, 50, ParameterDirection.Input, TestName);
                myparam[2] = ModHelper.CreateParameter("@Frequency", SqlDbType.VarChar, 50, ParameterDirection.Input, Frequency);
                myparam[3] = ModHelper.CreateParameter("@InspectionMethod", SqlDbType.VarChar, 50, ParameterDirection.Input, InspectionMethod);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblPMFGTestMethodMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update_tblPMFGTestMethodMaster_Del()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[5];
                myparam[0] = ModHelper.CreateParameter("@PMFamilyID", SqlDbType.BigInt, 8, ParameterDirection.Input, PMFamilyID);
                myparam[1] = ModHelper.CreateParameter("@TestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, TestNo);
                myparam[2] = ModHelper.CreateParameter("@Frequency", SqlDbType.VarChar, 50, ParameterDirection.Input, Frequency);
                myparam[3] = ModHelper.CreateParameter("@InspectionMethod", SqlDbType.VarChar, 50, ParameterDirection.Input, InspectionMethod);
                myparam[4] = ModHelper.CreateParameter("@Del", SqlDbType.Bit, 8, ParameterDirection.Input, Del);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblPMFGTestMethodMaster_Del", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
