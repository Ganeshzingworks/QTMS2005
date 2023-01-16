using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using DataFacade;
using System.Data;

namespace BusinessFacade
{
    public class ReagentSupplierPONumber_Class
    {
        # region Varibles
        private long ID;
        private long ReagentSupplierID;
        private string PONumber;        
        private long CreatedBy;
        private long ModifiedBy;
        # endregion 

        # region Properties
        public long id
        {
            get { return ID; }
            set { ID = value; }
        }
        public string ponumber
        {
            get { return PONumber; }
            set { PONumber = value; }
        }
        public long reagentsupplierid
        {
            get { return ReagentSupplierID; }
            set { ReagentSupplierID = value; }
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

        public bool Insert_ReagentSupplierPONumberMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@ReagentSupplierID", SqlDbType.BigInt, 8, ParameterDirection.Input, ReagentSupplierID);
                myparam[1] = ModHelper.CreateParameter("@PONumber", SqlDbType.VarChar, 200, ParameterDirection.Input, PONumber);
                myparam[2] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, CreatedBy);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblReagentSupplierPONumberMappingMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_ReagentSupplierPONumberMaster_SupplierID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@ReagentSupplierID", SqlDbType.BigInt, 8, ParameterDirection.Input, ReagentSupplierID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblReagentSupplierPONumberMappingMaster_SupplierID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update_ReagentSupplierPONumberMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@ID", SqlDbType.BigInt, 8, ParameterDirection.Input, ID);
                myparam[1] = ModHelper.CreateParameter("@ReagentSupplierID", SqlDbType.BigInt, 8, ParameterDirection.Input, ReagentSupplierID);
                myparam[2] = ModHelper.CreateParameter("@PONumber", SqlDbType.VarChar, 200, ParameterDirection.Input, PONumber);
                myparam[3] = ModHelper.CreateParameter("@ModifiedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, ModifiedBy);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblReagentSupplierPONumberMappingMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_ReagentSupplierPONumber()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@PONumber", SqlDbType.VarChar, 200, ParameterDirection.Input, PONumber);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_ReagentSupplierPONumber", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete_tblReagentSupplierPONumberMappingMaster()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@ID", SqlDbType.BigInt, 8, ParameterDirection.Input, ID);              
                myparam[1] = ModHelper.CreateParameter("@ModifiedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, ModifiedBy);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblReagentSupplierPONumberMappingMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_PONumber_All()
        {
            try
            {
                DataSet ds = new DataSet();              
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_PONumber_All");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_SupplierName_ByPONumber()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@ID", SqlDbType.BigInt, 8, ParameterDirection.Input, ID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_SupplierName_ByPONumber", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        # endregion
    }
}
