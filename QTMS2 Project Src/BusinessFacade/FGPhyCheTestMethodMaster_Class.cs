using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;

namespace BusinessFacade
{


    public class FGPhyCheTestMethodMaster_Class
    {

        # region Varibles
        private long FNo;
        private int TestNo;
        private string Min;
        private string Max;
        private string MethodName;
        private int Del;
        # endregion
        # region Properties
        public int del
        {
            get { return Del; }
            set { Del = value; }
        }
        public long fno
        {
            get { return FNo; }
            set { FNo = value; }
        }

        public int testno
        {
            get { return TestNo; }
            set { TestNo = value; }
        }
        public string min
        {
            get { return Min; }
            set { Min = value; }
        }
        public string max
        {
            get { return Max; }
            set { Max = value; }
        }
        public string methodname
        {
            get { return MethodName; }
            set { MethodName = value; }
        }
        # endregion

        public DataSet SELECT_FormulaNo_FGPhyChe()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_FormulaNo_FGPhyChe");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet SELECT_tblFGPhysicochemicalTestMethodMaster_tblBulkMaster()
        {
            DataSet ds = new DataSet();
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblFGPhysicochemicalTestMethodMaster_tblBulkMaster");
            return ds;
        }

        public DataSet SELECT_tblFGPhysicochemicalTestMethodMaster_tblBulkMaster_tblTestMaster()
        {
            DataSet ds = new DataSet();
            SqlParameter[] myparam = new SqlParameter[1];
            myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblFGPhysicochemicalTestMethodMaster_tblBulkMaster_tblTestMaster", myparam);
            return ds;
        }

        public bool Delete_tblFGPhysicochemicalTestMethodMaster()
        {
            SqlParameter[] myparam = new SqlParameter[1];
            myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblFGPhysicochemicalTestMethodMaster", myparam);
            return true;
        }

        public bool Update_tblFGPhysicochemicalTestMethodMaster_FNo_Del()
        {
            SqlParameter[] myparam = new SqlParameter[2];
            myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
            myparam[1] = ModHelper.CreateParameter("@Del", SqlDbType.Bit, 1, ParameterDirection.Input, del);
            SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblFGPhysicochemicalTestMethodMaster_FNo_Del", myparam);
            return true;
        }

        public void Insert_tblFGPhysicochemicalTestMethodMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[1] = ModHelper.CreateParameter("@TestNo", SqlDbType.Int, 4, ParameterDirection.Input, testno);
                myparam[2] = ModHelper.CreateParameter("@NormsMin", SqlDbType.VarChar, 50, ParameterDirection.Input, min);
                myparam[3] = ModHelper.CreateParameter("@NormsMax", SqlDbType.VarChar, 50, ParameterDirection.Input, max);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblFGPhysicochemicalTestMethodMaster", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        ///New Procedure for Instrument connectivity to add exra parameter method name
        /// </summary>
        public void Insert_tblFGPhysicochemicalTestMethodMasterLABX()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[5];
                myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[1] = ModHelper.CreateParameter("@TestNo", SqlDbType.Int, 4, ParameterDirection.Input, testno);
                myparam[2] = ModHelper.CreateParameter("@NormsMin", SqlDbType.VarChar, 50, ParameterDirection.Input, min);
                myparam[3] = ModHelper.CreateParameter("@NormsMax", SqlDbType.VarChar, 50, ParameterDirection.Input, max);
                myparam[4] = ModHelper.CreateParameter("@MethodName", SqlDbType.NVarChar, 50, ParameterDirection.Input, methodname);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblFGPhysicochemicalTestMethodMasterLABX", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update_tblFGPhysicochemicalTestMethodMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[5];
                myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[1] = ModHelper.CreateParameter("@TestNo", SqlDbType.Int, 4, ParameterDirection.Input, testno);
                myparam[2] = ModHelper.CreateParameter("@NormsMin", SqlDbType.VarChar, 50, ParameterDirection.Input, min);
                myparam[3] = ModHelper.CreateParameter("@NormsMax", SqlDbType.VarChar, 50, ParameterDirection.Input, max);
                myparam[4] = ModHelper.CreateParameter("@MethodName", SqlDbType.NVarChar, 50, ParameterDirection.Input, methodname);


                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblFGPhysicochemicalTestMethodMaster", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DELETE_tblFGPhysicochemicalTestMethodMaster_TestNo()
        {
            try
            {
                SqlParameter[] myaparam = new SqlParameter[2];
                myaparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myaparam[1] = ModHelper.CreateParameter("@TestNo", SqlDbType.Int, 4, ParameterDirection.Input, testno);
                SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_DELETE_tblFGPhysicochemicalTestMethodMaster_TestNo", myaparam);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update_tblFGPhysicochemicalTestMethodMaster_Del()
        {
            try
            {
                SqlParameter[] myaparam = new SqlParameter[3];
                myaparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myaparam[1] = ModHelper.CreateParameter("@TestNo", SqlDbType.Int, 4, ParameterDirection.Input, testno);
                myaparam[2] = ModHelper.CreateParameter("@Del", SqlDbType.Bit, 1, ParameterDirection.Input, del);
                SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_Update_tblFGPhysicochemicalTestMethodMaster_Del", myaparam);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
