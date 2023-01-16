using DataFacade;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BusinessFacade
{
    public class LineTransactionRejectionMaster_Class
    {
        #region Varibles
        private long Id;
        private long Loginuser;
        private long LineDescription;
        private string RejectionReason;
        private string RCA;
        #endregion
        #region Properties
        public long id
        {
            get { return Id; }
            set { Id = value; }
        }
        public long loginuser
        {
            get { return Loginuser; }
            set { Loginuser = value; }
        }
        public long lineDescription
        {
            get { return LineDescription; }
            set { LineDescription = value; }
        }
        public string rejectionReason 
        {
            get { return RejectionReason; }
            set { RejectionReason = value; }
        }
        public string rca 
        {
            get { return RCA; }
            set { RCA = value; }
        }
 

        #endregion
        #region Functions 
        public DataSet Select_LineTransactionRejection()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblLayoutLineTransaction");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Insert_LineTransactionRejection()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@LineDescription", SqlDbType.BigInt, 8, ParameterDirection.Input, lineDescription);
                myparam[1] = ModHelper.CreateParameter("@RejectionReason", SqlDbType.Text, int.MaxValue,  ParameterDirection.Input, rejectionReason);
                myparam[2] = ModHelper.CreateParameter("@RCA", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, rca);
                myparam[3] = ModHelper.CreateParameter("@LoginBy", SqlDbType.BigInt, 8, ParameterDirection.Input, loginuser);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_INSERT_tblLineRejectionHistory", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_LayoutLineTransactionMasterByLineDescriptionId(long lineDescription)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@LineDescription", SqlDbType.BigInt, 8, ParameterDirection.Input, lineDescription);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblLineRejectionHistory_ByLineDescription", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update_LineTransactionRejection()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[5];
                myparam[0] = ModHelper.CreateParameter("@Id", SqlDbType.BigInt, 8, ParameterDirection.Input, Id);
                myparam[1] = ModHelper.CreateParameter("@LineDescription", SqlDbType.BigInt, 8, ParameterDirection.Input, lineDescription);
                myparam[2] = ModHelper.CreateParameter("@RejectionReason", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, rejectionReason);
                myparam[3] = ModHelper.CreateParameter("@RCA", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, rca);
                myparam[4] = ModHelper.CreateParameter("@LoginBy", SqlDbType.BigInt, 8, ParameterDirection.Input, loginuser);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblLayoutLineTransactionRejection", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion 

        public DataSet Select_All_Record_tblLineTransactionRejection()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "SP_Select_All_tblLayoutLineTransactionRejection");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet Select_LayoutLineTransactionMasterByLineDescriptionIdDate(long lineDescriptionId,DateTime fromDate, DateTime toDate)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@LineDescription", SqlDbType.BigInt, 8, ParameterDirection.Input, lineDescriptionId);
                myparam[1] = ModHelper.CreateParameter("@FromDate", SqlDbType.DateTime, 250, ParameterDirection.Input, fromDate);
                myparam[2] = ModHelper.CreateParameter("@ToDate", SqlDbType.DateTime, 250, ParameterDirection.Input, toDate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblLineRejectionHistory_ByLineDescription_ByDate", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

         
        public DataSet Select_LayoutLineTransactionMasterByLineRejectionId(long Id)  
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@Id", SqlDbType.BigInt, 8, ParameterDirection.Input, Id);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblLineRejectionHistory_ById", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
