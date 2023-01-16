using System;
using System.Collections.Generic;
using System.Text;
using DataFacade;
using System.Data;
using System.Data.SqlClient;

namespace BusinessFacade.Transactions
{
    public class RMTransaction_Class
    {
        # region Varibles
        private int LoginID;
        private long LocationID;
        private long RMSamplingID;
        private long RemainingQuantity;
        private long RMPhyMethodNo;
        private long RMFDAPhyMethodNo;
        private long RMFDAPresMethodNo;
        private long RMPresMethodNo;
        private long RMTransID;
        private string NormsReading;
        private long RMCodeID;
        private string ReceiptDate;
        private string ChangeDate;
        private string InspDate;
        private string ValidityDate;
        private string SupplierLotNo;
        private string SpecificationNo;
        private string ChallanNo;
        private string MRR;
        private string ParaType;
        private char SRC;
        private char SRR;
        private char FirstRMReception;
        private char LabelForRetainer;
        private char Status;
        private char MethodType;
        private bool RMTransDone;
        private long RMSupplierID;
        private string PlantLotNo;
        private string QuantityReceived;
        private string QuantitySampled;
        private int ActualNoOfSegments;
        private int NoOfSegments;
        private bool IsValidityExpanded;
        private bool CurrentFlagTrans;
        private bool CurrentFlagStatus;
        private string TestType;
        private long RMPhyDetailNo;
        private long RMDetailID;
        private long StatusID;
        private string Comment;
        private long AcceptedQuantity;
        private string NonConReason;
        private string NormsMin;
        private string NormsMax;
        private string FromDate;
        private string ToDate;
        private string MicroStatus;
        private string ParaName;
        private string DescName;
        private string AgentName;
        private string AcceptedDate;
        private string SuppResult;
        private string IsAligned;
        private string Halal;
        private string PlantOrigin; 
        private string Countryoforigin;
        private Nullable<DateTime> ManufacturingDate;
        private string RejectDescription;
        private string TradeName;
        #endregion

        # region Properties
        public long locationID
        {
            get { return LocationID; }
            set { LocationID = value; }
        }

        public string accepteddate
        {
            get { return AcceptedDate; }
            set { AcceptedDate = value; }
        }

        public string suppresult
        {
            get { return SuppResult; }
            set { SuppResult = value; }
        }

        public string agentname
        {
            get { return AgentName; }
            set { AgentName = value; }
        }

        public string descname
        {
            get { return DescName; }
            set { DescName = value; }
        }

        public string paraname
        {
            get { return ParaName; }
            set { ParaName = value; }
        }

        public string microstatus
        {
            get { return MicroStatus; }
            set { MicroStatus = value; }
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

        public long acceptedquantity
        {
            get { return AcceptedQuantity; }
            set { AcceptedQuantity = value; }
        }
        public string nonconreason
        {
            get { return NonConReason; }
            set { NonConReason = value; }
        }
        public string comment
        {
            get { return Comment; }
            set { Comment = value; }
        }
        public long rmdetailid
        {
            get { return RMDetailID; }
            set { RMDetailID = value; }
        }
        public long statusid
        {
            get { return StatusID; }
            set { StatusID = value; }
        }
        public long rmphydetailno
        {
            get { return RMPhyDetailNo; }
            set { RMPhyDetailNo = value; }
        }
        public string testtype
        {
            get { return TestType; }
            set { TestType = value; }
        }
        public bool currentflagtrans
        {
            get { return CurrentFlagTrans; }
            set { CurrentFlagTrans = value; }
        }
        public bool currentflagstatus
        {
            get { return CurrentFlagStatus; }
            set { CurrentFlagStatus = value; }
        }
        public long rmsupplierid
        {
            get { return RMSupplierID; }
            set { RMSupplierID = value; }
        }
        public string plantlotno
        {
            get { return PlantLotNo; }
            set { PlantLotNo = value; }
        }
        public string quantityreceived
        {
            get { return QuantityReceived; }
            set { QuantityReceived = value; }
        }
        public string quantitysampled
        {
            get { return QuantitySampled; }
            set { QuantitySampled = value; }
        }
        public int actualnoofsegments
        {
            get { return ActualNoOfSegments; }
            set { ActualNoOfSegments = value; }
        }
        public int noofsegments
        {
            get { return NoOfSegments; }
            set { NoOfSegments = value; }
        }
        public int loginid
        {
            get { return LoginID; }
            set { LoginID = value; }
        }
        public long rmsamplingid
        {
            get { return RMSamplingID; }
            set { RMSamplingID = value; }
        }
        public long rmfdaphymethodno
        {
            get { return RMFDAPhyMethodNo; }
            set { RMFDAPhyMethodNo = value; }
        }
        public long rmfdapresmethodno
        {
            get { return RMFDAPresMethodNo; }
            set { RMFDAPresMethodNo = value; }
        }
        public long remainingquantity
        {
            get { return RemainingQuantity; }
            set { RemainingQuantity = value; }
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
        public long rmphymethodno
        {
            get { return RMPhyMethodNo; }
            set { RMPhyMethodNo = value; }
        }
        public bool rmtransdone
        {
            get { return RMTransDone; }
            set { RMTransDone = value; }
        }
        public bool isvalidityexpanded
        {
            get { return IsValidityExpanded; }
            set { IsValidityExpanded = value; }
        }
        public long rmcodeid
        {
            get { return RMCodeID; }
            set { RMCodeID = value; }
        }
        public string normsreading
        {
            get { return NormsReading; }
            set { NormsReading = value; }
        }
        public string normsmax
        {
            get { return NormsMax; }
            set { NormsMax = value; }
        }
        public string normsmin
        {
            get { return NormsMin; }
            set { NormsMin = value; }
        }
        public string receiptdate
        {
            get { return ReceiptDate; }
            set { ReceiptDate = value; }
        }
        public string paratype
        {
            get { return ParaType; }
            set { ParaType = value; }
        }
        public string changedate
        {
            get { return ChangeDate; }
            set { ChangeDate = value; }
        }
        public string inspdate
        {
            get { return InspDate; }
            set { InspDate = value; }
        }
        public string validitydate
        {
            get { return ValidityDate; }
            set { ValidityDate = value; }
        }
        public string supplierlotno
        {
            get { return SupplierLotNo; }
            set { SupplierLotNo = value; }
        }
        public string specificationno
        {
            get { return SpecificationNo; }
            set { SpecificationNo = value; }
        }
        public string challanno
        {
            get { return ChallanNo; }
            set { ChallanNo = value; }
        }
        public string mrr
        {
            get { return MRR; }
            set { MRR = value; }
        }
        public char src
        {
            get { return SRC; }
            set { SRC = value; }
        }
        public char methodtype
        {
            get { return MethodType; }
            set { MethodType = value; }
        }
        public char srr
        {
            get { return SRR; }
            set { SRR = value; }
        }
        public char firstrmreception
        {
            get { return FirstRMReception; }
            set { FirstRMReception = value; }
        }
        public char labelforretainer
        {
            get { return LabelForRetainer; }
            set { LabelForRetainer = value; }
        }
        public char status
        {
            get { return Status; }
            set { Status = value; }
        }

        public Nullable<DateTime> mfgDate
        {
            get { return ManufacturingDate; }
            set { ManufacturingDate = value; }
        }
        public string isAligned
        {
            get { return IsAligned; }
            set { IsAligned = value; }

        }

        public string halal  
        {
            get { return Halal; }
            set { Halal = value; }

        }

        public string plantOrigin  
        {
            get { return PlantOrigin; }
            set { PlantOrigin = value; }

        }

        public string countryoforigin  
        {
            get { return Countryoforigin; }
            set { Countryoforigin = value; }

        }

        private bool SubContract;
        public bool subContract
        {
            get { return SubContract; }
            set { SubContract = value;}
        }
        public string rejectdescription
        {
            get { return RejectDescription; }
            set { RejectDescription = value; }
        }
        public string tradename
        {
            get { return TradeName; }
            set { TradeName = value; }
        }
        #endregion

        #region Functions

        public DataSet Select_RMTransactionDone()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_RMTransactionDone");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_PendingRMTransaction()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_PendingRMTransaction");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public DataSet Select_RMPhysicochemicalTestMethodMaster_RMCodeID()
        //{
        //    try
        //    {
        //        DataSet ds = new DataSet();
        //        SqlParameter[] myparam = new SqlParameter[3];
        //        myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmcodeid);             
        //        ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMPhysicochemicalTestMethodMaster_RMCodeID", myparam);
        //        return ds;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public DataSet Select_FullControlTestingDone_tblRMSampling()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmcodeid);
                myparam[1] = ModHelper.CreateParameter("@RMSupplierID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmsupplierid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_FullControlTestingDone_tblRMSampling", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblRMPhysicochemicalTestMethodMaster_RMCodeID_TestType()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmcodeid);
                myparam[1] = ModHelper.CreateParameter("@TestType", SqlDbType.NVarChar, 50, ParameterDirection.Input, testtype);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMPhysicochemicalTestMethodMaster_RMCodeID_TestType", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblRMPhysicochemicalTestMethodDetails_MethodType_TestType()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[6];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmcodeid);
                myparam[1] = ModHelper.CreateParameter("@MethodType", SqlDbType.Char, 1, ParameterDirection.Input, methodtype);
                myparam[2] = ModHelper.CreateParameter("@TestType", SqlDbType.NVarChar, 50, ParameterDirection.Input, testtype);
                myparam[3] = ModHelper.CreateParameter("@RMSupplierID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmsupplierid);
                myparam[4] = ModHelper.CreateParameter("@PlantLotNo", SqlDbType.VarChar, 250, ParameterDirection.Input, plantlotno);
                myparam[5] = ModHelper.CreateParameter("@IsValidityExpanded", SqlDbType.Bit, 1, ParameterDirection.Input, isvalidityexpanded);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMPhysicochemicalTestMethodDetails_MethodType_TestType", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_RMPhysicochemicalTestMethodMaster_RMSampling_ReducedCon_RMCodeID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmcodeid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMPhysicochemicalTestMethodMaster_tblRMSampling__ReducedCon_RMCodeID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_RMPhysicochemicalTestMethodMaster_RMSampling_FullControlID_RMCodeID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmcodeid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMPhysicochemicalTestMethodMaster_tblRMSampling__FullControlID_RMCodeID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_RMPhysicochemicalTestMethodMaster_RMSampling_FullControlCon_RMCodeID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmcodeid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMPhysicochemicalTestMethodMaster_tblRMSampling__FullControlCon_RMCodeID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblRMPhysicochemicalTestMethodDetails_RMTransID_RMPhyMethodNo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@RMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmtransid);
                myparam[1] = ModHelper.CreateParameter("@RMPhyMethodNo", SqlDbType.BigInt, 8, ParameterDirection.Input, rmphymethodno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMPhysicochemicalTestMethodDetails_RMTransID_RMPhyMethodNo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblRMPhysicochemicalTestMethodDetails_RMTransID_TestType_ParaName_DescName()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@RMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmtransid);
                myparam[1] = ModHelper.CreateParameter("@TestType", SqlDbType.NVarChar, 50, ParameterDirection.Input, testtype);
                myparam[2] = ModHelper.CreateParameter("@ParaName", SqlDbType.NVarChar, 250, ParameterDirection.Input, paraname);
                myparam[3] = ModHelper.CreateParameter("@DescName", SqlDbType.NVarChar, 250, ParameterDirection.Input, descname);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMPhysicochemicalTestMethodDetails_RMTransID_TestType_ParaName_DescName", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_RMPhysicochemicalTestMethodDetails_RMSamplingID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@RMSamplingID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmsamplingid);
                myparam[1] = ModHelper.CreateParameter("@MethodType", SqlDbType.Char, 1, ParameterDirection.Input, methodtype);
                myparam[2] = ModHelper.CreateParameter("@ParaType", SqlDbType.NVarChar, 50, ParameterDirection.Input, paratype);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMPhysicochemicalTestMethodDetails_RMSamplingID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_RMPreservativeMethodDetails_RMSamplingID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMSamplingID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmsamplingid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMPreservativeMethodDetails_RMSamplingID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_RMFDAPreservativeMethodDetails_RMSamplingID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMSamplingID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmsamplingid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMFDAPreservativeMethodDetails_RMSamplingID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_RMFDAPhysicoChemicalTestMethodDetails_RMSamplingID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@RMSamplingID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmsamplingid);
                myparam[1] = ModHelper.CreateParameter("@ParaType", SqlDbType.NVarChar, 50, ParameterDirection.Input, paratype);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMFDAPhysicoChemicalTestMethodDetails_RMSamplingID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_RMFDAPhysicoChemicalTestMethodMaster_RMCodeID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmcodeid);
                myparam[1] = ModHelper.CreateParameter("@ParaType", SqlDbType.NVarChar, 250, ParameterDirection.Input, paratype);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMFDAPhysicoChemicalTestMethodMaster_RMCodeID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_RMFDAPreservativeMethodMaster_RMCodeID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmcodeid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMFDAPreservativeMethodMaster_tblRMSampling__RMCodeID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_RMPreservativeMethodMaster_RMSampling_FullControlAnalysis_RMCodeID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmcodeid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMPreservativeMethodMaster_tblRMSampling__FullControlAnalysis_RMCodeID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_RMSupplierAgentMaster_RMSupplierMaster_RMCodeID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMCodeID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMSupplierAgentMaster_tblRMSupplierMaster_RMCodeID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblRMCodeMaster_Micro_RMCodeID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMCodeID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMCodeMaster_Micro_RMCodeID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_RMSampling_ForDuplicate()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmcodeid);
                myparam[1] = ModHelper.CreateParameter("@RMSupplierID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMSupplierID);
                myparam[2] = ModHelper.CreateParameter("@PlantLotNo", SqlDbType.VarChar, 50, ParameterDirection.Input, PlantLotNo);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMSampling_RMCodeID_RMSupplierID_PlantLotNo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblRMDetails_RMSamplingID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMSamplingID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmsamplingid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMDetails_RMSamplingID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblRMStatus_RMTransID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmtransid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMStatus_RMTransID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Insert_RMSampling()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[9];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmcodeid);
                myparam[1] = ModHelper.CreateParameter("@RMSupplierID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmsupplierid);
                myparam[2] = ModHelper.CreateParameter("@PlantLotNo", SqlDbType.VarChar, 50, ParameterDirection.Input, plantlotno);
                myparam[3] = ModHelper.CreateParameter("@QuantityReceived", SqlDbType.VarChar, 50, ParameterDirection.Input, quantityreceived);
                myparam[4] = ModHelper.CreateParameter("@QuantitySampled", SqlDbType.VarChar, 50, ParameterDirection.Input, quantitysampled);
                myparam[5] = ModHelper.CreateParameter("@ActualNoOfSegments", SqlDbType.Int, 4, ParameterDirection.Input, actualnoofsegments);
                myparam[6] = ModHelper.CreateParameter("@NoOfSegments", SqlDbType.Int, 4, ParameterDirection.Input, noofsegments);
                myparam[7] = ModHelper.CreateParameter("@IsValidityExpanded", SqlDbType.Bit, 1, ParameterDirection.Input, isvalidityexpanded);
                myparam[8] = ModHelper.CreateParameter("@RMSamplingID", SqlDbType.BigInt, 8, ParameterDirection.Output, rmsamplingid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblRMSampling", myparam);

                rmsamplingid = Convert.ToInt64(myparam[8].Value);

                return rmsamplingid;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update_RMSampling()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[9];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmcodeid);
                myparam[1] = ModHelper.CreateParameter("@RMSupplierID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmsupplierid);
                myparam[2] = ModHelper.CreateParameter("@PlantLotNo", SqlDbType.VarChar, 50, ParameterDirection.Input, plantlotno);
                myparam[3] = ModHelper.CreateParameter("@QuantityReceived", SqlDbType.VarChar, 50, ParameterDirection.Input, quantityreceived);
                myparam[4] = ModHelper.CreateParameter("@QuantitySampled", SqlDbType.VarChar, 50, ParameterDirection.Input, quantitysampled);
                myparam[5] = ModHelper.CreateParameter("@ActualNoOfSegments", SqlDbType.Int, 4, ParameterDirection.Input, actualnoofsegments);
                myparam[6] = ModHelper.CreateParameter("@NoOfSegments", SqlDbType.Int, 4, ParameterDirection.Input, noofsegments);
                myparam[7] = ModHelper.CreateParameter("@IsValidityExpanded", SqlDbType.Bit, 1, ParameterDirection.Input, isvalidityexpanded);
                myparam[8] = ModHelper.CreateParameter("@RMSamplingID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmsamplingid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblRMSampling", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete_tblRMSampling()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMCodeID);
                myparam[1] = ModHelper.CreateParameter("@RMSupplierID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMSupplierID);
                myparam[2] = ModHelper.CreateParameter("@PlantLotNo", SqlDbType.VarChar, 250, ParameterDirection.Input, PlantLotNo);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblRMSampling", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Insert_RMTransaction()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[10];
                myparam[0] = ModHelper.CreateParameter("@RMSamplingID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmsamplingid);
                myparam[1] = ModHelper.CreateParameter("@MethodType", SqlDbType.Char, 1, ParameterDirection.Input, methodtype);
                myparam[2] = ModHelper.CreateParameter("@ValidityDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, validitydate);
                myparam[3] = ModHelper.CreateParameter("@RemainingQuantity", SqlDbType.BigInt, 8, ParameterDirection.Input, remainingquantity);
                myparam[4] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
                myparam[5] = ModHelper.CreateParameter("@CurrentFlag", SqlDbType.Bit, 1, ParameterDirection.Input, currentflagtrans);
                myparam[6] = ModHelper.CreateParameter("@RMTransDone", SqlDbType.Bit, 1, ParameterDirection.Input, rmtransdone);
                myparam[7] = ModHelper.CreateParameter("@ManufacturinDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, mfgDate); 
                myparam[8] = ModHelper.CreateParameter("@RMTransID", SqlDbType.BigInt, 8, ParameterDirection.Output, rmtransid);
                myparam[9] = ModHelper.CreateParameter("@SubContract", SqlDbType.Bit, 1, ParameterDirection.Input, subContract);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblRMTransaction", myparam);

                RMTransID = Convert.ToInt64(myparam[8].Value);

                return RMTransID;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Insert_tblRMTransaction_ValidityReport()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[8];
                myparam[0] = ModHelper.CreateParameter("@RMSamplingID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmsamplingid);
                myparam[1] = ModHelper.CreateParameter("@MethodType", SqlDbType.Char, 1, ParameterDirection.Input, methodtype);
                myparam[2] = ModHelper.CreateParameter("@ValidityDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, validitydate);
                myparam[3] = ModHelper.CreateParameter("@RemainingQuantity", SqlDbType.BigInt, 8, ParameterDirection.Input, remainingquantity);
                myparam[4] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
                myparam[5] = ModHelper.CreateParameter("@CurrentFlag", SqlDbType.Bit, 1, ParameterDirection.Input, currentflagtrans);
                myparam[6] = ModHelper.CreateParameter("@RMTransID", SqlDbType.BigInt, 8, ParameterDirection.Output, rmtransid);
                myparam[7] = ModHelper.CreateParameter("@SubContract", SqlDbType.Bit, 1, ParameterDirection.InputOutput,subContract);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblRMTransaction_ValidityReport", myparam);

                RMTransID = Convert.ToInt64(myparam[6].Value);

                return RMTransID;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update_RMTransaction()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[10];
                myparam[0] = ModHelper.CreateParameter("@RMSamplingID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmsamplingid);
                myparam[1] = ModHelper.CreateParameter("@MethodType", SqlDbType.Char, 1, ParameterDirection.Input, methodtype);
                myparam[2] = ModHelper.CreateParameter("@ValidityDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, validitydate);
                myparam[3] = ModHelper.CreateParameter("@RemainingQuantity", SqlDbType.BigInt, 8, ParameterDirection.Input, remainingquantity);
                myparam[4] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
                myparam[5] = ModHelper.CreateParameter("@CurrentFlag", SqlDbType.Bit, 1, ParameterDirection.Input, currentflagtrans);
                myparam[6] = ModHelper.CreateParameter("@RMTransDone", SqlDbType.Bit, 1, ParameterDirection.Input, rmtransdone);
                myparam[7] = ModHelper.CreateParameter("@ManufacturinDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, mfgDate);
                myparam[8] = ModHelper.CreateParameter("@RMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmtransid);
                myparam[9] = ModHelper.CreateParameter("@SubContract", SqlDbType.Bit, 1, ParameterDirection.Input, subContract);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblRMTransaction", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update_tblRMTransaction_IsValidityExpanded()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@RMSamplingID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmsamplingid);
                myparam[1] = ModHelper.CreateParameter("@IsValidityExpanded", SqlDbType.Bit, 1, ParameterDirection.Input, isvalidityexpanded);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblRMTransaction_IsValidityExpanded", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Insert_RMDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[20];
                myparam[0] = ModHelper.CreateParameter("@RMSamplingID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmsamplingid);
                myparam[1] = ModHelper.CreateParameter("@ReceiptDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, receiptdate);
                myparam[2] = ModHelper.CreateParameter("@InspDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, inspdate);
                myparam[3] = ModHelper.CreateParameter("@AcceptedDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, accepteddate);
                myparam[4] = ModHelper.CreateParameter("@AgentName", SqlDbType.VarChar, 50, ParameterDirection.Input, agentname);
                myparam[5] = ModHelper.CreateParameter("@SupplierLotNo", SqlDbType.VarChar, 50, ParameterDirection.Input, supplierlotno);
                myparam[6] = ModHelper.CreateParameter("@ChallanNo", SqlDbType.VarChar, 50, ParameterDirection.Input, challanno);
                myparam[7] = ModHelper.CreateParameter("@MRR", SqlDbType.VarChar, 50, ParameterDirection.Input, mrr);
                myparam[8] = ModHelper.CreateParameter("@SRR", SqlDbType.Char, 1, ParameterDirection.Input, srr);
                myparam[9] = ModHelper.CreateParameter("@FirstRMReception", SqlDbType.Char, 1, ParameterDirection.Input, firstrmreception);
                myparam[10] = ModHelper.CreateParameter("@LabelForRetainer", SqlDbType.Char, 1, ParameterDirection.Input, labelforretainer);
                myparam[11] = ModHelper.CreateParameter("@SRC", SqlDbType.Char, 1, ParameterDirection.Input, src);
                myparam[12] = ModHelper.CreateParameter("@MicroStatus", SqlDbType.Char, 4, ParameterDirection.Input, microstatus);
                myparam[13] = ModHelper.CreateParameter("@RMDetailID", SqlDbType.BigInt, 8, ParameterDirection.Output, rmdetailid);
                myparam[14] = ModHelper.CreateParameter("@LocationID", SqlDbType.BigInt, 8, ParameterDirection.Input, locationID);
                myparam[15] = ModHelper.CreateParameter("@IsAligned", SqlDbType.VarChar, 50, ParameterDirection.Input, isAligned);
                myparam[16] = ModHelper.CreateParameter("@Halal", SqlDbType.VarChar, 50, ParameterDirection.Input, halal);
                myparam[17] = ModHelper.CreateParameter("@PlantOrigin", SqlDbType.VarChar, 50, ParameterDirection.Input, plantOrigin);
                myparam[18] = ModHelper.CreateParameter("@countryoforigin", SqlDbType.VarChar, 50, ParameterDirection.Input, countryoforigin);
                myparam[19] = ModHelper.CreateParameter("@TradeName", SqlDbType.VarChar, 200, ParameterDirection.Input, tradename);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblRMDetails", myparam);
                return Convert.ToInt64(myparam[13].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update_RMDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[20];
                myparam[0] = ModHelper.CreateParameter("@RMSamplingID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmsamplingid);
                myparam[1] = ModHelper.CreateParameter("@ReceiptDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, receiptdate);
                myparam[2] = ModHelper.CreateParameter("@InspDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, inspdate);
                myparam[3] = ModHelper.CreateParameter("@AcceptedDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, accepteddate);
                myparam[4] = ModHelper.CreateParameter("@AgentName", SqlDbType.VarChar, 50, ParameterDirection.Input, agentname);
                myparam[5] = ModHelper.CreateParameter("@SupplierLotNo", SqlDbType.VarChar, 50, ParameterDirection.Input, supplierlotno);
                myparam[6] = ModHelper.CreateParameter("@ChallanNo", SqlDbType.VarChar, 50, ParameterDirection.Input, challanno);
                myparam[7] = ModHelper.CreateParameter("@MRR", SqlDbType.VarChar, 50, ParameterDirection.Input, mrr);
                myparam[8] = ModHelper.CreateParameter("@SRR", SqlDbType.Char, 1, ParameterDirection.Input, srr);
                myparam[9] = ModHelper.CreateParameter("@FirstRMReception", SqlDbType.Char, 1, ParameterDirection.Input, firstrmreception);
                myparam[10] = ModHelper.CreateParameter("@LabelForRetainer", SqlDbType.Char, 1, ParameterDirection.Input, labelforretainer);
                myparam[11] = ModHelper.CreateParameter("@SRC", SqlDbType.Char, 1, ParameterDirection.Input, src);
                myparam[12] = ModHelper.CreateParameter("@MicroStatus", SqlDbType.Char, 4, ParameterDirection.Input, microstatus);
                myparam[13] = ModHelper.CreateParameter("@RMDetailID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmdetailid);
                myparam[14] = ModHelper.CreateParameter("@LocationID", SqlDbType.BigInt, 8, ParameterDirection.Input, locationID);
                myparam[15]=ModHelper.CreateParameter("@IsAligned",SqlDbType.VarChar,50,ParameterDirection.Input,isAligned);
                myparam[16] = ModHelper.CreateParameter("@Halal", SqlDbType.VarChar, 50, ParameterDirection.Input, halal);
                myparam[17] = ModHelper.CreateParameter("@plantOrigin", SqlDbType.VarChar, 50, ParameterDirection.Input, plantOrigin);
                myparam[18] = ModHelper.CreateParameter("@countryoforigin", SqlDbType.VarChar, 50, ParameterDirection.Input, countryoforigin);
                myparam[19] = ModHelper.CreateParameter("@TradeName", SqlDbType.VarChar, 200, ParameterDirection.Input, tradename);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblRMDetails", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Insert_RMStatus()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[9];
                myparam[0] = ModHelper.CreateParameter("@RMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmtransid);
                myparam[1] = ModHelper.CreateParameter("@NonConReason", SqlDbType.VarChar, 200, ParameterDirection.Input, nonconreason);
                myparam[2] = ModHelper.CreateParameter("@AcceptedQuantity", SqlDbType.BigInt, 8, ParameterDirection.Input, acceptedquantity);
                myparam[3] = ModHelper.CreateParameter("@Status", SqlDbType.Char, 1, ParameterDirection.Input, status);
                myparam[4] = ModHelper.CreateParameter("@LoginID", SqlDbType.BigInt, 8, ParameterDirection.Input, loginid);
                myparam[5] = ModHelper.CreateParameter("@Comment", SqlDbType.VarChar, 200, ParameterDirection.Input, comment);
                myparam[6] = ModHelper.CreateParameter("@CurrentFlag", SqlDbType.Bit, 1, ParameterDirection.Input, currentflagstatus);
                myparam[7] = ModHelper.CreateParameter("@StatusID", SqlDbType.BigInt, 8, ParameterDirection.Output, statusid);
                myparam[8] = ModHelper.CreateParameter("@RejectDescription", SqlDbType.VarChar, 400, ParameterDirection.Input, rejectdescription);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblRMStatus", myparam);
                return Convert.ToInt64(myparam[7].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update_RMStatus()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[9];
                myparam[0] = ModHelper.CreateParameter("@RMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmtransid);
                myparam[1] = ModHelper.CreateParameter("@NonConReason", SqlDbType.VarChar, 200, ParameterDirection.Input, nonconreason);
                myparam[2] = ModHelper.CreateParameter("@AcceptedQuantity", SqlDbType.BigInt, 8, ParameterDirection.Input, acceptedquantity);
                myparam[3] = ModHelper.CreateParameter("@Status", SqlDbType.Char, 1, ParameterDirection.Input, status);
                myparam[4] = ModHelper.CreateParameter("@LoginID", SqlDbType.BigInt, 8, ParameterDirection.Input, loginid);
                myparam[5] = ModHelper.CreateParameter("@Comment", SqlDbType.VarChar, 200, ParameterDirection.Input, comment);
                myparam[6] = ModHelper.CreateParameter("@CurrentFlag", SqlDbType.Bit, 1, ParameterDirection.Input, currentflagstatus);
                myparam[7] = ModHelper.CreateParameter("@StatusID", SqlDbType.BigInt, 8, ParameterDirection.Input, statusid);
                myparam[8] = ModHelper.CreateParameter("@RejectDescription", SqlDbType.VarChar, 400, ParameterDirection.Input, rejectdescription);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblRMStatus", myparam);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Insert_RMPhysicochemicalTestMethodDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[7];
                myparam[0] = ModHelper.CreateParameter("@RMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmtransid);
                myparam[1] = ModHelper.CreateParameter("@RMPhyMethodNo", SqlDbType.BigInt, 8, ParameterDirection.Input, rmphymethodno);
                myparam[2] = ModHelper.CreateParameter("@NormsReading", SqlDbType.VarChar, 50, ParameterDirection.Input, normsreading);
                myparam[3] = ModHelper.CreateParameter("@NormsMin", SqlDbType.VarChar, 50, ParameterDirection.Input, normsmin);
                myparam[4] = ModHelper.CreateParameter("@NormsMax", SqlDbType.VarChar, 50, ParameterDirection.Input, normsmax);
                myparam[5] = ModHelper.CreateParameter("@SupplierResult", SqlDbType.NVarChar, 50, ParameterDirection.Input, suppresult);
                myparam[6] = ModHelper.CreateParameter("@RMPhyDetailNo", SqlDbType.BigInt, 8, ParameterDirection.Output, rmphydetailno);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblRMPhysicochemicalTestMethodDetails", myparam);                
                return Convert.ToInt64(myparam[6].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update_tblRMPhysicochemicalTestMethodDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@RMPhyDetailNo", SqlDbType.BigInt, 8, ParameterDirection.Input, rmphydetailno);
                myparam[1] = ModHelper.CreateParameter("@NormsReading", SqlDbType.VarChar, 50, ParameterDirection.Input, normsreading);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblRMPhysicochemicalTestMethodDetails", myparam);
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
                myparam[0] = ModHelper.CreateParameter("@RMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmtransid);
                myparam[1] = ModHelper.CreateParameter("@RMPresMethodNo", SqlDbType.BigInt, 8, ParameterDirection.Input, rmpresmethodno);
                myparam[2] = ModHelper.CreateParameter("@NormsReading", SqlDbType.VarChar, 50, ParameterDirection.Input, normsreading);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblRMPreservativeMethodDetails", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public void Insert_RMFDAPhysicoChemicalTestMethodDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@RMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmtransid);
                myparam[1] = ModHelper.CreateParameter("@RMFDAPhyMethodNo", SqlDbType.BigInt, 8, ParameterDirection.Input, rmfdaphymethodno);
                myparam[2] = ModHelper.CreateParameter("@NormsReading", SqlDbType.VarChar, 50, ParameterDirection.Input, normsreading);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblRMFDAPhysicoChemicalTestMethodDetails", myparam);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert_RMFDAPreservativeMethodDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@RMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmtransid);
                myparam[1] = ModHelper.CreateParameter("@RMFDAPresMethodNo", SqlDbType.BigInt, 8, ParameterDirection.Input, rmfdapresmethodno);
                myparam[2] = ModHelper.CreateParameter("@NormsReading", SqlDbType.VarChar, 50, ParameterDirection.Input, normsreading);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblRMFDAPreservativeMethodDetails", myparam);

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
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@RMSamplingID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmsamplingid);
                myparam[1] = ModHelper.CreateParameter("@IsValidityExpanded", SqlDbType.Bit, 1, ParameterDirection.Input, isvalidityexpanded);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMTransaction_RMSamplingID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_RMCodeMaster_RMCodeID_ForFDA()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmcodeid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMCodeMaster_RMCodeID_ForFDA", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_RMTransaction_RMDetails()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmtransid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMTransaction_tblRMDetails", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_MethodType_RMTransID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmtransid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_MethodType_RMTransID", myparam);
                return ds;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_RMPhysicochemicalTestMethodDetails_RMTransID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@RMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmtransid);
                myparam[1] = ModHelper.CreateParameter("@TestType", SqlDbType.NVarChar, 50, ParameterDirection.Input, testtype);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMPhysicochemicalTestMethodDetails_RMTransID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete_tblRMPhysicochemicalTestMethodDetails_RMtransID()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@RMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmtransid);
                myparam[1] = ModHelper.CreateParameter("@TestType", SqlDbType.NVarChar, 50, ParameterDirection.Input, testtype);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblRMPhysicochemicalTestMethodDetails_RMtransID", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_RMPreservativeMethodDetails_RMTransID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmtransid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMPreservativeMethodDetails_RMTransID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_RMFDAPhysicoChemicalTestMethodDetails_RMTransID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmtransid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMFDAPhysicoChemicalTestMethodDetails_RMTransID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_RMFDAPreservativeMethodDetails_RMTransID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmtransid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMFDAPreservativeMethodDetails_RMTransID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_RMProtocol_Report_TestType()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmcodeid);
                myparam[1] = ModHelper.CreateParameter("@TestType", SqlDbType.NVarChar, 50, ParameterDirection.Input, testtype);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_RMProtocol_Report_TestType", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_RMProtocol_Done_Report_TestType()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmcodeid);
                myparam[1] = ModHelper.CreateParameter("@TestType", SqlDbType.NVarChar, 50, ParameterDirection.Input, testtype);
                myparam[2] = ModHelper.CreateParameter("@RMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmtransid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_RMProtocol_Done_Report_TestType", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_RMProtocol_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmcodeid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_RMProtocol_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_RMProtocol_Done_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmcodeid);
                myparam[1] = ModHelper.CreateParameter("@RMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmtransid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_RMProtocol_Done_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_RMProtocol_Supplier_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@RMSupplierID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmsupplierid);
                myparam[1] = ModHelper.CreateParameter("@SupplierLotNo", SqlDbType.VarChar, 50, ParameterDirection.Input, supplierlotno);
                myparam[2] = ModHelper.CreateParameter("@RMSamplingID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmsamplingid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_RMProtocol_Supplier_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_RMProtocol_Pres_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMSamplingID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmsamplingid);

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_RMProtocol_Pres_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_RMProtocol_FDAPhy_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMSamplingID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmsamplingid);

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_RMProtocol_FDAPhy_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_RMProtocol_FDAPres_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMSamplingID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmsamplingid);

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_RMProtocol_FDAPres_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet Select_View_RMProtocol_Phy_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@RMSamplingID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmsamplingid);
                myparam[1] = ModHelper.CreateParameter("@MethodType", SqlDbType.Char, 1, ParameterDirection.Input, methodtype);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_RMProtocol_Phy_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        /////////////////////////////////////////

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

        public DataSet Select_tblRMSampling_ProtocolNo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMSamplingID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMSamplingID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMSampling_ProtocolNo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Select_tblRMSampling_tblRMTransaction_tblRMStatus_RMSamplingID()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMSamplingID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMSamplingID);
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMSampling_tblRMTransaction_tblRMStatus_RMSamplingID", myparam).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_RMDetails()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmcodeid);
                myparam[1] = ModHelper.CreateParameter("@RMSupplierID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMSupplierID);
                myparam[2] = ModHelper.CreateParameter("@PlantLotNo", SqlDbType.VarChar, 50, ParameterDirection.Input, PlantLotNo);
                myparam[3] = ModHelper.CreateParameter("@MethodType", SqlDbType.Char, 1, ParameterDirection.Input, methodtype);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_RMDetails", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Show safety symbol images by RM Code
        public DataSet Select_SefetySymbol_RmCodeID()
        {
            try
            {
                DataSet DS = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmcodeid);
                DS = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_RMRetainerSafetyAccess_RMCodeID", myparam);
                return DS;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Get previous location Id from RM Transaction 
        public DataSet Select_RMDetails_LocationID()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_RMDetails_LocationID");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Select_NoOFLots()
        {
            try
            {
                
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmcodeid);
                myparam[1] = ModHelper.CreateParameter("@RMSupplierID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmsupplierid);
                return Convert.ToInt64(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_Select_RM_NoOfLots", myparam).ToString());//).ToString());
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Get_If_LotNoExists()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@PlantLotNo", SqlDbType.VarChar, 50, ParameterDirection.Input, plantlotno);
                myparam[1] = ModHelper.CreateParameter("@ExistAlready", SqlDbType.Bit, 1, ParameterDirection.Output);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"STP_Get_RMLotNo_Exist", myparam);
                return (bool)myparam[1].Value;
            }
            catch
            {
                throw;
            }
        
        }
        public string Select_RMSupplier_SupplierID()
        {
            try
            {
                string outpt = "";
                SqlParameter[] parm = new SqlParameter[2];
                parm[0] = ModHelper.CreateParameter("@RMSupplierID", SqlDbType.BigInt,8, ParameterDirection.Input, rmsupplierid);
                parm[1] = ModHelper.CreateParameter("@Res", SqlDbType.VarChar, 50, ParameterDirection.Output);
               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Select_RMSupplier_SupplierID", parm);
               outpt = parm[1].Value.ToString();
               return outpt;
            }
            catch
            {
                throw;
            }
        
        }
        public DataSet  Select_RMAlignment_Protocol()
        {
            try
            {
                DataSet ds;
                ds = new DataSet();
                SqlParameter[] parm = new SqlParameter[1];
                parm[0] = ModHelper.CreateParameter("@RMSamplingID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmsamplingid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_RMAlignment_Protocol", parm);
                return ds;
            }
            catch
            {
                throw;
            }

        }
        //public DataTable Select_RMSAWhiteImage()
        //{
        //    try
        //    {
        //        DataTable dt = new DataTable();
        //        dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMSAWhiteImage").Tables[0];
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        #endregion
    }
}
