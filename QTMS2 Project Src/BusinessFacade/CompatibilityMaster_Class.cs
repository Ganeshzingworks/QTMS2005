using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;

namespace BusinessFacade
{
    public class CompatibilityMaster_Class
    {
        #region varibles & Properties

        private long CompNo;
        public long compNo
        {
            get { return CompNo; }
            set { CompNo = value; }
        }
        
        private int LoginID;
        public int loginid
        {
            get { return LoginID; }
            set { LoginID = value; }
        }

        private int InspectedBy;
        public int inspectedBy
        {
            get { return InspectedBy; }
            set { InspectedBy = value; }
        }

        private long FormulaNo;
        public long formulaNo
        {
            get{return FormulaNo;}
            set{ FormulaNo = value;}
        }
        
        private string ReportType;
        public string reportType
        {
            get
            {
                return ReportType;
            }
            set
            {
                ReportType = value;
            }
        }
             
        private string FillVolume;
        public string fillVolume
        {
            get
            {
                return FillVolume;
            }
            set
            {
                FillVolume = value;
            }
        }

        private string InspectionDate;
        public string inspectionDate
        {
            get
            {
                return InspectionDate;
            }
            set
            {
                InspectionDate = value;
            }
        }

        private string InitialStudyDate;
        public string initialStudyDate
        {
            get
            {
                return InitialStudyDate;
            }
            set
            {
                InitialStudyDate = value;
            }
        }

        private int NatureOfACRef;
        public int natureOfACRef
        {
            get{return NatureOfACRef;}
            set{NatureOfACRef = value;}
        }

        private int ACMaterialRef;
        public int aCMaterialRef
        {
            get
            {
                return ACMaterialRef;
            }
            set
            {
                ACMaterialRef = value;
            }
        }

        private int acmaterialno;

        public int AcMaterialNo
        {
            get { return acmaterialno; }
            set { acmaterialno = value; }
        }

        private string acmaterialref;

        public string AcMaterialRef
        {
            get { return acmaterialref; }
            set { acmaterialref = value; }
        }

        private string Supplier;
        public string supplier
        {
            get { return Supplier; }
            set { Supplier = value; }
        }

        private string PackingDescription;
        public string packingDescription
        {
            get { return PackingDescription; }
            set { PackingDescription = value; }
        }

        private string ControlDate;
        public string controlDate
        {
            get { return ControlDate; }
            set { ControlDate = value; }
        }

        //private string PressureLoss;
        //public string pressureLoss
        //{
        //    get { return PressureLoss; }
        //    set { PressureLoss = value; }
        //}

        // property for Nature of AC ref Master1
        private string NatureOfDefect;
        public string natureOfDefect
        {
            get { return NatureOfDefect; }
            set { NatureOfDefect = value; }
        }

        private int acnatureno;

        public int AcNatureNo
        {
            get { return acnatureno; }
            set { acnatureno = value; }
        }

        private char strflag;
        public char strFlag
        {
            get { return strflag; }
            set { strflag = value; }
        }
	
	

        private Char Compatible;
        public Char compatible
        {
            get { return Compatible; }
            set { Compatible = value; }
        }

        private string Comment;
        public string comment
        {
            get { return Comment; }
            set { Comment = value; }
        }

        private string ReportNo;

        public string reportNo
        {
            get { return ReportNo; }
            set { ReportNo = value; }
        }

        private string acnatureref;

        public string AcNatureRef
        {
            get { return acnatureref; }
            set { acnatureref = value; }
        }
	


        #endregion        

        #region Functions

        public long Insert_Compatibility()
        {
            try
            {               
                SqlParameter[] myparam = new SqlParameter[12];
                myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, this.formulaNo);                
                myparam[1] = ModHelper.CreateParameter("@ReportType", SqlDbType.NVarChar,50, ParameterDirection.Input,this.reportType);
                myparam[2] = ModHelper.CreateParameter("@InspectionDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, this.InspectionDate);
                myparam[3] = ModHelper.CreateParameter("@InitialStudyDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, this.initialStudyDate);
                myparam[4] = ModHelper.CreateParameter("@ControlDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, this.controlDate);
                myparam[5] = ModHelper.CreateParameter("@NatureOfDefect", SqlDbType.NVarChar, 20, ParameterDirection.Input, this.natureOfDefect);
                myparam[6] = ModHelper.CreateParameter("@Conclusion", SqlDbType.NVarChar, 1, ParameterDirection.Input, this.compatible);
                myparam[7] = ModHelper.CreateParameter("@Comment", SqlDbType.NVarChar, 50, ParameterDirection.Input, this.comment);
                myparam[8] = ModHelper.CreateParameter("@InspectedBy", SqlDbType.Int, 4, ParameterDirection.Input,this.inspectedBy);
                myparam[9] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, this.loginid);
                myparam[10] = ModHelper.CreateParameter("@FillVolume", SqlDbType.Int, 4, ParameterDirection.Input, this.fillVolume);
                myparam[11] = ModHelper.CreateParameter("@ReportNo", SqlDbType.NVarChar, 30, ParameterDirection.Input, this.reportNo);
                this.compNo=Convert.ToInt64(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_Insert_tblCompatibility", myparam));
                return this.compNo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update_Compatibility()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[13];
                myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, this.formulaNo);
                myparam[1] = ModHelper.CreateParameter("@ReportType", SqlDbType.NVarChar, 50, ParameterDirection.Input, this.reportType);
                myparam[2] = ModHelper.CreateParameter("@InspectionDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, this.InspectionDate);
                myparam[3] = ModHelper.CreateParameter("@InitialStudyDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, this.initialStudyDate);
                myparam[4] = ModHelper.CreateParameter("@ControlDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, this.controlDate);
                myparam[5] = ModHelper.CreateParameter("@CompNo", SqlDbType.Int, 4, ParameterDirection.Input, this.compNo);
                myparam[6] = ModHelper.CreateParameter("@NatureOfDefect", SqlDbType.NVarChar, 20, ParameterDirection.Input, this.natureOfDefect);
                myparam[7] = ModHelper.CreateParameter("@Conclusion", SqlDbType.NVarChar, 1, ParameterDirection.Input, this.compatible);
                myparam[8] = ModHelper.CreateParameter("@Comment", SqlDbType.NVarChar, 50, ParameterDirection.Input, this.comment);
                myparam[9] = ModHelper.CreateParameter("@InspectedBy", SqlDbType.Int, 4, ParameterDirection.Input, this.inspectedBy);
                myparam[10] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, this.loginid);
                myparam[11] = ModHelper.CreateParameter("@FillVolume", SqlDbType.Int, 4, ParameterDirection.Input, this.fillVolume);
                myparam[12] = ModHelper.CreateParameter("@ReportNo", SqlDbType.NVarChar, 30, ParameterDirection.Input, this.reportNo);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblCompatibility", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert_CompatPkgDesc()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[5];

                myparam[0] = ModHelper.CreateParameter("@CompNo", SqlDbType.BigInt, 8, ParameterDirection.Input, this.compNo);
                myparam[1] = ModHelper.CreateParameter("@NatureOfACRef", SqlDbType.Int, 4, ParameterDirection.Input, this.natureOfACRef);
                myparam[2] = ModHelper.CreateParameter("@ACMaterialRef", SqlDbType.Int, 4, ParameterDirection.Input, this.aCMaterialRef);
                myparam[3] = ModHelper.CreateParameter("@Supplier", SqlDbType.NChar, 100, ParameterDirection.Input, this.supplier);
                myparam[4] = ModHelper.CreateParameter("@Description", SqlDbType.NChar, 100, ParameterDirection.Input, this.packingDescription);

                SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_Insert_tblCompatPkgDesc", myparam);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable SELECT_tblCompatAcNatureMaster()
        {
            try
            {
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblCompatAcNMaster").Tables[0];
            }
            catch (Exception)
            {
                throw;
            }
        }

        public DataTable SELECT_CompatAcMaterialMaster()
        {
            try
            {
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblCompatAcMMaster").Tables[0];
            }
            catch (Exception)
            {
                throw;
            }
        }
        public DataSet Select_Compatibility_FNo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, this.formulaNo);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblCompatibility_FNo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_CompatibilityPkgDesc_CompNo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@CompNo", SqlDbType.BigInt, 8, ParameterDirection.Input, this.compNo);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblCompatPkgDesc_CompNo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete_CompatPkgDesc_CompNo()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@CompNo", SqlDbType.BigInt, 8, ParameterDirection.Input, this.compNo);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblCompatPkgDesc_CompNo ", myparam);
                return true;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
        #endregion       

        #region Compatibility Test Variables & Properties
        private int TestNo;

        public int testNo
        {
            get { return TestNo; }
            set { TestNo = value; }
        }
        private double BottleJar;

        public double bottleJar
        {
            get { return BottleJar; }
            set { BottleJar = value; }
        }
        private double CapPlug;

        public double capPlug
        {
            get { return CapPlug; }
            set { CapPlug = value; }
        }

        private double TareWT;

        public double tarewt
        {
            get { return TareWT; }
            set { TareWT = value; }
        }

        private string Temp;

        public string temp
        {
            get { return Temp; }
            set { Temp = value; }
        }
        private double Days0;

        public double days0
        {
            get { return Days0; }
            set { Days0 = value; }
        }

        private double Days7;

        public double days7
        {
            get { return Days7; }
            set { Days7 = value; }
        }
        private double Days30;

        public double days30
        {
            get { return Days30; }
            set { Days30 = value; }
        }
        private double Days60;

        public double days60
        {
            get { return Days60; }
            set { Days60 = value; }
        }
        private double Yrs3;

        public double yrs3
        {
            get { return Yrs3; }
            set { Yrs3 = value; }
        }
        private double Yrs4;

        public double yrs4
        {
            get { return Yrs4; }
            set { Yrs4 = value; }
        }

        //Status is used for the test is weight, deformation & Other test.If Test is Weight then use Char 'W', Test is Deformation then use Char 'D' & Test is other Test then Use 'T'.
        private string TestStatus;

        public string testStatus
        {
            get { return TestStatus; }
            set { TestStatus = value; }
        }

        private string Status;

        public string status
        {
            get { return Status; }
            set { Status = value; }
        }


        #endregion

        #region Compatibility Test Functions

        public bool Insert_CompatibilityTestDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[16];
                myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, this.formulaNo);
                myparam[1] = ModHelper.CreateParameter("@TestNo", SqlDbType.Int, 8, ParameterDirection.Input, this.testNo);
                myparam[2] = ModHelper.CreateParameter("@BottleJar", SqlDbType.Decimal, 8, ParameterDirection.Input, this.bottleJar);
                myparam[3] = ModHelper.CreateParameter("@CapPlug", SqlDbType.Decimal, 8, ParameterDirection.Input, this.capPlug);
                myparam[4] = ModHelper.CreateParameter("@TareWt", SqlDbType.Decimal, 8, ParameterDirection.Input, this.tarewt);
                myparam[5] = ModHelper.CreateParameter("@Temp", SqlDbType.NVarChar, 50, ParameterDirection.Input, this.temp);
                myparam[6] = ModHelper.CreateParameter("@Days0", SqlDbType.Decimal, 8, ParameterDirection.Input, this.days0);
                myparam[7] = ModHelper.CreateParameter("@Days7", SqlDbType.Decimal, 8, ParameterDirection.Input, this.days7);
                myparam[8] = ModHelper.CreateParameter("@Days30", SqlDbType.Decimal, 8, ParameterDirection.Input, this.days30);
                myparam[9] = ModHelper.CreateParameter("@Days60", SqlDbType.Decimal, 8, ParameterDirection.Input, this.days60);
                myparam[10] = ModHelper.CreateParameter("@Days3Yrs", SqlDbType.Decimal, 8, ParameterDirection.Input, this.yrs3);
                myparam[11] = ModHelper.CreateParameter("@Days4Yrs", SqlDbType.Decimal, 8, ParameterDirection.Input, this.yrs4);
                myparam[12] = ModHelper.CreateParameter("@TestStatus", SqlDbType.NVarChar, 50, ParameterDirection.Input, this.testStatus);
                myparam[13] = ModHelper.CreateParameter("@Status", SqlDbType.NVarChar, 50, ParameterDirection.Input, this.status);
                myparam[14] = ModHelper.CreateParameter("@InspectedBy", SqlDbType.Int, 4, ParameterDirection.Input, this.inspectedBy);
                myparam[15] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, this.loginid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblCompatibilityTestMethodDetails", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete_CompatibilityTestDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, this.formulaNo);
                myparam[1] = ModHelper.CreateParameter("@TestNo", SqlDbType.Int, 8, ParameterDirection.Input, this.testNo);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblCompatibilityTestMethodDetails", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_CompatibilityTestDetails()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, this.formulaNo);
                myparam[1] = ModHelper.CreateParameter("@TestNo", SqlDbType.Int, 8, ParameterDirection.Input, this.testNo);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblCompatibilityTestMethodDetails", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //This function gets all the test & thier status related to that particular formula
        public DataSet Select_CompatibilityTestDetails_FNo_GetStatus()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, this.formulaNo);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblCompatibilityTestMethodDetails_FNo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Get the Weight & Deformation Readings Report
        public DataSet Select_CompatibilityTestDetailsReport_FNo_WeightDeformation()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, this.formulaNo);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblCompatibilityTestMethodDetailsReport_FNo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // Get the Other Test Readings Report
        public DataSet Select_CompatibilityTestDetailsReport_FNo_OtherTest()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, this.formulaNo);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblCompatibilityTestMethodDetailsReport_FNo_OtherTest", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        #region this is for Nature of Ref Master from anil on 03 apr 2011

        // this method is used for both transaction insert record and update record
        // there is 2 flag 1 for Insert i.e. 'I' and 2nd for update i.e. 'U'
        public bool Insert_Update_NatureofRefMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[3];

                myparam[0] = ModHelper.CreateParameter("@strFlag", SqlDbType.NVarChar, 1, ParameterDirection.Input, strFlag);
                myparam[1] = ModHelper.CreateParameter("@AcNatureRef", SqlDbType.NVarChar, 250, ParameterDirection.Input, AcNatureRef);
                myparam[2] = ModHelper.CreateParameter("@AcNatureNo", SqlDbType.Int, 8, ParameterDirection.Input, AcNatureNo);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_INSERT_TblCompatAcNMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // to delete record from tblCompatAcNMaster
        public bool Delete_NatureofACMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@AcNatureNo", SqlDbType.Int, 4, ParameterDirection.Input, AcNatureNo);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_TblCompatAcNMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region this is for Material Ref Master from anil on 03 apr 2011

        // this method is used for both transaction insert record and update record
        // there is 2 flag 1 for Insert i.e. 'I' and 2nd for update i.e. 'U'

        public bool Insert_Update_MaterialRefMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[3];

                myparam[0] = ModHelper.CreateParameter("@strFlag", SqlDbType.NVarChar, 1, ParameterDirection.Input, strFlag);
                myparam[1] = ModHelper.CreateParameter("@AcMaterialRef", SqlDbType.NVarChar, 250, ParameterDirection.Input, AcMaterialRef);
                myparam[2] = ModHelper.CreateParameter("@AcMaterialNo", SqlDbType.Int, 8, ParameterDirection.Input, AcMaterialNo);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_INSERT_TblCompatAcMMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // to delete record from tblCompatAcMMaster
        public bool Delete_MaterialRefMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@AcMaterialNo", SqlDbType.Int, 4, ParameterDirection.Input, AcMaterialNo);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_TblCompatAcMMaster", myparam);
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
