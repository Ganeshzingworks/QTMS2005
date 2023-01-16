using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;
namespace BusinessFacade.Transactions
{
    public class LineSamplePackingDetails_Class
    {
        # region Varibles
        private int LoginID;
        private long FMID;
        private string TestDate;
        private string FormulaNo;
        private long LineSampleNo;
        private string MfgWO;
        private string InspDate;
        private string BatchNo;
        private int LNo;
        private long FGCode;
        private string PkgWO;
        private string Price;
        private string FillVolume;
        private string specification;
        private char ProddecFP;
        private char ProddecSF;
        private string CommentsSF;
        private char ProddecWIP;
        private char AOCPend;
        private string CommentsAOC;
        private char FDA;
        private char Controltype;
        private char Status;
        private string Comments;
        private string sourceref;
        private string Transid;
        private long PkgSampNo;
        private string FromDate;
        private string ToDate;
        private long FNo;
        private string TrackCode;
        private long FGNo;
        private long TLFID;
        private long FGTLFID;
        private string FillDate;
        private int KitFlag;
        private bool LinePkgDone;
        private long LocationID;
        private int InspectedBy;
        private int SFFlag;
        private int VerifiedBy;
        private int Colorant;
        private int Developer;
        private int SF;
        private int FG;
        private int Other;
        # endregion

        # region Properties

        public int other
        {
            get { return Other; }
            set { Other = value; }
        }
        public int fg
        {
            get { return FG; }
            set { FG = value; }
        }
        public int sf
        {
            get { return SF; }
            set { SF = value; }
        }
        public int developer
        {
            get { return Developer; }
            set { Developer = value; }
        }
        public int colorant
        {
            get { return Colorant; }
            set { Colorant = value; }
        }

        public int verifiedby
        {
            get { return VerifiedBy; }
            set { VerifiedBy = value; }
        }
        public int sfflag
        {
            get { return SFFlag; }
            set { SFFlag = value; }
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
        public long fmid
        {
            get { return FMID; }
            set { FMID = value; }
        }
        public long fno
        {
            get { return FNo; }
            set { FNo = value; }
        }
        public string testdate
        {
            get { return TestDate; }
            set { TestDate = value; }
        }
        public long pkgsampno
        {
            get { return PkgSampNo; }
            set { PkgSampNo = value; }
        }
        public string commentsaoc
        {
            get { return CommentsAOC; }
            set { CommentsAOC = value; }
        }
        public string commentssf
        {
            get { return CommentsSF; }
            set { CommentsSF = value; }
        }
        public string transid
        {
            get { return Transid; }
            set { Transid = value; }
        }
        public string Sourceref
        {
            get { return sourceref; }
            set { sourceref = value; }
        }
        public string comments
        {
            get { return Comments; }
            set { Comments = value; }
        }
        public char status
        {
            get { return Status; }
            set { Status = value; }
        }
        public char controltype
        {
            get { return Controltype; }
            set { Controltype = value; }
        }
        public char fda
        {
            get { return FDA; }
            set { FDA = value; }
        }
        public char proddecwip
        {
            get { return ProddecWIP; }
            set { ProddecWIP = value; }
        }
        public char aocPend
        {
            get { return AOCPend; }
            set { AOCPend = value; }
        }
        public char proddecsf
        {
            get { return ProddecSF; }
            set { ProddecSF = value; }
        }
        public char proddecfp
        {
            get { return ProddecFP; }
            set { ProddecFP = value; }
        }
        public string Specification
        {
            get { return specification; }
            set { specification = value; }
        }
        public string fillvolume
        {
            get { return FillVolume; }
            set { FillVolume = value; }
        }
        public string price
        {
            get { return Price; }
            set { Price = value; }
        }
        public string pkgwo
        {
            get { return PkgWO; }
            set { PkgWO = value; }
        }
        public long fgcode
        {
            get { return FGCode; }
            set { FGCode = value; }
        }
        public int lno
        {
            get { return LNo; }
            set { LNo = value; }
        }
        public string batchno
        {
            get { return BatchNo; }
            set { BatchNo = value; }
        }
        public string inspdate
        {
            get { return InspDate; }
            set { InspDate = value; }
        }
        public string mfgwo
        {
            get { return MfgWO; }
            set { MfgWO = value; }
        }
        public string formulano
        {
            get { return FormulaNo; }
            set { FormulaNo = value; }
        }
        public long linesampleno
        {
            get { return LineSampleNo; }
            set { LineSampleNo = value; }
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
        public string trackcode
        {
            get { return TrackCode; }
            set { TrackCode = value; }
        }
        public long fgno
        {
            get { return FGNo; }
            set { FGNo = value; }
        }
        public long tlfid
        {
            get { return TLFID; }
            set { TLFID = value; }
        }
        public long fgtlfid
        {
            get { return FGTLFID; }
            set { FGTLFID = value; }
        }
        public string filldate
        {
            get { return FillDate; }
            set { FillDate = value; }
        }
        public int kitflag
        {
            get { return KitFlag; }
            set { KitFlag = value; }
        }
        public bool linepkgdone
        {
            get { return LinePkgDone; }
            set { LinePkgDone = value; }
        }
        public long locationid
        {
            get { return LocationID; }
            set { LocationID = value; }
        }
        #endregion

        # region Functions

        public DataSet Select_PendingLinePackingDetails()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_PendingLinePackingDetails", param);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_ModificationLinePackingDetails(DateTime dtFrom, DateTime dtTo)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, dtFrom.ToShortDateString());
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, dtTo.ToShortDateString());
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_ModificationLinePackingDetails", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_ModificationLinePackingDetails_Details()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("TLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, tlfid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_ModificationLinePackingDetails_Details", param);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet Select_tblFGMaster_FGCode_FNo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblFGMaster_FGCode_FNo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SELECT_tblFM_MfgWo_FormulaNo()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblFM_MfgWo_FormulaNo");

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete_tblPkgSamp()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, tlfid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblPkgSamp", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete_tblTransTLF()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, tlfid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblTransTLF", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete_tblLinkTLF()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, tlfid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblLinkTLF", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete_tblFGTLF_TLFID()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, tlfid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblFGTLF_TLFID", myparam);
                return true;
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
                SqlParameter[] myparam = new SqlParameter[25];
                myparam[0] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, tlfid);
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
                myparam[14] = ModHelper.CreateParameter("@Status", SqlDbType.Char, 1, ParameterDirection.Input, status);
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
                myparam[19] = ModHelper.CreateParameter("@VerifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, verifiedby);

                if (developer == -1)
                {
                    myparam[20] = ModHelper.CreateParameter("@Colorant", SqlDbType.Int, 4, ParameterDirection.Input, System.DBNull.Value);
                    myparam[21] = ModHelper.CreateParameter("@Developer", SqlDbType.Int, 4, ParameterDirection.Input, System.DBNull.Value);
                    myparam[22] = ModHelper.CreateParameter("@SF", SqlDbType.Int, 4, ParameterDirection.Input, System.DBNull.Value);
                    myparam[23] = ModHelper.CreateParameter("@FG", SqlDbType.Int, 4, ParameterDirection.Input, System.DBNull.Value);
                    myparam[24] = ModHelper.CreateParameter("@Other", SqlDbType.Int, 4, ParameterDirection.Input, System.DBNull.Value);
                }
                else
                {
                    if (colorant == 0)
                        myparam[20] = ModHelper.CreateParameter("@Colorant", SqlDbType.Int, 4, ParameterDirection.Input, System.DBNull.Value);
                    else
                        myparam[20] = ModHelper.CreateParameter("@Colorant", SqlDbType.Int, 4, ParameterDirection.Input, colorant);
                    if (developer == 0)
                        myparam[21] = ModHelper.CreateParameter("@Developer", SqlDbType.Int, 4, ParameterDirection.Input, System.DBNull.Value);
                    else
                        myparam[21] = ModHelper.CreateParameter("@Developer", SqlDbType.Int, 4, ParameterDirection.Input, developer);
                    if (sf == 0)
                        myparam[22] = ModHelper.CreateParameter("@SF", SqlDbType.Int, 4, ParameterDirection.Input, System.DBNull.Value);
                    else
                        myparam[22] = ModHelper.CreateParameter("@SF", SqlDbType.Int, 4, ParameterDirection.Input, sf);
                    if (fg == 0)
                        myparam[23] = ModHelper.CreateParameter("@FG", SqlDbType.Int, 4, ParameterDirection.Input, System.DBNull.Value);
                    else
                        myparam[23] = ModHelper.CreateParameter("@FG", SqlDbType.Int, 4, ParameterDirection.Input, fg);
                    if (other == 0)
                        myparam[24] = ModHelper.CreateParameter("@Other", SqlDbType.Int, 4, ParameterDirection.Input, System.DBNull.Value);
                    else
                        myparam[24] = ModHelper.CreateParameter("@Other", SqlDbType.Int, 4, ParameterDirection.Input, other);
                }
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblPkgSamp", myparam);
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert_tblPkgSamp()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[25];
                myparam[0] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, tlfid);
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
                myparam[14] = ModHelper.CreateParameter("@Status", SqlDbType.Char, 1, ParameterDirection.Input, status);
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
                myparam[19] = ModHelper.CreateParameter("@VerifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, verifiedby);
                if (developer == -1)
                {
                    myparam[20] = ModHelper.CreateParameter("@Colorant", SqlDbType.Int, 4, ParameterDirection.Input, System.DBNull.Value);
                    myparam[21] = ModHelper.CreateParameter("@Developer", SqlDbType.Int, 4, ParameterDirection.Input, System.DBNull.Value);
                    myparam[22] = ModHelper.CreateParameter("@SF", SqlDbType.Int, 4, ParameterDirection.Input, System.DBNull.Value);
                    myparam[23] = ModHelper.CreateParameter("@FG", SqlDbType.Int, 4, ParameterDirection.Input, System.DBNull.Value);
                    myparam[24] = ModHelper.CreateParameter("@Other", SqlDbType.Int, 4, ParameterDirection.Input, System.DBNull.Value);
                }
                else
                {
                    if (colorant == 0)
                        myparam[20] = ModHelper.CreateParameter("@Colorant", SqlDbType.Int, 4, ParameterDirection.Input, System.DBNull.Value);
                    else
                        myparam[20] = ModHelper.CreateParameter("@Colorant", SqlDbType.Int, 4, ParameterDirection.Input, colorant);
                    if (developer == 0)
                        myparam[21] = ModHelper.CreateParameter("@Developer", SqlDbType.Int, 4, ParameterDirection.Input, System.DBNull.Value);
                    else
                        myparam[21] = ModHelper.CreateParameter("@Developer", SqlDbType.Int, 4, ParameterDirection.Input, developer);
                    if (sf == 0)
                        myparam[22] = ModHelper.CreateParameter("@SF", SqlDbType.Int, 4, ParameterDirection.Input, System.DBNull.Value);
                    else
                        myparam[22] = ModHelper.CreateParameter("@SF", SqlDbType.Int, 4, ParameterDirection.Input, sf);
                    if (fg == 0)
                        myparam[23] = ModHelper.CreateParameter("@FG", SqlDbType.Int, 4, ParameterDirection.Input, System.DBNull.Value);
                    else
                        myparam[23] = ModHelper.CreateParameter("@FG", SqlDbType.Int, 4, ParameterDirection.Input, fg);
                    if (other == 0)
                        myparam[24] = ModHelper.CreateParameter("@Other", SqlDbType.Int, 4, ParameterDirection.Input, System.DBNull.Value);
                    else
                        myparam[24] = ModHelper.CreateParameter("@Other", SqlDbType.Int, 4, ParameterDirection.Input, other);
                }
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblPkgSamp", myparam);
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Insert_tblTransTLF()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[7];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                myparam[1] = ModHelper.CreateParameter("@TrackCode", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, trackcode);
                myparam[2] = ModHelper.CreateParameter("@LNo", SqlDbType.BigInt, 8, ParameterDirection.Input, lno);
                myparam[3] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                myparam[4] = ModHelper.CreateParameter("@KitFlag", SqlDbType.Bit, 1, ParameterDirection.Input, kitflag);
                myparam[5] = ModHelper.CreateParameter("@SFFlag", SqlDbType.Bit, 1, ParameterDirection.Input, sfflag);
                myparam[6] = ModHelper.CreateParameter("@TLFID", SqlDbType.VarChar, 50, ParameterDirection.Output, tlfid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblTransTLF", myparam);

                return Convert.ToInt64(myparam[6].Value);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Insert_tblFGTLF()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[11];
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
                myparam[10] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.VarChar, 50, ParameterDirection.Output, fgtlfid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblFGTLF", myparam);

                return Convert.ToInt64(myparam[10].Value);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblLinkTLF()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                myparam[1] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, tlfid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblLinkTLF", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert_tblLinkTLF()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                myparam[1] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, tlfid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblLinkTLF", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update_tblFGTLF_TLFID()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[8];
                myparam[0] = ModHelper.CreateParameter("@FillDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, filldate);
                myparam[1] = ModHelper.CreateParameter("@PkgWO", SqlDbType.NVarChar, 200, ParameterDirection.Input, pkgwo);
                myparam[2] = ModHelper.CreateParameter("@Price", SqlDbType.NVarChar, 50, ParameterDirection.Input, price);
                myparam[3] = ModHelper.CreateParameter("@specification", SqlDbType.VarChar, 50, ParameterDirection.Input, specification);
                myparam[4] = ModHelper.CreateParameter("@AOCPend", SqlDbType.Char, 1, ParameterDirection.Input, aocPend);
                myparam[5] = ModHelper.CreateParameter("@CommentsAOC", SqlDbType.NVarChar, 250, ParameterDirection.Input, commentsaoc);
                myparam[6] = ModHelper.CreateParameter("@BatchNo", SqlDbType.VarChar, 50, ParameterDirection.Input, batchno);
                myparam[7] = ModHelper.CreateParameter("@TLFID", SqlDbType.VarChar, 50, ParameterDirection.Input, tlfid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblFGTLF_TLFID", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update_tblTransTLF_LinePkgDone()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, tlfid);
                myparam[1] = ModHelper.CreateParameter("@LinePkgDone", SqlDbType.Bit, 1, ParameterDirection.Input, linepkgdone);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblTransTLF_LinePkgDone", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update_tblTransTLF_KitFlag_SFFlag()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, tlfid);
                myparam[1] = ModHelper.CreateParameter("@KitFlag", SqlDbType.Bit, 1, ParameterDirection.Input, kitflag);
                myparam[2] = ModHelper.CreateParameter("@SFFlag", SqlDbType.Bit, 1, ParameterDirection.Input, sfflag);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblTransTLF_KitFlag_SFFlag", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblTransTLF_FMTLF()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                myparam[1] = ModHelper.CreateParameter("@TrackCode", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, trackcode);
                myparam[2] = ModHelper.CreateParameter("@LNo", SqlDbType.BigInt, 8, ParameterDirection.Input, lno);
                myparam[3] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblTransTLF_FMTLF", myparam);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblFGTLF_TLF()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@TrackCode", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, trackcode);
                myparam[1] = ModHelper.CreateParameter("@LNo", SqlDbType.BigInt, 8, ParameterDirection.Input, lno);
                myparam[2] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblFGTLF_TLF", myparam);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        # endregion
    }
}
