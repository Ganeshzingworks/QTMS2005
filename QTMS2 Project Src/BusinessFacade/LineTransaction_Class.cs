using DataFacade;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BusinessFacade
{
    public class LineTransaction_Class
    {
        #region Varibles
        private long Id;
        private long Loginuser;
        private long LineTransactionMasterId;
        private long LayoutLineValidationTransactionId;
        private long LineDescription;
        private string Name;
        private string MinValue;
        private string MaxValue;
        private string AttachedFilePath;
        private string AttachedFileName;
        private string Result;
        private string Value;
        private string Status;
        private string QualityRiskAnalysis;
        private string QualityRiskAnalysisFilePath;
        private string Parameter;
        private DateTime TransactionDate;
        private DateTime DueDate;
        private string ActionPlanFileName;
        private string ActionPlanFilePath;
        #endregion
        #region Properties
        public long id
        {
            get { return Id; }
            set { Id = value; }
        }
        public long layoutLineValidationTransactionId
        {
            get { return LayoutLineValidationTransactionId; }
            set { LayoutLineValidationTransactionId = value; }
        }
        public long lineTransactionMasterId
        {
            get { return LineTransactionMasterId; }
            set { LineTransactionMasterId = value; }
        }
        public long loginuser
        {
            get { return Loginuser; }
            set { Loginuser = value; }
        }
        public long lineDescription
        {
            get { return LineDescription; }
            set { LineDescription = value; }
        }
        public string status
        {
            get { return Status; }
            set { Status = value; }
        }
        public string name
        {
            get { return Name; }
            set { Name = value; }
        }
        public string minValue
        {
            get { return MinValue; }
            set { MinValue = value; }
        }
        public string maxValue
        {
            get { return MaxValue; }
            set { MaxValue = value; }
        }
        public string attachedFilePath
        {
            get { return AttachedFilePath; }
            set { AttachedFilePath = value; }
        }
        public string attachedFileName
        {
            get { return AttachedFileName; }
            set { AttachedFileName = value; }
        }
        public string result
        {
            get { return Result; }
            set { Result = value; }
        }
        public string value
        {
            get { return Value; }
            set { Value = value; }
        }
        public string parameter 
        {
            get { return Parameter; }
            set { Parameter = value; }
        }
        public string qualityRiskAnalysis 
        {
            get { return QualityRiskAnalysis; }
            set { QualityRiskAnalysis = value; }
        } 
        public string qualityRiskAnalysisFilePath
        {
            get { return QualityRiskAnalysisFilePath; }
            set { QualityRiskAnalysisFilePath = value; }
        }
        
        public DateTime transactionDate
        {
            get { return TransactionDate; }
            set { TransactionDate = value; }
        }
        public DateTime dueDate 
        {
            get { return DueDate; }
            set { DueDate = value; }
        }
        public string actionPlanFileName 
        {
            get { return ActionPlanFileName; }
            set { ActionPlanFileName = value; }
        }
        public string actionPlanFilePath 
        {
            get { return ActionPlanFilePath; }
            set { ActionPlanFilePath = value; }
        }

        #endregion
        #region Functions 
        public DataSet Select_LineTransaction()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblLayoutLineTransaction");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Insert_LineTransaction()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[19];
                myparam[0] = ModHelper.CreateParameter("@LineTransactionMasterId", SqlDbType.BigInt, 8, ParameterDirection.Input, LineTransactionMasterId);
                myparam[1] = ModHelper.CreateParameter("@LayoutLineValidationTransactionId", SqlDbType.BigInt, 8, ParameterDirection.Input, LayoutLineValidationTransactionId);
                myparam[2] = ModHelper.CreateParameter("@LayoutLineDescriptionId", SqlDbType.BigInt, 8, ParameterDirection.Input, lineDescription);
                myparam[3] = ModHelper.CreateParameter("@Name", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, name);
                myparam[4] = ModHelper.CreateParameter("@MinValue", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, minValue);
                myparam[5] = ModHelper.CreateParameter("@MaxValue", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, maxValue);
                myparam[6] = ModHelper.CreateParameter("@Value", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, value);
                myparam[7] = ModHelper.CreateParameter("@Result", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, result);
                myparam[8] = ModHelper.CreateParameter("@Status", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, status);
                myparam[9] = ModHelper.CreateParameter("@AttachedFilePath", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, attachedFilePath);
                myparam[10] = ModHelper.CreateParameter("@AttachedFileName", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, attachedFileName);
                myparam[11] = ModHelper.CreateParameter("@LoginBy", SqlDbType.BigInt, 8, ParameterDirection.Input, loginuser);
                myparam[12] = ModHelper.CreateParameter("@Parameter", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, parameter);
                myparam[13] = ModHelper.CreateParameter("@QualityRiskAnalysis", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, qualityRiskAnalysis);
                myparam[14] = ModHelper.CreateParameter("@TransactionDate", SqlDbType.DateTime, 250, ParameterDirection.Input, transactionDate);
                myparam[15] = ModHelper.CreateParameter("@DueDate", SqlDbType.DateTime, 250, ParameterDirection.Input, dueDate);
                myparam[16] = ModHelper.CreateParameter("@ActionPlanFileName", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, actionPlanFileName);
                myparam[17] = ModHelper.CreateParameter("@ActionPlanFilePath", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, actionPlanFilePath);
                myparam[18] = ModHelper.CreateParameter("@QualityRiskAnalysisFilePath", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, qualityRiskAnalysisFilePath);
                
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_INSERT_tblLayoutLineTransaction", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update_LineTransaction()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[17];
                myparam[0] = ModHelper.CreateParameter("@Id", SqlDbType.BigInt, 8, ParameterDirection.Input, Id); 
                myparam[1] = ModHelper.CreateParameter("@Name", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, name);
                myparam[2] = ModHelper.CreateParameter("@MinValue", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, minValue);
                myparam[3] = ModHelper.CreateParameter("@MaxValue", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, maxValue);
                myparam[4] = ModHelper.CreateParameter("@Value", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, value);
                myparam[5] = ModHelper.CreateParameter("@Result", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, result);
                myparam[6] = ModHelper.CreateParameter("@Status", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, status);
                myparam[7] = ModHelper.CreateParameter("@AttachedFilePath", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, attachedFilePath);
                myparam[8] = ModHelper.CreateParameter("@AttachedFileName", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, attachedFileName);
                myparam[9] = ModHelper.CreateParameter("@LoginBy", SqlDbType.BigInt, 8, ParameterDirection.Input, loginuser);
                myparam[10] = ModHelper.CreateParameter("@Parameter", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, parameter);
                myparam[11] = ModHelper.CreateParameter("@QualityRiskAnalysis", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, qualityRiskAnalysis);
                myparam[12] = ModHelper.CreateParameter("@TransactionDate", SqlDbType.DateTime, 250, ParameterDirection.Input, transactionDate);
                myparam[13] = ModHelper.CreateParameter("@DueDate", SqlDbType.DateTime, 250, ParameterDirection.Input, dueDate);
                myparam[14] = ModHelper.CreateParameter("@ActionPlanFileName", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, actionPlanFileName);
                myparam[15] = ModHelper.CreateParameter("@ActionPlanFilePath", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, actionPlanFilePath);
                myparam[16] = ModHelper.CreateParameter("@QualityRiskAnalysisFilePath", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, qualityRiskAnalysisFilePath);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblLayoutLineTransaction", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete_LineTransaction()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@Id", SqlDbType.BigInt, 8, ParameterDirection.Input, Id);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblLayoutLineTransaction", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion 

        public DataSet Select_All_Record_tblLineTransaction()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "SP_Select_All_tblLayoutLineTransaction");
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
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblLayoutLineTransaction_By_LayoutLineDescriptionId", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_LineQualityRiskAnalysisFiles(long LineTransactionMasterId)
        {
            try 
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@LineTransactionMasterId", SqlDbType.BigInt, 8, ParameterDirection.Input, LineTransactionMasterId);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblLineQualityRiskAnalysisFileMaster", myparam);
                return ds;
            }
            catch
            {
                throw;
            }
        }


        public bool Insert_LineQualityRiskAnalysisFileMaster(long LineTransactionMasterId, string QualityRiskAnalysisFilePath,string QualityRiskAnalysisFileName)
        {
            try 
            {
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@LineTransactionMasterId", SqlDbType.BigInt, int.MaxValue, ParameterDirection.Input, LineTransactionMasterId);
                myparam[1] = ModHelper.CreateParameter("@QualityRiskAnalysisFilePath", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, QualityRiskAnalysisFilePath);
                myparam[2] = ModHelper.CreateParameter("@QualityRiskAnalysisFileName", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, QualityRiskAnalysisFileName);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_INSERT_tblLineQualityRiskAnalysisFileMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool Delete_LineQualityRiskAnalysisFileMaster(long LineTransactionMasterId)
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@LineTransactionMasterId", SqlDbType.BigInt, int.MaxValue, ParameterDirection.Input, LineTransactionMasterId);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblLineQualityRiskAnalysisFileMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
