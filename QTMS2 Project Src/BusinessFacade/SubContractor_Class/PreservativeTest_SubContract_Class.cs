using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;

namespace BusinessFacade.SubContractor_Class
{
    public class PreservativeTest_SubContract_Class
    {
        # region Varibles
        private int LoginID;
        private long PreservativeNo;
        private Int32 PresNo;
        private string Obs;
        private char Remarks;
        private string InspDate;
        private long PkgSampNo;
        private char BPCNONBPC;
        private string NBPcommets;
        private char Status;
        private string Comments;
        private string transid;
        private string FromDate;
        private string ToDate;
        private long FMID;
        private long PresMethodNo;
        private string Reading;
        private bool PreservativeDone;
        private string NormsMin;
        private string NormsMax;
        private string PresFormula;
        private string WeightSample;
        private string WeightReference;
        private string AreaSample;
        private string AreaReference;
        private string VolumeSample;
        private string AssayConc;
        private int InspectedBy;
        private string Result;
        # endregion
        # region Properties
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
        public char remarks
        {
            get { return Remarks; }
            set { Remarks = value; }
        }
        public string obs
        {
            get { return Obs; }
            set { Obs = value; }
        }
        public Int32 presno
        {
            get { return PresNo; }
            set { PresNo = value; }
        }
        public long preservativeno
        {
            get { return PreservativeNo; }
            set { PreservativeNo = value; }
        }
        public string TransId
        {
            get { return transid; }
            set { transid = value; }
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
        public char bpcnonbpc
        {
            get { return BPCNONBPC; }
            set { BPCNONBPC = value; }
        }
        public string nbpcomments
        {
            get { return NBPcommets; }
            set { NBPcommets = value; }
        }
        public long pkgsampno
        {
            get { return PkgSampNo; }
            set { PkgSampNo = value; }
        }
        public string inspdate
        {
            get { return InspDate; }
            set { InspDate = value; }
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
        public long fmid
        {
            get { return FMID; }
            set { FMID = value; }
        }
        public long presmethodno
        {
            get { return PresMethodNo; }
            set { PresMethodNo = value; }
        }
        public string reading
        {
            get { return Reading; }
            set { Reading = value; }
        }
        public string normsmin
        {
            get { return NormsMin; }
            set { NormsMin = value; }
        }
        public string normsmax
        {
            get { return NormsMax; }
            set { NormsMax = value; }
        }
        public string presformula
        {
            get { return PresFormula; }
            set { PresFormula = value; }
        }
        public string weightsample
        {
            get { return WeightSample; }
            set { WeightSample = value; }
        }
        public string weightreference
        {
            get { return WeightReference; }
            set { WeightReference = value; }
        }
        public string areasample
        {
            get { return AreaSample; }
            set { AreaSample = value; }
        }
        public string areareference
        {
            get { return AreaReference; }
            set { AreaReference = value; }
        }
        public string volumesample
        {
            get { return VolumeSample; }
            set { VolumeSample = value; }
        }
        public string assayconc
        {
            get { return AssayConc; }
            set { AssayConc = value; }
        }
        public bool preservativedone
        {
            get { return PreservativeDone; }
            set { PreservativeDone = value; }
        }
        public string result
        {
            get { return Result; }
            set { Result = value; }
        }

        # endregion
        # region Functions

        public DataSet Select_PendingPreservativeDetails_SubContract()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_PendingPreservativeDetails_SubContract");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_PreservativeDetails_FMID_SubContract()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_PreservativeDetails_FMID_SubContract", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SELECT_tblPreservativeMethodMaster_FMID_SubContract()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblPreservativeMethodMaster_FMID_SubContract", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert_tblPreservative_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[8];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                myparam[1] = ModHelper.CreateParameter("@InspDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, inspdate);
                myparam[2] = ModHelper.CreateParameter("@BPCNONBPC", SqlDbType.Char, 1, ParameterDirection.Input, bpcnonbpc);
                myparam[3] = ModHelper.CreateParameter("@NBPcommts", SqlDbType.NVarChar, 250, ParameterDirection.Input, nbpcomments);
                myparam[4] = ModHelper.CreateParameter("@Status", SqlDbType.Char, 1, ParameterDirection.Input, status);
                myparam[5] = ModHelper.CreateParameter("@Comments", SqlDbType.NVarChar, 200, ParameterDirection.Input, comments);
                myparam[6] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
                myparam[7] = ModHelper.CreateParameter("@InspectedBy", SqlDbType.Int, 4, ParameterDirection.Input, inspectedby);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblPreservative_SubContract", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert_tblPreservativeMethodDetails_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[13];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                myparam[1] = ModHelper.CreateParameter("@PresMethodNo", SqlDbType.BigInt, 8, ParameterDirection.Input, presmethodno);
                myparam[2] = ModHelper.CreateParameter("@NormsReading", SqlDbType.VarChar, 50, ParameterDirection.Input, reading);
                myparam[3] = ModHelper.CreateParameter("@Min", SqlDbType.VarChar, 50, ParameterDirection.Input, normsmin);
                myparam[4] = ModHelper.CreateParameter("@Max", SqlDbType.VarChar, 50, ParameterDirection.Input, normsmax);
                myparam[5] = ModHelper.CreateParameter("@PresFormula", SqlDbType.NVarChar, 50, ParameterDirection.Input, presformula);
                myparam[6] = ModHelper.CreateParameter("@WeightSample", SqlDbType.VarChar, 50, ParameterDirection.Input, weightsample);
                myparam[7] = ModHelper.CreateParameter("@WeightReference", SqlDbType.VarChar, 50, ParameterDirection.Input, weightreference);
                myparam[8] = ModHelper.CreateParameter("@AreaSample", SqlDbType.VarChar, 50, ParameterDirection.Input, areasample);
                myparam[9] = ModHelper.CreateParameter("@AreaReference", SqlDbType.VarChar, 50, ParameterDirection.Input, areareference);
                myparam[10] = ModHelper.CreateParameter("@VolumeSample", SqlDbType.VarChar, 50, ParameterDirection.Input, volumesample);
                myparam[11] = ModHelper.CreateParameter("@AssayConc", SqlDbType.VarChar, 50, ParameterDirection.Input, assayconc);
                myparam[12] = ModHelper.CreateParameter("@Result", SqlDbType.VarChar, 50, ParameterDirection.Input, result);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblPreservativeMethodDetails_SubContract", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete_tblPreservativeMethodDetails_FMID_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblPreservativeMethodDetails_FMID_SubContract", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update_tblTransFM_PreservativeDone_SubContract()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                myparam[1] = ModHelper.CreateParameter("@PreservativeDone", SqlDbType.Bit, 1, ParameterDirection.Input, preservativedone);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblTransFM_PreservativeDone_SubContract", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblPreservativeMethodDetails_SubContract_Loreal()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                myparam[1] = ModHelper.CreateParameter("@PresMethodNo", SqlDbType.BigInt, 8, ParameterDirection.Input, presmethodno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblPreservativeMethodDetails_SubContract_Loreal", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_tblPreservativeMethodDetails_SubContract_Supplier()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                myparam[1] = ModHelper.CreateParameter("@PresMethodNo", SqlDbType.BigInt, 8, ParameterDirection.Input, presmethodno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblPreservativeMethodDetails_SubContract_Supplier", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_ModificationPreservativeDetails_Details_SubContract()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_ModificationPreservativeDetails_Details_SubContract", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_PreservativeTest_Protocol_FMID_SubContract()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_PreservativeTest_Protocol_FMID_SubContract", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
