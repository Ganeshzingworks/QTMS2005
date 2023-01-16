using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;

namespace BusinessFacade
{
   public  class AgitationMaster_Class
    {

        # region Varibles
       private string  Timefield;
       private string Rpm;
       private string AgitationTypes;
       private int AgitationNo;
       private int Id;
        # endregion
        # region Properties
        
       public string timefield
        {
            get { return Timefield; }
            set { Timefield = value; }
        }

       public string rpm
       {
           get { return Rpm; }
           set { Rpm = value; }
       }

       public string agitationTypes
       {
           get { return AgitationTypes; }
           set { AgitationTypes = value; }
       }

       public int agitationNo
       {
           get { return AgitationNo; }
           set { AgitationNo = value; }
       }

       public int id
       {
           get { return Id; }
           set { Id = value; }
       }





        # endregion
        # region Functions
       public DataSet Select_tblAgitationRpm()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblAgitationRpm");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       public DataSet Select_tblAgitationRpm_time()
       {
           try
           {
               DataSet ds = new DataSet();
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblAgitationRpm_time ");
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public DataSet Select_tblAgitationRpm_id ()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@Id", SqlDbType.Int,4,  ParameterDirection.Input,id);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblAgitationRpm_id", myparam);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }



       public bool Insert_tblAgitationRpm()
       {
           try
           {
               SqlParameter[] myparam = new SqlParameter[4];

               myparam[0] = ModHelper.CreateParameter("@Timefield", SqlDbType.VarChar, 250, ParameterDirection.Input,timefield );
               myparam[1] = ModHelper.CreateParameter("@Rpm", SqlDbType.VarChar, 250, ParameterDirection.Input,rpm);
               myparam[2] = ModHelper.CreateParameter("@AgitationTypes", SqlDbType.VarChar, 250, ParameterDirection.Input,AgitationTypes);
               myparam[3] = ModHelper.CreateParameter("@AgitationNo", SqlDbType.Int,4 , ParameterDirection.Input,agitationNo);
               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblAgitationRpm", myparam);
               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }


       public bool Update_tblAnnexTankMaster()
       {
           try
           {

               SqlParameter[] myparam = new SqlParameter[5];
               myparam[0] = ModHelper.CreateParameter("@Id", SqlDbType.BigInt, 8, ParameterDirection.Input, id);
               myparam[1] = ModHelper.CreateParameter("@Timefield", SqlDbType.VarChar, 250, ParameterDirection.Input, timefield);
               myparam[2] = ModHelper.CreateParameter("@Rpm", SqlDbType.VarChar, 250, ParameterDirection.Input, rpm);
               myparam[3] = ModHelper.CreateParameter("@AgitationTypes", SqlDbType.VarChar, 250, ParameterDirection.Input, AgitationTypes);
               myparam[4] = ModHelper.CreateParameter("@AgitationNo", SqlDbType.Int, 4, ParameterDirection.Input, agitationNo);
               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblAgitationRpm", myparam);
               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }


       public bool Delete_tblAgitationRpm()
       {
           try
           {

               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@Id", SqlDbType.BigInt, 8, ParameterDirection.Input,id);
               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblAgitationRpm", myparam);
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
