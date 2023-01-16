using System;
using System.Collections.Generic;
using System.Text;
using DataFacade;
using System.Data;
using System.Data.SqlClient;

namespace BusinessFacade.Transactions
{
    public class FDATransaction_Class
    {
        #region Variables
        private int LoginID;
        private int InspectedBy;
        private long FNo;
        private long FDAPhyMethodNo;
        private long FDAPresMethodNo;
        private long FDATransID;
        private long FMID;
        private char Status;
        private string NormsReading;
        private string NormsMin;
        private string NormsMax;
        private string PresFormula;
        private string WeightSample;
        private string WeightReference;
        private string AreaSample;
        private string AreaReference;
        private string VolumeSample;
        private string AssayConc;
        private char Decision;
        private bool FDADone;
        #endregion
        
        #region Properties
        public bool fdadone
        {
            get { return FDADone; }
            set { FDADone = value; }
        }

        public int loginid
        {
            get { return LoginID; }
            set { LoginID = value; }
        }

        public int inspectedby
        {
            get { return InspectedBy; }
            set { InspectedBy = value; }
        }


        public long fdaphymethodno
        {
            get { return FDAPhyMethodNo; }
            set { FDAPhyMethodNo = value; }
        }

        public long fdatransid
        {
            get { return FDATransID; }
            set { FDATransID = value; }
        }

        public string normsreading
        {
            get { return NormsReading; }
            set { NormsReading = value; }
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

        public char status
        {
            get { return Status; }
            set { Status = value; }
        }

        public char decision
        {
            get { return Decision; }
            set { Decision = value; }
        }


        public long fmid
        {
            get { return FMID; }
            set { FMID = value; }
        }

        public long fdapresmethodno
        {
            get { return FDAPresMethodNo; }
            set { FDAPresMethodNo = value; }
        }

        public long fno
        {
            get { return FNo; }
            set { FNo = value; }
        }

        #endregion

        #region Functions

        public DataSet Select_PendingFDADetails()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset("STP_Select_PendingFDADetails");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_ModificationFDADetails()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset("STP_Select_ModificationFDADetails");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_TransFM_FDAPhysicochemicalTestMethodMaster_FMID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, FMID);
                ds = SqlHelper.ExecuteDataset("STP_Select_tblTransFM_tblFDAPhysicochemicalTestMethodMaster_FMID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_FDAPhysicochemicalTestMethodMaster_TestMaster_Control_FMID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, FMID);
                ds = SqlHelper.ExecuteDataset("STP_Select_tblFDAPhysicochemicalTestMethodMaster_tblTestMaster_Control_FMID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //For Modification
        public DataSet Select_FDAPhysicochemicalTestMethodDetails_TestMaster_Control_FMID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, FMID);
                ds = SqlHelper.ExecuteDataset("STP_Select_tblFDAPhysicochemicalTestMethodDetails_tblTestMaster_Control_FMID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

        public DataSet Select_FDAPhysicochemicalTestMethodMaster_TestMaster_Identification_FMID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, @FMID);
                ds = SqlHelper.ExecuteDataset("STP_Select_tblFDAPhysicochemicalTestMethodMaster_tblTestMaster_Identification_FMID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //For Modification
        public DataSet Select_FDAPhysicochemicalTestMethodDetails_TestMaster_Identification_FMID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, @FMID);
                ds = SqlHelper.ExecuteDataset("STP_Select_tblFDAPhysicochemicalTestMethodDetails_tblTestMaster_Identification_FMID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_FDAPhysicochemicalTestMethodMaster_TestMaster_Analysis_FMID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, @FMID);
                ds = SqlHelper.ExecuteDataset("STP_Select_tblFDAPhysicochemicalTestMethodMaster_tblTestMaster_Analysis_FMID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //For Modification
        public DataSet Select_FDAPhysicochemicalTestMethodDetails_TestMaster_Analysis_FMID()            
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, @FMID);
                ds = SqlHelper.ExecuteDataset("STP_Select_tblFDAPhysicochemicalTestMethodDetails_tblTestMaster_Analysis_FMID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        

        public long Insert_tblFDATransaction()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[6];
                
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, FMID);
                myparam[1] = ModHelper.CreateParameter("@Status", SqlDbType.Char, 1, ParameterDirection.Input, Status);
                myparam[2] = ModHelper.CreateParameter("@Decision", SqlDbType.Char, 1, ParameterDirection.Input, Decision);
                myparam[3] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
                myparam[4] = ModHelper.CreateParameter("@FDATransID", SqlDbType.BigInt, 8, ParameterDirection.Output);
                myparam[5] = ModHelper.CreateParameter("@InspectedBy", SqlDbType.Int, 4, ParameterDirection.Input, inspectedby);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblFDATransaction", myparam);

                FDATransID = Convert.ToInt64(myparam[4].Value);

                return FDATransID;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean Update_tblFDATransaction()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[6];

                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, FMID);
                myparam[1] = ModHelper.CreateParameter("@Status", SqlDbType.Char, 1, ParameterDirection.Input, Status);
                myparam[2] = ModHelper.CreateParameter("@Decision", SqlDbType.Char, 1, ParameterDirection.Input, Decision);
                myparam[3] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
                myparam[4] = ModHelper.CreateParameter("@FDATransID", SqlDbType.BigInt, 8, ParameterDirection.Input ,fdatransid);
                myparam[5] = ModHelper.CreateParameter("@InspectedBy", SqlDbType.Int, 4, ParameterDirection.Input, inspectedby);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblFDATransaction", myparam);

                return true ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert_tblFDAPhysicoChemicalTestMethodDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[5];

                myparam[0] = ModHelper.CreateParameter("@FDATransID", SqlDbType.BigInt, 8, ParameterDirection.Input, FDATransID);
                myparam[1] = ModHelper.CreateParameter("@FDAPhyMethodNo", SqlDbType.BigInt, 8, ParameterDirection.Input, FDAPhyMethodNo);
                myparam[2] = ModHelper.CreateParameter("@NormsReading", SqlDbType.VarChar, 50, ParameterDirection.Input, NormsReading);
                myparam[3] = ModHelper.CreateParameter("@NormsMin", SqlDbType.VarChar, 50, ParameterDirection.Input, normsmin);
                myparam[4] = ModHelper.CreateParameter("@NormsMax", SqlDbType.VarChar, 50, ParameterDirection.Input, normsmax);              

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblFDAPhysicoChemicalTestMethodDetails", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert_tblFDAPreservativeTestMethodDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[12];
                myparam[0] = ModHelper.CreateParameter("@FDATransID", SqlDbType.BigInt, 8, ParameterDirection.Input, FDATransID);
                myparam[1] = ModHelper.CreateParameter("@FDAPresMethodNo", SqlDbType.BigInt, 8, ParameterDirection.Input, FDAPresMethodNo);
                myparam[2] = ModHelper.CreateParameter("@NormsReading", SqlDbType.VarChar, 50, ParameterDirection.Input, NormsReading);
                myparam[3] = ModHelper.CreateParameter("@NormsMin", SqlDbType.VarChar, 50, ParameterDirection.Input, normsmin);
                myparam[4] = ModHelper.CreateParameter("@NormsMax", SqlDbType.VarChar, 50, ParameterDirection.Input, normsmax);
                myparam[5] = ModHelper.CreateParameter("@PresFormula", SqlDbType.VarChar, 50, ParameterDirection.Input, presformula);
                myparam[6] = ModHelper.CreateParameter("@WeightSample", SqlDbType.VarChar, 50, ParameterDirection.Input, weightsample);
                myparam[7] = ModHelper.CreateParameter("@WeightReference", SqlDbType.VarChar, 50, ParameterDirection.Input, weightreference);
                myparam[8] = ModHelper.CreateParameter("@AreaSample", SqlDbType.VarChar, 50, ParameterDirection.Input, areasample);
                myparam[9] = ModHelper.CreateParameter("@AreaReference", SqlDbType.VarChar, 50, ParameterDirection.Input, areareference);
                myparam[10] = ModHelper.CreateParameter("@VolumeSample", SqlDbType.VarChar, 50, ParameterDirection.Input, volumesample);
                myparam[11] = ModHelper.CreateParameter("@AssayConc", SqlDbType.VarChar, 50, ParameterDirection.Input, assayconc);  
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblFDAPreservativeTestMethodDetails", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_FDATransaction_FMID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, FMID);
                ds = SqlHelper.ExecuteDataset("STP_Select_tblFDATransaction_FMID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_FDATransactionDetails_FMID()
        {
            try
            {
                DataTable Dt;
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, FMID);
                Dt = SqlHelper.ExecuteDataset("STP_Select_FDATransactionDetails_FMID", myparam).Tables[0];
                return Dt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //To read Status ,Decision ,InspectedBy from tblFDATransaction
        public DataTable Select_FDATransactionStatus_FMID()
        {
            try
            {
                DataTable Dt = new DataTable();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, FMID);
                Dt = SqlHelper.ExecuteDataset("STP_Select_tblFDATransactionStatus_FMID", myparam).Tables[0];
                if (Dt.Rows.Count == 0)
                {
                    throw new Exception("Pease select the details..");
                }
                else if (Dt.Rows.Count == 1)
                {
                    return Dt;
                }
                else
                {
                   throw new Exception("Multiple record found for selected value");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete_tblFDAPhysicoChemicalTestMethodDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];

                myparam[0] = ModHelper.CreateParameter("@FDATransID", SqlDbType.BigInt, 8, ParameterDirection.Input, fdatransid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblFDAPhysicoChemicalTestMethodDetails", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete_tblFDAPreservativeTestMethodDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];

                myparam[0] = ModHelper.CreateParameter("@FDATransID", SqlDbType.BigInt, 8, ParameterDirection.Input, fdatransid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblFDAPreservativeTestMethodDetails", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update_tblTransFM_FDADone()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                myparam[1] = ModHelper.CreateParameter("@FDADone", SqlDbType.Bit, 1, ParameterDirection.Input, fdadone);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblTransFM_FDADone", myparam);
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
