using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;
namespace BusinessFacade
{
    public class VesselMaster_Class
    {
        # region Varibles
        private long VesselNo;
        private string VesselName;
        private int SWC;
        private int VesselSize;
        # endregion
        # region Properties
        public long vesselno
        {
            get { return VesselNo; }
            set { VesselNo = value; }
        }
        public string vesselname
        {
            get { return VesselName; }
            set { VesselName = value; }
        }
        public int swc
        {
            get { return SWC; }
            set { SWC = value; }
        }
        public int vesselsize
        {
            get { return VesselSize; }
            set { VesselSize = value; }
        }
        # endregion
        # region Functions
        public DataSet Select_tblVesselMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblVesselMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblVesselMaster_By_Vesselno()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@VesselNo", SqlDbType.BigInt, 8, ParameterDirection.Input, VesselNo);

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblVesselMaster_By_Vesselno", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert_VesselMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@VslDesc", SqlDbType.NVarChar, 250, ParameterDirection.Input, VesselName);
                myparam[1] = ModHelper.CreateParameter("@SWC", SqlDbType.Int, 4, ParameterDirection.Input, SWC);
                myparam[2] = ModHelper.CreateParameter("@VesselValue", SqlDbType.Int, 4, ParameterDirection.Input, vesselsize);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_TblVesselMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update_VesselMaster()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@VesselNo", SqlDbType.BigInt, 8, ParameterDirection.Input, VesselNo);
                myparam[1] = ModHelper.CreateParameter("@VslDesc", SqlDbType.NVarChar, 250, ParameterDirection.Input, VesselName);
                myparam[2] = ModHelper.CreateParameter("@SWC", SqlDbType.Int, 4, ParameterDirection.Input, SWC);
                myparam[3] = ModHelper.CreateParameter("@VesselValue", SqlDbType.Int, 4, ParameterDirection.Input, vesselsize);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_TblVesselMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete_VesselMaster()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@VesselNo", SqlDbType.BigInt, 8, ParameterDirection.Input, VesselNo);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_TblVesselMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        # endregion


        public DataSet Select_tblAnnexTankMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblAnnexTankMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_All_Record_tblVesselMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "SP_Select_All_tblVesselMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }
    }
}
