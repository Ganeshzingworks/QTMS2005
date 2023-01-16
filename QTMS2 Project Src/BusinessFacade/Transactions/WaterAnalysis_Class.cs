using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;

namespace BusinessFacade.Transactions
{
    public class WaterAnalysis_Class
    {
        private long WANo;
        public long wano
        {
            get { return WANo; }
            set { WANo = value; }
        }
        private string MediaLotNo;
        public string medialotno
        {
            get { return MediaLotNo; }
            set { MediaLotNo = value; }
        }
        private string Norms;
        public string norms
        {
            get { return Norms; }
            set { Norms = value; }
        }
        private string AmtOfWaterSampled;
        public string amtofwatersampled
        {
            get { return AmtOfWaterSampled; }
            set { AmtOfWaterSampled = value; }
        }
        private string DateOfSampling;
        public string dateofsampling
        {
            get { return DateOfSampling; }
            set { DateOfSampling = value; }
        }
        private char Status;
        public char status
        {
            get { return Status; }
            set { Status = value; }
        }
        private string Comment;
        public string comment
        {
            get { return Comment; }
            set { Comment = value; }
        }
        private int LoginID;
        public int loginid
        {
            get { return LoginID; }
            set { LoginID = value; }
        }
        private int InspectedBy;
        public int inspectedby
        {
            get { return InspectedBy; }
            set { InspectedBy = value; }
        }
        private long SamplingNo;
        public long samplingno
        {
            get { return SamplingNo; }
            set { SamplingNo = value; }
        }
        private int SamplingPoint;
        public int samplingpoint
        {
            get { return SamplingPoint; }
            set { SamplingPoint = value; }
        }   
        private string StartTime;
        public string starttime
        {
            get { return StartTime; }
            set { StartTime = value; }
        }        
        private string FinishTime;
        public string finishtime
        {
            get { return FinishTime; }
            set { FinishTime = value; }
        }        
        private string AnalysisDate;
        public string analysisdate
        {
            get { return AnalysisDate; }
            set { AnalysisDate = value; }
        }        
        private string AnalysisTime;
        public string analysistime
        {
            get { return AnalysisTime; }
            set { AnalysisTime = value; }
        }
        private string ResultDate;
        public string resultdate
        {
            get { return ResultDate; }
            set { ResultDate = value; }
        }
        private string ResultTime;
        public string resulttime
        {
            get { return ResultTime; }
            set { ResultTime = value; }
        }
        private string Result;
        public string result
        {
            get { return Result; }
            set { Result = value; }
        }
        private double CFUML;
        public double cfuml
        {
            get { return CFUML; }
            set { CFUML = value; }
        }
        private string IncubTemp;
        public string incubtemp
        {
            get { return IncubTemp; }
            set { IncubTemp = value; }
        }

        private string PHNorms;

        public string phnorms
        {
            get { return PHNorms; }
            set { PHNorms = value; }
        }

        private string PHResult;

        public string phresult
        {
            get { return PHResult; }
            set { PHResult = value; }
        }
        private string Conductivity;

        public string conductivity
        {
            get { return Conductivity; }
            set { Conductivity = value; }
        }
        private string ConductivityResult;

        public string conductivityresult
        {
            get { return ConductivityResult; }
            set { ConductivityResult = value; }
        }

        private string AspectNorms;

        public string aspectnorm
        {
            get { return AspectNorms; }
            set { AspectNorms = value; }
        }

        private string AspectResult;

        public string aspectresult
        {
            get { return AspectResult; }
            set { AspectResult = value; }
        }

        private string OdorNorms;

        public string odornorms
        {
            get { return OdorNorms; }
            set { OdorNorms = value; }
        }
        private string OdorResult;

        public string odorresult
        {
            get { return OdorResult; }
            set { OdorResult = value; }
        }
        private string ColorNorms;

        public string colornorms
        {
            get { return ColorNorms; }
            set { ColorNorms = value; }
        }
        private string ColorResult;

        public string colorresult
        {
            get { return ColorResult; }
            set { ColorResult = value; }
        }

        private DateTime PHYChemSamplingDate;

        public DateTime phyChemSamplingDate
        {
            get { return PHYChemSamplingDate; }
            set { PHYChemSamplingDate = value; }
        }

        private long PhyChemWA;

        public long phyChemWA
        {
            get { return PhyChemWA; }
            set { PhyChemWA = value; }
        }

        private string Plant;

        public string plant
        {
            get { return Plant; }
            set { Plant = value; }
        }

        private string AnalysisType;
        public string analysistype
        {
            get { return AnalysisType; }
            set { AnalysisType = value; }
        }

        private long PID;

        public long pid
        {
            get { return PID; }
            set { PID = value; }
        }
	

        public DataSet Select_tblWaterAnalysis_MediaLotNo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@MediaLotNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, medialotno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblWaterAnalysis_MediaLotNo", param);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblWaterAnalysis_DateOfsampling()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@DateOfSampling", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, dateofsampling);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblWaterAnalysis_DateOfsampling", param);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblWaterAnalysis_DateOfsampling2()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[2];
                param[0] = ModHelper.CreateParameter("@DateOfSampling", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, dateofsampling);
                param[1] = ModHelper.CreateParameter("@Plant", SqlDbType.VarChar, 200, ParameterDirection.Input, plant);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblWaterAnalysis_DateOfsampling2", param);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update_tblWaterAnalysis()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[10];
                param[0] = ModHelper.CreateParameter("@MediaLotNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, medialotno);
                param[1] = ModHelper.CreateParameter("@DateOfSampling", SqlDbType.SmallDateTime, 50, ParameterDirection.Input, dateofsampling);
                param[2] = ModHelper.CreateParameter("@Norms", SqlDbType.NVarChar, 50, ParameterDirection.Input, norms);
                param[3] = ModHelper.CreateParameter("@AmtWaterFiltered", SqlDbType.NVarChar, 50, ParameterDirection.Input, amtofwatersampled);                
                param[4] = ModHelper.CreateParameter("@Status", SqlDbType.Char, 1, ParameterDirection.Input, status);
                param[5] = ModHelper.CreateParameter("@Comment", SqlDbType.NVarChar, 250, ParameterDirection.Input, comment);
                param[6] = ModHelper.CreateParameter("@InspectedBy", SqlDbType.Int, 4, ParameterDirection.Input, inspectedby);
                param[7] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
                param[8] = ModHelper.CreateParameter("@WANo", SqlDbType.BigInt, 8, ParameterDirection.Input, wano);
                param[9] = ModHelper.CreateParameter("@AnalysisType", SqlDbType.VarChar, 20, ParameterDirection.Input, analysistype);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblWaterAnalysis", param);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Insert_tblWaterAnalysis()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[11];
                param[0] = ModHelper.CreateParameter("@MediaLotNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, medialotno);
                param[1] = ModHelper.CreateParameter("@DateOfSampling", SqlDbType.SmallDateTime, 50, ParameterDirection.Input, dateofsampling);
                param[2] = ModHelper.CreateParameter("@Norms", SqlDbType.NVarChar, 50, ParameterDirection.Input, norms);
                param[3] = ModHelper.CreateParameter("@AmtWaterFiltered", SqlDbType.NVarChar, 50, ParameterDirection.Input, amtofwatersampled);                
                param[4] = ModHelper.CreateParameter("@Status", SqlDbType.Char, 1, ParameterDirection.Input, status);
                param[5] = ModHelper.CreateParameter("@Comment", SqlDbType.NVarChar, 250, ParameterDirection.Input, comment);
                param[6] = ModHelper.CreateParameter("@InspectedBy", SqlDbType.Int, 4, ParameterDirection.Input, inspectedby);
                param[7] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
                param[8] = ModHelper.CreateParameter("@WANo", SqlDbType.BigInt, 8, ParameterDirection.Output, wano);
                param[9] = ModHelper.CreateParameter("@Plant", SqlDbType.VarChar, 200, ParameterDirection.Input, plant);
                param[10] = ModHelper.CreateParameter("@AnalysisType", SqlDbType.VarChar, 20, ParameterDirection.Input, analysistype);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblWaterAnalysis", param);
                return Convert.ToInt64(param[8].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblWaterAnalysisSampling_WANo_SamplingPoint()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[2];
                param[0] = ModHelper.CreateParameter("@WANo", SqlDbType.BigInt, 8, ParameterDirection.Input, wano);
                param[1] = ModHelper.CreateParameter("@SamplingPoint", SqlDbType.Int, 4, ParameterDirection.Input, samplingpoint);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblWaterAnalysisSampling_WANo_SamplingPoint", param);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update_tblWaterAnalysisSampling()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[12];
                param[0] = ModHelper.CreateParameter("@WANo", SqlDbType.BigInt, 8, ParameterDirection.Input, wano);
                param[1] = ModHelper.CreateParameter("@SamplingPoint", SqlDbType.Int, 4, ParameterDirection.Input, samplingpoint);
                param[2] = ModHelper.CreateParameter("@StartTime", SqlDbType.NVarChar, 50, ParameterDirection.Input, starttime);
                param[3] = ModHelper.CreateParameter("@FinishTime", SqlDbType.NVarChar, 50, ParameterDirection.Input, finishtime);
                param[4] = ModHelper.CreateParameter("@AnalysisDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, analysisdate);
                param[5] = ModHelper.CreateParameter("@AnalysisTime", SqlDbType.NVarChar, 50, ParameterDirection.Input, analysistime);
                param[6] = ModHelper.CreateParameter("@ResultDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, resultdate);
                param[7] = ModHelper.CreateParameter("@ResultTime", SqlDbType.NVarChar, 50, ParameterDirection.Input, resulttime);
                param[8] = ModHelper.CreateParameter("@Result", SqlDbType.Int, 4, ParameterDirection.Input, result);
                param[9] = ModHelper.CreateParameter("@CFUML", SqlDbType.Float, 8, ParameterDirection.Input, cfuml);
                param[10] = ModHelper.CreateParameter("@IncubTemp", SqlDbType.NVarChar, 50, ParameterDirection.Input, incubtemp);
                param[11] = ModHelper.CreateParameter("@SamplingNo", SqlDbType.BigInt, 8, ParameterDirection.Input, samplingno);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblWaterAnalysisSampling", param);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Insert_tblWaterAnalysisSampling()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[12];
                param[0] = ModHelper.CreateParameter("@WANo", SqlDbType.BigInt, 8, ParameterDirection.Input, wano);
                param[1] = ModHelper.CreateParameter("@SamplingPoint", SqlDbType.Int, 4, ParameterDirection.Input, samplingpoint);
                param[2] = ModHelper.CreateParameter("@StartTime", SqlDbType.NVarChar, 50, ParameterDirection.Input, starttime);                
                param[3] = ModHelper.CreateParameter("@FinishTime", SqlDbType.NVarChar, 50, ParameterDirection.Input, finishtime);
                param[4] = ModHelper.CreateParameter("@AnalysisDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, analysisdate);
                param[5] = ModHelper.CreateParameter("@AnalysisTime", SqlDbType.NVarChar, 50, ParameterDirection.Input, analysistime);
                param[6] = ModHelper.CreateParameter("@ResultDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, resultdate);
                param[7] = ModHelper.CreateParameter("@ResultTime", SqlDbType.NVarChar, 50, ParameterDirection.Input, resulttime);
                param[8] = ModHelper.CreateParameter("@Result", SqlDbType.Int, 4, ParameterDirection.Input, result);
                param[9] = ModHelper.CreateParameter("@CFUML", SqlDbType.Float, 8, ParameterDirection.Input, cfuml);
                param[10] = ModHelper.CreateParameter("@IncubTemp", SqlDbType.NVarChar, 50, ParameterDirection.Input, incubtemp);
                param[11] = ModHelper.CreateParameter("@SamplingNo", SqlDbType.BigInt, 8, ParameterDirection.Output, samplingno);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblWaterAnalysisSampling", param);
                return Convert.ToInt64(param[11].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Get_RecordCount()
        {
            int cnt = 0;
            SqlParameter[] param = new SqlParameter[1];
            param[0] = ModHelper.CreateParameter("@WANo", SqlDbType.BigInt, 8, ParameterDirection.Input, wano);
            cnt = Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure,"STP_Get_WA_RecordCount", param).ToString());
            return cnt;
        }

        #region Physico Chemical Water analysis

        public DataSet Select_tblPhysicoChemicalWaterAnalysis_DateOfsampling()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@DateOfSampling", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, phyChemSamplingDate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblPhysicoChemicalWaterAnalysis_DateOfsampling", param);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblPhysicoChemicalWaterAnalysis_DateOfsampling2()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[2];
                param[0] = ModHelper.CreateParameter("@DateOfSampling", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, phyChemSamplingDate);
                param[1] = ModHelper.CreateParameter("@Plant", SqlDbType.VarChar, 200, ParameterDirection.Input, plant);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblPhysicoChemicalWaterAnalysis_DateOfsampling2", param);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update_tblPhysicoChemicalWaterAnalysis()
        {
            try
            {                
                SqlParameter[] param = new SqlParameter[16];
                param[0] = ModHelper.CreateParameter("@DateOfSampling", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, phyChemSamplingDate);
                param[1] = ModHelper.CreateParameter("@PHNorms", SqlDbType.NVarChar, 50, ParameterDirection.Input, phnorms);
                param[2] = ModHelper.CreateParameter("@PHResult", SqlDbType.NVarChar, 50, ParameterDirection.Input, phresult);
                param[3] = ModHelper.CreateParameter("@Conductivity", SqlDbType.NVarChar, 50, ParameterDirection.Input, conductivity);
                param[4] = ModHelper.CreateParameter("@ConductivityResult", SqlDbType.NVarChar, 50, ParameterDirection.Input, conductivityresult);
                param[5] = ModHelper.CreateParameter("@AspectNorms", SqlDbType.NVarChar, 50, ParameterDirection.Input, aspectnorm);
                param[6] = ModHelper.CreateParameter("@AspectResult", SqlDbType.NVarChar, 50, ParameterDirection.Input, aspectresult);
                param[7] = ModHelper.CreateParameter("@OdorNorms", SqlDbType.NVarChar, 50, ParameterDirection.Input, odornorms);
                param[8] = ModHelper.CreateParameter("@OdorResult", SqlDbType.NVarChar, 50, ParameterDirection.Input, odorresult);
                param[9] = ModHelper.CreateParameter("@ColorNorms", SqlDbType.NVarChar, 50, ParameterDirection.Input, colornorms);
                param[10] = ModHelper.CreateParameter("@ColorResult", SqlDbType.NVarChar, 50, ParameterDirection.Input, colorresult);
                param[11] = ModHelper.CreateParameter("@Status", SqlDbType.Char, 1, ParameterDirection.Input, status);
                param[12] = ModHelper.CreateParameter("@Comment", SqlDbType.NVarChar, 250, ParameterDirection.Input, comment);
                param[13] = ModHelper.CreateParameter("@InspectedBy", SqlDbType.Int, 4, ParameterDirection.Input, inspectedby);
                param[14] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
                param[15] = ModHelper.CreateParameter("PhyChemWA", SqlDbType.BigInt, 8, ParameterDirection.Input, PhyChemWA);
                int i = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblPhysicoChemicalWaterAnalysis", param);
                if (i>0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert_tblPhysicoChemicalWaterAnalysis()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[16];
                param[0] = ModHelper.CreateParameter("@DateOfSampling", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, phyChemSamplingDate);
                param[1] = ModHelper.CreateParameter("@PHNorms", SqlDbType.NVarChar, 50, ParameterDirection.Input, phnorms);
                param[2] = ModHelper.CreateParameter("@PHResult", SqlDbType.NVarChar, 50, ParameterDirection.Input, phresult);
                param[3] = ModHelper.CreateParameter("@Conductivity", SqlDbType.NVarChar, 50, ParameterDirection.Input, conductivity);
                param[4] = ModHelper.CreateParameter("@ConductivityResult", SqlDbType.NVarChar, 50, ParameterDirection.Input, conductivityresult);
                param[5] = ModHelper.CreateParameter("@AspectNorms", SqlDbType.NVarChar, 50, ParameterDirection.Input, aspectnorm);
                param[6] = ModHelper.CreateParameter("@AspectResult", SqlDbType.NVarChar, 50, ParameterDirection.Input, aspectresult);
                param[7] = ModHelper.CreateParameter("@OdorNorms", SqlDbType.NVarChar, 50, ParameterDirection.Input, odornorms);
                param[8] = ModHelper.CreateParameter("@OdorResult", SqlDbType.NVarChar, 50, ParameterDirection.Input, odorresult);
                param[9] = ModHelper.CreateParameter("@ColorNorms", SqlDbType.NVarChar, 50, ParameterDirection.Input, colornorms);
                param[10] = ModHelper.CreateParameter("@ColorResult", SqlDbType.NVarChar, 50, ParameterDirection.Input, colorresult);
                param[11] = ModHelper.CreateParameter("@Status", SqlDbType.Char, 1, ParameterDirection.Input, status);
                param[12] = ModHelper.CreateParameter("@Comment", SqlDbType.NVarChar, 250, ParameterDirection.Input, comment);
                param[13] = ModHelper.CreateParameter("@InspectedBy", SqlDbType.Int, 4, ParameterDirection.Input, inspectedby);
                param[14] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
                param[15] = ModHelper.CreateParameter("@Plant", SqlDbType.VarChar, 200, ParameterDirection.Input, plant);
                int i = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblPhysicoChemicalWaterAnalysis", param);
                if (i>0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblPlantMaster()
        {
            try
            {
                DataSet ds = new DataSet();

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblPlantMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblPlantMaster_ByPID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@PID", SqlDbType.BigInt, 8, ParameterDirection.Input, pid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblPlantMaster_ByPID", param);
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
