using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DataFacade;

namespace BusinessFacade
{
    public class ReagentSupplierMaster_Class
    {
        # region Varibles
        private string ReagentSupplierName;
        private long ReagentSupplierID;        
        private long CreatedBy;
        private long ModifiedBy;
        # endregion 

        # region Properties
        public string reagentsuppliername
        {
            get { return ReagentSupplierName; }
            set { ReagentSupplierName = value; }
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
        public bool Insert_ReagentSupplierMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@SupplierName", SqlDbType.VarChar, 200, ParameterDirection.Input, ReagentSupplierName);
                myparam[1] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, CreatedBy);
                // myparam[1] = ModHelper.CreateParameter("@DGACode", SqlDbType.VarChar, 50, ParameterDirection.Input, DGACode);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblReagentSupplierMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_ReagentSupplierMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblReagentSupplierMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update_ReagentSupplierMaster()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@ReagentSupplierID", SqlDbType.BigInt, 8, ParameterDirection.Input, ReagentSupplierID);
                myparam[1] = ModHelper.CreateParameter("@SupplierName", SqlDbType.VarChar, 200, ParameterDirection.Input, ReagentSupplierName);
                myparam[2] = ModHelper.CreateParameter("@ModifiedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, ModifiedBy);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblReagentSupplierMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete_ReagentSupplierMaster()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@ReagentSupplierID", SqlDbType.BigInt, 8, ParameterDirection.Input, ReagentSupplierID);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblReagentSupplierMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_ReagentSupplierMaster_ReagentSupplierName()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@SupplierName", SqlDbType.VarChar, 200, ParameterDirection.Input, ReagentSupplierName);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblReagentSupplierMaster_SupplierName", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_All_Record_tblReagentSupplierMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "SP_Select_All_tblReagentSupplierMaster");
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
