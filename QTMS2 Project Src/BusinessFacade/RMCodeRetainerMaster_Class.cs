using System;
using System.Collections.Generic;
using System.Text;
using DataFacade;
using System.Data.SqlClient;
using System.Data;

namespace BusinessFacade
{
    public class RMCodeRetainerMaster_Class
    { 
        #region Variables
        private string Type;
        private long RmCodeId;
        private long RmRetainerId;
        private long CreatedBy;
        private long ModifiedBy;
        #endregion

        #region Properties

        public string type
        {
            get { return Type; }
            set { Type = value; }
        }

        public long rmCodeId
        {
            get { return RmCodeId;}
            set { RmCodeId=value;}
        }

        public long rmRetainerId
        {
            get { return RmRetainerId; }
            set { RmRetainerId = value; }
        }      
      
        #endregion

        private long RMRetainerSAID;

        public long rmretainerid
        {
            get { return RMRetainerSAID; }
            set { RMRetainerSAID = value; }
        }

        private long RMCodeID;

        public long rmcodeid
        {
            get { return RMCodeID; }
            set { RMCodeID = value; }
        }

        private int SymID;

        public int symid
        {
            get { return SymID; }
            set { SymID = value; }
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


        #region Functions

        public DataTable Select_RMAccessoriesSymbol()
        {
            try
            {
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMAccessoriesSymbol").Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Select_RMSafetySymbol()
        {
            try
            {
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMSafetySymbol").Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_RMAccessoriesSymbol_RMCodeID()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 1, ParameterDirection.Input, rmcodeid);

                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMAccessoriesSymbol_RMCodeID", myparam).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Select_RMSafetySymbol_RMCodeID()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 1, ParameterDirection.Input, rmcodeid);

                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMSafetySymbol_RMCodeID", myparam).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert_RMRetainerSASymbol()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 1, ParameterDirection.Input, rmcodeid);
                myparam[1] = ModHelper.CreateParameter("@SymID", SqlDbType.BigInt, 1, ParameterDirection.Input, symid);
                myparam[2] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, createdby);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblRMRetainerSASymbol", myparam);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete_RMRetainerSASymbol()
        {
             try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 1, ParameterDirection.Input, rmcodeid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblRMRetainerSASymbol", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
   
        #endregion    
        #region Old Code
        public DataTable Select_RMRetainerMaster_By_Type()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@Type", SqlDbType.Char, 1, ParameterDirection.Input, type);
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMRetainerMaster_By_Type", myparam).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_RMRetainerDetails_RMCodeId_Type()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@Type", SqlDbType.Char, 1, ParameterDirection.Input, type);
                myparam[1] = ModHelper.CreateParameter("@RMCodeId", SqlDbType.BigInt, 1, ParameterDirection.Input, rmCodeId);
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMRetainerDetails_RMCodeId_Type", myparam).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert_RMRetainerDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@RMCodeId", SqlDbType.BigInt, 1, ParameterDirection.Input, rmCodeId);
                myparam[1] = ModHelper.CreateParameter("@RMRetainerId", SqlDbType.BigInt, 1, ParameterDirection.Input, rmRetainerId);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblRMRetainerDetails", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete_RMRetainerDetails_By_RMCodeId()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMCodeId", SqlDbType.BigInt, 1, ParameterDirection.Input, rmCodeId);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblRMRetainerDetails_RMCodeId", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
             #endregion
    }
}
