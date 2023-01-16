using System;
using System.Collections.Generic;
using System.Text;
using DataFacade;
using System.Data;
using System.Data.SqlClient;

namespace BusinessFacade
{
    public class PMSupplierMaster_Class
    {
        # region Varibles
        private string PMSupplierName;
        private string PMAuditDate;
        private long PMSupplierID;
        private long CreatedBy;
        private long ModifiedBy;
        # endregion

        # region Properties
        public string pmsuppliername
        {
            get { return PMSupplierName; }
            set { PMSupplierName = value; }
        }
        public string pmauditdate
        {
            get { return PMAuditDate; }
            set { PMAuditDate = value; }
        }
        public long pmsupplierid
        {
            get { return PMSupplierID; }
            set { PMSupplierID = value; }
        }
        private string SupplierMailID;

        public string supplierMailID
        {
            get { return SupplierMailID; }
            set { SupplierMailID = value; }
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

        #region Functions
        public bool Insert_PMSupplierMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@PMSupplierName", SqlDbType.VarChar, 200, ParameterDirection.Input, PMSupplierName);
                myparam[1] = ModHelper.CreateParameter("@AuditConducted", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, PMAuditDate);
                myparam[2] = ModHelper.CreateParameter("@PMSupplierMail", SqlDbType.VarChar, 500, ParameterDirection.Input, supplierMailID);
                myparam[3] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, createdby);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblPMSupplierMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_PMSupplierMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblPMSupplierMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_PMSupplierMaster_PMSupplierID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@PMSupplierID", SqlDbType.BigInt, 8, ParameterDirection.Input, PMSupplierID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblPMSupplierMaster_PMSupplierID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete_PMSupplierMaster()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@PMSupplierID", SqlDbType.BigInt, 8, ParameterDirection.Input, PMSupplierID);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblPMSupplierMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update_PMSupplierMaster()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[5];
                myparam[0] = ModHelper.CreateParameter("@PMSupplierID", SqlDbType.BigInt, 8, ParameterDirection.Input, PMSupplierID);
                myparam[1] = ModHelper.CreateParameter("@PMSupplierName", SqlDbType.VarChar, 200, ParameterDirection.Input, PMSupplierName);
                myparam[2] = ModHelper.CreateParameter("@AuditConducted", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, PMAuditDate);
                myparam[3] = ModHelper.CreateParameter("@PMSupplierMail", SqlDbType.VarChar, 500, ParameterDirection.Input, supplierMailID);
                myparam[4] = ModHelper.CreateParameter("@ModifiedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, modifiedby);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblPMSupplierMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        public DataSet Select_All_Record_tblPMSupplierMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "SP_Select_All_tblPMSupplierMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
