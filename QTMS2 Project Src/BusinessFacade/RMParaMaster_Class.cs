using System;
using System.Data;
using System.Data.SqlClient;
using DataFacade;

namespace BusinessFacade
{
    public class RMParaMaster_Class
    {
        public RMParaMaster_Class()
        {

        }
        
        # region varibles
        private string ParaName;
        private int ParaNo;
        private string ParaType;
        private long CreatedBy;
        private long ModifiedBy;
        # endregion
        # region Properties
        public string paraname
        {
            get
            {
                return ParaName;
            }
            set
            {
                ParaName = value;
            }
        }

        public string paratype
        {
            get
            {
                return ParaType;
            }
            set
            {
                ParaType = value;
            }
        }
        public int parano
        {
            get
            {
                return ParaNo;
            }
            set
            {
                ParaNo = value;
            }
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
        # endregion
        # region Functions
        public DataSet Select_ParaMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMParaMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_ParaMaster_ParaNo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@ParaNo", SqlDbType.Int, 4, ParameterDirection.Input, parano);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMParaMaster_ParaNo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update_ParaMaster()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@ParaNo", SqlDbType.Int, 4, ParameterDirection.Input, parano);
                myparam[1] = ModHelper.CreateParameter("@ParaName", SqlDbType.NVarChar, 250, ParameterDirection.Input, paraname);
                myparam[2] = ModHelper.CreateParameter("@ModifiedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, modifiedby);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblRMParaMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Insert_ParaMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@ParaName", SqlDbType.NVarChar, 250, ParameterDirection.Input, paraname);
                myparam[1] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, createdby);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblRMParaMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete_ParaMaster()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@ParaNo", SqlDbType.Int, 4, ParameterDirection.Input, parano);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblRMParaMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_ParaMaster_ParaName()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@ParaName", SqlDbType.NVarChar, 250, ParameterDirection.Input,paraname);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMParaMaster_ParaName", myparam);
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
