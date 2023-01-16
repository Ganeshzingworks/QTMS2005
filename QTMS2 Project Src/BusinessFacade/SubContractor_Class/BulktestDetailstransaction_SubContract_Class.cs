using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DataFacade;

namespace BusinessFacade.SubContractor_Class
{
    public class BulktestDetailstransaction_SubContract_Class
    {
        #region Varibles

        private int LoginID;
        private long BulkNo;
        private string FormulaName;
        private long FormulaNo;
        private long FNo;
        private string Mfgwo = "";
        private long FMID;
        private string FormulaType = "";
        private string DecisionDate = "";
        private string Supplier = "";
        private long supplierId;
        private int NoBatches = 0;
        private int BatchSize = 0;
        private char FlagRL;
        private char BPCNONBPC;
        private string NonBPCcmts = "";
        private char Status;
        private string Comments = "";
        private string Reading;
        private string InitialValue;
        private string FinalValue;
        private long BulkMethodNo;
        private long SubContract;
        private int InspectedBy;
        private string NormsMin;
        private string NormsMax;
        private string MicroNorms;
        private long _FGSupplierId;
        private long _ManufacturedById;
        private string InspDate;
        private string ValidDate;

        /*private char SQPIF;
        private char LotValidation;
       
        private char TestClear;       
        private string TransId = "";
        private int TankNO;
        private char FA;
        private string FromDate;
        private string ToDate;       
        private string StartedOn;
        private string CompletedOn;
        private string ExtLabReportNo;      
        private bool DWP;
        */
        #endregion

        #region Properties

        public string micronorms
        {
            get { return MicroNorms; }
            set { MicroNorms = value; }
        }

        public long SupplierId
        {
            get { return supplierId; }
            set { supplierId = value; }
        }

        public long FGSupplierId
        {
            get { return _FGSupplierId; }
            set { _FGSupplierId = value; }
        }

        public long ManufacturedById
        {
            get { return _ManufacturedById; }
            set { _ManufacturedById = value; }
        }

        /*public string extlabreportno
        {
            get { return ExtLabReportNo; }
            set { ExtLabReportNo = value; }
        }
        public string completedon
        {
            get { return CompletedOn; }
            set { CompletedOn = value; }
        }
        public string startedon
        {
            get { return StartedOn; }
            set { StartedOn = value; }
        }*/
        public int inspectedby
        {
            get { return InspectedBy; }
            set { InspectedBy = value; }
        }
        public int loginid
        {
            get { return LoginID; }
            set { LoginID = value; }
        }

        public string formulaname
        {
            get { return FormulaName; }
            set { FormulaName = value; }
        }
        public long bulkno
        {
            get { return BulkNo; }
            set { BulkNo = value; }
        }
        public long formulano
        {
            get { return FormulaNo; }
            set { FormulaNo = value; }
        }
        public long fno
        {
            get { return FNo; }
            set { FNo = value; }
        }
        public long fmid
        {
            get { return FMID; }
            set { FMID = value; }
        }

        public long subcontract
        {
            get { return SubContract; }
            set { SubContract = value; }
        }

        public string mfgwo
        {
            get { return Mfgwo; }
            set { Mfgwo = value; }
        }
        public string formulatype
        {
            get { return FormulaType; }
            set { FormulaType = value; }
        }
         public string Inspdate
         {
             get { return InspDate; }
             set { InspDate = value; }
         }
         /*public string mfgdate
         {
             get { return MfgDate; }
             set { MfgDate = value; }
         }
         public char fa
         {
             get { return FA; }
             set { FA = value; }
         }
         public string Inspdate_to
         {
             get { return InspDate_TO; }
             set { InspDate_TO = value; }
         }
         public int vesselno
         {
             get { return VesselNo; }
             set { VesselNo = value; }
         }*/
        public int noofbatches
        {
            get { return NoBatches; }
            set { NoBatches = value; }
        }
        public int batchsize
        {
            get { return BatchSize; }
            set { BatchSize = value; }
        }
        /*public int tankno
        {
            get { return TankNO; }
            set { TankNO = value; }
        }
        public string density
        {
            get { return Density; }
            set { Density = value; }
        }
        public string serialno
        {
            get { return SerialNo; }
            set { SerialNo = value; }
        }*/
        public char flagrl
        {
            get { return FlagRL; }
            set { FlagRL = value; }
        }
        public string validdate
        {
            get { return ValidDate; }
            set { ValidDate = value; }
        }
        /*public char sqpif
        {
            get { return SQPIF; }
            set { SQPIF = value; }
        }
        public char lotvalidation
        {
            get { return LotValidation; }
            set { LotValidation = value; }
        }
       
        public char testclear
        {
            get { return TestClear; }
            set { TestClear = value; }
        }*/
        public char bpcnonbpc
        {
            get { return BPCNONBPC; }
            set { BPCNONBPC = value; }
        }
        public string nonbpccomment
        {
            get { return NonBPCcmts; }
            set { NonBPCcmts = value; }
        }
        public char status
        {
            get { return Status; }
            set { Status = value; }
        }
        public string comments
        {
            get { return Comments; }
            set { Comments = value; }
        }
        /* public string transid
         {
             get { return TransId; }
             set { TransId = value; }
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
         public string supplier
         {
             get { return Supplier; }
             set { Supplier = value; }
         }
         */

        public string reading
        {
            get { return Reading; }
            set { Reading = value; }
        }
        public string initialvalue
        {
            get { return InitialValue; }
            set { InitialValue = value; }
        }
        public string finalvalue
        {
            get { return FinalValue; }
            set { FinalValue = value; }
        }
        public long bulkmethodno
        {
            get { return BulkMethodNo; }
            set { BulkMethodNo = value; }
        }
        public string normmin
        {
            get { return NormsMin; }
            set { NormsMin = value; }
        }
        public string normmax
        {
            get { return NormsMax; }
            set { NormsMax = value; }
        }

        #endregion

        #region Functions

        public long SELECT_tblTransFM_FNo_MfgWo_SubContract()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[1] = ModHelper.CreateParameter("@MfgWo", SqlDbType.NVarChar, 200, ParameterDirection.Input, mfgwo);
                myparam[2] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Output, fmid);
                SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_SELECT_tblTransFM_FNo_MfgWo_SubContractor", myparam);
                if (myparam[2].Value is DBNull)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt64(myparam[2].Value);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long INSERT_tblTransFM_FNo_MfgWo_SubContract()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[1] = ModHelper.CreateParameter("@MfgWo", SqlDbType.NVarChar, 200, ParameterDirection.Input, mfgwo);
                myparam[2] = ModHelper.CreateParameter("@SubContract", SqlDbType.Int, 1, ParameterDirection.Input, subcontract);
                myparam[3] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Output, fmid);
                SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_Insert_tblTransFM_FNo_MfgWo_SubContract", myparam);
                return Convert.ToInt64(myparam[3].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblBulkTestTransaction_FMID_SubContract()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblBulkTestTransaction_FMID_SubContractor", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update_tblBulkTestDetailstransaction_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[16];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 200, ParameterDirection.Input, fmid);
                myparam[1] = ModHelper.CreateParameter("@FormulaType", SqlDbType.VarChar, 50, ParameterDirection.Input, formulatype);                
                myparam[2] = ModHelper.CreateParameter("@InspDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, Inspdate);                
                myparam[3] = ModHelper.CreateParameter("@NoBatches", SqlDbType.Int, 4, ParameterDirection.Input, NoBatches);
                myparam[4] = ModHelper.CreateParameter("@BatchSize", SqlDbType.Int, 4, ParameterDirection.Input, batchsize);
                myparam[5] = ModHelper.CreateParameter("@MfgWoNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, mfgwo);
                myparam[6] = ModHelper.CreateParameter("@FlagRL", SqlDbType.Char, 1, ParameterDirection.Input, flagrl);               
                myparam[7] = ModHelper.CreateParameter("@ValidDate", SqlDbType.SmallDateTime, 8, ParameterDirection.Input, validdate);
                myparam[8] = ModHelper.CreateParameter("@BPCNONBPC", SqlDbType.Char, 1, ParameterDirection.Input, bpcnonbpc);
                myparam[9] = ModHelper.CreateParameter("@NonBPCcmts", SqlDbType.NVarChar, 250, ParameterDirection.Input, nonbpccomment);
                myparam[10] = ModHelper.CreateParameter("@Status", SqlDbType.Char, 1, ParameterDirection.Input, status);
                myparam[11] = ModHelper.CreateParameter("@Comments", SqlDbType.NVarChar, 250, ParameterDirection.Input, comments);
                myparam[12] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
                myparam[13] = ModHelper.CreateParameter("@InspectedBy", SqlDbType.Int, 4, ParameterDirection.Input, inspectedby);
                myparam[14] = ModHelper.CreateParameter("@BulkNo", SqlDbType.BigInt, 8, ParameterDirection.Input, bulkno);             
                myparam[15] = ModHelper.CreateParameter("@FGSupplierId", SqlDbType.Int, 8, ParameterDirection.Input, FGSupplierId);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_UPDATE_tblBulkTestTrans_SubContractor", myparam);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public long Insert_tblBulkTestDetailstransaction_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[16];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 200, ParameterDirection.Input, fmid);
                myparam[1] = ModHelper.CreateParameter("@FormulaType", SqlDbType.VarChar, 50, ParameterDirection.Input, formulatype);
                myparam[2] = ModHelper.CreateParameter("@InspDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, Inspdate);
                myparam[3] = ModHelper.CreateParameter("@NoBatches", SqlDbType.Int, 4, ParameterDirection.Input, NoBatches);
                myparam[4] = ModHelper.CreateParameter("@BatchSize", SqlDbType.Int, 4, ParameterDirection.Input, batchsize);
                myparam[5] = ModHelper.CreateParameter("@MfgWoNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, mfgwo);
                myparam[6] = ModHelper.CreateParameter("@FlagRL", SqlDbType.Char, 1, ParameterDirection.Input, flagrl);
                myparam[7] = ModHelper.CreateParameter("@ValidDate", SqlDbType.SmallDateTime, 8, ParameterDirection.Input, validdate);
                myparam[8] = ModHelper.CreateParameter("@BPCNONBPC", SqlDbType.Char, 1, ParameterDirection.Input, bpcnonbpc);
                myparam[9] = ModHelper.CreateParameter("@NonBPCcmts", SqlDbType.NVarChar, 250, ParameterDirection.Input, nonbpccomment);
                myparam[10] = ModHelper.CreateParameter("@Status", SqlDbType.Char, 1, ParameterDirection.Input, status);
                myparam[11] = ModHelper.CreateParameter("@Comments", SqlDbType.NVarChar, 250, ParameterDirection.Input, comments);
                myparam[12] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
                myparam[13] = ModHelper.CreateParameter("@InspectedBy", SqlDbType.Int, 4, ParameterDirection.Input, inspectedby);              
                myparam[14] = ModHelper.CreateParameter("@FGSupplierId", SqlDbType.Int, 8, ParameterDirection.Input, FGSupplierId);
                myparam[15] = ModHelper.CreateParameter("@BulkNo", SqlDbType.BigInt, 8, ParameterDirection.Output);
               
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_INSERT_tblBulktesttrans_SubContractor", myparam);
                bulkno = Convert.ToInt64(myparam[15].Value);
                return bulkno;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool Delete_tblBulkPhysicochemicalTestMethodDetails_FMID_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblBulkPhysicochemicalTestMethodDetails_FMID_SubContract", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool INSERT_tblBulkPhysicochemicalTestMethodDetails_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[7];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                myparam[1] = ModHelper.CreateParameter("@BulkMethodNo", SqlDbType.BigInt, 8, ParameterDirection.Input, bulkmethodno);
                myparam[2] = ModHelper.CreateParameter("@NormsReading", SqlDbType.VarChar, 50, ParameterDirection.Input, reading);
                myparam[3] = ModHelper.CreateParameter("@InitialValue", SqlDbType.VarChar, 50, ParameterDirection.Input, initialvalue);
                myparam[4] = ModHelper.CreateParameter("@FinalValue", SqlDbType.VarChar, 50, ParameterDirection.Input, finalvalue);
                myparam[5] = ModHelper.CreateParameter("@NormsMin", SqlDbType.VarChar, 50, ParameterDirection.Input, normmin);// newly added at transaction level for save norms
                myparam[6] = ModHelper.CreateParameter("@NormsMax", SqlDbType.VarChar, 50, ParameterDirection.Input, normmax);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_INSERT_tblBulkPhysicochemicalTestMethodDetails_SubContract", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblBulkTestTransaction_FNo_MfgWo_SubContract()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[1] = ModHelper.CreateParameter("@MfgWo", SqlDbType.NVarChar, 200, ParameterDirection.Input, mfgwo);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblBulkTestTransaction_FNo_MfgWo_SubContract", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Select_tblBulktesttransaction_NoBatches_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[1] = ModHelper.CreateParameter("@Result", SqlDbType.BigInt, 8, ParameterDirection.Output);
                SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_tblBulktesttransaction_NoBatches_SubContract", myparam);
                if (myparam[1].Value is DBNull)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt64(myparam[1].Value);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblBulkPhysicochemicalTestMethodDetails_SubContract()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[1] = ModHelper.CreateParameter("@MfgWo", SqlDbType.NVarChar, 200, ParameterDirection.Input, mfgwo);
                myparam[2] = ModHelper.CreateParameter("@BulkMethodNo", SqlDbType.BigInt, 8, ParameterDirection.Input, bulkmethodno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblBulkPhysicochemicalTestMethodDetails_SubContract", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_BulkTestDetail_ProtocolNo_SubContract()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_BulkTestDetail_ProtocolNo_SubContract", myparam);
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
