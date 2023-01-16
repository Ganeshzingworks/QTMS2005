using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DataFacade;

namespace BusinessFacade.Transactions
{
    public class BMRReport_Class
    {
        private long FMID;
        public long fmid
        {
            get { return FMID; }
            set { FMID = value; }
        }
        private char Status;
        public char status
        {
            get { return Status; }
            set { Status = value; }
        }
        private string Comment;
        public string comment
        {
            get { return Comment; }
            set { Comment = value; }
        }
        private int InspectedBy;
        public int inspectedby
        {
            get { return InspectedBy; }
            set { InspectedBy = value; }
        }

        public DataSet Select_tblBMRReport_FMID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblBMRReport_FMID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert_tblBMRReport()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                myparam[1] = ModHelper.CreateParameter("@Status", SqlDbType.Char, 1, ParameterDirection.Input, status);
                myparam[2] = ModHelper.CreateParameter("@Comment", SqlDbType.NVarChar, 250, ParameterDirection.Input, comment);
                myparam[3] = ModHelper.CreateParameter("@InspectedBy", SqlDbType.Int, 4, ParameterDirection.Input, inspectedby);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblBMRReport", myparam);                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update_tblBMRReport()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                myparam[1] = ModHelper.CreateParameter("@Status", SqlDbType.Char, 1, ParameterDirection.Input, status);
                myparam[2] = ModHelper.CreateParameter("@Comment", SqlDbType.NVarChar, 250, ParameterDirection.Input, comment);
                myparam[3] = ModHelper.CreateParameter("@InspectedBy", SqlDbType.Int, 4, ParameterDirection.Input, inspectedby);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblBMRReport", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
