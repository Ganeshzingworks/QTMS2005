using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataFacade;
using System.Data.SqlClient;

namespace BusinessFacade
{
    public class FGSupplierMaster
    {
        private long _FGSupplierId;

        public long FGSupplierId
        {
            get { return _FGSupplierId; }
            set { _FGSupplierId = value; }
        }

        private string _FGSupplierName;

        public string FGSupplierName
        {
            get { return _FGSupplierName; }
            set { _FGSupplierName = value; }
        }

        private bool _Active;

        public bool Active
        {
            get { return _Active; }
            set { _Active = value; }
        }

        private string _Email;

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        #region Avinash S 19-08-2014

        private long fgno;
        private string fgcode;
        private string coc;
        private bool packing;
        private bool micro;
        private bool physicochemical;
        private string nooflots;
        private string actuallots;
        private string mark;
        private long createdby;

        public long FGNo
        {
            get { return fgno; }
            set { fgno = value; }
        }

        public long CreatedBy
        {
            get { return createdby; }
            set { createdby = value; }
        }

        public string FGCode
        {
            get { return fgcode; }
            set { fgcode = value; }
        }

        public string COC
        {
            get { return coc; }
            set { coc = value; }
        }

        public bool Packing
        {
            get { return packing; }
            set { packing = value; }
        }

        public bool Micro
        {
            get { return micro; }
            set { micro = value; }
        }

        public bool Physicochemical
        {
            get { return physicochemical; }
            set { physicochemical = value; }
        }

        public string NoofLots
        {
            get { return nooflots; }
            set { nooflots = value; }
        }

        public string ActualLots
        {
            get { return actuallots; }
            set { actuallots = value; }
        }

        public string Mark
        {
            get { return mark; }
            set { mark = value; }
        }
        #endregion

        //private int myVar;

        public bool CheckSupplierExistance
        {
            get
            {
                bool ChkExistance = false;
                try
                {
                    DataSet ds = new DataSet();
                    SqlParameter[] myParam = new SqlParameter[1];
                    myParam[0] = ModHelper.CreateParameter("@FGSupplierName", SqlDbType.VarChar, 145, ParameterDirection.Input, FGSupplierName);
                    ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_FGSupplierMaster_FGSupplierName", myParam);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        ChkExistance = true;
                    }
                    else
                    {
                        ChkExistance = false;
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                return ChkExistance;
            }
        }


        public DataSet Select_FGSupplierMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_FGSupplierMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert_FGSupplierMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                //SqlParameter[]myparam=new SqlParameter[]
                myparam[0] = ModHelper.CreateParameter("@FGSupplierName", SqlDbType.VarChar, 150, ParameterDirection.Input, FGSupplierName);
                myparam[1] = ModHelper.CreateParameter("@FGEmail", SqlDbType.NVarChar, 150, ParameterDirection.Input, Email);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_INSERT_TblFGSupplierMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_FGSupplierMaster_FGSupplierID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myParam = new SqlParameter[1];
                myParam[0] = ModHelper.CreateParameter("@FGSupplierId", SqlDbType.BigInt, 8, ParameterDirection.Input, FGSupplierId);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_FGSupplierMaster_FGSupplierId", myParam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckIn_tblBulkTestTransaction()
        {
            try
            {
                bool deleteStatus = false;
                DataSet ds = new DataSet();
                SqlParameter[] myParam = new SqlParameter[1];
                myParam[0] = ModHelper.CreateParameter("@FGSupplierId", SqlDbType.BigInt, 8, ParameterDirection.Input, FGSupplierId);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_FGBulkTestTransaction_FGSupplierId", myParam);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    deleteStatus = true;
                }
                else
                {
                    deleteStatus = false;
                }
                return deleteStatus;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool Update_FGSupplierMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[3];
                //SqlParameter[]myparam=new SqlParameter[]

                myparam[0] = ModHelper.CreateParameter("@FGSupplierName", SqlDbType.VarChar, 150, ParameterDirection.Input, FGSupplierName);
                myparam[1] = ModHelper.CreateParameter("@FGSupplierMail", SqlDbType.NVarChar, 150, ParameterDirection.Input, Email);
                myparam[2] = ModHelper.CreateParameter("@FGSupplierId", SqlDbType.BigInt, 8, ParameterDirection.Input, FGSupplierId);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblFGSullier", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete_FGSupplier()
        {
            try
            {
                SqlParameter[] myParam = new SqlParameter[1];
                myParam[0] = ModHelper.CreateParameter("@FGSupplierId", SqlDbType.BigInt, 8, ParameterDirection.Input, FGSupplierId);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblFGSullier", myParam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #region Avinash S

        public DataSet Select_FGSubContractorID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myParam = new SqlParameter[1];
                myParam[0] = ModHelper.CreateParameter("@FGSupplierName", SqlDbType.VarChar, 145, ParameterDirection.Input, FGSupplierName);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_FGSupplierMaster_FGSupplierName", myParam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert_FGSubContactorMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[10];
                //SqlParameter[]myparam=new SqlParameter[]
                myparam[0] = ModHelper.CreateParameter("@FGSupplierId", SqlDbType.BigInt, 8, ParameterDirection.Input, FGSupplierId);
                myparam[1] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, FGNo);
                myparam[2] = ModHelper.CreateParameter("@FGCode", SqlDbType.VarChar, 150, ParameterDirection.Input, FGCode);
                myparam[3] = ModHelper.CreateParameter("@COC", SqlDbType.NVarChar, 50, ParameterDirection.Input, COC);
                myparam[4] = ModHelper.CreateParameter("@Packing", SqlDbType.Bit, 1, ParameterDirection.Input, Packing);
                myparam[5] = ModHelper.CreateParameter("@Micro", SqlDbType.Bit, 1, ParameterDirection.Input, Micro);
                myparam[6] = ModHelper.CreateParameter("@Physicochemical", SqlDbType.Bit, 1, ParameterDirection.Input, Physicochemical);
                myparam[7] = ModHelper.CreateParameter("@NoofLots", SqlDbType.NVarChar, 150, ParameterDirection.Input, NoofLots);
                myparam[8] = ModHelper.CreateParameter("@ActualLots", SqlDbType.NVarChar, 150, ParameterDirection.Input, ActualLots);
                myparam[9] = ModHelper.CreateParameter("@Mark", SqlDbType.NVarChar, 50, ParameterDirection.Input, Mark);
                //myparam[9] = ModHelper.CreateParameter("@Flag", SqlDbType.NVarChar, 150, ParameterDirection.Input, "Insert");
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_TblFG_SubContracter", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete_FGSubContactorMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                //SqlParameter[]myparam=new SqlParameter[]
                myparam[0] = ModHelper.CreateParameter("@FGSupplierId", SqlDbType.BigInt, 8, ParameterDirection.Input, FGSupplierId);
                myparam[1] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, createdby);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_TblFGSubContracter", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public bool Update_FGSubContactorMaster()
        //{
        //    try
        //    {
        //        SqlParameter[] myparam = new SqlParameter[10];
        //        //SqlParameter[]myparam=new SqlParameter[]
        //        myparam[0] = ModHelper.CreateParameter("@FGSupplierId", SqlDbType.BigInt, 8, ParameterDirection.Input, FGSupplierId);
        //        myparam[1] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, FGNo);
        //        myparam[2] = ModHelper.CreateParameter("@FGCode", SqlDbType.VarChar, 150, ParameterDirection.Input, FGCode);
        //        myparam[3] = ModHelper.CreateParameter("@COC", SqlDbType.NVarChar, 50, ParameterDirection.Input, COC);
        //        myparam[4] = ModHelper.CreateParameter("@Packing", SqlDbType.Bit, 1, ParameterDirection.Input, Packing);
        //        myparam[5] = ModHelper.CreateParameter("@Micro", SqlDbType.Bit, 1, ParameterDirection.Input, Micro);
        //        myparam[6] = ModHelper.CreateParameter("@Physicochemical", SqlDbType.Bit, 1, ParameterDirection.Input, Physicochemical);
        //        myparam[7] = ModHelper.CreateParameter("@NoofLots", SqlDbType.NVarChar, 150, ParameterDirection.Input, NoofLots);
        //        myparam[8] = ModHelper.CreateParameter("@ActualLots", SqlDbType.NVarChar, 150, ParameterDirection.Input, ActualLots);
        //        myparam[9] = ModHelper.CreateParameter("@Flag", SqlDbType.NVarChar, 150, ParameterDirection.Input, "Update");
        //        SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_TblFG_SubContracter", myparam);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public DataSet Select_TblFG_SubContracter_FGSupplierID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myParam = new SqlParameter[1];
                myParam[0] = ModHelper.CreateParameter("@FGSupplierId", SqlDbType.BigInt, 8, ParameterDirection.Input, FGSupplierId);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_TblFG_SubContracter_FGSupplierId", myParam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Select_SPT_CheckMicroTest()
        {
            try
            {
                bool res;
                SqlParameter[] myParam = new SqlParameter[1];
                myParam[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, FGNo);
                res = Convert.ToBoolean(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "SPT_CheckMicroTest", myParam));
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion


    }
}
