using System;
using System.Collections.Generic;
using System.Text;
using DataFacade;
using System.Data.SqlClient;
using System.Data;

namespace BusinessFacade
{
    public class RMCodeTestMethodMaster_Class
    {
        #region Variables

        private string RMCode;
        private long RMCodeID;

        private int TestNo;
        private int RMParaNo;
        private int DescNo;

        
        private string NormsMin;
        private string NormsMax;
        private char MethodType;
        private string TestType;
        
        private Int16 PreservativeTest;
        private Int16 MicrobiologyTest;
        private Int16 FDADone;
        private int RowIndex;
        private int Del;
        private long CreatedBy;
        private long ModifiedBy;
        #endregion

        #region Properties
        public int del
        {
            get { return Del; }
            set { Del = value; }
        }
        public int rowindex
        {
            get { return RowIndex; }
            set { RowIndex = value; }
        }

        public Int16 preservativetest
        {
            get { return PreservativeTest; }
            set { PreservativeTest = value; }
        }

        public Int32 rmparano
        {
            get { return RMParaNo; }
            set { RMParaNo = value; }
        }

        public Int32 descno
        {
            get { return DescNo; }
            set { DescNo = value; }
        }


        public Int16 fdadone
        {
            get { return FDADone; }
            set { FDADone = value; }
        }

        public Int16 microbiologytest
        {
            get { return MicrobiologyTest; }
            set { MicrobiologyTest = value; }
        }

        public string rmcode
        {
            get { return RMCode; }
            set { RMCode = value; }
        }
        public long rmcodeid
        {
            get { return RMCodeID; }
            set { RMCodeID = value; }
        }
        public int testno
        {
            get { return TestNo; }
            set { TestNo = value; }
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
        
        public char methodtype
        {
            get { return MethodType; }
            set { MethodType = value; }
        }

        public string testtype
        {
            get { return TestType; }
            set { TestType = value; }
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
        public DataSet Select_RMCodeMaster()
        {
            try
            {
                DataSet ds = new DataSet();

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMCodeMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_RMCodeMaster_RMCodeID_All()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMCodeID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMCodeMaster_tblRMFamilyMaster_RMCodeID_All", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_PreservativeMaster_AnalysisTest()
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
        public DataSet Select_ParaMaster_IdentificationTest()
        {
            try
            {
                DataSet ds = new DataSet();

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMParaMaster_IdentificationTest");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_ParaMaster_IdentificationTestControlTest()
        {
            try
            {
                DataSet ds = new DataSet();

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMParaMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_ParaMaster_ControlTest()
        {
            try
            {
                DataSet ds = new DataSet();

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMParaMaster_ControlTest");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Insert_RMPhysicochemicalTestMethodMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[8];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmcodeid);
                myparam[1] = ModHelper.CreateParameter("@DescNo", SqlDbType.Int, 4, ParameterDirection.Input, descno);
                myparam[2] = ModHelper.CreateParameter("@NormsMin", SqlDbType.VarChar, 50, ParameterDirection.Input, normsmin);
                myparam[3] = ModHelper.CreateParameter("@NormsMax", SqlDbType.VarChar,50, ParameterDirection.Input, normsmax);                
                myparam[4] = ModHelper.CreateParameter("@TestType", SqlDbType.NVarChar, 50, ParameterDirection.Input, testtype);
                myparam[5] = ModHelper.CreateParameter("@RowIndex", SqlDbType.Int, 4, ParameterDirection.Input, rowindex);
                myparam[6] = ModHelper.CreateParameter("@Del", SqlDbType.Bit, 1, ParameterDirection.Input, del);
                myparam[7] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, createdby);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblRMPhysicochemicalTestMethodMaster", myparam);                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Update_RMPhysicochemicalTestMethodMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[8];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmcodeid);
                myparam[1] = ModHelper.CreateParameter("@DescNo", SqlDbType.Int, 4, ParameterDirection.Input, descno);
                myparam[2] = ModHelper.CreateParameter("@NormsMin", SqlDbType.VarChar, 50, ParameterDirection.Input, normsmin);
                myparam[3] = ModHelper.CreateParameter("@NormsMax", SqlDbType.VarChar, 50, ParameterDirection.Input, normsmax);
                myparam[4] = ModHelper.CreateParameter("@TestType", SqlDbType.NVarChar, 50, ParameterDirection.Input, testtype);
                myparam[5] = ModHelper.CreateParameter("@RowIndex", SqlDbType.Int, 4, ParameterDirection.Input, rowindex);
                myparam[6] = ModHelper.CreateParameter("@Del", SqlDbType.Bit, 1, ParameterDirection.Input, del);
                myparam[7] = ModHelper.CreateParameter("@ModifiedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, modifiedby);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblRMPhysicochemicalTestMethodMaster", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Update_tblRMPhysicochemicalTestMethodMaster_RowIndex()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmcodeid);
                myparam[1] = ModHelper.CreateParameter("@DescNo", SqlDbType.Int, 4, ParameterDirection.Input, descno);
                myparam[2] = ModHelper.CreateParameter("@TestType", SqlDbType.NVarChar, 50, ParameterDirection.Input, testtype);
                myparam[3] = ModHelper.CreateParameter("@RowIndex", SqlDbType.Int, 4, ParameterDirection.Input, rowindex);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblRMPhysicochemicalTestMethodMaster_RowIndex", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete_RMPhysicochemicalTestMethodMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMCodeID);
                myparam[1] = ModHelper.CreateParameter("@DescNo", SqlDbType.Int, 4, ParameterDirection.Input, descno);
                myparam[2] = ModHelper.CreateParameter("@TestType", SqlDbType.NVarChar, 50, ParameterDirection.Input, testtype);
                SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_Delete_tblRMPhysicochemicalTestMethodMaster", myparam);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update_tblRMPhysicochemicalTestMethodMaster_Del()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMCodeID);
                myparam[1] = ModHelper.CreateParameter("@DescNo", SqlDbType.Int, 4, ParameterDirection.Input, descno);
                myparam[2] = ModHelper.CreateParameter("@TestType", SqlDbType.NVarChar, 50, ParameterDirection.Input, testtype);
                myparam[3] = ModHelper.CreateParameter("@Del", SqlDbType.Bit, 1, ParameterDirection.Input, del);
                SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_Update_tblRMPhysicochemicalTestMethodMaster_Del", myparam);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete_AllTests()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMCodeID);
                SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_Delete_AllTests", myparam);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete_tblRMPhysicochemicalTestMethodMaster_RMCodeID()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMCodeID);
                SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_Delete_tblRMPhysicochemicalTestMethodMaster_RMCodeID", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update_tblRMPhysicochemicalTestMethodMaster_RMCodeID_Del()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMCodeID);
                myparam[1] = ModHelper.CreateParameter("@Del", SqlDbType.Bit, 1, ParameterDirection.Input, del);
                SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_Update_tblRMPhysicochemicalTestMethodMaster_RMCodeID_Del", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_RMPhysicochemicalTestMethodMaster_RMCodeID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmcodeid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMPhysicochemicalTestMethodMaster_RMCodeID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert_RMPreservativeMethodMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[5];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMCodeID);
                myparam[1] = ModHelper.CreateParameter("@Prsno", SqlDbType.Int, 4, ParameterDirection.Input, TestNo);
                myparam[2] = ModHelper.CreateParameter("@NormsMin", SqlDbType.VarChar, 50, ParameterDirection.Input, NormsMin);
                myparam[3] = ModHelper.CreateParameter("@NormsMax", SqlDbType.VarChar, 50, ParameterDirection.Input, NormsMax);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblRMPreservativeMethodMaster", myparam);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Update_RMPreservativeMethodMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMCodeID);
                myparam[1] = ModHelper.CreateParameter("@Prsno", SqlDbType.Int, 4, ParameterDirection.Input, TestNo);
                myparam[2] = ModHelper.CreateParameter("@NormsMin", SqlDbType.VarChar, 50, ParameterDirection.Input, NormsMin);
                myparam[3] = ModHelper.CreateParameter("@NormsMax", SqlDbType.VarChar, 50, ParameterDirection.Input, NormsMax);
                //myparam[4] = ModHelper.CreateParameter("@FormulaType", SqlDbType.VarChar, 50, ParameterDirection.Input, formulatype);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblRMPreservativeMethodMaster", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete_RMPreservativeMethodMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMCodeID);
                myparam[1] = ModHelper.CreateParameter("@Prsno", SqlDbType.Int, 4, ParameterDirection.Input, TestNo);
                SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_Delete_tblRMPreservativeMethodMaster", myparam);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete_RMFDAPhysicoChemicalTestMethodMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMCodeID);
                myparam[1] = ModHelper.CreateParameter("@DescNo", SqlDbType.Int, 4, ParameterDirection.Input, descno);
                SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_Delete_tblRMFDAPhysicoChemicalTestMethodMaster", myparam);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblRMPhysicochemicalTestMethodMaster_RMCode_MethodType()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmcodeid);
                myparam[1] = ModHelper.CreateParameter("@MethodType", SqlDbType.Char, 1, ParameterDirection.Input, methodtype);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMPhysicochemicalTestMethodMaster_RMCode_MethodType", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_RMPhysicochemicalTestMethodMaster_RMCode_ReducedIdentification()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMCodeID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMPhysicochemicalTestMethodMaster_RMCode_Reduced_Identification", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_RMPhysicochemicalTestMethodMaster_RMCode_ReducedControlCon()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMCodeID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMPhysicochemicalTestMethodMaster_RMCode_Reduced_Control", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_RMPhysicochemicalTestMethodMaster_RMCode_FullControlId()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMCodeID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMPhysicochemicalTestMethodMaster_RMCode_Full_Identification", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_RMPhysicochemicalTestMethodMaster_RMCode_FullControlCon()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMCodeID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMPhysicochemicalTestMethodMaster_RMCode_Full_Control", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_RMPreservativeMethodMaster_RMCode_FullControlAnalysis()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMCodeID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMPreservativeMethodMaster_RMCode_Full_ControlAnalysis", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_RMFDAPhysicoChemicalTestMethodMaster_RMCode()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMCodeID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMFDAPhysicoChemicalTestMethodMaster_RMCode", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_RMFDAPreservativeMethodMaster_RMCode()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMCodeID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMFDAPreservativeMethodMaster_RMCode", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblRMPhysicochemicalTestMethodMaster()
        {
            try
            {
                DataSet ds = new DataSet();

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMPhysicochemicalTestMethodMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_RMPhysicochemicalTestMethodMaster_RMPreservativeMethodMaster()
        {
            try
            {
                DataSet ds = new DataSet();

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMPhysicochemicalTestMethodMaster_tblRMPreservativeMethodMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert_RMFDAPhysicoChemicalTestMethodMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMCodeID);
                myparam[1] = ModHelper.CreateParameter("@DescNo", SqlDbType.Int, 4, ParameterDirection.Input, DescNo);
                myparam[2] = ModHelper.CreateParameter("@NormsMin", SqlDbType.VarChar, 50, ParameterDirection.Input, NormsMin);
                myparam[3] = ModHelper.CreateParameter("@NormsMax", SqlDbType.VarChar, 50, ParameterDirection.Input, NormsMax);
                
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblRMFDAPhysicoChemicalTestMethodMaster", myparam);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert_RMFDAPreservativeMethodMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMCodeID);
                myparam[1] = ModHelper.CreateParameter("@Prsno", SqlDbType.Int, 4, ParameterDirection.Input, TestNo);
                myparam[2] = ModHelper.CreateParameter("@NormsMin", SqlDbType.VarChar, 50, ParameterDirection.Input, NormsMin);
                myparam[3] = ModHelper.CreateParameter("@NormsMax", SqlDbType.VarChar, 50, ParameterDirection.Input, NormsMax);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblRMFDAPreservativeMethodMaster", myparam);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Update_RMFDAPhysicoChemicalTestMethodMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMCodeID);
                myparam[1] = ModHelper.CreateParameter("@DescNo", SqlDbType.Int, 4, ParameterDirection.Input, DescNo);
                myparam[2] = ModHelper.CreateParameter("@NormsMin", SqlDbType.VarChar, 50, ParameterDirection.Input, NormsMin);
                myparam[3] = ModHelper.CreateParameter("@NormsMax", SqlDbType.VarChar, 50, ParameterDirection.Input, NormsMax);
                

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblRMFDAPhysicoChemicalTestMethodMaster", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Update_RMFDAPreservativeMethodMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMCodeID);
                myparam[1] = ModHelper.CreateParameter("@Prsno", SqlDbType.Int, 4, ParameterDirection.Input, TestNo);
                myparam[2] = ModHelper.CreateParameter("@NormsMin", SqlDbType.VarChar, 50, ParameterDirection.Input, NormsMin);
                myparam[3] = ModHelper.CreateParameter("@NormsMax", SqlDbType.VarChar, 50, ParameterDirection.Input, NormsMax);


                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblRMFDAPreservativeMethodMaster", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete_RMFDAPreservativeMethodMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMCodeID);
                myparam[1] = ModHelper.CreateParameter("@Prsno", SqlDbType.Int, 4, ParameterDirection.Input, TestNo);
                SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_Delete_tblRMFDAPreservativeMethodMaster", myparam);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_RMDescMaster_ParaNo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@ParaNo", SqlDbType.Int, 4, ParameterDirection.Input, rmparano);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMDescMaster_ParaNo", myparam);
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
