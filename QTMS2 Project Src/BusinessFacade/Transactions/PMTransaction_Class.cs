using System;
using System.Collections.Generic;
using System.Text;
using DataFacade;
using System.Data;
using System.Data.SqlClient;

namespace BusinessFacade.Transactions
{
    public class PMTransaction_Class
    {
        #region Variables
        private long PMSupplierCOCID;
        private long PMSupplCOCID;
        private long PMFamilyID;
        private long PMTransID;
        private long PMSamplingID;
        private long QuantityReceived;
        private long QuantitySampled;
        private long Quantity;

        private int NoOfPallets;
        private int NoOfShippers;
        private int SampleSizeReading;
        private int CurrentFlag;
        private int Treatmented;
        private int TreatmentDone;
        private int ChangedStatus;
        private int LoginID;

        private string Type;
        private string LotSize;
        private string TestName;
        private string InspectionMethod;
        private long FGMethodNo;
        private string Status;
        private string ActualStatus;
        private string ControlType;
        private string InspDate;
        private string AcceptedDate;
        private string ReceiptDate;
        private string PlantLotNo;
        private string RejectComment;
        private string SpecificationNo;
        private string ChallanNo;
        private string MRR;
        private string SRR;
        private string LaunchRegular;
        private string DefectObserved;
        private string DefectComment;
        private string FirstPMReception;
        private string AQLReading;
        private string AQLZReading;
        private string AQLCReading;
        private string AQLMReading;
        private string AQLM1Reading;
        private string Frequency;
        private long PMTestID;
        private int LNo;
        private string DefectQuantity;
        private int NoOfBatches;
        private string Description;
        private string Comment;
        private int Count;
        private string COCApplicable;
        private string TransCOC;
        private int COCFrequency;
        private int AnalysisDone;
        private string CDCVersion;
        private int NoOfDefect;
        private string QualityDecision;
        private int OpenBy;
        private int CloseBy;
        private string DefectStatus;
        private long DefectID;
        private long PMChangeID;
        private string ActionTaken;
        private long PMDefectID;
        private long PMCodeID;
        public string CheckDate;

        private int LotReturn;
        private int Complete;
        private int Partly;
        private long PartlyQuantity;
        private int OnlineSorted;
        private int LotComsumption;
        private string Remark;


        #endregion

        #region Properties
        public long pmcodeid
        {
            get { return PMCodeID; }
            set { PMCodeID = value; }
        }
        public long pmdefectid
        {
            get { return PMDefectID; }
            set { PMDefectID = value; }
        }
        public string actiontaken
        {
            get { return ActionTaken; }
            set { ActionTaken = value; }
        }
        public long pmchangeid
        {
            get { return PMChangeID; }
            set { PMChangeID = value; }
        }
        public long defectid
        {
            get { return DefectID; }
            set { DefectID = value; }
        }
        public string defectstatus
        {
            get { return DefectStatus; }
            set { DefectStatus = value; }
        }
        public string qualitydecision
        {
            get { return QualityDecision; }
            set { QualityDecision = value; }
        }
        public int noofdefect
        {
            get { return NoOfDefect; }
            set { NoOfDefect = value; }
        }
        public string cdcversion
        {
            get { return CDCVersion; }
            set { CDCVersion = value; }
        }
        public int analysisdone
        {
            get { return AnalysisDone; }
            set { AnalysisDone = value; }
        }
        public string cocapplicable
        {
            get { return COCApplicable; }
            set { COCApplicable = value; }
        }
        public string transcoc
        {
            get { return TransCOC; }
            set { TransCOC = value; }
        }
        public int cocfrequency
        {
            get { return COCFrequency; }
            set { COCFrequency = value; }
        }
        public int count
        {
            get { return Count; }
            set { Count = value; }
        }
        public long pmsuppliercocid
        {
            get { return PMSupplierCOCID; }
            set { PMSupplierCOCID = value; }
        }
        public long pmsupplcocid
        {
            get { return PMSupplCOCID; }
            set { PMSupplCOCID = value; }
        }
        public long quantity
        {
            get { return Quantity; }
            set { Quantity = value; }
        }
        public int loginid
        {
            get { return LoginID; }
            set { LoginID = value; }
        }
        public long fgmethodno
        {
            get { return FGMethodNo; }
            set { FGMethodNo = value; }
        }
        public int currentflag
        {
            get { return CurrentFlag; }
            set { CurrentFlag = value; }
        }
        public long pmsamplingid
        {
            get { return PMSamplingID; }
            set { PMSamplingID = value; }
        }
        public long pmtestid
        {
            get { return PMTestID; }
            set { PMTestID = value; }
        }
        public long quantityreceived
        {
            get { return QuantityReceived; }
            set { QuantityReceived = value; }
        }
        public long quantitysampled
        {
            get { return QuantitySampled; }
            set { QuantitySampled = value; }
        }
        public int noofpallets
        {
            get { return NoOfPallets; }
            set { NoOfPallets = value; }
        }
        public int noofshippers
        {
            get { return NoOfShippers; }
            set { NoOfShippers = value; }
        }
        public int samplesizereading
        {
            get { return SampleSizeReading; }
            set { SampleSizeReading = value; }
        }
        public int treatmentdone
        {
            get { return TreatmentDone; }
            set { TreatmentDone = value; }
        }
        public int treatmented
        {
            get { return Treatmented; }
            set { Treatmented = value; }
        }
        public int changedstatus
        {
            get { return ChangedStatus; }
            set { ChangedStatus = value; }
        }
        public long pmtransid
        {
            get { return PMTransID; }
            set { PMTransID = value; }
        }
        public string type
        {
            get { return Type; }
            set { Type = value; }
        }
        public string inspectionmethod
        {
            get { return InspectionMethod; }
            set { InspectionMethod = value; }
        }
        public string testname
        {
            get { return TestName; }
            set { TestName = value; }
        }
        public string lotsize
        {
            get { return LotSize; }
            set { LotSize = value; }
        }
        public string status
        {
            get { return Status; }
            set { Status = value; }
        }
        public string actualstatus
        {
            get { return ActualStatus; }
            set { ActualStatus = value; }
        }
        public string controltype
        {
            get { return ControlType; }
            set { ControlType = value; }
        }
        public string inspdate
        {
            get { return InspDate; }
            set { InspDate = value; }
        }
        public string accepteddate
        {
            get { return AcceptedDate; }
            set { AcceptedDate = value; }
        }

        public string receiptdate
        {
            get { return ReceiptDate; }
            set { ReceiptDate = value; }
        }
        public string plantlotno
        {
            get { return PlantLotNo; }
            set { PlantLotNo = value; }
        }
        public string rejectcomment
        {
            get { return RejectComment; }
            set { RejectComment = value; }
        }
        public string specificationno
        {
            get { return SpecificationNo; }
            set { SpecificationNo = value; }
        }
        public string challanno
        {
            get { return ChallanNo; }
            set { ChallanNo = value; }
        }
        public string mrr
        {
            get { return MRR; }
            set { MRR = value; }
        }
        public string srr
        {
            get { return SRR; }
            set { SRR = value; }
        }
        public string launchregular
        {
            get { return LaunchRegular; }
            set { LaunchRegular = value; }
        }
        public string defectobserved
        {
            get { return DefectObserved; }
            set { DefectObserved = value; }
        }
        public string defectcomment
        {
            get { return DefectComment; }
            set { DefectComment = value; }
        }
        public string firstpmreception
        {
            get { return FirstPMReception; }
            set { FirstPMReception = value; }
        }
        public string aqlreading
        {
            get { return AQLReading; }
            set { AQLReading = value; }
        }
        public string aqlzreading
        {
            get { return AQLZReading; }
            set { AQLZReading = value; }
        }
        public string aqlcreading
        {
            get { return AQLCReading; }
            set { AQLCReading = value; }
        }
        public string aqlmreading
        {
            get { return AQLMReading; }
            set { AQLMReading = value; }
        }
        public string aqlm1reading
        {
            get { return AQLM1Reading; }
            set { AQLM1Reading = value; }
        }
        public string frequency
        {
            get { return Frequency; }
            set { Frequency = value; }
        }
        public long pmfamilyid
        {
            get { return PMFamilyID; }
            set { PMFamilyID = value; }
        }
        public string defectquantity
        {
            get { return DefectQuantity; }
            set { DefectQuantity = value; }
        }
        public int noofbatches
        {
            get { return NoOfBatches; }
            set { NoOfBatches = value; }
        }
        public string comment
        {
            get { return Comment; }
            set { Comment = value; }
        }
        public string description
        {
            get { return Description; }
            set { Description = value; }
        }
        private int SampleSize;
        public int samplesize
        {
            get { return SampleSize; }
            set { SampleSize = value; }
        }
        private string AQL;

        public string aql
        {
            get { return AQL; }
            set { AQL = value; }
        }
        private string AQLZ;

        public string aqlz
        {
            get { return AQLZ; }
            set { AQLZ = value; }
        }
        private string AQLC;

        public string aqlc
        {
            get { return AQLC; }
            set { AQLC = value; }
        }
        private string AQLM;

        public string aqlm
        {
            get { return AQLM; }
            set { AQLM = value; }
        }
        //
        private char DefStatus;

        public char defstatus
        {
            get { return DefStatus; }
            set { DefStatus = value; }
        }
        //

        private string AQLM1; //defectstatus

        public string aqlm1
        {
            get { return AQLM1; }
            set { AQLM1 = value; }
        }

        private int FromAnalysisReanalysis;

        public int fromAnalysisReanalysis
        {
            get { return FromAnalysisReanalysis; }
            set { FromAnalysisReanalysis = value; }
        }

        private string LineNumber;

        public string lineNumber
        {
            get { return LineNumber; }
            set { LineNumber = value; }
        }

        private string FileName;

        public string fileName
        {
            get { return FileName; }
            set { FileName = value; }
        }

        private string FileExtension;

        public string fileExtension
        {
            get { return FileExtension; }
            set { FileExtension = value; }
        }

        private byte[] FileData;

        public byte[] fileData
        {
            get { return FileData; }
            set { FileData = value; }
        }
        private long CorrectiveNoteID;

        public long correctiveNoteID
        {
            get { return CorrectiveNoteID; }
            set { CorrectiveNoteID = value; }
        }

        private long TestNo;

        public long testNo
        {
            get { return TestNo; }
            set { TestNo = value; }
        }

        // This property used for dimension 
        private long DPTransStatusID;

        public long dpTransStatusID
        {
            get { return DPTransStatusID; }
            set { DPTransStatusID = value; }
        }

        public string checkDate
        {
            get { return CheckDate; }
            set { CheckDate = value; }
        
        }


        public int lotcomsumption
        {
            get { return LotComsumption; }
            set { LotComsumption = value; }
        }
        public int lotreturn
        {
            get { return LotReturn; }
            set { LotReturn = value; }
        }
        public int complete
        {
            get { return Complete; }
            set { Complete = value; }
        }
        public int partly
        {
            get { return Partly; }
            set { Partly = value; }
        }
        public long partlyquantity
        {
            get { return PartlyQuantity; }
            set { PartlyQuantity = value; }
        }
        public int onlinesorted
        {
            get { return OnlineSorted; }
            set { OnlineSorted = value; }
        }
        public string remark
        {
            get { return Remark; }
            set { Remark = value; }
        }

        #endregion

        #region Functions
        public DataSet Select_PMCodeMaster_PMSupplierMaster_PMSupplierCOC()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblPMCodeMaster_tblPMSupplierMaster_tblPMSupplierCOC");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_PMCodeMaster_PMSupplierMaster_PMSupplierCOC_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblPMCodeMaster_tblPMSupplierMaster_tblPMSupplierCOC_Report");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_ModificationPMDetails()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_ModificationPMDetails");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_ModificationPMDetails_Details()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@PMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmtransid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_ModificationPMDetails_Details", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // If PMCode assign test then goes to this STP
        public DataSet Select_View_PMFGMethodDetails_TestNo_TestName_PMCodeID()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[5];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@PMFamilyID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmfamilyid);
                myparam[1] = ModHelper.CreateParameter("@Type", SqlDbType.VarChar, 50, ParameterDirection.Input, Type);
                myparam[2] = ModHelper.CreateParameter("@LotSize", SqlDbType.VarChar, 50, ParameterDirection.Input, LotSize);
                myparam[3] = ModHelper.CreateParameter("@Frequency", SqlDbType.VarChar, 50, ParameterDirection.Input, frequency);
                myparam[4] = ModHelper.CreateParameter("@PMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmcodeid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Select_View_PMFGMethodDetails_TestNo_TestName_PMCodeID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // If PMCode does not assign test then goes to this STP
        public DataSet Select_View_PMFGMethodDetails_TestNo_TestName()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@PMFamilyID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmfamilyid);
                myparam[1] = ModHelper.CreateParameter("@Type", SqlDbType.VarChar, 50, ParameterDirection.Input, Type);
                myparam[2] = ModHelper.CreateParameter("@LotSize", SqlDbType.VarChar, 50, ParameterDirection.Input, LotSize);
                myparam[3] = ModHelper.CreateParameter("@Frequency", SqlDbType.VarChar, 50, ParameterDirection.Input, frequency);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Select_View_PMFGMethodDetails_TestNo_TestName", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_ModificationPMFGMethodDetails_TestNo_TestName()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[6];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@PMFamilyID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmfamilyid);
                myparam[1] = ModHelper.CreateParameter("@Type", SqlDbType.VarChar, 50, ParameterDirection.Input, Type);
                myparam[2] = ModHelper.CreateParameter("@LotSize", SqlDbType.VarChar, 50, ParameterDirection.Input, LotSize);
                myparam[3] = ModHelper.CreateParameter("@Frequency", SqlDbType.VarChar, 50, ParameterDirection.Input, frequency);
                myparam[4] = ModHelper.CreateParameter("@PMCodeID", SqlDbType.VarChar, 50, ParameterDirection.Input, pmcodeid);
                myparam[5] = ModHelper.CreateParameter("@PMChangeID", SqlDbType.VarChar, 50, ParameterDirection.Input, pmchangeid);

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_ModificationPMFGMethodDetails_TestNo_TestName", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_View_PMFGMethodDetails_InspectionMethod()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[5];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@TestName", SqlDbType.VarChar, 250, ParameterDirection.Input, TestName);
                myparam[1] = ModHelper.CreateParameter("@PMFamilyID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmfamilyid);
                myparam[2] = ModHelper.CreateParameter("@Type", SqlDbType.VarChar, 50, ParameterDirection.Input, type);
                myparam[3] = ModHelper.CreateParameter("@LotSize", SqlDbType.VarChar, 50, ParameterDirection.Input, lotsize);
                myparam[4] = ModHelper.CreateParameter("@Frequency", SqlDbType.VarChar, 50, ParameterDirection.Input, frequency);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Select_PMFGMethodDetails_InspectionMethod", myparam);   // OLD Procedure Select_View_PMFGMethodDetails_InspectionMethod
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // This procedure for PM Modification Test
        public DataSet Select_View_PMFGMethodDetails_InspectionMethod_Modification()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[5];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@TestName", SqlDbType.VarChar, 250, ParameterDirection.Input, TestName);
                myparam[1] = ModHelper.CreateParameter("@PMFamilyID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmfamilyid);
                myparam[2] = ModHelper.CreateParameter("@Type", SqlDbType.VarChar, 50, ParameterDirection.Input, type);
                myparam[3] = ModHelper.CreateParameter("@LotSize", SqlDbType.VarChar, 50, ParameterDirection.Input, lotsize);
                myparam[4] = ModHelper.CreateParameter("@Frequency", SqlDbType.VarChar, 50, ParameterDirection.Input, frequency);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Select_View_PMFGMethodDetails_InspectionMethod", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Select_PMFGTestMethodMaster_FGMethodNo()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[7];

                myparam[0] = ModHelper.CreateParameter("@PMFamilyID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmfamilyid);
                myparam[1] = ModHelper.CreateParameter("@TestName", SqlDbType.VarChar, 250, ParameterDirection.Input, TestName);
                myparam[2] = ModHelper.CreateParameter("@InspectionMethod", SqlDbType.VarChar, 50, ParameterDirection.Input, inspectionmethod);
                myparam[3] = ModHelper.CreateParameter("@Type", SqlDbType.VarChar, 50, ParameterDirection.Input, type);
                myparam[4] = ModHelper.CreateParameter("@LotSize", SqlDbType.VarChar, 50, ParameterDirection.Input, lotsize);
                myparam[5] = ModHelper.CreateParameter("@Frequency", SqlDbType.VarChar, 50, ParameterDirection.Input, frequency);
                myparam[6] = ModHelper.CreateParameter("@FGMethodNo", SqlDbType.BigInt, 8, ParameterDirection.Output);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Select_tblPMFGTestMethodMaster_FGMethodNo", myparam);
                if(myparam[6].Value!=DBNull.Value)
                FGMethodNo = Convert.ToInt64(myparam[6].Value);

                return FGMethodNo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_PMFGTestMethodMaster_All()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[6];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@TestName", SqlDbType.VarChar, 250, ParameterDirection.Input, testname);
                myparam[1] = ModHelper.CreateParameter("@PMFamilyID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmfamilyid);
                myparam[2] = ModHelper.CreateParameter("@Type", SqlDbType.VarChar, 50, ParameterDirection.Input, type);
                myparam[3] = ModHelper.CreateParameter("@LotSize", SqlDbType.VarChar, 50, ParameterDirection.Input, lotsize);
                myparam[4] = ModHelper.CreateParameter("@InspectionMethod", SqlDbType.VarChar, 50, ParameterDirection.Input, inspectionmethod);
                myparam[5] = ModHelper.CreateParameter("@Frequency", SqlDbType.VarChar, 50, ParameterDirection.Input, frequency);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Select_PMFGMethodDetails_All", myparam); // Old Procedure Select_VIEW_PMFGMethodDetails_All
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // This procedure for PM Modification Test all readings

        public DataSet Select_PMFGTestMethodMaster_All_Modification()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[6];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@TestName", SqlDbType.VarChar, 250, ParameterDirection.Input, testname);
                myparam[1] = ModHelper.CreateParameter("@PMFamilyID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmfamilyid);
                myparam[2] = ModHelper.CreateParameter("@Type", SqlDbType.VarChar, 50, ParameterDirection.Input, type);
                myparam[3] = ModHelper.CreateParameter("@LotSize", SqlDbType.VarChar, 50, ParameterDirection.Input, lotsize);
                myparam[4] = ModHelper.CreateParameter("@InspectionMethod", SqlDbType.VarChar, 50, ParameterDirection.Input, inspectionmethod);
                myparam[5] = ModHelper.CreateParameter("@Frequency", SqlDbType.VarChar, 50, ParameterDirection.Input, frequency);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Select_VIEW_PMFGMethodDetails_All", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // New Change for accept readings in modification
        public DataSet Select_PMFGMethodDetails_PMTransID()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[7];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@TestName", SqlDbType.VarChar, 250, ParameterDirection.Input, testname);
                myparam[1] = ModHelper.CreateParameter("@PMFamilyID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmfamilyid);
                myparam[2] = ModHelper.CreateParameter("@Type", SqlDbType.VarChar, 50, ParameterDirection.Input, type);
                myparam[3] = ModHelper.CreateParameter("@LotSize", SqlDbType.VarChar, 50, ParameterDirection.Input, lotsize);
                myparam[4] = ModHelper.CreateParameter("@InspectionMethod", SqlDbType.VarChar, 50, ParameterDirection.Input, inspectionmethod);
                myparam[5] = ModHelper.CreateParameter("@Frequency", SqlDbType.VarChar, 50, ParameterDirection.Input, frequency);
                myparam[6] = ModHelper.CreateParameter("@PMTransID", SqlDbType.VarChar, 250, ParameterDirection.Input, pmtransid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Select_PMFGMethodDetails_PMTransID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public long Insert_PMTransaction()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[7];
                myparam[0] = ModHelper.CreateParameter("@PMSupplierCOCID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmsuppliercocid);
                myparam[1] = ModHelper.CreateParameter("@PlantLotNo", SqlDbType.VarChar, 50, ParameterDirection.Input, plantlotno);
                myparam[2] = ModHelper.CreateParameter("@ControlType", SqlDbType.Char, 10, ParameterDirection.Input, type);
                myparam[3] = ModHelper.CreateParameter("@AnalysisDone", SqlDbType.Bit, 1, ParameterDirection.Input, analysisdone);
                myparam[4] = ModHelper.CreateParameter("@TransCOC", SqlDbType.Char, 1, ParameterDirection.Input, transcoc);
                myparam[5] = ModHelper.CreateParameter("@CDCVersion", SqlDbType.VarChar, 50, ParameterDirection.Input, cdcversion);
                myparam[6] = ModHelper.CreateParameter("@PMTransID", SqlDbType.BigInt, 8, ParameterDirection.Output);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblPMTransaction", myparam);

                PMTransID = Convert.ToInt64(myparam[6].Value);

                return PMTransID;
                //return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblPMSampling()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[6];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@PMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmtransid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblPMSampling", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Insert_PMSampling()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[5];
                myparam[0] = ModHelper.CreateParameter("@PMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmtransid);
                myparam[1] = ModHelper.CreateParameter("@QuantitySampled", SqlDbType.BigInt, 8, ParameterDirection.Input, quantitysampled);
                myparam[2] = ModHelper.CreateParameter("@NoOfPallets", SqlDbType.Int, 4, ParameterDirection.Input, noofpallets);
                myparam[3] = ModHelper.CreateParameter("@NoOfShippers", SqlDbType.Int, 4, ParameterDirection.Input, noofshippers);
                myparam[4] = ModHelper.CreateParameter("@PMSamplingID", SqlDbType.BigInt, 8, ParameterDirection.Output);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblPMSampling", myparam);

                PMSamplingID = Convert.ToInt64(myparam[4].Value);

                return PMSamplingID;
                //return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update_tblPMSampling()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@QuantitySampled", SqlDbType.BigInt, 8, ParameterDirection.Input, quantitysampled);
                myparam[1] = ModHelper.CreateParameter("@NoOfPallets", SqlDbType.Int, 4, ParameterDirection.Input, noofpallets);
                myparam[2] = ModHelper.CreateParameter("@NoOfShippers", SqlDbType.Int, 4, ParameterDirection.Input, noofshippers);
                myparam[3] = ModHelper.CreateParameter("@PMSamplingID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmsamplingid);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblPMSampling", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert_PMDetails()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[8];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@PMSamplingID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmsamplingid);
                myparam[1] = ModHelper.CreateParameter("@NoOfBatches", SqlDbType.Int, 4, ParameterDirection.Input, noofbatches);
                myparam[2] = ModHelper.CreateParameter("@SpecificationNo", SqlDbType.VarChar, 50, ParameterDirection.Input, specificationno);
                myparam[3] = ModHelper.CreateParameter("@ChallanNo", SqlDbType.VarChar, 50, ParameterDirection.Input, challanno);
                myparam[4] = ModHelper.CreateParameter("@MRR", SqlDbType.VarChar, 50, ParameterDirection.Input, mrr);
                myparam[5] = ModHelper.CreateParameter("@SRR", SqlDbType.Char, 1, ParameterDirection.Input, srr);
                myparam[6] = ModHelper.CreateParameter("@LaunchRegular", SqlDbType.Char, 1, ParameterDirection.Input, launchregular);
                myparam[7] = ModHelper.CreateParameter("@FirstPMReception", SqlDbType.Char, 1, ParameterDirection.Input, firstpmreception);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblPMDetails", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update_tblPMDetails()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[8];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@PMSamplingID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmsamplingid);
                myparam[1] = ModHelper.CreateParameter("@NoOfBatches", SqlDbType.Int, 4, ParameterDirection.Input, noofbatches);
                myparam[2] = ModHelper.CreateParameter("@SpecificationNo", SqlDbType.VarChar, 50, ParameterDirection.Input, specificationno);
                myparam[3] = ModHelper.CreateParameter("@ChallanNo", SqlDbType.VarChar, 50, ParameterDirection.Input, challanno);
                myparam[4] = ModHelper.CreateParameter("@MRR", SqlDbType.VarChar, 50, ParameterDirection.Input, mrr);
                myparam[5] = ModHelper.CreateParameter("@SRR", SqlDbType.Char, 1, ParameterDirection.Input, srr);
                myparam[6] = ModHelper.CreateParameter("@LaunchRegular", SqlDbType.Char, 1, ParameterDirection.Input, launchregular);
                myparam[7] = ModHelper.CreateParameter("@FirstPMReception", SqlDbType.Char, 1, ParameterDirection.Input, firstpmreception);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblPMDetails", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert_tblPMFGTestMethodDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[15];
                myparam[0] = ModHelper.CreateParameter("@PMChangeID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmchangeid);
                myparam[1] = ModHelper.CreateParameter("@FGMethodNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgmethodno);
                myparam[2] = ModHelper.CreateParameter("@SampleSizeReading", SqlDbType.Int, 4, ParameterDirection.Input, samplesizereading);
                myparam[3] = ModHelper.CreateParameter("@AQLReading", SqlDbType.VarChar, 50, ParameterDirection.Input, aqlreading);
                myparam[4] = ModHelper.CreateParameter("@AQLZReading", SqlDbType.VarChar, 50, ParameterDirection.Input, aqlzreading);
                myparam[5] = ModHelper.CreateParameter("@AQLCReading", SqlDbType.VarChar, 50, ParameterDirection.Input, aqlcreading);
                myparam[6] = ModHelper.CreateParameter("@AQLMReading", SqlDbType.VarChar, 50, ParameterDirection.Input, aqlmreading);
                myparam[7] = ModHelper.CreateParameter("@AQLM1Reading", SqlDbType.VarChar, 50, ParameterDirection.Input, aqlm1reading);
                myparam[8] = ModHelper.CreateParameter("@InspectionMethod", SqlDbType.VarChar, 50, ParameterDirection.Input, inspectionmethod);
                myparam[9] = ModHelper.CreateParameter("@AQL", SqlDbType.VarChar, 50, ParameterDirection.Input, aql);
                myparam[10] = ModHelper.CreateParameter("@AQLZ", SqlDbType.VarChar, 50, ParameterDirection.Input, aqlz);
                myparam[11] = ModHelper.CreateParameter("@AQLC", SqlDbType.VarChar, 50, ParameterDirection.Input, aqlc);
                myparam[12] = ModHelper.CreateParameter("@AQLM", SqlDbType.VarChar, 50, ParameterDirection.Input, aqlm);
                myparam[13] = ModHelper.CreateParameter("@AQLM1", SqlDbType.VarChar, 50, ParameterDirection.Input, aqlm1);
                myparam[14] = ModHelper.CreateParameter("@SampleSize", SqlDbType.Int, 4, ParameterDirection.Input, samplesize);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblPMFGTestMethodDetails", myparam);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete_tblPMTransaction()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@PMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmtransid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblPMTransaction", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete_tblPMFGTestMethodDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@PMChangeID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmchangeid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblPMFGTestMethodDetails", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Insert_PMStatus()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[11];
                myparam[0] = ModHelper.CreateParameter("@PMTestID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmtestid);
                myparam[1] = ModHelper.CreateParameter("@InspDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, inspdate);
                myparam[2] = ModHelper.CreateParameter("@DefectObserved", SqlDbType.Char, 1, ParameterDirection.Input, defectobserved);
                myparam[3] = ModHelper.CreateParameter("@NoOfDefect", SqlDbType.Int, 4, ParameterDirection.Input, noofdefect);
                myparam[4] = ModHelper.CreateParameter("@Status", SqlDbType.Char, 10, ParameterDirection.Input, status);
                myparam[5] = ModHelper.CreateParameter("@ActualStatus", SqlDbType.Char, 10, ParameterDirection.Input, actualstatus);
                myparam[6] = ModHelper.CreateParameter("@RejectComment", SqlDbType.VarChar, 50, ParameterDirection.Input, rejectcomment);
                myparam[7] = ModHelper.CreateParameter("@CurrentFlag", SqlDbType.Bit, 1, ParameterDirection.Input, currentflag);
                myparam[8] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
                myparam[9] = ModHelper.CreateParameter("@fromAnalysisReanalysis", SqlDbType.Int, 4, ParameterDirection.Input, fromAnalysisReanalysis);
                myparam[10] = ModHelper.CreateParameter("@PMChangeID", SqlDbType.BigInt, 8, ParameterDirection.Output, pmchangeid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblPMStatus", myparam);
                return Convert.ToInt64(myparam[10].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert_Update_tblPMDefectRemark()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[9];
                myparam[0] = ModHelper.CreateParameter("@PMTestID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmtestid);
                myparam[1] = ModHelper.CreateParameter("@LotReturn", SqlDbType.Int, 4, ParameterDirection.Input, lotreturn);
                myparam[2] = ModHelper.CreateParameter("@Complete", SqlDbType.Int, 4, ParameterDirection.Input, complete);
                myparam[3] = ModHelper.CreateParameter("@Partly", SqlDbType.Int, 4, ParameterDirection.Input, partly);
                myparam[4] = ModHelper.CreateParameter("@PartlyQuantity", SqlDbType.BigInt, 8, ParameterDirection.Input, partlyquantity);
                myparam[5] = ModHelper.CreateParameter("@OnlineSorted", SqlDbType.Int, 4, ParameterDirection.Input, onlinesorted);
                myparam[6] = ModHelper.CreateParameter("@LotComsumption", SqlDbType.Int, 4, ParameterDirection.Input, lotcomsumption);
                myparam[7] = ModHelper.CreateParameter("@Remark", SqlDbType.NVarChar, 400, ParameterDirection.Input, remark);
                myparam[8] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
               
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_Update_tblPMDefectRemark", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Update_tblPMStatus()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[11];
                myparam[0] = ModHelper.CreateParameter("@PMTestID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmtestid);
                myparam[1] = ModHelper.CreateParameter("@InspDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, inspdate);
                myparam[2] = ModHelper.CreateParameter("@DefectObserved", SqlDbType.Char, 1, ParameterDirection.Input, defectobserved);
                myparam[3] = ModHelper.CreateParameter("@NoOfDefect", SqlDbType.Int, 4, ParameterDirection.Input, noofdefect);
                myparam[4] = ModHelper.CreateParameter("@Status", SqlDbType.Char, 10, ParameterDirection.Input, status);
                myparam[5] = ModHelper.CreateParameter("@ActualStatus", SqlDbType.Char, 10, ParameterDirection.Input, actualstatus);
                myparam[6] = ModHelper.CreateParameter("@RejectComment", SqlDbType.VarChar, 50, ParameterDirection.Input, rejectcomment);
                myparam[7] = ModHelper.CreateParameter("@CurrentFlag", SqlDbType.Bit, 1, ParameterDirection.Input, currentflag);
                myparam[8] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
                myparam[9] = ModHelper.CreateParameter("@fromAnalysisReanalysis", SqlDbType.Int, 4, ParameterDirection.Input, fromAnalysisReanalysis);
                myparam[10] = ModHelper.CreateParameter("@PMChangeID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmchangeid);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblPMStatus", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_PMChangeId_PMStatus()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@PMTestId", SqlDbType.BigInt, 8, ParameterDirection.Input, pmtestid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_PMChangeId_PMStatus", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update_tblPMTest_CurrentFlag()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@PMTestID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmtestid);
                myparam[1] = ModHelper.CreateParameter("@CurrentFlag", SqlDbType.Bit, 1, ParameterDirection.Input, currentflag);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblPMTest_CurrentFlag", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblPMTest()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@PMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmtransid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblPMTest", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_tblPMStatus()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@PMTestID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmtestid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblPMStatus", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public long Insert_PMTest()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[6];
                myparam[0] = ModHelper.CreateParameter("@PMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmtransid);
                myparam[1] = ModHelper.CreateParameter("@AcceptedDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, accepteddate);
                myparam[2] = ModHelper.CreateParameter("@Quantity", SqlDbType.BigInt, 8, ParameterDirection.Input, quantity);
                myparam[3] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
                myparam[4] = ModHelper.CreateParameter("@PMTestID", SqlDbType.BigInt, 8, ParameterDirection.Output);
                myparam[5] = ModHelper.CreateParameter("@ReceiptDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, receiptdate);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblPMTest", myparam);

                return Convert.ToInt64(myparam[4].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update_tblPMTest()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[5];
                myparam[0] = ModHelper.CreateParameter("@AcceptedDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, accepteddate);
                myparam[1] = ModHelper.CreateParameter("@Quantity", SqlDbType.BigInt, 8, ParameterDirection.Input, quantity);
                myparam[2] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
                myparam[3] = ModHelper.CreateParameter("@PMTestID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmtestid);
                myparam[4] = ModHelper.CreateParameter("@ReceiptDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, receiptdate);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblPMTest", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_PMTransaction_PMSupplierCOCID_PlantLotNo()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@PMSupplierCOCID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmsuppliercocid);
                myparam[1] = ModHelper.CreateParameter("@PlantLotNo", SqlDbType.VarChar, 50, ParameterDirection.Input, plantlotno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblPMTransaction_PMSupplierCOCID_PlantLotNo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public DataSet Select_PMTranID_SupplierCOCID()
        //{
        //    try
        //    {
        //        SqlParameter[] myparam = new SqlParameter[1];
        //        DataSet ds = new DataSet();
        //        myparam[0] = ModHelper.CreateParameter("@PMSupplierCOCID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmsuppliercocid);
        //        ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Select_PMTranID_SupplierCOCID", myparam);
        //        return ds;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public DataSet Select_PMTransaction_PMTest_PMSupplierCOCID_PlantLotNo()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@PMSupplierCOCID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmsuppliercocid);
                myparam[1] = ModHelper.CreateParameter("@PlantLotNo", SqlDbType.VarChar, 50, ParameterDirection.Input, plantlotno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblPMTransaction_tblPMTest_PMSupplierCOCID_PlantLotNo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_PMFGDetails()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@PMSupplierCOCID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmsuppliercocid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_PMFGDetails", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_PeriodicTestingDone_PMSupplierCOCID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@PMSupplierCOCID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmsuppliercocid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_PeriodicTestingDone_PMSupplierCOCID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Update_tblPMSupplierCOC_COCApplicable()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@PMSupplierCOCID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmsuppliercocid);
                myparam[1] = ModHelper.CreateParameter("@COCApplicable", SqlDbType.Char, 1, ParameterDirection.Input, cocapplicable);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Update_tblPMSupplierCOC_COCApplicable", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Select_tblPMTransaction_NoBatches()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@PMSupplierCOCID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmsuppliercocid);
                myparam[1] = ModHelper.CreateParameter("@Result", SqlDbType.BigInt, 8, ParameterDirection.Output);
                SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_tblPMTransaction_NoBatches", myparam);
                if (myparam[1].Value is DBNull)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt64(myparam[1].Value);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Decide_ControlType_PM()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@PMSupplierCOCID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmsuppliercocid);
                myparam[1] = ModHelper.CreateParameter("@ControlType", SqlDbType.VarChar, 50, ParameterDirection.Output, controltype);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Decide_ControlType_PM", myparam);

                return Convert.ToString(myparam[1].Value);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Check_PMTransaction()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@PMSupplierCOCID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmsupplcocid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "[STP_Select_tblPMTransaction_Check_PMTransaction]", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Decide_TopNormalCount_PM()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@PMSupplierCOCID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmsuppliercocid);
                myparam[1] = ModHelper.CreateParameter("@Count", SqlDbType.Int, 4, ParameterDirection.Output, count);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Decide_TopNormalCount_PM", myparam);

                return Convert.ToInt32(myparam[1].Value);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_PendingPMTreatmentDetails()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_PendingPMTreatmentDetails");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_PMTreatmentDetails()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@PMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmtransid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_PMTreatmentDetails", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update_tblPMTest_TreatmentDone()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@PMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmtransid);
                myparam[1] = ModHelper.CreateParameter("@TreatmentDone", SqlDbType.Bit, 1, ParameterDirection.Input, treatmentdone);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblPMTest_TreatmentDone", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert_PMStatus_Treatment()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[13];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@PMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmtransid);
                myparam[1] = ModHelper.CreateParameter("@PMTestID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmtestid);
                myparam[2] = ModHelper.CreateParameter("@DefectObserved", SqlDbType.Char, 1, ParameterDirection.Input, defectobserved);
                myparam[3] = ModHelper.CreateParameter("@DefectComment", SqlDbType.VarChar, 200, ParameterDirection.Input, defectcomment);
                myparam[4] = ModHelper.CreateParameter("@DefectSampleQuantity", SqlDbType.VarChar, 50, ParameterDirection.Input, defectquantity);
                myparam[5] = ModHelper.CreateParameter("@NoOfDefect", SqlDbType.Int, 4, ParameterDirection.Input, noofdefect);
                myparam[6] = ModHelper.CreateParameter("@Defect", SqlDbType.VarChar, 50, ParameterDirection.Input, qualitydecision);
                myparam[7] = ModHelper.CreateParameter("@Status", SqlDbType.Char, 10, ParameterDirection.Input, status);
                myparam[8] = ModHelper.CreateParameter("@ActualStatus", SqlDbType.Char, 10, ParameterDirection.Input, actualstatus);
                myparam[9] = ModHelper.CreateParameter("@RejectComment", SqlDbType.VarChar, 50, ParameterDirection.Input, rejectcomment);
                myparam[10] = ModHelper.CreateParameter("@CurrentFlag", SqlDbType.Bit, 1, ParameterDirection.Input, currentflag);
                myparam[11] = ModHelper.CreateParameter("@ChangedStatus", SqlDbType.Bit, 1, ParameterDirection.Input, changedstatus);
                myparam[12] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginid);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblPMStatusChange_newstatuschange", myparam);
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_PMProtocol_Report()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@PMSupplierCOCID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmsuppliercocid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_PMProtocol_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_PendingPMDefectNote()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_PendingPMDefectNote");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_PendingPMDefectNote()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_PendingPMDefectNote");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_View_PendingPMReanalysis()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_PendingPMReanalysis");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_View_PendingPMDefectNote_PMCodeID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@PMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmcodeid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_PendingPMDefectNote_PMCodeID", myparam);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_View_PendingPMReanalysis_PMCodeID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@PMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmcodeid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_PendingPMReanalysis_PMCodeID", myparam);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_View_PendingPMDefectNote_PMTestID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@PMTestID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmtestid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_PendingPMDefectNote_PMTestID", myparam);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_View_PendingPMReanalysis_PMTestID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@PMTestID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmtestid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_PendingPMReanalysis_PMTestID", myparam);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_PMDefect_PMTestID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@PMTestID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmtestid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_PMDefect_PMTestID", myparam);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_PMDefect_PMTestID_FromReanalysis()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@PMTestID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmtestid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_PMDefect_PMTestID_fromAnalysisReanalysis", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_STP_Select_PMDefect_PMTransID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@PMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmtransid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_PMDefect_PMTransID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_PMSampling_PMDetails_PMTransID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@PMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmtransid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblPMPMSampling_tblPMDetails_PMTransID", myparam);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblPMStatus_PMTransID()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@PMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmtransid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblPMStatus_PMTransID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public long Insert_tblPMDefect()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[8];
                myparam[0] = ModHelper.CreateParameter("@PMChangeID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmchangeid);
                myparam[1] = ModHelper.CreateParameter("@DefectComment", SqlDbType.VarChar, 50, ParameterDirection.Input, defectcomment);
                myparam[2] = ModHelper.CreateParameter("@DefectQuantity", SqlDbType.VarChar, 50, ParameterDirection.Input, defectquantity);
                myparam[3] = ModHelper.CreateParameter("@ActionTaken", SqlDbType.Char, 1, ParameterDirection.Input, actiontaken);
                myparam[4] = ModHelper.CreateParameter("@QualityDecision", SqlDbType.VarChar, 50, ParameterDirection.Input, qualitydecision);
                myparam[5] = ModHelper.CreateParameter("@DefectStatus", SqlDbType.Char, 1, ParameterDirection.Input, defectstatus);
                myparam[6] = ModHelper.CreateParameter("@LNo", SqlDbType.VarChar, 50, ParameterDirection.Input, lineNumber);
                myparam[7] = ModHelper.CreateParameter("@PMDefectID", SqlDbType.BigInt, 8, ParameterDirection.Output, pmdefectid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblPMDefect", myparam);
                return Convert.ToInt64(myparam[7].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update_tblPMDefect()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[7];
                myparam[0] = ModHelper.CreateParameter("@DefectComment", SqlDbType.VarChar, 50, ParameterDirection.Input, defectcomment);
                myparam[1] = ModHelper.CreateParameter("@DefectQuantity", SqlDbType.VarChar, 50, ParameterDirection.Input, defectquantity);
                myparam[2] = ModHelper.CreateParameter("@ActionTaken", SqlDbType.Char, 1, ParameterDirection.Input, actiontaken);
                myparam[3] = ModHelper.CreateParameter("@QualityDecision", SqlDbType.VarChar, 50, ParameterDirection.Input, qualitydecision);
                myparam[4] = ModHelper.CreateParameter("@DefectStatus", SqlDbType.Char, 1, ParameterDirection.Input, defectstatus);
                myparam[5] = ModHelper.CreateParameter("@PMDefectID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmdefectid);
                myparam[6] = ModHelper.CreateParameter("@LNo", SqlDbType.VarChar, 50, ParameterDirection.Input, lineNumber);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblPMDefect", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // PM Supplier Corrective Note
        public bool Insert_PMSupplierCorrectiveNote()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[5];
                myparam[0] = ModHelper.CreateParameter("@PMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmtransid);
                myparam[1] = ModHelper.CreateParameter("@FileName", SqlDbType.VarChar, 500, ParameterDirection.Input, fileName);
                myparam[2] = ModHelper.CreateParameter("@FileType", SqlDbType.VarChar, 50, ParameterDirection.Input, fileExtension);
                myparam[3] = ModHelper.CreateParameter("@DefectStatus", SqlDbType.Char, 1, ParameterDirection.Input, defstatus);
                myparam[4] = ModHelper.CreateParameter("@FileData", SqlDbType.Image, 2147483647, ParameterDirection.Input, fileData);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblSupplierCorrectiveNote", myparam);
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_tblSupplierCorrectiveNote_CorrectiveNoteID()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@CorrectiveNoteID", SqlDbType.BigInt, 8, ParameterDirection.Input, correctiveNoteID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblSupplierCorrectiveNote_CorrectiveNoteID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblSupplierCorrectiveNote_PMTransID()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@PMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmtransid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblSupplierCorrectiveNote_PMTransID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblSupplierCorrectiveNote_DefectStatus()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@PMTestID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmtestid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_SupplierCorrectiveNote_Status", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblSupplierCorrectiveNote_PMTrans_Status()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@PMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmtransid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_SupplierCorrectiveNote_PMTrans_Status", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion


        public void Insert_tblPMCOCHistory()
        {
            // pmtransid; PMTransID;COCApplicable;

            bool COCStatus;
            try
            {
                if (cocapplicable == "N")
                {
                    COCStatus = false;
                }
                else
                {
                    COCStatus = true;
                }
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@COCFlag", SqlDbType.Bit, 50, ParameterDirection.Input, COCStatus);
                myparam[1] = ModHelper.CreateParameter("@PMTransID", SqlDbType.BigInt, 50, ParameterDirection.Input, pmtransid);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "SP_Insert_tblPMCOCHistory", myparam);
                //return Convert.ToInt64(myparam[3].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }


        }

        public DataSet CheckCOCStatus_tblPMTransaction()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@PMSupplierCOCID", SqlDbType.BigInt, 50, ParameterDirection.Input, PMSupplierCOCID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "SP_CheckCOC_Status_tblPMTransaction", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet CheckCOCStatus_tblPMCOCHistory()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@PMTransID", SqlDbType.BigInt, 50, ParameterDirection.Input, pmtransid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "SP_CheckCOC_Status_tblPMCOCHistory", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteCOCStatus_tblPMCOCHistory()
        {
            try
            {
                //delete coc status from tblPMCOCHistory
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@PMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmtransid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "SP_DeleteCOC_Status_tblPMCOCHistory", myparam);
                //return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GenerateCOCHistory_Report(long PMsuppliercocid)
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@PMSupplierCOCID", SqlDbType.BigInt, 50, ParameterDirection.Input, PMsuppliercocid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "SP_PMCOC_History_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Insert Multiple Dimension readings against TransactionID
        public void Insert_DimensionStatusPMTransRelation()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@DPTransStatusID", SqlDbType.BigInt, 8, ParameterDirection.Input, dpTransStatusID);
                myparam[1] = ModHelper.CreateParameter("@PMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmtransid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblDimensionStatusPMTransRelation", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Select_DimensionStatusPMTransRelation()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@DPTransStatusID", SqlDbType.BigInt, 8, ParameterDirection.Input, dpTransStatusID);
                myparam[1] = ModHelper.CreateParameter("@PMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmtransid);
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblDimensionStatusPMTransRelation", myparam).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DateTime  Select_LastCOCUpdate_Date()
        {
            try
            {
                
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@PMSupplierCOCID", SqlDbType.BigInt, 8, ParameterDirection.Input,pmsupplcocid);
                myparam[1] = ModHelper.CreateParameter("@CheckDate", SqlDbType.SmallDateTime,4, ParameterDirection.Output);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_PM_LastCOCUpdate_Date", myparam);
                return Convert.ToDateTime(myparam[1].Value.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_GetConsecutive_DefectStatus()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@PMSupplierCOCID", SqlDbType.BigInt, 8, ParameterDirection.Input, PMSupplierCOCID);
                myparam[1] = ModHelper.CreateParameter("@CheckDate", SqlDbType.NVarChar, 250, ParameterDirection.Input, checkDate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_GetConsecutive_DefectStatus", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_LastTen_DefectObserved()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@PMSupplierCOCID", SqlDbType.BigInt, 8, ParameterDirection.Input, PMSupplierCOCID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_GetLastTen_DefectObserved", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
