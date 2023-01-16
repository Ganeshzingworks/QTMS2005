using System;
using System.Collections.Generic;
using System.Text;
using DataFacade;
using System.Data;
using System.Data.SqlClient;

namespace BusinessFacade.Transactions
{
    public class RMValidityReport_Class
    {
        #region Variables
        private int LoginID;
        private string FromDate;
        private string ToDate;
        private long RMTransID;
        private long RMPhyMethodNo;
        private string NormsReading;
        private long RMSamplingID;
        private long RemainingQuantity;
        private long RMPresMethodNo;
        private string ValidityDate;
        private char Status;
        #endregion

        #region Properties

        public char status
        {
            get { return Status; }
            set { Status = value; }
        }


        public int loginid
        {
            get { return LoginID; }
            set { LoginID = value; }
        }


        public string fromdate
        {
            get { return FromDate; }
            set { FromDate = value; }
        }

        public string todate
        {
            get { return ToDate; }
            set { ToDate = value; }
        }

        public string validitydate
        {
            get { return ValidityDate; }
            set { ValidityDate = value; }
        }


        public long rmtransid
        {
            get { return RMTransID; }
            set { RMTransID = value; }
        }

        public long rmpresmethodno
        {
            get { return RMPresMethodNo; }
            set { RMPresMethodNo = value; }
        }


        public long remainingquantity
        {
            get { return RemainingQuantity; }
            set { RemainingQuantity = value; }
        }

        public long rmsamplingid
        {
            get { return RMSamplingID; }
            set { RMSamplingID = value; }
        }

        public long rmphymethodno
        {
            get { return RMPhyMethodNo; }
            set { RMPhyMethodNo = value; }
        }

       
        public string normsreading
        {
            get { return NormsReading; }
            set { NormsReading = value; }
        }

        #endregion

        #region Functions

        public DataSet Select_RMDetails_RMCodeMaster_InspDate()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, FromDate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, ToDate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMDetails_tblRMCodeMaster_InspDate_ValidityReport", myparam);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_RMSampling_RMSupplierMaster_RMDetails_RMStatus_RMTransaction_RMSamplingID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMSamplingID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMSamplingID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMSampling_tblRMSupplierMaster_tblRMDetails_tblRMStatus_tblRMTransaction_RMSamplingID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_RMTransaction_RMSamplingID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMSamplingID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMSamplingID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMTransaction_RMSamplingID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_Tests_ForReducedControlIdentification()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMSamplingID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMSamplingID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMPhysicochemicalTestMethodMaster_tblTestMaster_RMTransID_Reduced_Id", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_Tests_ForReducedControlControl()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMSamplingID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMSamplingID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMPhysicochemicalTestMethodMaster_tblTestMaster_RMTransID_Reduced_Con", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_Tests_ForFullControlId()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMSamplingID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMSamplingID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMPhysicochemicalTestMethodMaster_tblTestMaster_RMTransID_Full_Id", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_Tests_ForFullControlCon()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMSamplingID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMSamplingID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMPhysicochemicalTestMethodMaster_tblTestMaster_RMTransID_Full_Con", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet Select_Tests_ForFullControlAnalysis()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMSamplingID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMSamplingID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMPreservativeMethodMaster_tblPreservativeMaster_RMTransID_Full_Analysis", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long  Insert_RMTransaction()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[5];
                myparam[0] = ModHelper.CreateParameter("@RMSamplingID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMSamplingID);
                myparam[1] = ModHelper.CreateParameter("@ValidityDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, ValidityDate);
                myparam[2] = ModHelper.CreateParameter("@RemainingQuantity", SqlDbType.BigInt, 8, ParameterDirection.Input, RemainingQuantity);
                myparam[3] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
                myparam[4] = ModHelper.CreateParameter("@RMTransID", SqlDbType.BigInt, 8, ParameterDirection.Output);
                
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblRMTransaction_ValidityReport", myparam);
                RMTransID = Convert.ToInt64(myparam[4].Value);

                return RMTransID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert_RMPhysicochemicalTestMethodDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@RMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMTransID);
                myparam[1] = ModHelper.CreateParameter("@RMPhyMethodNo", SqlDbType.BigInt, 8, ParameterDirection.Input, RMPhyMethodNo);
                myparam[2] = ModHelper.CreateParameter("@NormsReading", SqlDbType.VarChar, 50,ParameterDirection.Input, NormsReading);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblRMPhysicochemicalTestMethodDetails", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert_RMStatus()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@RMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMTransID);
                myparam[1] = ModHelper.CreateParameter("@Status", SqlDbType.Char ,1, ParameterDirection.Input,status);
                
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblRMStatus_ValidityReport", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert_RMPreservativeMethodDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@RMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMTransID);
                myparam[1] = ModHelper.CreateParameter("@RMPresMethodNo", SqlDbType.BigInt, 8, ParameterDirection.Input, RMPresMethodNo);
                myparam[2] = ModHelper.CreateParameter("@NormsReading", SqlDbType.VarChar, 50, ParameterDirection.Input, NormsReading);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblRMPreservativeMethodDetails", myparam);
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
