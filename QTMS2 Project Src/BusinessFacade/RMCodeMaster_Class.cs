using System;
using System.Collections.Generic;
using System.Text;
using DataFacade;
using System.Data;
using System.Data.SqlClient;

namespace BusinessFacade
{
    public class RMCodeMaster_Class
    {
        # region Varibles
        private string RMCode;
        private string X3Barcode;
        private string RMDescription;
        private string RMINCIName;
        private long RMSupplierID;
        private long RMFamilyID;
        private char RMMicro;
        private string RMSpecification;
        private char RMType;
        private string RMSupplierName;
        private string RMAgentName;
        private long RMCodeID;
        private Int16 PreservativeTest;
        private Int16 MicrobiologyTest;
        private Int16 FDADone;
        private string MicroNorms;
        private string CreationDate;
        private string ModificationDate;
        private string MicroSpecDate;
        private string IsAligned;
        private string Barcode;
         
        private string Halal; 
        private string PlantOrigin;
        private string Countryoforigin;
        private long RMCategoryID;
        private long CreatedBy;
        private long ModifiedBy;
        private string TradeName;
        # endregion

        # region Properties

        public string creationdate
        {
            get { return CreationDate; }
            set { CreationDate = value; }
        }

        public string modificationdate
        {
            get { return ModificationDate; }
            set { ModificationDate = value; }
        }

        public string microspecdate
        {
            get { return MicroSpecDate; }
            set { MicroSpecDate = value; }
        }

        public string micronorms
        {
            get { return MicroNorms; }
            set { MicroNorms = value; }
        }

        public Int16 preservativetest
        {
            get { return PreservativeTest; }
            set { PreservativeTest = value; }
        }

        public Int16 microbiologytest
        {
            get { return MicrobiologyTest; }
            set { MicrobiologyTest = value; }
        }


        public Int16 fdadone
        {
            get { return FDADone; }
            set { FDADone = value; }
        }


        public string rmcode
        {
            get { return RMCode; }
            set { RMCode = value; }
        }
        public string x3Barcode
        {
            get { return X3Barcode; }
            set { X3Barcode = value; }
        }
        
        public long rmcodeid
        {
            get { return RMCodeID; }
            set { RMCodeID = value; }
        }
        public string rmdescription
        {
            get { return RMDescription; }
            set { RMDescription = value; }
        }
        public string rminciname
        {
            get { return RMINCIName; }
            set { RMINCIName = value; }
        }

        public long rmsupplierid
        {
            get { return RMSupplierID; }
            set { RMSupplierID = value; }
        }
        public long rmfamilyid
        {
            get { return RMFamilyID; }
            set { RMFamilyID = value; }
        }
        public char rmmicro
        {
            get { return RMMicro; }
            set { RMMicro = value; }
        }
        public string rmspecification
        {
            get { return RMSpecification; }
            set { RMSpecification = value; }
        }
        public char rmtype
        {
            get { return RMType; }
            set { RMType = value; }
        }
        public string rmsuppliername
        {
            get { return RMSupplierName; }
            set { RMSupplierName = value; }
        }
        public string rmagentname
        {
            get { return RMAgentName; }
            set { RMAgentName = value; }
        }

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
        public string isAligned
        {
            get { return IsAligned; }
            set { IsAligned = value; }
        
        }

        public string barcode 
        {
            get { return Barcode; }
            set { Barcode = value; }
        }

        public string halal  
        {
            get { return Halal; }
            set { Halal = value; }

        }

        public string plantOrigin 
        {
            get { return PlantOrigin; }
            set { PlantOrigin = value; }

        }
        public string countryoforigin  
        {
            get { return Countryoforigin; }
            set { Countryoforigin = value; }

        }
        public long rmcategoryid
        {
            get { return RMCategoryID; }
            set { RMCategoryID = value; }
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
        public string tradename
        {
            get { return TradeName; }
            set { TradeName = value; }
        }
        #endregion

        #region Functions
        public bool Insert_RMSupplierAgentMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[10];
                myparam[0] = ModHelper.CreateParameter("@RMSupplierID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMSupplierID);
                myparam[1] = ModHelper.CreateParameter("@RMAgentName", SqlDbType.VarChar, 200, ParameterDirection.Input, RMAgentName);
                myparam[2] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMCodeID);
                myparam[3] = ModHelper.CreateParameter("@IsAligned", SqlDbType.VarChar, 50, ParameterDirection.Input, isAligned);
                myparam[4] = ModHelper.CreateParameter("@Halal", SqlDbType.VarChar, 50, ParameterDirection.Input, Halal);
                myparam[5] = ModHelper.CreateParameter("@PlantOrigin", SqlDbType.VarChar, 50, ParameterDirection.Input, PlantOrigin);
                myparam[6] = ModHelper.CreateParameter("@countryoforigin", SqlDbType.VarChar, 50, ParameterDirection.Input, Countryoforigin);
                myparam[7] = ModHelper.CreateParameter("@Barcode", SqlDbType.NVarChar,int.MaxValue, ParameterDirection.Input, barcode);
                myparam[8] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, createdby);
                myparam[9] = ModHelper.CreateParameter("@TradeName", SqlDbType.VarChar, 200, ParameterDirection.Input, tradename);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblRMSupplierAgentMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public bool Insert_RMCodeMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[16];
                myparam[0] = ModHelper.CreateParameter("@RMCode", SqlDbType.VarChar, 50, ParameterDirection.Input, RMCode);
                myparam[1] = ModHelper.CreateParameter("@RMDescription", SqlDbType.VarChar, 200, ParameterDirection.Input, RMDescription);
                myparam[2] = ModHelper.CreateParameter("@RMINCIName", SqlDbType.VarChar, 100, ParameterDirection.Input, RMINCIName);                
                myparam[3] = ModHelper.CreateParameter("@RMFamilyID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMFamilyID);                
                myparam[4] = ModHelper.CreateParameter("@RMSpecification", SqlDbType.VarChar, 200, ParameterDirection.Input, RMSpecification);                
                myparam[5] = ModHelper.CreateParameter("@PreservativeTest", SqlDbType.TinyInt, 1, ParameterDirection.Input, preservativetest);
                myparam[6] = ModHelper.CreateParameter("@MicrobiologyTest", SqlDbType.TinyInt, 1, ParameterDirection.Input, microbiologytest);
                myparam[7] = ModHelper.CreateParameter("@MicroNorms", SqlDbType.VarChar,250, ParameterDirection.Input, micronorms);
                myparam[8] = ModHelper.CreateParameter("@FDADone", SqlDbType.TinyInt, 1, ParameterDirection.Input, fdadone);
                myparam[9] = ModHelper.CreateParameter("@CreationDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, creationdate);
                myparam[10] = ModHelper.CreateParameter("@ModificationDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, modificationdate);
                myparam[11] = ModHelper.CreateParameter("@MicroSpecDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, microspecdate);
                myparam[12] = ModHelper.CreateParameter("@PHFlag", SqlDbType.Bit, 1, ParameterDirection.Input, phflag);
                myparam[13] = ModHelper.CreateParameter("@ViscosityFlag", SqlDbType.Bit, 1, ParameterDirection.Input, viscosityflag);
                myparam[14] = ModHelper.CreateParameter("@X3Barcode", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, x3Barcode);
                myparam[15] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, createdby);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblRMCodeMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update_RMCodeMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[16];
                myparam[0] = ModHelper.CreateParameter("@RMCode", SqlDbType.VarChar, 50, ParameterDirection.Input, RMCode);        
                myparam[1] = ModHelper.CreateParameter("@RMDescription", SqlDbType.VarChar, 200, ParameterDirection.Input, RMDescription);
                myparam[2] = ModHelper.CreateParameter("@RMINCIName", SqlDbType.VarChar, 100, ParameterDirection.Input, RMINCIName);
                myparam[3] = ModHelper.CreateParameter("@RMFamilyID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMFamilyID);                
                myparam[4] = ModHelper.CreateParameter("@RMSpecification", SqlDbType.VarChar, 200, ParameterDirection.Input, RMSpecification);                
                myparam[5] = ModHelper.CreateParameter("@PreservativeTest", SqlDbType.TinyInt, 1, ParameterDirection.Input, preservativetest);
                myparam[6] = ModHelper.CreateParameter("@MicrobiologyTest", SqlDbType.TinyInt, 1, ParameterDirection.Input, microbiologytest);
                myparam[7] = ModHelper.CreateParameter("@MicroNorms", SqlDbType.VarChar, 250, ParameterDirection.Input, micronorms);                
                myparam[8] = ModHelper.CreateParameter("@FDADone", SqlDbType.TinyInt, 1, ParameterDirection.Input, fdadone);
                myparam[9] = ModHelper.CreateParameter("@CreationDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, creationdate);
                myparam[10] = ModHelper.CreateParameter("@ModificationDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, modificationdate);
                myparam[11] = ModHelper.CreateParameter("@MicroSpecDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, microspecdate);
                myparam[12] = ModHelper.CreateParameter("@PHFlag", SqlDbType.Bit, 1, ParameterDirection.Input, phflag);
                myparam[13] = ModHelper.CreateParameter("@ViscosityFlag", SqlDbType.Bit, 1, ParameterDirection.Input, viscosityflag);
                myparam[14] = ModHelper.CreateParameter("@X3Barcode", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, x3Barcode);
                myparam[15] = ModHelper.CreateParameter("@ModifiedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, modifiedby);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblRMCodeMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
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
        public DataSet Select_RMCategory()
        {
            try
            {
                DataSet ds = new DataSet();

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMCategoryMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_RMCodeMaster_RMCode()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.VarChar, 50, ParameterDirection.Input,RMCodeID );
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMCodeMaster_RMCode", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete_RMCodeMaster_RMCodeID()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMCodeID);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblRMCodeMaster_RMCodeID", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete_RMSupplierAgentMaster_RMCodeID()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMCodeID);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblRMSupplierAgentMaster_RMCodeID", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool Delete_RMSupplierAgentMaster_RMCodeID_RMSupplierID_RMAgentName()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMCodeID);
                myparam[1] = ModHelper.CreateParameter("@RMSupplierID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMSupplierID);
                myparam[2] = ModHelper.CreateParameter("@RMAgentName", SqlDbType.VarChar, 200, ParameterDirection.Input, RMAgentName);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblRMSupplierAgentMaster_RMCodeID_RMSupplierID_RMAgentName", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet Select_RMCodeMaster_RMCodeID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMCode", SqlDbType.VarChar, 50, ParameterDirection.Input, RMCode);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMCodeMaster_RMCodeID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_RMSupplierAgentMaster_RMSupplierMaster_RMCodeID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMCodeID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMSupplierAgentMaster_tblRMSupplierMaster_RMCodeID_FORSupplierAgent", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_RMSupplierAgentMaster_RMSupplierMaster_RMCodeID2()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMCodeID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMSupplierAgentMaster_tblRMSupplierMaster_RMCodeID2", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public long Select_RMtotalNoOfLot()
        //{

        //    try
        //    {
        //        SqlParameter[] myparam = new SqlParameter[1];
        //        myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMCodeID);
        //        long count = 0;

        //    }
        //    catch (Exception)
        //    {
                
        //        throw;
        //    }
        
        
        //}
        #endregion

        public DataSet Select_All_Record_tblRMCodeMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "SP_Select_All_tblRMCodeMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet RMCodeReport(long RMCodeID, string halal) 
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@RMCode", SqlDbType.BigInt, 8, ParameterDirection.Input, RMCodeID);
                myparam[1] = ModHelper.CreateParameter("@Halal", SqlDbType.VarChar, 50, ParameterDirection.Input, halal);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_RMcode_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool INSERT_tblRMCodeLinkCategory()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmcodeid);
                myparam[1] = ModHelper.CreateParameter("@RMCategoryID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmcategoryid);
                myparam[2] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, createdby);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_INSERT_tblRMCodeLinkCategory", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool DELETE_tblRMCodeLinkCategory()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmcodeid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblRMCodeLinkCategory", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblRMCodeLinkCategory_RMCodeID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmcodeid);
              
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMCodeLinkCategory_RMCodeID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
