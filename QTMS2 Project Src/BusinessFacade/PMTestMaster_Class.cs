using System;
using System.Collections.Generic;
using System.Text;
using DataFacade;
using System.Data;
using System.Data.SqlClient;

namespace BusinessFacade
{
    public class PMTestMaster_Class
    {
        #region Variables
        private string TestName;
        private long TestNo;
        private string TestDesc;
        private long CreatedBy;
        private long ModifiedBy;
        #endregion

        #region Properties
        public string testname
        {
            get
            {
                return TestName;
            }
            set
            {
                TestName = value;
            }
        }
        public string testdesc
        {
            get
            {
                return TestDesc;
            }
            set
            {
                TestDesc = value;
            }
        }

        public long testno
        {
            get
            {
                return TestNo;
            }
            set
            {
                TestNo = value;
            }
        }
        private short DimensionTest;

        public short dimensionTest
        {
            get { return DimensionTest; }
            set { DimensionTest = value; }
        }
        public long createdby
        {
            get { return CreatedBy; }
            set { CreatedBy = value; }
        }
        public long modifiedby
        {
            get { return ModifiedBy; }
            set { ModifiedBy = value; }
        }

        #endregion

        #region Functions
        public bool Insert_PMFGTestMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@TestName", SqlDbType.VarChar, 250, ParameterDirection.Input, TestName);
                myparam[1] = ModHelper.CreateParameter("@TestDesc", SqlDbType.VarChar, 250, ParameterDirection.Input, TestDesc);
                myparam[2] = ModHelper.CreateParameter("@DimensionTest", SqlDbType.Bit, 2, ParameterDirection.Input, dimensionTest);
                myparam[3] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, createdby);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblPMFGTestMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_PMFGTestMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblPMFGTestMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_PMFGTestMaster_TestNo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@TestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, TestNo);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblPMFGTestMaster_TestNo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update_PMFGTestMaster_TestNo()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[5];

                myparam[0] = ModHelper.CreateParameter("@TestName", SqlDbType.VarChar, 250, ParameterDirection.Input, TestName);
                myparam[1] = ModHelper.CreateParameter("@TestDesc", SqlDbType.VarChar, 250, ParameterDirection.Input, TestDesc);
                myparam[2] = ModHelper.CreateParameter("@TestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, TestNo);
                myparam[3] = ModHelper.CreateParameter("@DimensionTest", SqlDbType.Bit, 2, ParameterDirection.Input, dimensionTest);
                myparam[4] = ModHelper.CreateParameter("@ModifiedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, modifiedby);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblPMFGTestMaster_TestNo", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete_PMFGTestMaster()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@TestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, testno);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_PMFGTestMaster_TestNo", myparam);
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
