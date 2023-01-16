using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;
namespace BusinessFacade.Transactions
{
   public class Microbiologytest_Class
   {
       # region Varibles
       private int LoginID;
       private string FSD;
       private string STS;
       private string LBK;
       private string EST;
       private string LSD;
       private string CM1;
       private string CM2;
       private string CM3;
       private string CM4;
       private string CM5;
       private long TankNo;
       private long MicroNo;
       private long BulkNo;
       private string ClearDate;
       private string Innoc_Broth_Date;
       private string Innoc_Broth_Time;
       private string Innoc_Agar_Date;
       private string Innoc_Agar_Time;
       private string Inccubation_Broth_Date;
       private string Inccubation_Broth_Time;
       private string Inccubation_Agar_Date;
       private string Inccubation_Agar_Time;
       private string Inccubation_Other_Date;
       private string Inccubation_Other_Time;
       private string Inccub_Broth_Temp;
       private string Inccub_Agar_Temp;
       private string Inccub_Other_Temp;
       private string Result_Broth_Date;
       private string Result_Broth_Time;
       private string Result_Agar_Date;
       private string Result_Agar_Time;
       private string Result_Other_Date;
       private string Result_Other_Time;
       private string TotalTime_Broth;
       private string TotalTime_Agar;
       private string TotalTime_Other;
       private string Remarks_Broth;
       private string Remarks_Agar;
       private string Remarks_Other;
       private char Status;
       private char BpcNonBpc;
       private string NonBpcComments;
       private string Comment;
       private string FromDate;
       private string ToDate;
       private int LNo;
       private string MediaLotNo;
       private long FMID;
       private long TLFID;
       private long BulkTankDetailNo;
       private char SampleToRetainer;
       private string DetailsNo;
       private string TrackCode;
       private long FGNo;
       private bool MicroDone;
       private int InspectedBy;
       # endregion
       # region Properties
       public int inspectedby
       {
           get { return InspectedBy; }
           set { InspectedBy = value; }
       }
       public string detailsno
       {
           get { return DetailsNo; }
           set { DetailsNo = value; }
       }
       public string trackcode
       {
           get { return TrackCode; }
           set { TrackCode = value; }
       }
       public long fgno
       {
           get { return FGNo; }
           set { FGNo = value; }
       }
       public int loginid
       {
           get { return LoginID; }
           set { LoginID = value; }
       }
       public long tankno
       {
           get { return TankNo; }
           set { TankNo = value; }
       }
       public long microno
       {
           get { return MicroNo; }
           set { MicroNo = value; }
       }
       public long bulkno
       {
           get { return BulkNo; }
           set { BulkNo = value; }
       }
       public string fsd
       {
           get { return FSD; }
           set { FSD = value; }
       }
       public string sts
       {
           get { return STS; }
           set { STS = value; }
       }
       public string lbk
       {
           get { return LBK; }
           set { LBK = value; }
       }       
       public string est
       {
           get { return EST; }
           set { EST = value; }
       }
       public string lsd
       {
           get { return LSD; }
           set { LSD = value; }
       }
       public string cm1
       {
           get { return CM1; }
           set { CM1 = value; }
       }
       public string cm2
       {
           get { return CM2; }
           set { CM2 = value; }
       }
       public string cm3
       {
           get { return CM3; }
           set { CM3 = value; }
       }
       public string cm4
       {
           get { return CM4; }
           set { CM4 = value; }
       }
       public string cm5
       {
           get { return CM5; }
           set { CM5 = value; }
       }
       public string cleardate
       {
           get { return ClearDate; }
           set { ClearDate = value; }
       }
       public string innoc_broth_date
       {
           get { return Innoc_Broth_Date; }
           set { Innoc_Broth_Date = value; }
       }
       public string innoc_broth_time
       {
           get { return Innoc_Broth_Time; }
           set { Innoc_Broth_Time = value; }
       }
       public string innoc_agar_date
       {
           get { return Innoc_Agar_Date; }
           set { Innoc_Agar_Date = value; }
       }
       public string innoc_agar_time
       {
           get { return Innoc_Agar_Time; }
           set { Innoc_Agar_Time = value; }
       }
       public string inccubation_broth_date
       {
           get { return Inccubation_Broth_Date; }
           set { Inccubation_Broth_Date = value; }
       }
       
       public string inccubation_broth_time
       {
           get { return Inccubation_Broth_Time; }
           set { Inccubation_Broth_Time = value; }
       }
       public string inccubation_agar_date
       {
           get { return Inccubation_Agar_Date; }
           set { Inccubation_Agar_Date = value; }
       }
       public string inccubation_agar_time
       {
           get { return Inccubation_Agar_Time; }
           set { Inccubation_Agar_Time = value; }
       }
       public string inccubation_other_date
       {
           get { return Inccubation_Other_Date; }
           set { Inccubation_Other_Date = value; }
       }
       public string inccubation_other_time
       {
           get { return Inccubation_Other_Time; }
           set { Inccubation_Other_Time = value; }
       }
       public string inccub_broth_temp
       {
           get { return Inccub_Broth_Temp; }
           set { Inccub_Broth_Temp = value; }
       }
       public string inccub_other_temp
       {
           get { return Inccub_Other_Temp; }
           set { Inccub_Other_Temp = value; }
       }
       public string inccub_agar_temp
       {
           get { return Inccub_Agar_Temp; }
           set { Inccub_Agar_Temp = value; }
       }
       public string result_broth_date
       {
           get { return Result_Broth_Date; }
           set { Result_Broth_Date = value; }
       }
       public string result_broth_time
       {
           get { return Result_Broth_Time; }
           set { Result_Broth_Time = value; }
       }
       public string result_agar_date
       {
           get { return Result_Agar_Date; }
           set { Result_Agar_Date = value; }
       }
       public string result_agar_time
       {
           get { return Result_Agar_Time; }
           set { Result_Agar_Time = value; }
       }
       public string result_other_date
       {
           get { return Result_Other_Date; }
           set { Result_Other_Date = value; }
       }
       public string result_other_time
       {
           get { return Result_Other_Time; }
           set { Result_Other_Time = value; }
       }
       public string totaltime_broth
       {
           get { return TotalTime_Broth; }
           set { TotalTime_Broth = value; }
       }
       public string totaltime_agar
       {
           get { return TotalTime_Agar; }
           set { TotalTime_Agar = value; }
       }
       public string totaltime_other
       {
           get { return TotalTime_Other; }
           set { TotalTime_Other = value; }
       }
       public string remarks_broth
       {
           get { return Remarks_Broth; }
           set { Remarks_Broth = value; }
       }
       public string remarks_agar
       {
           get { return Remarks_Agar; }
           set { Remarks_Agar = value; }
       }
       public string remarks_other
       {
           get { return Remarks_Other; }
           set { Remarks_Other = value; }
       }
       public char status
       {
           get { return Status; }
           set { Status = value; }
       }
       public char bpcnonbpc
       {
           get { return BpcNonBpc; }
           set { BpcNonBpc = value; }
       }
       public string nonbpccomments
       {
           get { return NonBpcComments; }
           set { NonBpcComments = value; }
       }
       public string comments
       {
           get { return Comment; }
           set { Comment = value; }
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
       public int lno
       {
           get { return LNo; }
           set { LNo = value; }
       }
       public string medialotno
       {
           get { return MediaLotNo; }
           set { MediaLotNo = value; }
       }
       public long tlfid
       {
           get { return TLFID; }
           set { TLFID = value; }
       }
       public long fmid
       {
           get { return FMID; }
           set { FMID = value; }
       }
       public long bulktankdetailno
       {
           get { return BulkTankDetailNo; }
           set { BulkTankDetailNo = value; }
       }
       public char sampletoretainer
       {
           get { return SampleToRetainer; }
           set { SampleToRetainer = value; }
       }
       public bool microdone
       {
           get { return MicroDone; }
           set { MicroDone = value; }
       }
       # endregion
       # region Functions

       public DataSet Select_PendingMicrobiologyDetails()
       {
           DataSet ds = new DataSet();
           ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_PendingMicrobiologyDetails");
           return ds;
       }

       public DataSet Select_ModificationMicrobiologyDetails()
       {
           DataSet ds = new DataSet();
           ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_ModificationMicrobiologyDetails");
           return ds;
       }

       public bool DELETE_tblMicrobiologytest_SampleDetails()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, tlfid);
               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_DELETE_tblMicrobiologytest_SampleDetails", myparam);
               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public bool DELETE_tblMicrobiologytest()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, tlfid);
               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_DELETE_tblMicrobiologytest", myparam);
               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public DataSet SELECT_tblMicrobiologytest_SampleDetails_MicroNo()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@MicroNo", SqlDbType.BigInt, 8, ParameterDirection.Input, microno);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblMicrobiologytest_SampleDetails_MicroNo", myparam);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public DataSet SELECT_MicrobiologyTestCorrection_MicroNo()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@MicroNo", SqlDbType.BigInt, 8, ParameterDirection.Input, microno);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_MicrobiologyTestCorrection_MicroNo", myparam);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public DataSet SELECT_MicrobiologyTestCorrection()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@ClearDate", SqlDbType.SmallDateTime,4,ParameterDirection.Input, cleardate);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_MicrobiologyTestCorrection", myparam);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public bool Insert_tblMicrobiologytest_SampleDetails()
       {
           try
           {
               SqlParameter[] myparam = new SqlParameter[12];
               myparam[0] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt,8, ParameterDirection.Input, tlfid);
               myparam[1] = ModHelper.CreateParameter("@BulkTankDetailNo", SqlDbType.BigInt,8, ParameterDirection.Input, bulktankdetailno);
               myparam[2] = ModHelper.CreateParameter("@FSD", SqlDbType.VarChar, 50, ParameterDirection.Input,fsd);
               myparam[3] = ModHelper.CreateParameter("@STS", SqlDbType.VarChar,50, ParameterDirection.Input, sts);
               myparam[4] = ModHelper.CreateParameter("@LBK", SqlDbType.VarChar, 50, ParameterDirection.Input, lbk);
               myparam[5] = ModHelper.CreateParameter("@EST", SqlDbType.VarChar, 50, ParameterDirection.Input, est);
               myparam[6] = ModHelper.CreateParameter("@LSD", SqlDbType.VarChar, 50, ParameterDirection.Input, lsd);
               myparam[7] = ModHelper.CreateParameter("@CM1", SqlDbType.VarChar,50, ParameterDirection.Input, cm1);
               myparam[8] = ModHelper.CreateParameter("@CM2", SqlDbType.VarChar, 50, ParameterDirection.Input, cm2);
               myparam[9] = ModHelper.CreateParameter("@CM3", SqlDbType.VarChar, 50, ParameterDirection.Input, cm3);
               myparam[10] = ModHelper.CreateParameter("@CM4", SqlDbType.VarChar, 50, ParameterDirection.Input, cm4);
               myparam[11] = ModHelper.CreateParameter("@CM5", SqlDbType.VarChar, 50, ParameterDirection.Input, cm5);
                              
               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblMicrobiologytest_SampleDetails", myparam);
               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public bool Update_tblMicrobiologytest()
       {
           try
           {
               //SqlParameter[] myparam = new SqlParameter[31];
               //myparam[0] = ModHelper.CreateParameter("@MicroNo_1", SqlDbType.BigInt, 8, ParameterDirection.Input, microno);
               //if (Innoc_Broth_Date != "")
               //{
               //    myparam[1] = ModHelper.CreateParameter("@Innoc_Broth_Date_2", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, Innoc_Broth_Date);
               //}
               //else
               //{
               //    myparam[1] = ModHelper.CreateParameter("@Innoc_Broth_Date_2", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DBNull.Value);
               //}
               //myparam[2] = ModHelper.CreateParameter("@Innoc_Broth_Time_3", SqlDbType.VarChar,50, ParameterDirection.Input, innoc_broth_time);
               //if (innoc_agar_date != "")
               //{
               //    myparam[3] = ModHelper.CreateParameter("@Innoc_Agar_Date_4", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, Innoc_Agar_Date);
               //}
               //else
               //{
               //    myparam[3] = ModHelper.CreateParameter("@Innoc_Agar_Date_4", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DBNull.Value);
               //}
               //myparam[4] = ModHelper.CreateParameter("@Innoc_Agar_Time_5", SqlDbType.VarChar,50, ParameterDirection.Input, innoc_agar_time);
               //if (Inccubation_Broth_Date != "")
               //{
               //    myparam[5] = ModHelper.CreateParameter("@Inccubation_Broth_Date_6", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, inccubation_broth_date);
               //}
               //else
               //{
               //    myparam[5] = ModHelper.CreateParameter("@Inccubation_Broth_Date_6", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DBNull.Value);
               //}
               //myparam[6] = ModHelper.CreateParameter("@Inccubation_Broth_Time_7", SqlDbType.VarChar,50, ParameterDirection.Input, inccubation_broth_time);
               //if (inccubation_agar_date != "")
               //{
               //    myparam[7] = ModHelper.CreateParameter("@Inccubation_Agar_Date_8", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, inccubation_agar_date);
               //}
               //else
               //{
               //    myparam[7] = ModHelper.CreateParameter("@Inccubation_Agar_Date_8", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DBNull.Value);
               //}
               //myparam[8] = ModHelper.CreateParameter("@Inccubation_Agar_Time_9", SqlDbType.VarChar,50, ParameterDirection.Input, inccubation_agar_time);
               //if (inccubation_other_date != "")
               //{
               //    myparam[9] = ModHelper.CreateParameter("@Inccubation_Other_Date_10", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, inccubation_other_date);
               //}
               //else
               //{
               //    myparam[9] = ModHelper.CreateParameter("@Inccubation_Other_Date_10", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DBNull.Value);
               //}
               //myparam[10] = ModHelper.CreateParameter("@Inccubation_Other_time_11", SqlDbType.VarChar,50, ParameterDirection.Input, inccubation_other_time);
               //myparam[11] = ModHelper.CreateParameter("@Inccub_Broth_Temp_12", SqlDbType.VarChar, 50, ParameterDirection.Input, Inccub_Broth_Temp);
               //myparam[12] = ModHelper.CreateParameter("@Inccub_Agar_Temp_13", SqlDbType.VarChar, 50, ParameterDirection.Input, Inccub_Agar_Temp);
               //if (result_broth_date != "")
               //{
               //    myparam[13] = ModHelper.CreateParameter("@Result_Broth_Date_14", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, result_broth_date);
               //}
               //else
               //{
               //    myparam[13] = ModHelper.CreateParameter("@Result_Broth_Date_14", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DBNull.Value);
               //}
               //myparam[14] = ModHelper.CreateParameter("@Result_Broth_Time_15", SqlDbType.VarChar,50, ParameterDirection.Input, result_broth_time);
               //if (Result_Agar_Date != "")
               //{
               //    myparam[15] = ModHelper.CreateParameter("@Result_Agar_Date_16", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, Result_Agar_Date);
               //}
               //else
               //{
               //    myparam[15] = ModHelper.CreateParameter("@Result_Agar_Date_16", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DBNull.Value);
               //}
               //myparam[16] = ModHelper.CreateParameter("@Result_Agar_Time_17", SqlDbType.VarChar,50, ParameterDirection.Input, Result_Agar_Time);
               //if (Result_Other_Date != "")
               //{
               //    myparam[17] = ModHelper.CreateParameter("@Result_Other_Date_18", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, Result_Other_Date);
               //}
               //else
               //{
               //    myparam[17] = ModHelper.CreateParameter("@Result_Other_Date_18", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DBNull.Value);
               //}
               //myparam[18] = ModHelper.CreateParameter("@Result_Other_Time_19", SqlDbType.VarChar,50, ParameterDirection.Input, result_other_time);
               //myparam[19] = ModHelper.CreateParameter("@TotalTime_Broth_20", SqlDbType.VarChar, 50, ParameterDirection.Input, TotalTime_Broth);
               //myparam[20] = ModHelper.CreateParameter("@TotalTime_Agar_21", SqlDbType.VarChar, 50, ParameterDirection.Input, totaltime_agar);
               //myparam[21] = ModHelper.CreateParameter("@TotalTime_Other_22", SqlDbType.VarChar, 50, ParameterDirection.Input, totaltime_other);
               //myparam[22] = ModHelper.CreateParameter("@Remarks_Broth_23", SqlDbType.VarChar, 50, ParameterDirection.Input, Remarks_Broth);
               //myparam[23] = ModHelper.CreateParameter("@Remarks_Agar_24", SqlDbType.VarChar, 50, ParameterDirection.Input, Remarks_Agar);
               //myparam[24] = ModHelper.CreateParameter("@Remarks_Other_25", SqlDbType.VarChar, 50, ParameterDirection.Input, Remarks_Other);
               //myparam[25] = ModHelper.CreateParameter("@Status_26", SqlDbType.Char,1, ParameterDirection.Input, status);
               //myparam[26] = ModHelper.CreateParameter("@BpcNonBpc_27", SqlDbType.Char, 1, ParameterDirection.Input, bpcnonbpc);
               //myparam[27] = ModHelper.CreateParameter("@NonBpcComments_28", SqlDbType.VarChar,250, ParameterDirection.Input, nonbpccomments);
               //myparam[28] = ModHelper.CreateParameter("@Comment_29", SqlDbType.VarChar, 250, ParameterDirection.Input, comments);
               //myparam[29] = ModHelper.CreateParameter("@LNo_30", SqlDbType.Int, 4, ParameterDirection.Input, lno);
               //myparam[30] = ModHelper.CreateParameter("@MediaLotNo_31", SqlDbType.VarChar, 50, ParameterDirection.Input, medialotno);
          
               //SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblMicrobiologytest", myparam);

               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public bool Insert_tblMicrobiologytest()
       {
           try
           {
               SqlParameter[] myparam = new SqlParameter[36];
               myparam[0] = ModHelper.CreateParameter("@ClearDate", SqlDbType.SmallDateTime,4, ParameterDirection.Input, cleardate);
               if (innoc_broth_date != "")
               {
                   myparam[1] = ModHelper.CreateParameter("@Innoc_Broth_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, innoc_broth_date);
               }
               else
               {
                   myparam[1] = ModHelper.CreateParameter("@Innoc_Broth_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DBNull.Value);
               }

               if (innoc_broth_time != "")
               {
                   myparam[2] = ModHelper.CreateParameter("@Innoc_Broth_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, innoc_broth_time);
               }
               else
               {
                   myparam[2] = ModHelper.CreateParameter("@Innoc_Broth_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, DBNull.Value);
               }

               if (innoc_agar_date != "")
               {
                   myparam[3] = ModHelper.CreateParameter("@Innoc_Agar_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, innoc_agar_date);
               }
               else
               {
                   myparam[3] = ModHelper.CreateParameter("@Innoc_Agar_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DBNull.Value);
               }
               if (innoc_agar_time != "")
               {
                   myparam[4] = ModHelper.CreateParameter("@Innoc_Agar_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, innoc_agar_time);
               }
               else
               {
                   myparam[4] = ModHelper.CreateParameter("@Innoc_Agar_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, DBNull.Value);
               }
               if (Inccubation_Broth_Date != "")
               {
                   myparam[5] = ModHelper.CreateParameter("@Inccubation_Broth_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, inccubation_broth_date);
               }
               else
               {
                   myparam[5] = ModHelper.CreateParameter("@Inccubation_Broth_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DBNull.Value);
               }

               if (inccubation_broth_time != "")
               {
                   myparam[6] = ModHelper.CreateParameter("@Inccubation_Broth_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, inccubation_broth_time);
               }
               else
               {
                   myparam[6] = ModHelper.CreateParameter("@Inccubation_Broth_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, DBNull.Value);
               }
               if (inccubation_agar_date != "")
               {
                   myparam[7] = ModHelper.CreateParameter("@Inccubation_Agar_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, Inccubation_Agar_Date);
               }
               else
               {
                   myparam[7] = ModHelper.CreateParameter("@Inccubation_Agar_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DBNull.Value);
               }

               if (Inccubation_Agar_Time != "")
               {
                   myparam[8] = ModHelper.CreateParameter("@Inccubation_Agar_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, Inccubation_Agar_Time);
               }
               else
               {
                   myparam[8] = ModHelper.CreateParameter("@Inccubation_Agar_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, DBNull.Value);
               }
               if (inccubation_other_date != "")
               {
                   myparam[9] = ModHelper.CreateParameter("@Inccubation_Other_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, Inccubation_Other_Date);
               }
               else
               {
                   myparam[9] = ModHelper.CreateParameter("@Inccubation_Other_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DBNull.Value);
               }

               if (inccubation_other_time != "")
               {
                   myparam[10] = ModHelper.CreateParameter("@Inccubation_Other_time", SqlDbType.VarChar, 50, ParameterDirection.Input, inccubation_other_time);
               }
               else
               {
                   myparam[10] = ModHelper.CreateParameter("@Inccubation_Other_time", SqlDbType.VarChar, 50, ParameterDirection.Input, DBNull.Value);
               }

               myparam[11] = ModHelper.CreateParameter("@Inccub_Broth_Temp", SqlDbType.NVarChar, 50, ParameterDirection.Input,Inccub_Broth_Temp);
               myparam[12] = ModHelper.CreateParameter("@Inccub_Agar_Temp", SqlDbType.NVarChar, 50, ParameterDirection.Input,Inccub_Agar_Temp);
               myparam[13] = ModHelper.CreateParameter("@Inccub_Other_Temp", SqlDbType.NVarChar, 50, ParameterDirection.Input, Inccub_Other_Temp);
               if (result_broth_date != "")
               {
                   myparam[14] = ModHelper.CreateParameter("@Result_Broth_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, Result_Broth_Date);
               }
               else
               {
                   myparam[14] = ModHelper.CreateParameter("@Result_Broth_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DBNull.Value);
               }

               if (Result_Broth_Time != "")
               {
                   myparam[15] = ModHelper.CreateParameter("@Result_Broth_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, Result_Broth_Time);
               }
               else
               {
                   myparam[15] = ModHelper.CreateParameter("@Result_Broth_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, DBNull.Value);
               }
               if (result_agar_date != "")
               {
                   myparam[16] = ModHelper.CreateParameter("@Result_Agar_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, Result_Agar_Date);
               }
               else
               {
                   myparam[16] = ModHelper.CreateParameter("@Result_Agar_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DBNull.Value);
               }

               if (Result_Agar_Time != "")
               {
                   myparam[17] = ModHelper.CreateParameter("@Result_Agar_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, Result_Agar_Time);
               }
               else
               {
                   myparam[17] = ModHelper.CreateParameter("@Result_Agar_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, DBNull.Value);
               }


               if (result_other_date != "")
               {
                   myparam[18] = ModHelper.CreateParameter("@Result_Other_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, Result_Other_Date);
               }
               else
               {
                   myparam[18] = ModHelper.CreateParameter("@Result_Other_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DBNull.Value);
               }
               if (Result_Other_Time != "")
               {
                   myparam[19] = ModHelper.CreateParameter("@Result_Other_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, Result_Other_Time);
               }
               else
               {
                   myparam[19] = ModHelper.CreateParameter("@Result_Other_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, DBNull.Value);
               }
               myparam[20] = ModHelper.CreateParameter("@TotalTime_Broth", SqlDbType.VarChar, 50, ParameterDirection.Input,TotalTime_Broth);
               myparam[21] = ModHelper.CreateParameter("@TotalTime_Agar", SqlDbType.VarChar, 50, ParameterDirection.Input,TotalTime_Agar);
               myparam[22] = ModHelper.CreateParameter("@TotalTime_Other", SqlDbType.VarChar, 50, ParameterDirection.Input,TotalTime_Other);
               myparam[23] = ModHelper.CreateParameter("@Remarks_Broth", SqlDbType.VarChar, 250, ParameterDirection.Input, Remarks_Broth);
               myparam[24] = ModHelper.CreateParameter("@Remarks_Agar", SqlDbType.VarChar, 250, ParameterDirection.Input, Remarks_Agar);
               myparam[25] = ModHelper.CreateParameter("@Remarks_Other", SqlDbType.VarChar, 250, ParameterDirection.Input, Remarks_Other);
               myparam[26] = ModHelper.CreateParameter("@Status", SqlDbType.Char,1, ParameterDirection.Input, status);
               myparam[27] = ModHelper.CreateParameter("@BpcNonBpc", SqlDbType.Char, 1, ParameterDirection.Input, BpcNonBpc);
               myparam[28] = ModHelper.CreateParameter("@NonBpcComments", SqlDbType.VarChar, 250, ParameterDirection.Input, NonBpcComments);
               myparam[29] = ModHelper.CreateParameter("@Comment", SqlDbType.VarChar, 250, ParameterDirection.Input, comments);
               myparam[30] = ModHelper.CreateParameter("@MediaLotNo", SqlDbType.VarChar, 50, ParameterDirection.Input, medialotno);
               myparam[31] = ModHelper.CreateParameter("@SampleToRetainer", SqlDbType.Char, 1, ParameterDirection.Input, sampletoretainer);
               myparam[32] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, tlfid);
               myparam[33] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
               myparam[34] = ModHelper.CreateParameter("@InspectedBy", SqlDbType.Int, 4, ParameterDirection.Input, inspectedby);              
               myparam[35] = ModHelper.CreateParameter("@MicroNo", SqlDbType.BigInt,8, ParameterDirection.Output);
               
               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblMicrobiologytest", myparam);
               //microno =Convert.ToInt64(myparam[35].Value);
               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public bool Update_tblTransTLF_MicroDone()
       {
           try
           {
               SqlParameter[] myparam = new SqlParameter[2];
               myparam[0] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, tlfid);
               myparam[1] = ModHelper.CreateParameter("@MicroDone", SqlDbType.Bit, 1, ParameterDirection.Input, microdone);
               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblTransTLF_MicroDone", myparam);
               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public DataSet Select_MicrobiologyDetails_DetailsNo()
       {
           DataSet ds = new DataSet();
           SqlParameter[] myparam = new SqlParameter[3];
           myparam[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
           //myparam[1] = ModHelper.CreateParameter("@TrackCode", SqlDbType.SmallDateTime, 4, ParameterDirection.Input,trackcode);
           myparam[1] = ModHelper.CreateParameter("@TrackCode", SqlDbType.VarChar,20, ParameterDirection.Input, trackcode);
           myparam[2] = ModHelper.CreateParameter("@LNo", SqlDbType.Int, 4, ParameterDirection.Input, lno);
           ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_MicrobiologyDetails_DetailsNo", myparam);
           return ds;
       }

       public DataSet Select_MicrobiologyDetails_TLFID()
       {
           DataSet ds = new DataSet();
           SqlParameter[] myparam=new SqlParameter[1];
           myparam[0] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, tlfid);
           ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_MicrobiologyDetails_TLFID", myparam);
           return ds;
       }
       public DataSet Select_Microbiology_Tank()
       {
           DataSet ds = new DataSet();
           SqlParameter[] myparam = new SqlParameter[1];
           myparam[0] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, tlfid);
           ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_Microbiology_Tank", myparam);
           return ds;
       }
       public DataSet Select_tblMicrobiologytest_TLFID()
       {
           DataSet ds = new DataSet();
           SqlParameter[] myparam = new SqlParameter[1];
           myparam[0] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, tlfid);
           ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblMicrobiologytest_TLFID", myparam);
           return ds;
       }
           
       

       # endregion
   }
}
