using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;

namespace BusinessFacade.Transactions 
{
   public class Line_SamplePoint
    {
        #region private variable
        private int Lno;
        private Int64 SamplingPointId;
        private bool Del;
        #endregion

        #region Properties
        public int lno
        {
            get { return Lno;}
            set { Lno=value;}
        }
        public Int64 samplingPointId
        {
            get { return SamplingPointId; }
            set { SamplingPointId = value; }
        
        }
        public bool del
        {

            get { return Del; }
            set { Del = value; }
        }
        #endregion

        #region Function
        public bool Insert_LineSamplingPointrlt()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@LNo", SqlDbType.Int, 4, ParameterDirection.Input, lno);
                myparam[1] = ModHelper.CreateParameter("@SamplingPointId", SqlDbType.BigInt, 8, ParameterDirection.Input, samplingPointId);
                myparam[2] = ModHelper.CreateParameter("@Del", SqlDbType.Bit, 1, ParameterDirection.Input, del);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblLineSamplingPointRltnMaster", myparam);
                return true;
            }
            catch
            {

                return false;
            }
        }
        public bool Del_Update_LineSamplingPointrlt()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@LNo", SqlDbType.Int, 4, ParameterDirection.Input, lno);
                myparam[1] = ModHelper.CreateParameter("@SamplingPointId", SqlDbType.BigInt, 8, ParameterDirection.Input, samplingPointId);
                myparam[2] = ModHelper.CreateParameter("@Del", SqlDbType.Bit, 1, ParameterDirection.Input, del);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_DelUpdate_tblLineSamplingPointRltnMaster", myparam);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public DataSet Select_SamplingPointForLine()
        {
            DataSet ds = new DataSet();
            SqlParameter[] myparam = new SqlParameter[1];
            myparam[0] = ModHelper.CreateParameter("@LNo", SqlDbType.Int, 4, ParameterDirection.Input, lno);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SelectSamplingPoninForLine", myparam);
            return ds;
        }
        #endregion

    }
}
