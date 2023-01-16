using System;
using System.Collections.Generic;
using System.Text;
using DataFacade;
using System.Data;
using System.Data.SqlClient;

namespace BusinessFacade
{
    public class RMSamplingMaster_Class
    {
        #region Variables
        private long RMCodeID;        
        private long RMSupplierID;
        private string PlantLotNo;
        private string  QuantityReceived;
        private string QuantitySampled;
        private int ActualNoOfSegments;
        private int NoOfSegments;
        private long RMSamplingID;
        #endregion

        #region Properties
        public long rmcodeid
        {
            get { return RMCodeID; }
            set { RMCodeID = value; }
        }
        public long rmsamplingid
        {
            get { return RMSamplingID; }
            set { RMSamplingID = value; }
        }
        public long rmsupplierid
        {
            get { return RMSupplierID; }
            set { RMSupplierID = value; }
        }
        public string  plantlotno
        {
            get { return PlantLotNo; }
            set { PlantLotNo = value; }
        }
        public string  quantityreceived
        {
            get { return QuantityReceived; }
            set { QuantityReceived = value; }
        }
        public string quantitysampled
        {
            get { return QuantitySampled; }
            set { QuantitySampled = value; }
        }

        public int  actualnoofsegments
        {
            get { return ActualNoOfSegments; }
            set { ActualNoOfSegments = value; }
        }

        public int noofsegments
        {
            get { return NoOfSegments; }
            set { NoOfSegments = value; }
        }



        #endregion

        #region Functions
        public DataSet Select_RMCodeMaster()
        {
            try
            {

                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMCodeMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_RMSampling_ForDuplicate()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmcodeid);
                myparam[1] = ModHelper.CreateParameter("@RMSupplierID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMSupplierID);
                myparam[2] = ModHelper.CreateParameter("@PlantLotNo", SqlDbType.VarChar, 50, ParameterDirection.Input, PlantLotNo);
                ds=SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMSampling_RMCodeID_RMSupplierID_PlantLotNo",myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_RMSupplierAgentMaster_RMSupplierMaster_RMCodeID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMCodeID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMSupplierAgentMaster_tblRMSupplierMaster_RMCodeID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_RMSampling_RMCodeID()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMSampling_RMCodeID");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_RMSampling_RMCodeID_All()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMCodeID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMSampling_RMCodeID_All", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public long Insert_RMSampling()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[9];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMCodeID);
                myparam[1] = ModHelper.CreateParameter("@RMSupplierID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMSupplierID);
                myparam[2] = ModHelper.CreateParameter("@PlantLotNo", SqlDbType.VarChar, 50, ParameterDirection.Input, PlantLotNo);
                myparam[3] = ModHelper.CreateParameter("@QuantityReceived", SqlDbType.VarChar, 50, ParameterDirection.Input, QuantityReceived);
                myparam[4] = ModHelper.CreateParameter("@QuantitySampled", SqlDbType.VarChar, 50, ParameterDirection.Input, QuantitySampled);
                myparam[5] = ModHelper.CreateParameter("@ActualNoOfSegments", SqlDbType.Int, 4, ParameterDirection.Input, ActualNoOfSegments);
                myparam[6] = ModHelper.CreateParameter("@NoOfSegments", SqlDbType.Int, 4, ParameterDirection.Input, NoOfSegments);
                myparam[7] = ModHelper.CreateParameter("@RMSamplingID", SqlDbType.BigInt, 8, ParameterDirection.Output, rmsamplingid);
                myparam[8] = ModHelper.CreateParameter("@IsValidityExpanded", SqlDbType.Bit, 1, ParameterDirection.Input, false);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblRMSampling", myparam);
                
                return Convert.ToInt64(myparam[7].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update_RMSampling()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[7];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMCodeID);
                myparam[1] = ModHelper.CreateParameter("@RMSupplierID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMSupplierID);
                myparam[2] = ModHelper.CreateParameter("@PlantLotNo", SqlDbType.VarChar, 50, ParameterDirection.Input, PlantLotNo);
                myparam[3] = ModHelper.CreateParameter("@QuantityReceived", SqlDbType.VarChar, 50, ParameterDirection.Input, QuantityReceived);
                myparam[4] = ModHelper.CreateParameter("@QuantitySampled", SqlDbType.VarChar, 50, ParameterDirection.Input, QuantitySampled);
                myparam[5] = ModHelper.CreateParameter("@ActualNoOfSegments", SqlDbType.Int, 4, ParameterDirection.Input, ActualNoOfSegments);
                myparam[6] = ModHelper.CreateParameter("@NoOfSegments", SqlDbType.Int, 4, ParameterDirection.Input, NoOfSegments);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblRMSampling", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete_RMSampling_RMCodeID()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMCodeID);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblRMSampling_RMCodeID", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_RMSupplierAgentMaster_RMCodeId_RMSupplierID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMCodeID);
                myparam[1] = ModHelper.CreateParameter("@RMSupplierID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMSupplierID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMSupplierAgentMaster_RMCodeID_RMSupplierID", myparam);
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
