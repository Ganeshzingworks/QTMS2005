using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;

namespace BusinessFacade.Transactions
{
    public class FDAMaster_Class
    {
        # region Variables
        private int TestNo;
        private string Min;
        private string Max;
        private string FormulaType;
        private long FNo;
        private int Prsno;
        #endregion
        # region Properties
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

        public int prsno
        {
            get { return Prsno; }
            set { Prsno = value; }
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
        public string formulatype
        {
            get { return FormulaType; }
            set { FormulaType = value; }
        }

        #endregion

        # region Functions

        public DataSet Select_tblBulkMaster_FNo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_TblBulkMaster_PreservativeTest_FNo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }


        public DataSet Select_tbltestmaster_ControlTest()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tbltestmaster_ControlTest_ForFDAMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tbltestmaster_IdentificationTest()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tbltestmaster_IdentificationTest_ForFDAMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet STP_Select_tblPreservativeMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblPreservativeMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet Select_tblPreservativeMaster_Prsno()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@Prsno", SqlDbType.Int, 4, ParameterDirection.Input, prsno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblPreservativeMaster_Prsno", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        public void Insert_tblFDAPhysicochemicalTestMethodMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[1] = ModHelper.CreateParameter("@TestNo", SqlDbType.Int, 4, ParameterDirection.Input, testno);
                myparam[2] = ModHelper.CreateParameter("@NormsMin", SqlDbType.VarChar, 50, ParameterDirection.Input, min);
                myparam[3] = ModHelper.CreateParameter("@NormsMax", SqlDbType.VarChar, 50, ParameterDirection.Input, max);
                

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblFDAPhysicochemicalTestMethodMaster", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert_tblFDAPreservativeTestMethodMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[1] = ModHelper.CreateParameter("@TestNo", SqlDbType.Int, 4, ParameterDirection.Input, testno);
                myparam[2] = ModHelper.CreateParameter("@NormsMin", SqlDbType.VarChar, 50, ParameterDirection.Input, min);
                myparam[3] = ModHelper.CreateParameter("@NormsMax", SqlDbType.VarChar, 50, ParameterDirection.Input, max);
               

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblFDAPreservativeTestMethodMaster", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Update_tblFDAPhysicochemicalTestMethodMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[1] = ModHelper.CreateParameter("@TestNo", SqlDbType.Int, 4, ParameterDirection.Input, testno);
                myparam[2] = ModHelper.CreateParameter("@NormsMin", SqlDbType.VarChar, 50, ParameterDirection.Input, min);
                myparam[3] = ModHelper.CreateParameter("@NormsMax", SqlDbType.VarChar, 50, ParameterDirection.Input, max);
                //myparam[4] = ModHelper.CreateParameter("@FormulaType", SqlDbType.VarChar, 50, ParameterDirection.Input, formulatype);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblFDAPhysicochemicalTestMethodMaster", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update_tblFDAPreservativeTestMethodMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[1] = ModHelper.CreateParameter("@TestNo", SqlDbType.Int, 4, ParameterDirection.Input, testno);
                myparam[2] = ModHelper.CreateParameter("@NormsMin", SqlDbType.VarChar, 50, ParameterDirection.Input, min);
                myparam[3] = ModHelper.CreateParameter("@NormsMax", SqlDbType.VarChar, 50, ParameterDirection.Input, max);
               

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblFDAPreservativeTestMethodMaster", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete_tblFDAPhysicochemicalTestMethodMaster()
        {
            try
            {
                SqlParameter[] myaparam = new SqlParameter[2];
                myaparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myaparam[1] = ModHelper.CreateParameter("@TestNo", SqlDbType.Int, 4, ParameterDirection.Input, testno);                
                SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_Delete_tblFDAPhysicochemicalTestMethodMaster", myaparam);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete_tblFDAPhysicochemicalTestMethodMaster_tblFDAPreservativeTestMethodMaster()
        {
            try
            {
                SqlParameter[] myaparam = new SqlParameter[1];
                myaparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);                
                SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_Delete_tblFDAPhysicochemicalTestMethodMaster_tblFDAPreservativeTestMethodMaster", myaparam);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete_tblFDAPreservativeTestMethodMaster()
        {
            try
            {
                SqlParameter[] myaparam = new SqlParameter[2];
                myaparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myaparam[1] = ModHelper.CreateParameter("@TestNo", SqlDbType.Int, 4, ParameterDirection.Input, testno);
                SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_Delete_tblFDAPreservativeTestMethodMaster", myaparam);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet SELECT_tblFDAPhysicoChemicalTestMethodMaster_FNo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblFDAPhysicoChemicalTestMethodMaster_FNo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        public DataSet SELECT_tblFDAPreservativeTestMethodMaster_FNo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblFDAPreservativeTestMethodMaster_FNo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
        public DataSet SELECT_FormulaNo_tblBulkMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "SELECT_FormulaNo_tblBulkMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet SELECT_FormulaNo_tblFDAPhysicochemicalTestMethodMaster_tblFDAPreservativeTestMethodMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "SELECT_FormulaNo_tblFDAPhysicochemicalTestMethodMaster_tblFDAPreservativeTestMethodMaster");
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
