using System;
using System.Collections.Generic;
using System.Text;
using DataFacade;
using System.Data;
using System.Data.SqlClient;
 
namespace BusinessFacade
{
   public  class ReagentMaster_Class
    {

        # region Varibles
       private string RACode;
       private string ReagentName;
       private int ReorderLevel;
       private string NormalityUnit;
       private int LoginID;
       private long  ReagentID;
       private string Symb;
        #endregion

        #region Properties

       public string racode
       {
           get { return RACode; }
           set { RACode = value; }
       }

       public string reagentname
       {
           get { return ReagentName; }
           set { ReagentName = value; }
       }

       public int reorderlevel
       {
           get { return ReorderLevel; }
           set { ReorderLevel = value; }
       }
       public string normalityunit
       {
           get { return NormalityUnit; }
           set { NormalityUnit = value; }
       }
       public int loginid 
       {
           get { return LoginID; }
           set { LoginID = value; }
       }

       public long reagentid 
       {
           get { return ReagentID; }
           set { ReagentID = value; }
       }
       public string symb
       {
           get { return Symb; }
           set { Symb = value; }
       }
        #endregion

        #region Functions

       

       public bool Insert_tblReagentMaster()
       {
           try
           {
               int active = 1;
               
               SqlParameter[] myparam = new SqlParameter[9];
               myparam[0] = ModHelper.CreateParameter("@RACode", SqlDbType.VarChar, 250, ParameterDirection.Input, racode );
               myparam[1] = ModHelper.CreateParameter("@ReagentName", SqlDbType.VarChar, 500, ParameterDirection.Input, reagentname );
               myparam[2] = ModHelper.CreateParameter("@ReorderLevel", SqlDbType.Int, 250, ParameterDirection.Input, reorderlevel );
               myparam[3] = ModHelper.CreateParameter("@NormalityUnit", SqlDbType.VarChar, 250, ParameterDirection.Input, normalityunit );
               myparam[4] = ModHelper.CreateParameter("@Active", SqlDbType.Int, 4, ParameterDirection.Input, active);
               myparam[5] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.Int , 4, ParameterDirection.Input, loginid);
               myparam[6] = ModHelper.CreateParameter("@ModifiedBy", SqlDbType.VarChar, 50, ParameterDirection.Input, DBNull.Value );
               myparam[7] = ModHelper.CreateParameter("@ModifiedDate", SqlDbType.VarChar, 250, ParameterDirection.Input, DBNull.Value );
               myparam[8] = ModHelper.CreateParameter("@Symb", SqlDbType.VarChar, 400, ParameterDirection.Input, Symb);
               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblReagentMaster", myparam);
               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public DataSet Select_tblReagent_Normality()
       {
           try
           {
               DataSet ds = new DataSet();
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblReagentUnit");
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public bool Update_tblReagentMaster()
       {
           try
           {

               SqlParameter[] myparam = new SqlParameter[7];
               myparam[0] = ModHelper.CreateParameter("@ReagentID", SqlDbType.BigInt, 8, ParameterDirection.Input, reagentid);
               myparam[1] = ModHelper.CreateParameter("@RACode", SqlDbType.VarChar, 50, ParameterDirection.Input, racode );
               myparam[2] = ModHelper.CreateParameter("@ReagentName", SqlDbType.VarChar, 250, ParameterDirection.Input, reagentname);
               myparam[3] = ModHelper.CreateParameter("@ReorderLevel", SqlDbType.Int, 4, ParameterDirection.Input, reorderlevel );
               myparam[4] = ModHelper.CreateParameter("@NormalityUnit", SqlDbType.VarChar, 250, ParameterDirection.Input, normalityunit);
               myparam[5] = ModHelper.CreateParameter("@ModifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, loginid );
               myparam[6] = ModHelper.CreateParameter("@Symb", SqlDbType.VarChar, 400, ParameterDirection.Input, Symb);
               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblReagentMaster", myparam);
               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public DataSet Select_tblReagenMaster_RACode()
       {
           try
           {
               DataSet ds = new DataSet();
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblReagentMAster_RACode");
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public DataSet Select_tblReagentMaster_Details()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@ReagentID", SqlDbType.BigInt, 8, ParameterDirection.Input, reagentid);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblReagentMaster_Details", myparam);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public bool  Delete_Selected_Record()
       {
           try
           {

               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@ReagentID", SqlDbType.BigInt, 8, ParameterDirection.Input, reagentid);
               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_Delete_tblReagentMaster", myparam);
               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }


     

       public DataSet Check_Transaction_Count(long ReagentID)
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@ReagentID", SqlDbType.BigInt, 8, ParameterDirection.Input, reagentid);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_tblReagentTransaction_CheckDelete_Count", myparam);
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
