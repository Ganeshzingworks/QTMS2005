using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;
namespace BusinessFacade
{
    public class FGGlobalFamilyMaster_Class
    {
        #region Varibles
        private long FGGlobalFamilyID;
        private string FGGlobalFamilyName;
        #endregion
        #region Properties
        public long fgglobalfamilyid
        {
            get { return FGGlobalFamilyID; }
            set { FGGlobalFamilyID = value; }
        }
        public string fgglobalfamilyname
        {
            get { return FGGlobalFamilyName; }
            set { FGGlobalFamilyName = value; }
        }
        #endregion
        #region Functions
        public DataSet Select_FGGlobalFamilyMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblFGGlobalFamilyMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_FGGlobalFamilyMaster_FGGlobalFamilyName()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FGGlobalFamilyName", SqlDbType.VarChar, 200, ParameterDirection.Input, fgglobalfamilyname);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblFGGlobalFamilyMaster_FGGlobalFamilyName",myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert_FGGlobalFamilyMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FGGlobalFamilyName", SqlDbType.VarChar, 200, ParameterDirection.Input, fgglobalfamilyname);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_INSERT_tblFGGlobalFamilyMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update_FGGlobalFamilyMaster()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FGGlobalFamilyID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgglobalfamilyid);
                myparam[1] = ModHelper.CreateParameter("@FGGlobalFamilyName", SqlDbType.VarChar, 200, ParameterDirection.Input, fgglobalfamilyname);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblFGGlobalFamilyMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete_FGGlobalFamilyMaster()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FGGlobalFamilyID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgglobalfamilyid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblFGGlobalFamilyMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public DataSet Select_All_Record_tblFGGlobalFamilyMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "SP_Select_All_tblFGGlobalFamilyMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
