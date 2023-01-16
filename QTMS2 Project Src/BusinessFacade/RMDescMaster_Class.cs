using System;
using System.Data;
using System.Data.SqlClient;
using DataFacade;

namespace BusinessFacade
{
    public class RMDescMaster_Class
    {
        public RMDescMaster_Class()
        {

        }
        # region varibles
        private int DescNo;
        private int ParaNo;
        private string DescName;
        private long CreatedBy;
        private long ModifiedBy;
        # endregion

        # region Properties
        public string descname
        {
            get
            {
                return DescName;
            }
            set
            {
                DescName = value;
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
        public int descno
        {
            get
            {
                return DescNo;
            }
            set
            {
                DescNo = value;
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

        #region Functions

        public bool Delete_DescMaster()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@DescNo", SqlDbType.Int, 4, ParameterDirection.Input, descno);
                myparam[1] = ModHelper.CreateParameter("@DescName", SqlDbType.NVarChar, 250, ParameterDirection.Input, descname);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblRMDescMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void  Update_DescMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@ParaNo", SqlDbType.Int, 4, ParameterDirection.Input, parano);
                myparam[1] = ModHelper.CreateParameter("@DescName", SqlDbType.NVarChar, 250, ParameterDirection.Input, descname);
                myparam[2] = ModHelper.CreateParameter("@DescNo", SqlDbType.Int, 4, ParameterDirection.Input,descno);
                myparam[3] = ModHelper.CreateParameter("@ModifiedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, modifiedby);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblRMDescMaster", myparam);
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int Insert_DescMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@ParaNo", SqlDbType.Int, 4, ParameterDirection.Input, parano);
                myparam[1] = ModHelper.CreateParameter("@DescName", SqlDbType.NVarChar, 250, ParameterDirection.Input, descname);
                myparam[2] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, createdby);
                myparam[3] = ModHelper.CreateParameter("@DescNo", SqlDbType.Int, 4, ParameterDirection.Output,descno);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblRMDescMaster", myparam);
                DescNo = Convert.ToInt32(myparam[3].Value);
                return DescNo;
              
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_ParaMaster_DescMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMParaMaster_tblRMDescMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_DescMaster_ParaNo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@ParaNo", SqlDbType.Int, 4, ParameterDirection.Input, parano);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMDescMaster_ParaNo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_DescMaster_DescName()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@DescName", SqlDbType.NVarChar, 250, ParameterDirection.Input, descname);
                myparam[1] = ModHelper.CreateParameter("@ParaNo", SqlDbType.Int, 4, ParameterDirection.Input, parano);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMDescMaster_DescName", myparam);
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
