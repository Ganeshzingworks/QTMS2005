using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;
using System.Configuration;


namespace BusinessFacade.Transactions
{
    public class Report_Class
    {
        private string FromDate;
        public string fromdate
        {
            get { return FromDate; }
            set { FromDate = value; }
        }
        private string ToDate;
        public string todate
        {
            get { return ToDate; }
            set { ToDate = value; }
        }
        private string WithDate;
        public string withdate
        {
            get { return WithDate; }
            set { WithDate = value; }
        }
        private long FNo;
        public long fno
        {
            get { return FNo; }
            set { FNo = value; }
        }
        private long FMID;
        public long fmid
        {
            get { return FMID; }
            set { FMID = value; }
        }
        private long PKGTechNo;
        public long pkgtechno
        {
            get { return PKGTechNo; }
            set { PKGTechNo = value; }
        }
        private string MfgWo;
        public string mfgwo
        {
            get { return MfgWo; }
            set { MfgWo = value; }
        }
        private string FormulaType;
        public string formulatype
        {
            get { return FormulaType; }
            set { FormulaType = value; }
        }
        private long BulkMethodNo;
        public long bulkmethodno
        {
            get { return BulkMethodNo; }
            set { BulkMethodNo = value; }
        }
        private int TestNo;
        public int testno
        {
            get { return TestNo; }
            set { TestNo = value; }
        }
        private long FGTestNo;
        public long fgtestno
        {
            get { return FGTestNo; }
            set { FGTestNo = value; }
        }
        private long FGTLFID;
        public long fgtlfid
        {
            get { return FGTLFID; }
            set { FGTLFID = value; }
        }
        private long RMTransID;
        public long rmtransid
        {
            get { return RMTransID; }
            set { RMTransID = value; }
        }
        private long RMSamplingID;
        public long rmsamplingid
        {
            get { return RMSamplingID; }
            set { RMSamplingID = value; }
        }

        private long PMTransID;
        public long pmtransid
        {
            get { return PMTransID; }
            set { PMTransID = value; }
        }
        private int FromAnalysisReanalysis;

        public int fromAnalysisReanalysis
        {
            get { return FromAnalysisReanalysis; }
            set { FromAnalysisReanalysis = value; }
        }

        private long PMTestID;
        public long pmtestid
        {
            get { return PMTestID; }
            set { PMTestID = value; }
        }

        private long PMFamilyID;
        public long pmfamilyid
        {
            get { return PMFamilyID; }
            set { PMFamilyID = value; }
        }

        private long FDATransID;
        public long fdatransid
        {
            get { return FDATransID; }
            set { FDATransID = value; }
        }
        private long RMCodeID;
        public long rmcodeid
        {
            get { return RMCodeID; }
            set { RMCodeID = value; }
        }
        private long TransID;
        public long transid
        {
            get { return TransID; }
            set { TransID = value; }
        }
        private long CategoryID;
        public long categoryid
        {
            get { return CategoryID; }
            set { CategoryID = value; }
        }

       

        private string BatchNo;
        public string batchno
        {
            get { return BatchNo; }
            set { BatchNo = value; }
        }

        private string MediaLotNo;

        public string medialotno
        {
            get { return MediaLotNo; }
            set { MediaLotNo = value; }
        }

        private int BatchSize;

        public int batchsize
        {
            get { return BatchSize; }
            set { BatchSize = value; }
        }

        private int locationid;

        public int LocationID
        {
            get { return locationid; }
            set { locationid = value; }
        }

        private long AdjID;

        public long adjid
        {
            get { return AdjID; }
            set { AdjID = value; }
        }

        private long FGNo;

        public long fgno
        {
            get { return FGNo; }
            set { FGNo = value; }
        }

        private long PMSupplierID;

        public long pmsupplierid
        {
            get { return PMSupplierID; }
            set { PMSupplierID = value; }
        }

        private string Status;

        public string status
        {
            get { return Status; }
            set { Status = value; }
        }
        private int ParaNo;

        public int paraNo
        {
            get { return ParaNo; }
            set { ParaNo = value; }
        }
        private char MethodType;

        public char methodType
        {
            get { return MethodType; }
            set { MethodType = value; }
        }

        private string PlantNo;

        public string plantNo
        {
            get { return PlantNo; }
            set { PlantNo = value; }
        }

        private DateTime PHYChemSamplingDate;

        public DateTime phyChemSamplingDate
        {
            get { return PHYChemSamplingDate; }
            set { PHYChemSamplingDate = value; }
        }

        private long PMSupplierCOID;

        private string SupplierName;
        int _rmsupplierid;
        public int rmsupplierid
        {
            get { return _rmsupplierid; }
            set { _rmsupplierid = value; }
        }
        public string suppliername
        {

            get { return SupplierName; }
            set { SupplierName = value; }
        }

        private string PMCode;
        public string pmcode
        {
            get { return PMCode; }
            set { PMCode = value; }
        }

        public long pmsuppliercoid
        {
            get { return PMSupplierCOID; }
            set { PMSupplierCOID = value; }
        }

        private long _ManufacturedById;

        public long ManufacturedById
        {
            get { return _ManufacturedById; }
            set { _ManufacturedById = value; }
        }
        private int TLFID;
        public DateTime fromDate;
        public DateTime toDate;
        public int tlfid
        {
            get { return TLFID; }
            set { TLFID = value; }
        }

       
        public DataSet STP_Select_View_PM_Analysis_Report_SupplierCOCID()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@PMSupplierCOCID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmsuppliercoid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_PM_Analysis_Report_SupplierCOCID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_VIEW_LotDossier_Report_2()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtestno);
                myparam[1] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[2] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_LotDossier_Report_2", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_VIEW_LotDossier_Report_2NEW()
        {
            ////try
            ////{
            ////    DataSet ds = new DataSet();
            ////    SqlParameter[] myparam = new SqlParameter[3];
            ////    myparam[0] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtestno);
            ////    myparam[1] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
            ////    myparam[2] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
            ////    ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_LotDossier_Report_2NEW", myparam);
            ////    return ds;
            ////}
            ////catch (Exception ex)
            ////{
            ////    throw ex;
            ////}

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Scoop_QTMS_MergedConnectionString"].ConnectionString);
            con.Open();
            try
            {
                DataSet ds = new DataSet();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "STP_Select_VIEW_LotDossier_Report_2NEW";
                cmd.Parameters.Add("@FGTestNo",fgtestno);
                cmd.Parameters.Add("@FromDate", fromdate);
                cmd.Parameters.Add("@ToDate", todate);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                // SqlHelper.CreateCommand(SqlHelper.GetMDIQuizConnectionString, "STP_Select_tblFGTLF_LotDetails",);
                cmd.CommandTimeout = 0;
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(ds);
                //ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblFGTLF_LotDetails");

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }

        public DataSet Select_VIEW_LotDossier_Report_SF()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtestno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_LotDossier_Report_SF", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_VIEW_LotDossier_Report_FM()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtestno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_LotDossier_Report_FM", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_VIEW_LotDossier_Report_BMR()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtestno);
                myparam[1] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_LotDossier_Report_BMR", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblLinkTLF_FGTestNo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtestno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblLinkTLF_FGTestNo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_PMTransaction_PMAnalysisReport()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblPMTransaction_PMAnalysisReport");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_PMCode_PMReAnalysisReport()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblPMCode_PMReAnalysisReport");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_RejectionNote_PM_Details()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_RejectionNote_PM_Details");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_STP_Get_RM_Transaction_RMCodeDetails()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Get_RM_Transaction_RMCode");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public DataSet Select_STP_Get_RM_Rejection_SupplierDetails()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMCode", SqlDbType.BigInt, 8, ParameterDirection.Input, rmcodeid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Get_RM_Rejection_Supplier",myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_STP_RM_Rejection_Note_Details()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                //myparam[0] = ModHelper.CreateParameter("@RMCode", SqlDbType.BigInt, 8, ParameterDirection.Input, rmcodeid);
                //myparam[1] = ModHelper.CreateParameter("@RMSupplierId", SqlDbType.BigInt, 8, ParameterDirection.Input, rmsupplierid);
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_RM_Rejection_Note_Details", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_STP_View_RM_Rejection_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@RMCode", SqlDbType.BigInt, 8, ParameterDirection.Input, rmcodeid);
                myparam[1] = ModHelper.CreateParameter("@RMSupplierId", SqlDbType.BigInt, 8, ParameterDirection.Input, rmsupplierid);
                myparam[2] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[3] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_View_RM_Rejection_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_DefectNote_PM_Details()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_DefectNote_PM_Details");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_VIEW_PreLotDossier_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_PreLotDossier_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_VIEW_PreLotDossier_Report2()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_PreLotDossier_Report_2", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_VIEW_FG_Analysis_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtestno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_FG_Analysis_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_FinishedGoodDetails_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_FinishedGoodDetails_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_FormulaMasterDetails_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_FormulaMasterDetails_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_VIEW_FG_Analysis_Report_BMR()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtestno);
                myparam[1] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_FG_Analysis_Report_BMR", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_VIEW_FG_Analysis_Report_FM()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtestno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_FG_Analysis_Report_FM", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_RejectionNote_FG()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtestno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_RejectionNote_FG", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_VIEW_FG_Analysis_Phy_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtestno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_FG_Analysis_Phy_Report", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_VIEW_FG_Analysis_Phy_Report_BMR()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtestno);
                myparam[1] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_FG_Analysis_Phy_Report_BMR", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_VIEW_FG_Analysis_Phy_Report_BMR_Phy()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_FG_Analysis_Phy_Report_BMR_Phy", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_VIEW_FG_Analysis_Pack_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtestno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_FG_Analysis_Pack_Report", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Check SF = 1 
        public DataTable Select_SFFinishedGood()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtestno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_SFFinishedGood", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_VIEW_FG_Analysis_Pres_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtestno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_FG_Analysis_Pres_Report", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_VIEW_FG_Analysis_Pres_Report_BMR()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtestno);
                myparam[1] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_FG_Analysis_Pres_Report_BMR", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_VIEW_FG_Analysis_Pres_Report_BMR_Pres()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_FG_Analysis_Pres_Report_BMR_Pres", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_VIEW_FinishedGoodTest_Reports()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_FinishedGoodTest_Reports", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_VIEW_FinishedGoodDue_Reports()
        {

            SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["connectionstring"]);
            con.Open();
            try
            {
                DataSet ds = new DataSet();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "STP_Select_VIEW_FinishedGoodDue_Reports";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.Add("@FromDate", SqlDbType.VarChar, 50).Value = fromdate;
                cmd.Parameters.Add("@ToDate", SqlDbType.VarChar, 50).Value = todate;
                cmd.CommandTimeout = 0;
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }




            //try
            //{
            //    DataSet ds = new DataSet();
            //    SqlParameter[] myparam = new SqlParameter[2];
            //    myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
            //    myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
            //    ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_FinishedGoodDue_Reports", myparam);
            //    return ds;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }
        public DataSet Select_ScoopVIEW_FinishedGoodTest_Reports()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_Scoop_VIEW_FinishedGoodTest_Reports", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_NonScoopVIEW_FinishedGoodTest_Reports()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_NonScoop_VIEW_FinishedGoodTest_Reports", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_VIEW_RMTransaction_Reports()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_RMTransaction_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_VIEW_PMDue_Reports()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_PMDue_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_RMTransaction_Reports()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                myparam[2] = ModHelper.CreateParameter("@Status", SqlDbType.Char, 10, ParameterDirection.Input, status);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_RMTransaction_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_RM_SupplierReportReceived_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_RM_SupplierReportReceived_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_VIEW_FinishedGoodTDB_Reports()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_FinishedGoodTDB_Reports", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_VIEW_Global_FG_TDB_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                myparam[2] = ModHelper.CreateParameter("@ManuById", SqlDbType.BigInt, 8, ParameterDirection.Input, ManufacturedById);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_Global_FG_TDB_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_VIEW_FG_LineDetails_TDB_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_FG_LineDetails_TDB_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_VIEW_Filling_Packing_Quality_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_Filling_Packing_Quality_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_FinishedGoodSummary_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_FinishedGoodSummary_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_Scoop_View_FinishedGoodSummary_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_Scoop_View_FinishedGoodSummary_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_NonScoop_View_FinishedGoodSummary_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_NonScoop_View_FinishedGoodSummary_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_FinishedGood_NonBPC_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_FinishedGood_NonBPC_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_Scoop_View_FinishedGood_NonBPC_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_Scoop_View_FinishedGood_NonBPC_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_NonScoop_View_FinishedGood_NonBPC_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_NonScoop_View_FinishedGood_NonBPC_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_VIEW_BulkTestDetailReport()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_BulkTestDetailReport", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_BulkTest_NonBPC_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_BulkTest_NonBPC_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_BulkTest_NewLaunch_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_BulkTest_NewLaunch_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_BulkTest_NonValidated_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_BulkTest_NonValidated_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_BulkAnalysis_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_BulkAnalysis_Report");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_VIEW_Bulk_Analysis_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_Bulk_Analysis_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet Select_View_BMR_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_BMR_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_BMR_FG_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_BMR_FG_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_BMR_PreSummary_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_BMR_PreSummary_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_VIEW_PreLotDossier_Report_QStatus()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_PreLotDossier_Report_QStatus", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_VIEW_LotDossier_Report_FG()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_LotDossier_Report_FG", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_VIEW_BulkTest_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[1] = ModHelper.CreateParameter("@TestNo", SqlDbType.Int, 4, ParameterDirection.Input, testno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_BulkTest_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_VIEW_FormulaHistory_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[5];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                myparam[2] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[3] = ModHelper.CreateParameter("@BatchSize", SqlDbType.Int, 4, ParameterDirection.Input, batchsize);
                myparam[4] = ModHelper.CreateParameter("@FormulaType", SqlDbType.VarChar, 50, ParameterDirection.Input, formulatype);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_FormulaHistory_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_VIEW_FormulaHistory_FG_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                myparam[2] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[3] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_FormulaHistory_FG_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_VIEW_BulkTransaction_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_BulkTransaction_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_VIEW_BulkTDB_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_BulkTDB_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_VIEW_Pending_Bulk_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_Pending_Bulk_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_VIEW_Pending_FGBulk_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_Pending_FGBulk_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_VIEW_LineSampling_Reports()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_LineSampling_Reports", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_Scoop_VIEW_LineSampling_Reports()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_Scoop_VIEW_LineSampling_Reports", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_NonScoop_VIEW_LineSampling_Reports()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_NonScoop_VIEW_LineSampling_Reports", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       
        public DataSet Select_VIEW_LineSamplingSummary_Reports()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_LineSamplingSummary_Reports", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_Scoop_VIEW_LineSamplingSummary_Reports()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_Scoop_VIEW_LineSamplingSummary_Reports", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_NonScoop_VIEW_LineSamplingSummary_Reports()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_NonScoop_VIEW_LineSamplingSummary_Reports", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet Select_VIEW_LinePacking_Reports()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_LinePacking_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_Scoop_VIEW_LinePacking_Reports()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_Scoop_VIEW_LinePacking_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_NonScoop_VIEW_LinePacking_Reports()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_NonScoop_VIEW_LinePacking_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_VIEW_PreservativeTest_Reports()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_PreservativeTest_Reports", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_VIEW_MicrobiologyTest_Reports()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                myparam[2] = ModHelper.CreateParameter("@WithDate", SqlDbType.VarChar, 50, ParameterDirection.Input, withdate);
                myparam[3] = ModHelper.CreateParameter("@tlfid", SqlDbType.Int, 50, ParameterDirection.Input, tlfid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_MicrobiologyTest_Reports", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_Scoop_VIEW_MicrobiologyTest_Reports()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                myparam[2] = ModHelper.CreateParameter("@WithDate", SqlDbType.VarChar, 50, ParameterDirection.Input, withdate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_Scoop_VIEW_MicrobiologyTest_Reports", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_NonScoop_VIEW_MicrobiologyTest_Reports()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                myparam[2] = ModHelper.CreateParameter("@WithDate", SqlDbType.VarChar, 50, ParameterDirection.Input, withdate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_NonScoop_VIEW_MicrobiologyTest_Reports", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet Select_VIEW_MicrobiologySummary_Reports()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                myparam[2] = ModHelper.CreateParameter("@WithDate", SqlDbType.VarChar, 50, ParameterDirection.Input, withdate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_MicrobiologySummary_Reports", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_Scoop_VIEW_MicrobiologySummary_Reports()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                myparam[2] = ModHelper.CreateParameter("@WithDate", SqlDbType.VarChar, 50, ParameterDirection.Input, withdate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_Scoop_VIEW_MicrobiologySummary_Reports", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_NonScoop_VIEW_MicrobiologySummary_Reports()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                myparam[2] = ModHelper.CreateParameter("@WithDate", SqlDbType.VarChar, 50, ParameterDirection.Input, withdate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_NonScoop_VIEW_MicrobiologySummary_Reports", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public DataSet Select_VIEW_MicrobiologyTDB_Reports()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                myparam[2] = ModHelper.CreateParameter("@WithDate", SqlDbType.VarChar, 50, ParameterDirection.Input, withdate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_MicrobiologyTDB_Reports", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_VIEW_RMTDB_Reports()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_RMTDB_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_VIEW_RM_Supplier_TDB_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_RM_Supplier_TDB_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblFGTLF_Details()
        {
            try
            {
                DataSet ds = new DataSet();

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblFGTLF_Details");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_RejectionNote_FG_Details()
        {
            try
            {
                DataSet ds = new DataSet();

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_RejectionNote_FG_Details");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblComplaintTransaction_ComplaintRefNo()
        {
            try
            {
                DataSet ds = new DataSet();

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblComplaintTransaction_ComplaintRefNo");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet Select_tblFGTLF_PreDetails()
        {
            try
            {
                DataSet ds = new DataSet();

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblFGTLF_PreDetails");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblFGTLF_LotDetails()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Scoop_QTMS_MergedConnectionString"].ConnectionString);
            con.Open();
            try
            {
                DataSet ds = new DataSet();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "STP_Select_tblFGTLF_LotDetails";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                // SqlHelper.CreateCommand(SqlHelper.GetMDIQuizConnectionString, "STP_Select_tblFGTLF_LotDetails",);
                cmd.CommandTimeout = 0;
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(ds);
                //ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblFGTLF_LotDetails");

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
        }


        public DataSet Select_View_PendingRM_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_PendingRM_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet Select_View_FormulaDescription_Report()
        {
            try
            {
                DataSet ds = new DataSet();

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_FormulaDescription_Report");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_PMCodeDescription_Report()
        {
            try
            {
                DataSet ds = new DataSet();

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_PMCodeDescription_Report");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_FDA_Analysis()
        {
            try
            {
                DataSet ds = new DataSet();

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_FDA_Analysis");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet Select_RMTransaction_RMAnalysisReport()
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


        public DataSet Select_View_RM_Analysis_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMSamplingID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmsamplingid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_RM_Analysis_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet Select_View_RMValidity_Analysis_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);


                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_RMValidity_Analysis_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet Select_View_PMTransaction_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);


                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_PMTransaction_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_PMComponentHistory_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                myparam[2] = ModHelper.CreateParameter("@PMCode", SqlDbType.VarChar, 50, ParameterDirection.Input, pmcode);
                myparam[3] = ModHelper.CreateParameter("@Supplier", SqlDbType.VarChar, 200, ParameterDirection.Input, suppliername);

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_PM_COC_Transaction_Report_component", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_PM_NewLaunch_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);


                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_PM_NewLaunch_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_PM_SupplierReportReceived_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);


                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_PM_SupplierReportReceived_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_PMRejectionDetail_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);


                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_PMRejectionDetail_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet Select_View_PMRejectionDetail_Report_PMStatus()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);


                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_PMRejectionDetail_Report_PMStatus", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // PM Defect Note Detail Report 06-July-2010
        public DataSet Select_PMDefectNoteDetail_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);


                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_PMDefectNoteDetail_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_View_RM_Analysis_Phy_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMSamplingID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmsamplingid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_RM_Phy_Analysis_Report", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        public DataTable Select_View_RM_Analysis_Pres_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];

                myparam[0] = ModHelper.CreateParameter("@RMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmtransid);

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_RM_Pres_Analysis_Report", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_PM_Analysis_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                myparam[2] = ModHelper.CreateParameter("@PMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmtransid);
                myparam[3] = ModHelper.CreateParameter("@fromAnalysisReanalysis", SqlDbType.Int, 4, ParameterDirection.Input, fromAnalysisReanalysis);

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_PM_Analysis_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_RejectionNote_PM()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@PMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmtransid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_RejectionNote_PM", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_DefectNote_PM()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@PMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmtransid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_DefectNote_PM", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_View_PM_Analysis_SubReport()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@PMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmtransid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_PM_Analysis_SubReport", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_View_PM_Analysis_DefectReport()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@PMTransID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmtransid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_PM_Analysis_DefectReport", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_PM_TDB_Report()
        {
            SqlConnection con = new SqlConnection(ConfigurationSettings.AppSettings["connectionstring"]);
            con.Open();
            try
            {
                DataSet ds = new DataSet();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "STP_Select_View_PM_TDB_Report";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;
                cmd.Parameters.Add("@FromDate", SqlDbType.VarChar, 50).Value = fromdate;
                cmd.Parameters.Add("@ToDate", SqlDbType.VarChar, 50).Value = todate;
                cmd.CommandTimeout = 0;
                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                adpt.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            /////
            //try
            //{
            //    DataSet ds = new DataSet();
            //    SqlParameter[] myparam = new SqlParameter[2];
            //    myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
            //    myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);                
            //    ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_PM_TDB_Report", myparam);
            //    return ds;
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        public DataSet Select_View_PM_COCList_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_PM_COCList_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_PM_COC_Transaction_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);


                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_PM_COC_Transaction_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_ComplaintSummary_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[5];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                myparam[2] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[3] = ModHelper.CreateParameter("@BatchNo", SqlDbType.VarChar, 50, ParameterDirection.Input, batchno);
                myparam[4] = ModHelper.CreateParameter("@CategoryID", SqlDbType.BigInt, 8, ParameterDirection.Input, categoryid);

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_ComplaintSummary_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_View_ComplaintResponce_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
               

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_ComplaintResponce_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_ComplaintSummary_Report_FormulaNo()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_ComplaintSummary_Report_FormulaNo");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_ComplaintSummary_Report_BatchNo()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_ComplaintSummary_Report_BatchNo");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_ComplaintSummary_Report_Category()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_ComplaintSummary_Report_Category");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_FDA_Analysis_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("FDATransID", SqlDbType.BigInt, 8, ParameterDirection.Input, fdatransid);

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_FDA_Analysis_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_View_FDA_Analysis_Phy_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("FDATransID", SqlDbType.BigInt, 8, ParameterDirection.Input, fdatransid);

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_FDA_Analysis_Phy_Report", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_View_FDA_Analysis_Pres_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("FDATransID", SqlDbType.BigInt, 8, ParameterDirection.Input, fdatransid);

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_FDA_Analysis_Pres_Report", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblRMCodeMaster()
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

        public DataSet SELECT_View_RMTestMethodMaster_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmcodeid);

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_View_RMTestMethodMaster_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_RMCodeHistory_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmcodeid);

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_RMCodeHistory_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SELECT_View_RMPhysicochemicalTestMethodMaster_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmcodeid);

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_View_RMPhysicochemicalTestMethodMaster_Report", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SELECT_View_RMPreservativeMethodMaster_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmcodeid);

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_View_RMPreservativeMethodMaster_Report", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SELECT_View_RMFDAPhysicoChemicalTestMethodMaster_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmcodeid);

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_View_RMFDAPhysicoChemicalTestMethodMaster_Report", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SELECT_View_RMFDAPreservativeMethodMaster_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmcodeid);

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_View_RMFDAPreservativeMethodMaster_Report", myparam);
                return ds.Tables[0];
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

        public DataSet SELECT_View_TestMethodMaster_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_View_TestMethodMaster_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SELECT_View_FGTestMethodMaster_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("PKGTechNo", SqlDbType.BigInt, 8, ParameterDirection.Input, pkgtechno);

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_View_FGTestMethodMaster_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SELECT_View_PMTestMethodMaster_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("PMFamilyID", SqlDbType.BigInt, 8, ParameterDirection.Input, pmfamilyid);

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_View_PMTestMethodMaster_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable SELECT_View_BulkPhysicochemicalTestMethodMaster_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_View_BulkPhysicochemicalTestMethodMaster_Report", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SELECT_View_LineTestMethodMaster_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_View_LineTestMethodMaster_Report", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SELECT_View_FGPhysicochemicalTestMethodMaster_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_View_FGPhysicochemicalTestMethodMaster_Report", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SELECT_View_PreservativeMethodMaster_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_View_PreservativeMethodMaster_Report", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SELECT_View_FDAPhysicochemicalTestMethodMaster_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_View_FDAPhysicochemicalTestMethodMaster_Report", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SELECT_View_FDAPreservativeTestMethodMaster_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_View_FDAPreservativeTestMethodMaster_Report", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_VIEW_ComplaintAnalysis_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@TransID", SqlDbType.BigInt, 8, ParameterDirection.Input, transid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_ComplaintAnalysis_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_VIEW_ComplaintAnalysis_Packing_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@TransID", SqlDbType.BigInt, 8, ParameterDirection.Input, transid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_ComplaintAnalysis_Packing_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_VIEW_ComplaintAnalysis_PhyChe_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@TransID", SqlDbType.BigInt, 8, ParameterDirection.Input, transid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_ComplaintAnalysis_PhyChe_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_ComplaintAnalysis_InvestigationSteps_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@TransID", SqlDbType.BigInt, 8, ParameterDirection.Input, transid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_ComplaintAnalysis_InvestigationSteps_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_ComplaintAnalysis_BatchNoCnt_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@BatchNo", SqlDbType.VarChar, 50, ParameterDirection.Input, batchno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_ComplaintAnalysis_BatchNoCnt_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_ComplaintAnalysis_FormulaNoCnt_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@TransID", SqlDbType.BigInt, 8, ParameterDirection.Input, transid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_ComplaintAnalysis_FormulaNoCnt_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_Complaint_TDB_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_Complaint_TDB_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet Select_tblWaterAnalysis()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblWaterAnalysis");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_WaterAnalysis_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@DateOfSampling", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_WaterAnalysis_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // Physicochemical Water analysis report
        public DataSet Select_tblPhysicoChemicalWaterAnalysis_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@DateOfSampling", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, phyChemSamplingDate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblPhysicoChemicalWaterAnalysis_Report", param);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_WaterAnalysisSampling_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_WaterAnalysisSampling_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_WaterAnalysisSampling_Report2()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                myparam[2] = ModHelper.CreateParameter("@Plant", SqlDbType.VarChar, 200, ParameterDirection.Input,plantNo);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_WaterAnalysisSampling_Report2", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_PreservativeTest_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_PreservativeTest_Report");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_VIEW_PreservativeTest_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_PreservativeTest_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_VIEW_Analysis_Summary_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_Analysis_Summary_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_FGReleaseDossier_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_FGReleaseDossier_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_FGReleaseDossierDetails_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_FGReleaseDossierDetails_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // This is used for RMMicrobiology Test Report
        public DataSet Select_RMMicrobiologyTest_Reports()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                myparam[2] = ModHelper.CreateParameter("@WithDate", SqlDbType.VarChar, 50, ParameterDirection.Input, withdate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_RMMicrobiologyTest_Reports", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Select_RMRetainerLocation_Report()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@LocationId", SqlDbType.BigInt, 8, ParameterDirection.Input, LocationID);

                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_RetainerLocation_Report", myparam).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // This is used for Ref sample management (FG)
        public DataSet Select_RSMgmtDetails_Fno_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_RSMgmtDetails_Fno_Report", param);
                return ds;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataSet Select_Bulk_Analysis_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_Bulk_Analysis_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        // This is used for Ref Sample Mgmt (RM)
        public DataSet Select_RMRSMgmtDetails_RMCodeID_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmcodeid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_RMRSMgmtDetails_RMCodeID_Report", param);
                return ds;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataSet Select_RM_Analysis_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmcodeid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_RM_Analysis_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_tblAdjustment_BatchSize()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblAdjustment_BatchSize", param);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_tblAdjustment_AdjID_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[2];
                param[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                param[1] = ModHelper.CreateParameter("@BatchSize", SqlDbType.Int, 4, ParameterDirection.Input, batchsize);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblAdjustment_AdjID_Report", param);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_RetainerSampleLocation_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                myparam[2] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_FGRetainerSampleLocation_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet Select_PendingDesctructLocation_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                myparam[2] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_PendingDesctructLocation_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet Select_RetainerSampleLocation_Report_PkgWo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                myparam[2] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_FGRetainerSampleLocation_Report_PkgWo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet Select_RetainerSampleLocation_Report_PkgWo_Pune()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                myparam[2] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_FGRetainerSampleLocation_Report_PkgWo_Pune", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// Show Report on parameter selection 
        /// </summary>
        /// <returns></returns>

        public DataSet Select_RMParameter_Reports()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@ParaNo", SqlDbType.Int, 4, ParameterDirection.Input, paraNo);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_RMParameter_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// RM Control Type Report. Report shows on Reduced control & Full control
        /// </summary>
        /// <returns></returns>
        public DataSet Select_RMControlType_Reports()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                myparam[2] = ModHelper.CreateParameter("@MethodType", SqlDbType.Char, 1, ParameterDirection.Input, methodType);
                myparam[3] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 1, ParameterDirection.Input, rmcodeid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_RMControlType_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Reference sample mgmt summary report. Datawise report
        /// </summary>
        public DataSet Select_RSMgmtSummary_Reports()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_RSMgmtSummary_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// FG Reference mgmt summary report
        /// </summary>
        /// <returns></returns>
        public DataSet Select_FGRefMgmtTransaction_Reports()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[2];
                param[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                param[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_FGRefMgmt_Report", param);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_AOC_File_Reports()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[2];
                param[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                param[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_AOC_File_Reports", param);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_FGDecleration_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[2];
                param[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                param[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_FGDecleration_Report", param);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_OOS_LogReport()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[2];
                param[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                param[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_View_OOS_LogReport", param);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Int64 GEtTestNo()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 50, ParameterDirection.Input, fgtlfid);
                Int64 TestId =Convert.ToInt64(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_GEtTestNo",param).ToString());
                return TestId;
            }
            catch(Exception)
            {
                throw;
            }
        }
        public DataSet Select_View_RM_Alignment_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[2];
                param[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                param[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_RM_Alignment_Report", param);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_View_RM_Alignment_Report_Aligned()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[2];
                param[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                param[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_RM_Alignment_Report_Aligned", param);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_RM_Alignment_Report_NotAligned()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[2];
                param[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                param[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_RM_Alignment_Report_NotAligned", param);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_View_RMCodeHistory_Report2()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[3];                
                
                param[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                param[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                param[2] = ModHelper.CreateParameter("@RMCodeID", SqlDbType.BigInt, 8, ParameterDirection.Input, rmcodeid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_RMCodeHistory_Report2", param);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_Analysis_Transaction_Reports()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_Analysis_Transaction_Reports", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //By Vishal Mahajan 26-09-2017
        /// <summary>
        /// Select Line Transaction Report
        /// </summary>
        /// <returns></returns>
        public DataSet Select_LineTransaction_Report(long lineDescrId, DateTime fromdate, DateTime todate)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[3]; 
                myparam[0] = ModHelper.CreateParameter("@LineDescriptionId", SqlDbType.BigInt, 50, ParameterDirection.Input, lineDescrId);
                myparam[1] = ModHelper.CreateParameter("@fromDate", SqlDbType.DateTime, 50, ParameterDirection.Input, fromdate);
                myparam[2] = ModHelper.CreateParameter("@toDate", SqlDbType.DateTime, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblLayoutLineTransactionReport", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_Made_LastProduction_Formula()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_Made_LastProduction_Formula");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        
        //By Vishal Mahajan 26-09-2017
        /// <summary>
        /// Select Line Transaction Report
        /// </summary>
        /// <returns></returns>
        public DataSet Select_LineTransaction_ReportNew(long lineDescrId, DateTime fromdate, DateTime todate)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@LineDescriptionId", SqlDbType.BigInt, 50, ParameterDirection.Input, lineDescrId);
                myparam[1] = ModHelper.CreateParameter("@fromDate", SqlDbType.DateTime, 50, ParameterDirection.Input, fromdate);
                myparam[2] = ModHelper.CreateParameter("@toDate", SqlDbType.DateTime, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SelectLineTransactionReport", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //By Vishal Mahajan 03-10-2017
        /// <summary>
        /// Select RMBarcode Checker Report
        /// </summary>
        /// <returns></returns> 
        public DataSet Select_RMBarcodeChecker_Report(DateTime fromdate, DateTime todate)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@fromDate", SqlDbType.DateTime, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@toDate", SqlDbType.DateTime, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMBarcodeCheckerReport", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Select_LineTransactionMaster_Report
        /// </summary>
        /// <param name="lineDescrId"></param>
        /// <param name="fromdate"></param>
        /// <param name="todate"></param>
        /// <returns></returns>
        public DataSet Select_LineTransactionMaster_Report(long lineDescrId, DateTime fromdate, DateTime todate)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@LineDescriptionId", SqlDbType.BigInt, 50, ParameterDirection.Input, lineDescrId);
                myparam[1] = ModHelper.CreateParameter("@fromDate", SqlDbType.DateTime, 50, ParameterDirection.Input, fromdate);
                myparam[2] = ModHelper.CreateParameter("@toDate", SqlDbType.DateTime, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SelectLineTransactionMasterReport", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_Bulk_BatchCode_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@StartDate", SqlDbType.DateTime, 4, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@EndDate", SqlDbType.DateTime, 4, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_Bulk_BatchCode_Report", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_Bulk_ValidatedNonValidated()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@fromdate", SqlDbType.DateTime, 4, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@todate", SqlDbType.DateTime, 4, ParameterDirection.Input, todate);
                myparam[2] = ModHelper.CreateParameter("@formulatype", SqlDbType.VarChar,50, ParameterDirection.Input, formulatype);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_Bulk_ValidatedNonValidated", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_View_tblLocationDistruction_DetailReport()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@LocationID", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
               
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_tblLocationDistruction_DetailReport", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_tblLocationDistruction_SummaryReport()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate ", SqlDbType.VarChar, 20, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate ", SqlDbType.VarChar, 20, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_tblLocationDistruction_SummaryReport", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

    
}
