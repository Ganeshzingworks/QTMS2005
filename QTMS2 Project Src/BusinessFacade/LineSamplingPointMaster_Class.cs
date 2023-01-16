using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;

namespace BusinessFacade
{
   public class LineSamplingPointMaster_Class 
    {
        #region privateVariable
        private Int64 SamplingPointId;
        private string SamplingName;
        private bool Del;
        #endregion

        public LineSamplingPointMaster_Class()
        { }
        #region Properties
        public Int64 samplingPointId
        {
            get { return SamplingPointId; }
            set { SamplingPointId = value; }
         }
        public string samplingName
        {
            get { return SamplingName; }
            set { SamplingName = value; }
        
        }
        public bool del
        {
            get { return Del; }
            set { Del = value; }
        }
        #endregion

        #region Function

        public bool Insert_SamplingPointMaster()
        {
            try
            {//stp_Insert_tblLineSamplingPointMaster
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@SamplingPointName", SqlDbType.NVarChar, 250, ParameterDirection.Input, samplingName);
                myparam[1] = ModHelper.CreateParameter("@DelSamplePoint", SqlDbType.Bit, 1, ParameterDirection.Input, del);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "stp_Insert_tblLineSamplingPointMaster", myparam);
                return true;
            }
            catch
            {
                throw;
            }
        }

        public bool Update_SamplingPointMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@SamplingPointId", SqlDbType.BigInt, 8, ParameterDirection.Input, samplingPointId);
                myparam[1] = ModHelper.CreateParameter("@SamplingPointName", SqlDbType.NVarChar, 250, ParameterDirection.Input, samplingName);
                myparam[2] = ModHelper.CreateParameter("@DelSamplePoint", SqlDbType.Bit, 1, ParameterDirection.Input, del);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "stp_Update_tblLineSamplingPointMaster", myparam);
                return true;
            }
            catch 
            {
                return false;
            }
        
        }

        public DataSet Select_SamplingPointMaster()
        {
            try
            {
                DataSet ds = new DataSet();
               ds= SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "stp_Select_tblLineSamplingPointMaster ");
                return ds;
            }
            catch(Exception ex)
            {
                throw;           
            }
        }
    
        #endregion

    }
}
