using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DataFacade;

namespace BusinessFacade.Scoop_Class
{
   public class UPTestSamplingPoint_Class
    {
        #region proivate member
        Int64 UPSamplingPontTestID, UPID, SampleID;
        DateTime StartTime; int Frequency;

        Int64 FGNo; int LNo;
        #endregion

        #region properties
        public Int64 upsamplingpointtestId
        {
            get { return UPSamplingPontTestID; }
            set { UPSamplingPontTestID = value; }
        }

        public Int64 upid
        {

            get { return UPID; }
            set { UPID = value; }
        }

        public Int64 sampleid
        {
            get { return SampleID; }
            set{SampleID=value;}      
        }

        public DateTime starttime
        {
            get { return StartTime; }
            set { StartTime = value; }
        }

        public int frequency
        {
            get { return Frequency; }
            set { Frequency = value; }
        }
        public int lno
        {
            get { return LNo; }
            set { LNo = value; }
        }
        public Int64 fgno
        {
            get { return FGNo; }
            set { FGNo = value; }
        }
        #endregion

        #region functions

        public bool Insert_tblUPTestSamplingPoints()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@UPID", SqlDbType.BigInt, 8, ParameterDirection.Input, upid);
                myparam[1] = ModHelper.CreateParameter("@SampleID ", SqlDbType.BigInt, 8, ParameterDirection.Input, sampleid);
                myparam[2] = ModHelper.CreateParameter("@StartTime", SqlDbType.DateTime, 8, ParameterDirection.Input, starttime);
                myparam[3] = ModHelper.CreateParameter("@Frequency ", SqlDbType.Int, 4, ParameterDirection.Input,frequency);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblUPTestSamplingPoints", myparam);
                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public Int64 GetLastAdded_tblUPTestSamplingPoints()
        {
            try
            {
                Int64 Id = 0;
                Id =Convert.ToInt64(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_GetLastAdded_tblUPTestSamplingPoints").ToString());
                return Id;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataTable Get_DefectCount()
        {

            try
            {
                DataTable dt = new DataTable();
                dt.Columns.Add("AQLZ");
                dt.Columns.Add("AQLC");
                dt.Columns.Add("AQLM");
                dt.Columns.Add("AQLM1");

                SqlParameter[] myparam = new SqlParameter[8];
                myparam[0] = ModHelper.CreateParameter("@LNo", SqlDbType.Int, 4, ParameterDirection.Input, lno);
                myparam[1] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                myparam[2] = ModHelper.CreateParameter("@SamplingPointId", SqlDbType.BigInt, 8, ParameterDirection.Input, sampleid);
                myparam[3] = ModHelper.CreateParameter("@UPSamplingPontTestID", SqlDbType.BigInt, 8, ParameterDirection.Input, upsamplingpointtestId);
                myparam[4] = ModHelper.CreateParameter("@AQLMDefctCount", SqlDbType.Int, 4, ParameterDirection.Output);
                myparam[5] = ModHelper.CreateParameter("@AQLZDefectCount ", SqlDbType.Int, 4, ParameterDirection.Output);
                myparam[6] = ModHelper.CreateParameter("@AQLCDefectCount", SqlDbType.Int, 4, ParameterDirection.Output);
                myparam[7] = ModHelper.CreateParameter("@AQLM1DefectCount", SqlDbType.Int, 4, ParameterDirection.Output);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_GetDefectCount_Curser", myparam);
                dt.Rows.Add(myparam[5].Value, myparam[6].Value, myparam[4].Value, myparam[7].Value);

                return dt;
            }
            catch
            {
                throw;
            }
        
        }
        #endregion
    }
}
