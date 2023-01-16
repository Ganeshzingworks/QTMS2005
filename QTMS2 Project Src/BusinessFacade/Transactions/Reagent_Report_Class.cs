using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataFacade;
using System.Data.SqlClient;

namespace BusinessFacade.Transactions
{
   
   public  class Reagent_Report_Class
    {
        #region Variable
        private long ReagentID;

        #endregion

        #region Properties
        public long reagentid
        {
            get { return ReagentID; }
            set { ReagentID = value; }
        }
        #endregion

        private string FromDate;
        public string fromdate
        {
            get { return FromDate; }
            set { FromDate = value; }
        }
        private string ToDate;
        public string todate
        {
            get { return ToDate; }
            set { ToDate = value; }
        }

        #region Functions

       
        public System.Data.DataSet GenerateReagentStockReport()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@ReagentID", SqlDbType.BigInt, 8, ParameterDirection.Input, reagentid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblReagentBottle_AvailableStock", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GenerateReagent_Details_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@ReagentID", SqlDbType.BigInt, 8, ParameterDirection.Input, reagentid);
                myparam[1] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[2] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_Reagent_Details", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       public DataSet SelectReorderLevel(double percentage)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@Percentage", SqlDbType.Float, 8, ParameterDirection.Input, percentage);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblReagentBottle_ReorderLevel", myparam);
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
