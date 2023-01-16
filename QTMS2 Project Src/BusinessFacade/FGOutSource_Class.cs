using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;

namespace BusinessFacade
{
    public class FGOutSource_Class
    {
        # region Varibles

        private long OFGID;
        private string FinalFGCode;
        private string Batchcode;
        private string Mfgdate;
        private long CreatedBy;
        private string CreatedOn;
        private long ModifiedBy;
        private string ModifiedOn;

        private long OCFGID;
        private string ChildFGCode;
        private string ChildBatchcode;
        private string ChildMfgdate;
        private string Supplier;

        private string fromdate;
        private string todate;

        #endregion

        #region Properties

        public long _OFGID
        {
            get { return OFGID; }
            set { OFGID = value; }
        }
        public string _FinalFGCode
        {
            get { return FinalFGCode; }
            set { FinalFGCode = value; }
        }
        public string _Batchcode
        {
            get { return Batchcode; }
            set { Batchcode = value; }
        }
        public string _Mfgdate
        {
            get { return Mfgdate; }
            set { Mfgdate = value; }
        }
        public long _CreatedBy
        {
            get { return CreatedBy; }
            set { CreatedBy = value; }
        }
        public string _CreatedOn
        {
            get { return CreatedOn; }
            set { CreatedOn = value; }
        }
        public long _ModifiedBy
        {
            get { return ModifiedBy; }
            set { ModifiedBy = value; }
        }
        public string _ModifiedOn
        {
            get { return ModifiedOn; }
            set { ModifiedOn = value; }
        }
        public long _OCFGID
        {
            get { return OCFGID; }
            set { OCFGID = value; }
        }
        public string _ChildFGCode
        {
            get { return ChildFGCode; }
            set { ChildFGCode = value; }
        }
        public string _ChildBatchcode
        {
            get { return ChildBatchcode; }
            set { ChildBatchcode = value; }
        }
        public string _ChildMfgdate
        {
            get { return ChildMfgdate; }
            set { ChildMfgdate = value; }
        }
        public string _Supplier
        {
            get { return Supplier; }
            set { Supplier = value; }
        }
        public string _fromdate
        {
            get { return fromdate; }
            set { fromdate = value; }
        }
        public string _todate
        {
            get { return todate; }
            set { todate = value; }
        }
        #endregion

        #region Functions

        public long Insert_tblOutSourceFG()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[6];
                myparam[0] = ModHelper.CreateParameter("@FinalFGCode", SqlDbType.VarChar, 50, ParameterDirection.Input, FinalFGCode);
                myparam[1] = ModHelper.CreateParameter("@Batchcode", SqlDbType.VarChar, 250, ParameterDirection.Input, Batchcode);
                myparam[2] = ModHelper.CreateParameter("@Mfgdate", SqlDbType.DateTime, 4, ParameterDirection.Input, Mfgdate);
                myparam[3] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, CreatedBy);
                myparam[4] = ModHelper.CreateParameter("@CreatedOn", SqlDbType.DateTime, 4, ParameterDirection.Input, CreatedOn);

                myparam[5] = ModHelper.CreateParameter("@OFGID", SqlDbType.BigInt, 8, ParameterDirection.Output);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_INSERT_tblOutSourceFG", myparam);

                OFGID = Convert.ToInt32(myparam[5].Value);

                return OFGID;
                //return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert_tblOutSourceFG_Child()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[7];
                myparam[0] = ModHelper.CreateParameter("@OFGID", SqlDbType.BigInt, 8, ParameterDirection.Input, OFGID);
                myparam[1] = ModHelper.CreateParameter("@ChildFGCode", SqlDbType.VarChar, 50, ParameterDirection.Input, ChildFGCode);
                myparam[2] = ModHelper.CreateParameter("@Batchcode", SqlDbType.VarChar, 250, ParameterDirection.Input, ChildBatchcode);
                myparam[3] = ModHelper.CreateParameter("@Mfgdate", SqlDbType.DateTime, 4, ParameterDirection.Input, ChildMfgdate);
                myparam[4] = ModHelper.CreateParameter("@Supplier", SqlDbType.VarChar, 400, ParameterDirection.Input, Supplier);
                myparam[5] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, CreatedBy);
                myparam[6] = ModHelper.CreateParameter("@CreatedOn", SqlDbType.DateTime, 4, ParameterDirection.Input, CreatedOn);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_INSERT_tblOutSourceFG_Child", myparam);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_tblOutSourceFG()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblOutSourceFG", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_tblOutSourceFG_By_OFGID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@OFGID", SqlDbType.BigInt, 8, ParameterDirection.Input, OFGID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblOutSourceFG_By_OFGID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_tblOutSourceFG_Child_By_OFGID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@OFGID", SqlDbType.BigInt, 8, ParameterDirection.Input, OFGID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblOutSourceFG_Child_By_OFGID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Get_OFGID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@FinalFGCode", SqlDbType.VarChar, 50, ParameterDirection.Input, FinalFGCode);
                myparam[1] = ModHelper.CreateParameter("@Batchcode", SqlDbType.VarChar, 250, ParameterDirection.Input, Batchcode);
                myparam[2] = ModHelper.CreateParameter("@Mfgdate", SqlDbType.DateTime, 4, ParameterDirection.Input, Mfgdate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Get_OFGID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update_tblOutSourceFG()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[6];
                myparam[0] = ModHelper.CreateParameter("@FinalFGCode", SqlDbType.VarChar, 50, ParameterDirection.Input, FinalFGCode);
                myparam[1] = ModHelper.CreateParameter("@Batchcode", SqlDbType.VarChar, 250, ParameterDirection.Input, Batchcode);
                myparam[2] = ModHelper.CreateParameter("@Mfgdate", SqlDbType.DateTime, 4, ParameterDirection.Input, Mfgdate);
                myparam[3] = ModHelper.CreateParameter("@ModifiedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, ModifiedBy);
                myparam[4] = ModHelper.CreateParameter("@ModifiedOn", SqlDbType.DateTime, 4, ParameterDirection.Input, ModifiedOn);
                myparam[5] = ModHelper.CreateParameter("@OFGID", SqlDbType.BigInt, 8, ParameterDirection.Input,OFGID);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblOutSourceFG", myparam);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete_tblOutSourceFG_Child()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@OCFGID", SqlDbType.BigInt, 8, ParameterDirection.Input, OCFGID);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblOutSourceFG_Child", myparam);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete_tblOutSourceFG()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@OFGID", SqlDbType.BigInt, 8, ParameterDirection.Input, OFGID);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblOutSourceFG", myparam);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_tblOutSourceFG_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblOutSourceFG_Report", myparam);
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
