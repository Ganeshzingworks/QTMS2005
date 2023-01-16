using System;
using System.Collections.Generic;
using System.Text;
using DataFacade;
using System.Data;
using System.Data.SqlClient; 

namespace BusinessFacade.Transactions
{
    public class FinishedGoodTest_Class
    {
       #region variables
        private bool ScoopApplicable;
        private long LineNo;
        private int LoginID;
        private long FGTestNo;
        private long FGMethodNo;
        private long pkgSampNo;
        private long PKGTechNo;
        private string Type;
        private string LotSize;
        private string TestDate;
        private int Quantity;
        private string Status;
        private string ActualStatus;
        private string comment;
        private string Decision;
        private string NonBPCComment;
        private string Transid;
        //private int PkgSampNo;
        private int SampleSize;
        private int RejectSamples;
        private string TestName;
        private string InspectionMethod;
        private string Frequency;        
        private string ControlType;
        private string CT;
        private int SampleSizeReading;
        private string AQLReading;
        private string AQLZReading;
        private string AQLCReading;
        private string AQLMReading;
        private string AQLM1Reading;
        private string FromDate;
        private string ToDate;
        private long FGTLFID;
        private long FGNo;
        private string TrackCode;
        private int LNo;
        private long FNo;
        private string Catagory;
        private string  RejectComment;
        private long FGPhyCheNo;
        private long FGPackingNo;
        private string PkgStatus;
        private string PhyCheStatus;
        private string MfgWo;
        private string TestType;
        private long FMID;
        private long FGPhyMethodNo;
        private long FGPresMethodNo;
        private string Reading;
        private string FormulaNo;
        private int TankNo;
        private int CurrentFlag;
        private int Treatmented;
        private int TreatmentDone;
        private bool FGDone;
        private int InspectedBy;
        private string VersionNo;
        private long TLFID;
        private long UnitID;
        private int PackSize;
        private double Weight;
        private int NoOfDefets;
        private int NoOfSamples;
        private int Count;
        private int TestNo;
        private long MTID;
        private long LinkTLFID;
        private char WAStatus;
        private long StatusID;
        private double Obs;
        private bool WADone;
        private char Reason;
        private long WATransID;
        private char FlagRL;
        private string TorqueMin;
        private string TorqueMax;
        private string AnalysisType;
        private int Cnt;
        private long UPSamplePointID;
        private string Form_Name;
        private int VerifiedBy;

        private DateTime TimeBrief;
        private double AVG;
        private int Mettler;

        
	
       #endregion


       #region properties

        public double avg
        {
            get { return AVG; }
            set { AVG = value; }
        }
        public DateTime timebrief
        {
            get { return TimeBrief; }
            set { TimeBrief = value; }
        }

        public int verifiedby
        {
            get { return VerifiedBy; }
            set { VerifiedBy = value; }
        }
        public string form_name
        {
            get { return Form_Name; }
            set { Form_Name = value; }
        }
        public bool scoopapplicable
        {
            get { return ScoopApplicable; }
            set { ScoopApplicable = value; }
        }
        public long upsamplingpointid
        {
            get { return UPSamplePointID; }
            set { UPSamplePointID = value; }
        }

        public long lineno
        {
            get { return LineNo; }
            set { LineNo = value; }
        }

        public string analysistype
        {
            get { return AnalysisType; }
            set { AnalysisType = value; }
        }
        public int cnt
        {
            get { return Cnt; }
            set { Cnt = value; }
        }
        public string torquemax
        {
            get { return TorqueMax; }
            set { TorqueMax = value; }
        }
        public string torquemin
        {
            get { return TorqueMin; }
            set { TorqueMin = value; }
        }
        public char flagrl
        {
            get { return FlagRL; }
            set { FlagRL = value; }
        }
        public long watransid
        {
            get { return WATransID; }
            set { WATransID = value; }
        }
        public char reason
        {
            get { return Reason; }
            set { Reason = value; }
        }
        public bool wadone
        {
            get { return WADone; }
            set { WADone = value; }
        }
        public double obs
        {
            get { return Obs; }
            set { Obs = value; }
        }
        public long statusid
        {
            get { return StatusID; }
            set { StatusID = value; }
        }
        public char wastatus
        {
            get { return WAStatus; }
            set { WAStatus = value; }
        }
        public long linktlfid
        {
            get { return LinkTLFID; }
            set { LinkTLFID = value; }
        }
        public long mtid
        {
            get { return MTID; }
            set { MTID = value; }
        }
        public int testno
        {
            get { return TestNo; }
            set { TestNo = value; }
        }
        public int count
        {
            get { return Count; }
            set { Count = value; }
        }
        public int noofsamples
        {
            get { return NoOfSamples; }
            set { NoOfSamples = value; }
        }
        public int noofdefects
        {
            get { return NoOfDefets; }
            set { NoOfDefets = value; }
        }
        public double weight
        {
            get { return Weight; }
            set { Weight = value; }
        }
        public int packsize
        {
            get { return PackSize; }
            set { PackSize = value; }
        }
        public long unitid
        {
            get { return UnitID; }
            set { UnitID = value; }
        }
        public long tlfid
        {
            get { return TLFID; }
            set { TLFID = value; }
        }
        public string versionno
        {
            get { return VersionNo; }
            set { VersionNo = value; }
        }
        public int inspectedby
        {
            get { return InspectedBy; }
            set { InspectedBy = value; }
        }
        public int loginid
        {
            get { return LoginID; }
            set { LoginID = value; }
        }
        public string formulano
        {
            get { return FormulaNo; }
            set { FormulaNo = value; }
        }
        public long fmid
        {
            get { return FMID; }
            set { FMID = value; }
        }
        public string testtype
        {
            get { return TestType; }
            set { TestType = value; }
        }
        public string mfgwo
        {
            get { return MfgWo; }
            set { MfgWo = value; }
        }
        public string pkgstatus
        {
            get { return PkgStatus; }
            set { PkgStatus = value; }
        }
        public string phychestatus
        {
            get { return PhyCheStatus; }
            set { PhyCheStatus = value; }
        }
        public long fgpackingno
        {
            get { return FGPackingNo; }
            set { FGPackingNo = value; }
        }
        public long fgphycheno
        {
            get { return FGPhyCheNo; }
            set { FGPhyCheNo = value; }
        }
        public long fgphymethodno
        {
            get { return FGPhyMethodNo; }
            set { FGPhyMethodNo = value; }
        }
        public long fgpresmethodno
        {
            get { return FGPresMethodNo; }
            set { FGPresMethodNo = value; }
        }
        public int tankno
        {
            get { return TankNo; }
            set { TankNo = value; }
        }
        public string reading
        {
            get { return Reading; }
            set { Reading = value; }
        }
        public long fgtlfid
        {
            get { return FGTLFID; }
            set { FGTLFID = value; }
        }
        public string catagory
        {
            get { return Catagory; }
            set { Catagory = value; }
        }
        public long pkgtechno
        {
            get { return PKGTechNo; }
            set { PKGTechNo = value; }
        }
        public long fgno
        {
            get { return FGNo; }
            set { FGNo = value; }
        }
        public string trackcode
        {
            get { return TrackCode; }
            set { TrackCode = value; }
        }
        public int lno
        {
            get { return LNo; }
            set { LNo = value; }
        }
        public long fno
        {
            get { return FNo; }
            set { FNo = value; }
        }
        public long pkgsampno
        {
            get { return pkgSampNo; }
            set { pkgSampNo = value; }
        }
        public string type
        {
            get { return Type; }
            set { Type = value; }
        }
        public string lotsize
        {
            get { return LotSize; }
            set { LotSize = value; }
        }
        public string testdate
        {
            get { return TestDate; }
            set { TestDate = value; }
        }
        public int quantity
        {
            get { return Quantity; }
            set { Quantity = value; }
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
        public string Comment
        {
            get { return comment; }
            set { comment = value; }
        }
        public string decision
        {
            get { return Decision; }
            set { Decision = value; }
        }
        public string nonbpccomment
        {
            get { return NonBPCComment; }
            set { NonBPCComment = value; }
        }
        public string transid
        {
            get { return Transid; }
            set { Transid = value; }
        }
        public long fgtestno
        {
            get { return FGTestNo; }
            set { FGTestNo = value; }
        }
        public long fgmethodno
        {
            get { return FGMethodNo; }
            set { FGMethodNo = value; }
        }
        public int samplesize
        {
            get { return SampleSize; }
            set { SampleSize = value; }
        }
        public int  rejectsamples
        {
            get { return RejectSamples; }
            set { RejectSamples = value; }
        }
        public string testname
        {
            get { return TestName; }
            set { TestName = value; }
        } 
        public string inspectionmethod
        {
            get { return InspectionMethod; }
            set { InspectionMethod = value; }
        }
        public string frequency
        {
            get { return Frequency; }
            set { Frequency = value; }
        }        
        public string controltype
        {
            get { return ControlType; }
            set { ControlType = value; }
        }
        public int samplesizereading
        {
            get { return SampleSizeReading; }
            set { SampleSizeReading = value; }
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
        public string fromdate
        {
            get { return FromDate; }
            set { FromDate = value; }
        }
        public string todate
        {
            get { return ToDate; }
            set { ToDate = value; }
        }
        public string rejectcomment
        {
            get { return RejectComment; }
            set { RejectComment = value; }
        }
        public int currentflag
        {
            get { return  CurrentFlag;}
            set { CurrentFlag = value ;}
        }
        public int treatmented
        {
            get { return  Treatmented;}
            set { Treatmented = value ;}
        }
        public int treatmentdone
        {
            get { return TreatmentDone; }
            set { TreatmentDone = value; }
        }
        public bool fgdone
        {
            get { return FGDone; }
            set { FGDone = value; }
        }
        private string NormsMin;
        public string normmin
        {
            get { return NormsMin; }
            set { NormsMin = value; }
        }
        private string NormsMax;
        public string normmax
        {
            get { return NormsMax; }
            set { NormsMax = value; }
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
        private string AQLM1;

        public string aqlm1
        {
            get { return AQLM1; }
            set { AQLM1 = value; }
        }

        private string FormulaType;

        public string formulaType
        {
            get { return FormulaType; }
            set { FormulaType = value; }
        }

        private string fgcode;

        public string FGCode
        {
            get { return fgcode; }
            set { fgcode = value; }
        }
        private long LocationID;
        public long locationid
        {
            get { return LocationID; }
            set { LocationID = value; }
        }

        private string PhyDate;
        public string phydate
        {
            get { return PhyDate; }
            set { PhyDate = value; }
        }

        private string _filepath;
        public string filepath
        {
            get { return _filepath; }
            set { _filepath = value; }
        }
        private string _filename;
        public string filename
        {
            get { return _filename; }
            set { _filename = value; }
        }
        private string _FGPackingfilepath;
        public string FGPackingfilepath
        {
            get { return _FGPackingfilepath; }
            set { _FGPackingfilepath = value; }
        }


        private string _Quantity;
        public string _quantity
        {
            get { return _Quantity; }
            set { _Quantity = value; }
        }
        private string Kitcode;
        public string kitcode
        {
            get { return Kitcode; }
            set { Kitcode = value; }
        }

        private int Tubes;
        public int tubes
        {
            get { return Tubes; }
            set { Tubes = value; }
        }
        private int Kits;
        public int kits
        {
            get { return Kits; }
            set { Kits = value; }
        }
        private int Bottles;
        public int bottles
        {
            get { return Bottles; }
            set { Bottles = value; }
        }

        public int mettler
        {
            get { return Mettler; }
            set { Mettler = value; }
        }

        #endregion

        public string Decide_ControlType_FG()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@LNo", SqlDbType.Int, 4, ParameterDirection.Input, lno);
                myparam[1] = ModHelper.CreateParameter("@ControlType", SqlDbType.VarChar, 50, ParameterDirection.Output,controltype);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Decide_ControlType_FG", myparam);

                CT = Convert.ToString(myparam[1].Value);

                return CT;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet STP_SELECT_FGNo_FMID_PkgSamp()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                //myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                myparam[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_FGNo_FMID_PkgSamp",myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_DoneFinishedGoodDetails(DateTime dtFromDate,DateTime dtToDate)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, dtFromDate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, dtToDate);

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_DoneFinishedGoodDetails", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_PendingFinishedGoodDetails()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_PendingFinishedGoodDetails");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_PendingFinishedGoodDetailsUP()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_PendingFinishedGoodDetailsUP");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_FGCode_FGRefMgt()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_FGCode_FGRefMgt");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_PendingFinishedGoodSFPackingDetails()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_PendingFinishedGoodSFPackingDetails");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_ModificationFinishedGoodDetails()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_ModificationFinishedGoodDetails");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_PendingFinishedGoodTreatmentDetails()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_PendingFinishedGoodTreatmentDetails");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
               
        public DataSet Select_FinishedGood_PackingBulkTestDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_FinishedGood_PackingBulkTestDetails", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // For getting Track codes of specific FGNo 
        public DataSet Select_TrackCode_FGRefMgt()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_TrackCode_FGRefMgt", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_FinishedGoodTest_SFPackingBulkTestDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_FinishedGoodTest_SFPackingBulkTestDetails", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_FinishedGood_SFPackingBulkTestDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_FinishedGood_SFPackingBulkTestDetails", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblFinishedGoodUnitDetails_FGTLFID_TLFID()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                myparam[1] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, tlfid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblFinishedGoodUnitDetails_FGTLFID_TLFID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert_tblFinishedGoodUnitDetails()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[4];                
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                myparam[1] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, tlfid);
                myparam[2] = ModHelper.CreateParameter("@PackSize", SqlDbType.Int, 4, ParameterDirection.Input, packsize);
                myparam[3] = ModHelper.CreateParameter("@Weight", SqlDbType.Float, 8, ParameterDirection.Input, weight);                
                SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Insert_tblFinishedGoodUnitDetails", myparam);                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update_tblFinishedGoodUnitDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                myparam[1] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, tlfid);
                myparam[2] = ModHelper.CreateParameter("@PackSize", SqlDbType.Int, 4, ParameterDirection.Input, packsize);
                myparam[3] = ModHelper.CreateParameter("@Weight", SqlDbType.Float, 8, ParameterDirection.Input, weight);                
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblFinishedGoodUnitDetails", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblFinishedGoodDetails_FGTLFID()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblFinishedGoodDetails_FGTLFID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblLineMaster_ScoopApplicable()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblLineMaster_ScoopApplicable", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_ModificationFinishedGoodDetails_Details()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_ModificationFinishedGoodDetails_Details", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update_tblFinishedGoodTestDetails_TreatmentDone()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];                
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                myparam[1] = ModHelper.CreateParameter("@TreatmentDone", SqlDbType.Bit, 1, ParameterDirection.Input, treatmentdone);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblFinishedGoodTestDetails_TreatmentDone", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblFinishedGoodDetails_ControlType_FGTLFID()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblFinishedGoodDetails_ControlType_FGTLFID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblFinishedGoodPackingDetails_PkgStatus()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid); 
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblFinishedGoodPackingDetails_PkgStatus", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblFinishedGoodPackingDetailsTreatment_PkgStatus()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblFinishedGoodPackingDetailsTreatment_PkgStatus", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public long INSERT_FinishedGood_Status()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[5];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@Status", SqlDbType.Char, 10, ParameterDirection.Input, status);
                myparam[1] = ModHelper.CreateParameter("@ControlType", SqlDbType.VarChar, 50, ParameterDirection.Input, type);
                myparam[2] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.VarChar, 50, ParameterDirection.Input, fgtlfid);
                myparam[3] = ModHelper.CreateParameter("@CurrentFlag", SqlDbType.Bit, 1, ParameterDirection.Input, currentflag); 
                myparam[4] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Output, fgtestno);
                SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_INSERT_FinishedGood_Status", myparam);
                return (Convert.ToInt64(myparam[4].Value));                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public int Select_ValidityDate_FGCode()
        //{
        //    try
        //    {
        //        SqlParameter[] myparam = new SqlParameter[2];
        //        DataSet ds = new DataSet();
        //        myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.Bit, 1, ParameterDirection.Input, fgtlfid); 
        //        myparam[1] = ModHelper.CreateParameter("@Cnt", SqlDbType.BigInt, 8, ParameterDirection.Output, cnt);
        //        SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_ValidityDate_FGCode", myparam);
        //        return (Convert.ToInt32(myparam[1].Value));                
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public long Insert_tblFinishedGoodPackingDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[7];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtestno);
                myparam[1] = ModHelper.CreateParameter("@Quantity", SqlDbType.Int, 4, ParameterDirection.Input, quantity);
                myparam[2] = ModHelper.CreateParameter("@PkgStatus", SqlDbType.Char, 1, ParameterDirection.Input, pkgstatus);
                myparam[3] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
                myparam[4] = ModHelper.CreateParameter("@InspectedBy", SqlDbType.Int, 4, ParameterDirection.Input, inspectedby);
                myparam[5] = ModHelper.CreateParameter("@FGPackingNo", SqlDbType.BigInt, 8, ParameterDirection.Output, fgpackingno);
                myparam[6] = ModHelper.CreateParameter("@FGPackingfilepath", SqlDbType.NVarChar, 4000, ParameterDirection.Input, FGPackingfilepath);
                SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Insert_tblFinishedGoodPackingDetails", myparam);
                return (Convert.ToInt64(myparam[5].Value));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Update_tblFinishedGoodPackingDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[7];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtestno);
                myparam[1] = ModHelper.CreateParameter("@Quantity", SqlDbType.Int, 4, ParameterDirection.Input, quantity);
                myparam[2] = ModHelper.CreateParameter("@PkgStatus", SqlDbType.Char, 1, ParameterDirection.Input, pkgstatus);
                myparam[3] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
                myparam[4] = ModHelper.CreateParameter("@InspectedBy", SqlDbType.Int, 4, ParameterDirection.Input, inspectedby);
                myparam[5] = ModHelper.CreateParameter("@FGPackingNo", SqlDbType.BigInt, 8, ParameterDirection.Output, fgpackingno);
                myparam[6] = ModHelper.CreateParameter("@FGPackingfilepath", SqlDbType.NVarChar, 4000, ParameterDirection.Input, FGPackingfilepath);
                SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Update_tblFinishedGoodPackingDetails", myparam);
                return (Convert.ToInt64(myparam[5].Value));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete_tblFinishedGoodTest_TestMethodDetails_FGPackingNo()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();                
                myparam[0] = ModHelper.CreateParameter("@FGPackingNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgpackingno);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Delete_tblFinishedGoodTest_TestMethodDetails_FGPackingNo", myparam);
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete_tblFGPhysicochemicalTestMethodDetails_FGPhyCheNo()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGPhyCheNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgphycheno);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Delete_tblFGPhysicochemicalTestMethodDetails_FGPhyCheNo", myparam);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblFinishedGoodPackingDetails_FGTLFID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];                
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                ds =  SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Select_tblFinishedGoodPackingDetails_FGTLFID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblFinishedGoodPhyCheDetails_FGTLFID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                myparam[1] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Select_tblFinishedGoodPhyCheDetails_FGTLFID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_FinishedGood_FGDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);               
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_FinishedGood_FGDetails", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_Protocol_FGPackingDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_Protocol_FGPackingDetails", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_Protocol_FGPackingDetails_PhyChe()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                myparam[1] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_Protocol_FGPackingDetails_PhyChe", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_FinishedGood_BulkDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_FinishedGood_BulkDetails", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblFinishedGoodDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[3];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@pkgSampNo", SqlDbType.BigInt, 8, ParameterDirection.Input, pkgtechno);
                myparam[1] = ModHelper.CreateParameter("@Type", SqlDbType.VarChar, 50, ParameterDirection.Input, type);
                myparam[2] = ModHelper.CreateParameter("@LotSize", SqlDbType.VarChar, 50, ParameterDirection.Input, LotSize);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Select_tblFinishedGoodDetails", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_VIEW_FinishedGoodDetails_TestNo_TestName()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[3];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@PKGTechNo", SqlDbType.BigInt, 8, ParameterDirection.Input, pkgtechno);
                myparam[1] = ModHelper.CreateParameter("@Type", SqlDbType.VarChar, 50, ParameterDirection.Input, type);
                myparam[2] = ModHelper.CreateParameter("@LotSize", SqlDbType.VarChar, 50, ParameterDirection.Input, LotSize);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Select_VIEW_FinishedGoodDetails_TestNo_TestName", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_VIEW_FinishedGoodDetails1_TestNo_TestName1()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[5];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                myparam[1] = ModHelper.CreateParameter("@PKGTechNo", SqlDbType.BigInt, 8, ParameterDirection.Input, pkgtechno);
                myparam[2] = ModHelper.CreateParameter("@Type", SqlDbType.VarChar, 50, ParameterDirection.Input, type);
                myparam[3] = ModHelper.CreateParameter("@LotSize", SqlDbType.VarChar, 50, ParameterDirection.Input, LotSize);
                myparam[4] = ModHelper.CreateParameter("@ScoopApplicable", SqlDbType.Bit, 1, ParameterDirection.Input, scoopapplicable);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Select_VIEW_FinishedGoodDetails1_TestNo_TestName1", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_VIEW_FinishedGoodTestMethodDetails_TestNo_TestName()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@PKGTechNo", SqlDbType.BigInt, 8, ParameterDirection.Input, pkgtechno);
                myparam[1] = ModHelper.CreateParameter("@Type", SqlDbType.VarChar, 50, ParameterDirection.Input, type);
                myparam[2] = ModHelper.CreateParameter("@LotSize", SqlDbType.VarChar, 50, ParameterDirection.Input, LotSize);
                myparam[3] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtestno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Select_VIEW_FinishedGoodTestMethodDetails_TestNo_TestName", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_VIEW_FinishedGoodDetails_Correction_TestNo_TestName()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[3];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@pkgSampNo", SqlDbType.BigInt, 8, ParameterDirection.Input, pkgtechno);
                myparam[1] = ModHelper.CreateParameter("@Type", SqlDbType.VarChar, 50, ParameterDirection.Input, type);
                myparam[2] = ModHelper.CreateParameter("@LotSize", SqlDbType.VarChar, 50, ParameterDirection.Input, LotSize);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Select_VIEW_FinishedGoodDetails_Correction_TestNo_TestName", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_VIEW_FinishedGoodDetails_InspectionMethod()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@Method", SqlDbType.NVarChar, 250, ParameterDirection.Input,testname);
                myparam[1] = ModHelper.CreateParameter("@PKGTechNo", SqlDbType.BigInt, 8, ParameterDirection.Input, pkgtechno);
                myparam[2] = ModHelper.CreateParameter("@Type", SqlDbType.VarChar, 50, ParameterDirection.Input, type);
                myparam[3] = ModHelper.CreateParameter("@LotSize", SqlDbType.VarChar, 50, ParameterDirection.Input, lotsize);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Select_VIEW_FinishedGoodDetails_InspectionMethod", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_VIEW_FinishedGoodTestMethodDetails_InspectionMethod()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[5];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@Method", SqlDbType.NVarChar, 250, ParameterDirection.Input, testname);
                myparam[1] = ModHelper.CreateParameter("@PKGTechNo", SqlDbType.BigInt, 8, ParameterDirection.Input, pkgtechno);
                myparam[2] = ModHelper.CreateParameter("@Type", SqlDbType.VarChar, 50, ParameterDirection.Input, type);
                myparam[3] = ModHelper.CreateParameter("@LotSize", SqlDbType.VarChar, 50, ParameterDirection.Input, lotsize);
                myparam[4] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtestno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Select_VIEW_FinishedGoodTestMethodDetails_InspectionMethod", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_tblWAType_TestNo()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@TestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, testno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblWAType_TestNo", myparam);
                return ds;               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_tblLinkTLF_FGNo_FNo()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                myparam[1] = ModHelper.CreateParameter("@TestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, testno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblLinkTLF_FGNo_FNo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_tblLinkTLF_Top20_WA()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[3];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                myparam[1] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                myparam[2] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblLinkTLF_Top20_WA", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Decide_Top20Count_WA()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[6];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                myparam[1] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                myparam[2] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[3] = ModHelper.CreateParameter("@LNo", SqlDbType.Int, 4, ParameterDirection.Input, lno);
                myparam[4] = ModHelper.CreateParameter("@MTID", SqlDbType.BigInt, 8, ParameterDirection.Input, mtid);
                myparam[5] = ModHelper.CreateParameter("@Count", SqlDbType.Int, 4, ParameterDirection.Output, count);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Decide_Top20Count_WA", myparam);

                return Convert.ToInt32(myparam[5].Value);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Decide_Top3Count_WA()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);                
                myparam[1] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[2] = ModHelper.CreateParameter("@MTID", SqlDbType.BigInt, 8, ParameterDirection.Input, mtid);
                myparam[3] = ModHelper.CreateParameter("@Count", SqlDbType.Int, 4, ParameterDirection.Output, count);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Decide_Top3Count_WA", myparam);

                return Convert.ToInt32(myparam[3].Value);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get top 5 record for test wa
        /// </summary>
        /// <returns></returns>
        public int Decide_Top5Count_WA()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[6];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                myparam[1] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[2] = ModHelper.CreateParameter("@MTID", SqlDbType.BigInt, 8, ParameterDirection.Input, mtid);
                myparam[3] = ModHelper.CreateParameter("@Count", SqlDbType.Int, 4, ParameterDirection.Output, count);
                myparam[4] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                myparam[5] = ModHelper.CreateParameter("@LNo", SqlDbType.BigInt, 8, ParameterDirection.Input, lno);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Decide_Top5Count_WA", myparam);

                return Convert.ToInt32(myparam[3].Value);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public long Select_VIEW_FinishedGoodDetails_FGMethodNo()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[6];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@Method", SqlDbType.NVarChar, 250, ParameterDirection.Input, testname);
                myparam[1] = ModHelper.CreateParameter("@PKGTechNo", SqlDbType.BigInt, 8, ParameterDirection.Input, pkgtechno);
                myparam[2] = ModHelper.CreateParameter("@Type", SqlDbType.VarChar, 50, ParameterDirection.Input, type);
                myparam[3] = ModHelper.CreateParameter("@LotSize", SqlDbType.VarChar, 50, ParameterDirection.Input, lotsize);
                myparam[4] = ModHelper.CreateParameter("@InspectionMethod", SqlDbType.VarChar, 50, ParameterDirection.Input, inspectionmethod);
                myparam[5] = ModHelper.CreateParameter("@FGMethodNo", SqlDbType.BigInt, 8, ParameterDirection.Output, fgmethodno);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Select_VIEW_FinishedGoodDetails_FGMethodNo", myparam);
                return Convert.ToInt64(myparam[5].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_VIEW_FinishedGoodDetails_Correction_InspectionMethod()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@Method", SqlDbType.NVarChar, 250, ParameterDirection.Input, testname);
                myparam[1] = ModHelper.CreateParameter("@pkgSampNo", SqlDbType.BigInt, 8, ParameterDirection.Input, pkgtechno);
                myparam[2] = ModHelper.CreateParameter("@Type", SqlDbType.VarChar, 50, ParameterDirection.Input, type);
                myparam[3] = ModHelper.CreateParameter("@LotSize", SqlDbType.VarChar, 50, ParameterDirection.Input, lotsize);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Select_VIEW_FinishedGoodDetails_Correction_InspectionMethod", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_VIEW_FinishedGoodDetails_All()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[5];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@Method", SqlDbType.NVarChar, 250, ParameterDirection.Input, testname);
                myparam[1] = ModHelper.CreateParameter("@PKGTechNo", SqlDbType.BigInt, 8, ParameterDirection.Input, pkgtechno);
                myparam[2] = ModHelper.CreateParameter("@Type", SqlDbType.VarChar, 50, ParameterDirection.Input, type);
                myparam[3] = ModHelper.CreateParameter("@LotSize", SqlDbType.VarChar, 50, ParameterDirection.Input, lotsize);
                myparam[4] = ModHelper.CreateParameter("@InspectionMethod", SqlDbType.VarChar, 50, ParameterDirection.Input, inspectionmethod);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Select_VIEW_FinishedGoodDetails_All", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_VIEW_FinishedGoodTestMethodDetails_All()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[6];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@Method", SqlDbType.NVarChar, 250, ParameterDirection.Input, testname);
                myparam[1] = ModHelper.CreateParameter("@PKGTechNo", SqlDbType.BigInt, 8, ParameterDirection.Input, pkgtechno);
                myparam[2] = ModHelper.CreateParameter("@Type", SqlDbType.VarChar, 50, ParameterDirection.Input, type);
                myparam[3] = ModHelper.CreateParameter("@LotSize", SqlDbType.VarChar, 50, ParameterDirection.Input, lotsize);
                myparam[4] = ModHelper.CreateParameter("@InspectionMethod", SqlDbType.VarChar, 50, ParameterDirection.Input, inspectionmethod);
                myparam[5] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtestno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Select_VIEW_FinishedGoodTestMethodDetails_All", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_VIEW_FinishedGoodDetails_Correction_All()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[5];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@Method", SqlDbType.NVarChar, 250, ParameterDirection.Input, testname);
                myparam[1] = ModHelper.CreateParameter("@pkgSampNo", SqlDbType.BigInt, 8, ParameterDirection.Input, pkgtechno);
                myparam[2] = ModHelper.CreateParameter("@Type", SqlDbType.VarChar, 50, ParameterDirection.Input, type);
                myparam[3] = ModHelper.CreateParameter("@LotSize", SqlDbType.VarChar, 50, ParameterDirection.Input, lotsize);
                myparam[4] = ModHelper.CreateParameter("@InspectionMethod", SqlDbType.VarChar, 50, ParameterDirection.Input, inspectionmethod);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Select_VIEW_FinishedGoodDetails_Correction_All", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public long Insert_tblFinishedGoodTestDetails()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[21];
                myparam[0] = ModHelper.CreateParameter("@TestDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, testdate);                
                myparam[1] = ModHelper.CreateParameter("@Status", SqlDbType.Char, 10, ParameterDirection.Input, status);
                myparam[2] = ModHelper.CreateParameter("@comment", SqlDbType.VarChar, 50, ParameterDirection.Input, Comment);
                myparam[3] = ModHelper.CreateParameter("@Decision", SqlDbType.Char, 10, ParameterDirection.Input, decision);
                myparam[4] = ModHelper.CreateParameter("@RejectComment", SqlDbType.VarChar, 50, ParameterDirection.Input, rejectcomment);
                myparam[5] = ModHelper.CreateParameter("@NoOfDefects", SqlDbType.Int, 4, ParameterDirection.Input, noofdefects);
                myparam[6] = ModHelper.CreateParameter("@NoOfSamples", SqlDbType.Int, 4, ParameterDirection.Input, noofsamples);
                myparam[7] = ModHelper.CreateParameter("@NonBPCComment", SqlDbType.VarChar, 250, ParameterDirection.Input, nonbpccomment);
                myparam[8] = ModHelper.CreateParameter("@Catagory", SqlDbType.VarChar, 50, ParameterDirection.Input, catagory);
                myparam[9] = ModHelper.CreateParameter("@Type", SqlDbType.Char, 10, ParameterDirection.Input, type);
                myparam[10] = ModHelper.CreateParameter("@LNo", SqlDbType.Int, 4, ParameterDirection.Input, lno);
                myparam[11] = ModHelper.CreateParameter("@VersionNo", SqlDbType.NVarChar,50, ParameterDirection.Input, versionno);
                myparam[12] = ModHelper.CreateParameter("@ActualStatus", SqlDbType.Char, 10, ParameterDirection.Input, actualstatus);
                myparam[13] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                myparam[14] = ModHelper.CreateParameter("@CurrentFlag", SqlDbType.Bit, 1, ParameterDirection.Input, currentflag);
                myparam[15] = ModHelper.CreateParameter("@Treatmented", SqlDbType.Bit, 1, ParameterDirection.Input, treatmented);
                myparam[16] = ModHelper.CreateParameter("@TreatmentDone", SqlDbType.Bit, 1, ParameterDirection.Input, treatmentdone);
                myparam[17] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
                myparam[18] = ModHelper.CreateParameter("@InspectedBy", SqlDbType.Int, 4, ParameterDirection.Input, inspectedby);
                myparam[19] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Output);

                myparam[20] = ModHelper.CreateParameter("@VerifiedBy", SqlDbType.Int, 4, ParameterDirection.Input,verifiedby);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblFinishedGoodTestDetails", myparam);

                FGTestNo = Convert.ToInt32(myparam[19].Value);
 
                return FGTestNo;
                //return true;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete_tblFinishedGoodTestDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblFinishedGoodTestDetails", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert_tblFinishedGoodTest_TestMethodDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[15];
                myparam[0] = ModHelper.CreateParameter("@SampleSizeReading", SqlDbType.Int, 4, ParameterDirection.Input, samplesizereading);
                myparam[1] = ModHelper.CreateParameter("@AQLReading", SqlDbType.VarChar, 50, ParameterDirection.Input, aqlreading);
                myparam[2] = ModHelper.CreateParameter("@AQLZReading", SqlDbType.VarChar, 50, ParameterDirection.Input, aqlzreading);
                myparam[3] = ModHelper.CreateParameter("@AQLCReading", SqlDbType.VarChar, 50, ParameterDirection.Input, aqlcreading);
                myparam[4] = ModHelper.CreateParameter("@AQLMReading", SqlDbType.VarChar, 50, ParameterDirection.Input, aqlmreading);
                myparam[5] = ModHelper.CreateParameter("@AQLM1Reading", SqlDbType.VarChar, 50, ParameterDirection.Input,aqlm1reading);
                myparam[6] = ModHelper.CreateParameter("@FGMethodNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgmethodno);
                myparam[7] = ModHelper.CreateParameter("@FGPackingNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgpackingno);
                myparam[8] = ModHelper.CreateParameter("@InspectionMethod", SqlDbType.VarChar, 50, ParameterDirection.Input, inspectionmethod);
                myparam[9] = ModHelper.CreateParameter("@AQL", SqlDbType.VarChar, 50, ParameterDirection.Input, aql);
                myparam[10] = ModHelper.CreateParameter("@AQLZ", SqlDbType.VarChar, 50, ParameterDirection.Input, aqlz);
                myparam[11] = ModHelper.CreateParameter("@AQLC", SqlDbType.VarChar, 50, ParameterDirection.Input, aqlc);
                myparam[12] = ModHelper.CreateParameter("@AQLM", SqlDbType.VarChar, 50, ParameterDirection.Input, aqlm);
                myparam[13] = ModHelper.CreateParameter("@AQLM1", SqlDbType.VarChar, 50, ParameterDirection.Input, aqlm1);
                myparam[14] = ModHelper.CreateParameter("@SampleSize", SqlDbType.Int, 4, ParameterDirection.Input, samplesize);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblFinishedGoodTest_TestMethodDetails", myparam);
                                
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public long Select_tblFinishedGoodDetails_FGMethodNo()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[6];
                
                myparam[0] = ModHelper.CreateParameter("@PKGTechNo", SqlDbType.BigInt, 8, ParameterDirection.Input, pkgtechno);
                myparam[1] = ModHelper.CreateParameter("@TestMethod", SqlDbType.NVarChar, 250, ParameterDirection.Input, testname);
                myparam[2] = ModHelper.CreateParameter("@InspectionMethod", SqlDbType.VarChar, 50, ParameterDirection.Input, inspectionmethod);                
                myparam[3] = ModHelper.CreateParameter("@Type", SqlDbType.VarChar, 50, ParameterDirection.Input, type);
                myparam[4] = ModHelper.CreateParameter("@LotSize", SqlDbType.VarChar, 50, ParameterDirection.Input, lotsize);
                myparam[5] = ModHelper.CreateParameter("@FGMethodNo", SqlDbType.BigInt, 8, ParameterDirection.Output);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Select_tblFinishedGoodDetails_FGMethodNo", myparam);

                FGMethodNo = Convert.ToInt64(myparam[5].Value);

                return FGMethodNo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Select_tblFinishedGoodTestMethodDetails_FGMethodNo()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[7];

                myparam[0] = ModHelper.CreateParameter("@PKGTechNo", SqlDbType.BigInt, 8, ParameterDirection.Input, pkgtechno);
                myparam[1] = ModHelper.CreateParameter("@TestMethod", SqlDbType.NVarChar, 250, ParameterDirection.Input, testname);
                myparam[2] = ModHelper.CreateParameter("@InspectionMethod", SqlDbType.VarChar, 50, ParameterDirection.Input, inspectionmethod);
                myparam[3] = ModHelper.CreateParameter("@Type", SqlDbType.VarChar, 50, ParameterDirection.Input, type);
                myparam[4] = ModHelper.CreateParameter("@LotSize", SqlDbType.VarChar, 50, ParameterDirection.Input, lotsize);
                myparam[5] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Input,fgtestno);
                myparam[6] = ModHelper.CreateParameter("@FGMethodNo", SqlDbType.BigInt, 8, ParameterDirection.Output);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Select_tblFinishedGoodTestMethodDetails_FGMethodNo", myparam);

                FGMethodNo = Convert.ToInt64(myparam[6].Value);

                return FGMethodNo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_TankDetails_Formula_MfgWo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[1] = ModHelper.CreateParameter("@MfgWo", SqlDbType.VarChar, 200, ParameterDirection.Input, mfgwo);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_TankDetails_Formula_MfgWo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update_tblFGTLF_FGDone()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                myparam[1] = ModHelper.CreateParameter("@FGDone", SqlDbType.Bit, 1, ParameterDirection.Input, fgdone);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblFGTLF_FGDone", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }                
        
        public DataSet Select_VIEW_FGTestDetails_Correction()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Select_VIEW_FGTestDetails_Correction");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_VIEW_FGTestDetails_Correction_pkgSampNo()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@pkgSampNo", SqlDbType.BigInt, 8, ParameterDirection.Input, pkgsampno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Select_VIEW_FGTestDetails_Correction_pkgSampNo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblFinishedGoodTest_TestMethodDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGMethodNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgmethodno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Select_tblFinishedGoodTest_TestMethodDetails", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Select_tblFinishedGoodTestDetails_FGTestNo()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[5];
                myparam[0] = ModHelper.CreateParameter("@PkgSampNo", SqlDbType.BigInt, 8, ParameterDirection.Input, pkgsampno);
                myparam[1] = ModHelper.CreateParameter("@Type", SqlDbType.Char, 10, ParameterDirection.Input, type);
                myparam[2] = ModHelper.CreateParameter("@PkgTechNo", SqlDbType.BigInt, 8, ParameterDirection.Input, pkgtechno);
                myparam[3] = ModHelper.CreateParameter("@LNo", SqlDbType.Int, 4, ParameterDirection.Input, lno);
                myparam[4] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Output);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Select_tblFinishedGoodTestDetails_FGTestNo", myparam);

                FGTestNo = Convert.ToInt32(myparam[4].Value);
                
                return FGTestNo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update_tblFinishedGoodTestDetails()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[21];
                myparam[0] = ModHelper.CreateParameter("@TestDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, testdate);
                myparam[1] = ModHelper.CreateParameter("@Status", SqlDbType.Char, 10, ParameterDirection.Input, status);
                myparam[2] = ModHelper.CreateParameter("@comment", SqlDbType.VarChar, 50, ParameterDirection.Input, Comment);
                myparam[3] = ModHelper.CreateParameter("@Decision", SqlDbType.Char, 10, ParameterDirection.Input, decision);
                myparam[4] = ModHelper.CreateParameter("@RejectComment", SqlDbType.VarChar, 50, ParameterDirection.Input, rejectcomment);
                myparam[5] = ModHelper.CreateParameter("@NoOfDefects", SqlDbType.Int, 4, ParameterDirection.Input, noofdefects);
                myparam[6] = ModHelper.CreateParameter("@NoOfSamples", SqlDbType.Int, 4, ParameterDirection.Input, noofsamples);
                myparam[7] = ModHelper.CreateParameter("@NonBPCComment", SqlDbType.VarChar, 250, ParameterDirection.Input, nonbpccomment);
                myparam[8] = ModHelper.CreateParameter("@Catagory", SqlDbType.VarChar, 50, ParameterDirection.Input, catagory);
                myparam[9] = ModHelper.CreateParameter("@Type", SqlDbType.Char, 10, ParameterDirection.Input, type);
                myparam[10] = ModHelper.CreateParameter("@LNo", SqlDbType.Int, 4, ParameterDirection.Input, lno);
                myparam[11] = ModHelper.CreateParameter("@VersionNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, versionno);
                myparam[12] = ModHelper.CreateParameter("@ActualStatus", SqlDbType.Char, 10, ParameterDirection.Input, actualstatus);
                myparam[13] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtestno);
                myparam[14] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                myparam[15] = ModHelper.CreateParameter("@CurrentFlag", SqlDbType.Bit, 1, ParameterDirection.Input, currentflag);
                myparam[16] = ModHelper.CreateParameter("@Treatmented", SqlDbType.Bit, 1, ParameterDirection.Input, treatmented);
                myparam[17] = ModHelper.CreateParameter("@TreatmentDone", SqlDbType.Bit, 1, ParameterDirection.Input, treatmentdone);
                myparam[18] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
                myparam[19] = ModHelper.CreateParameter("@InspectedBy", SqlDbType.Int, 4, ParameterDirection.Input, inspectedby);
                myparam[20] = ModHelper.CreateParameter("@VerifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, verifiedby);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblFinishedGoodTestDetails", myparam);
                
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update_tblFinishedGoodTestDetails_CurrentFlag()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                myparam[1] = ModHelper.CreateParameter("@CurrentFlag", SqlDbType.Bit, 1, ParameterDirection.Input, currentflag);                

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblFinishedGoodTestDetails_CurrentFlag", myparam);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update_tblFinishedGoodTest_TestMethodDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[8];
                myparam[0] = ModHelper.CreateParameter("@SampleSizeReading", SqlDbType.Int, 4, ParameterDirection.Input, samplesizereading);
                myparam[1] = ModHelper.CreateParameter("@AQLReading", SqlDbType.VarChar, 50, ParameterDirection.Input, aqlreading);
                myparam[2] = ModHelper.CreateParameter("@AQLZReading", SqlDbType.VarChar, 50, ParameterDirection.Input, aqlzreading);
                myparam[3] = ModHelper.CreateParameter("@AQLCReading", SqlDbType.VarChar, 50, ParameterDirection.Input, aqlcreading);
                myparam[4] = ModHelper.CreateParameter("@AQLMReading", SqlDbType.VarChar, 50, ParameterDirection.Input, aqlmreading);
                myparam[5] = ModHelper.CreateParameter("@AQLM1Reading", SqlDbType.VarChar, 50, ParameterDirection.Input, aqlm1reading);
                myparam[6] = ModHelper.CreateParameter("@FGMethodNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgmethodno);
                myparam[7] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtestno);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblFinishedGoodTest_TestMethodDetails", myparam);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string Autogeneratecode()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[18];
                myparam[0] = ModHelper.CreateParameter("@TestDate", SqlDbType.SmallDateTime,4, ParameterDirection.Input, testdate);
                string s = testdate.Substring(0, 10);
                DateTime DTPInspDate = Convert.ToDateTime(s);
                int c;
                try
                {
                    c = Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_Autogenerate_FGTest", myparam));
                }
                catch
                {
                    c = 0;
                }
                int ano = c + 1;
                string Autogen = "";
                if (ano < 10)
                {
                    Autogen = "FGT" + Convert.ToString(DTPInspDate.Year) + Convert.ToString(DTPInspDate.Month) + Convert.ToString(DTPInspDate.Day) + "00" + ano;
                }
                else if ((ano >= 10) && (ano < 100))
                {
                    Autogen = "FGT" + Convert.ToString(DTPInspDate.Year) + Convert.ToString(DTPInspDate.Month) + Convert.ToString(DTPInspDate.Day) + "0" + ano;
                }
                else if (ano >= 100)
                {
                    Autogen = "FGT" + Convert.ToString(DTPInspDate.Year) + Convert.ToString(DTPInspDate.Month) + Convert.ToString(DTPInspDate.Day) + "0" + ano;
                }

                return Autogen;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblFGPhysicochemicalTestMethodMaster_FNo()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);                
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblFGPhysicochemicalTestMethodMaster_FNo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblFGPhysicochemicalTestMethodDetails_FGTLFID_FMID_Tests()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                myparam[1] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblFGPhysicochemicalTestMethodDetails_FGTLFID_FMID_Tests", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblFGPhysicochemicalTestMethodDetails_FGTLFID_FMID()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[3];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                myparam[1] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                myparam[2] = ModHelper.CreateParameter("@FGPhyMethodNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgphymethodno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblFGPhysicochemicalTestMethodDetails_FGTLFID_FMID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public DataSet Select_tblFGPreservativeMethodMaster_FNo()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblFGPreservativeMethodMaster_FNo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Select_tblTransFM_FMID()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[3];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[1] = ModHelper.CreateParameter("@MfgWo", SqlDbType.VarChar, 200, ParameterDirection.Input, mfgwo);
                myparam[2] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Output, fmid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Select_tblTransFM_FMID", myparam);
                return Convert.ToInt64(myparam[2].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Insert_tblFinishedGoodPhyCheDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[7];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtestno);
                myparam[1] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                myparam[2] = ModHelper.CreateParameter("@PhyCheStatus", SqlDbType.Char, 1, ParameterDirection.Input, phychestatus);
                myparam[3] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
                myparam[4] = ModHelper.CreateParameter("@InspectedBy", SqlDbType.Int, 4, ParameterDirection.Input, inspectedby);
                myparam[5] = ModHelper.CreateParameter("@FGPhyCheNo", SqlDbType.BigInt, 8, ParameterDirection.Output, fgphycheno);
                myparam[6] = ModHelper.CreateParameter("@PhyDate", SqlDbType.VarChar, 20, ParameterDirection.Input, phydate);
                SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Insert_tblFinishedGoodPhyCheDetails", myparam);
                return (Convert.ToInt64(myparam[5].Value));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Update_tblFinishedGoodPhyCheDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[7];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtestno);
                myparam[1] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                myparam[2] = ModHelper.CreateParameter("@PhyCheStatus", SqlDbType.Char, 1, ParameterDirection.Input, phychestatus);
                myparam[3] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
                myparam[4] = ModHelper.CreateParameter("@InspectedBy", SqlDbType.Int, 4, ParameterDirection.Input, inspectedby);
                myparam[5] = ModHelper.CreateParameter("@FGPhyCheNo", SqlDbType.BigInt, 8, ParameterDirection.Output, fgphycheno);
                myparam[6] = ModHelper.CreateParameter("@PhyDate", SqlDbType.VarChar, 20, ParameterDirection.Input, phydate);
                SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Update_tblFinishedGoodPhyCheDetails", myparam);
                return (Convert.ToInt64(myparam[5].Value));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    
        public void Insert_tblFGPhysicochemicalTestMethodDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[6];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGPhyCheNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgphycheno);
                myparam[1] = ModHelper.CreateParameter("@FGPhyMethodNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgphymethodno);
                myparam[2] = ModHelper.CreateParameter("@TankNo", SqlDbType.BigInt, 8, ParameterDirection.Input, tankno);
                myparam[3] = ModHelper.CreateParameter("@NormsReading", SqlDbType.VarChar, 50, ParameterDirection.Input, reading);
                myparam[4] = ModHelper.CreateParameter("@NormsMin", SqlDbType.VarChar, 50, ParameterDirection.Input, normmin);
                myparam[5] = ModHelper.CreateParameter("@NormsMax", SqlDbType.VarChar, 50, ParameterDirection.Input, normmax);                

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblFGPhysicochemicalTestMethodDetails", myparam);                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert_tblFGPreservativeMethodDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[3];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGPhyCheNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgphycheno);
                myparam[1] = ModHelper.CreateParameter("@FGPresMethodNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgpresmethodno);
                myparam[2] = ModHelper.CreateParameter("@NormsReading", SqlDbType.VarChar, 50, ParameterDirection.Input, reading);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblFGPreservativeMethodDetails", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblFinishedGoodPhyCheDetails_PhyCheStatus()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[3];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                myparam[1] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[2] = ModHelper.CreateParameter("@MfgWo", SqlDbType.VarChar, 200, ParameterDirection.Input, mfgwo);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblFinishedGoodPhyCheDetails_PhyCheStatus", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // This is for only Finish Good Test SF Packing
        public DataSet Select_tblFinishedGoodPhyCheDetails_PhyCheStatus_FNo_MfgWo() 
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[1] = ModHelper.CreateParameter("@MfgWo", SqlDbType.VarChar, 200, ParameterDirection.Input, mfgwo);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblFinishedGoodPhyCheDetails_PhyCheStatus_FNo_MfgWo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet STP_Select_tblFinishedGoodTest_TestMethodDetails_FGTLFID_FGMethodNo()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                myparam[1] = ModHelper.CreateParameter("@FGMethodNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgmethodno);                
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblFinishedGoodTest_TestMethodDetails_FGTLFID_FGMethodNo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblWAStatus_LinkTLFID()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@LinkTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, linktlfid);              
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblWAStatus_LinkTLFID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblWAStatus_WATransID()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@WATransID", SqlDbType.BigInt, 8, ParameterDirection.Input, watransid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblWAStatus_WATransID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update_tblWAStatus()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[7];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@WATransID", SqlDbType.BigInt, 8, ParameterDirection.Input, watransid);
                myparam[1] = ModHelper.CreateParameter("@Reason", SqlDbType.Char, 1, ParameterDirection.Input, reason);
                myparam[2] = ModHelper.CreateParameter("@Status", SqlDbType.Char, 1, ParameterDirection.Input, wastatus);
                myparam[3] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
                myparam[4] = ModHelper.CreateParameter("@InspectedBy", SqlDbType.Int, 4, ParameterDirection.Input, inspectedby);
                myparam[5] = ModHelper.CreateParameter("@StatusID", SqlDbType.BigInt, 8, ParameterDirection.Input, statusid);
                myparam[6] = ModHelper.CreateParameter("@Mettler", SqlDbType.Int, 4, ParameterDirection.Input, mettler);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblWAStatus", myparam);                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Avinash 17-0702014

        public void Insert_tblWAStatus_Scoop()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[10];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@uptestsamplingpointid", SqlDbType.BigInt, 8, ParameterDirection.Input, upsamplingpointid);
                myparam[1] = ModHelper.CreateParameter("@Reason", SqlDbType.Char, 1, ParameterDirection.Input, reason);
                myparam[2] = ModHelper.CreateParameter("@Status", SqlDbType.Char, 1, ParameterDirection.Input, wastatus);
                myparam[3] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
                myparam[4] = ModHelper.CreateParameter("@InspectedBy", SqlDbType.Int, 4, ParameterDirection.Input, inspectedby);
                myparam[5] = ModHelper.CreateParameter("@MTID", SqlDbType.Int, 4, ParameterDirection.Input, mtid);
                myparam[6] = ModHelper.CreateParameter("@TestNo", SqlDbType.Int, 4, ParameterDirection.Input, testno);
                myparam[7] = ModHelper.CreateParameter("@TimeBrief", SqlDbType.DateTime, 8, ParameterDirection.Input, timebrief);
                myparam[8] = ModHelper.CreateParameter("@Avgrage", SqlDbType.Float, 4, ParameterDirection.Input, avg);
                myparam[9] = ModHelper.CreateParameter("@AnalysisType", SqlDbType.NVarChar, 20, ParameterDirection.Input, analysistype);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_tblWAScoopStatus_Insert", myparam);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Update_tblWAStatus_Scoop()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[7];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@uptestsamplingpointid", SqlDbType.BigInt, 8, ParameterDirection.Input, upsamplingpointid);
                myparam[1] = ModHelper.CreateParameter("@Reason", SqlDbType.Char, 1, ParameterDirection.Input, reason);
                myparam[2] = ModHelper.CreateParameter("@Status", SqlDbType.Char, 1, ParameterDirection.Input, wastatus);
                myparam[3] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
                myparam[4] = ModHelper.CreateParameter("@InspectedBy", SqlDbType.Int, 4, ParameterDirection.Input, inspectedby);
                myparam[5] = ModHelper.CreateParameter("@MTID", SqlDbType.Int, 4, ParameterDirection.Input, mtid);
                myparam[6] = ModHelper.CreateParameter("@Avgrage", SqlDbType.Float, 4, ParameterDirection.Input, avg);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_tblWAScoopStatus_Update", myparam);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert_tblWAObsScoop_Scoop()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@StatusID", SqlDbType.BigInt, 8, ParameterDirection.Input, statusid);
                myparam[1] = ModHelper.CreateParameter("@Obs", SqlDbType.Float, 8, ParameterDirection.Input, obs);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_tblWAObsScoop_Insert", myparam);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete_tblWAObsScoop_Scoop()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@StatusID", SqlDbType.BigInt, 8, ParameterDirection.Input, statusid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_tblWAObsScoop_Delete", myparam);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblWAStatus_Scoop_StatusID()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@uptestsamplingpointid", SqlDbType.BigInt, 8, ParameterDirection.Input, upsamplingpointid);
                myparam[1] = ModHelper.CreateParameter("@MTID", SqlDbType.Int, 4, ParameterDirection.Input, mtid);
                myparam[2] = ModHelper.CreateParameter("@TestNo", SqlDbType.Int, 4, ParameterDirection.Input, testno);
                myparam[3] = ModHelper.CreateParameter("@TimeBrief", SqlDbType.DateTime, 8, ParameterDirection.Input, timebrief);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblWAStatus_Scoop_StatusID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblWAObsScoop_StatusID()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@StatusID", SqlDbType.BigInt, 8, ParameterDirection.Input, statusid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblWAObsScoop_StatusID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
        
        public long Insert_tblWAStatus()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[7];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@WATransID", SqlDbType.BigInt, 8, ParameterDirection.Input, watransid);
                myparam[1] = ModHelper.CreateParameter("@Reason", SqlDbType.Char, 1, ParameterDirection.Input, reason);
                myparam[2] = ModHelper.CreateParameter("@Status", SqlDbType.Char, 1, ParameterDirection.Input, wastatus);
                myparam[3] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
                myparam[4] = ModHelper.CreateParameter("@InspectedBy", SqlDbType.Int, 4, ParameterDirection.Input, inspectedby);
                myparam[5] = ModHelper.CreateParameter("@StatusID", SqlDbType.BigInt, 8, ParameterDirection.Output, statusid);
                myparam[6] = ModHelper.CreateParameter("@Mettler", SqlDbType.Int, 4, ParameterDirection.Input, mettler);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblWAStatus", myparam);
                return (Convert.ToInt64(myparam[5].Value));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete_tblWAObs()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];                
                myparam[0] = ModHelper.CreateParameter("@StatusID", SqlDbType.BigInt, 8, ParameterDirection.Input, statusid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblWAObs", myparam);                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert_tblWAObs()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];                
                myparam[0] = ModHelper.CreateParameter("@StatusID", SqlDbType.BigInt, 8, ParameterDirection.Input, statusid);
                myparam[1] = ModHelper.CreateParameter("@Obs", SqlDbType.Float, 8, ParameterDirection.Input, obs);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblWAObs", myparam);                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Insert_tblWATrans()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[8];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                myparam[1] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                myparam[2] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[3] = ModHelper.CreateParameter("@LNo", SqlDbType.Int, 4, ParameterDirection.Input, lno);
                myparam[4] = ModHelper.CreateParameter("@FlagRL", SqlDbType.Char, 1, ParameterDirection.Input, flagrl);    
                myparam[5] = ModHelper.CreateParameter("@MTID", SqlDbType.BigInt, 8, ParameterDirection.Input, mtid);               
                myparam[6] = ModHelper.CreateParameter("@WADone", SqlDbType.Bit, 1, ParameterDirection.Input, wadone);
                myparam[7] = ModHelper.CreateParameter("@WATransID", SqlDbType.BigInt, 8, ParameterDirection.Output, watransid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblWATrans", myparam);
                return (Convert.ToInt64(myparam[7].Value));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblWATrans_FGFormula()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[5];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                myparam[1] = ModHelper.CreateParameter("@MTID", SqlDbType.BigInt, 8, ParameterDirection.Input, mtid);
                myparam[2] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                myparam[3] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[4] = ModHelper.CreateParameter("@LNo", SqlDbType.Int, 4, ParameterDirection.Input, lno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblWATrans_FGFormula", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblBulkTestTransaction_FlagRL()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[4];             
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);                
                myparam[1] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                myparam[2] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[3] = ModHelper.CreateParameter("@LNo", SqlDbType.Int, 4, ParameterDirection.Input, lno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblBulkTestTransaction_FlagRL", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update_tblWATrans_WADone()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@WATransID", SqlDbType.BigInt, 8, ParameterDirection.Input, watransid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblWATrans_WADone", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblWAObs_WATransID()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@WATransID", SqlDbType.BigInt, 8, ParameterDirection.Input, watransid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblWAObs_WATransID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_GetNorms_TestNo_FNo_FormulaType()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] myParam = new SqlParameter[3];
                myParam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myParam[1] = ModHelper.CreateParameter("@TestNo", SqlDbType.Int, 4, ParameterDirection.Input, testno);
                myParam[2] = ModHelper.CreateParameter("@FormulaType", SqlDbType.VarChar, 50, ParameterDirection.Input, formulaType);
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblBulkPhysicochemicalTestMethodMaster_FNo_TestNo_FormulaType", myParam).Tables[0];
                return dt;                
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
        public DataSet Select_selectFgLine_tblFGTLF()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_FGLIne_tblFGTLF", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        
        }

        public DataSet SelectLineStartedDate()
        {
            SqlParameter[] myparam = new SqlParameter[3];
            DataSet ds = new DataSet();
            myparam[0] = ModHelper.CreateParameter("@FGCode", SqlDbType.VarChar, 50, ParameterDirection.Input, FGCode);
            myparam[1] = ModHelper.CreateParameter("@TrackCode", SqlDbType.DateTime, 50, ParameterDirection.Input, Convert.ToDateTime(trackcode));
            myparam[2] = ModHelper.CreateParameter("@LNo", SqlDbType.Int, 8 , ParameterDirection.Input, lno);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_Kit_LineStartedDate", myparam);
            return ds;
        }

        public DataSet SelectLineStartedDatefromFGNonadTodayDate(DateTime dt, DateTime dt1)
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[3];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.VarChar, 50, ParameterDirection.Input, fgno);
                myparam[1] = ModHelper.CreateParameter("@dt1", SqlDbType.DateTime, 50, ParameterDirection.Input, dt);
                myparam[2] = ModHelper.CreateParameter("@dt2", SqlDbType.DateTime, 50, ParameterDirection.Input, dt1);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SelectLineStartedDatefromFGNonadTodayDate", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            //throw new Exception("The method or operation is not implemented.");
        }

        //public string GetPKGWO()
        //{
        //    try
        //    {
        //        SqlParameter[] myparam = new SqlParameter[1];
        //        DataSet ds = new DataSet();
        //        myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.VarChar, 50, ParameterDirection.Input, fgno);
        //        //myparam[1] = ModHelper.CreateParameter("@dt1", SqlDbType.DateTime, 50, ParameterDirection.Input, dt);
        //        //myparam[2] = ModHelper.CreateParameter("@dt2", SqlDbType.DateTime, 50, ParameterDirection.Input, dt1);
        //        ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_selectFgLine_tblFGTLF", myparam);
        //        return ds;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public DataSet Select_ScoopLineStart()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGTLGID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_ScoopLineStart",myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update_tblPkgSamp()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[6];
                myparam[0] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, tlfid);               
                if (locationid == 0)
                {
                    myparam[1] = ModHelper.CreateParameter("@LocationID", SqlDbType.BigInt, 8, ParameterDirection.Input, System.DBNull.Value);
                }
                else
                {
                    myparam[1] = ModHelper.CreateParameter("@LocationID", SqlDbType.BigInt, 8, ParameterDirection.Input, locationid);
                }
                
                myparam[2] = ModHelper.CreateParameter("@Kitcode", SqlDbType.VarChar, 50, ParameterDirection.Input, kitcode);
                myparam[3] = ModHelper.CreateParameter("@Tubes", SqlDbType.Int, 4, ParameterDirection.Input, tubes);
                myparam[4] = ModHelper.CreateParameter("@Kits", SqlDbType.Int, 4, ParameterDirection.Input, Kits);
                myparam[5] = ModHelper.CreateParameter("@Bottles", SqlDbType.Int, 4, ParameterDirection.Input, bottles);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblPkgSamp_Baddi", myparam);
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_Location_Baddi()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                myparam[1] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, tlfid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_Location_Baddi", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_PhysicoChemical_Subcontractor_RegularFG()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, tlfid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_PhysicoChemical_Subcontractor_RegularFG", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
