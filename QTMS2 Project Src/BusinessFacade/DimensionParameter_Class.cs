using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using DataFacade;
using System.Data;

namespace BusinessFacade
{
    public class DimensionParameter_Class
    {
        #region Variables & Properties

        private long PMCodeID;
        private long CreatedBy;
        private long ModifiedBy;
        public long pmCodeID
        {
            get { return PMCodeID; }
            set { PMCodeID = value; }
        }

        private long PMFamilyID;
        public long pmfamilyid
        {
            get { return PMFamilyID; }
            set { PMFamilyID = value; }
        }
        private int DimensionParaID;

        public int dimensionParaID
        {
            get { return DimensionParaID; }
            set { DimensionParaID = value; }
        }
        private long TestNo;

        public long testNo
        {
            get { return TestNo; }
            set { TestNo = value; }
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

        private double NormsMin;

        public double normsMin
        {
            get { return NormsMin; }
            set { NormsMin = value; }
        }

        private double NormsMax;

        public double normsMax
        {
            get { return NormsMax; }
            set { NormsMax = value; }
        }
        private long Quantity;

        public long quantity
        {
            get { return Quantity; }
            set { Quantity = value; }
        }

        private long PMTransID;

        public long pmTransID
        {
            get { return PMTransID; }
            set { PMTransID = value; }
        }
        private long DPTransStatusID;

        public long dpTransStatusID
        {
            get { return DPTransStatusID; }
            set { DPTransStatusID = value; }
        }

        private long DimensionMethodID;

        public long dimensionMethodID
        {
            get { return DimensionMethodID; }
            set { DimensionMethodID = value; }
        }


        #endregion

        #region Functions

        public DataTable Select_PMFamilyDimensionParaRelation_PMFamilyID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@PMFamilyID", SqlDbType.BigInt, 8, ParameterDirection.Input, PMFamilyID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblPMFamilyDimensionParaRelation_PMFamilyID", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert_PMFamilyDimensionParaRelation()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@PMFamilyID", SqlDbType.BigInt, 8, ParameterDirection.Input, PMFamilyID);
                myparam[1] = ModHelper.CreateParameter("@DimensionParaID", SqlDbType.Int, 4, ParameterDirection.Input, dimensionParaID);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblPMFamilyDimensionParaRelation", myparam);
                //return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete_PMFamilyDimensionParaRelation()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@PMFamilyID", SqlDbType.BigInt, 8, ParameterDirection.Input, PMFamilyID);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblPMFamilyDimensionParaRelation", myparam);
                //return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Show Parameter name in particular family
        public DataTable Select_DimensionParaRelation_PMFamilyID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@PMFamilyID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmfamilyid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_DimensionParameter_FamilyID", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Show Parameter name in particular family & test
        public DataTable Select_DimensionParaRelation_PMFamilyIDTestNo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@PMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmCodeID);
                myparam[1] = ModHelper.CreateParameter("@PMFamilyID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmfamilyid);
                myparam[2] = ModHelper.CreateParameter("@TestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, testNo);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_DimensionParameter_FamilyIDTestNo", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <Summary>
        /// Insert Norms of parameter familywise & testwise
        /// </Summary>

        public bool Insert_PMFamilyDimensionMethodMaster()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[7];
                param[0] = ModHelper.CreateParameter("@PMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmCodeID);
                param[1] = ModHelper.CreateParameter("@PMFamilyID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmfamilyid);
                param[2] = ModHelper.CreateParameter("@TestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, testNo);
                param[3] = ModHelper.CreateParameter("@DimensionParaID", SqlDbType.Int, 4, ParameterDirection.Input, dimensionParaID);
                param[4] = ModHelper.CreateParameter("@NormsMin", SqlDbType.Float, 50, ParameterDirection.Input, normsMin);
                param[5] = ModHelper.CreateParameter("@NormsMax", SqlDbType.Float, 4, ParameterDirection.Input, normsMax);
                param[6] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, createdby);
                int i = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblPMFamilyDimensionMethodMaster", param);
                if (i > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <Summary>
        /// UPDATE Norms of parameter familywise & testwise
        /// </Summary>

        public bool Update_PMFamilyDimensionMethodMaster()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[7];
                param[0] = ModHelper.CreateParameter("@PMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmCodeID);
                param[1] = ModHelper.CreateParameter("@PMFamilyID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmfamilyid);
                param[2] = ModHelper.CreateParameter("@TestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, testNo);
                param[3] = ModHelper.CreateParameter("@DimensionParaID", SqlDbType.Int, 4, ParameterDirection.Input, dimensionParaID);
                param[4] = ModHelper.CreateParameter("@NormsMin", SqlDbType.Float, 50, ParameterDirection.Input, normsMin);
                param[5] = ModHelper.CreateParameter("@NormsMax", SqlDbType.Float, 4, ParameterDirection.Input, normsMax);
                param[6] = ModHelper.CreateParameter("@ModifiedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, modifiedby);
                int i = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblPMFamilyDimensionMethodMaster", param);
                if (i > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Show Parameter name in particular family & test & dimension parameter
        public DataTable Select_DimensionParaRelation_PMFamilyIDTestNodimensionParaID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@PMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmCodeID);
                myparam[1] = ModHelper.CreateParameter("@PMFamilyID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmfamilyid);
                myparam[2] = ModHelper.CreateParameter("@TestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, testNo);
                myparam[3] = ModHelper.CreateParameter("@DimensionParaID", SqlDbType.Int, 4, ParameterDirection.Input, dimensionParaID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_tblPMFamilyDimensionMethodMaster_CheckExist", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_DimensionParaRelation_PMCodeIDTestNo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@PMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmCodeID);
                myparam[1] = ModHelper.CreateParameter("@TestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, testNo);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_DimensionParameter_PMCodeIDTestNo", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_DimensionParaRelation_PMTransID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@PMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmTransID);
                myparam[1] = ModHelper.CreateParameter("@TestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, testNo);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblDimensionStatusPMTransRelation_PMTransID", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Select_DimensionParaRelation_PMTransIDTestNo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@PMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmTransID);
                myparam[1] = ModHelper.CreateParameter("@TestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, testNo);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_GetNorms_PMTransID_TestNo", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable STP_Select_DimensionObs_TestNo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@TestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, testNo);
                //myparam[0] = ModHelper.CreateParameter("@SampleSize", SqlDbType.BigInt, 8, ParameterDirection.Input, quantity);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_DimensionObs_TestNo", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable Select_DimensionParaRelation_StatusIDDimensionMethodID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@DPTransStatusID", SqlDbType.BigInt, 8, ParameterDirection.Input, dpTransStatusID);
                myparam[1] = ModHelper.CreateParameter("@DimensionMethodID", SqlDbType.BigInt, 8, ParameterDirection.Input, dimensionMethodID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_TransactionObservation_PMTransIDDimensionMethodID", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
