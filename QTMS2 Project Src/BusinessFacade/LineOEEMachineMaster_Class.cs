using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;

namespace BusinessFacade
{
    public class LineOEEMachineMaster_Class
    {
        # region Varibles
        private long mid;
        private long lno;
        private string machinename;
        private int active;
        private long createdby;
        # endregion
        # region Properties
        public long CreatedBy
        {
            get { return createdby; }
            set { createdby = value; }
        }
        public int Active
        {
            get { return active; }
            set { active = value; }
        }
        public string MachineName
        {
            get { return machinename; }
            set { machinename = value; }
        }
        public long Lno
        {
            get { return lno; }
            set { lno = value; }
        }
        public long Mid
        {
            get { return mid; }
            set { mid = value; }
        }
        # endregion

        # region Functions

        public DataSet Select_tblLineOEEMachineMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblLineOEEMachineMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        public DataTable Select_tblLineOEEMachineMaster_ByMid()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@Mid", SqlDbType.BigInt, 8, ParameterDirection.Input, mid);
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblLineOEEMachineMaster_ByMid", myparam).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataTable Select_tblLineOEEMachineMaster_ByLno()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@Lno", SqlDbType.BigInt, 8, ParameterDirection.Input, lno);
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblLineOEEMachineMaster_ByLno", myparam).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool tblLineOEEMachineMaster_Insert()
        {
            try
            {
                SqlParameter[] myaparam = new SqlParameter[4];
                myaparam[0] = ModHelper.CreateParameter("@Lno", SqlDbType.BigInt, 8, ParameterDirection.Input, lno);
                myaparam[1] = ModHelper.CreateParameter("@MachineName", SqlDbType.VarChar, 150, ParameterDirection.Input, machinename);
                myaparam[2] = ModHelper.CreateParameter("@Active", SqlDbType.Int, 4, ParameterDirection.Input, active);
                myaparam[3] = ModHelper.CreateParameter("@CreadtedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, createdby);
                
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_tblLineOEEMachineMaster_Insert", myaparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool tblLineOEEMachineMaster_Update()
        {
            try
            {
                SqlParameter[] myaparam = new SqlParameter[4];
                myaparam[0] = ModHelper.CreateParameter("@Mid", SqlDbType.BigInt, 4, ParameterDirection.Input, mid);
                myaparam[1] = ModHelper.CreateParameter("@Lno", SqlDbType.BigInt, 8, ParameterDirection.Input, lno);
                myaparam[2] = ModHelper.CreateParameter("@MachineName", SqlDbType.VarChar, 150, ParameterDirection.Input, machinename);                
                myaparam[3] = ModHelper.CreateParameter("@CreadtedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, createdby);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_tblLineOEEMachineMaster_Update", myaparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool tblLineOEEMachineMaster_Delete()
        {
            try
            {
                SqlParameter[] myaparam = new SqlParameter[2];
                myaparam[0] = ModHelper.CreateParameter("@Mid", SqlDbType.BigInt, 4, ParameterDirection.Input, mid);
                myaparam[1] = ModHelper.CreateParameter("@ModifiedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, createdby);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_tblLineOEEMachineMaster_Delete", myaparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable tblLineOEEMachineMaster_RecordExist()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@Lno", SqlDbType.BigInt, 8, ParameterDirection.Input, lno);
                myparam[1] = ModHelper.CreateParameter("@MachineName", SqlDbType.VarChar,150, ParameterDirection.Input, machinename);
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_tblLineOEEMachineMaster_RecordExist", myparam).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool tblLineOEEMachineMaster_Activate(long id)
        {
            try
            {
                SqlParameter[] myaparam = new SqlParameter[2];
                myaparam[0] = ModHelper.CreateParameter("@Mid", SqlDbType.BigInt, 4, ParameterDirection.Input, id);
                myaparam[1] = ModHelper.CreateParameter("@ModifiedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, createdby);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_tblLineOEEMachineMaster_Activate", myaparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        # endregion
    }
}
