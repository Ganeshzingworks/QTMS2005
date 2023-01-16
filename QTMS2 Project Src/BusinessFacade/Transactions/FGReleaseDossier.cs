using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;

namespace BusinessFacade.Transactions
{
    public class FGReleaseDossier
    {
        private long FNo;
        public long fno
        {
            get { return FNo; }
            set { FNo = value; }
        }
        private string MfgWo;
        public string mfgwo
        {
            get { return MfgWo; }
            set { MfgWo = value; }
        }
        private string OffRefNo;
        public string offrefno
        {
            get { return OffRefNo; }
            set { OffRefNo = value; }
        }
        private string OffPIFRef;
        public string offpifref
        {
            get { return OffPIFRef; }
            set { OffPIFRef = value; }
        }
        private string OffKITRef;
        public string offkitref
        {
            get { return OffKITRef; }
            set { OffKITRef = value; }
        }
        private long FMID;
        public long fmid
        {
            get { return FMID; }
            set { FMID = value; }
        }
        private string ReceivedFrom;
        public string receivedfrom
        {
            get { return ReceivedFrom; }
            set { ReceivedFrom = value; }
        }
        private string ReceivedOn;
        public string receivedon
        {
            get { return ReceivedOn; }
            set { ReceivedOn = value; }
        }
        private string LotNo;
        public string lotno
        {
            get { return LotNo; }
            set { LotNo = value; }
        }
        private string ValidityDate;
        public string validitydate
        {
            get { return ValidityDate; }
            set { ValidityDate = value; }
        }
        private string AOCApprovalDate;
        public string aocapprovaldate
        {
            get { return AOCApprovalDate; }
            set { AOCApprovalDate = value; }
        }
        private string IntranetRecordDate;
        public string intranetrecorddate
        {
            get { return IntranetRecordDate; }
            set { IntranetRecordDate = value; }
        }
        private bool RAD;
        public bool rad
        {
            get { return RAD; }
            set { RAD = value; }
        }
        private char Production;
        public char production
        {
            get { return Production; }
            set { Production = value; }
        }
        private string Comments;
        public string comments
        {
            get { return Comments; }
            set { Comments = value; }
        }
        private long LoginID;
        public long loginid
        {
            get { return LoginID; }
            set { LoginID = value; }
        }
        private long FPID;
        public long fpid
        {
            get { return FPID; }
            set { FPID = value; }
        }
        private string _FormulationApproved;
        public string FormulationApproved
        {
            get { return _FormulationApproved; }
            set { _FormulationApproved = value; }
        }
        private bool _RandI;
        public bool RandI
        { 
            get { return _RandI; }
            set { _RandI = value; }
        }
        private string _RandIApprovalDate;
        public string RandIApprovalDate
        {
            get { return _RandIApprovalDate; }
            set { _RandIApprovalDate = value; }
        }
        private char _Status;
        public char Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        public DataSet Select_View_BMR_Report_FNo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_BMR_Report_FNo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_BMR_Report_BulkPFDetails()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[1] = ModHelper.CreateParameter("@MfgWo", SqlDbType.VarChar, 200, ParameterDirection.Input, mfgwo);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_BMR_Report_BulkPFDetails", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblFPRelease_FNo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblFPRelease_FNo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblFPReleaseDetails_FPID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FPID", SqlDbType.BigInt, 8, ParameterDirection.Input, fpid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblFPReleaseDetails_FPID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Insert_tblFPRelease()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[17];
                myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[1] = ModHelper.CreateParameter("@OffRefNo", SqlDbType.VarChar, 50, ParameterDirection.Input, offrefno);
                myparam[2] = ModHelper.CreateParameter("@OffPIFRef", SqlDbType.VarChar, 50, ParameterDirection.Input, offpifref);
                myparam[3] = ModHelper.CreateParameter("@OffKITRef", SqlDbType.VarChar, 50, ParameterDirection.Input, offkitref);
                myparam[4] = ModHelper.CreateParameter("@ReceivedFrom", SqlDbType.VarChar, 50, ParameterDirection.Input, receivedfrom);
                myparam[5] = ModHelper.CreateParameter("@ReceivedOn", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, receivedon);
                myparam[6] = ModHelper.CreateParameter("@LotNo", SqlDbType.VarChar, 50, ParameterDirection.Input, lotno);
                myparam[7] = ModHelper.CreateParameter("@ValidityDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, validitydate);
                myparam[8] = ModHelper.CreateParameter("@AOCApprovalDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, aocapprovaldate);
                myparam[9] = ModHelper.CreateParameter("@IntranetRecordDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, intranetrecorddate);
                myparam[10] = ModHelper.CreateParameter("@Comments", SqlDbType.VarChar, 200, ParameterDirection.Input, comments);
                myparam[11] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
                myparam[12] = ModHelper.CreateParameter("@FPID", SqlDbType.BigInt, 8, ParameterDirection.Output, fpid);
                myparam[13] = ModHelper.CreateParameter("@FormulationApproved", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, FormulationApproved);
                myparam[14] = ModHelper.CreateParameter("@RandI",SqlDbType.Bit,1,ParameterDirection.Input,RandI);
                myparam[15] = ModHelper.CreateParameter("@RandIApprovalDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, RandIApprovalDate);
                myparam[16] = ModHelper.CreateParameter("@Status", SqlDbType.Char, 1, ParameterDirection.Input, Status);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblFPRelease", myparam);
                return Convert.ToInt64(myparam[12].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update_tblFPRelease()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[17];
                myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[1] = ModHelper.CreateParameter("@OffRefNo", SqlDbType.VarChar, 50, ParameterDirection.Input, offrefno);
                myparam[2] = ModHelper.CreateParameter("@OffPIFRef", SqlDbType.VarChar, 50, ParameterDirection.Input, offpifref);
                myparam[3] = ModHelper.CreateParameter("@OffKITRef", SqlDbType.VarChar, 50, ParameterDirection.Input, offkitref);
                myparam[4] = ModHelper.CreateParameter("@ReceivedFrom", SqlDbType.VarChar, 50, ParameterDirection.Input, receivedfrom);
                myparam[5] = ModHelper.CreateParameter("@ReceivedOn", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, receivedon);
                myparam[6] = ModHelper.CreateParameter("@LotNo", SqlDbType.VarChar, 50, ParameterDirection.Input, lotno);
                myparam[7] = ModHelper.CreateParameter("@ValidityDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, validitydate);
                myparam[8] = ModHelper.CreateParameter("@AOCApprovalDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, aocapprovaldate);
                myparam[9] = ModHelper.CreateParameter("@IntranetRecordDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, intranetrecorddate);
                myparam[10] = ModHelper.CreateParameter("@Comments", SqlDbType.VarChar, 200, ParameterDirection.Input, comments);
                myparam[11] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
                myparam[12] = ModHelper.CreateParameter("@FPID", SqlDbType.BigInt, 8, ParameterDirection.Input, fpid);
                myparam[13] = ModHelper.CreateParameter("@FormulationApproved", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, FormulationApproved);
                myparam[14] = ModHelper.CreateParameter("@RandI", SqlDbType.Bit, 1, ParameterDirection.Input, RandI);
                myparam[15] = ModHelper.CreateParameter("@RandIApprovalDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, RandIApprovalDate);
                myparam[16] = ModHelper.CreateParameter("@Status", SqlDbType.Char, 1, ParameterDirection.Input, Status);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblFPRelease", myparam);                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert_tblFPReleaseDetails()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@FPID", SqlDbType.BigInt, 8, ParameterDirection.Input, fpid);
                myparam[1] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                myparam[2] = ModHelper.CreateParameter("@RAD", SqlDbType.Bit, 1, ParameterDirection.Input, rad);
                myparam[3] = ModHelper.CreateParameter("@Production", SqlDbType.Char, 1, ParameterDirection.Input, production);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblFPReleaseDetails", myparam);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete_tblFPReleaseDetails()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FPID", SqlDbType.BigInt, 8, ParameterDirection.Input, fpid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblFPReleaseDetails", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete_tblFPRelease()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblFPRelease", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
