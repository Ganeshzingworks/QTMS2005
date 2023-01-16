using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;

namespace BusinessFacade
{
    public class CountryMaster_Class
    {
        public CountryMaster_Class()
        {
            //
            // To Do Add Constructor Logic
        }
        #region Variable
        private int CountryID;
        private string CountryName;

        #endregion

        #region Properties
        public int countryid
        {
            get { return CountryID; }
            set { CountryID = value; }
        }
        public string countryname
        {
            get { return CountryName; }
            set { CountryName = value; }
        }
        #endregion

        #region Function
        public DataTable Select_CountryMaster()
        {
            try
            {
                DataTable Dt = new DataTable();
                Dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure,"STP_Select_CountryMaster").Tables[0];
                return Dt;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public bool Insert_CountryMaster()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@Country", SqlDbType.NVarChar, 50, ParameterDirection.Input, countryname);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"STP_Insert_tblCountryMaster",param);
                return true;                
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
        public bool Update_CountryMaster()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = ModHelper.CreateParameter("@CountryID", SqlDbType.BigInt, 8, ParameterDirection.Input, countryid);
                param[1] = ModHelper.CreateParameter("@Country", SqlDbType.NVarChar, 50, ParameterDirection.Input, countryname);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblCountryMaster", param);
                return true;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        public bool Delete_CountryMaster()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@CountryID", SqlDbType.BigInt, 8, ParameterDirection.Input, countryid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblCountryMaster", param);
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
