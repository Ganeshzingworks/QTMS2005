using System;
using System.Collections.Generic;
using System.Text;
using DataFacade;
using System.Data;
using System.Data.SqlClient;

namespace BusinessFacade
{
    public class RMFamilyMaster_Class
    {
        # region Varibles
        private string RMFamilyName;
        private long RMFamilyID;
        private long CreatedBy;
        private long ModifiedBy;
        #endregion

        #region Properties
        public string rmfamilyname
        {
            get { return RMFamilyName; }
            set { RMFamilyName = value; }
        }
        public long rmfamilyid
        {
            get { return RMFamilyID; }
            set { RMFamilyID = value; }
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
        public bool Insert_RMFamilyMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@RMFamilyName", SqlDbType.VarChar, 200, ParameterDirection.Input, RMFamilyName);
                myparam[1] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, CreatedBy);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblRMFamilyMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_RMFamilyMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMFamilyMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update_RMFamilyMaster()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@RMFamilyID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMFamilyID);
                myparam[1] = ModHelper.CreateParameter("@RMFamilyName", SqlDbType.VarChar, 200, ParameterDirection.Input, RMFamilyName);
                myparam[2] = ModHelper.CreateParameter("@ModifiedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, ModifiedBy);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblRMFamilyMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public bool Delete_RMFamilyMaster()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMFamilyID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMFamilyID);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblRMFamilyMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_RMFamilyMaster_RMFamilyName()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMFamilyName", SqlDbType.VarChar, 200, ParameterDirection.Input, rmfamilyname);
                ds=SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMFamilyMaster_RMFamilyName", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion


    }
}
