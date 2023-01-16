using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;
namespace BusinessFacade
{
   public class PreservetiveMaster_Class
   {
       # region Varibles
       private string PresType;
       private string Concent;
       private int Prsno;
       private string PresFormula;
       # endregion
       # region Properties
       public string prestype
       {
           get { return PresType; }
           set { PresType = value; }
       }
       public string presformula
       {
           get { return PresFormula; }
           set { PresFormula = value; }
       }
       public string concent
       {
           get { return Concent; }
           set { Concent = value; }
       }
       public int prsno
       {
           get { return Prsno; }
           set { Prsno = value; }
       }
       # endregion
       # region Functions
       public DataSet STP_Select_tblPreservativeMaster()
       {
           try
           {
               DataSet ds = new DataSet();
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblPreservativeMaster");
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }

       }
       public DataSet Select_tblPreservativeMaster_Prsno()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@Prsno", SqlDbType.Int, 4, ParameterDirection.Input, prsno);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblPreservativeMaster_Prsno", myparam);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;

           }

       }
       public bool Insert_tblPreservativeMaster()
       {
           try
           {
               SqlParameter[] myaparam = new SqlParameter[2];
               myaparam[0] = ModHelper.CreateParameter("@PresType", SqlDbType.NVarChar, 250, ParameterDirection.Input, prestype);
               myaparam[1] = ModHelper.CreateParameter("@PresFormula", SqlDbType.NVarChar, 50, ParameterDirection.Input, presformula);
               SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_Insert_tblPreservativeMaster", myaparam);
               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public bool Update_tblPreservativeMaster()
       {
           try
           {
               SqlParameter[] myparam = new SqlParameter[3];
               myparam[0] = ModHelper.CreateParameter("@Prsno", SqlDbType.Int, 4, ParameterDirection.Input, prsno);
               myparam[1] = ModHelper.CreateParameter("@PresType", SqlDbType.NVarChar, 250, ParameterDirection.Input, prestype);
               myparam[2] = ModHelper.CreateParameter("@PresFormula", SqlDbType.NVarChar, 50, ParameterDirection.Input, presformula);
               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblPreservativeMaster", myparam);
               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public bool Delete_tblPreservativeMaster()
       {
           try
           {
               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@Prsno", SqlDbType.Int, 4, ParameterDirection.Input, Prsno);
               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblPreservativeMaster", myparam);
               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       # endregion

       public DataSet Select_All_Record_tblPreservativeMaster()
       {
           try
           {
               DataSet ds = new DataSet();
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "SP_Select_All_tblPreservativeMaster");
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }


       }
   }
}
