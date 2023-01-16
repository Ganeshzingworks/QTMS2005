using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DataFacade;

namespace BusinessFacade.Transactions
{
   public class BulktestDetailstransaction_Class
   {
       #region Varibles
       private int LoginID;
       private long BulkNo;
       private string FormulaName;
       private long FormulaNo;
       private long FNo;
       private string Mfgwo="";
       private long FMID;
       private string FormulaType = "";
       private string InspDate="";
       private string MfgDate = "";
       private string Supplier = "";
       private string InspDate_TO = "";
       private int VesselNo=0;
       private int NoBatches=0;
       private int BatchSize=0;
       private string Density;
       private string SerialNo;
       private char FlagRL;
       private char SQPIF;
       private char LotValidation;
       private string ValidDate;
       private char TestClear;
       private char BPCNONBPC;
       private string NonBPCcmts="";
       private char Status;
       private string Comments="";
       private string TransId="";
       private int TankNO;       
       private char FA;
       private string FromDate;
       private string ToDate;
       private string Reading;
       private string InitialValue;
       private string FinalValue;
       private long BulkMethodNo;
       private long SubContract;
       private int InspectedBy;
       private string StartedOn;
       private string CompletedOn;
       private string ExtLabReportNo;
       private string NormsMin;
       private string NormsMax;
       private string MicroNorms;
       private long _FGSupplierId;
       private long _ManufacturedById;
       private bool DWP;
       private int VerifiedBy;

       public bool dwp
       {
           get { return DWP; }
           set { DWP = value; }
       }

       
	
       public string micronorms
       {
           get { return MicroNorms; }
           set { MicroNorms = value; }
       }
       private int BulkNoReject;

       public int bulknoreject
       {
           get { return BulkNoReject; }
           set { BulkNoReject = value; }
       }
       #endregion

       #region Properties   

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

       public string extlabreportno
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
       }
       public int inspectedby
       {
           get { return InspectedBy; }
           set { InspectedBy = value; }
       }
       public int verifiedby
       {
           get { return VerifiedBy; }
           set { VerifiedBy = value; }
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
       public string mfgdate
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
       }
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
       public int tankno
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
       }
       public char flagrl
       {
           get { return FlagRL; }
           set { FlagRL = value; }
       }
       public char sqpif
       {
           get { return SQPIF; }
           set { SQPIF = value; }
       }
       public char lotvalidation
       {
           get { return LotValidation; }
           set { LotValidation = value; }
       }
       public string validdate
       {
           get { return ValidDate; }
           set { ValidDate = value; }
       }
       public char testclear
       {
           get { return TestClear; }
           set { TestClear = value; }
       }
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
       public string transid
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
           get { return Supplier ; }
           set { Supplier = value; }
       }


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

             
       public DataSet Select_BulkDetails()
       {
           try
           {
               DataSet ds = new DataSet();
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_BulkDetails");
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public DataSet Select_ModificationBulkTestDetails()
       {
           try
           {
               DataSet ds = new DataSet();
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_ModificationBulkTestDetails");
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public DataSet Select_ModificationBulkTestDetails_Details()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@BulkNo", SqlDbType.BigInt, 8, ParameterDirection.Input, bulkno);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_ModificationBulkTestDetails_Details", myparam);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public long Select_tblBulktesttransaction_NoBatches()
       {
           try
           {               
               SqlParameter[] myparam = new SqlParameter[2];
               myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
               myparam[1] = ModHelper.CreateParameter("@Result", SqlDbType.BigInt, 8, ParameterDirection.Output);
               SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_tblBulktesttransaction_NoBatches", myparam);
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
       public DataSet Select_tblBulktesttrans_FormulaNo_Mfgwono()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[2];
               myparam[0] = ModHelper.CreateParameter("@FormulaNo", SqlDbType.BigInt,8, ParameterDirection.Input, formulano);
               myparam[1] = ModHelper.CreateParameter("@Mfgwo", SqlDbType.NVarChar, 200, ParameterDirection.Input, mfgwo);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_tblBulktesttrans_FormulaNo_Mfgwono", myparam);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
      }
        public DataSet Select_View_BulkRejection_Report()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@BulkNo", SqlDbType.BigInt,8, ParameterDirection.Input, bulkno);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Select_VIEW_BulkRejectionDetails", myparam);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
      }

       public DataSet Select_tblBulkTestTransaction_NoBatches()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[2];
               myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
               myparam[1] = ModHelper.CreateParameter("@Mfgwo", SqlDbType.NVarChar, 200, ParameterDirection.Input, mfgwo);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblBulkTestTransaction_NoBatches", myparam);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }


       public DataSet SELECT_tblBulkTankDetails_tankMaster()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[4];
               myparam[0] = ModHelper.CreateParameter("@BulkNo", SqlDbType.BigInt,8, ParameterDirection.Input, bulkno);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblBulkTankDetails_tankMaster", myparam);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
      
       public long SELECT_tblTransFM_FNo_MfgWo()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[3];
               myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
               myparam[1] = ModHelper.CreateParameter("@MfgWo", SqlDbType.NVarChar, 200, ParameterDirection.Input, mfgwo);
               myparam[2] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Output, fmid);
               SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_SELECT_tblTransFM_FNo_MfgWo", myparam);
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

       public long INSERT_tblTransFM_FNo_MfgWo()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[4];
               myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
               myparam[1] = ModHelper.CreateParameter("@MfgWo", SqlDbType.NVarChar, 200, ParameterDirection.Input, mfgwo);
               myparam[2] = ModHelper.CreateParameter("@SubContract", SqlDbType.Int, 1, ParameterDirection.Input, subcontract);
               myparam[3] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Output, fmid);
               SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_Insert_tblTransFM_FNo_MfgWo", myparam);
               return Convert.ToInt64(myparam[3].Value);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public bool Delete_tblTransFM()
       {
           try
           {
               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt,8, ParameterDirection.Input, fmid);
               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblTransFM", myparam);
               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public bool DELETE_tblBulktankdetails()
       {
           try
           {
               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@BulkNo", SqlDbType.BigInt,8, ParameterDirection.Input, bulkno);
               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_DELETE_tblBulktankdetails", myparam);
               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public bool INSERT_tblBulktankdetails()
       {
           try
           {
               SqlParameter[] myparam = new SqlParameter[2];
               myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt,8, ParameterDirection.Input, fmid);
               myparam[1] = ModHelper.CreateParameter("@TankNo", SqlDbType.Int,4, ParameterDirection.Input, tankno);
               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_INSERT_tblBulktankdetails", myparam);
               return true;
           }
           catch (Exception ex)
           {
               throw ex;               
           }
       }

       public bool Delete_tblBulkPhysicochemicalTestMethodDetails_FMID()
       {
           try
           {
               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblBulkPhysicochemicalTestMethodDetails_FMID", myparam);
               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public bool Update_tblBulkTestDetailstransaction()
       {
           try
           {
               SqlParameter[] myparam = new SqlParameter[26];
               myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 200, ParameterDirection.Input, fmid);
               myparam[1] = ModHelper.CreateParameter("@FormulaType", SqlDbType.VarChar, 50, ParameterDirection.Input, formulatype);
               myparam[2] = ModHelper.CreateParameter("@Supplier", SqlDbType.VarChar, 200, ParameterDirection.Input, supplier);               
               myparam[3] = ModHelper.CreateParameter("@InspDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, Inspdate);
               myparam[4] = ModHelper.CreateParameter("@StartedOn", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, startedon);
               myparam[5] = ModHelper.CreateParameter("@CompletedOn", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, completedon);
               myparam[6] = ModHelper.CreateParameter("@ExtLabReportNo", SqlDbType.VarChar, 50, ParameterDirection.Input, extlabreportno);
               myparam[7] = ModHelper.CreateParameter("@VesselNo", SqlDbType.BigInt, 8, ParameterDirection.Input, vesselno);
               myparam[8] = ModHelper.CreateParameter("@NoBatches", SqlDbType.Int, 4, ParameterDirection.Input, NoBatches);
               myparam[9] = ModHelper.CreateParameter("@BatchSize", SqlDbType.Int, 4, ParameterDirection.Input, batchsize);
               myparam[10] = ModHelper.CreateParameter("@SerialNo", SqlDbType.VarChar, 50, ParameterDirection.Input, serialno);
               myparam[11] = ModHelper.CreateParameter("@FlagRL", SqlDbType.Char, 1, ParameterDirection.Input, flagrl);
               myparam[12] = ModHelper.CreateParameter("@FormulationApproved", SqlDbType.Char, 1, ParameterDirection.Input, fa);               
               myparam[13] = ModHelper.CreateParameter("@ValidDate", SqlDbType.SmallDateTime, 8, ParameterDirection.Input, validdate);
               myparam[14] = ModHelper.CreateParameter("@BPCNONBPC", SqlDbType.Char, 1, ParameterDirection.Input, bpcnonbpc);
               myparam[15] = ModHelper.CreateParameter("@NonBPCcmts", SqlDbType.NVarChar, 250, ParameterDirection.Input, nonbpccomment);
               myparam[16] = ModHelper.CreateParameter("@Status", SqlDbType.Char, 1, ParameterDirection.Input, status);
               myparam[17] = ModHelper.CreateParameter("@Comments", SqlDbType.NVarChar, 250, ParameterDirection.Input, comments);
               myparam[18] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
               myparam[19] = ModHelper.CreateParameter("@InspectedBy", SqlDbType.Int, 4, ParameterDirection.Input, inspectedby);
               myparam[20] = ModHelper.CreateParameter("@BulkNo", SqlDbType.BigInt, 8, ParameterDirection.Input,bulkno);
               myparam[21] = ModHelper.CreateParameter("@MicroNorms", SqlDbType.VarChar, 250, ParameterDirection.Input, micronorms);
               myparam[22] = ModHelper.CreateParameter("@ManuById", SqlDbType.Int, 8, ParameterDirection.Input, ManufacturedById);
               myparam[23] = ModHelper.CreateParameter("@FGSupplierId", SqlDbType.Int, 8, ParameterDirection.Input, FGSupplierId);
               myparam[24] = ModHelper.CreateParameter("@DWP", SqlDbType.Bit, 1, ParameterDirection.Input, dwp);
               myparam[25] = ModHelper.CreateParameter("@VerifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, verifiedby);
               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_UPDATE_tblBulkTestTrans", myparam);
               
               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }

       }

       public bool Update_tblTransFM()
       {
           try
           {
               SqlParameter[] myparam = new SqlParameter[2];
               myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 200, ParameterDirection.Input, fmid);
               myparam[1] = ModHelper.CreateParameter("@SubContract", SqlDbType.VarChar, 50, ParameterDirection.Input, subcontract);
               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblTransFM", myparam);
               
               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }

       }


       public DataSet Select_tblBulkTestTransaction_FMID()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblBulkTestTransaction_FMID", myparam);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public DataSet Select_tblBulkTankDetails_FMID_TankNo()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[2];
               myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
               myparam[1] = ModHelper.CreateParameter("@TankNo", SqlDbType.Int, 4, ParameterDirection.Input, tankno);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblBulkTankDetails_FMID_TankNo", myparam);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public long Insert_tblBulkTestDetailstransaction()
       {
           try
           {
               SqlParameter[] myparam=new SqlParameter[26];
               myparam[0]  = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 200, ParameterDirection.Input, fmid);
               myparam[1] = ModHelper.CreateParameter("@FormulaType", SqlDbType.VarChar, 50, ParameterDirection.Input, formulatype);
               myparam[2] = ModHelper.CreateParameter("@Supplier", SqlDbType.VarChar, 200, ParameterDirection.Input, supplier);               
               myparam[3]  = ModHelper.CreateParameter("@InspDate", SqlDbType.SmallDateTime,4, ParameterDirection.Input, Inspdate);
               myparam[4] = ModHelper.CreateParameter("@StartedOn", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, startedon);
               myparam[5] = ModHelper.CreateParameter("@CompletedOn", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, completedon);
               myparam[6] = ModHelper.CreateParameter("@ExtLabReportNo", SqlDbType.VarChar, 50, ParameterDirection.Input, extlabreportno);
               myparam[7]  = ModHelper.CreateParameter("@VesselNo", SqlDbType.BigInt,8, ParameterDirection.Input, vesselno);
               myparam[8]  = ModHelper.CreateParameter("@NoBatches", SqlDbType.Int, 4, ParameterDirection.Input, NoBatches);
               myparam[9]  = ModHelper.CreateParameter("@BatchSize", SqlDbType.Int, 4, ParameterDirection.Input, batchsize);
               myparam[10] = ModHelper.CreateParameter("@SerialNo", SqlDbType.VarChar, 50, ParameterDirection.Input, serialno);
               myparam[11]  = ModHelper.CreateParameter("@FlagRL", SqlDbType.Char,1, ParameterDirection.Input, flagrl);
               myparam[12] = ModHelper.CreateParameter("@FormulationApproved", SqlDbType.Char, 1, ParameterDirection.Input, fa);               
               myparam[13] = ModHelper.CreateParameter("@ValidDate", SqlDbType.SmallDateTime,8, ParameterDirection.Input, validdate);
               myparam[14] = ModHelper.CreateParameter("@BPCNONBPC", SqlDbType.Char, 1, ParameterDirection.Input, bpcnonbpc);
               myparam[15] = ModHelper.CreateParameter("@NonBPCcmts", SqlDbType.NVarChar,250, ParameterDirection.Input, nonbpccomment);
               myparam[16] = ModHelper.CreateParameter("@Status", SqlDbType.Char,1, ParameterDirection.Input, status);
               myparam[17] = ModHelper.CreateParameter("@Comments", SqlDbType.NVarChar,250, ParameterDirection.Input, comments);
               myparam[18] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
               myparam[19] = ModHelper.CreateParameter("@InspectedBy", SqlDbType.Int, 4, ParameterDirection.Input, inspectedby);
               myparam[20] = ModHelper.CreateParameter("@BulkNo", SqlDbType.BigInt, 8, ParameterDirection.Output);
               myparam[21] = ModHelper.CreateParameter("@MicroNorms", SqlDbType.VarChar, 250, ParameterDirection.Input, micronorms);
               myparam[22] = ModHelper.CreateParameter("@ManuById", SqlDbType.Int, 8, ParameterDirection.Input, ManufacturedById);
               myparam[23] = ModHelper.CreateParameter("@FGSupplierId", SqlDbType.Int, 8, ParameterDirection.Input, FGSupplierId);
               myparam[24] = ModHelper.CreateParameter("@DWP", SqlDbType.Bit, 1, ParameterDirection.Input, dwp);
               myparam[25] = ModHelper.CreateParameter("@VerifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, verifiedby);
               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_INSERT_tblBulktesttrans", myparam);
               bulkno = Convert.ToInt64(myparam[20].Value);
               return bulkno;
           }
           catch (Exception ex)
           {
               throw ex;
           }
           
       }

       public bool INSERT_tblBulkPhysicochemicalTestMethodDetails()
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
               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_INSERT_tblBulkPhysicochemicalTestMethodDetails", myparam);
               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public DataSet Select_tblTransFM_FormulaNo_MfgWo()
       {
           try
           {
               DataSet ds = new DataSet();
               ds =  SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblTransFM_FormulaNo_MfgWo");
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public DataSet Select_tblTransFM_tblBulkTestTransaction()
       {
           try
           {
               DataSet ds = new DataSet();
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblTransFM_tblBulkTestTransaction");
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public DataSet Select_tbltestmaster_IdentificationTest_ControlTest()
       {
           try
           {
               DataSet ds = new DataSet();
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tbltestmaster_IdentificationTest_ControlTest");
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }


       public DataSet Select_tblTransFM_MfgWo()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter param = new SqlParameter();
               param = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno); 
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblTransFM_MfgWo",param);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public DataSet Select_tblBulkTestTransaction_BatchSize()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter param = new SqlParameter();
               param = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblBulkTestTransaction_BatchSize", param);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public DataSet Select_VIEW_Protocol_Bulk()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[2];
               myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
               myparam[1] = ModHelper.CreateParameter("@FormulaType", SqlDbType.VarChar, 50, ParameterDirection.Input, FormulaType);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_Protocol_Bulk", myparam);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public DataSet Select_tblBulkPhysicochemicalTestMethodDetails()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[3];
               myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
               myparam[1] = ModHelper.CreateParameter("@MfgWo", SqlDbType.NVarChar, 200, ParameterDirection.Input, mfgwo);
               myparam[2] = ModHelper.CreateParameter("@BulkMethodNo", SqlDbType.BigInt, 8, ParameterDirection.Input, bulkmethodno);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblBulkPhysicochemicalTestMethodDetails", myparam);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public DataSet SELECT_tblBulkPhysicochemicalTestMethodDetails_FMID()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myaparam = new SqlParameter[1];
               myaparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);               
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblBulkPhysicochemicalTestMethodDetails_FMID", myaparam);

               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       // Get norms From Transaction table

       public DataSet SELECT_tblBulkPhysicochemicalTestMethodDetails_Norms_FMID()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myaparam = new SqlParameter[1];
               myaparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblBulkPhysicochemicalTestMethodDetails_Norms_FMID", myaparam);

               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public DataSet Select_tblBulkTestTransaction_FNo_MfgWo()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[2];
               myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
               myparam[1] = ModHelper.CreateParameter("@MfgWo", SqlDbType.NVarChar, 200, ParameterDirection.Input, mfgwo);               
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblBulkTestTransaction_FNo_MfgWo", myparam);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public DataSet Select_tblBulktankDetails_FNo_MfgWo()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[2];
               myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
               myparam[1] = ModHelper.CreateParameter("@MfgWo", SqlDbType.NVarChar, 200, ParameterDirection.Input, mfgwo);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblBulktankDetails_FNo_MfgWo", myparam);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public DataSet Select_BulkTestDetail_ProtocolNo()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_BulkTestDetail_ProtocolNo", myparam);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public DataSet Select_tblTransFM_FNo()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblTransFM_FNo", myparam);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public string Autogeneratecode()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[18];
               myparam[0] = ModHelper.CreateParameter("@InspDate", SqlDbType.DateTime,8, ParameterDirection.Input, InspDate);
               string s = Inspdate.Substring(0, 10);
               DateTime DTPInspDate = Convert.ToDateTime(s);
               int c;
               try
               {
                    c = Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_Autogeneratecode", myparam));
               }
               catch 
               {
                   c = 0;
               }
               int ano = c + 1;
               string Autogen="";
               if(ano < 10)
               {
                   Autogen = "MD" + Convert.ToString(DTPInspDate.Year) + Convert.ToString(DTPInspDate.Month) + Convert.ToString(DTPInspDate.Day) + "00" + ano;
               }
               else if((ano >= 10) && (ano < 100))
               {
                   Autogen = "MD" + Convert.ToString(DTPInspDate.Year) + Convert.ToString(DTPInspDate.Month) + Convert.ToString(DTPInspDate.Day) + "0" + ano;
               }
               else if(ano >= 100)
               {
                   Autogen = "MD" + Convert.ToString(DTPInspDate.Year) + Convert.ToString(DTPInspDate.Month) + Convert.ToString(DTPInspDate.Day) + "0" + ano;
               }
        
               return Autogen;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       #endregion

       public DataSet Select_FGSupplier_By_SupplierID(int FGSupplierId)
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@FGSupplierId", SqlDbType.BigInt, 8, ParameterDirection.Input, FGSupplierId);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_FGSupplierMaster_FGSupplierId", myparam);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
   }
}
