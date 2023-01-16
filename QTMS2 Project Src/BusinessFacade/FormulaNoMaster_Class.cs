using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;
namespace BusinessFacade
{
   public class FormulaNoMaster_Class
   {
       # region Variables
       private string FormulaNo;
       private int TechFamNo;
       private string BulkDesc;
       private decimal Density;
       private int NoOfBatches;
       private string OfficializationNo;
       private string ReferenceDate;
       private Int16 PreservativeTest;
       private Int16 MicrobiologyTest;
       private string Norms;
       private long FNo;
       private Int16 pHLevel;
       private Int16 H2O2Level;
       private Int16 DyeTest;
       private int TestNo;
       private string Min;
       private string Max;
       private string FormulaType;
       private int Deactive;
       private string CreationDate;
       private string ModificationDate;
       private int ExtLabReport;
       private int Del;
       private string FType;
       private string FDAApprovalDate;
       private string FILCode;
       private int CreatedBy;
       private string BacterialCount;
       private string FungalCount;
       private string FDAApprovalDateExport;
       # endregion

       # region Properties
       public string filcode
       {
           get { return FILCode; }
           set { FILCode = value; }
       }
       
       public string fdaapprovaldate
       {
           get { return FDAApprovalDate; }
           set { FDAApprovalDate = value; }
       }

       public string ftype
       {
           get { return FType; }
           set { FType = value; }
       }
       public int del
       {
           get { return Del; }
           set { Del = value; }
       }
       public int extlabreport
       {
           get { return ExtLabReport; }
           set { ExtLabReport = value; }
       }
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
       public int deactive
       {
           get { return Deactive; }
           set { Deactive = value; }
       }
       public Int16 phlevel
       {
           get { return pHLevel; }
           set { pHLevel = value; }
       }
       public Int16 h2o2level
       {
           get { return H2O2Level; }
           set { H2O2Level = value; }
       }
       public Int16 dyetest
       {
           get { return DyeTest; }
           set { DyeTest = value; }
       }
      
       public long fno
       {
           get { return FNo; }
           set { FNo = value; }
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
       public string norms
       {
           get { return Norms; }
           set { Norms = value; }
       }
       public string formulano
       {
           get { return FormulaNo; }
           set { FormulaNo = value; }
       }
       public string bulkdesc
       {
           get { return BulkDesc; }
           set { BulkDesc = value; }
       }
       public int techfamno
       {
           get { return TechFamNo; }
           set { TechFamNo = value; }
       }
       public decimal density
       {
           get { return Density; }
           set { Density = value; }
       }
       public int noofbatches
       {
           get { return NoOfBatches; }
           set { NoOfBatches = value; }
       }
       public string officializationno
       {
           get { return OfficializationNo; }
           set { OfficializationNo = value; }
       }
       public string referencedate
       {
           get { return ReferenceDate; }
           set { ReferenceDate = value; }
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
       public string formulatype
       {
           get { return FormulaType; }
           set { FormulaType = value; }
       }
       public int createdby
       {
           get { return CreatedBy; }
           set { CreatedBy = value; }
       }
       public string bacterialcount
       {
           get { return BacterialCount; }
           set { BacterialCount = value; }
       }
       public string fungalcount
       {
           get { return FungalCount; }
           set { FungalCount = value; }
       }
       public string fdaapprovaldateexport
       {
           get { return FDAApprovalDateExport; }
           set { FDAApprovalDateExport = value; }
       }
       # endregion
       # region Functions
       public DataSet SELECT_FormulaNo_Preservative()
       {
           try
           {
               DataSet ds = new DataSet();
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_FormulaNo_Preservative");
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }

       }
       public DataSet Select_TblBulkMaster()
       {
           try
           {
               DataSet ds = new DataSet();
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_TblBulkMaster");
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }

       }
       public DataSet SELECT_TblBulkMaster_Active()
       {
           try
           {
               DataSet ds = new DataSet();
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_TblBulkMaster_Active");
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }

       }
       public DataSet Select_From_TblBulkMaster_By_FormulaNo()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@FormulaNo", SqlDbType.VarChar, 200, ParameterDirection.Input, formulano);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_TblBulkMaster_FormulaNo", myparam);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;

           }

       }
       public DataSet SELECT_TblBulkMaster_tblblkfamilyMaster()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.VarChar, 200, ParameterDirection.Input, fno);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_TblBulkMaster_tblblkfamilyMaster", myparam);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public DataSet Select_From_TblBulkMaster_By_FNo()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_TblBulkMaster_FNo", myparam);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;

           }
       }

       // This function is used for Reference date enabled false if transaction is done from Reference sample mgmt
       public DataTable Select_BulkMaster_RSMgmt_FNo()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblBulkMaster_RSMgmt_FNo", myparam);
               return ds.Tables[0];
           }
           catch (Exception ex)
           {
               throw ex;

           }
       }

       public DataSet SELECT_tblLineTestMethodMaster_FNo()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblLineTestMethodMaster_FNo", myparam);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;

           }

       }

       public DataSet SELECT_tblBulkPhysicochemicalTestMethodMaster_FNo()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblBulkPhysicochemicalTestMethodMaster_FNo", myparam);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;

           }

       }
       // Using For compatibility
       public DataSet SELECT_BulkPhysicochemicalTestMethodMaster_tblTestMaster_FNo()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblBulkPhysicochemicalTestMethodMaster_tblTestMaster_FNo", myparam);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;

           }

       }
       public long Insert_BulkMaster()
       {
           try
           {
               SqlParameter[] myaparam = new SqlParameter[22];
               myaparam[0] = ModHelper.CreateParameter("@FormulaNo", SqlDbType.NVarChar, 200, ParameterDirection.Input, formulano);
               myaparam[1] = ModHelper.CreateParameter("@TechFamNo", SqlDbType.Int, 4, ParameterDirection.Input, techfamno);
               myaparam[2] = ModHelper.CreateParameter("@BulkDesc", SqlDbType.NVarChar, 250, ParameterDirection.Input,bulkdesc);
               myaparam[3] = ModHelper.CreateParameter("@Density", SqlDbType.Float, 8, ParameterDirection.Input, density);
               myaparam[4] = ModHelper.CreateParameter("@NoOfBatches", SqlDbType.Int, 4, ParameterDirection.Input, noofbatches);
               myaparam[5] = ModHelper.CreateParameter("@FType", SqlDbType.VarChar, 50, ParameterDirection.Input, ftype);
               myaparam[6] = ModHelper.CreateParameter("@PreservativeTest", SqlDbType.TinyInt,1, ParameterDirection.Input, preservativetest);
               myaparam[7] = ModHelper.CreateParameter("@MicrobiologyTest", SqlDbType.TinyInt,1, ParameterDirection.Input, microbiologytest);
               myaparam[8] = ModHelper.CreateParameter("@Norms", SqlDbType.VarChar, 250, ParameterDirection.Input, norms);
               myaparam[9] = ModHelper.CreateParameter("@ReferenceDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, referencedate);
               myaparam[10] = ModHelper.CreateParameter("@OfficializationNo", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, officializationno);
               myaparam[11] = ModHelper.CreateParameter("@CreationDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, creationdate);
               myaparam[12] = ModHelper.CreateParameter("@ModificationDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, modificationdate);
               myaparam[13] = ModHelper.CreateParameter("@FDAApprovalDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, fdaapprovaldate);
               myaparam[14] = ModHelper.CreateParameter("@ExtLabReport", SqlDbType.Bit, 1, ParameterDirection.Input, extlabreport);
               myaparam[15] = ModHelper.CreateParameter("@Deactive", SqlDbType.Bit, 1, ParameterDirection.Input, deactive);
               myaparam[16] = ModHelper.CreateParameter("@FILCode", SqlDbType.VarChar, 200, ParameterDirection.Input, filcode);
               myaparam[17] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, createdby);
               myaparam[18] = ModHelper.CreateParameter("@BacterialCount", SqlDbType.VarChar, 250, ParameterDirection.Input, bacterialcount);
               myaparam[19] = ModHelper.CreateParameter("@FungalCount", SqlDbType.VarChar, 250, ParameterDirection.Input, fungalcount);
               myaparam[20] = ModHelper.CreateParameter("@FDAApprovalDateExport", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, fdaapprovaldateexport);
               myaparam[21] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Output, fno);
               
               SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_INSERT_TblBulkMaster", myaparam);

               return Convert.ToInt32(myaparam[21].Value);               
           }
           catch (Exception ex)
           {               
               throw ex;               
           }
       }
       public bool Update_BulkMaster()
       {
           try
           {
               SqlParameter[] myaparam = new SqlParameter[22];
               myaparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt,8, ParameterDirection.Input, fno);
               myaparam[1] = ModHelper.CreateParameter("@FormulaNo", SqlDbType.NVarChar, 200, ParameterDirection.Input, formulano);
               myaparam[2] = ModHelper.CreateParameter("@TechFamNo", SqlDbType.Int, 4, ParameterDirection.Input, techfamno);
               myaparam[3] = ModHelper.CreateParameter("@BulkDesc", SqlDbType.NVarChar, 250, ParameterDirection.Input, bulkdesc);
               myaparam[4] = ModHelper.CreateParameter("@Density", SqlDbType.Float, 8, ParameterDirection.Input, density);
               myaparam[5] = ModHelper.CreateParameter("@NoOfBatches", SqlDbType.Int, 4, ParameterDirection.Input, noofbatches);
               myaparam[6] = ModHelper.CreateParameter("@FType", SqlDbType.VarChar, 50, ParameterDirection.Input, ftype);
               myaparam[7] = ModHelper.CreateParameter("@PreservativeTest", SqlDbType.TinyInt, 1, ParameterDirection.Input, preservativetest);
               myaparam[8] = ModHelper.CreateParameter("@MicrobiologyTest", SqlDbType.TinyInt, 1, ParameterDirection.Input, microbiologytest);
               myaparam[9] = ModHelper.CreateParameter("@Norms", SqlDbType.VarChar, 250, ParameterDirection.Input, norms);
               myaparam[10] = ModHelper.CreateParameter("@ReferenceDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, referencedate);
               myaparam[11] = ModHelper.CreateParameter("@OfficializationNo", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, officializationno);
               myaparam[12] = ModHelper.CreateParameter("@CreationDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, creationdate);
               myaparam[13] = ModHelper.CreateParameter("@ModificationDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, modificationdate);
               myaparam[14] = ModHelper.CreateParameter("@FDAApprovalDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, fdaapprovaldate);
               myaparam[15] = ModHelper.CreateParameter("@ExtLabReport", SqlDbType.Bit, 1, ParameterDirection.Input, extlabreport);
               myaparam[16] = ModHelper.CreateParameter("@Deactive", SqlDbType.Bit, 1, ParameterDirection.Input, deactive);
               myaparam[17] = ModHelper.CreateParameter("@FILCode", SqlDbType.VarChar, 200, ParameterDirection.Input, filcode);
               myaparam[18] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, createdby);
               myaparam[19] = ModHelper.CreateParameter("@BacterialCount", SqlDbType.VarChar, 250, ParameterDirection.Input, bacterialcount);
               myaparam[20] = ModHelper.CreateParameter("@FungalCount", SqlDbType.VarChar, 250, ParameterDirection.Input, fungalcount);
               myaparam[21] = ModHelper.CreateParameter("@FDAApprovalDateExport", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, fdaapprovaldateexport);
               
               SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_UPDATE_TblBulkMaster", myaparam);

               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public bool Delete_BulkMaster()
       {
           try
           {
               SqlParameter[] myaparam = new SqlParameter[1];
               myaparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt,8, ParameterDirection.Input, fno);
               SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_Delete_BulkMaster", myaparam);

               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public void Insert_tblLineTestMethodMaster()
       {
           try
           {
               SqlParameter[] myparam = new SqlParameter[4];
               myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
               myparam[1] = ModHelper.CreateParameter("@TestNo", SqlDbType.Int, 4, ParameterDirection.Input, testno);
               myparam[2] = ModHelper.CreateParameter("@NormsMin", SqlDbType.VarChar, 50, ParameterDirection.Input, min);
               myparam[3] = ModHelper.CreateParameter("@NormsMax", SqlDbType.VarChar, 50, ParameterDirection.Input, max);

               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblLineTestMethodMaster", myparam); 
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public void Insert_tblBulkPhysicochemicalTestMethodMaster()
       {
           try
           {
               SqlParameter[] myparam = new SqlParameter[5];
               myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
               myparam[1] = ModHelper.CreateParameter("@TestNo", SqlDbType.Int, 4, ParameterDirection.Input, testno);
               myparam[2] = ModHelper.CreateParameter("@NormsMin", SqlDbType.VarChar, 50, ParameterDirection.Input, min);
               myparam[3] = ModHelper.CreateParameter("@NormsMax", SqlDbType.VarChar, 50, ParameterDirection.Input, max);
               myparam[4] = ModHelper.CreateParameter("@FormulaType", SqlDbType.VarChar, 50, ParameterDirection.Input, formulatype );

               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblBulkPhysicochemicalTestMethodMaster", myparam);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public bool Delete_tblBulkPhysicochemicalTestMethodMaster()
       {
           try
           {
               SqlParameter[] myaparam = new SqlParameter[3];
               myaparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
               myaparam[1] = ModHelper.CreateParameter("@TestNo", SqlDbType.Int, 4, ParameterDirection.Input, testno);
               myaparam[2] = ModHelper.CreateParameter("@FormulaType", SqlDbType.VarChar, 50, ParameterDirection.Input, formulatype);
               SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_Delete_tblBulkPhysicochemicalTestMethodMaster", myaparam);

               return true;
           }
           catch (Exception ex)
           {         
               throw ex;
           }
       }

       public bool Update_tblBulkPhysicochemicalTestMethodMaster_Del()
       {
           try
           {
               SqlParameter[] myaparam = new SqlParameter[4];
               myaparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
               myaparam[1] = ModHelper.CreateParameter("@TestNo", SqlDbType.Int, 4, ParameterDirection.Input, testno);
               myaparam[2] = ModHelper.CreateParameter("@FormulaType", SqlDbType.VarChar, 50, ParameterDirection.Input, formulatype);
               myaparam[3] = ModHelper.CreateParameter("@Del", SqlDbType.Bit, 1, ParameterDirection.Input, del);
               SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_Update_tblBulkPhysicochemicalTestMethodMaster_Del", myaparam);

               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public bool Delete_tblLineTestMethodMaster()
       {
           try
           {
               SqlParameter[] myaparam = new SqlParameter[2];
               myaparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
               myaparam[1] = ModHelper.CreateParameter("@TestNo", SqlDbType.Int, 4, ParameterDirection.Input, testno);
               SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_Delete_tblLineTestMethodMaster", myaparam);

               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public bool Update_tblLineTestMethodMaster_Del()
       {
           try
           {
               SqlParameter[] myaparam = new SqlParameter[3];
               myaparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
               myaparam[1] = ModHelper.CreateParameter("@TestNo", SqlDbType.Int, 4, ParameterDirection.Input, testno);
               myaparam[2] = ModHelper.CreateParameter("@Del", SqlDbType.Bit, 1, ParameterDirection.Input, del);
               SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_Update_tblLineTestMethodMaster_Del", myaparam);

               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public void Update_tblBulkPhysicochemicalTestMethodMaster()
       {
           try
           {
               SqlParameter[] myparam = new SqlParameter[5];
               myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
               myparam[1] = ModHelper.CreateParameter("@TestNo", SqlDbType.Int, 4, ParameterDirection.Input, testno);
               myparam[2] = ModHelper.CreateParameter("@NormsMin", SqlDbType.VarChar, 50, ParameterDirection.Input, min);
               myparam[3] = ModHelper.CreateParameter("@NormsMax", SqlDbType.VarChar, 50, ParameterDirection.Input, max);
               myparam[4] = ModHelper.CreateParameter("@FormulaType", SqlDbType.VarChar, 50, ParameterDirection.Input, formulatype);

               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblBulkPhysicochemicalTestMethodMaster", myparam);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public void Update_tblLineTestMethodMaster()
       {
           try
           {
               SqlParameter[] myparam = new SqlParameter[4];
               myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
               myparam[1] = ModHelper.CreateParameter("@TestNo", SqlDbType.Int, 4, ParameterDirection.Input, testno);
               myparam[2] = ModHelper.CreateParameter("@NormsMin", SqlDbType.VarChar, 50, ParameterDirection.Input, min);
               myparam[3] = ModHelper.CreateParameter("@NormsMax", SqlDbType.VarChar, 50, ParameterDirection.Input, max);
               

               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblLineTestMethodMaster", myparam);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public DataSet SELECT_tblBulkPhysicochemicalTestMethodMaster_FNo_FormulaType()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myaparam = new SqlParameter[2];
               myaparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);               
               myaparam[1] = ModHelper.CreateParameter("@FormulaType", SqlDbType.VarChar, 50, ParameterDirection.Input, formulatype);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblBulkPhysicochemicalTestMethodMaster_FNo_FormulaType", myaparam);

               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       
       # endregion


       public DataSet Select_All_Record_tblLineTestMethodMaster()
       {
           try
           {
               DataSet ds = new DataSet();
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "SP_Select_All_tblLineTestMethodMaster");
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
   }
}
