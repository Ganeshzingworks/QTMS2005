using System;
using System.Collections.Generic;
using System.Text;
using DataFacade;
using System.Data;
using System.Data.SqlClient; 
namespace BusinessFacade.Transactions
{
    public class DyeKit_Class
    {
        private long FGCode;
        public long fgcode
        {
            get { return FGCode; }
            set { FGCode = value; }
        }
        private long FGNo;
        public long fgno
        {
            get { return FGNo; }
            set { FGNo = value; }
        }
        private long FGNoKit;
        public long fgnokit
        {
            get { return FGNoKit; }
            set { FGNoKit = value; }
        }
        private long TLFID;
        public long tlfid
        {
            get { return TLFID; }
            set { TLFID = value; }
        }
        private long FGTLFID;
        public long fgtlfid
        {
            get { return FGTLFID; }
            set { FGTLFID = value; }
        }
        private long KitFGTLFID;

        public long kitfgtlfid
        {
            get { return KitFGTLFID; }
            set { KitFGTLFID = value; }
        }
	
        private string FillDateFG;
        public string filldatefg
        {
            get { return FillDateFG; }
            set { FillDateFG = value; }
        }
        private long FMID;
        public long fmid
        {
            get { return FMID; }
            set { FMID = value; }
        }
        private long FNo;
        public long fno
        {
            get { return FNo; }
            set { FNo = value; }
        }
        private string CommentsAOCFG;
        public string commentsaocfg
        {
            get { return CommentsAOCFG; }
            set { CommentsAOCFG = value; }
        }
        private string CommentsFG;
        public string commentsfg
        {
            get { return CommentsFG; }
            set { CommentsFG = value; }
        }
        private string BatchNoFG;
        public string batchnofg
        {
            get { return BatchNoFG; }
            set { BatchNoFG = value; }
        }
        private char StatusFG;
        public char statusfg
        {
            get { return StatusFG; }
            set { StatusFG = value; }
        }
        private char AOCPendFG;
        public char aocPendfg
        {
            get { return AOCPendFG; }
            set { AOCPendFG = value; }
        }
        private string SpecificationFG;
        public string specificationfg
        {
            get { return SpecificationFG; }
            set { SpecificationFG = value; }
        }
        private string PriceFG;
        public string pricefg
        {
            get { return PriceFG; }
            set { PriceFG = value; }
        }
        private string PkgWOFG;
        public string pkgwofg
        {
            get { return PkgWOFG; }
            set { PkgWOFG = value; }
        }
        private int LNoFG;
        public int lnofg
        {
            get { return LNoFG; }
            set { LNoFG = value; }
        }
        private string MfgWO;
        public string mfgwo
        {
            get { return MfgWO; }
            set { MfgWO = value; }
        }
        private string TrackCodeFG;
        public string trackcodefg
        {
            get { return TrackCodeFG; }
            set { TrackCodeFG = value; }
        }
        private int SFFlag;

        public int sfflag
        {
            get { return SFFlag; }
            set { SFFlag = value; }
        }
        private string fgCodeFG;

        public string fgcodefg
        {
            get { return fgCodeFG; }
            set { fgCodeFG = value; }
        }

        private string LineDesc;

        public string linedesc
        {
            get { return LineDesc; }
            set { LineDesc = value; }
        }
	
        public DataSet Select_PendingKitDetails()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_PendingKitDetails");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_SFDetails()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_SFDetails");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_ModificationKitDetails()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_ModificationKitDetails");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_Formula_MfgWo_Kit()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgnokit);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_Formula_MfgWo_Kit", param);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_Formula_MfgWo_Kit_Subcontractor()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgnokit);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_Formula_MfgWo_Kit_Subcontractor", param);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_Formula_MfgWo_SF()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgnokit);
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_Formula_MfgWo_SF", param).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_FGCode_SF()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgnokit);
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_FGCode_SF", param).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }              

        public DataSet Select_tblLinkTLF_FGTLFID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblLinkTLF_FGTLFID", param);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblLinkTLF_FGTLFID_SubContractor()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblLinkTLF_FGTLFID_SubContractor", param);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // This is used for to check sfflag assigned for kit mfgwo
        public DataTable Select_tblLinkTLF_FGTLFID_SFFlag()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblLinkTLF_FGTLFID_SFFlag", param).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SELECT_tblFgMaster_FormulaNo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgnokit);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblFgMaster_FormulaNo", param);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }   

        public bool Update_Kit_tblPkgSamp_Details()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[7];
                param[0] = ModHelper.CreateParameter("@FillDateFG", SqlDbType.SmallDateTime, 8, ParameterDirection.Input, filldatefg);
                param[1] = ModHelper.CreateParameter("@PkgWOFG", SqlDbType.NVarChar,200, ParameterDirection.Input, pkgwofg);
                param[2] = ModHelper.CreateParameter("@PriceFG", SqlDbType.NVarChar, 50, ParameterDirection.Input, pricefg);
                param[3] = ModHelper.CreateParameter("@SpecificationFG", SqlDbType.VarChar, 50, ParameterDirection.Input, specificationfg);
                param[4] = ModHelper.CreateParameter("@AOCPendFG", SqlDbType.Char, 1, ParameterDirection.Input, aocPendfg);
                param[5] = ModHelper.CreateParameter("@CommentsAOCFG", SqlDbType.NVarChar, 250, ParameterDirection.Input, commentsaocfg);
                //param[6] = ModHelper.CreateParameter("@StatusFG", SqlDbType.Char,1 , ParameterDirection.Input, statusfg);
                //param[7] = ModHelper.CreateParameter("@CommentsFG", SqlDbType.NVarChar, 250, ParameterDirection.Input, commentsfg);                              
                param[6] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, tlfid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_Kit_tblPkgSamp_Details", param);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;                
            }
        }
        // Update SFFlag from kit details
        public void Update_tblTransTLF_SFFlag()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, tlfid);
                myparam[1] = ModHelper.CreateParameter("@SFFlag", SqlDbType.BigInt, 8, ParameterDirection.Input, sfflag);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblTransTLF_SFFlag", myparam);
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
                myparam[0] = ModHelper.CreateParameter("@TrackCode", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, trackcodefg);
                myparam[1] = ModHelper.CreateParameter("@LNo", SqlDbType.BigInt, 8, ParameterDirection.Input, lnofg);
                myparam[2] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgnokit);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblFGTLF_TLF", myparam);

                return ds;
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
                myparam[0] = ModHelper.CreateParameter("@TrackCode", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, trackcodefg);
                myparam[1] = ModHelper.CreateParameter("@LNo", SqlDbType.BigInt, 8, ParameterDirection.Input, lnofg);
                myparam[2] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgnokit);
                myparam[3] = ModHelper.CreateParameter("@FillDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, filldatefg);
                myparam[4] = ModHelper.CreateParameter("@PkgWO", SqlDbType.NVarChar, 200, ParameterDirection.Input, pkgwofg);
                myparam[5] = ModHelper.CreateParameter("@Price", SqlDbType.NVarChar, 50, ParameterDirection.Input, pricefg);
                myparam[6] = ModHelper.CreateParameter("@specification", SqlDbType.VarChar, 50, ParameterDirection.Input, specificationfg);
                myparam[7] = ModHelper.CreateParameter("@AOCPend", SqlDbType.Char, 1, ParameterDirection.Input, aocPendfg);
                myparam[8] = ModHelper.CreateParameter("@CommentsAOC", SqlDbType.NVarChar, 250, ParameterDirection.Input, commentsaocfg);
                myparam[9] = ModHelper.CreateParameter("@BatchNo", SqlDbType.VarChar, 50, ParameterDirection.Input, batchnofg);
                myparam[10] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.VarChar, 50, ParameterDirection.Output, fgtlfid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblFGTLF", myparam);

                return Convert.ToInt64(myparam[10].Value);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update_tblFGTLF()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[9];                
                myparam[1] = ModHelper.CreateParameter("@FillDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, filldatefg);
                myparam[2] = ModHelper.CreateParameter("@PkgWO", SqlDbType.NVarChar, 200, ParameterDirection.Input, pkgwofg);
                myparam[3] = ModHelper.CreateParameter("@Price", SqlDbType.NVarChar, 50, ParameterDirection.Input, pricefg);
                myparam[4] = ModHelper.CreateParameter("@specification", SqlDbType.VarChar, 50, ParameterDirection.Input, specificationfg);
                myparam[5] = ModHelper.CreateParameter("@AOCPend", SqlDbType.Char, 1, ParameterDirection.Input, aocPendfg);
                myparam[6] = ModHelper.CreateParameter("@CommentsAOC", SqlDbType.NVarChar, 250, ParameterDirection.Input, commentsaocfg);
                myparam[7] = ModHelper.CreateParameter("@BatchNo", SqlDbType.VarChar, 50, ParameterDirection.Input, batchnofg);
                myparam[8] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.VarChar, 50, ParameterDirection.Input, fgtlfid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblFGTLF", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete_tblFGTLF_FGTLFID()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblFGTLF_FGTLFID", myparam);
                return true;
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

        public void Insert_tblLinkTLF_Sub()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                myparam[1] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, tlfid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblLinkTLF_SubContractor_Kit", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
 
        public void Insert_tblLinkSF()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                myparam[1] = ModHelper.CreateParameter("@TLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, tlfid);
                myparam[2] = ModHelper.CreateParameter("@KitFGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, kitfgtlfid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblLinkSF", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete_tblLinkTLF_FGTLFID()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);                
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblLinkTLF_FGTLFID", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        //show fgcode trackcode lineno of sf modification
        

        public DataSet Select_ModificationSFDetails()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_ModificationSFDetails");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // show sf modification details of fgcode
        public DataSet Select_tblLinkSF_FGTLFID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblLinkSF_FGTLFID", param);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // Tick in sf modification details of fgcode 
        public DataSet Select_tblLinkSF_tblTransTLF_MarkFGCode()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                //param[1] = ModHelper.CreateParameter("@FGCode", SqlDbType.VarChar, 255, ParameterDirection.Input, fgCodeFG);
                //param[2] = ModHelper.CreateParameter("@TrackCode", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, trackcodefg);
                //param[3] = ModHelper.CreateParameter("@LineDesc", SqlDbType.VarChar, 255, ParameterDirection.Input, linedesc);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblLinkSF_FGTLFID_MarkFGCode", param);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // Tick in sf modification details of fgcode for kit product 
        public DataSet Select_tblLinkSF_tblFGTLF_MarkFGCode()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                //param[1] = ModHelper.CreateParameter("@FGCode", SqlDbType.VarChar, 255, ParameterDirection.Input, fgCodeFG);
                //param[2] = ModHelper.CreateParameter("@TrackCodeFG", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, trackcodefg);
                //param[3] = ModHelper.CreateParameter("@LineDesc", SqlDbType.VarChar, 255, ParameterDirection.Input, linedesc);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblLinkSF_tblFGTLF_MarkFGCode", param);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // Delete ids in tblLinkSF 
        public void Delete_tblLinkSF_FGTLFID()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblLinkSF_FGTLFID", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
