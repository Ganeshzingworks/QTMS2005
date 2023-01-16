using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;
namespace BusinessFacade
{
   public class FGTestMaster_Class
   {
       # region Varibles
       private long TestNo;
       private long FGMethodNo;
       private long FGNo;
       private string TestName;
       private string TestDesc;
       private int PKGTechNo;
       private string Frequency;
       private string InspectionMethod;
       private int Del;
       private bool UP;
       private bool Quality;
       //Avinash 11-07-2014
       private bool ScoopQty;
       # endregion
       # region Properties
       //Avinash 11-07-2014
       public bool Scoop_Qty
       {
           get { return ScoopQty; }
           set { ScoopQty = value; }
       }


       public int del
       {
           get { return Del; }
           set { Del = value; }
       }
       public string testdesc
       {
           get { return TestDesc; }
           set { TestDesc = value; }
       }
       public string testname
       {
           get { return TestName;}
           set { TestName = value;}
       }
       public long testno
       {
           get{return TestNo;}
           set{TestNo = value;}
       }

       public long fgmethodno
       {
           get { return FGMethodNo; }
           set { FGMethodNo = value; }
       }

       public long fgno
       {
           get { return FGNo; }
           set { FGNo = value; }
       }
      
       public int pkgtechno
       {
           get { return PKGTechNo; }
           set { PKGTechNo = value; }
       }
       public string frequency
       {
           get { return Frequency; }
           set { Frequency = value; }
       }
       public string inspectionmethod
       {
           get { return InspectionMethod; }
           set { InspectionMethod = value; }
       }

       public bool up
       {
           get { return UP; }
           set { UP = value; }

       }
       public bool quality
       {
           get { return Quality; }
           set { Quality = value; }

       }
       # endregion
       # region Functions
       public DataSet Select_TestMaster()
       {
           try
           {
               DataSet ds = new DataSet();
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblFgTestDescMaster1");
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public DataSet Select_tblTestMaster_Packing()
       {
           try
           {
               DataSet ds = new DataSet();
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblTestMaster_Packing");
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public DataSet Select_tblTestMaster_tblFinishGoodDetails()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@PKGTechNo", SqlDbType.BigInt, 8, ParameterDirection.Input, pkgtechno);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblTestMaster_tblFinishGoodDetails", myparam);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public DataSet Select_Testname_Frequency_InspectionMethod()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@PKGTechNo", SqlDbType.BigInt, 8, ParameterDirection.Input, pkgtechno);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_Testname_Frequency_InspectionMethod",myparam);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public DataSet Select_FinishGoodDetails_PKGTechNo()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@PKGTechNo", SqlDbType.BigInt, 8, ParameterDirection.Input, pkgtechno);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_FinishGoodDetails_PKGTechNo", myparam);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public DataSet Select_TestMaster_TestNo()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@TestNo", SqlDbType.Int, 4, ParameterDirection.Input, testno);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblFgTestDescMaster_TestNo", myparam);
               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public bool Update_TestMaster()
       {
           try
           {

               SqlParameter[] myparam = new SqlParameter[3];
               myparam[0] = ModHelper.CreateParameter("@TestNo", SqlDbType.Int, 4, ParameterDirection.Input, testno);
               myparam[1] = ModHelper.CreateParameter("@TestName", SqlDbType.NVarChar, 250, ParameterDirection.Input, testname);
               myparam[2] = ModHelper.CreateParameter("@TestDesc", SqlDbType.NVarChar, 250, ParameterDirection.Input, testdesc);
               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblFgTestDescMaster", myparam);
               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }
       public bool Insert_TestMaster()
       {
           try
           {
               SqlParameter[] myparam = new SqlParameter[2];
               myparam[0] = ModHelper.CreateParameter("@TestName", SqlDbType.NVarChar,250, ParameterDirection.Input, testname);
               myparam[1] = ModHelper.CreateParameter("@TestDesc", SqlDbType.NVarChar,250, ParameterDirection.Input, testdesc);
               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblFgTestDescMaster", myparam);
               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public bool Delete_TestMaster()
       {
           try
           {

               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@TestNo", SqlDbType.Int, 4, ParameterDirection.Input, testno);
               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblFgTestDescMaster", myparam);
               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public DataSet Select_FinisnedGoodDetails()
       {
           try
           {
               DataSet ds = new DataSet(); 
               SqlParameter[] myparam = new SqlParameter[4];
               myparam[0] = ModHelper.CreateParameter("@PKGtechNo", SqlDbType.BigInt, 8, ParameterDirection.Input, pkgtechno);
               myparam[1] = ModHelper.CreateParameter("@TestName", SqlDbType.NVarChar, 250, ParameterDirection.Input, testname);
               myparam[2] = ModHelper.CreateParameter("@Frequency", SqlDbType.VarChar, 50, ParameterDirection.Input, frequency);
               myparam[3] = ModHelper.CreateParameter("@InspectionMethod", SqlDbType.VarChar, 50, ParameterDirection.Input, inspectionmethod);


               ds=SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_FinisnedGoodDetails", myparam);

               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public DataSet Select_tblFinishGoodDetails_FGMethodNo()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[3];
               myparam[0] = ModHelper.CreateParameter("@TestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, testno);
               myparam[1] = ModHelper.CreateParameter("@Frequency", SqlDbType.VarChar, 50, ParameterDirection.Input, frequency);
               myparam[2] = ModHelper.CreateParameter("@InspectionMethod", SqlDbType.VarChar, 50, ParameterDirection.Input, inspectionmethod);


               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblFinishGoodDetails_FGMethodNo", myparam);

               return ds;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public bool Delete_FinisnedGoodDetails()
       {
           try
           {               
               SqlParameter[] myparam = new SqlParameter[4];
               myparam[0] = ModHelper.CreateParameter("@PKGtechNo", SqlDbType.BigInt, 8, ParameterDirection.Input, pkgtechno);
               myparam[1] = ModHelper.CreateParameter("@TestName", SqlDbType.NVarChar, 250, ParameterDirection.Input, testname);
               myparam[2] = ModHelper.CreateParameter("@Frequency", SqlDbType.VarChar, 50, ParameterDirection.Input, frequency);
               myparam[3] = ModHelper.CreateParameter("@InspectionMethod", SqlDbType.VarChar, 50, ParameterDirection.Input, inspectionmethod);
               
               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure,"STP_Delete_FinisnedGoodDetails",myparam);
               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public bool Update_tblFinishGoodDetails_Del()
       {
           try
           {
               SqlParameter[] myparam = new SqlParameter[5];
               myparam[0] = ModHelper.CreateParameter("@PKGtechNo", SqlDbType.BigInt, 8, ParameterDirection.Input, pkgtechno);
               myparam[1] = ModHelper.CreateParameter("@TestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, testno);
               myparam[2] = ModHelper.CreateParameter("@Frequency", SqlDbType.VarChar, 50, ParameterDirection.Input, frequency);
               myparam[3] = ModHelper.CreateParameter("@InspectionMethod", SqlDbType.VarChar, 50, ParameterDirection.Input, inspectionmethod);
               myparam[4] = ModHelper.CreateParameter("@Del", SqlDbType.Bit, 1, ParameterDirection.Input, del);

               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblFinishGoodDetails_Del", myparam);
               return true;
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       # endregion

       public void Delete_tblFGCodeFamilyTestRelation()
       {
           try
           {
               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblFGCodeFamilyTestRelation", myparam);               
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public void Delete_tblFGCodeFamilyTestRelationUP()
       {
           try
           {
               SqlParameter[] myparam = new SqlParameter[1];
               myparam[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblFGCodeFamilyTestRelationUP", myparam);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public void Insert_tblFGCodeFamilyTestRelation()
       {
           try
           {
               SqlParameter[] myparam = new SqlParameter[3];
               myparam[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
               myparam[1] = ModHelper.CreateParameter("@FGMethodNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgmethodno);
               myparam[2] = ModHelper.CreateParameter("@IsSCOOPTest", SqlDbType.Bit, 1, ParameterDirection.Input, Scoop_Qty);
               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblFGCodeFamilyTestRelation", myparam);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       //public void Insert_tblFGCodeFamilyTestRelationScoop()
       //{

       //    try
       //    {
       //        SqlParameter[] myparam = new SqlParameter[4];
       //        myparam[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
       //        myparam[1] = ModHelper.CreateParameter("@FGMethodNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgmethodno);
       //        myparam[2] = ModHelper.CreateParameter("@up", SqlDbType.Bit, 1, ParameterDirection.Input, up);
       //        myparam[3] = ModHelper.CreateParameter("@Quality", SqlDbType.Bit, 1, ParameterDirection.Input, quality);
       //        SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblFGCodeFamilyTestRelationSCoop", myparam);
       //    }
       //    catch (Exception ex)
       //    {
       //        throw ex;
       //    }
       //}


       public void Insert_tblFGCodeFamilyTestRelationUP()//<-----------------------------------------------  MAnisk K(TO STOTRE UPFGCODE AND THERES TEST METHODS)
       {

           try
           {
               SqlParameter[] myparam = new SqlParameter[2];
               myparam[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
               myparam[1] = ModHelper.CreateParameter("@FGMethodNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgmethodno);
               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_tblFGCodeFamilyTestRelationUP", myparam);
           }
           catch (Exception ex)
           {
               throw ex;
           }
       }

       public DataSet Select_AllTestMaster()
       {
           DataSet ds = new DataSet();
           ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "stp_Select_tblTestMasterNw");
           return ds;
       }
   }
}
