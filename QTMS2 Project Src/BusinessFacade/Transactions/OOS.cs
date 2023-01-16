using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;

namespace BusinessFacade.Transactions
{
    public class OOS
    {
        #region Properties

        private long OOSid;
        public long oosid
        {
            get { return OOSid; }
            set { OOSid = value; }
        }

        private string OOSRequestNo;
        public string oosrequestno
        {
            get { return OOSRequestNo; }
            set { OOSRequestNo = value; }
        }

        private string FormName;
        public string formname
        {
            get { return FormName; }
            set { FormName = value; }
        }

        private long Fno;
        public long fno
        {
            get { return Fno; }
            set { Fno = value; }
        }

        private string MfgWo;
        public string mfgwo
        {
            get { return MfgWo; }
            set { MfgWo = value; }
        }

        private long BulkMethodno;
        public long bulkmethodno
        {
            get { return BulkMethodno; }
            set { BulkMethodno = value; }
        }

        private int Tankno;
        public int tankno
        {
            get { return Tankno; }
            set { Tankno = value; }
        }

        private string OccurenceDate;
        public string occurencedate
        {
            get { return OccurenceDate; }
            set { OccurenceDate = value; }
        }

        private string ProductName;
        public string productname
        {
            get { return ProductName; }
            set { ProductName = value; }
        }

        private string TestName;
        public string testname
        {
            get { return TestName; }
            set { TestName = value; }
        }

        private string BatchNumber;
        public string batchnumber
        {
            get { return BatchNumber; }
            set { BatchNumber = value; }
        }

        private long AnalystIncharge;
        public long analystincharge
        {
            get { return AnalystIncharge; }
            set { AnalystIncharge = value; }
        }

        private string TestResultSummary;
        public string testresultsummary
        {
            get { return TestResultSummary; }
            set { TestResultSummary = value; }
        }

        private long CreatedBy;
        public long createdby
        {
            get { return CreatedBy; }
            set { CreatedBy = value; }
        }

        private string SmapleBatchno;
        public string smaplebatchno
        {
            get { return SmapleBatchno; }
            set { SmapleBatchno = value; }
        }

        private string SampleInitialResult;
        public string sampleinitialresult
        {
            get { return SampleInitialResult; }
            set { SampleInitialResult = value; }
        }

        private string LaboratoryInvestigationResult;
        public string laboratoryinvestigationresult
        {
            get { return LaboratoryInvestigationResult; }
            set { LaboratoryInvestigationResult = value; }
        }

        private string LaboratoryInvestigationResult1;
        public string laboratoryinvestigationresult1
        {
            get { return LaboratoryInvestigationResult1; }
            set { LaboratoryInvestigationResult1 = value; }
        }

        private string LaboratoryInvestigationResult2;
        public string laboratoryinvestigationresult2
        {
            get { return LaboratoryInvestigationResult2; }
            set { LaboratoryInvestigationResult2 = value; }
        }

        private string LaboratoryInvestigationAverage1and2;
        public string laboratoryinvestigationaverage1and2
        {
            get { return LaboratoryInvestigationAverage1and2; }
            set { LaboratoryInvestigationAverage1and2 = value; }
        }

        private string LaboratoryInvestigationRepeatability;
        public string laboratoryinvestigationrepeatability
        {
            get { return LaboratoryInvestigationRepeatability; }
            set { LaboratoryInvestigationRepeatability = value; }
        }

        private string LaboratoryInvestigationDiffrence;
        public string laboratoryinvestigationdiffrence
        {
            get { return LaboratoryInvestigationDiffrence; }
            set { LaboratoryInvestigationDiffrence = value; }
        }

        private string LaboratoryInvestigationInitialResult;
        public string laboratoryinvestigationinitialresult
        {
            get { return LaboratoryInvestigationInitialResult; }
            set { LaboratoryInvestigationInitialResult = value; }
        }

        private string LaboratoryInvestigationReAnalysisResult;
        public string laboratoryinvestigationreanalysisresult
        {
            get { return LaboratoryInvestigationReAnalysisResult; }
            set { LaboratoryInvestigationReAnalysisResult = value; }
        }

        private string LaboratoryInvestigationReProducibility;
        public string laboratoryinvestigationreproducibility
        {
            get { return LaboratoryInvestigationReProducibility; }
            set { LaboratoryInvestigationReProducibility = value; }
        }

        private string Reanalysis;
        public string reanalysis
        {
            get { return Reanalysis; }
            set { Reanalysis = value; }
        }

        private string LaboratoryInvestigationConclusion;
        public string laboratoryinvestigationconclusion
        {
            get { return LaboratoryInvestigationConclusion; }
            set { LaboratoryInvestigationConclusion = value; }
        }

        private string Parameters;
        public string parameters
        {
            get { return Parameters; }
            set { Parameters = value; }
        }

        private string Observations;
        public string observations
        {
            get { return Observations; }
            set { Observations = value; }
        }

        private string Comments;
        public string comments
        {
            get { return Comments; }
            set { Comments = value; }
        }

        private string Result1;
        public string result1
        {
            get { return Result1; }
            set { Result1 = value; }
        }

        private string Result2;
        public string result2
        {
            get { return Result2; }
            set { Result2 = value; }
        }

        private string Average;
        public string average
        {
            get { return Average; }
            set { Average = value; }
        }

        private string Repeatability;
        public string repeatability
        {
            get { return Repeatability; }
            set { Repeatability = value; }
        }

        private string Conculsion;
        public string conculsion
        {
            get { return Conculsion; }
            set { Conculsion = value; }
        }

        private long QCAnalyst;
        public long qcanalyst
        {
            get { return QCAnalyst; }
            set { QCAnalyst = value; }
        }

        private string CompletionDate;
        public string completionDate
        {
            get { return CompletionDate; }
            set { CompletionDate = value; }
        }

        private string ReSample;
        public string resample
        {
            get { return ReSample; }
            set { ReSample = value; }
        }

        private string Conclusion;
        public string conclusion
        {
            get { return Conclusion; }
            set { Conclusion = value; }
        }

        private string Simulating;
        public string simulating
        {
            get { return Simulating; }
            set { Simulating = value; }
        }

        private string ResonResult1;
        public string resonResult1
        {
            get { return ResonResult1; }
            set { ResonResult1 = value; }
        }

        private string ResonResult2;
        public string resonResult2
        {
            get { return ResonResult2; }
            set { ResonResult2 = value; }
        }

        private string ResonAverage;
        public string resonaverage
        {
            get { return ResonAverage; }
            set { ResonAverage = value; }
        }

        private string ResonRepeatability;
        public string resonrepeatability
        {
            get { return ResonRepeatability; }
            set { ResonRepeatability = value; }
        }

        private string FinalRemark;
        public string finalremark
        {
            get { return FinalRemark; }
            set { FinalRemark = value; }
        }

        private string OOSValid;
        public string oosvalid
        {
            get { return OOSValid; }
            set { OOSValid = value; }
        }

        private string Proceed;
        public string proceed
        {
            get { return Proceed; }
            set { Proceed = value; }
        }

        private long HeadQualityControl;
        public long headqualitycontrol
        {
            get { return HeadQualityControl; }
            set { HeadQualityControl = value; }
        }

        private string ResonCompletionDate;
        public string resoncompletiondate
        {
            get { return ResonCompletionDate; }
            set { ResonCompletionDate = value; }
        }

        private long LabDetailsID;
        public long labdetailsid
        {
            get { return LabDetailsID; }
            set { LabDetailsID = value; }
        }

        private string InstrumentUsed;
        public string instrumentused
        {
            get { return InstrumentUsed; }
            set { InstrumentUsed = value; }
        }

        private string CalibrationDue;
        public string calibrationdue
        {
            get { return CalibrationDue; }
            set { CalibrationDue = value; }
        }

        private string SolutionUsed;
        public string solutionused
        {
            get { return SolutionUsed; }
            set { SolutionUsed = value; }
        }

        private string ValidUptoDate;
        public string validuptodate
        {
            get { return ValidUptoDate; }
            set { ValidUptoDate = value; }
        }

        private string Strength;
        public string strength
        {
            get { return Strength; }
            set { Strength = value; }
        }

        private int Srno;
        public int srno
        {
            get { return Srno; }
            set { Srno = value; }
        }

        private string Summary;
        public string summary
        {
            get { return Summary; }
            set { Summary = value; }
        }

        private string FinalDecision;
        public string finaldecision
        {
            get { return FinalDecision; }
            set { FinalDecision = value; }
        }

        private long UpManager;
        public long upmanager
        {
            get { return UpManager; }
            set { UpManager = value; }
        }

        private long ProcessExpert;
        public long processexpert
        {
            get { return ProcessExpert; }
            set { ProcessExpert = value; }
        }

        private long QualityHead;
        public long qualityhead
        {
            get { return QualityHead; }
            set { QualityHead = value; }
        }

        private string Laberror;
        public string laberror
        {
            get { return Laberror; }
            set { Laberror = value; }
        }

        #endregion


        public bool Insert_Update_tblOOS_Bulk()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[10];
                myparam[0] = ModHelper.CreateParameter("@Fno", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[1] = ModHelper.CreateParameter("@MfgWo", SqlDbType.NVarChar, 150, ParameterDirection.Input, mfgwo);
                myparam[2] = ModHelper.CreateParameter("@BulkMethodno", SqlDbType.BigInt, 8, ParameterDirection.Input, bulkmethodno);
                myparam[3] = ModHelper.CreateParameter("@OccurenceDate", SqlDbType.DateTime, 50, ParameterDirection.Input, Convert.ToDateTime(occurencedate));
                myparam[4] = ModHelper.CreateParameter("@ProductName", SqlDbType.NVarChar, 150, ParameterDirection.Input, productname);
                myparam[5] = ModHelper.CreateParameter("@TestName", SqlDbType.NVarChar, 150, ParameterDirection.Input, testname);
                myparam[6] = ModHelper.CreateParameter("@BatchNumber", SqlDbType.NVarChar, 150, ParameterDirection.Input, batchnumber);
                myparam[7] = ModHelper.CreateParameter("@AnalystIncharge", SqlDbType.Int, 8, ParameterDirection.Input, analystincharge);
                myparam[8] = ModHelper.CreateParameter("@TestResultSummary", SqlDbType.NVarChar, 400, ParameterDirection.Input, TestResultSummary);
                myparam[9] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, createdby);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_Update_tblOOS_Bulk", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblOOS_Bulk()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[3];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@Fno", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[1] = ModHelper.CreateParameter("@MfgWo", SqlDbType.NVarChar, 150, ParameterDirection.Input, mfgwo);
                myparam[2] = ModHelper.CreateParameter("@BulkMethodno", SqlDbType.BigInt, 8, ParameterDirection.Input, bulkmethodno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblOOS_Bulk", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert_Update_tblOOS_LaboratoryInvestigation()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[16];
                myparam[0] = ModHelper.CreateParameter("@OOSID", SqlDbType.BigInt, 8, ParameterDirection.Input, oosid);
                myparam[1] = ModHelper.CreateParameter("@SmapleBatchno", SqlDbType.NVarChar, 150, ParameterDirection.Input, smaplebatchno);
                myparam[2] = ModHelper.CreateParameter("@SampleInitialResult", SqlDbType.NVarChar, 150, ParameterDirection.Input, sampleinitialresult);
                myparam[3] = ModHelper.CreateParameter("@LaboratoryInvestigationResult", SqlDbType.NVarChar, 150, ParameterDirection.Input, laboratoryinvestigationresult);
                myparam[4] = ModHelper.CreateParameter("@LaboratoryInvestigationResult1", SqlDbType.NVarChar, 150, ParameterDirection.Input, laboratoryinvestigationresult1);
                myparam[5] = ModHelper.CreateParameter("@LaboratoryInvestigationResult2", SqlDbType.NVarChar, 150, ParameterDirection.Input, laboratoryinvestigationresult2);
                myparam[6] = ModHelper.CreateParameter("@LaboratoryInvestigationAverage1and2", SqlDbType.NVarChar, 150, ParameterDirection.Input, laboratoryinvestigationaverage1and2);
                myparam[7] = ModHelper.CreateParameter("@LaboratoryInvestigationRepeatability", SqlDbType.NVarChar, 150, ParameterDirection.Input, laboratoryinvestigationrepeatability);
                myparam[8] = ModHelper.CreateParameter("@LaboratoryInvestigationDiffrence", SqlDbType.NVarChar, 150, ParameterDirection.Input, laboratoryinvestigationdiffrence);
                myparam[9] = ModHelper.CreateParameter("@LaboratoryInvestigationInitialResult", SqlDbType.NVarChar, 150, ParameterDirection.Input, laboratoryinvestigationinitialresult);
                myparam[10] = ModHelper.CreateParameter("@LaboratoryInvestigationReAnalysisResult", SqlDbType.NVarChar, 150, ParameterDirection.Input, laboratoryinvestigationreanalysisresult);
                myparam[11] = ModHelper.CreateParameter("@LaboratoryInvestigationReProducibility", SqlDbType.NVarChar, 150, ParameterDirection.Input, laboratoryinvestigationreproducibility);
                myparam[12] = ModHelper.CreateParameter("@Reanalysis", SqlDbType.NVarChar, 50, ParameterDirection.Input, reanalysis);
                myparam[13] = ModHelper.CreateParameter("@LaboratoryInvestigationConclusion", SqlDbType.NVarChar, 400, ParameterDirection.Input, laboratoryinvestigationconclusion);
                myparam[14] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, createdby);
                myparam[15] = ModHelper.CreateParameter("@Laberror", SqlDbType.NVarChar, 50, ParameterDirection.Input, laberror);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_Update_tblOOS_LaboratoryInvestigation", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblOOS_LaboratoryInvestigation()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@OOSID", SqlDbType.BigInt, 8, ParameterDirection.Input, oosid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblOOS_LaboratoryInvestigation", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert_tblOOS_LabDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[5];
                myparam[0] = ModHelper.CreateParameter("@Srno", SqlDbType.Int, 4, ParameterDirection.Input, srno);
                myparam[1] = ModHelper.CreateParameter("@OOSID", SqlDbType.BigInt, 8, ParameterDirection.Input, oosid);
                myparam[2] = ModHelper.CreateParameter("@Parameters", SqlDbType.NVarChar, 400, ParameterDirection.Input, parameters);
                myparam[3] = ModHelper.CreateParameter("@Observations", SqlDbType.NVarChar, 50, ParameterDirection.Input, observations);
                myparam[4] = ModHelper.CreateParameter("@Comments", SqlDbType.NVarChar, 400, ParameterDirection.Input, comments);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblOOS_LabDetails", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblOOS_LabDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@OOSID", SqlDbType.BigInt, 8, ParameterDirection.Input, oosid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblOOS_LabDetails", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete_tblOOS_LabDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@OOSID", SqlDbType.BigInt, 8, ParameterDirection.Input, oosid);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblOOS_LabDetails", myparam);
                //return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert_tblOOS_Chromatography()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@OOSID", SqlDbType.BigInt, 8, ParameterDirection.Input, oosid);
                myparam[1] = ModHelper.CreateParameter("@Parameters", SqlDbType.NVarChar, 400, ParameterDirection.Input, parameters);
                myparam[2] = ModHelper.CreateParameter("@Observations", SqlDbType.NVarChar, 50, ParameterDirection.Input, observations);
                myparam[3] = ModHelper.CreateParameter("@Comments", SqlDbType.NVarChar, 400, ParameterDirection.Input, comments);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblOOS_Chromatography", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert_tblOOS_LabErrorIdentified()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@OOSID", SqlDbType.BigInt, 8, ParameterDirection.Input, oosid);
                myparam[1] = ModHelper.CreateParameter("@Parameters", SqlDbType.NVarChar, 400, ParameterDirection.Input, parameters);
                myparam[2] = ModHelper.CreateParameter("@Observations", SqlDbType.NVarChar, 50, ParameterDirection.Input, observations);
                myparam[3] = ModHelper.CreateParameter("@Comments", SqlDbType.NVarChar, 400, ParameterDirection.Input, comments);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblOOS_LabErrorIdentified", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert_Update_tblOOS_LabError()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[10];
                myparam[0] = ModHelper.CreateParameter("@OOSID", SqlDbType.BigInt, 8, ParameterDirection.Input, oosid);
                myparam[1] = ModHelper.CreateParameter("@Result1", SqlDbType.NVarChar, 50, ParameterDirection.Input, result1);
                myparam[2] = ModHelper.CreateParameter("@Result2", SqlDbType.NVarChar, 50, ParameterDirection.Input, result2);
                myparam[3] = ModHelper.CreateParameter("@Average", SqlDbType.NVarChar, 50, ParameterDirection.Input, average);
                myparam[4] = ModHelper.CreateParameter("@Repeatability", SqlDbType.NVarChar, 150, ParameterDirection.Input, repeatability);
                myparam[5] = ModHelper.CreateParameter("@Conculsion", SqlDbType.NVarChar, 150, ParameterDirection.Input, conculsion);
                myparam[7] = ModHelper.CreateParameter("@QCAnalyst", SqlDbType.BigInt, 8, ParameterDirection.Input, qcanalyst);
                myparam[8] = ModHelper.CreateParameter("@CompletionDate", SqlDbType.DateTime, 50, ParameterDirection.Input, Convert.ToDateTime(completionDate));
                myparam[9] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, createdby);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_Update_tblOOS_LabError", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert_Update_tblOOS_Resampling()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[20];
                myparam[0] = ModHelper.CreateParameter("@OOSID", SqlDbType.BigInt, 8, ParameterDirection.Input, oosid);
                myparam[1] = ModHelper.CreateParameter("@ReSample", SqlDbType.NVarChar, 50, ParameterDirection.Input, resample);
                myparam[2] = ModHelper.CreateParameter("@Result1", SqlDbType.NVarChar, 50, ParameterDirection.Input, result1);
                myparam[3] = ModHelper.CreateParameter("@Result2", SqlDbType.NVarChar, 50, ParameterDirection.Input, result2);
                myparam[4] = ModHelper.CreateParameter("@Average", SqlDbType.NVarChar, 50, ParameterDirection.Input, average);
                myparam[5] = ModHelper.CreateParameter("@Repeatablity", SqlDbType.NVarChar, 50, ParameterDirection.Input, repeatability);
                myparam[6] = ModHelper.CreateParameter("@QCAnalyst", SqlDbType.BigInt, 8, ParameterDirection.Input, qcanalyst);
                myparam[7] = ModHelper.CreateParameter("@CompletionDate", SqlDbType.DateTime, 50, ParameterDirection.Input, Convert.ToDateTime(completionDate));
                myparam[8] = ModHelper.CreateParameter("@Conclusion", SqlDbType.NVarChar, 400, ParameterDirection.Input, conclusion);
                myparam[9] = ModHelper.CreateParameter("@Simulating", SqlDbType.NVarChar, 400, ParameterDirection.Input, simulating);
                myparam[10] = ModHelper.CreateParameter("@ResonResult1", SqlDbType.NVarChar, 50, ParameterDirection.Input, resonResult1);
                myparam[11] = ModHelper.CreateParameter("@ResonResult2", SqlDbType.NVarChar, 50, ParameterDirection.Input, resonResult2);
                myparam[12] = ModHelper.CreateParameter("@ResonAverage", SqlDbType.NVarChar, 50, ParameterDirection.Input, resonaverage);
                myparam[13] = ModHelper.CreateParameter("@ResonRepeatability", SqlDbType.NVarChar, 50, ParameterDirection.Input, resonrepeatability);
                myparam[14] = ModHelper.CreateParameter("@FinalRemark", SqlDbType.NVarChar, 400, ParameterDirection.Input, finalremark);
                myparam[15] = ModHelper.CreateParameter("@OOSValid", SqlDbType.NVarChar, 50, ParameterDirection.Input, oosvalid);
                myparam[16] = ModHelper.CreateParameter("@Proceed", SqlDbType.NVarChar, 50, ParameterDirection.Input, proceed);
                myparam[17] = ModHelper.CreateParameter("@HeadQualityControl", SqlDbType.BigInt, 8, ParameterDirection.Input, headqualitycontrol);
                myparam[18] = ModHelper.CreateParameter("@ResonCompletionDate", SqlDbType.DateTime, 50, ParameterDirection.Input, Convert.ToDateTime(resoncompletiondate));
                myparam[19] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, createdby);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_Update_tblOOS_Resampling", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_LabDetailsID_tblOOS_LabDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@OOSID", SqlDbType.BigInt, 8, ParameterDirection.Input, oosid);
                myparam[1] = ModHelper.CreateParameter("@Parameters", SqlDbType.NVarChar, 400, ParameterDirection.Input, parameters);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STO_Select_LabDetailsID_tblOOS_LabDetails", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert_tblOOS_LabError_Instruments()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@LabDetailsID", SqlDbType.BigInt, 8, ParameterDirection.Input, labdetailsid);
                myparam[1] = ModHelper.CreateParameter("@InstrumentUsed", SqlDbType.NVarChar, 400, ParameterDirection.Input, instrumentused);
                myparam[2] = ModHelper.CreateParameter("@CalibrationDue", SqlDbType.DateTime, 50, ParameterDirection.Input, Convert.ToDateTime(calibrationdue));
                myparam[3] = ModHelper.CreateParameter("@OOSID", SqlDbType.BigInt, 8, ParameterDirection.Input, oosid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblOOS_LabError_Instruments", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool STP_Insert_tblOOS_LabError_Solution()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[5];
                myparam[0] = ModHelper.CreateParameter("@LabDetailsID", SqlDbType.BigInt, 8, ParameterDirection.Input, labdetailsid);
                myparam[1] = ModHelper.CreateParameter("@SolutionUsed", SqlDbType.NVarChar, 400, ParameterDirection.Input, solutionused);
                myparam[2] = ModHelper.CreateParameter("@ValidUptoDate", SqlDbType.DateTime, 50, ParameterDirection.Input, Convert.ToDateTime(validuptodate));
                myparam[3] = ModHelper.CreateParameter("@Strength", SqlDbType.NVarChar, 400, ParameterDirection.Input, strength);
                myparam[4] = ModHelper.CreateParameter("@OOSID", SqlDbType.BigInt, 8, ParameterDirection.Input, oosid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblOOS_LabError_Solution", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblOOS()
        {
            try
            {
                //SqlParameter[] myparam = new SqlParameter[2];
                //DataSet ds = new DataSet();
                //myparam[0] = ModHelper.CreateParameter("@OOSID", SqlDbType.BigInt, 8, ParameterDirection.Input, oosid);
                //myparam[1] = ModHelper.CreateParameter("@Parameters", SqlDbType.NVarChar, 400, ParameterDirection.Input, parameters);
                //ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblOOS", myparam);
                //return ds;

                //SqlParameter[] myparam = new SqlParameter[2];
                DataSet ds = new DataSet();
                //myparam[0] = ModHelper.CreateParameter("@OOSID", SqlDbType.BigInt, 8, ParameterDirection.Input, oosid);
                //myparam[1] = ModHelper.CreateParameter("@Parameters", SqlDbType.NVarChar, 400, ParameterDirection.Input, parameters);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblOOS");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_OOSDetails_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@OOSID", SqlDbType.BigInt, 8, ParameterDirection.Input, oosid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_OOSDetails_Report", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_tblOOS_LabDetails_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@OOSID", SqlDbType.BigInt, 8, ParameterDirection.Input, oosid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_tblOOS_LabDetails_Report", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_tblOOS_Chromatography_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@OOSID", SqlDbType.BigInt, 8, ParameterDirection.Input, oosid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_tblOOS_Chromatography_Report", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_tblOOS_LabErrorIdentified_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@OOSID", SqlDbType.BigInt, 8, ParameterDirection.Input, oosid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_tblOOS_LabErrorIdentified_Report", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Select_tblOOS_Resampling_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@OOSID", SqlDbType.BigInt, 8, ParameterDirection.Input, oosid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_tblOOS_Resampling_Report", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert_Update_tblOOS_MI_Parameters()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[5];
                myparam[0] = ModHelper.CreateParameter("@OOSID", SqlDbType.BigInt, 8, ParameterDirection.Input, oosid);
                myparam[1] = ModHelper.CreateParameter("@Srno", SqlDbType.Int, 4, ParameterDirection.Input, srno);
                myparam[2] = ModHelper.CreateParameter("@Parameters", SqlDbType.NVarChar, 400, ParameterDirection.Input, parameters);
                myparam[3] = ModHelper.CreateParameter("@Observation", SqlDbType.NVarChar, 50, ParameterDirection.Input, observations);
                myparam[4] = ModHelper.CreateParameter("@Comments", SqlDbType.NVarChar, 400, ParameterDirection.Input, comments);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_Update_tblOOS_MI_Parameters", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert_Update_tblOOS_MIDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[8];
                myparam[0] = ModHelper.CreateParameter("@OOSID", SqlDbType.BigInt, 8, ParameterDirection.Input, oosid);
                myparam[1] = ModHelper.CreateParameter("@Summary", SqlDbType.NVarChar, 400, ParameterDirection.Input, summary);
                myparam[2] = ModHelper.CreateParameter("@FinalDecision", SqlDbType.NVarChar, 400, ParameterDirection.Input, finaldecision);
                myparam[3] = ModHelper.CreateParameter("@UpManager", SqlDbType.BigInt, 8, ParameterDirection.Input, upmanager);
                myparam[4] = ModHelper.CreateParameter("@ProcessExpert", SqlDbType.BigInt, 8, ParameterDirection.Input, processexpert);
                myparam[5] = ModHelper.CreateParameter("@QualityHead", SqlDbType.BigInt, 8, ParameterDirection.Input, qualityhead);
                myparam[6] = ModHelper.CreateParameter("@CompletionDate", SqlDbType.DateTime, 50, ParameterDirection.Input, Convert.ToDateTime(completionDate));
                myparam[7] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, createdby);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_Update_tblOOS_MIDetails", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblOOS_MIDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@OOSID", SqlDbType.BigInt, 8, ParameterDirection.Input, oosid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblOOS_MIDetails", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_tblOOS_MI_Parameters_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@OOSID", SqlDbType.BigInt, 8, ParameterDirection.Input, oosid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_tblOOS_MI_Parameters_Report", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert_Update_tblOOS_FG()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[11];
                myparam[0] = ModHelper.CreateParameter("@Fno", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[1] = ModHelper.CreateParameter("@MfgWo", SqlDbType.NVarChar, 150, ParameterDirection.Input, mfgwo);
                myparam[2] = ModHelper.CreateParameter("@BulkMethodno", SqlDbType.BigInt, 8, ParameterDirection.Input, bulkmethodno);
                myparam[3] = ModHelper.CreateParameter("@OccurenceDate", SqlDbType.DateTime, 50, ParameterDirection.Input, Convert.ToDateTime(occurencedate));
                myparam[4] = ModHelper.CreateParameter("@ProductName", SqlDbType.NVarChar, 150, ParameterDirection.Input, productname);
                myparam[5] = ModHelper.CreateParameter("@TestName", SqlDbType.NVarChar, 150, ParameterDirection.Input, testname);
                myparam[6] = ModHelper.CreateParameter("@BatchNumber", SqlDbType.NVarChar, 150, ParameterDirection.Input, batchnumber);
                myparam[7] = ModHelper.CreateParameter("@AnalystIncharge", SqlDbType.Int, 8, ParameterDirection.Input, analystincharge);
                myparam[8] = ModHelper.CreateParameter("@TestResultSummary", SqlDbType.NVarChar, 400, ParameterDirection.Input, TestResultSummary);
                myparam[9] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, createdby);
                myparam[10] = ModHelper.CreateParameter("@Tankno", SqlDbType.Int, 4, ParameterDirection.Input, tankno);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_Update_tblOOS_FG", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblOOS_FG()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@Fno", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[1] = ModHelper.CreateParameter("@MfgWo", SqlDbType.NVarChar, 150, ParameterDirection.Input, mfgwo);
                myparam[2] = ModHelper.CreateParameter("@BulkMethodno", SqlDbType.BigInt, 8, ParameterDirection.Input, bulkmethodno);
                myparam[3] = ModHelper.CreateParameter("@Tankno", SqlDbType.Int, 4, ParameterDirection.Input, tankno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblOOS_FG", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
