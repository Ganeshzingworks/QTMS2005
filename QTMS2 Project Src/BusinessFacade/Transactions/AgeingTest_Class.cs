using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;

namespace BusinessFacade.Transactions
{
   public class AgeingTest_Class
   {
       #region Varibles

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
       private long TestNo;
       public long testno
       {
           get { return TestNo; }
           set { TestNo = value; }
       }
       private string NormsMin;
       public string normsmin
       {
           get { return NormsMin; }
           set { NormsMin = value; }
       }
       private string NormsMax;
       public string normsmax
       {
           get { return NormsMax; }
           set { NormsMax = value; }
       }
       private string Status;
       public string status
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

       private string Description;
       public string description
       {
           get { return Description; }
           set { Description = value; }
       }
       private string QPFStatus;
       public string qpfstatus
       {
           get { return QPFStatus; }
           set { QPFStatus = value; }
       }
       private string QPFComment;
       public string qpfcomment
       {
           get { return QPFComment; }
           set { QPFComment = value; }
       }
       private string Confirmation;
       public string confirmation
       {
           get { return Confirmation; }
           set { Confirmation = value; }
       }
       private string AgeingResultComment;
       public string ageingresultcomment
       {
           get { return AgeingResultComment; }
           set { AgeingResultComment = value; }
       }

       private int VerifiedBy;
       public int verifiedby
       {
           get { return VerifiedBy; }
           set { VerifiedBy = value; }
       }
       private int CheckedBy;
       public int checkedby
       {
           get { return CheckedBy; }
           set { CheckedBy = value; }
       }
       private string FileName;
       public string filename
       {
           get { return FileName; }
           set { FileName = value; }
       }

       #endregion

       public DataSet SELECT_FormulaNo_For_AgeingTest()
       {
           try
           {
               DataSet ds = new DataSet();
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_FormulaNo_For_AgeingTest");
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }

       }

       public DataSet SELECT_LineSampleTest_FNo()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_LineSampleTest_FNo", myparam);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;

           }

       }

       public DataSet SELECT_LineSampleTest_For_Update()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_LineSampleTest_For_Update", myparam);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;

           }

       }

       public DataSet SELECT_TransFMDetails_For_AgeingTest()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_TransFMDetails_For_AgeingTest", myparam);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;

           }

       }

       public DataSet SELECT_tblQPF_MC_AgeingTest_For_Update()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblQPF_MC_AgeingTest_For_Update", myparam);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;

           }

       }


       public DataSet Check_AgeingTest_For_Update()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Check_AgeingTest_For_Update", myparam);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;

           }

       }

       public bool INSERT_tblAgeingTestDetails()
       {
           try
           {
               SqlParameter[] myparam = new SqlParameter[7];
               myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.Int, 8, ParameterDirection.Input, fno);
               myparam[1] = ModHelper.CreateParameter("@FMID", SqlDbType.Int, 8, ParameterDirection.Input, fmid);
               myparam[2] = ModHelper.CreateParameter("@TestNo", SqlDbType.Int, 8, ParameterDirection.Input, testno);
               myparam[3] = ModHelper.CreateParameter("@NormsMin", SqlDbType.VarChar, 50, ParameterDirection.Input, normsmin);
               myparam[4] = ModHelper.CreateParameter("@NormsMax", SqlDbType.VarChar, 50, ParameterDirection.Input, normsmax);
               myparam[5] = ModHelper.CreateParameter("@Status", SqlDbType.VarChar, 250, ParameterDirection.Input, status);
               myparam[6] = ModHelper.CreateParameter("@Comment", SqlDbType.VarChar, 250, ParameterDirection.Input, comment);

               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_INSERT_tblAgeingTestDetails", myparam);
               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public bool INSERT_tblQPF_MC_AgeingTestDetails()
       {
           try
           {
               SqlParameter[] myparam = new SqlParameter[9];
               myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.Int, 8, ParameterDirection.Input, fno);
               myparam[1] = ModHelper.CreateParameter("@FMID", SqlDbType.Int, 8, ParameterDirection.Input, fmid);
               myparam[2] = ModHelper.CreateParameter("@Description", SqlDbType.VarChar, 50, ParameterDirection.Input, description);
               myparam[3] = ModHelper.CreateParameter("@QPFStatus", SqlDbType.VarChar, 250, ParameterDirection.Input, qpfstatus);
               myparam[4] = ModHelper.CreateParameter("@QPFComment", SqlDbType.VarChar, 250, ParameterDirection.Input, qpfcomment);
               myparam[5] = ModHelper.CreateParameter("@Confirmation", SqlDbType.VarChar, 50, ParameterDirection.Input, confirmation);
               myparam[6] = ModHelper.CreateParameter("@AgeingResultComment", SqlDbType.VarChar, 250, ParameterDirection.Input, ageingresultcomment);
               myparam[7] = ModHelper.CreateParameter("@CheckedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, CheckedBy);
               myparam[8] = ModHelper.CreateParameter("@VerifiedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, verifiedby);

               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_INSERT_QPF_MC_AgeingTestDetails", myparam);
               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }


       public DataSet STP_Update_tblAgeingTestReminder()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myaparam = new SqlParameter[2];
               myaparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
               myaparam[1] = ModHelper.CreateParameter("@FileName", SqlDbType.VarChar, 50, ParameterDirection.Input, filename);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Update_tblAgeingTestReminder", myaparam);

               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public bool Update_tblAgeingTestDetails()
       {
           try
           {
               SqlParameter[] myparam = new SqlParameter[4];
               myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.Int, 8, ParameterDirection.Input, fno);
               myparam[1] = ModHelper.CreateParameter("@TestNo", SqlDbType.Int, 8, ParameterDirection.Input, testno);
               myparam[2] = ModHelper.CreateParameter("@Status", SqlDbType.VarChar, 250, ParameterDirection.Input, status);
               myparam[3] = ModHelper.CreateParameter("@Comment", SqlDbType.VarChar, 250, ParameterDirection.Input, comment);

               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_AgeingTest_Details", myparam);
               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public bool Update_tblQPF_MC_AgeingTestDetails()
       {
           try
           {
               SqlParameter[] myparam = new SqlParameter[7];
               myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.Int, 8, ParameterDirection.Input, fno);
               myparam[1] = ModHelper.CreateParameter("@QPFStatus", SqlDbType.VarChar, 250, ParameterDirection.Input, qpfstatus);
               myparam[2] = ModHelper.CreateParameter("@QPFComment", SqlDbType.VarChar, 250, ParameterDirection.Input, qpfcomment);
               myparam[3] = ModHelper.CreateParameter("@Confirmation", SqlDbType.VarChar, 250, ParameterDirection.Input, confirmation);
               myparam[4] = ModHelper.CreateParameter("@AgeingResultComment", SqlDbType.VarChar, 250, ParameterDirection.Input, ageingresultcomment);
               myparam[5] = ModHelper.CreateParameter("@CheckedBy", SqlDbType.Int, 8, ParameterDirection.Input, checkedby);
               myparam[6] = ModHelper.CreateParameter("@VerifiedBy", SqlDbType.Int, 8, ParameterDirection.Input, verifiedby);

               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblQPF_MC_AgeingTest_Details", myparam);
               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }


       public DataSet SELECT_FormulaNo_For_AgeingTest_Report()
       {
           try
           {
               DataSet ds = new DataSet();
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_FormulaNo_For_AgeingTest_Report");
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }

       }

       public DataSet SELECT_View_AgeingTest_Report()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_View_AgeingTest_Report", myparam);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
   }
}
