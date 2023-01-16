using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;
namespace BusinessFacade
{
   public class FgFamilyMethodMaster_Class
   {
       # region Varibles
       private int PKGTechNo;
       private int MethodNo;
       # endregion
       # region Properties
       public int pkgtechno
       {
           get { return PKGTechNo; }
           set { PKGTechNo = value; }
       }
       public int methodno
       {
           get { return MethodNo; }
           set { MethodNo = value; }
       }
       # endregion
       # region Functions
       public DataSet Select_FGFamilyMethodMaster()
       {
           try
           {
               DataSet ds = new DataSet();
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_TblFgFamMethodMaster");
               return ds;
           }
           catch (Exception ex)
           {
               
               throw ex;
           }
       }
       public bool Insert_FGFamilyMethodMaster()
       {
           try
           {
               SqlParameter[] myparam = new SqlParameter[2];
               myparam[0] = ModHelper.CreateParameter("@PKGTechNo", SqlDbType.Int, 4, ParameterDirection.Input, PKGTechNo);
               myparam[1] = ModHelper.CreateParameter("@MethodNo", SqlDbType.Int, 4, ParameterDirection.Input, methodno);
               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_INSERT_TblFgFamMethodMaster", myparam);
               return true;

           }
           catch (Exception)
           {
               
               throw;
           }
       }
       public bool Delete_FGFamilyMethodMaster()
       {
           try
           {
               SqlParameter[] myparam = new SqlParameter[2];
               myparam[0] = ModHelper.CreateParameter("@PKGTechNo", SqlDbType.Int, 4, ParameterDirection.Input, PKGTechNo);
               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_TblFgFamMethodMaster", myparam);
               return true;
           }
           catch (Exception)
           {
               
               throw;
           }
       }
       public DataSet Select_FGFamilyMethodMaster_PkgNo()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@PKGTechNo", SqlDbType.Int, 4, ParameterDirection.Input, PKGTechNo);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_TblFgFamMethodMaster_PkgTechNo", myparam);
               return ds;
           }
           catch (Exception)
           {
               
               throw;
           }
       }
       # endregion
   }
}
