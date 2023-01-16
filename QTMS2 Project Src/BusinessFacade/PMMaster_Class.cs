using System;
using System.Collections.Generic;
using System.Text;
using DataFacade;
using System.Data;
using System.Data.SqlClient;

namespace BusinessFacade
{
    public class PMMaster_Class
    {
        #region Variables
        private char COCApplicable;
        private long PMSupplierID;
        private long PMCodeID;
        private string PMCode;
        private string PMDescription;
        private long PMFamilyID;
        private long NoOfLots;
        private long PMTestNo;
        private long PMSupplierCOID;
        private long CreatedBy;
        private long ModifiedBy;
        #endregion

        #region Properties
        public char cocapplicable
        {
            get { return COCApplicable; }
            set { COCApplicable = value; }
        }

        public long pmsupplierid
        {
            get { return PMSupplierID; }
            set { PMSupplierID = value; }
        }

        public long pmsuppliecoid
        {
            get { return PMSupplierCOID; }
            set { PMSupplierCOID = value; }
        }

        public long pmcodeid
        {
            get { return PMCodeID; }
            set { PMCodeID = value; }
        }

        public long nooflots
        {
            get { return NoOfLots; }
            set { NoOfLots = value; }
        }

        public string pmcode
        {
            get { return PMCode; }
            set { PMCode = value; }
        }

        public string pmdescription
        {
            get { return PMDescription; }
            set { PMDescription = value; }
        }

        public long pmfamilyid
        {
            get { return PMFamilyID; }
            set { PMFamilyID = value; }
        }
        public long pmtestno
        {
            get { return PMTestNo; }
            set { PMTestNo = value; }
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

        public DataSet Select_PMMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblPMMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_PMCodeMaster_PMSupplierCOC_PMSupplierMaster_PMCode()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@PMCodeID", SqlDbType.VarChar, 50, ParameterDirection.Input, PMCodeID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblPMCodeMaster_tblPMSupplierCOC_tblPMSupplierMaster_PMCode", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_PMCodeMaster_PMSupplierCOC_PMSupplierMaster_PMCode_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@PMCodeID", SqlDbType.VarChar, 50, ParameterDirection.Input, PMCodeID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblPMCodeMaster_tblPMSupplierCOC_tblPMSupplierMaster_PMCode_Reprt", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public long Select_NoOfLots_PMSupplierCOC()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@PMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmcodeid);
                myparam[1] = ModHelper.CreateParameter("@Result", SqlDbType.BigInt, 8, ParameterDirection.Output);
                SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_tblPMTransaction_NoOfLots", myparam);
                if (myparam[1].Value is DBNull)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt64(myparam[1].Value);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_PMCodeMaster__PMSupplierMaster_PMCode()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@PMCodeID", SqlDbType.VarChar, 50, ParameterDirection.Input, pmcodeid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblPMCodeMaster_tblPMSupplierMaster_PMCodeID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet STP_tblPMTransaction_NoOfLots_SupplierCOC()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@PMSupplierCOCId", SqlDbType.VarChar, 50, ParameterDirection.Input, pmsuppliecoid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_tblPMTransaction_NoOfLots_SupplierCOC", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet STP_tblPMTransaction_NoOfLots_SupplierCOC_2()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@PMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmcodeid);
                myparam[1] = ModHelper.CreateParameter("@PMSupplierID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmsupplierid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_tblPMTransaction_NoOfLots_SupplierCOC_2", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_tblPMCodeFamilyTestRelation_PMCodeID()
        {
            try
            {

                DataTable Dt = new DataTable();
                SqlParameter[] myParam = new SqlParameter[1];
                myParam[0] = ModHelper.CreateParameter("@PMCodeID", SqlDbType.VarChar, 50, ParameterDirection.Input, pmcodeid);
                Dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblPMCodeFamilyTestRelation_PMCodeID", myParam).Tables[0];
                return Dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_PMFamilyMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblPMFamilyMaster_For_PMMaster");
                return ds;
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
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblPMSupplierMaster_For_PMMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert_PMSupplierCOC()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[5];
                myparam[0] = ModHelper.CreateParameter("@PMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, PMCodeID);
                myparam[1] = ModHelper.CreateParameter("@PMSupplierID", SqlDbType.BigInt, 8, ParameterDirection.Input, PMSupplierID);
                myparam[2] = ModHelper.CreateParameter("@COCApplicable", SqlDbType.Char, 1, ParameterDirection.Input, COCApplicable);
                myparam[3] = ModHelper.CreateParameter("@NoOfLots", SqlDbType.BigInt, 8, ParameterDirection.Input, NoOfLots);
                myparam[4] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, createdby);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblPMSupplierCOC", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Insert_PMCodeMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[5];
                myparam[0] = ModHelper.CreateParameter("@PMCode", SqlDbType.VarChar, 50, ParameterDirection.Input, PMCode);
                myparam[1] = ModHelper.CreateParameter("@PMDescription", SqlDbType.VarChar, 200, ParameterDirection.Input, PMDescription);
                myparam[2] = ModHelper.CreateParameter("@PMFamilyID", SqlDbType.BigInt, 8, ParameterDirection.Input, PMFamilyID);
                myparam[3] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, createdby);
                myparam[4] = ModHelper.CreateParameter("@PMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Output, pmcodeid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblPMCodeMaster", myparam);
                return Convert.ToInt64(myparam[4].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete_tblPMCodeFamilyTestRelation_PMCodeID()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@PMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmcodeid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblPMCodeFamilyTestRelation_PMCodeID", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert_tblPMCodeFamilyTestRelation()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@PMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmcodeid);
                myparam[1] = ModHelper.CreateParameter("@TestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, pmtestno);
                myparam[2] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, createdby);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblPMCodeFamilyTestRelation", myparam);
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet Select_PMMaster_PMCode()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@PMCode", SqlDbType.VarChar, 50, ParameterDirection.Input, PMCode);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblPMMaster_PMCode", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update_PMMaster()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[5];
                myparam[0] = ModHelper.CreateParameter("@PMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmcodeid);
                myparam[1] = ModHelper.CreateParameter("@PMDescription", SqlDbType.VarChar, 200, ParameterDirection.Input, PMDescription);
                myparam[2] = ModHelper.CreateParameter("@PMFamilyID", SqlDbType.BigInt, 8, ParameterDirection.Input, PMFamilyID);
                myparam[3] = ModHelper.CreateParameter("@PMCode", SqlDbType.VarChar, 50, ParameterDirection.Input, PMCode);
                myparam[4] = ModHelper.CreateParameter("@ModifiedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, modifiedby);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblPMMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete_PMSupplierCOC()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@PMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, PMSupplierID);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblPMSupplierCOC", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete_PMSupplierCOC_PMCodeMaster()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@PMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, PMCodeID);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_DELETE_tblPMSupplierCOC_tblPMCodeMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion


        public DataSet Select_All_Record_tblPMCodeMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "SP_Select_All_tblPMCodeMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public long Select_PMNoOfLots()
        {
            try
            {
                long rslt = 0;
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@PMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmcodeid);
                rslt=Convert.ToInt64(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_Select_PM_NoOfLots", myparam).ToString());
              return rslt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_PMSupplier_STP_Select_PMSupplierMaster_By_PMCode()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@PMSupplierId", SqlDbType.BigInt, 8, ParameterDirection.Input, pmsuppliecoid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_PMSupplierMaster_By_PMCode", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
