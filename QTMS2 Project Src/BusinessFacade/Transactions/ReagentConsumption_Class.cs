using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;

namespace BusinessFacade.Transactions
{
    public class ReagentConsumption_Class
    {
        #region Variables

        private long ReagentID;
        private long ReagentTransID;
        private long ReagentBottleID;
        private int LoginID;
        private long InspectedBy;
        #endregion

        #region Properties

        public long reagentid
        {
            get { return ReagentID; }
            set { ReagentID = value; }
        }
        public long reagenttransid
        {
            get { return ReagentTransID; }
            set { ReagentTransID = value; }
        }

        public long reagentbottleid
        {
            get { return ReagentBottleID; }
            set { ReagentBottleID = value; }
        }
        public int loginid
        {
            get { return LoginID; }
            set { LoginID = value; }
        }
        public long inspectedby
        {
            get { return InspectedBy; }
            set { InspectedBy = value; }
        }
        #endregion

        #region Functions


        public DataSet Select_RACode()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblReagentMAster_RACode");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_LotNo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@ReagentID", SqlDbType.BigInt, 8, ParameterDirection.Input, reagentid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblReagentTrans_LotNo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_StdBottleNos()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@ReagentTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, reagenttransid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblReagent_StdBottleNo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Update_tblReagentBottle_IsConsume my fun to do task
        /// </summary>
        /// <param name="consDate"></param>integer only
        /// <returns></returns>bool only
        public bool Update_tblReagentBottle_IsConsume()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[3];                
                myparam[0] = ModHelper.CreateParameter("@ReagentBottleID", SqlDbType.BigInt, 8, ParameterDirection.Input, reagentbottleid);                
                myparam[1] = ModHelper.CreateParameter("@ModifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
                myparam[2] = ModHelper.CreateParameter("@InspectedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, inspectedby);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Upadte_tblReagentBottle", myparam);
                return true;


                //SqlParameter[] myparam = new SqlParameter[4];
                //myparam[0] = ModHelper.CreateParameter("@ReagentTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, reagenttransid);
                //myparam[1] = ModHelper.CreateParameter("@ReagentBottleID", SqlDbType.Int, 250, ParameterDirection.Input, reagentbottleid);
                //myparam[2] = ModHelper.CreateParameter("@ConsumptionDate", SqlDbType.VarChar, 250, ParameterDirection.Input, consDate);
                //myparam[3] = ModHelper.CreateParameter("@ModifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, loginid);

                //SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Upadte_tblReagentBottle", myparam);
                //return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        public DataSet Select_ReceiveDate(long TransactionID)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@ReagentTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, TransactionID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblReagentTransaction_ReceiveDate", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_ConsumptionBottle()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@ReagentTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, reagenttransid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_ConsumptionBottle", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
