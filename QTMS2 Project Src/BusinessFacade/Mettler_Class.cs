using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;

namespace BusinessFacade
{
    public class Mettler_Class
    {
        # region Varibles
        private long MettlerID;
        private long FGTLFID;
        private long FNo;
        private long CreatedBy;
        private string MettlerDate;
        private string MettlerTime;
        private string TareWeight;
        private string Weight;
        private long WeightID;
        private string TareWeightTime;
        private string AvgTareWeight;
        private string WeightTime;
        private string BulkWeight;

        private string AVERAGE;
        private string STDDEV;
        private string M_MAX;
        private string M_MIN;
        private string DISPERSION;
        private string DISPERSIONREMARK;
        private string GAP;
        private int ManualEntry;

        private long FGNo;
        private long LNo;
        private string TrackCode;

       
	
        # endregion

        # region Properties
        public int manualentry
        {
            get { return ManualEntry; }
            set { ManualEntry = value; }
        }
        public string gap
        {
            get { return GAP; }
            set { GAP = value; }
        }
        public string dispersionremark
        {
            get { return DISPERSIONREMARK; }
            set { DISPERSIONREMARK = value; }
        }
        public string dispersion
        {
            get { return DISPERSION; }
            set { DISPERSION = value; }
        }
        public string m_min
        {
            get { return M_MIN; }
            set { M_MIN = value; }
        }
        public string m_max
        {
            get { return M_MAX; }
            set { M_MAX = value; }
        }
        public string stddev
        {
            get { return STDDEV; }
            set { STDDEV = value; }
        }
        public string average
        {
            get { return AVERAGE; }
            set { AVERAGE = value; }
        }
        public long mettlerid
        {
            get { return MettlerID; }
            set { MettlerID = value; }
        }
        public long fgtlfid
        {
            get { return FGTLFID; }
            set { FGTLFID = value; }
        }
        public long fno
        {
            get { return FNo; }
            set { FNo = value; }
        }
        public long createdby
        {
            get { return CreatedBy; }
            set { CreatedBy = value; }
        }

        public string mettlerdate
        {
            get { return MettlerDate; }
            set { MettlerDate = value; }
        }

        public string mettlertime
        {
            get { return MettlerTime; }
            set { MettlerTime = value; }
        }

        public string tareweight
        {
            get { return TareWeight; }
            set { TareWeight = value; }
        }
        public string weight
        {
            get { return Weight; }
            set { Weight = value; }
        }

        public long weightid
        {
            get { return WeightID; }
            set { WeightID = value; }
        }
        public string tareweighttime
        {
            get { return TareWeightTime; }
            set { TareWeightTime = value; }
        }
        public string avgtareweight
        {
            get { return AvgTareWeight; }
            set { AvgTareWeight = value; }
        }
        public string bulkweight
        {
            get { return BulkWeight; }
            set { BulkWeight = value; }
        }
        public string weighttime
        {
            get { return WeightTime; }
            set { WeightTime = value; }
        }

        public string trackcode
        {
            get { return TrackCode; }
            set { TrackCode = value; }
        }


        public long lno
        {
            get { return LNo; }
            set { LNo = value; }
        }


        public long fgno
        {
            get { return FGNo; }
            set { FGNo = value; }
        }
        # endregion

        # region Functions

        public DataSet Select_tblMettler()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                myparam[1] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[2] = ModHelper.CreateParameter("@MettlerDate", SqlDbType.DateTime, 4, ParameterDirection.Input, mettlerdate);
                myparam[3] = ModHelper.CreateParameter("@MettlerTime", SqlDbType.VarChar, 50, ParameterDirection.Input, mettlertime);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblMettler", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblMettler_New()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                myparam[1] = ModHelper.CreateParameter("@TrackCode", SqlDbType.DateTime, 4, ParameterDirection.Input, trackcode);
                myparam[2] = ModHelper.CreateParameter("@LNo", SqlDbType.BigInt, 8, ParameterDirection.Input, lno);
                myparam[3] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);               
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblMettler_New", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblMettlerWeight()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@MettlerID", SqlDbType.BigInt, 8, ParameterDirection.Input, mettlerid);
                myparam[1] = ModHelper.CreateParameter("@MettlerTime", SqlDbType.VarChar, 50, ParameterDirection.Input, mettlertime);
               
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblMettlerWeight", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblMettlerWeight_MINMAXAVG()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@MettlerID", SqlDbType.BigInt, 8, ParameterDirection.Input, mettlerid);
                myparam[1] = ModHelper.CreateParameter("@MettlerTime", SqlDbType.VarChar, 50, ParameterDirection.Input, mettlertime);

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblMettlerWeight_MINMAXAVG", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblMettlerWeight_StandardVariance()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@MettlerID", SqlDbType.BigInt, 8, ParameterDirection.Input, mettlerid);
                myparam[1] = ModHelper.CreateParameter("@MettlerTime", SqlDbType.VarChar, 50, ParameterDirection.Input, mettlertime);

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblMettlerWeight_StandardVariance", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Insert_tblMettler()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[7];

                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                myparam[1] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[2] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, createdby);
                myparam[3] = ModHelper.CreateParameter("@MettlerDate", SqlDbType.DateTime, 4, ParameterDirection.Input, mettlerdate);
                myparam[4] = ModHelper.CreateParameter("@MettlerTime", SqlDbType.VarChar, 50, ParameterDirection.Input, mettlertime);
                myparam[5] = ModHelper.CreateParameter("@TareWeight", SqlDbType.VarChar, 50, ParameterDirection.Input, tareweight);
                myparam[6] = ModHelper.CreateParameter("@MettlerID", SqlDbType.BigInt, 8, ParameterDirection.Output);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblMettler", myparam);

                MettlerID = Convert.ToInt32(myparam[6].Value);

                return MettlerID;
                //return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Insert_tblMettler_New()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[8];

                myparam[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                myparam[1] = ModHelper.CreateParameter("@TrackCode", SqlDbType.DateTime, 4, ParameterDirection.Input, trackcode);
                myparam[2] = ModHelper.CreateParameter("@LNo", SqlDbType.BigInt, 8, ParameterDirection.Input, lno);
                myparam[3] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[4] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, createdby);                
                myparam[5] = ModHelper.CreateParameter("@MettlerTime", SqlDbType.VarChar, 50, ParameterDirection.Input, mettlertime);
                myparam[6] = ModHelper.CreateParameter("@TareWeight", SqlDbType.VarChar, 50, ParameterDirection.Input, tareweight);
                myparam[7] = ModHelper.CreateParameter("@MettlerID", SqlDbType.BigInt, 8, ParameterDirection.Output);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblMettler_New", myparam);

                MettlerID = Convert.ToInt32(myparam[7].Value);

                return MettlerID;
                //return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert_tblMettlerWeight()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[6];

                myparam[0] = ModHelper.CreateParameter("@MettlerID", SqlDbType.BigInt, 8, ParameterDirection.Input, mettlerid);
                myparam[1] = ModHelper.CreateParameter("@Weight", SqlDbType.Decimal, 18, ParameterDirection.Input, weight);
                myparam[2] = ModHelper.CreateParameter("@BulkWeight", SqlDbType.Decimal, 18, ParameterDirection.Input, bulkweight);
                myparam[3] = ModHelper.CreateParameter("@Time", SqlDbType.VarChar, 50, ParameterDirection.Input, weighttime);
                myparam[4] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, createdby);
                myparam[5] = ModHelper.CreateParameter("@MettlerTime", SqlDbType.VarChar, 50, ParameterDirection.Input, mettlertime);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblMettlerWeight", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delet_tblMettlerWeight_ByWeightID()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];

                myparam[0] = ModHelper.CreateParameter("WeightID", SqlDbType.BigInt, 8, ParameterDirection.Input, weightid);              

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delet_tblMettlerWeight_ByWeightID", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert_Update_tblMettler_TareWeight()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[6];

                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                myparam[1] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[2] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, createdby);
                myparam[3] = ModHelper.CreateParameter("@MettlerDate", SqlDbType.DateTime, 4, ParameterDirection.Input, mettlerdate);
                myparam[4] = ModHelper.CreateParameter("@MettlerTime", SqlDbType.VarChar, 50, ParameterDirection.Input, mettlertime);
                myparam[5] = ModHelper.CreateParameter("@TareWeight", SqlDbType.VarChar, 50, ParameterDirection.Input, tareweight);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_Update_tblMettler_TareWeight", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblMettler_FinishedGoodtest()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                myparam[1] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                //ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblMettler_FinishedGoodtest", myparam);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_MettlerReadingInfo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert_tblMettlerTareWeight()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];

                myparam[0] = ModHelper.CreateParameter("@MettlerID", SqlDbType.BigInt, 8, ParameterDirection.Input, mettlerid);
                myparam[1] = ModHelper.CreateParameter("@TareWeight", SqlDbType.VarChar, 50, ParameterDirection.Input, tareweight);
                myparam[2] = ModHelper.CreateParameter("@TareWeightTime", SqlDbType.VarChar, 50, ParameterDirection.Input, tareweighttime);
                myparam[3] = ModHelper.CreateParameter("@LoginID", SqlDbType.BigInt, 8, ParameterDirection.Input, createdby);              
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblMettlerTareWeight", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DeActive_tblMettler(long ID)
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];

                myparam[0] = ModHelper.CreateParameter("@MettlerID", SqlDbType.BigInt, 8, ParameterDirection.Input, ID);
                myparam[1] = ModHelper.CreateParameter("@ModifiedBy", SqlDbType.BigInt, 18, ParameterDirection.Input, createdby);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_DeActive_tblMettler", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert_Update_tblMettlerAverage_ByAutoEntry()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[11];

                myparam[0] = ModHelper.CreateParameter("@MettlerID", SqlDbType.BigInt, 8, ParameterDirection.Input, mettlerid);
                myparam[1] = ModHelper.CreateParameter("@MettlerTime", SqlDbType.VarChar, 50, ParameterDirection.Input, mettlertime);
                myparam[2] = ModHelper.CreateParameter("@AVERAGE", SqlDbType.VarChar, 50, ParameterDirection.Input, average);
                myparam[3] = ModHelper.CreateParameter("@STDDEV", SqlDbType.VarChar, 50, ParameterDirection.Input, stddev);
                myparam[4] = ModHelper.CreateParameter("@M_MAX", SqlDbType.VarChar, 50, ParameterDirection.Input, m_max);
                myparam[5] = ModHelper.CreateParameter("@M_MIN", SqlDbType.VarChar, 50, ParameterDirection.Input, m_min);
                myparam[6] = ModHelper.CreateParameter("@DISPERSION", SqlDbType.VarChar, 50, ParameterDirection.Input, dispersion);
                myparam[7] = ModHelper.CreateParameter("@GAP", SqlDbType.VarChar, 50, ParameterDirection.Input, gap);
                myparam[8] = ModHelper.CreateParameter("@ManualEntry", SqlDbType.Int, 4, ParameterDirection.Input, manualentry);
                myparam[9] = ModHelper.CreateParameter("@Active", SqlDbType.Int, 4, ParameterDirection.Input, 1);               
                myparam[10] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, createdby);               

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_Update_tblMettlerAverage_ByAutoEntry", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update_tblMettlerAverage_DISPERSIONREMARK()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];

                myparam[0] = ModHelper.CreateParameter("@MettlerID", SqlDbType.BigInt, 8, ParameterDirection.Input, mettlerid);
                myparam[1] = ModHelper.CreateParameter("@MettlerTime", SqlDbType.VarChar, 50, ParameterDirection.Input, mettlertime);
                myparam[2] = ModHelper.CreateParameter("@DISPERSIONREMARK", SqlDbType.VarChar, 500, ParameterDirection.Input, DISPERSIONREMARK);               
                myparam[3] = ModHelper.CreateParameter("@ManualEntry", SqlDbType.Int, 4, ParameterDirection.Input, manualentry);


                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblMettlerAverage_DISPERSIONREMARK", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_tblMettlerAverage_DISPERSIONREMARK()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@MettlerID", SqlDbType.BigInt, 8, ParameterDirection.Input, mettlerid);
                myparam[1] = ModHelper.CreateParameter("@MettlerTime", SqlDbType.VarChar, 50, ParameterDirection.Input, mettlertime);              
                myparam[2] = ModHelper.CreateParameter("@ManualEntry", SqlDbType.Int, 4, ParameterDirection.Input, manualentry);
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblMettlerAverage_DISPERSIONREMARK", myparam).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_tblMettlerAverage_ManualExists()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@MettlerID", SqlDbType.BigInt, 8, ParameterDirection.Input, mettlerid);
                myparam[1] = ModHelper.CreateParameter("@MettlerTime", SqlDbType.VarChar, 50, ParameterDirection.Input, mettlertime);                
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblMettlerAverage_ManualExists", myparam).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Select_tblMettlerAverage_AutoExists()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@MettlerID", SqlDbType.BigInt, 8, ParameterDirection.Input, mettlerid);
                myparam[1] = ModHelper.CreateParameter("@MettlerTime", SqlDbType.VarChar, 50, ParameterDirection.Input, mettlertime);
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblMettlerAverage_AutoExists", myparam).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Insert_tblMettlerAverage_ByManualEntry()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[11];

                myparam[0] = ModHelper.CreateParameter("@MettlerID", SqlDbType.BigInt, 8, ParameterDirection.Input, mettlerid);
                myparam[1] = ModHelper.CreateParameter("@MettlerTime", SqlDbType.VarChar, 50, ParameterDirection.Input, mettlertime);
                myparam[2] = ModHelper.CreateParameter("@AVERAGE", SqlDbType.VarChar, 50, ParameterDirection.Input, average);
                myparam[3] = ModHelper.CreateParameter("@STDDEV", SqlDbType.VarChar, 50, ParameterDirection.Input, stddev);
                myparam[4] = ModHelper.CreateParameter("@M_MAX", SqlDbType.VarChar, 50, ParameterDirection.Input, m_max);
                myparam[5] = ModHelper.CreateParameter("@M_MIN", SqlDbType.VarChar, 50, ParameterDirection.Input, m_min);
                myparam[6] = ModHelper.CreateParameter("@DISPERSION", SqlDbType.VarChar, 50, ParameterDirection.Input, dispersion);
                myparam[7] = ModHelper.CreateParameter("@GAP", SqlDbType.VarChar, 50, ParameterDirection.Input, gap);
                myparam[8] = ModHelper.CreateParameter("@ManualEntry", SqlDbType.Int, 4, ParameterDirection.Input, manualentry);
                myparam[9] = ModHelper.CreateParameter("@Active", SqlDbType.Int, 4, ParameterDirection.Input, 1);
                myparam[10] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, createdby);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblMettlerAverage_ByManualEntry", myparam);
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
