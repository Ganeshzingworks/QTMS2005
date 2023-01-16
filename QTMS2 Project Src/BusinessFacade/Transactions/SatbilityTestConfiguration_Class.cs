using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;

namespace BusinessFacade.Transactions
{
   public class SatbilityTestConfiguration_Class
   {
       # region Variables
       private long FNo;
       public long fno
       {
           get { return FNo; }
           set { FNo = value; }
       }

       private string Week1Date;
       public string week1date
       {
           get { return Week1Date; }
           set { Week1Date = value; }
       }

       private string CreatedOn;
       public string createdon
       {
           get { return CreatedOn; }
           set { CreatedOn = value; }
       }

       private string FormulaNo;
       public string formulano
       {
           get { return FormulaNo; }
           set { FormulaNo = value; }
       }

       # endregion

       public DataSet SELECT_NewLunch_FormulaNo()
       {
           try
           {
               DataSet ds = new DataSet();
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_NewLunch_FormulaNo");
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }

       }

       public DataSet SELECT_StabilityTestConfi_NewLunch_FormulaNoDetails()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myaparam = new SqlParameter[1];
               myaparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_StabilityTestConfi_NewLunch_FormulaNoDetails", myaparam);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }

       }

       public bool Insert_tblStabilityTestConfiguration_Details()
       {
           try
           {
               SqlParameter[] myparam = new SqlParameter[2];
               myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.Int, 8, ParameterDirection.Input, fno);
               myparam[1] = ModHelper.CreateParameter("@Week1Date", SqlDbType.VarChar, 50, ParameterDirection.Input, week1date);
              // myparam[2] = ModHelper.CreateParameter("@CreatedOn", SqlDbType.VarChar, 200, ParameterDirection.Input, createdon);
               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_INSERT_tblStabilityTestConfiguration_Details", myparam);
               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       

       public DataSet Check_StabilityTestConfi_NewLunch_Week1Date()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myaparam = new SqlParameter[1];
               myaparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Check_StabilityTestConfi_NewLunch_Week1Date", myaparam);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }

       }

    }
}
