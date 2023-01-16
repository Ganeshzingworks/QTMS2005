using System;
using System.Collections.Generic;
using System.Text;
using DataFacade;
using System.Data;
using System.Data.SqlClient;

namespace BusinessFacade
{
    public class PMFamilyMaster_Class
    {
        # region Varibles
        private long PMFamilyID;
        private string PMFamilyName;
        private int COCFrequency;
        private string CDCVersion;
        private long CreatedBy;
        private long ModifiedBy;
        # endregion

        # region Properties
        public long pmfamilyid
        {
            get { return PMFamilyID; }
            set { PMFamilyID = value; }
        }

        public string pmfamilyname
        {
            get { return PMFamilyName; }
            set { PMFamilyName = value; }
        }

        public int cocfrequency
        {
            get { return COCFrequency; }
            set { COCFrequency = value; }
        }

        public string cdcversion
        {
            get { return CDCVersion; }
            set { CDCVersion = value; }
        }
        // This property used for Dimension Parameters (familywise & Testwise)
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

        private int NormsMin;

        public int normsMin
        {
            get { return NormsMin; }
            set { NormsMin = value; }
        }

        private int NormsMax;

        public int normsMax
        {
            get { return NormsMax; }
            set { NormsMax = value; }
        }

        private long PMCodeID;

        public long pmCodeID
        {
            get { return PMCodeID; }
            set { PMCodeID = value; }
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

        public long Insert_PMFamilyMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@PMFamilyName", SqlDbType.VarChar, 200, ParameterDirection.Input, PMFamilyName);
                myparam[1] = ModHelper.CreateParameter("@COCFrequency", SqlDbType.Int, 4, ParameterDirection.Input, COCFrequency);
                myparam[2] = ModHelper.CreateParameter("@CDCVersion", SqlDbType.VarChar, 50, ParameterDirection.Input, CDCVersion);
                myparam[3] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, createdby);

                return Convert.ToInt64(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_Insert_tblPMFamilyMaster", myparam));                                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_PMFamilyMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblPMFamilyMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_PMFamilyMaster_PMFamilyID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@PMFamilyID", SqlDbType.BigInt, 8, ParameterDirection.Input, PMFamilyID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblPMFamilyMaster_PMFamilyID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete_PMFamilyMaster()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@PMFamilyID", SqlDbType.BigInt, 8, ParameterDirection.Input, PMFamilyID);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblPMFamilyMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update_PMFamilyMaster()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[5];
                myparam[0] = ModHelper.CreateParameter("@PMFamilyID", SqlDbType.BigInt, 8, ParameterDirection.Input, PMFamilyID);
                myparam[1] = ModHelper.CreateParameter("@PMFamilyName", SqlDbType.VarChar, 200, ParameterDirection.Input, PMFamilyName);
                myparam[2] = ModHelper.CreateParameter("@COCFrequency", SqlDbType.Int, 4, ParameterDirection.Input, COCFrequency);
                myparam[3] = ModHelper.CreateParameter("@CDCVersion", SqlDbType.VarChar, 50, ParameterDirection.Input, CDCVersion);
                myparam[4] = ModHelper.CreateParameter("@ModifiedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, modifiedby);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblPMFamilyMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        #endregion

        #region PMFamilyDimensionParaRelation

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

        public DataTable Select_DimensionParaRelation_PMFamilyIDTestNo_Updated()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@PMCode", SqlDbType.BigInt, 8, ParameterDirection.Input, pmCodeID);
                myparam[1] = ModHelper.CreateParameter("@PMFamily", SqlDbType.BigInt, 8, ParameterDirection.Input, pmfamilyid);
                myparam[2] = ModHelper.CreateParameter("@Test", SqlDbType.BigInt, 8, ParameterDirection.Input, testNo);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_DimensionParameter_Updated", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert_PMFamilyDimensionMethodMaster()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = ModHelper.CreateParameter("@PMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmCodeID);
                param[1] = ModHelper.CreateParameter("@PMFamilyID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmfamilyid);
                param[2] = ModHelper.CreateParameter("@TestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, testNo);
                param[3] = ModHelper.CreateParameter("@DimensionParaID", SqlDbType.Int, 4, ParameterDirection.Input, dimensionParaID);
                param[4] = ModHelper.CreateParameter("@NormsMin", SqlDbType.VarChar, 50, ParameterDirection.Input, normsMin);
                param[5] = ModHelper.CreateParameter("@NormsMax", SqlDbType.Int, 4, ParameterDirection.Input, normsMax);
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
                SqlParameter[] param = new SqlParameter[6];
                param[0] = ModHelper.CreateParameter("@PMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmCodeID);
                param[1] = ModHelper.CreateParameter("@PMFamilyID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmfamilyid);
                param[2] = ModHelper.CreateParameter("@TestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, testNo);
                param[3] = ModHelper.CreateParameter("@DimensionParaID", SqlDbType.Int, 4, ParameterDirection.Input, dimensionParaID);
                param[4] = ModHelper.CreateParameter("@NormsMin", SqlDbType.VarChar, 50, ParameterDirection.Input, normsMin);
                param[5] = ModHelper.CreateParameter("@NormsMax", SqlDbType.Int, 4, ParameterDirection.Input, normsMax);
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
        #endregion


    }
}
