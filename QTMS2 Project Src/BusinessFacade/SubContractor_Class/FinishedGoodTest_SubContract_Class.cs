using System;
using System.Collections.Generic;
using System.Text;
using DataFacade;
using System.Data;
using System.Data.SqlClient;

namespace BusinessFacade.SubContractor_Class
{
    public class FinishedGoodTest_SubContract_Class
    {
        #region variables

        private long _fgno;
        private long _pkgtechno;
        private long _fno;
        private string _status;
        private string _pkgstatus;
        private int _quantity;
        private string _coc;
        private bool _micro;
        private bool _physicochemical;
        private long _FGSupplierID;
        private string _type;
        private string _LotSize;
        private long _testno;
        private long _fgtlfid;
        private long _lno;
        private char _flagrl;
        private long _mtid;
        private bool _wadone;
        private long _watransid;
        private char _reason;
        private char _wastatus;
        private string _analysistype;
        private string _torquemin;
        private string _torquemax;
        private int _count;
        private long _upsamplingpointid;
        private string _supplier;
        private string _fgcode;
        private string _formulano;
        private int _samplesizereading;
        private string _aqlreading;
        private string _aqlzreading;
        private string _aqlcreading;
        private string _aqlmreading;
        private string _aqlm1reading;
        private long _fgmethodno;
        private long _fgpackingno;
        private string _inspectionmethod;
        private string _aql;
        private string _aqlz;
        private string _aqlc;
        private string _aqlm;
        private string _aqlm1;
        private int _samplesize;
        private string _result;
        private long _inspectedby;
        private int _loginid;
        private int _currentflag;
        private long _fgtestno;
        private string _testname;
        private string _frequency;
        private string _trackcode;
        private string _filldate;
        private string _pkgwo;
        private string _price;
        private string _Specification;
        private char _aocPend;
        private string _commentsaoc;
        private string _batchno;
        private string _mfgwo;
        private char _seminished;
        private string _commentsssf;
        private char _wip;
        private char _finishedproduct;
        private long _statusid;
        private double _obs;
        private string CT;
        private string _phychestatus;
        private bool _preservativeDone;
        private bool _fdaDone;
        private long _fmid;
        private long _fgphycheno;
        private long _fgphymethodno;
        private string _reading;
        private string _normmin;
        private string _normmax;
        private string _lorealresult;
        private string _supplierresult;
        private long _TLFID;
        private bool _kit;
        private bool _sf;
        private string _cleardate;
        private string _innoc_broth_date;
        private string _innoc_broth_time;
        private string _innoc_agar_date;
        private string _innoc_agar_time;
        private string _inccubation_broth_date;
        private string _inccubation_broth_time;
        private string _Inccubation_Agar_Date;
        private string _Inccubation_Agar_Time;
        private string _Inccubation_Other_Date;
        private string _inccubation_other_time;
        private string _Inccub_Broth_Temp;
        private string _Inccub_Agar_Temp;
        private string _Inccub_Other_Temp;
        private string _Result_Broth_Date;
        private string _Result_Broth_Time;
        private string _Result_Agar_Date;
        private string _Result_Agar_Time;
        private string _Result_Other_Date;
        private string _Result_Other_Time;
        private string _TotalTime_Broth;
        private string _TotalTime_Agar;
        private string _TotalTime_Other;
        private string _Remarks_Broth;
        private string _Remarks_Agar;
        private string _Remarks_Other;
        private char _BpcNonBpc;
        private string _NonBpcComments;
        private string _comments;
        private string _medialotno;
        private char _sampletoretainer;
        private char _microstatus;
        private string _testdate;
        private string _Comment;
        private string _decision;
        private string _rejectcomment;
        private int _noofdefects;
        private int _noofsamples;
        private string _nonbpccomment;
        private string _catagory;
        private string _versionno;
        private string _actualstatus;
        private int _treatmented;
        private int _treatmentdone;
        private string _bmrfilepath;
        private bool _fgdone;
        private string _filename;
        private string _filepath;
        private string _fillvolume;
        private string _inspdate;
        private char _proddecfp;
        private char _proddecsf;
        private string _commentssf;
        private long _locationid;
        private char _proddecwip;
        private char _packingstatus;
        private string _formulatype;
        private bool _packing;
        
        #endregion

        #region Properties

        public bool packing
        {
            get { return _packing; }
            set { _packing = value; }
        }

        public string formulatype
        {
            get { return _formulatype; }
            set { _formulatype = value; }
        }
        public char packingstatus
        {
            get { return _packingstatus; }
            set { _packingstatus = value; }
        }
        public char proddecwip
        {
            get { return _proddecwip; }
            set { _proddecwip = value; }
        }
        public long locationid
        {
            get { return _locationid; }
            set { _locationid = value; }
        }
        public string commentssf
        {
            get { return _commentssf; }
            set { _commentssf = value; }
        }
        public char proddecsf
        {
            get { return _proddecsf; }
            set { _proddecsf = value; }
        }
        public char proddecfp
        {
            get { return _proddecfp; }
            set { _proddecfp = value; }
        }
        public string inspdate
        {
            get { return _inspdate; }
            set { _inspdate = value; }
        }
        public string fillvolume
        {
            get { return _fillvolume; }
            set { _fillvolume = value; }
        }
        public string filepath
        {
            get { return _filepath; }
            set { _filepath = value; }
        }
        public string filename
        {
            get { return _filename; }
            set { _filename = value; }
        }
        public bool fgdone
        {
            get { return _fgdone; }
            set { _fgdone = value; }
        }
        public string bmrfilepath
        {
            get { return _bmrfilepath; }
            set { _bmrfilepath = value; }
        }
        public int treatmentdone
        {
            get { return _treatmentdone; }
            set { _treatmentdone = value; }
        }
        public int treatmented
        {
            get { return _treatmented; }
            set { _treatmented = value; }
        }
        public string actualstatus
        {
            get { return _actualstatus; }
            set { _actualstatus = value; }
        }
        public string versionno
        {
            get { return _versionno; }
            set { _versionno = value; }
        }
        public string catagory
        {
            get { return _catagory; }
            set { _catagory = value; }
        }
        public string nonbpccomment
        {
            get { return _nonbpccomment; }
            set { _nonbpccomment = value; }
        }
        public int noofsamples
        {
            get { return _noofsamples; }
            set { _noofsamples = value; }
        }
        public int noofdefects
        {
            get { return _noofdefects; }
            set { _noofdefects = value; }
        }
        public string rejectcomment
        {
            get { return _rejectcomment; }
            set { _rejectcomment = value; }
        }
        public string decision
        {
            get { return _decision; }
            set { _decision = value; }
        }
        public string Comment
        {
            get { return _Comment; }
            set { _Comment = value; }
        }
        public string testdate
        {
            get { return _testdate; }
            set { _testdate = value; }
        }
        public char microstatus
        {
            get { return _microstatus; }
            set { _microstatus = value; }
        }
        public char sampletoretainer
        {
            get { return _sampletoretainer; }
            set { _sampletoretainer = value; }
        }
        public string medialotno
        {
            get { return _medialotno; }
            set { _medialotno = value; }
        }
        public string comments
        {
            get { return _comments; }
            set { _comments = value; }
        }
        public string NonBpcComments
        {
            get { return _NonBpcComments; }
            set { _NonBpcComments = value; }
        }
        public char BpcNonBpc
        {
            get { return _BpcNonBpc; }
            set { _BpcNonBpc = value; }
        }
        public string Remarks_Other
        {
            get { return _Remarks_Other; }
            set { _Remarks_Other = value; }
        }
        public string Remarks_Agar
        {
            get { return _Remarks_Agar; }
            set { _Remarks_Agar = value; }
        }
        public string Remarks_Broth
        {
            get { return _Remarks_Broth; }
            set { _Remarks_Broth = value; }
        }
        public string TotalTime_Other
        {
            get { return _TotalTime_Other; }
            set { _TotalTime_Other = value; }
        }
        public string TotalTime_Agar
        {
            get { return _TotalTime_Agar; }
            set { _TotalTime_Agar = value; }
        }
        public string TotalTime_Broth
        {
            get { return _TotalTime_Broth; }
            set { _TotalTime_Broth = value; }
        }
        public string Result_Other_Time
        {
            get { return _Result_Other_Time; }
            set { _Result_Other_Time = value; }
        }
        public string Result_Other_Date
        {
            get { return _Result_Other_Date; }
            set { _Result_Other_Date = value; }
        }
        public string Result_Agar_Time
        {
            get { return _Result_Agar_Time; }
            set { _Result_Agar_Time = value; }
        }
        public string Result_Agar_Date
        {
            get { return _Result_Agar_Date; }
            set { _Result_Agar_Date = value; }
        }
        public string Result_Broth_Time
        {
            get { return _Result_Broth_Time; }
            set { _Result_Broth_Time = value; }
        }
        public string Result_Broth_Date
        {
            get { return _Result_Broth_Date; }
            set { _Result_Broth_Date = value; }
        }
        public string Inccub_Other_Temp
        {
            get { return _Inccub_Other_Temp; }
            set { _Inccub_Other_Temp = value; }
        }
        public string Inccub_Agar_Temp
        {
            get { return _Inccub_Agar_Temp; }
            set { _Inccub_Agar_Temp = value; }
        }
        public string Inccub_Broth_Temp
        {
            get { return _Inccub_Broth_Temp; }
            set { _Inccub_Broth_Temp = value; }
        }
        public string inccubation_other_time
        {
            get { return _inccubation_other_time; }
            set { _inccubation_other_time = value; }
        }
        public string Inccubation_Other_Date
        {
            get { return _Inccubation_Other_Date; }
            set { _Inccubation_Other_Date = value; }
        }
        public string Inccubation_Agar_Time
        {
            get { return _Inccubation_Agar_Time; }
            set { _Inccubation_Agar_Time = value; }
        }
        public string Inccubation_Agar_Date
        {
            get { return _Inccubation_Agar_Date; }
            set { _Inccubation_Agar_Date = value; }
        }
        public string inccubation_broth_time
        {
            get { return _inccubation_broth_time; }
            set { _inccubation_broth_time = value; }
        }
        public string inccubation_broth_date
        {
            get { return _inccubation_broth_date; }
            set { _inccubation_broth_date = value; }
        }
        public string innoc_agar_time
        {
            get { return _innoc_agar_time; }
            set { _innoc_agar_time = value; }
        }
        public string innoc_agar_date
        {
            get { return _innoc_agar_date; }
            set { _innoc_agar_date = value; }
        }
        public string innoc_broth_time
        {
            get { return _innoc_broth_time; }
            set { _innoc_broth_time = value; }
        }
        public string innoc_broth_date
        {
            get { return _innoc_broth_date; }
            set { _innoc_broth_date = value; }
        }
        public string cleardate
        {
            get { return _cleardate; }
            set { _cleardate = value; }
        }
        public bool sf
        {
            get { return _sf; }
            set { _sf = value; }
        }
        public bool kit
        {
            get { return _kit; }
            set { _kit = value; }
        }
        public long TLFID
        {
            get { return _TLFID; }
            set { _TLFID = value; }
        }
        public string supplierresult
        {
            get { return _supplierresult; }
            set { _supplierresult = value; }
        }
        public string lorealresult
        {
            get { return _lorealresult; }
            set { _lorealresult = value; }
        }
        public string normmax
        {
            get { return _normmax; }
            set { _normmax = value; }
        }
        public string normmin
        {
            get { return _normmin; }
            set { _normmin = value; }
        }
        public string reading
        {
            get { return _reading; }
            set { _reading = value; }
        }
        public long fgphymethodno
        {
            get { return _fgphymethodno; }
            set { _fgphymethodno = value; }
        }
        public long fgphycheno
        {
            get { return _fgphycheno; }
            set { _fgphycheno = value; }
        }
        public long fmid
        {
            get { return _fmid; }
            set { _fmid = value; }
        }
        public bool fdaDone
        {
            get { return _fdaDone; }
            set { _fdaDone = value; }
        }
        public bool preservativeDone
        {
            get { return _preservativeDone; }
            set { _preservativeDone = value; }
        }
        public string phychestatus
        {
            get { return _phychestatus; }
            set { _phychestatus = value; }
        }
        public double obs
        {
            get { return _obs; }
            set { _obs = value; }
        }
        public long statusid
        {
            get { return _statusid; }
            set { _statusid = value; }
        }
        public char finishedproduct
        {
            get { return _finishedproduct; }
            set { _finishedproduct = value; }
        }
        public char wip
        {
            get { return _wip; }
            set { _wip = value; }
        }
        public string commentsssf
        {
            get { return _commentsssf; }
            set { _commentsssf = value; }
        }
        public char seminished
        {
            get { return _seminished; }
            set { _seminished = value; }
        }
        public string mfgwo
        {
            get { return _mfgwo; }
            set { _mfgwo = value; }
        }
        public string batchno
        {
            get { return _batchno; }
            set { _batchno = value; }
        }
        public string commentsaoc
        {
            get { return _commentsaoc; }
            set { _commentsaoc = value; }
        }
        public char aocPend
        {
            get { return _aocPend; }
            set { _aocPend = value; }
        }
        public string Specification
        {
            get { return _Specification; }
            set { _Specification = value; }
        }
        public string price
        {
            get { return _price; }
            set { _price = value; }
        }
        public string pkgwo
        {
            get { return _pkgwo; }
            set { _pkgwo = value; }
        }
        public string filldate
        {
            get { return _filldate; }
            set { _filldate = value; }
        }
        public string trackcode
        {
            get { return _trackcode; }
            set { _trackcode = value; }
        }
        public string frequency
        {
            get { return _frequency; }
            set { _frequency = value; }
        }
        public string testname
        {
            get { return _testname; }
            set { _testname = value; }
        }
        public long fgtestno
        {
            get { return _fgtestno; }
            set { _fgtestno = value; }
        }
        public int currentflag
        {
            get { return _currentflag; }
            set { _currentflag = value; }
        }
        public int loginid
        {
            get { return _loginid; }
            set { _loginid = value; }
        }
        public long inspectedby
        {
            get { return _inspectedby; }
            set { _inspectedby = value; }
        }
        public string result
        {
            get { return _result; }
            set { _result = value; }
        }
        public int samplesize
        {
            get { return _samplesize; }
            set { _samplesize = value; }
        }
        public string aqlm1
        {
            get { return _aqlm1; }
            set { _aqlm1 = value; }
        }
        public string aqlm
        {
            get { return _aqlm; }
            set { _aqlm = value; }
        }
        public string aqlc
        {
            get { return _aqlc; }
            set { _aqlc = value; }
        }
        public string aqlz
        {
            get { return _aqlz; }
            set { _aqlz = value; }
        }
        public string aql
        {
            get { return _aql; }
            set { _aql = value; }
        }
        public string inspectionmethod
        {
            get { return _inspectionmethod; }
            set { _inspectionmethod = value; }
        }
        public long fgpackingno
        {
            get { return _fgpackingno; }
            set { _fgpackingno = value; }
        }
        public long fgmethodno
        {
            get { return _fgmethodno; }
            set { _fgmethodno = value; }
        }
        public string aqlm1reading
        {
            get { return _aqlm1reading; }
            set { _aqlm1reading = value; }
        }
        public string aqlmreading
        {
            get { return _aqlmreading; }
            set { _aqlmreading = value; }
        }
        public string aqlcreading
        {
            get { return _aqlcreading; }
            set { _aqlcreading = value; }
        }
        public string aqlzreading
        {
            get { return _aqlzreading; }
            set { _aqlzreading = value; }
        }
        public string aqlreading
        {
            get { return _aqlreading; }
            set { _aqlreading = value; }
        }
        public int samplesizereading
        {
            get { return _samplesizereading; }
            set { _samplesizereading = value; }
        }
        public string supplier
        {
            get { return _supplier; }
            set { _supplier = value; }
        }
        public string fgcode
        {
            get { return _fgcode; }
            set { _fgcode = value; }
        }
        public string formulano
        {
            get { return _formulano; }
            set { _formulano = value; }
        }
        public long upsamplingpointid
        {
            get { return _upsamplingpointid; }
            set { _upsamplingpointid = value; }
        }
        public int count
        {
            get { return _count; }
            set { _count = value; }
        }
        public string analysistype
        {
            get { return _analysistype; }
            set { _analysistype = value; }
        }
        public string torquemin
        {
            get { return _torquemin; }
            set { _torquemin = value; }
        }
        public string torquemax
        {
            get { return _torquemax; }
            set { _torquemax = value; }
        }
        public char reason
        {
            get { return _reason; }
            set { _reason = value; }
        }
        public char wastatus
        {
            get { return _wastatus; }
            set { _wastatus = value; }
        }
        public long watransid
        {
            get { return _watransid; }
            set { _watransid = value; }
        }
        public bool wadone
        {
            get { return _wadone; }
            set { _wadone = value; }
        }
        public long mtid
        {
            get { return _mtid; }
            set { _mtid = value; }
        }
        public char flagrl
        {
            get { return _flagrl; }
            set { _flagrl = value; }
        }
        public long lno
        {
            get { return _lno; }
            set { _lno = value; }
        }
        public long fgtlfid
        {
            get { return _fgtlfid; }
            set { _fgtlfid = value; }
        }
        public long testno
        {
            get { return _testno; }
            set { _testno = value; }
        }
        public string lotsize
        {
            get { return _LotSize; }
            set { _LotSize = value; }
        }
        public string type
        {
            get { return _type; }
            set { _type = value; }
        }
        public string coc
        {
            get { return _coc; }
            set { _coc = value; }
        }
        public bool micro
        {
            get { return _micro; }
            set { _micro = value; }
        }
        public bool physicochemical
        {
            get { return _physicochemical; }
            set { _physicochemical = value; }
        }
        public long FGSupplierID
        {
            get { return _FGSupplierID; }
            set { _FGSupplierID = value; }
        }
        public int quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }
        public string pkgstatus
        {
            get { return _pkgstatus; }
            set { _pkgstatus = value; }
        }
        public string status
        {
            get { return _status; }
            set { _status = value; }
        }
        public long fgno
        {
            get { return _fgno; }
            set { _fgno = value; }
        }
        public long pkgtechno
        {
            get { return _pkgtechno; }
            set { _pkgtechno = value; }
        }
        public long fno
        {
            get { return _fno; }
            set { _fno = value; }
        }

        private string _FGPackingfilepath;
        public string FGPackingfilepath
        {
            get { return _FGPackingfilepath; }
            set { _FGPackingfilepath = value; }
        }

        #endregion

        #region Functions

        public string Decide_ControlType_FG_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@LNo", SqlDbType.Int, 4, ParameterDirection.Input, FGSupplierID);
                myparam[1] = ModHelper.CreateParameter("@ControlType", SqlDbType.VarChar, 50, ParameterDirection.Output, type);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Decide_ControlType_FG_SubContract", myparam);

                CT = Convert.ToString(myparam[1].Value);

                return CT;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_FinishedGoodDetails_SubContract()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_FinishedGoodDetails_SubContract");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SELECT_FinishedGood_SubContract_FGNo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.NVarChar, 200, ParameterDirection.Input, fgno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_FinishedGood_SubContract", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SELECT_FormulaNumber_SubContract_FGNo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.NVarChar, 200, ParameterDirection.Input, fgno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_FormulaNumber_SubContract", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SELECT_SUPPLIER_SubContract_FGNo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.NVarChar, 200, ParameterDirection.Input, fgno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_SUPPLIER_FGNo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_MicroPhysicochemical_SubContract()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                myparam[1] = ModHelper.CreateParameter("@FGSupplierID", SqlDbType.BigInt, 8, ParameterDirection.Input, FGSupplierID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_MicroPhysicochemical_SubContract", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_VIEW_FinishedGoodDetails1_TestNo_TestName1_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[5];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                myparam[1] = ModHelper.CreateParameter("@PKGTechNo", SqlDbType.BigInt, 8, ParameterDirection.Input, pkgtechno);
                myparam[2] = ModHelper.CreateParameter("@Type", SqlDbType.VarChar, 50, ParameterDirection.Input, type);
                myparam[3] = ModHelper.CreateParameter("@LotSize", SqlDbType.VarChar, 50, ParameterDirection.Input, lotsize);
                myparam[4] = ModHelper.CreateParameter("@ScoopApplicable", SqlDbType.Bit, 1, ParameterDirection.Input, 0);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Select_VIEW_FinishedGoodDetails1_TestNo_TestName1", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_VIEW_FinishedGoodDetails_TestNo_TestName_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[3];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@PKGTechNo", SqlDbType.BigInt, 8, ParameterDirection.Input, pkgtechno);
                myparam[1] = ModHelper.CreateParameter("@Type", SqlDbType.VarChar, 50, ParameterDirection.Input, type);
                myparam[2] = ModHelper.CreateParameter("@LotSize", SqlDbType.VarChar, 50, ParameterDirection.Input, lotsize);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Select_VIEW_FinishedGoodDetails_TestNo_TestName", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SELECT_TblTestMaster_SubContract()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@TestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, testno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_TblTestMaster_SubContract", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Insert_tblWATrans_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[8];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                myparam[1] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                myparam[2] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[3] = ModHelper.CreateParameter("@LNo", SqlDbType.Int, 4, ParameterDirection.Input, FGSupplierID);
                myparam[4] = ModHelper.CreateParameter("@FlagRL", SqlDbType.Char, 1, ParameterDirection.Input, flagrl);
                myparam[5] = ModHelper.CreateParameter("@MTID", SqlDbType.BigInt, 8, ParameterDirection.Input, mtid);
                myparam[6] = ModHelper.CreateParameter("@WADone", SqlDbType.Bit, 1, ParameterDirection.Input, wadone);
                myparam[7] = ModHelper.CreateParameter("@WATransID", SqlDbType.BigInt, 8, ParameterDirection.Output, watransid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblWATrans_SubContract", myparam);
                return (Convert.ToInt64(myparam[7].Value));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblWATrans_FGFormula_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];
                DataSet ds = new DataSet();

                myparam[0] = ModHelper.CreateParameter("@MTID", SqlDbType.BigInt, 8, ParameterDirection.Input, mtid);
                myparam[1] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                myparam[2] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[3] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblWATrans_FGFormula_SubContract", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert_tblFinishedGoodTest_TestMethodDetails_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[17];
                myparam[0] = ModHelper.CreateParameter("@SampleSizeReading", SqlDbType.Int, 4, ParameterDirection.Input, samplesizereading);
                myparam[1] = ModHelper.CreateParameter("@AQLReading", SqlDbType.VarChar, 50, ParameterDirection.Input, aqlreading);
                myparam[2] = ModHelper.CreateParameter("@AQLZReading", SqlDbType.VarChar, 50, ParameterDirection.Input, aqlzreading);
                myparam[3] = ModHelper.CreateParameter("@AQLCReading", SqlDbType.VarChar, 50, ParameterDirection.Input, aqlcreading);
                myparam[4] = ModHelper.CreateParameter("@AQLMReading", SqlDbType.VarChar, 50, ParameterDirection.Input, aqlmreading);
                myparam[5] = ModHelper.CreateParameter("@AQLM1Reading", SqlDbType.VarChar, 50, ParameterDirection.Input, aqlm1reading);
                myparam[6] = ModHelper.CreateParameter("@FGMethodNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgmethodno);
                myparam[7] = ModHelper.CreateParameter("@FGPackingNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgpackingno);
                myparam[8] = ModHelper.CreateParameter("@InspectionMethod", SqlDbType.VarChar, 50, ParameterDirection.Input, inspectionmethod);
                myparam[9] = ModHelper.CreateParameter("@AQL", SqlDbType.VarChar, 50, ParameterDirection.Input, aql);
                myparam[10] = ModHelper.CreateParameter("@AQLZ", SqlDbType.VarChar, 50, ParameterDirection.Input, aqlz);
                myparam[11] = ModHelper.CreateParameter("@AQLC", SqlDbType.VarChar, 50, ParameterDirection.Input, aqlc);
                myparam[12] = ModHelper.CreateParameter("@AQLM", SqlDbType.VarChar, 50, ParameterDirection.Input, aqlm);
                myparam[13] = ModHelper.CreateParameter("@AQLM1", SqlDbType.VarChar, 50, ParameterDirection.Input, aqlm1);
                myparam[14] = ModHelper.CreateParameter("@SampleSize", SqlDbType.Int, 4, ParameterDirection.Input, samplesize);
                myparam[15] = ModHelper.CreateParameter("@Result", SqlDbType.VarChar, 50, ParameterDirection.Input, result);
                myparam[16] = ModHelper.CreateParameter("@SupplierID", SqlDbType.BigInt, 8, ParameterDirection.Input, FGSupplierID);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblFinishedGoodTest_TestMethodDetails_SubContract", myparam);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Insert_tblFinishedGoodPackingDetails_SubContract()
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
                SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Insert_tblFinishedGoodPackingDetails_SubContract", myparam);
                return (Convert.ToInt64(myparam[5].Value));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long INSERT_FinishedGood_Status_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[6];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@Status", SqlDbType.Char, 10, ParameterDirection.Input, status);
                myparam[1] = ModHelper.CreateParameter("@ControlType", SqlDbType.VarChar, 50, ParameterDirection.Input, type);
                myparam[2] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.VarChar, 50, ParameterDirection.Input, fgtlfid);
                myparam[3] = ModHelper.CreateParameter("@CurrentFlag", SqlDbType.Bit, 1, ParameterDirection.Input, currentflag);
                myparam[4] = ModHelper.CreateParameter("@SupplierID", SqlDbType.BigInt, 8, ParameterDirection.Input, FGSupplierID);
                myparam[5] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Output, fgtestno);

                SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_INSERT_FinishedGood_Status_SubContract", myparam);
                return (Convert.ToInt64(myparam[5].Value));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Update_tblFinishedGoodPackingDetails_SubContract()
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
                SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Update_tblFinishedGoodPackingDetails_SubContract", myparam);
                return (Convert.ToInt64(myparam[5].Value));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete_tblFinishedGoodTest_TestMethodDetails_FGPackingNo_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGPackingNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgpackingno);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Delete_tblFinishedGoodTest_TestMethodDetails_FGPackingNo_SubContract", myparam);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Insert_tblFGTLF_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[18];
                myparam[0] = ModHelper.CreateParameter("@TrackCode", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, trackcode);
                myparam[1] = ModHelper.CreateParameter("@LNo", SqlDbType.BigInt, 8, ParameterDirection.Input, lno);
                myparam[2] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                myparam[3] = ModHelper.CreateParameter("@FillDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, filldate);
                myparam[4] = ModHelper.CreateParameter("@PkgWO", SqlDbType.NVarChar, 200, ParameterDirection.Input, pkgwo);
                myparam[5] = ModHelper.CreateParameter("@Price", SqlDbType.NVarChar, 50, ParameterDirection.Input, price);
                myparam[6] = ModHelper.CreateParameter("@specification", SqlDbType.VarChar, 50, ParameterDirection.Input, Specification);
                myparam[7] = ModHelper.CreateParameter("@AOCPend", SqlDbType.Char, 1, ParameterDirection.Input, aocPend);
                myparam[8] = ModHelper.CreateParameter("@CommentsAOC", SqlDbType.NVarChar, 250, ParameterDirection.Input, commentsaoc);
                myparam[9] = ModHelper.CreateParameter("@BatchNo", SqlDbType.VarChar, 50, ParameterDirection.Input, batchno);
                myparam[10] = ModHelper.CreateParameter("@Fno", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[11] = ModHelper.CreateParameter("@MfgWo", SqlDbType.VarChar, 50, ParameterDirection.Input, "");
                myparam[12] = ModHelper.CreateParameter("@SupplierID", SqlDbType.BigInt, 8, ParameterDirection.Input, FGSupplierID);
                myparam[13] = ModHelper.CreateParameter("@Semifinished", SqlDbType.Char, 1, ParameterDirection.Input, seminished);
                myparam[14] = ModHelper.CreateParameter("@CommentSSF", SqlDbType.NVarChar, 250, ParameterDirection.Input, commentsssf);
                myparam[15] = ModHelper.CreateParameter("@WIP", SqlDbType.Char, 1, ParameterDirection.Input, wip);
                myparam[16] = ModHelper.CreateParameter("@FinishedProduct", SqlDbType.Char, 1, ParameterDirection.Input, finishedproduct);

                myparam[17] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.VarChar, 50, ParameterDirection.Output, fgtlfid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblFGTLF_SubContract", myparam);

                return Convert.ToInt64(myparam[17].Value);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update_tblFGTLF_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[18];
                myparam[0] = ModHelper.CreateParameter("@TrackCode", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, trackcode);
                myparam[1] = ModHelper.CreateParameter("@LNo", SqlDbType.BigInt, 8, ParameterDirection.Input, lno);
                myparam[2] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                myparam[3] = ModHelper.CreateParameter("@FillDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, filldate);
                myparam[4] = ModHelper.CreateParameter("@PkgWO", SqlDbType.NVarChar, 200, ParameterDirection.Input, pkgwo);
                myparam[5] = ModHelper.CreateParameter("@Price", SqlDbType.NVarChar, 50, ParameterDirection.Input, price);
                myparam[6] = ModHelper.CreateParameter("@specification", SqlDbType.VarChar, 50, ParameterDirection.Input, Specification);
                myparam[7] = ModHelper.CreateParameter("@AOCPend", SqlDbType.Char, 1, ParameterDirection.Input, aocPend);
                myparam[8] = ModHelper.CreateParameter("@CommentsAOC", SqlDbType.NVarChar, 250, ParameterDirection.Input, commentsaoc);
                myparam[9] = ModHelper.CreateParameter("@BatchNo", SqlDbType.VarChar, 50, ParameterDirection.Input, batchno);
                myparam[10] = ModHelper.CreateParameter("@Fno", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[11] = ModHelper.CreateParameter("@MfgWo", SqlDbType.VarChar, 50, ParameterDirection.Input, "");
                myparam[12] = ModHelper.CreateParameter("@SupplierID", SqlDbType.BigInt, 8, ParameterDirection.Input, FGSupplierID);
                myparam[13] = ModHelper.CreateParameter("@Semifinished", SqlDbType.Char, 1, ParameterDirection.Input, seminished);
                myparam[14] = ModHelper.CreateParameter("@CommentSSF", SqlDbType.NVarChar, 250, ParameterDirection.Input, commentsssf);
                myparam[15] = ModHelper.CreateParameter("@WIP", SqlDbType.Char, 1, ParameterDirection.Input, wip);
                myparam[16] = ModHelper.CreateParameter("@FinishedProduct", SqlDbType.Char, 1, ParameterDirection.Input, finishedproduct);

                myparam[17] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.VarChar, 50, ParameterDirection.Input, fgtlfid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblFGTLF_SubContract", myparam);

                //return Convert.ToInt64(myparam[17].Value);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblFinishedGoodDetails_FGTLFID_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblFinishedGoodDetails_SubContract_FGTLFID_SubContract", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblFinishedGoodPackingDetails_FGTLFID_SubContract()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Select_tblFinishedGoodPackingDetails_FGTLFID_SubContract", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblFinishedGoodPackingDetails_PkgStatus_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblFinishedGoodPackingDetails_PkgStatus_SubContract", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblFGTLF_SubContract_FGTLFID()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[5];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                myparam[1] = ModHelper.CreateParameter("@Fno", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[2] = ModHelper.CreateParameter("@MfgWo", SqlDbType.VarChar, 50, ParameterDirection.Input, mfgwo);
                myparam[3] = ModHelper.CreateParameter("@SupplierID", SqlDbType.BigInt, 8, ParameterDirection.Input, FGSupplierID);
                myparam[4] = ModHelper.CreateParameter("@TrackCode", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, trackcode);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblFGTLF_SubContract_FGTLFID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_VIEW_FinishedGoodTestMethodDetails_InspectionMethod_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[6];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@Method", SqlDbType.NVarChar, 250, ParameterDirection.Input, testname);
                myparam[1] = ModHelper.CreateParameter("@PKGTechNo", SqlDbType.BigInt, 8, ParameterDirection.Input, pkgtechno);
                myparam[2] = ModHelper.CreateParameter("@Type", SqlDbType.VarChar, 50, ParameterDirection.Input, type);
                myparam[3] = ModHelper.CreateParameter("@LotSize", SqlDbType.VarChar, 50, ParameterDirection.Input, lotsize);
                myparam[4] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtestno);
                myparam[5] = ModHelper.CreateParameter("@Result", SqlDbType.VarChar, 50, ParameterDirection.Input, result);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Select_VIEW_FinishedGoodTestMethodDetails_InspectionMethod_SubContract", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet STP_Select_tblFinishedGoodTest_TestMethodDetails_FGTLFID_FGMethodNo_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[3];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                myparam[1] = ModHelper.CreateParameter("@FGMethodNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgmethodno);
                myparam[2] = ModHelper.CreateParameter("@Result", SqlDbType.VarChar, 50, ParameterDirection.Input, result);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblFinishedGoodTest_TestMethodDetails_FGTLFID_FGMethodNo_SubContract", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_VIEW_FinishedGoodTestMethodDetails_All_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[7];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@Method", SqlDbType.NVarChar, 250, ParameterDirection.Input, testname);
                myparam[1] = ModHelper.CreateParameter("@PKGTechNo", SqlDbType.BigInt, 8, ParameterDirection.Input, pkgtechno);
                myparam[2] = ModHelper.CreateParameter("@Type", SqlDbType.VarChar, 50, ParameterDirection.Input, type);
                myparam[3] = ModHelper.CreateParameter("@LotSize", SqlDbType.VarChar, 50, ParameterDirection.Input, lotsize);
                myparam[4] = ModHelper.CreateParameter("@InspectionMethod", SqlDbType.VarChar, 50, ParameterDirection.Input, inspectionmethod);
                myparam[5] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtestno);
                myparam[6] = ModHelper.CreateParameter("@Result", SqlDbType.VarChar, 50, ParameterDirection.Input, result);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Select_VIEW_FinishedGoodTestMethodDetails_All_SubContract_SubContract", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Insert_tblWAStatus_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[6];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@WATransID", SqlDbType.BigInt, 8, ParameterDirection.Input, watransid);
                myparam[1] = ModHelper.CreateParameter("@Reason", SqlDbType.Char, 1, ParameterDirection.Input, reason);
                myparam[2] = ModHelper.CreateParameter("@Status", SqlDbType.Char, 1, ParameterDirection.Input, wastatus);
                myparam[3] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
                myparam[4] = ModHelper.CreateParameter("@InspectedBy", SqlDbType.Int, 4, ParameterDirection.Input, inspectedby);
                myparam[5] = ModHelper.CreateParameter("@StatusID", SqlDbType.BigInt, 8, ParameterDirection.Output, statusid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblWAStatus_SubContract", myparam);
                return (Convert.ToInt64(myparam[5].Value));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblWAStatus_WATransID_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@WATransID", SqlDbType.BigInt, 8, ParameterDirection.Input, watransid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblWAStatus_WATransID_SubContract", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update_tblWAStatus_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[6];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@WATransID", SqlDbType.BigInt, 8, ParameterDirection.Input, watransid);
                myparam[1] = ModHelper.CreateParameter("@Reason", SqlDbType.Char, 1, ParameterDirection.Input, reason);
                myparam[2] = ModHelper.CreateParameter("@Status", SqlDbType.Char, 1, ParameterDirection.Input, wastatus);
                myparam[3] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
                myparam[4] = ModHelper.CreateParameter("@InspectedBy", SqlDbType.Int, 4, ParameterDirection.Input, inspectedby);
                myparam[5] = ModHelper.CreateParameter("@StatusID", SqlDbType.BigInt, 8, ParameterDirection.Input, statusid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblWAStatus_SubContract", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update_tblWATrans_WADone_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@WATransID", SqlDbType.BigInt, 8, ParameterDirection.Input, watransid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblWATrans_WADone_SubContract", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert_tblWAObs_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@StatusID", SqlDbType.BigInt, 8, ParameterDirection.Input, statusid);
                myparam[1] = ModHelper.CreateParameter("@Obs", SqlDbType.Float, 8, ParameterDirection.Input, obs);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblWAObs_SubContract", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete_tblWAObs_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@StatusID", SqlDbType.BigInt, 8, ParameterDirection.Input, statusid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblWAObs_SubContract", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblWAObs_WATransID_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@WATransID", SqlDbType.BigInt, 8, ParameterDirection.Input, watransid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblWAObs_WATransID_SubContract", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_SubContract_FlagRL()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_SubContract_FlagRL", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Decide_Top5Count_WA_SubContract()
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
                myparam[5] = ModHelper.CreateParameter("@LNo", SqlDbType.BigInt, 8, ParameterDirection.Input, FGSupplierID);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Decide_Top5Count_WA_SubContract", myparam);

                return Convert.ToInt32(myparam[3].Value);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Decide_Top20Count_WA_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[6];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                myparam[1] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                myparam[2] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[3] = ModHelper.CreateParameter("@LNo", SqlDbType.Int, 4, ParameterDirection.Input, FGSupplierID);
                myparam[4] = ModHelper.CreateParameter("@MTID", SqlDbType.BigInt, 8, ParameterDirection.Input, mtid);
                myparam[5] = ModHelper.CreateParameter("@Count", SqlDbType.Int, 4, ParameterDirection.Output, count);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Decide_Top20Count_WA_SubContract", myparam);

                return Convert.ToInt32(myparam[5].Value);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Insert_tblTransFMFinishedGoods_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[8];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                myparam[1] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[2] = ModHelper.CreateParameter("@MfgWo", SqlDbType.VarChar, 50, ParameterDirection.Input, mfgwo);
                myparam[3] = ModHelper.CreateParameter("@SupplierID", SqlDbType.Int, 4, ParameterDirection.Input, FGSupplierID);
                myparam[4] = ModHelper.CreateParameter("@PreservativeDone", SqlDbType.Bit, 1, ParameterDirection.Input, preservativeDone);
                myparam[5] = ModHelper.CreateParameter("@FDADone", SqlDbType.Bit, 1, ParameterDirection.Input, fdaDone);
                myparam[6] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Output, fmid);
                myparam[7] = ModHelper.CreateParameter("@TrackCode", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, trackcode);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblTransFMFinishedGoods_SubContract", myparam);

                return Convert.ToInt32(myparam[6].Value);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblTransFMFinishedGoods_SubContract_FMID()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[5];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                myparam[1] = ModHelper.CreateParameter("@Fno", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[2] = ModHelper.CreateParameter("@MfgWo", SqlDbType.VarChar, 50, ParameterDirection.Input, mfgwo);
                myparam[3] = ModHelper.CreateParameter("@SupplierID", SqlDbType.BigInt, 8, ParameterDirection.Input, FGSupplierID);
                myparam[4] = ModHelper.CreateParameter("@TrackCode", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, trackcode);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblTransFMFinishedGoods_SubContract_FMID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Insert_tblFinishedGoodPhyCheDetails_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[6];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtestno);
                myparam[1] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                myparam[2] = ModHelper.CreateParameter("@PhyCheStatus", SqlDbType.Char, 1, ParameterDirection.Input, phychestatus);
                myparam[3] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
                myparam[4] = ModHelper.CreateParameter("@InspectedBy", SqlDbType.Int, 4, ParameterDirection.Input, inspectedby);
                myparam[5] = ModHelper.CreateParameter("@FGPhyCheNo", SqlDbType.BigInt, 8, ParameterDirection.Output, fgphycheno);
                SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Insert_tblFinishedGoodPhyCheDetails_SubContract", myparam);
                return (Convert.ToInt64(myparam[5].Value));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Update_tblFinishedGoodPhyCheDetails_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[6];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtestno);
                myparam[1] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                myparam[2] = ModHelper.CreateParameter("@PhyCheStatus", SqlDbType.Char, 1, ParameterDirection.Input, phychestatus);
                myparam[3] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
                myparam[4] = ModHelper.CreateParameter("@InspectedBy", SqlDbType.Int, 4, ParameterDirection.Input, inspectedby);
                myparam[5] = ModHelper.CreateParameter("@FGPhyCheNo", SqlDbType.BigInt, 8, ParameterDirection.Output, fgphycheno);
                SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Update_tblFinishedGoodPhyCheDetails_SubContract", myparam);
                return (Convert.ToInt64(myparam[5].Value));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblFinishedGoodPhyCheDetails_SubContract_FGTLFID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                myparam[1] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Select_tblFinishedGoodPhyCheDetails_SubContract_FGTLFID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert_tblFGPhysicochemicalTestMethodDetails_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[7];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGPhyCheNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgphycheno);
                myparam[1] = ModHelper.CreateParameter("@FGPhyMethodNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgphymethodno);
                myparam[2] = ModHelper.CreateParameter("@NormsReading", SqlDbType.VarChar, 50, ParameterDirection.Input, reading);
                myparam[3] = ModHelper.CreateParameter("@NormsMin", SqlDbType.VarChar, 50, ParameterDirection.Input, normmin);
                myparam[4] = ModHelper.CreateParameter("@NormsMax", SqlDbType.VarChar, 50, ParameterDirection.Input, normmax);
                myparam[5] = ModHelper.CreateParameter("@LoreslResult", SqlDbType.VarChar, 50, ParameterDirection.Input, lorealresult);
                myparam[6] = ModHelper.CreateParameter("@SupplierResult", SqlDbType.VarChar, 50, ParameterDirection.Input, supplierresult);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblFGPhysicochemicalTestMethodDetails_SubContract", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete_tblFGPhysicochemicalTestMethodDetails_FGPhyCheNo_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGPhyCheNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgphycheno);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "Delete_tblFGPhysicochemicalTestMethodDetails_SubContract_FGPhyCheNo", myparam);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblFinishedGoodPhyCheDetails_PhyCheStatus_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblFinishedGoodPhyCheDetails_PhyCheStatus_SubContract", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblFGPhysicochemicalTestMethodDetails_FGTLFID_FMID_Tests_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                //myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblFGPhysicochemicalTestMethodDetails_FGTLFID_FMID_Tests_SubContract", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Insert_tblTransTLF_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[8];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                myparam[1] = ModHelper.CreateParameter("@Trackcode", SqlDbType.SmallDateTime, 50, ParameterDirection.Input, trackcode);
                myparam[2] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                myparam[3] = ModHelper.CreateParameter("@SupplierID", SqlDbType.BigInt, 8, ParameterDirection.Input, FGSupplierID);
                myparam[4] = ModHelper.CreateParameter("@MicroDone", SqlDbType.Bit, 1, ParameterDirection.Input, micro);
                myparam[5] = ModHelper.CreateParameter("@KitFlag", SqlDbType.Bit, 1, ParameterDirection.Input, kit);
                myparam[6] = ModHelper.CreateParameter("@SFFlag", SqlDbType.Bit, 1, ParameterDirection.Input, sf);

                myparam[7] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt, 8, ParameterDirection.Output, TLFID);
                SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Insert_tblTransTLF_SubContract", myparam);
                return (Convert.ToInt64(myparam[7].Value));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblTransTLF_SubContract_TLFID()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblTransTLF_SubContract_TLFID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update_tblTransTLF_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[8];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                myparam[1] = ModHelper.CreateParameter("@Trackcode", SqlDbType.SmallDateTime, 50, ParameterDirection.Input, trackcode);
                myparam[2] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                myparam[3] = ModHelper.CreateParameter("@SupplierID", SqlDbType.BigInt, 8, ParameterDirection.Input, FGSupplierID);
                myparam[4] = ModHelper.CreateParameter("@MicroDone", SqlDbType.Bit, 1, ParameterDirection.Input, micro);
                myparam[5] = ModHelper.CreateParameter("@KitFlag", SqlDbType.Bit, 1, ParameterDirection.Input, kit);
                myparam[6] = ModHelper.CreateParameter("@SFFlag", SqlDbType.Bit, 1, ParameterDirection.Input, sf);
                myparam[7] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, TLFID);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblTransTLF_SubContract", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert_tblMicrobiologytest_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[36];
                myparam[0] = ModHelper.CreateParameter("@ClearDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, cleardate);
                if (innoc_broth_date != "")
                {
                    myparam[1] = ModHelper.CreateParameter("@Innoc_Broth_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, innoc_broth_date);
                }
                else
                {
                    myparam[1] = ModHelper.CreateParameter("@Innoc_Broth_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DBNull.Value);
                }

                if (innoc_broth_time != "")
                {
                    myparam[2] = ModHelper.CreateParameter("@Innoc_Broth_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, innoc_broth_time);
                }
                else
                {
                    myparam[2] = ModHelper.CreateParameter("@Innoc_Broth_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, DBNull.Value);
                }

                if (innoc_agar_date != "")
                {
                    myparam[3] = ModHelper.CreateParameter("@Innoc_Agar_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, innoc_agar_date);
                }
                else
                {
                    myparam[3] = ModHelper.CreateParameter("@Innoc_Agar_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DBNull.Value);
                }
                if (innoc_agar_time != "")
                {
                    myparam[4] = ModHelper.CreateParameter("@Innoc_Agar_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, innoc_agar_time);
                }
                else
                {
                    myparam[4] = ModHelper.CreateParameter("@Innoc_Agar_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, DBNull.Value);
                }
                if (inccubation_broth_date != "")
                {
                    myparam[5] = ModHelper.CreateParameter("@Inccubation_Broth_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, inccubation_broth_date);
                }
                else
                {
                    myparam[5] = ModHelper.CreateParameter("@Inccubation_Broth_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DBNull.Value);
                }

                if (inccubation_broth_time != "")
                {
                    myparam[6] = ModHelper.CreateParameter("@Inccubation_Broth_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, inccubation_broth_time);
                }
                else
                {
                    myparam[6] = ModHelper.CreateParameter("@Inccubation_Broth_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, DBNull.Value);
                }
                if (Inccubation_Agar_Date != "")
                {
                    myparam[7] = ModHelper.CreateParameter("@Inccubation_Agar_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, Inccubation_Agar_Date);
                }
                else
                {
                    myparam[7] = ModHelper.CreateParameter("@Inccubation_Agar_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DBNull.Value);
                }

                if (Inccubation_Agar_Time != "")
                {
                    myparam[8] = ModHelper.CreateParameter("@Inccubation_Agar_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, Inccubation_Agar_Time);
                }
                else
                {
                    myparam[8] = ModHelper.CreateParameter("@Inccubation_Agar_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, DBNull.Value);
                }
                if (Inccubation_Other_Date != "")
                {
                    myparam[9] = ModHelper.CreateParameter("@Inccubation_Other_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, Inccubation_Other_Date);
                }
                else
                {
                    myparam[9] = ModHelper.CreateParameter("@Inccubation_Other_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DBNull.Value);
                }

                if (inccubation_other_time != "")
                {
                    myparam[10] = ModHelper.CreateParameter("@Inccubation_Other_time", SqlDbType.VarChar, 50, ParameterDirection.Input, inccubation_other_time);
                }
                else
                {
                    myparam[10] = ModHelper.CreateParameter("@Inccubation_Other_time", SqlDbType.VarChar, 50, ParameterDirection.Input, DBNull.Value);
                }

                myparam[11] = ModHelper.CreateParameter("@Inccub_Broth_Temp", SqlDbType.NVarChar, 50, ParameterDirection.Input, Inccub_Broth_Temp);
                myparam[12] = ModHelper.CreateParameter("@Inccub_Agar_Temp", SqlDbType.NVarChar, 50, ParameterDirection.Input, Inccub_Agar_Temp);
                myparam[13] = ModHelper.CreateParameter("@Inccub_Other_Temp", SqlDbType.NVarChar, 50, ParameterDirection.Input, Inccub_Other_Temp);
                if (Result_Broth_Date != "")
                {
                    myparam[14] = ModHelper.CreateParameter("@Result_Broth_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, Result_Broth_Date);
                }
                else
                {
                    myparam[14] = ModHelper.CreateParameter("@Result_Broth_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DBNull.Value);
                }

                if (Result_Broth_Time != "")
                {
                    myparam[15] = ModHelper.CreateParameter("@Result_Broth_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, Result_Broth_Time);
                }
                else
                {
                    myparam[15] = ModHelper.CreateParameter("@Result_Broth_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, DBNull.Value);
                }
                if (Result_Agar_Date != "")
                {
                    myparam[16] = ModHelper.CreateParameter("@Result_Agar_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, Result_Agar_Date);
                }
                else
                {
                    myparam[16] = ModHelper.CreateParameter("@Result_Agar_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DBNull.Value);
                }

                if (Result_Agar_Time != "")
                {
                    myparam[17] = ModHelper.CreateParameter("@Result_Agar_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, Result_Agar_Time);
                }
                else
                {
                    myparam[17] = ModHelper.CreateParameter("@Result_Agar_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, DBNull.Value);
                }


                if (Result_Other_Date != "")
                {
                    myparam[18] = ModHelper.CreateParameter("@Result_Other_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, Result_Other_Date);
                }
                else
                {
                    myparam[18] = ModHelper.CreateParameter("@Result_Other_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DBNull.Value);
                }
                if (Result_Other_Time != "")
                {
                    myparam[19] = ModHelper.CreateParameter("@Result_Other_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, Result_Other_Time);
                }
                else
                {
                    myparam[19] = ModHelper.CreateParameter("@Result_Other_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, DBNull.Value);
                }
                myparam[20] = ModHelper.CreateParameter("@TotalTime_Broth", SqlDbType.VarChar, 50, ParameterDirection.Input, TotalTime_Broth);
                myparam[21] = ModHelper.CreateParameter("@TotalTime_Agar", SqlDbType.VarChar, 50, ParameterDirection.Input, TotalTime_Agar);
                myparam[22] = ModHelper.CreateParameter("@TotalTime_Other", SqlDbType.VarChar, 50, ParameterDirection.Input, TotalTime_Other);
                myparam[23] = ModHelper.CreateParameter("@Remarks_Broth", SqlDbType.VarChar, 250, ParameterDirection.Input, Remarks_Broth);
                myparam[24] = ModHelper.CreateParameter("@Remarks_Agar", SqlDbType.VarChar, 250, ParameterDirection.Input, Remarks_Agar);
                myparam[25] = ModHelper.CreateParameter("@Remarks_Other", SqlDbType.VarChar, 250, ParameterDirection.Input, Remarks_Other);
                myparam[26] = ModHelper.CreateParameter("@Status", SqlDbType.Char, 1, ParameterDirection.Input, microstatus);
                myparam[27] = ModHelper.CreateParameter("@BpcNonBpc", SqlDbType.Char, 1, ParameterDirection.Input, BpcNonBpc);
                myparam[28] = ModHelper.CreateParameter("@NonBpcComments", SqlDbType.VarChar, 250, ParameterDirection.Input, NonBpcComments);
                myparam[29] = ModHelper.CreateParameter("@Comment", SqlDbType.VarChar, 250, ParameterDirection.Input, comments);
                myparam[30] = ModHelper.CreateParameter("@MediaLotNo", SqlDbType.VarChar, 50, ParameterDirection.Input, medialotno);
                myparam[31] = ModHelper.CreateParameter("@SampleToRetainer", SqlDbType.Char, 1, ParameterDirection.Input, sampletoretainer);
                myparam[32] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, TLFID);
                myparam[33] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
                myparam[34] = ModHelper.CreateParameter("@InspectedBy", SqlDbType.Int, 4, ParameterDirection.Input, inspectedby);
                myparam[35] = ModHelper.CreateParameter("@MicroNo", SqlDbType.BigInt, 8, ParameterDirection.Output);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblMicrobiologytest_SubContract", myparam);
                //microno =Convert.ToInt64(myparam[35].Value);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblMicrobiologytest_SubContract_Status()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, TLFID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblMicrobiologytest_SubContract_Status", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Insert_tblFinishedGoodTestDetails_SubContract()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[22];
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
                myparam[13] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                myparam[14] = ModHelper.CreateParameter("@CurrentFlag", SqlDbType.Bit, 1, ParameterDirection.Input, currentflag);
                myparam[15] = ModHelper.CreateParameter("@Treatmented", SqlDbType.Bit, 1, ParameterDirection.Input, treatmented);
                myparam[16] = ModHelper.CreateParameter("@TreatmentDone", SqlDbType.Bit, 1, ParameterDirection.Input, treatmentdone);
                myparam[17] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
                myparam[18] = ModHelper.CreateParameter("@InspectedBy", SqlDbType.Int, 4, ParameterDirection.Input, inspectedby);
                myparam[19] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Output);
                myparam[20] = ModHelper.CreateParameter("@SupplierID", SqlDbType.BigInt, 8, ParameterDirection.Input, FGSupplierID);
                myparam[21] = ModHelper.CreateParameter("@BMRFilepath", SqlDbType.VarChar, 400, ParameterDirection.Input, bmrfilepath);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblFinishedGoodTestDetails_SubContract", myparam);

                fgtestno = Convert.ToInt32(myparam[19].Value);

                return fgtestno;
                //return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update_tblFinishedGoodTestDetails_SubContract()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[22];
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
                myparam[20] = ModHelper.CreateParameter("@SupplierID", SqlDbType.BigInt, 8, ParameterDirection.Input, FGSupplierID);
                myparam[21] = ModHelper.CreateParameter("@BMRFilepath", SqlDbType.VarChar, 400, ParameterDirection.Input, bmrfilepath);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblFinishedGoodTestDetails_SubContract", myparam);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update_tblFGTLF_FGDone_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                myparam[1] = ModHelper.CreateParameter("@FGDone", SqlDbType.Bit, 1, ParameterDirection.Input, fgdone);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblFGTLF_FGDone_SubContract", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update_tblTransFMFinishedGoods_SubContract_tblTransTLF_SubContract_Status()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblTransFMFinishedGoods_SubContract_tblTransTLF_SubContract_Status", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert_tblPkgSamp_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[22];
                myparam[0] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, TLFID);
                myparam[1] = ModHelper.CreateParameter("@BatchNo", SqlDbType.VarChar, 50, ParameterDirection.Input, batchno);
                myparam[2] = ModHelper.CreateParameter("@FillVolume", SqlDbType.VarChar, 50, ParameterDirection.Input, fillvolume);
                myparam[3] = ModHelper.CreateParameter("@FillDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, filldate);
                myparam[4] = ModHelper.CreateParameter("@InspDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, inspdate);
                myparam[5] = ModHelper.CreateParameter("@PkgWO", SqlDbType.NVarChar, 200, ParameterDirection.Input, pkgwo);
                myparam[6] = ModHelper.CreateParameter("@Price", SqlDbType.NVarChar, 50, ParameterDirection.Input, price);
                myparam[7] = ModHelper.CreateParameter("@specification", SqlDbType.VarChar, 50, ParameterDirection.Input, Specification);
                myparam[8] = ModHelper.CreateParameter("@ProddecFP", SqlDbType.Char, 1, ParameterDirection.Input, proddecfp);
                myparam[9] = ModHelper.CreateParameter("@ProddecSF", SqlDbType.Char, 1, ParameterDirection.Input, proddecsf);
                myparam[10] = ModHelper.CreateParameter("@CommentsSF", SqlDbType.NVarChar, 250, ParameterDirection.Input, commentssf);
                myparam[11] = ModHelper.CreateParameter("@ProddecWIP", SqlDbType.Char, 1, ParameterDirection.Input, proddecwip);
                myparam[12] = ModHelper.CreateParameter("@AOCPend", SqlDbType.Char, 1, ParameterDirection.Input, aocPend);
                myparam[13] = ModHelper.CreateParameter("@CommentsAOC", SqlDbType.NVarChar, 250, ParameterDirection.Input, commentsaoc);
                myparam[14] = ModHelper.CreateParameter("@Status", SqlDbType.Char, 1, ParameterDirection.Input, packingstatus);
                myparam[15] = ModHelper.CreateParameter("@Comments", SqlDbType.NVarChar, 250, ParameterDirection.Input, comments);
                myparam[16] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
                myparam[17] = ModHelper.CreateParameter("@InspectedBy", SqlDbType.Int, 4, ParameterDirection.Input, inspectedby);
                if (locationid == 0)
                {
                    myparam[18] = ModHelper.CreateParameter("@LocationID", SqlDbType.BigInt, 8, ParameterDirection.Input, System.DBNull.Value);
                }
                else
                {
                    myparam[18] = ModHelper.CreateParameter("@LocationID", SqlDbType.BigInt, 8, ParameterDirection.Input, locationid);
                }
                myparam[19] = ModHelper.CreateParameter("@FormulaType", SqlDbType.VarChar, 50, ParameterDirection.Input, formulatype);
                myparam[20] = ModHelper.CreateParameter("@FlagRL", SqlDbType.Char, 1, ParameterDirection.Input, flagrl);
                myparam[21] = ModHelper.CreateParameter("@BPCNONBPC", SqlDbType.Char, 1, ParameterDirection.Input, decision);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblPkgSamp_SubContract", myparam);
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_ModificationFinishedGoodDetails_SubContract()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_ModificationFinishedGoodDetails_SubContract");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_FinishedGood_FGDetails_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_FinishedGood_FGDetails_SubContract", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert_tblLinkTLF_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                myparam[1] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, TLFID);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblLinkTLF_SubContract", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_FinishedGood_PackingBulkTestDetails_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_FinishedGood_PackingBulkTestDetails_SubContract", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_ModificationFinishedGoodDetails_Details_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_ModificationFinishedGoodDetails_Details_SubContract", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_Protocol_FGPackingDetails_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_Protocol_FGPackingDetails_SubContract", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_Protocol_FGPackingDetails_PhyChe_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                myparam[1] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_Protocol_FGPackingDetails_PhyChe_SubContract", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_CheckPreservativeTest()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];                
                myparam[0] = ModHelper.CreateParameter("@Fno", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "SPT_CheckPreservativeTest", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblPreservativetest_SubContract_Status()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblPreservativetest_SubContract_Status", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_COC_Subcontractor()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@Supplierid", SqlDbType.BigInt, 8, ParameterDirection.Input, FGSupplierID);
                myparam[1] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_COC_Subcontractor", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update_RetainerLocation_Subcontract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                
                if (locationid == 0)
                {
                    myparam[1] = ModHelper.CreateParameter("@LocationID", SqlDbType.BigInt, 8, ParameterDirection.Input, System.DBNull.Value);
                }
                else
                {
                    myparam[1] = ModHelper.CreateParameter("@LocationID", SqlDbType.BigInt, 8, ParameterDirection.Input, locationid);
                }
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_RetainerLocation_Subcontract", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
