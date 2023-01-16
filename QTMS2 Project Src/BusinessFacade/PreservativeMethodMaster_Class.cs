using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;
namespace BusinessFacade
{
   public class PreservativeMethodMaster_Class
   {
       # region Varibles
       private long FNo;
       private int Prsno;
       private long PresMethodNo;
       private int TestNo;
       private string Min;
       private string Max;
       private int Del;
       # endregion
       # region Properties
       public int del
       {
           get { return Del; }
           set { Del = value; }
       }
       public long fno
       {
           get { return FNo; }
           set { FNo = value; }
       }
       public int prsno
       {
           get { return Prsno; }
           set { Prsno = value; }
       }
       public long presmethodno
       {
           get { return PresMethodNo; }
           set { PresMethodNo = value; }
       }
       public int testno
       {
           get { return TestNo; }
           set { TestNo = value; }
       }
       public string min
       {
           get { return Min; }
           set { Min = value; }
       }
       public string max
       {
           get { return Max; }
           set { Max = value; }
       }
       # endregion
       # region Functions
       public bool DELETE_tblPreservativeMethodMaster()
       {
           SqlParameter[] myparam = new SqlParameter[1];
           myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
           SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_DELETE_tblPreservativeMethodMaster", myparam);
           return true;
       }

       public bool Update_tblPreservativeMethodMaster_FNo_Del()
       {
           SqlParameter[] myparam = new SqlParameter[2];
           myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
           myparam[1] = ModHelper.CreateParameter("@Del", SqlDbType.Bit, 1, ParameterDirection.Input, del);
           SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblPreservativeMethodMaster_FNo_Del", myparam);
           return true;
       }
             
       public DataSet SELECT_tblPreservativeMethodMaster_tblBulkMaster_tblPreservativeMaster()
       {
           DataSet ds = new DataSet();
           SqlParameter[] myparam = new SqlParameter[1];
           myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
           ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblPreservativeMethodMaster_tblBulkMaster_tblPreservativeMaster", myparam);
           return ds;
       }

       public DataSet SELECT_tblPreservativeMethodMaster_tblBulkMaster()
       {
           DataSet ds = new DataSet();
           ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblPreservativeMethodMaster_tblBulkMaster");
           return ds;
       }

       public void Insert_tblPreservativeMethodMaster()
       {
           try
           {
               SqlParameter[] myparam = new SqlParameter[4];
               myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
               myparam[1] = ModHelper.CreateParameter("@PrsNo", SqlDbType.Int, 4, ParameterDirection.Input, testno);
               myparam[2] = ModHelper.CreateParameter("@NormsMin", SqlDbType.VarChar, 50, ParameterDirection.Input, min);
               myparam[3] = ModHelper.CreateParameter("@NormsMax", SqlDbType.VarChar, 50, ParameterDirection.Input, max);

               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblPreservativeMethodMaster", myparam);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public void Update_tblPreservativeMethodMaster()
       {
           try
           {
               SqlParameter[] myparam = new SqlParameter[4];
               myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
               myparam[1] = ModHelper.CreateParameter("@PrsNo", SqlDbType.Int, 4, ParameterDirection.Input, testno);
               myparam[2] = ModHelper.CreateParameter("@NormsMin", SqlDbType.VarChar, 50, ParameterDirection.Input, min);
               myparam[3] = ModHelper.CreateParameter("@NormsMax", SqlDbType.VarChar, 50, ParameterDirection.Input, max);


               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblPreservativeMethodMaster", myparam);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public bool Delete_tblPreservativeMethodMaster_Prsno()
       {
           try
           {
               SqlParameter[] myaparam = new SqlParameter[2];
               myaparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
               myaparam[1] = ModHelper.CreateParameter("@PrsNo", SqlDbType.Int, 4, ParameterDirection.Input, testno);
               SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_Delete_tblPreservativeMethodMaster_Prsno", myaparam);

               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public bool Update_tblPreservativeMethodMaster_Del()
       {
           try
           {
               SqlParameter[] myaparam = new SqlParameter[3];
               myaparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
               myaparam[1] = ModHelper.CreateParameter("@PrsNo", SqlDbType.Int, 4, ParameterDirection.Input, testno);
               myaparam[2] = ModHelper.CreateParameter("@Del", SqlDbType.Bit, 1, ParameterDirection.Input, del);
               SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_Update_tblPreservativeMethodMaster_Del", myaparam);

               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       # endregion
   }
}
