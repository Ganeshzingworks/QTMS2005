using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataFacade;
using System.Data.SqlClient;

namespace BusinessFacade
{
    public class DimensionParaMaster_Class
    {
        #region Variables & Properties
        private int DimensionParaID;
        private long CreatedBy;
        private long ModifiedBy;
        public int dimensionParaID
        {
            get { return DimensionParaID; }
            set { DimensionParaID = value; }
        }

        private string DimensionParaName;

        public string dimensionParaName
        {
            get { return DimensionParaName; }
            set { DimensionParaName = value; }
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

        #region Function

        public DataTable Select_DimensionParaMaster()
        {
            try
            {
                DataTable Dt = new DataTable();
                Dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblDimensionParaMaster").Tables[0];
                return Dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool Insert_DimensionParaMaster()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = ModHelper.CreateParameter("@DimensionParaName", SqlDbType.NVarChar, 500, ParameterDirection.Input, dimensionParaName);
                param[1] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, createdby);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblDimensionParaMaster", param);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update_DimensionParaMaster()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = ModHelper.CreateParameter("@DimensionParaID", SqlDbType.Int, 4, ParameterDirection.Input, dimensionParaID);
                param[1] = ModHelper.CreateParameter("@DimensionParaName", SqlDbType.NVarChar, 500, ParameterDirection.Input, dimensionParaName);
                param[2] = ModHelper.CreateParameter("@ModifiedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, modifiedby);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblDimensionParaMaster", param);
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool Delete_DimensionParaMaster()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@DimensionParaID", SqlDbType.Int, 4, ParameterDirection.Input, dimensionParaID);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblDimensionParaMaster", param);
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
