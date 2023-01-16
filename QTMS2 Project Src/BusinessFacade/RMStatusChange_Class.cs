using System;
using System.Collections.Generic;
using System.Text;
using DataFacade;
using System.Data;
using System.Data.SqlClient;

namespace BusinessFacade
{
    public class RMStatusChange_Class
    {
        #region Variables
        private int LoginID;
        private string FromDate;
        private string ToDate;
        private string NonConReason;
        private long RMTransID;
        private long AcceptedQuantity;
        private char Status;
        private string Comment;
        private string ChangeDate;

        #endregion

        #region Properties
        
        public int loginid
        {
            get { return LoginID; }
            set { LoginID = value; }
        }
        
        public string fromdate
        {
            get { return FromDate; }
            set { FromDate=value; }
        }

        public string changedate
        {
            get { return ChangeDate; }
            set { ChangeDate = value; }
        }

        public string todate
        {
            get { return ToDate;}
            set { ToDate = value; }
        }

        public long rmtransid
        {
            get { return RMTransID; }
            set { RMTransID = value; }
        }

        public string nonconreason
        {
            get { return NonConReason; }
            set { NonConReason = value; }

        }

        public string comment
        {
            get { return Comment; }
            set { Comment = value; }

        }


        public long acceptedquantity
        {

            get { return AcceptedQuantity; }
            set { AcceptedQuantity = value; }

        }

        public char status
        {
            get { return Status; }
            set { Status = value; }
        }


        #endregion

        #region Function

        public DataSet Select_RMDetails_RMCodeMaster_InspDate()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, FromDate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, ToDate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMDetails_tblRMCodeMaster_InspDate", myparam);
               
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_RMSampling_RMSupplierMaster_RMTransID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMTransID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMSampling_tblRMSupplierMaster_RMTransID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert_RMStatus()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[7];
                myparam[0] = ModHelper.CreateParameter("@RMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMTransID);
                myparam[1] = ModHelper.CreateParameter("@NonConReason", SqlDbType.VarChar, 200, ParameterDirection.Input, NonConReason);
                myparam[2] = ModHelper.CreateParameter("@AcceptedQuantity", SqlDbType.BigInt, 8, ParameterDirection.Input, AcceptedQuantity);
                myparam[3] = ModHelper.CreateParameter("@Status", SqlDbType.Char, 1, ParameterDirection.Input, Status);
                myparam[4] = ModHelper.CreateParameter("@Comment", SqlDbType.VarChar,200, ParameterDirection.Input, Comment);
                myparam[5] = ModHelper.CreateParameter("@ChangeDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, ChangeDate);
                myparam[6] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input,loginid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblRMStatus_newstatuschange", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion


    }
}
