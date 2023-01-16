using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;
namespace BusinessFacade.Transactions
{
    public class LineTesting_Class
    {
        private long FNo;
        public long fno
        {
            get { return FNo; }
            set { FNo = value; }
        }
        private long BulkTankDetailNo;
        public long bulktankdetailno
        {
            get { return BulkTankDetailNo; }
            set { BulkTankDetailNo = value; }
        }
        private long TankNo;
        public long tankno
        {
            get { return TankNo; }
            set { TankNo = value; }
        }
        private long TLFID;
        public long tlfid
        {
            get { return TLFID; }
            set { TLFID = value; }
        }
        private string SampleTestDesc;
        public string sampletestdesc
        {
            get { return SampleTestDesc; }
            set { SampleTestDesc = value; }
        }
        private string SampleTestResult;
        public string sampletestresult
        {
            get { return SampleTestResult; }
            set { SampleTestResult = value; }
        }
        private long FillTankSampNo;
        public long filltanksampno
        {
            get { return FillTankSampNo; }
            set { FillTankSampNo = value; }
        }
        private long LineMethodNo;
        public long linemethodno
        {
            get { return LineMethodNo; }
            set { LineMethodNo = value; }
        }
        private long LineTestDetailNo;
        public long linetestdetailno
        {
            get { return LineTestDetailNo; }
            set { LineTestDetailNo = value; }
        }
        private string NormsReading;
        public string normsreading
        {
            get { return NormsReading; }
            set { NormsReading = value; }
        }


        public DataSet Select_tblFillTankSamp_FillTankSampNo_SampTestResult()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@TankNo", SqlDbType.Int, 4, ParameterDirection.Input, tankno);
                myparam[1] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, tlfid);
                myparam[2] = ModHelper.CreateParameter("@SampTestDesc", SqlDbType.VarChar, 50, ParameterDirection.Input, sampletestdesc);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblFillTankSamp_FillTankSampNo_SampTestResult", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long INSERT_tblFillTankSamp()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[5];
                myparam[0] = ModHelper.CreateParameter("@TankNo", SqlDbType.Int, 4, ParameterDirection.Input, tankno);
                myparam[1] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, tlfid);
                myparam[2] = ModHelper.CreateParameter("@SampTestDesc", SqlDbType.VarChar, 50, ParameterDirection.Input, sampletestdesc);
                myparam[3] = ModHelper.CreateParameter("@SampTestResult", SqlDbType.VarChar, 50, ParameterDirection.Input, sampletestresult);
                myparam[4] = ModHelper.CreateParameter("@FillTankSampNo", SqlDbType.BigInt, 8, ParameterDirection.Output, filltanksampno);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_INSERT_tblFillTankSamp", myparam);
                return (Convert.ToInt64(myparam[4].Value));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update_tblFillTankSamp_SampTestResult()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FillTankSampNo", SqlDbType.BigInt, 8, ParameterDirection.Input, filltanksampno);
                myparam[1] = ModHelper.CreateParameter("@SampTestResult", SqlDbType.VarChar, 50, ParameterDirection.Input, sampletestresult);                
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblFillTankSamp_SampTestResult", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SELECT_tblLineTestMethodMaster_FNo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblLineTestMethodMaster_FNo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public DataSet Select_tblLineTestMethodDetails_NormsReading()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@TankNo", SqlDbType.Int, 4, ParameterDirection.Input, tankno);
                myparam[1] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, tlfid);
                myparam[2] = ModHelper.CreateParameter("@SampTestDesc", SqlDbType.VarChar, 50, ParameterDirection.Input, sampletestdesc);
                myparam[3] = ModHelper.CreateParameter("@LineMethodNo", SqlDbType.BigInt, 8, ParameterDirection.Input, linemethodno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblLineTestMethodDetails_NormsReading", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblLineTestMethodDetails_Tests()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@TankNo", SqlDbType.Int, 4, ParameterDirection.Input, tankno);
                myparam[1] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, tlfid);
                myparam[2] = ModHelper.CreateParameter("@SampTestDesc", SqlDbType.VarChar, 50, ParameterDirection.Input, sampletestdesc);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblLineTestMethodDetails_Tests", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Insert_tblLineTestMethodDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@FillTankSampNo", SqlDbType.BigInt, 8, ParameterDirection.Input, filltanksampno);
                myparam[1] = ModHelper.CreateParameter("@LineMethodNo", SqlDbType.BigInt, 8, ParameterDirection.Input, linemethodno);
                myparam[2] = ModHelper.CreateParameter("@NormsReading", SqlDbType.VarChar, 50, ParameterDirection.Input, NormsReading);                
                myparam[3] = ModHelper.CreateParameter("@LineTestDetailNo", SqlDbType.BigInt, 8, ParameterDirection.Output, filltanksampno);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblLineTestMethodDetails", myparam);
                return (Convert.ToInt64(myparam[3].Value));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update_tblLineTestMethodDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];                
                myparam[0] = ModHelper.CreateParameter("@NormsReading", SqlDbType.VarChar, 50, ParameterDirection.Input, NormsReading);
                myparam[1] = ModHelper.CreateParameter("@LineTestDetailNo", SqlDbType.BigInt, 8, ParameterDirection.Input, LineTestDetailNo);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblLineTestMethodDetails", myparam);                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblLineTestMethodDetails_LineTestDetailNo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FillTankSampNo", SqlDbType.BigInt, 8, ParameterDirection.Input, filltanksampno);
                myparam[1] = ModHelper.CreateParameter("@LineMethodNo", SqlDbType.BigInt, 8, ParameterDirection.Input, linemethodno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblLineTestMethodDetails_LineTestDetailNo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
