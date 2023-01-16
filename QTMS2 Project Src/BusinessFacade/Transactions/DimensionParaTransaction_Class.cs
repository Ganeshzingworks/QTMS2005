using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;
namespace BusinessFacade.Transactions
{
    public class DimensionParaTransaction_Class
    {
       
        #region Properties
        private long SupplierCOCID;

        public long supplierCOCID
        {
            get { return SupplierCOCID; }
            set { SupplierCOCID = value; }
        }
        private long TestNo;

        public long testNo
        {
            get { return TestNo; }
            set { TestNo = value; }
        }
        private char Status;

        public char status
        {
            get { return Status; }
            set { Status = value; }
        }
        private Nullable<int> InspectedBy;

        public Nullable<int> inspectedBy
        {
            get { return InspectedBy; }
            set { InspectedBy = value; }
        }
        private int LoginID;

        public int loginID
        {
            get { return LoginID; }
            set { LoginID = value; }
        }

        private long DPTransStatusID;

        public long dpTransStatusID
        {
            get { return DPTransStatusID; }
            set { DPTransStatusID = value; }
        }
        private long DimensionMethodID;

        public long dimensionMethodID
        {
            get { return DimensionMethodID; }
            set { DimensionMethodID = value; }
        }


        private double Obs;

        public double obs
        {
            get { return Obs; }
            set { Obs = value; }
        }
        private SqlTransaction Trans;

        public SqlTransaction trans
        {
            get { return Trans; }
            set { Trans = value; }
        }

	    
        #endregion
        #region Function

        public long Insert_DimensionParaTransStatus()
        {
            try
            {
                
                SqlParameter[] param = new SqlParameter[4];
                param[0] = ModHelper.CreateParameter("@TestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, testNo);
                param[1] = ModHelper.CreateParameter("@Status", SqlDbType.Char, 1, ParameterDirection.Input, status);
                param[2] = ModHelper.CreateParameter("@InspectedBy", SqlDbType.Int, 4, ParameterDirection.Input, null);
                param[3] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginID);

                return Convert.ToInt64(SqlHelper.ExecuteScalar(trans,CommandType.StoredProcedure,"STP_Insert_tblDimensionParaTransStatus",param));
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public void Update_DimensionParaTransStatus()
        {
            try
            {

                SqlParameter[] param = new SqlParameter[4];
                param[0] = ModHelper.CreateParameter("@DPTransStatusID", SqlDbType.BigInt, 8, ParameterDirection.Input, dpTransStatusID);
                param[1] = ModHelper.CreateParameter("@Status", SqlDbType.Char, 1, ParameterDirection.Input, status);
                param[2] = ModHelper.CreateParameter("@InspectedBy", SqlDbType.Int, 4, ParameterDirection.Input, inspectedBy);
                param[3] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginID);
                SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "STP_Update_tblDimensionParaTransStatus", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete_DimensionParaTransStatus()
        {
            try
            {

                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@DPTransStatusID", SqlDbType.BigInt, 8, ParameterDirection.Input, dpTransStatusID);
                SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "STP_Delete_tblDimensionParaObs", param);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Insert_DimensionParaObs()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = ModHelper.CreateParameter("@DPTransStatusID", SqlDbType.BigInt, 8, ParameterDirection.Input, dpTransStatusID);
                param[1] = ModHelper.CreateParameter("@DimensionMethodID", SqlDbType.BigInt, 8, ParameterDirection.Input, dimensionMethodID);
                param[2] = ModHelper.CreateParameter("@Obs", SqlDbType.Float, 8, ParameterDirection.Input, obs);
                SqlHelper.ExecuteNonQuery(trans, CommandType.StoredProcedure, "STP_Insert_tblDimensionParaObs", param);
                
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        #endregion
    }
}
