using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using DataFacade;
using System.Data.SqlClient;

namespace BusinessFacade.Transactions
{
    public class ReagentTransaction_Class
    {

        #region variables
        private long ReagentTransID;
        private long ReagentID;
        private string SupplierName;
        private string ReagentLotNo;
        private DateTime ReceiveDate;
        private double QtyPerUnit;
        private string  Unit;
        private double NumOfUnit;
        private double TotalQty; 
        private double ReagentNormality;
        private string NormalityUnit;
        private int LoginID;
        private SqlTransaction Trans;

        private long POID;
        private DateTime MfgDate;
        private DateTime ValidityDate;
        private string Comments;
        private long InspectedBy;

        private long COAID;
        private string COAFile;

        #endregion


        #region Properties

        public string coafile
        {
            get { return COAFile; }
            set { COAFile = value; }
        }
        public long coaid
        {
            get { return COAID; }
            set { COAID = value; }
        }
        public long inspectedby
        {
            get { return InspectedBy; }
            set { InspectedBy = value; }
        }
        public string comments
        {
            get { return Comments; }
            set { Comments = value; }
        }
        public DateTime validatedate
        {
            get { return ValidityDate; }
            set { ValidityDate = value; }
        }
        public DateTime mfgdate
        {
            get { return MfgDate; }
            set { MfgDate = value; }
        }

        public long poid
        {
            get { return POID; }
            set { POID = value; }
        }

        public long reagenttransid
        {
            get { return ReagentTransID; }
            set { ReagentTransID = value; }
        }

        public long reagentid
        {
            get { return ReagentID; }
            set { ReagentID = value; }
        }

        public string  suppliername
        {
            get { return SupplierName; }
            set { SupplierName = value; }
        }

        public string  reagentlotno
        {
            get { return ReagentLotNo; }
            set { ReagentLotNo = value; }
        }

        public DateTime  receivedate
        {
            get { return ReceiveDate; }
            set { ReceiveDate = value; }
        }

        public double  qtyperunit
        {
            get { return QtyPerUnit; }
            set { QtyPerUnit = value; }
        }
    
         

        public string  unit
        {
            get { return Unit; }
            set { Unit = value; }
        }

        public double totalqty
        {
            get { return TotalQty; }
            set { TotalQty = value; }
        }
        public double numofunit
        {
            get { return NumOfUnit; }
            set { NumOfUnit = value; }
        }
        
        public double reagentnormality
        {
            get { return ReagentNormality; }
            set { ReagentNormality = value; }
        }

        public string  normalityunit
        {
            get { return NormalityUnit; }
            set { NormalityUnit = value; }
        }

        public int loginid
        {
            get { return LoginID; }
            set { LoginID = value; }
        }
      

        public SqlTransaction trans
        {
            get { return Trans; }
            set { Trans = value; }
        }
       

        #endregion


        #region Functions
        public DataSet Select_tblReagent_Unit()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblReagentUnit");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblReagent_RACode()
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

        public DataSet Select_tblReagentMaster_ReagentName()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@ReagentID", SqlDbType.BigInt, 8, ParameterDirection.Input, reagentid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblReagentMAster_ReagentName", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Insert_tblReagentTransaction()
        {
            try
            {
                int active = 1;
                int OutTransID; ;

                SqlParameter[] myparam = new SqlParameter[19];
                myparam[0] = ModHelper.CreateParameter("@ReagentID", SqlDbType.BigInt , 8, ParameterDirection.Input, reagentid );
                myparam[1] = ModHelper.CreateParameter("@SupplierName", SqlDbType.VarChar, 250, ParameterDirection.Input, suppliername );
                myparam[2] = ModHelper.CreateParameter("@ReagentLotNo", SqlDbType.VarChar, 250, ParameterDirection.Input, reagentlotno );
                myparam[3] = ModHelper.CreateParameter("@ReceiveDate", SqlDbType.DateTime, 8, ParameterDirection.Input, receivedate );
                myparam[4] = ModHelper.CreateParameter("@QtyPerUnit", SqlDbType.Decimal, 8, ParameterDirection.Input, qtyperunit );
                myparam[5] = ModHelper.CreateParameter("@Unit", SqlDbType.VarChar, 250, ParameterDirection.Input, unit);
                myparam[6] = ModHelper.CreateParameter("@NumOfUnit", SqlDbType.Decimal , 8, ParameterDirection.Input, numofunit);
                myparam[7] = ModHelper.CreateParameter("@TotalQty", SqlDbType.Decimal, 8, ParameterDirection.Input, totalqty);
                myparam[8] = ModHelper.CreateParameter("@ReagentNormality", SqlDbType.Float , 4, ParameterDirection.Input, reagentnormality );
                myparam[9] = ModHelper.CreateParameter("@NormalityUnit", SqlDbType.VarChar, 250, ParameterDirection.Input, normalityunit );
                myparam[10] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
                myparam[11] = ModHelper.CreateParameter("@ModifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, DBNull.Value);
                myparam[12] = ModHelper.CreateParameter("@ModifiedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, DBNull.Value);

                myparam[13] = ModHelper.CreateParameter("@POID", SqlDbType.BigInt, 8, ParameterDirection.Input, poid);
                myparam[14] = ModHelper.CreateParameter("@MfgDate", SqlDbType.DateTime, 8, ParameterDirection.Input, mfgdate);
                myparam[15] = ModHelper.CreateParameter("@ValidityDate", SqlDbType.DateTime, 8, ParameterDirection.Input, validatedate);
                myparam[16] = ModHelper.CreateParameter("@Comments", SqlDbType.VarChar, 4000, ParameterDirection.Input, comments);
                myparam[17] = ModHelper.CreateParameter("@InspectedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, inspectedby);

                myparam[18] = ModHelper.CreateParameter("@OutTransID", SqlDbType.Int, 8, ParameterDirection.Output);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblReagentTransaction", myparam);
                OutTransID = Convert.ToInt32(myparam[18].Value);
                return OutTransID  ;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet  Select_tblReagenMaster_tblReagentTransaction_RACode()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblReagentTransaction_ReagentTransID");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblReagentTransaction_Details()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@ReagentTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, reagenttransid);
                myparam[1] = ModHelper.CreateParameter("@ReagentID", SqlDbType.BigInt, 8, ParameterDirection.Input, reagentid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_Record_tblReagentTransaction", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update_tblReagentTransaction()
        {
            try
            {

                int active = 1;

                SqlParameter[] myparam = new SqlParameter[12];
                myparam[0] = ModHelper.CreateParameter("@ReagentTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, reagenttransid);
                myparam[1] = ModHelper.CreateParameter("@QtyPerUnit", SqlDbType.Decimal, 8, ParameterDirection.Input, qtyperunit);
                myparam[2] = ModHelper.CreateParameter("@Unit", SqlDbType.VarChar, 250, ParameterDirection.Input, unit);
                myparam[3] = ModHelper.CreateParameter("@NumOfUnit", SqlDbType.Decimal, 8, ParameterDirection.Input, numofunit);
                myparam[4] = ModHelper.CreateParameter("@TotalQty", SqlDbType.Decimal, 8, ParameterDirection.Input, totalqty);
                myparam[5] = ModHelper.CreateParameter("@ReagentNormality", SqlDbType.Float, 250, ParameterDirection.Input, reagentnormality);
                myparam[6] = ModHelper.CreateParameter("@NormalityUnit", SqlDbType.VarChar, 250, ParameterDirection.Input, normalityunit);
                myparam[7] = ModHelper.CreateParameter("@ModifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
                myparam[8] = ModHelper.CreateParameter("@MfgDate", SqlDbType.DateTime, 8, ParameterDirection.Input, mfgdate);
                myparam[9] = ModHelper.CreateParameter("@ValidityDate", SqlDbType.DateTime, 8, ParameterDirection.Input, validatedate);
                myparam[10] = ModHelper.CreateParameter("@InspectedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, inspectedby);
                myparam[11] = ModHelper.CreateParameter("@Comments", SqlDbType.VarChar, 4000, ParameterDirection.Input, comments);
                
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblReagentTransaction", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


       

        public void Insert_tblReagentBottle(int BottleNo, int OutTransID)
        {
            try
            {
                int active = 1;
                int isStanderdised = 0;

                SqlParameter[] myparam = new SqlParameter[8];

                myparam[0] = ModHelper.CreateParameter("@ReagentTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, OutTransID);
                myparam[1] = ModHelper.CreateParameter("@BottleNo", SqlDbType.Int, 4, ParameterDirection.Input, BottleNo);
                myparam[2] = ModHelper.CreateParameter("@IsConsumed", SqlDbType.Int, 4, ParameterDirection.Input, DBNull.Value);
                myparam[3] = ModHelper.CreateParameter("@IsStandardised", SqlDbType.Int, 4, ParameterDirection.Input, isStanderdised);
                myparam[4] = ModHelper.CreateParameter("@ConsumptionDate", SqlDbType.DateTime, 8, ParameterDirection.Input, DBNull.Value);
                myparam[5] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
                myparam[6] = ModHelper.CreateParameter("@ModifiedBy", SqlDbType.Int, 4, ParameterDirection.Input, DBNull.Value);
                myparam[7] = ModHelper.CreateParameter("@ModifiedDate", SqlDbType.DateTime, 8, ParameterDirection.Input, DBNull.Value);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_tblReagentBottle", myparam);
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public DataSet Check_tblReagenTransaction_lotNo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@ReagentID", SqlDbType.BigInt, 8, ParameterDirection.Input, reagentid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_tblReagentTransaction_Check_Duplicate", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_LotNos()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@ReagentID", SqlDbType.BigInt, 8, ParameterDirection.Input, reagentid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblReagentTransaction_LotNo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

         

        public DataSet GetBottleCOunt(int transID)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@ReagentTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, transID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblReagentBottle_Count", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetStdCOunt(int transID)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@ReagentTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, transID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblReagentBottle_Consume_Count", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete_NonStd_ByTransID(int transID)
        {
            try
            {
               

                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@ReagentTransID", SqlDbType.VarChar, 250, ParameterDirection.Input, transID);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblReagentBottle", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateNumOfBottle(int BottleCount ,int transID)
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@NumOfUnit", SqlDbType.VarChar, 250, ParameterDirection.Input, BottleCount);
                myparam[1] = ModHelper.CreateParameter("@ReagentTransID", SqlDbType.VarChar, 250, ParameterDirection.Input, transID);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_NumOfUnit_tblReagentTransaction", myparam);
               
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public bool Update_tblReagentTransaction_ActiveFlag(long TransactionID)
        {
            try
            {


                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@ReagentTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, TransactionID);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblReagentTransaction_ActiveFlag", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet tblReagentBottle_CheckDelete_Count(long ReagentTransID)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@ReagentTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, ReagentTransID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_tblReagentBottle_CheckDelete_Count", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert_tblReagentCOAFile(long OutTransID)
        {
            try
            {              
                SqlParameter[] myparam = new SqlParameter[4];

                myparam[0] = ModHelper.CreateParameter("@ReagentTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, OutTransID);
                myparam[1] = ModHelper.CreateParameter("@ReagentID", SqlDbType.Int, 4, ParameterDirection.Input, ReagentID);
                myparam[2] = ModHelper.CreateParameter("@LotNumber", SqlDbType.VarChar, 200, ParameterDirection.Input, ReagentLotNo);
                myparam[3] = ModHelper.CreateParameter("@COAFile", SqlDbType.VarChar, 4000, ParameterDirection.Input, coafile);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblReagentCOAFile", myparam);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Check_LotNumber(string lotnumber)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@LotNumber", SqlDbType.VarChar, 200, ParameterDirection.Input, lotnumber);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Check_LotNumber", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet ReagentPrintLabel_Report(long ReagentTransID)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@ReagentTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, ReagentTransID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Reagent_LabelPrint", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet CheckReagentTransaction_Exists()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@ReagentID", SqlDbType.BigInt, 8, ParameterDirection.Input, reagentid);
                myparam[1] = ModHelper.CreateParameter("@LotNumber", SqlDbType.VarChar, 150, ParameterDirection.Input, reagentlotno);
                myparam[2] = ModHelper.CreateParameter("@POID", SqlDbType.BigInt, 8, ParameterDirection.Input, poid);
                myparam[3] = ModHelper.CreateParameter("@ReceiveDate", SqlDbType.DateTime, 8, ParameterDirection.Input, receivedate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_CheckReagentTransaction_Exists", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_ModificationReagentTransaction()
        {
            try
            {
                DataSet ds = new DataSet();              
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_ModificationReagentTransaction");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_ReagentTransactionDetails()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@ReagentTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, reagenttransid);            
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_ReagentTransactionDetails", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_ConsumptionReagentTransaction()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_ConsumptionReagentTransaction");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
