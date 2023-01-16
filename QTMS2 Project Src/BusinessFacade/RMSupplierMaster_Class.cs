using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;

namespace BusinessFacade
{
    public class RMSupplierMaster_Class
    {
        # region Varibles
        private string RMSupplierName;
        private long RMSupplierID;
        private string DGACode;
        private long CreatedBy;
        private long ModifiedBy;
        # endregion 

        # region Properties
        public string rmsuppliername
        {
            get { return RMSupplierName; }
            set { RMSupplierName = value; }
        }
        public long rmsupplierid
        {
            get { return RMSupplierID; }
            set { RMSupplierID = value; }
        }
        public string dgacode
        {
            get { return DGACode; }
            set { DGACode = value; }
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
        #endregion
        # region Functions
        public bool Insert_RMSupplierMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@RMSupplierName", SqlDbType.VarChar, 200, ParameterDirection.Input, RMSupplierName);
                myparam[1] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, CreatedBy);
               // myparam[1] = ModHelper.CreateParameter("@DGACode", SqlDbType.VarChar, 50, ParameterDirection.Input, DGACode);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblRMSupplierMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_RMSupplierMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMSupplierMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        public bool Update_RMSupplierMaster()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@RMSupplierID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMSupplierID);
                myparam[1] = ModHelper.CreateParameter("@RMSupplierName", SqlDbType.VarChar, 200, ParameterDirection.Input, RMSupplierName);
                myparam[2] = ModHelper.CreateParameter("@ModifiedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, ModifiedBy);
                //myparam[2] = ModHelper.CreateParameter("@DGACode", SqlDbType.VarChar, 50, ParameterDirection.Input, DGACode);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblRMSupplierMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete_RMSupplierMaster()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMSupplierID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMSupplierID);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblRMSupplierMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string Select_RMSupplierMaster_DGACode()
        {
            try
            {
                string Str_Result = "";
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMSupplierID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMSupplierID);
                Str_Result=Convert.ToString(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_Select_tblRMSupplierMaster_DGACode", myparam));
                return Str_Result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_RMSupplierMaster_RMSupplierName()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@RMSupplierName", SqlDbType.VarChar, 200, ParameterDirection.Input, rmsuppliername);
                //myparam[1] = ModHelper.CreateParameter("@DGACode", SqlDbType.VarChar, 50, ParameterDirection.Input, dgacode);
                ds=SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMSupplierMaster_RMSupplierName", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion


        public DataSet Select_All_Record_tblRMSupplierMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "SP_Select_All_tblRMSupplierMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
