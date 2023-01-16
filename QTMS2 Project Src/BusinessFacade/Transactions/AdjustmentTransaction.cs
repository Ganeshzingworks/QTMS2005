using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DataFacade;
namespace BusinessFacade.Transactions
{
    public class AdjustmentTransaction
    {
        #region Properties
        private Nullable<short> PHFlag;

        public Nullable<short> phflag
        {
            get { return PHFlag; }
            set { PHFlag = value; }
        }
        private Nullable<short> ViscosityFlag;

        public Nullable<short> viscosityflag
        {
            get { return ViscosityFlag; }
            set { ViscosityFlag = value; }
        }
        private long FNo;

        public long fno
        {
            get { return FNo; }
            set { FNo = value; }
        }

        private int AdjDetailsId;

        public int adjdetailsid
        {
            get { return AdjDetailsId; }
            set { AdjDetailsId = value; }
        }

        private string MFGWO;

        public string mfgwo
        {
            get { return MFGWO; }
            set { MFGWO = value; }
        }
        private int BatchSize;

        public int batchsize
        {
            get { return BatchSize; }
            set { BatchSize = value; }
        }
        private DateTime AdjDate;

        public DateTime adjdate
        {
            get { return AdjDate; }
            set { AdjDate = value; }
        }
        private Nullable<long> RMSamplingID;

        public Nullable<long> rmsamplingid
        {
            get { return RMSamplingID; }
            set { RMSamplingID = value; }
        }
        private double InitialPHValue;

        public double initialphvalue
        {
            get { return InitialPHValue; }
            set { InitialPHValue = value; }
        }
        private double InitialVSValue;

        public double initialvsvalue
        {
            get { return InitialVSValue; }
            set { InitialVSValue = value; }
        }
        private long PHRMCodeID;

        public long phrmcodeid
        {
            get { return PHRMCodeID; }
            set { PHRMCodeID = value; }
        }
        private long VSRMCodeID;

        public long vsrmcodeid
        {
            get { return VSRMCodeID; }
            set { VSRMCodeID = value; }
        }
        private double TotalPHPercent;

        public double totalphpercent
        {
            get { return TotalPHPercent; }
            set { TotalPHPercent = value; }
        }

        //
        private int PHFlagIncrDecr;

        public int phflagincrdecr
        {
            get { return PHFlagIncrDecr; }
            set { PHFlagIncrDecr = value; }
        }
        private int VSFlagIncrDecr;

        public int vsflagincrdecr
        {
            get { return VSFlagIncrDecr; }
            set { VSFlagIncrDecr = value; }
        }
        //

        //
        private int PHRMCodeUpdate;

        public int phrmcodeupdate
        {
            get { return PHRMCodeUpdate; }
            set { PHRMCodeUpdate = value; }
        }

        private int PHVSCodeUpdate;

        public int phvscodeupdate
        {
            get { return PHVSCodeUpdate; }
            set { PHVSCodeUpdate = value; }
        }
        //

        private double TotalPHQty;

        public double totalphqty
        {
            get { return TotalPHQty; }
            set { TotalPHQty = value; }
        }
        private double TotalVSPercent;

        public double totalvspercent
        {
            get { return TotalVSPercent; }
            set { TotalVSPercent = value; }
        }
        private double TotalVSQty;

        public double totalvsqty
        {
            get { return TotalVSQty; }
            set { TotalVSQty = value; }
        }
        private double PHPercent;

        public double phpercent
        {
            get { return PHPercent; }
            set { PHPercent = value; }
        }
        private double PHQty;

        public double phqty
        {
            get { return PHQty; }
            set { PHQty = value; }
        }
        private double VSPercent;

        public double vspercent
        {
            get { return VSPercent; }
            set { VSPercent = value; }
        }
        private double VSQty;

        public double vsqty
        {
            get { return VSQty; }
            set { VSQty = value; }
        }
        private double PHObserved;

        public double phobserved
        {
            get { return PHObserved; }
            set { PHObserved = value; }
        }
        private double VSObserved;

        public double vsobserved
        {
            get { return VSObserved; }
            set { VSObserved = value; }
        }
        private long AdjID;

        public long adjid
        {
            get { return AdjID; }
            set { AdjID = value; }
        }

        private string WorkOrder;
        public string workorder
        {
            get { return WorkOrder; }
            set { WorkOrder = value; }
        }

        private string MethodNa;
        public string methodna
        {
            get { return MethodNa; }
            set { MethodNa = value; }
        }
        //
        private string Ident;
        public string ident
        {
            get { return Ident; }
            set { Ident = value; }
        }

        private string Result;
        public string result
        {
            get { return Result; }
            set { Result = value; }
        }
        private string Unit;
        public string unit
        {
            get { return Unit; }
            set { Unit = value; }
        }
        private string LastChange;
        public string lastchange
        {
            get { return LastChange; }
            set { LastChange = value; }
        }
        private short LFlag;
        public short lflag
        {
            get { return LFlag; }
            set { LFlag = value; }
        }
        #endregion

        #region Functions

        public bool Insert_tblLabXResults()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = ModHelper.CreateParameter("@WorkOrder", SqlDbType.NVarChar, 200, ParameterDirection.Input, workorder);
                param[1] = ModHelper.CreateParameter("@MethodName", SqlDbType.NVarChar, 100, ParameterDirection.Input, methodna);
                param[2] = ModHelper.CreateParameter("@Identification", SqlDbType.NVarChar, 100, ParameterDirection.Input, ident);
                param[3] = ModHelper.CreateParameter("@Result", SqlDbType.NVarChar, 50, ParameterDirection.Input, result);
                param[4] = ModHelper.CreateParameter("@Unit", SqlDbType.NVarChar, 50, ParameterDirection.Input, unit);
                param[5] = ModHelper.CreateParameter("@LastChange", SqlDbType.NVarChar, 50, ParameterDirection.Input, lastchange);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_LabxResults", param);
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert_tblLabXResults_First()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[7];
                param[0] = ModHelper.CreateParameter("@WorkOrder", SqlDbType.NVarChar, 200, ParameterDirection.Input, workorder);
                param[1] = ModHelper.CreateParameter("@MethodName", SqlDbType.NVarChar, 100, ParameterDirection.Input, methodna);
                param[2] = ModHelper.CreateParameter("@Identification", SqlDbType.NVarChar, 100, ParameterDirection.Input, ident);
                param[3] = ModHelper.CreateParameter("@Result", SqlDbType.NVarChar, 50, ParameterDirection.Input, result);
                param[4] = ModHelper.CreateParameter("@Unit", SqlDbType.NVarChar, 50, ParameterDirection.Input, unit);
                param[5] = ModHelper.CreateParameter("@LastChange", SqlDbType.NVarChar, 50, ParameterDirection.Input, lastchange);
                param[6] = ModHelper.CreateParameter("@Flag", SqlDbType.Bit, 1, ParameterDirection.Input, lflag);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_LabxResults_First", param);
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_RMTransaction_RMCode_Supplier_Lotno()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMTransaction_RMAnalysisReport");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_RMCodeMaster_PHFlag()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@PHFlag", SqlDbType.Bit, 1, ParameterDirection.Input, phflag);
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_RMCodeMaster_PHFlag", param).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Select_RMCodeMaster_ViscosityFlag()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@ViscosityFlag", SqlDbType.Bit, 1, ParameterDirection.Input, viscosityflag);
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_RMCodeMaster_ViscosityFlag", param).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public long Insert_tblAdjustment()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[7];
                param[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                param[1] = ModHelper.CreateParameter("@RMSamplingID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmsamplingid);
                //param[2] = ModHelper.CreateParameter("@PHFlag", SqlDbType.TinyInt, 2, ParameterDirection.Input, phflag);
                //param[3] = ModHelper.CreateParameter("@PHRMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, phrmcodeid);
                //param[4] = ModHelper.CreateParameter("@VSFlag", SqlDbType.TinyInt, 2, ParameterDirection.Input, viscosityflag);
                //param[5] = ModHelper.CreateParameter("@VSRMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, vsrmcodeid);
                param[2] = ModHelper.CreateParameter("@MfgWO", SqlDbType.VarChar, 200, ParameterDirection.Input, mfgwo);
                param[3] = ModHelper.CreateParameter("@BatchSize", SqlDbType.Int, 4, ParameterDirection.Input, batchsize);
                param[4] = ModHelper.CreateParameter("@InitialPHValue", SqlDbType.Float, 4, ParameterDirection.Input, initialphvalue);
                param[5] = ModHelper.CreateParameter("@InitialVSValue", SqlDbType.Float, 4, ParameterDirection.Input, initialvsvalue);
                param[6] = ModHelper.CreateParameter("@AdjDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, adjdate);
                //param[11] = ModHelper.CreateParameter("@AdjID", SqlDbType.BigInt, 8, ParameterDirection.Output, adjid);
                return Convert.ToInt64(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_Insert_tblAdjustment", param));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Insert_tblAdjustmentDetails_AdjID()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[11];
                param[0] = ModHelper.CreateParameter("@AdjID", SqlDbType.BigInt, 8, ParameterDirection.Input, adjid);
                param[1] = ModHelper.CreateParameter("@PHPercent", SqlDbType.Float, 4, ParameterDirection.Input, phpercent);
                param[2] = ModHelper.CreateParameter("@PHQty", SqlDbType.Float, 4, ParameterDirection.Input, phqty);
                param[3] = ModHelper.CreateParameter("@VSPercent", SqlDbType.Float, 4, ParameterDirection.Input, vspercent);
                param[4] = ModHelper.CreateParameter("@VSQty", SqlDbType.Float, 4, ParameterDirection.Input, vsqty);
                param[5] = ModHelper.CreateParameter("@PHObserved", SqlDbType.Float, 4, ParameterDirection.Input, phobserved);
                param[6] = ModHelper.CreateParameter("@VSObserved", SqlDbType.Float, 4, ParameterDirection.Input, vsobserved);
                param[7] = ModHelper.CreateParameter("@PHFlag", SqlDbType.TinyInt, 2, ParameterDirection.Input, phflagincrdecr);
                param[8] = ModHelper.CreateParameter("@PHRMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, phrmcodeupdate);
                param[9] = ModHelper.CreateParameter("@VSFlag", SqlDbType.TinyInt, 2, ParameterDirection.Input, vsflagincrdecr);
                param[10] = ModHelper.CreateParameter("@VSRMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, phvscodeupdate);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblAdjustmentDetails_AdjID", param);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete_tblAdjustmentDetails_AdjID()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@AdjID", SqlDbType.BigInt, 8, ParameterDirection.Input, adjid);
                int i = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblAdjustmentDetails_AdjID", param);
                if (i == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update_tblAdjustment_AdjID()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[8];

                param[0] = ModHelper.CreateParameter("@TotalPHPercent", SqlDbType.Float, 4, ParameterDirection.Input, totalphpercent);
                param[1] = ModHelper.CreateParameter("@TotalPHQty", SqlDbType.Float, 4, ParameterDirection.Input, totalphqty);
                param[2] = ModHelper.CreateParameter("@TotalVSPercent", SqlDbType.Float, 4, ParameterDirection.Input, totalvspercent);
                param[3] = ModHelper.CreateParameter("@TotalVSQty", SqlDbType.Float, 4, ParameterDirection.Input, totalvsqty);
                param[4] = ModHelper.CreateParameter("@FinalPHValue", SqlDbType.Float, 4, ParameterDirection.Input, phobserved);
                param[5] = ModHelper.CreateParameter("@FinalVSValue", SqlDbType.Float, 4, ParameterDirection.Input, vsobserved);
                param[6] = ModHelper.CreateParameter("@AdjID", SqlDbType.BigInt, 8, ParameterDirection.Input, adjid);
                param[7] = ModHelper.CreateParameter("@RMSamplingID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmsamplingid);
                //param[8] = ModHelper.CreateParameter("@PHFlag", SqlDbType.TinyInt, 4, ParameterDirection.Input, phflagincrdecr);
                //param[9] = ModHelper.CreateParameter("@VSFlag", SqlDbType.TinyInt, 4, ParameterDirection.Input, vsflagincrdecr);
                //param[10] = ModHelper.CreateParameter("@PHRMCodeID", SqlDbType.TinyInt, 4, ParameterDirection.Input, phrmcodeupdate);
                //param[11] = ModHelper.CreateParameter("@VSRMCodeID", SqlDbType.TinyInt, 4, ParameterDirection.Input, phvscodeupdate);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblAdjustment_AdjID ", param);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update_tblAdjustmentDetails_AdjID()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = ModHelper.CreateParameter("@AdjDetailsID", SqlDbType.BigInt, 8, ParameterDirection.Input, adjdetailsid);
                param[1] = ModHelper.CreateParameter("@AdjID", SqlDbType.BigInt, 8, ParameterDirection.Input, adjid);
                param[2] = ModHelper.CreateParameter("@PHObserved", SqlDbType.Float, 4, ParameterDirection.Input, phobserved);
                param[3] = ModHelper.CreateParameter("@VSObserved", SqlDbType.Float, 4, ParameterDirection.Input, vsobserved);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblAdjustmentDetails_AdjID ", param);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblAdjustment_fno_mfgwo_batchsize()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[3];
                param[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                param[1] = ModHelper.CreateParameter("@MfgWO", SqlDbType.VarChar, 200, ParameterDirection.Input, mfgwo);
                param[2] = ModHelper.CreateParameter("@BatchSize", SqlDbType.Int, 4, ParameterDirection.Input, batchsize);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblAdjustment_fno_mfgwo_batchsize", param);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Select_tblAdjustment_AdjID()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@AdjID", SqlDbType.BigInt, 8, ParameterDirection.Input, adjid);
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblAdjustmentDetails_AdjID", myparam).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_tblAdjustment_Details()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblAdjustment").Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable STP_Select_LabxResults_Flag() 
        {
            try
            {
                DataTable dt = new DataTable();
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_LabxResults_Flag").Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // This is used for to show initial PH & initial viscosity value
        public DataTable Select_RMSamplingID_AdjustmentHistory_RMSamplingID()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMSamplingID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmsamplingid);
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMSamplingID_AdjustmentHistory_RMSamplingID", myparam).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_LabxResults()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_LAbxResult").Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
