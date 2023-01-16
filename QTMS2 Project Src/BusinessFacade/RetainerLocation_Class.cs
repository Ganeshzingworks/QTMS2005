using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;
namespace BusinessFacade
{
    public class RetainerLocation_Class
    {
        #region Varibles

        private long LocationID;
        private string Location;
        private long CreatedBy;
        private long ModifiedBy;
        private long DistructionID;
        private long TLFID;

       
	
        #endregion
        #region Properties
        public long locationid
        {
            get { return LocationID; }
            set { LocationID = value; }
        }
        public string location
        {
            get { return Location; }
            set { Location = value; }
        }
        public long createdby
        {
            get { return CreatedBy; }
            set { CreatedBy = value; }
        }
        public long modifiedby
        {
            get { return ModifiedBy; }
            set { ModifiedBy = value; }
        }
        public long distructionid
        {
            get { return DistructionID; }
            set { DistructionID = value; }
        }
        public long tlfid
        {
            get { return TLFID; }
            set { TLFID = value; }
        }
        #endregion
        #region Functions

        public DataSet Select_tblRetainerLocation()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRetainerLocation");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_Distruct_tblRetainerLocation()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_Distruct_tblRetainerLocation");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_Distruct_tblRetainerLocation_Report(DateTime fromdate)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@date", SqlDbType.DateTime, 8, ParameterDirection.Input, fromdate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_Distruct_tblRetainerLocation_Report",myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblRetainerLocation_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRetainerLocation_Report");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
 
        public DataSet Select_RMRetainerLocation()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMRetainerLocation");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Insert_tblRetainerLocation()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@Location", SqlDbType.VarChar, 50, ParameterDirection.Input, location);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblRetainerLocation", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert_RMRetainerLocation()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@Location", SqlDbType.VarChar, 50, ParameterDirection.Input, location);
                myparam[1] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, createdby);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblRMRetainerLocation", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update_tblRetainerLocation()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@LocationID", SqlDbType.BigInt, 8, ParameterDirection.Input, locationid);
                myparam[1] = ModHelper.CreateParameter("@Location", SqlDbType.VarChar, 50, ParameterDirection.Input, location);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblRetainerLocation", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update_RMRetainerLocation()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@LocationID", SqlDbType.BigInt, 8, ParameterDirection.Input, locationid);
                myparam[1] = ModHelper.CreateParameter("@Location", SqlDbType.VarChar, 50, ParameterDirection.Input, location);
                myparam[2] = ModHelper.CreateParameter("@ModifiedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, modifiedby);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblRMRetainerLocation", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete_tblRetainerLocation()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@LocationID", SqlDbType.BigInt, 8, ParameterDirection.Input, locationid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblRetainerLocation", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete_RMRetainerLocation()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@LocationID", SqlDbType.BigInt, 8, ParameterDirection.Input, locationid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblRMRetainerLocation", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_RetainerLocation_LocationID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@LocationID", SqlDbType.BigInt, 8, ParameterDirection.Input, locationid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_RetainerLocation_LocationID",myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Insert_tblLocationDistruction()
        {
            try
            {
                SqlParameter[] myaparam = new SqlParameter[3];
                myaparam[0] = ModHelper.CreateParameter("@LocationID", SqlDbType.BigInt, 8, ParameterDirection.Input, locationid);
                myaparam[1] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, createdby);
                myaparam[2] = ModHelper.CreateParameter("@DistructionID", SqlDbType.BigInt, 8, ParameterDirection.Output, distructionid);

                SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_Insert_tblLocationDistruction", myaparam);

                return Convert.ToInt32(myaparam[2].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Insert_tblDistrunctionTransaction()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@DistructionID", SqlDbType.BigInt, 8, ParameterDirection.Input, distructionid);
                myparam[1] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, tlfid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblDistrunctionTransaction", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_tblRetainerLocation_Destruction(string FromDate , string ToDate)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, FromDate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, ToDate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRetainerLocation_Destruction", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_RetainerLocation_TransactionExiest()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@LocationID", SqlDbType.BigInt, 8, ParameterDirection.Input, locationid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_RetainerLocation_TransactionExiest", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_RetainerLocation_Destruct()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@LocationID", SqlDbType.BigInt, 8, ParameterDirection.Input, locationid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_RetainerLocation_Destruct", myparam);
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
