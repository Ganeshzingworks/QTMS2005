using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;

namespace BusinessFacade
{
    public class LocationMaster_Class
    {
        public LocationMaster_Class()
        {
            //
            //To Do Add Constructor Logic
            //
        }

        #region Variable
        private int LocID;
        private string LocationName;

        #endregion

        #region Properties
        public int locid
        {
            get { return LocID; }
            set { LocID = value; }
        }
        public string locationname
        {
            get { return LocationName; }
            set { LocationName = value; }
        }
        #endregion

        #region Function
        public DataTable Select_LocationMaster()
        {
            try
            {
                DataTable Dt = new DataTable();
                Dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_LocationMaster").Tables[0];
                return Dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Insert_LocationMaster()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@Location", SqlDbType.NVarChar, 50, ParameterDirection.Input, locationname);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblReferenceLocation", param);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update_LocationMaster()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = ModHelper.CreateParameter("@LocID", SqlDbType.BigInt, 8, ParameterDirection.Input, locid);
                param[1] = ModHelper.CreateParameter("@Location", SqlDbType.NVarChar, 50, ParameterDirection.Input, locationname);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblReferenceLocation", param);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete_LocationMaster()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@LocID", SqlDbType.BigInt, 8, ParameterDirection.Input, locid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblReferenceLocation", param);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion 
    }
}
