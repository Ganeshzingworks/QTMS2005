using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DataFacade;
namespace BusinessFacade.Transactions
{
    public class FGPending_Class
    {
        #region Properties

        private long FGPendingID;

        public long fgPendingID
        {
            get { return FGPendingID; }
            set { FGPendingID = value; }
        }
        private DateTime FromDate;

        public DateTime fromDate
        {
            get { return FromDate; }
            set { FromDate = value; }
        }

        private DateTime TODate;

        public DateTime toDate
        {
            get { return TODate; }
            set { TODate = value; }
        }

        private bool Active;

        public bool active
        {
            get { return Active; }
            set { Active = value; }
        }

        private int GroupID;

        public int groupID
        {
            get { return GroupID; }
            set { GroupID = value; }
        }

        private int Is3or6days;

        public int is3or6Days
        {
            get { return Is3or6days; }
            set { Is3or6days = value; }
        }
        private SqlTransaction Trans;
        public SqlTransaction trans
        {
            get { return Trans; }
            set { Trans = value; }
        }

        private DateTime Days3FG;

        public DateTime days3FG
        {
            get { return Days3FG; }
            set { Days3FG = value; }
        }

        private DateTime Days6FG;

        public DateTime days6FG
        {
            get { return Days6FG; }
            set { Days6FG = value; }
        }


        
	
        #endregion

        #region Functions

        public long Insert_FGPending()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, fromDate);
                param[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, toDate);
                param[2] = ModHelper.CreateParameter("@Active", SqlDbType.Bit, 1, ParameterDirection.Input, active);
                return Convert.ToInt64(SqlHelper.ExecuteScalar(trans, CommandType.StoredProcedure, "STP_Insert_tblFGPending", param));
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
        public void Insert_FGPendingGroupRelation()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = ModHelper.CreateParameter("@FGPendingID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgPendingID);
                param[1] = ModHelper.CreateParameter("@GroupID", SqlDbType.Int, 4, ParameterDirection.Input, groupID);
                param[2] = ModHelper.CreateParameter("@Is3daysor6days", SqlDbType.Int, 4, ParameterDirection.Input, is3or6Days);
                SqlHelper.ExecuteNonQuery(trans,CommandType.StoredProcedure, "STP_Insert_tblFGPendingGroupRelation", param);
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public void Delete_FGPendingGroupRelation()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@FGPendingID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgPendingID);
                SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "STP_Delete_FGPendingGroupRelation", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_FGPending()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_FGPending");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_FGPendingGroupRelation()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@FGPendingID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgPendingID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_FGPendingGroupRelation",param);
                return ds;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public bool Insert_FGPending3DaysOr6Days()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = ModHelper.CreateParameter("@Days3Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, days3FG);
                param[1] = ModHelper.CreateParameter("@Days6Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, days6FG);
                param[2] = ModHelper.CreateParameter("@FGPendingID", SqlDbType.BigInt, 1, ParameterDirection.Input, fgPendingID);
                SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "STP_Insert_tblFGPending3DaysOr6Days", param);
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
