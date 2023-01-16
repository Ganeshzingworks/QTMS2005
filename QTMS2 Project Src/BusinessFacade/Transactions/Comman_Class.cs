using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DataFacade;

namespace BusinessFacade.Transactions
{
   public class Comman_Class
   {
       # region Functions
       public DateTime Select_ServerDate()
       {
           try
           {
              return Convert.ToDateTime(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_Select_Serverdate"));
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       # endregion
   }
}
