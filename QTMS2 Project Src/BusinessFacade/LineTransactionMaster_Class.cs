using DataFacade;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BusinessFacade
{
    public class LineTransactionMaster_Class
    {
        #region Varibles
        private long Id;
        private long Loginuser;
        private long LineTransactionMasterId;
        private long LayoutLineValidationTransactionId;
        private long LineDescription;
        private int AllParameterDone;
        private string QualityRiskAnalysis;
        private string QualityRiskAnalysisFileName;
        private string QualityRiskAnalysisFilePath;
        private DateTime Date;
        #endregion 
        #region Properties
        public long id
        {
            get { return Id; }
            set { Id = value; }
        }
        public long lineTransactionMasterId
        {
            get { return LineTransactionMasterId; }
            set { LineTransactionMasterId = value; }
        }
        public long layoutLineValidationTransactionId
        {
            get { return LayoutLineValidationTransactionId; }
            set { LayoutLineValidationTransactionId = value; }
        }
        public long loginuser
        {
            get { return Loginuser; }
            set { Loginuser = value; }
        }
        public int allParameterDone
        { 
            get { return AllParameterDone; }
            set { AllParameterDone = value; }
        }
        public string qualityRiskAnalysis
        {
            get { return QualityRiskAnalysis; }
            set { QualityRiskAnalysis = value; }
        }
        public string qualityRiskAnalysisFileName
        {
            get { return QualityRiskAnalysisFileName; }
            set { QualityRiskAnalysisFileName = value; }
        }
        public string qualityRiskAnalysisFilePath
        {
            get { return QualityRiskAnalysisFilePath; }
            set { QualityRiskAnalysisFilePath = value; }
        }
        public long lineDescription
        {
            get { return LineDescription; }
            set { LineDescription = value; }
        }
        public DateTime date
        {
            get { return Date; }
            set { Date = value; }
        }

        #endregion
        #region Functions
        public DataSet Select_LineTransactionMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblLayoutLineTransactionMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Insert_LineTransactionMaster(out DataSet ds)
        {
            try
            {
                ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[8];
                myparam[0] = ModHelper.CreateParameter("@LayoutLineValidationTransactionId", SqlDbType.BigInt, 8, ParameterDirection.Input, LayoutLineValidationTransactionId);
                myparam[1] = ModHelper.CreateParameter("@LayoutLineDescriptionId", SqlDbType.BigInt, 8, ParameterDirection.Input, LineDescription);
                myparam[2] = ModHelper.CreateParameter("@Date", SqlDbType.DateTime, 250, ParameterDirection.Input, Date);
                myparam[3] = ModHelper.CreateParameter("@LoginBy", SqlDbType.BigInt, 8, ParameterDirection.Input, loginuser);
                myparam[4] = ModHelper.CreateParameter("@QualityRiskAnalysis", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, qualityRiskAnalysis);
                myparam[5] = ModHelper.CreateParameter("@QualityRiskAnalysisFileName", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, qualityRiskAnalysisFileName);
                myparam[6] = ModHelper.CreateParameter("@QualityRiskAnalysisFilePath", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, qualityRiskAnalysisFilePath);
                myparam[7] = ModHelper.CreateParameter("@AllParameterDone", SqlDbType.Int, 8, ParameterDirection.Input, allParameterDone);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_INSERT_tblLayoutLineTransactionMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Select_LayoutLineTransactionForModification BY LineTransactionMasterId
        /// </summary>
        /// <param name="lineDescriptionId"></param>
        /// <param name="date"></param>
        /// <param name="loginuser"></param>
        /// <returns></returns>
        public DataSet Select_LayoutLineTransactionForModification(long LineTransactionMasterId, DateTime date, long loginuser)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@LineTransactionMasterId", SqlDbType.BigInt, 8, ParameterDirection.Input, LineTransactionMasterId);
                myparam[1] = ModHelper.CreateParameter("@Date", SqlDbType.DateTime, 250, ParameterDirection.Input, date);
                myparam[2] = ModHelper.CreateParameter("@LoginBy", SqlDbType.BigInt, 8, ParameterDirection.Input, loginuser);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Record_tblLayoutLineTransactionMasterForModification", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update_LineTransactionMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[8];
                myparam[0] = ModHelper.CreateParameter("@Id", SqlDbType.BigInt, 8, ParameterDirection.Input, Id);
                myparam[1] = ModHelper.CreateParameter("@LayoutLineValidationTransactionId", SqlDbType.BigInt, 8, ParameterDirection.Input, layoutLineValidationTransactionId);
                myparam[2] = ModHelper.CreateParameter("@LayoutLineDescriptionId", SqlDbType.BigInt, 8, ParameterDirection.Input, lineDescription);
                myparam[3] = ModHelper.CreateParameter("@LoginBy", SqlDbType.BigInt, 8, ParameterDirection.Input, loginuser);
                myparam[4] = ModHelper.CreateParameter("@QualityRiskAnalysis", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, qualityRiskAnalysis);
                myparam[5] = ModHelper.CreateParameter("@QualityRiskAnalysisFileName", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, qualityRiskAnalysisFileName);
                myparam[6] = ModHelper.CreateParameter("@QualityRiskAnalysisFilePath", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, qualityRiskAnalysisFilePath);
                myparam[7] = ModHelper.CreateParameter("@AllParameterDone", SqlDbType.Int, 8, ParameterDirection.Input, allParameterDone);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblLayoutLineTransactionMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete_LineTransactionMaster()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@Id", SqlDbType.BigInt, 8, ParameterDirection.Input, Id);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblLayoutLineTransactionMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public DataSet Select_All_Record_tblLineTransactionMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "SP_Select_All_tblLayoutLineTransactionMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public DataSet Select_LayoutLineTransactionMasterByLineDescriptionId(long lineDescriptionId)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@LayoutLineDescriptionId", SqlDbType.BigInt, 8, ParameterDirection.Input, lineDescriptionId);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblLayoutLineValidationTransaction_By_LayoutLineDescriptionId", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet Select_IsTransactionExist(long LayoutLineDescriptionId, DateTime Date, long LoginBy)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@LayoutLineDescriptionId", SqlDbType.BigInt, 8, ParameterDirection.Input, LayoutLineDescriptionId);
                myparam[1] = ModHelper.CreateParameter("@Date", SqlDbType.DateTime, 250, ParameterDirection.Input, Date);
                myparam[2] = ModHelper.CreateParameter("@LoginBy", SqlDbType.BigInt, 8, ParameterDirection.Input, LoginBy);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_RecordIsExist_tblLayoutLineTransactionMaster", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_LayoutLineTransactionMasterForAllTransaction()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblLayoutLineValidationMasterForAllTransaction");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
