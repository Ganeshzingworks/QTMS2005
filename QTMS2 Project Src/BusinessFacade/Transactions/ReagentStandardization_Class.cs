using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataFacade;
using System.Data.SqlClient;

namespace BusinessFacade.Transactions
{
    public class ReagentStandardization_Class
    {
        #region Variables

        private long ReagentID;
        private long ReagentTransID;
        private long ReagentBottleNo;
        private DateTime StdDate;
        private long NormalityUnit;
        private DateTime ValidityDate;
        private int LoginID;
        private DateTime ReceiveDate;
        #endregion

        #region Properties

        public long reagentid
        {
            get { return ReagentID; }
            set { ReagentID = value; }
        }

        public long reagenttransid
        {
            get { return ReagentTransID; }
            set { ReagentTransID = value; }
        }
        public long reagentbottleno 
        {
            get { return ReagentBottleNo; }
            set { ReagentBottleNo = value; }
        }
        public DateTime  stddate
        {
            get { return StdDate; }
            set { StdDate = value; }
        }
        public long normalityunit
        {
            get { return NormalityUnit; }
            set { NormalityUnit = value; }
        }
        public DateTime validitydate
        {
            get { return ValidityDate; }
            set { ValidityDate = value; }
        }
        public int loginid 
        {
            get { return LoginID; }
            set { LoginID = value; }
        }
        public DateTime receivedate  
        {
            get { return ReceiveDate; }
            set { ReceiveDate = value; }
        }
        #endregion

        #region Functions


      


        public DataSet Select_RACode()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblReagentMAster_RACode");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_LotNo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@ReagentID", SqlDbType.BigInt, 8, ParameterDirection.Input, reagentid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblReagentTrans_LotNo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert_tblReagentStandardization()
        {
            try
            {
                int active = 1;

                SqlParameter[] myparam = new SqlParameter[13];
                myparam[0] = ModHelper.CreateParameter("@ReagentID", SqlDbType.BigInt, 8, ParameterDirection.Input, reagentid);
                myparam[1] = ModHelper.CreateParameter("@ReagentTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, reagenttransid );
                myparam[2] = ModHelper.CreateParameter("@ReagentBottleNo", SqlDbType.BigInt, 8, ParameterDirection.Input, reagentbottleno );
                myparam[3] = ModHelper.CreateParameter("@StdDate", SqlDbType.DateTime, 8, ParameterDirection.Input, stddate );
                myparam[4] = ModHelper.CreateParameter("@NormalityUnit", SqlDbType.Decimal, 8, ParameterDirection.Input, normalityunit);
                myparam[5] = ModHelper.CreateParameter("@ValidityDate", SqlDbType.DateTime, 8, ParameterDirection.Input, validitydate);
                              
                myparam[6] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
                myparam[7] = ModHelper.CreateParameter("@ModifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, DBNull.Value);
                myparam[8] = ModHelper.CreateParameter("@ModifiedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, DBNull.Value);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblReagentStandardazation", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_BottleNos()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@ReagentTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, reagenttransid );
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_BottleNo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update_tblReagentBottle()
        {
            try
            {
 
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@ReagentTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, reagenttransid);
                myparam[1] = ModHelper.CreateParameter("@BottleNo", SqlDbType.Int , 8, ParameterDirection.Input, reagentbottleno );

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblReagentBottle", myparam);
              
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
