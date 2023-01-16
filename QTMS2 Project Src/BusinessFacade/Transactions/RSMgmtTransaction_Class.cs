using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;


namespace BusinessFacade.Transactions
{
    public class RSMgmtTransaction_Class
    {
        #region Variables
        private long FNo;

        public long fno
        {
            get { return FNo; }
            set { FNo = value; }
        }

        private string FormulaNo;

        public string formulano
        {
            get { return FormulaNo; }
            set { FormulaNo = value; }
        }

        private string MFGWO;

        public string mfgwo
        {
            get { return MFGWO; }
            set { MFGWO = value; }
        }

        private long CountryID;

        public long countryid
        {
            get { return CountryID; }
            set { CountryID = value; }
        }

        private DateTime ReceivingDate;

        public DateTime receivingdate
        {
            get { return ReceivingDate;; }
            set { ReceivingDate = value; }
        }

        private string PFLot;

        public string pflot
        {
            get { return PFLot; }
            set { PFLot = value; }
        }

        private DateTime ValidityDate;

        public DateTime validitydate
        {
            get { return ValidityDate; }
            set { ValidityDate = value; }
        }

        private long LocID;

        public long locid
        {
            get { return LocID; }
            set { LocID = value; }
        }

        private long RSID;

        public long rsid
        {
            get { return RSID; }
            set { RSID = value; }
        }

        private long FMID;

        public long fmid
        {
            get { return FMID; }
            set { FMID = value; }
        }

        private DateTime WSValidityDate;

        public DateTime wsvaliditydate
        {
            get { return WSValidityDate; }
            set { WSValidityDate = value; }
        }

        private long WSID;

        public long wsid
        {
            get { return WSID; }
            set { WSID = value; }
        }

        // Variables for Ref Sample Mgmt (RM)
        private long RMCodeID;

        public long rmcodeid
        {
            get { return RMCodeID; }
            set { RMCodeID = value; }
        }

        private int RMSamplingID;

        public int rmsamplingid
        {
            get { return RMSamplingID; }
            set { RMSamplingID = value; }
        }

        private long RMWSID;

        public long rmwsid
        {
            get { return RMWSID; }
            set { RMWSID = value; }
        }

        private int SupplierID;

        public int supplierid
        {
            get { return SupplierID; }
            set { SupplierID = value; }
        }
	
        private string SupplierName;

        public string suppliername
        {
            get { return SupplierName; }
            set { SupplierName = value; }
        }

        private SqlTransaction Trans;

        public SqlTransaction  trans
        {
            get { return Trans; }
            set { Trans = value; }
        }

          #endregion


        #region Functions
        SqlTransaction myTransaction = null;
        public DataSet select_TblBulkMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_TblBulkMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet select_tblBulkMaster_FNo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_TblBulkMaster_FNo", myparam);
                return ds;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public int Insert_tblRSDetails_tblRSFirstIndRun_fno()
        {
            try
            {

                SqlParameter[] param = new SqlParameter[8];
                param[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                param[1] = ModHelper.CreateParameter("@FormulaNo", SqlDbType.VarChar, 50, ParameterDirection.Input, formulano);
                param[2] = ModHelper.CreateParameter("@MfgWo", SqlDbType.VarChar, 50, ParameterDirection.Input, mfgwo);
                param[3] = ModHelper.CreateParameter("@CountryID", SqlDbType.BigInt, 8, ParameterDirection.Input, countryid);
                param[4] = ModHelper.CreateParameter("@ReceivingDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, receivingdate);
                param[5] = ModHelper.CreateParameter("@PFLot", SqlDbType.VarChar, 50, ParameterDirection.Input, pflot);
                param[6] = ModHelper.CreateParameter("@ValidityDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, validitydate);
                //param[7] = ModHelper.CreateParameter("@LocID", SqlDbType.BigInt, 8, ParameterDirection.Input, locid);
                param[7] = ModHelper.CreateParameter("@RSID", SqlDbType.BigInt, 8, ParameterDirection.Input, rsid);
                return Convert.ToInt32(SqlHelper.ExecuteScalar(trans,CommandType.StoredProcedure, "STP_Insert_tblRSDetails_tblRSFirstIndRun_fno", param));

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public bool Insert_tblRSWorkingStandardDetails()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = ModHelper.CreateParameter("@RSID", SqlDbType.BigInt, 8, ParameterDirection.Input, rsid);
                param[1] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                param[2] = ModHelper.CreateParameter("@ValidityDate", SqlDbType.SmallDateTime, 50, ParameterDirection.Input, wsvaliditydate);
                param[3] = ModHelper.CreateParameter("@CurrentFlag", SqlDbType.Bit, 1, ParameterDirection.Input, 1);
                param[4] = ModHelper.CreateParameter("@LocID", SqlDbType.BigInt, 8, ParameterDirection.Input, locid);
                SqlHelper.ExecuteNonQuery(trans,CommandType.StoredProcedure, "STP_Insert_tblRSWorkingStandardDetails", param);
                return true;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public DataSet Select_RSMgmtDetails_Fno()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_RSMgmtDetails", param);
                return ds;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public bool Delete_RSWorkingStanardDetails()
        {
            
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@WSID", SqlDbType.BigInt, 8, ParameterDirection.Input, wsid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblRSWorkingStandardDetails", param);
                return true;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        //Update reference date from reference sample management in validity date 
        public bool Update_tblBulkMaster_FNo()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                param[1] = ModHelper.CreateParameter("@ReferenceDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, validitydate);
                SqlHelper.ExecuteNonQuery(trans,CommandType.StoredProcedure, "STP_UPDATE_tblBulkMaster_FNo", param);
                return true;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        // Stored procedure for Reference sample management for RM
        public DataTable Select_tblRMCode_RMCodeID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmcodeid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMCode_RMCodeID", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_tblRMSampling_RMCodeID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmcodeid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMSampling_RMCodeID", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Select_tblRMDetails_RMSamplingID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMSamplingID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmsamplingid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMSampling_RMSamplingID", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert_tblRMRSWorkingStandardDetails()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = ModHelper.CreateParameter("@RMSamplingID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmsamplingid);
                param[1] = ModHelper.CreateParameter("@ValidityDate", SqlDbType.SmallDateTime, 50, ParameterDirection.Input, wsvaliditydate);
                param[2] = ModHelper.CreateParameter("@ActiveFlag", SqlDbType.Bit, 1, ParameterDirection.Input, 1);// It is used for Soft delete record 
                //param[3] = ModHelper.CreateParameter("@LocationID", SqlDbType.BigInt, 8, ParameterDirection.Input, locid);
                param[3] = ModHelper.CreateParameter("@RMSupplierID", SqlDbType.BigInt, 8, ParameterDirection.Input, supplierid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblRMRSWorkingStandardDetails", param);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete_RMRSWorkingStanardDetails()
        {

            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@RMWSID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmwsid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblRMRSWorkingStandardDetails", param);
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataTable Select_RMRSMgmtDetails_RMCodeID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmcodeid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_RMRefSampleMgmtDetails", param);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion
    }
}
