using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;
namespace BusinessFacade.Transactions
{
   public class LineSampleDetails_Class
   {
       # region Varibles
       private int LoginID;
       private long BulkNo;
       private long LineSampleNo;
       private string FormulaNo;
       private string MfgWO;
       private string BatchNo;
       private int LNo;
       private string FillDate;
       private string PHlevel;
       private string H2O2Level;
       private string Dyetest;
       private char Status;
       private char Dossr;
       private string Comments;
       private string SourceRef;
       private string TransId;
       private int TankNo;
       private char StartOFStk;
       private char Min30;
       private char FirstSamp;
       private char EndOFStk;
       private string FillVolume;
       private string FromDate;
       private string ToDate;
       private long FMID;
       private long TLFID;
       private long FNo;
       private string InspDate;
       private bool LineSampDone;
       private int InspecedBy;
       private int VerifiedBy;
       private DateTime LSD;
       private string CMW;
       private string CST;

       # endregion

       # region Properties   
       public int verifiedby
       {
           get { return VerifiedBy; }
           set { VerifiedBy = value; }
       }
       public int inspectedby
       {
           get { return InspecedBy; }
           set { InspecedBy = value; }
       }
       public int loginid
       {
           get { return LoginID; }
           set { LoginID = value; }
       }
       public string fillvolume
       {
           get { return FillVolume; }
           set { FillVolume = value; }
       }
       public long bulkno
       {
           get { return BulkNo; }
           set { BulkNo = value; }
       }
       public string formulano
       {
           get { return FormulaNo; }
           set { FormulaNo = value; }
       }
       public char startofstk
       {
           get { return StartOFStk; }
           set { StartOFStk = value; }
       }
       public char min30
       {
           get { return Min30; }
           set { Min30 = value; }
       }
       public char firstsamp
       {
           get { return FirstSamp; }
           set { FirstSamp = value; }
       }
       public char endofstk
       {
           get { return EndOFStk; }
           set { EndOFStk = value; }
       }
       public string mfgwo
       {
           get { return MfgWO; }
           set { MfgWO = value; }
       }
       public long linesampleno
       {
           get { return LineSampleNo; }
           set { LineSampleNo = value; }
       }
       public int tankno
       {
           get { return TankNo; }
           set { TankNo = value; }
       }
       public string batchno
       {
           get { return BatchNo; }
           set { BatchNo = value; }
       }
       public int lno
       {
           get { return LNo; }
           set { LNo = value; }
       }
       public string filldate
       {
           get { return FillDate; }
           set { FillDate = value; }
       }
       public string phlevel
       {
           get { return PHlevel; }
           set { PHlevel = value; }
       }
       public string h2o2level
       {
           get { return H2O2Level; }
           set { H2O2Level = value; }
       }
       public string dyetest
       {
           get { return Dyetest; }
           set { Dyetest = value; }
       }
       public char status
       {
           get { return Status; }
           set { Status = value; }
       }
       public char dossr
       {
           get { return Dossr; }
           set { Dossr = value; }
       }
       public string comments
       {
           get { return Comments; }
           set { Comments = value; }
       }
       public string sourceref
       {
           get { return SourceRef; }
           set { SourceRef = value; }
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
       public long fmid
       {
           get { return FMID; }
           set { FMID = value; }
       }
       public long tlfid
       {
           get { return TLFID; }
           set { TLFID = value; }
       }
       public long fno
       {
           get { return FNo; }
           set { FNo = value; }
       }
       public string inspdate
       {
           get { return InspDate; }
           set { InspDate = value; }
       }
       public bool linesampdone
       {
           get { return LineSampDone; }
           set { LineSampDone = value; }
       }
       public DateTime lsd
       {
           get { return LSD; }
           set { LSD = value; }
       }
       public string cmw
       {
           get { return CMW; }
           set { CMW = value; }
       }
       public string cst
       {
           get { return CST; }
           set { CST = value; }
       }
       # endregion
       # region Functions

       public DataSet Select_PendingLineSampleDetails()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[2];
               myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
               myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_PendingLineSampleDetails",myparam);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public DataSet Select_ModificationLineSampleDetails()
       {
           try
           {
               DataSet ds = new DataSet();
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_ModificationLineSampleDetails");
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public DataSet Select_ModificationLineSampleDetailsforDropDown()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[2];
               myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
               myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_ModificationLineSampleDetailsforDropDown", myparam);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public DataTable Select_ModificationLineSampleDetails_Mfgwo()
       {
           try
           {
               DataTable dt = new DataTable();
               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@MfgWo", SqlDbType.VarChar, 200, ParameterDirection.Input, mfgwo);
               dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_ModificationLineSampleDetails_mfgwo", myparam).Tables[0];
               return dt;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public DataSet Select_LineSampleDetails_TLFID()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, tlfid);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_LineSampleDetails_TLFID", myparam);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public DataSet Select_ModificationLineSampleDetails_Details()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@LineSampleNo", SqlDbType.BigInt, 8, ParameterDirection.Input, linesampleno);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_ModificationLineSampleDetails_Details", myparam);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
        

       public DataSet Select_TankDetails_FMID()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_TankDetails_FMID", myparam);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public DataSet SELECT_tblFillTankSamp_TLFID()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, tlfid);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblFillTankSamp_TLFID", myparam);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public DataSet SELECT_tblFillTankSamp_tblTankMaster_TLFID()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, tlfid);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblFillTankSamp_tblTankMaster_TLFID", myparam);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public bool INSERT_tblFillSample()
       {
           try
           {
               SqlParameter[] myparam = new SqlParameter[7];
               myparam[0] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt,8, ParameterDirection.Input, tlfid);
               myparam[1] = ModHelper.CreateParameter("@InspDate", SqlDbType.SmallDateTime,4, ParameterDirection.Input,inspdate);
               myparam[2] = ModHelper.CreateParameter("@Status", SqlDbType.Char,1, ParameterDirection.Input,status);
               myparam[3] = ModHelper.CreateParameter("@Comments", SqlDbType.NVarChar,250, ParameterDirection.Input, comments);
               myparam[4] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
               myparam[5] = ModHelper.CreateParameter("@InspectedBy", SqlDbType.Int, 4, ParameterDirection.Input, inspectedby);
               myparam[6] = ModHelper.CreateParameter("@VerifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, verifiedby);

               //myparam[7] = ModHelper.CreateParameter("@LSD", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, lsd);
               //myparam[8] = ModHelper.CreateParameter("@CMW", SqlDbType.VarChar, 200, ParameterDirection.Input, cmw);
               //myparam[9] = ModHelper.CreateParameter("@CST", SqlDbType.VarChar, 200, ParameterDirection.Input, cst);
               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblFillSamp", myparam);
               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public bool Insert_Update_tblFillTankSamp()
       {
           try
           {
               SqlParameter[] myparam = new SqlParameter[5];
               myparam[0] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, tlfid);
               myparam[1] = ModHelper.CreateParameter("@TankNo", SqlDbType.Int, 4, ParameterDirection.Input, tankno);              
               myparam[2] = ModHelper.CreateParameter("@CMW", SqlDbType.VarChar, 200, ParameterDirection.Input, cmw);
               myparam[3] = ModHelper.CreateParameter("@CST", SqlDbType.VarChar, 200, ParameterDirection.Input, cst);
               myparam[4] = ModHelper.CreateParameter("@LSD", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, lsd);
               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_Update_tblFillTankSamp", myparam);
               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public bool Update_tblTransTLF_LineSampDone()
       {
           try
           {
               SqlParameter[] myparam = new SqlParameter[2];
               myparam[0] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, tlfid);
               myparam[1] = ModHelper.CreateParameter("@LineSampDone", SqlDbType.Bit, 1, ParameterDirection.Input, linesampdone);
               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblTransTLF_LineSampDone", myparam);
               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public bool Delete_tblFillSamp()
       {
           try
           {
               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, tlfid);
               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblFillSamp", myparam);
               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public bool Delete_tblFillTankSamp()
       {
           try
           {
               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, tlfid);
               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblFillTankSamp", myparam);
               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public DataSet Select_tblFillSamp_TLFID()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, tlfid);

               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblFillSamp_TLFID", myparam);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public bool Update_tblFillSamp()
       {
           try
           {
               SqlParameter[] myparam = new SqlParameter[7];
               myparam[0] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, tlfid);
               myparam[1] = ModHelper.CreateParameter("@InspDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, inspdate);
               myparam[2] = ModHelper.CreateParameter("@Status", SqlDbType.Char, 1, ParameterDirection.Input, status);
               myparam[3] = ModHelper.CreateParameter("@Comments", SqlDbType.NVarChar, 250, ParameterDirection.Input, comments);
               myparam[4] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
               myparam[5] = ModHelper.CreateParameter("@InspectedBy", SqlDbType.Int, 4, ParameterDirection.Input, inspectedby);
               myparam[6] = ModHelper.CreateParameter("@VerifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, verifiedby);

               //myparam[7] = ModHelper.CreateParameter("@LSD", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, lsd);
               //myparam[8] = ModHelper.CreateParameter("@CMW", SqlDbType.VarChar, 200, ParameterDirection.Input, cmw);
               //myparam[9] = ModHelper.CreateParameter("@CST", SqlDbType.VarChar, 200, ParameterDirection.Input, cst);
               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblFillSamp", myparam);
               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public DataTable Select_LineSampleDetails_Mfgwo()
       {
           try
           {
               DataTable dt = new DataTable();
               SqlParameter[] myparam = new SqlParameter[3];
               myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
               myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
               myparam[2] = ModHelper.CreateParameter("@MfgWo",SqlDbType.VarChar,200,ParameterDirection.Input,mfgwo);
               dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_LineSampleDetails_Mfgwo", myparam).Tables[0];
               return dt;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       # endregion
   }
}
