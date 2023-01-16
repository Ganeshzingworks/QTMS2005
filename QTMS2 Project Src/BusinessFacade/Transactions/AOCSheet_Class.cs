using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;

namespace BusinessFacade.Transactions
{

    public class AOCSheet_Class
    {
        #region Properties

        private long FGNo;

        public long fgno
        {
            get { return FGNo; }
            set { FGNo = value; }
        }

        private long FNo;
        public long fno
        {
            get { return FNo; }
            set { FNo = value; }
        }

        private long FMID;

        public long fmid
        {
            get { return FMID; }
            set { FMID = value; }
        }

        private string RequestDate;

        public string requestDate
        {
            get { return RequestDate; }
            set { RequestDate = value; }
        }

        //
        private string ClearenceDate;

        public string clearenceDate
        {
            get { return ClearenceDate; }
            set { ClearenceDate = value; }
        }
        //
        private string CommersializeAuthorisation;

        public string comAuthorisation
        {
            get { return CommersializeAuthorisation; }
            set { CommersializeAuthorisation = value; }
        }

        private int LoginID;

        public int loginid
        {
            get { return LoginID; }
            set { LoginID = value; }
        }

        #endregion

        #region Function
        public DataSet Select_tblTransFM_FNo_GetMfgWo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblTransFM_FNo_GetMfgWo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert_tblAOCSheet()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[7];
                param[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                param[1] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                param[2] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                param[3] = ModHelper.CreateParameter("@RequestDate", SqlDbType.SmallDateTime, 8, ParameterDirection.Input, requestDate);
                param[4] = ModHelper.CreateParameter("@ClearenceDate", SqlDbType.SmallDateTime, 8, ParameterDirection.Input, clearenceDate);
                param[5] = ModHelper.CreateParameter("@CommersializeAuthorisation", SqlDbType.NVarChar, 150, ParameterDirection.Input, comAuthorisation);
                param[6] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblAOCSheet", param);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool Update_tblAOCSheet()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[7];
                param[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                param[1] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                param[2] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                param[3] = ModHelper.CreateParameter("@RequestDate", SqlDbType.SmallDateTime, 8, ParameterDirection.Input, requestDate);
                param[4] = ModHelper.CreateParameter("@ClearenceDate", SqlDbType.SmallDateTime, 8, ParameterDirection.Input, clearenceDate);
                param[5] = ModHelper.CreateParameter("@CommersializeAuthorisation", SqlDbType.NVarChar, 150, ParameterDirection.Input, comAuthorisation);
                param[6] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblAOCSheet", param);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblAOCSheet_FGNo_FNo_FMID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[3];
                param[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                param[1] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                param[2] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblAOCSheet_FGNo_FNo_FMID", param);
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
