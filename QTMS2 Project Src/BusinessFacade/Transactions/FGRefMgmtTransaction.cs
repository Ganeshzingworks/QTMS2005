using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;

namespace BusinessFacade.Transactions
{
    public class FGRefMgmtTransaction
    {
        #region Variables & Properties
        private long FGTLFID;

        public long fgtlfid
        {
            get { return FGTLFID; }
            set { FGTLFID = value; }
        }
        private long FGNOFG;

        public long fgnofg
        {
            get { return FGNOFG; }
            set { FGNOFG = value; }
        }
        private long FGNo;

        public long fgno
        {
            get { return FGNo; }
            set { FGNo = value; }
        }
        private DateTime TrackCodeDate;

        public DateTime trackCodeDate
        {
            get { return TrackCodeDate; }
            set { TrackCodeDate = value; }
        }

        private DateTime ValidityDate;

        public DateTime validityDate
        {
            get { return ValidityDate; }
            set { ValidityDate = value; }
        }
        private long FNo;

        public long fno
        {
            get { return FNo; }
            set { FNo = value; }
        }

        #endregion

        #region Functions

        public bool Insert_FGRefMgmtTransaction()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                param[1] = ModHelper.CreateParameter("@TrackCodeDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, trackCodeDate);
                param[2] = ModHelper.CreateParameter("@ValidityDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, validityDate);
                int i = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblFGRefMgmtTransaction", param);
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

        public bool Insert_FGRefMgmtTransactionFGCode()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                param[1] = ModHelper.CreateParameter("@TrackCodeDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, trackCodeDate);
                param[2] = ModHelper.CreateParameter("@ValidityDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, validityDate);
                int i = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblFGRefMgmtTransactionFGCode", param);
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
        public DataTable Select_FGRefMgmtTransaction()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblFGRefMgmtTransaction_FGTLFID", param).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Select_FGNO_FGTLFID_FGRegMgt()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                param[1] = ModHelper.CreateParameter("@FGNOFG", SqlDbType.BigInt, 8, ParameterDirection.Output);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Select_FGNO_FGTLFID_FGRefMgt", param);
                return Convert.ToInt64(param[1].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_FGRefMgmtTransactionFGCode()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblFGRefMgmtTransactionFGCode", param).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_FGRefMgmtTransactionFGCode_Details()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblFGRefMgmtTransactionFGCode_Details", param).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_Type_FGTLFID_Fno()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[2];
                param[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                param[1] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_Type_FGTLFID_Fno", param).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        #endregion
    }
}
