using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;
namespace BusinessFacade
{
    public class AnnextureTankMaster_Class
    {


        # region Varibles
        private string AnnexTankDesc;
        private int AnnexTankNo;


        # endregion
        # region Properties

        public string annexTankDesc
        {
            get { return AnnexTankDesc; }
            set { AnnexTankDesc = value; }
        }

        public int annexTankNo
        {
            get { return AnnexTankNo; }
            set { AnnexTankNo = value; }
        }





        # endregion
        # region Functions

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


        public bool Insert_tblAnnexTankMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];

                myparam[0] = ModHelper.CreateParameter("@AnnexTankDesc", SqlDbType.VarChar, 250, ParameterDirection.Input, annexTankDesc);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblAnnexTankMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update_tblAnnexTankMaster()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@AnnexTankNo", SqlDbType.BigInt, 8, ParameterDirection.Input, annexTankNo);
                myparam[1] = ModHelper.CreateParameter("@AnnexTankDesc", SqlDbType.NVarChar, 250, ParameterDirection.Input, annexTankDesc);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblAnnexTankMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool Delete_tblAnnexTankMaster()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@AnnexTankNo", SqlDbType.BigInt, 8, ParameterDirection.Input,annexTankNo);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblAnnexTankMaster", myparam);
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
