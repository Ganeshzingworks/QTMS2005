using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataFacade;
using System.Data.SqlClient;

namespace BusinessFacade.Transactions
{
    public class PMStatusChange_Class
    {
        #region Variables
        private string FromDate;
        private string ToDate;
        private long PMTransID;
        private long PMTestID;
        private string COCApplicable;
        private string COCApplicableComment;
        private string DefectObserved;
        private int LNo;
        private int LoginID;
        private string DefectSampleQuantity;
        private string DefectCategory;
        private string DefectComment;
        private string Status;
        private string ActualStatus;
        private string RejectComment;
        private int CurrentFlag;
        private int ChangedStatus;
        private int NoOfDefect;
        private string Defect;
        private char Closed;
        #endregion

        #region Properties
        public char closed
        {
            get { return Closed; }
            set { Closed = value; }
        }

        public string defect
        {
            get { return Defect; }
            set { Defect = value; }
        }

        public int noofdefect
        {
            get { return NoOfDefect; }
            set { NoOfDefect = value; }
        }

        public int loginid
        {
            get { return LoginID; }
            set { LoginID = value; }
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

        public string cocapplicable
        {
            get { return COCApplicable; }
            set { COCApplicable = value; }
        }

        public string cocapplicablecomment
        {
            get { return COCApplicableComment; }
            set { COCApplicableComment = value; }
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

        public string defectcategory
        {
            get { return DefectCategory; }
            set { DefectCategory = value; }
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

        public string rejectcomment
        {
            get { return RejectComment; }
            set { RejectComment = value; }
        }
        public long pmtransid
        {
            get { return PMTransID; }
            set { PMTransID = value; }
        }
        public long pmtestid
        {
            get { return PMTestID; }
            set { PMTestID = value; }
        }
        public string defectsamplequantity
        {
            get { return DefectSampleQuantity; }
            set { DefectSampleQuantity = value; }
        }
        public int currentflag
        {
            get { return CurrentFlag; }
            set { CurrentFlag = value; }
        }
        public int changedstatus
        {
            get { return ChangedStatus; }
            set { ChangedStatus = value; }
        }

        #endregion

        #region Functions
        public DataSet Select_LineMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_TblLineMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_PMTransaction_PMSupplierCOC_PMCodeMaster_InspDate()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, FromDate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, ToDate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblPMTransaction_tblPMSupplierCOC_tblPMCodeMaster_InspDate", myparam);

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
                myparam[0] = ModHelper.CreateParameter("@PMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input,pmtransid);                
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblPMPMSampling_tblPMDetails_PMTransID", myparam);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert_PMStatus()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[14];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@PMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmtransid);
                myparam[1] = ModHelper.CreateParameter("@PMTestID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmtestid);                
                myparam[2] = ModHelper.CreateParameter("@DefectObserved", SqlDbType.Char, 1, ParameterDirection.Input, defectobserved);
                myparam[3] = ModHelper.CreateParameter("@DefectComment", SqlDbType.VarChar, 200, ParameterDirection.Input, defectcomment);                
                myparam[4] = ModHelper.CreateParameter("@DefectSampleQuantity", SqlDbType.VarChar, 50, ParameterDirection.Input, defectsamplequantity);
                myparam[5] = ModHelper.CreateParameter("@NoOfDefect", SqlDbType.Int, 4, ParameterDirection.Input, noofdefect);
                myparam[6] = ModHelper.CreateParameter("@Defect", SqlDbType.VarChar, 50, ParameterDirection.Input, defect);
                myparam[7] = ModHelper.CreateParameter("@Status", SqlDbType.Char, 10, ParameterDirection.Input, status);
                myparam[8] = ModHelper.CreateParameter("@ActualStatus", SqlDbType.Char, 10, ParameterDirection.Input, actualstatus);
                myparam[9] = ModHelper.CreateParameter("@RejectComment", SqlDbType.VarChar, 50, ParameterDirection.Input, rejectcomment);
                myparam[10] = ModHelper.CreateParameter("@Closed", SqlDbType.Char, 1, ParameterDirection.Input, closed);
                myparam[11] = ModHelper.CreateParameter("@CurrentFlag", SqlDbType.Bit, 1, ParameterDirection.Input, currentflag);
                myparam[12] = ModHelper.CreateParameter("@ChangedStatus", SqlDbType.Bit, 1, ParameterDirection.Input, changedstatus);
                myparam[13] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginid);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblPMStatusChange_newstatuschange", myparam);
                return true;

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

        #endregion

    }
}
