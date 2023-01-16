using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DataFacade;


namespace BusinessFacade.Scoop_Class
{
    public class UPTestAtSamplingPoint_Class
    {

        #region private memebr
        Int64 UPSamplingPontTestID;
        Int64 SCPTestMethodID;
        int TestNo, AQLZ, AQLC, AQLM, AQLM1,AQL;
        bool Defect, IsLast;
        string TestName;
        string Time, ExpectedTime;
        Int64 UPTestAtSamplingPointId;
        bool NotDone;
        string NotDoneDescription;
        bool UPauthorityRemark;
        DateTime TimeBrief;
        bool QualityAuthorityRemark;
        string NotDoneDesc;

        Int64 _loginid;
        string _ResumeDescription;


        #endregion

        #region Properties

        public Int64 loginid
        {
            get { return _loginid; }
            set { _loginid = value; }
        }

        public string ResumeDescription
        {
            get { return _ResumeDescription; }
            set { _ResumeDescription = value; }
        }

        public Int64 uptestsamplingpointid
        {
            get { return UPSamplingPontTestID; }
            set { UPSamplingPontTestID = value; }
        }
        public Int64 sCPTestMethodID
        {
            get { return SCPTestMethodID; }
            set { SCPTestMethodID = value; }
        }
        public int testno
        {
            get { return TestNo; }
            set { TestNo = value; }
        }
        //Avinash 15-07-2014
        public int aql
        {
            get { return AQL; }
            set { AQL = value; }
        }

        public int aqlz
        {
            get { return AQLZ; }
            set { AQLZ = value; }
        }
        public int aqlc
        {
            get { return AQLC; }
            set { AQLC = value; }
        }
        public int aqlm
        {
            get { return AQLM; }
            set { AQLM = value; }
        }
        public int aqlm1
        {
            get { return AQLM1; }
            set { AQLM1 = value; }
        }
        public bool defect
        {
            get { return Defect; }
            set { Defect = value; }
        }
        public string time
        {
            get { return Time; }
            set { Time = value; }
        }
        public string expectedtime
        {
            get { return ExpectedTime; }
            set { ExpectedTime = value; }
        }
        public string testName
        {
            get { return TestName; }
            set { TestName = value; }

        }
        public Int64 uptestAtsamplingPointId
        {
            get { return UPTestAtSamplingPointId; }
            set { UPTestAtSamplingPointId = value; }

        }
        public bool isLast
        {
            get { return IsLast; }
            set { IsLast = value; }
        }
        public bool notdone
        {
            get { return NotDone; }
            set { NotDone = value; }
        }
        public string notdonedescription
        {
            get { return NotDoneDescription; }
            set { NotDoneDescription = value; }

        }
        public bool upauthorityremark
        {
            get { return UPauthorityRemark; }
            set { UPauthorityRemark = value; }
        }
        public DateTime timeBrief
        {
            get { return TimeBrief; }
            set { TimeBrief = value; }

        }
        public bool qualityAuthorityremark
        {

            get { return QualityAuthorityRemark; }
            set { QualityAuthorityRemark = value; }
        }
        public string notDoneDesc
        {
            get { return NotDoneDesc; }
            set { NotDoneDesc = value; }

        }

        private bool? _ApproveUpPMNotDone;
        public bool? ApproveUpPMNotDone
        {
            get { return _ApproveUpPMNotDone; }
            set { _ApproveUpPMNotDone = value; }

        }
        private bool? _ApproveQualityPMNotDone;
        public bool? ApproveQualityPMNotDone
        {
            get { return _ApproveQualityPMNotDone; }
            set { _ApproveQualityPMNotDone = value; }

        }

        #endregion

        #region function

        public bool insert_tblUPTestAtSAmplingPoint()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[13];
                myparam[0] = ModHelper.CreateParameter("@UPSamplingPontTestID", SqlDbType.BigInt, 8, ParameterDirection.Input, uptestsamplingpointid);
                myparam[1] = ModHelper.CreateParameter("@TestNo", SqlDbType.Int, 4, ParameterDirection.Input, testno);
                myparam[2] = ModHelper.CreateParameter("@AQLZ", SqlDbType.Int, 4, ParameterDirection.Input, aqlz);
                myparam[3] = ModHelper.CreateParameter("@AQLC", SqlDbType.Int, 4, ParameterDirection.Input, aqlc);
                myparam[4] = ModHelper.CreateParameter("@AQLM", SqlDbType.Int, 4, ParameterDirection.Input, aqlm);
                myparam[5] = ModHelper.CreateParameter("@AQLM1", SqlDbType.Int, 4, ParameterDirection.Input, aqlm1);
                myparam[6] = ModHelper.CreateParameter("@Defect", SqlDbType.Int, 4, ParameterDirection.Input, defect);
                myparam[7] = ModHelper.CreateParameter("@time", SqlDbType.VarChar, 100, ParameterDirection.Input, time);
                myparam[8] = ModHelper.CreateParameter("@ExpectedTime", SqlDbType.VarChar, 100, ParameterDirection.Input, expectedtime);
                myparam[9] = ModHelper.CreateParameter("@IsLast", SqlDbType.Bit, 1, ParameterDirection.Input, isLast);
                myparam[10] = ModHelper.CreateParameter("@NotDone", SqlDbType.Bit, 1, ParameterDirection.Input, notdone);
                myparam[11] = ModHelper.CreateParameter("@TimeBrief", SqlDbType.DateTime, 8, ParameterDirection.Input, timeBrief);
                myparam[12] = ModHelper.CreateParameter("@AQL", SqlDbType.Int, 4, ParameterDirection.Input, aql);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblUPTestAtSAmplingPoint", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }

        public Int64 GetLastAdded_tblUPTestAtSAmplingPoint()
        {
            try
            {
                Int64 Id = 0;
                Id = Convert.ToInt64(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_GetLastAdded_tblUPTestAtSAmplingPoint").ToString());
                return Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_SelectSamplingRow_tblUPTestAtSAmplingPoint()//to get all sampling rows which were ticked to test
        {
            DataSet ds = new DataSet();
            SqlParameter[] myparam = new SqlParameter[1];
            myparam[0] = ModHelper.CreateParameter("@UPSamplingPontTestID", SqlDbType.BigInt, 8, ParameterDirection.Input, uptestsamplingpointid);
            ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SelectSamplingRow_tblUPTestAtSAmplingPoint", myparam);
            return ds;

        }

        public DataSet Select_tblUPTestAtSAmplingPointByTime()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@UPSamplingPontTestID", SqlDbType.BigInt, 8, ParameterDirection.Input, uptestsamplingpointid);
                myparam[1] = ModHelper.CreateParameter("@time", SqlDbType.VarChar, 100, ParameterDirection.Input, time);
                myparam[2] = ModHelper.CreateParameter("@ExpectedTime", SqlDbType.VarChar, 100, ParameterDirection.Input, expectedtime);
                myparam[3] = ModHelper.CreateParameter("@TimeBrief", SqlDbType.DateTime, 8, ParameterDirection.Input, timeBrief);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblUPTestAtSAmplingPointByTime", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update_tblUPTestAtSAmplingPoint_OneAtTime()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[6];
                myparam[0] = ModHelper.CreateParameter("@UPTestAtSamplingPointID", SqlDbType.BigInt, 8, ParameterDirection.Input, uptestAtsamplingPointId);
                myparam[1] = ModHelper.CreateParameter("@AQLC", SqlDbType.Int, 4, ParameterDirection.Input, aqlc);
                myparam[2] = ModHelper.CreateParameter("@AQLM", SqlDbType.Int, 4, ParameterDirection.Input, aqlm);
                myparam[3] = ModHelper.CreateParameter("@AQLM1", SqlDbType.Int, 4, ParameterDirection.Input, aqlm1);
                myparam[4] = ModHelper.CreateParameter("@AQLZ", SqlDbType.Int, 4, ParameterDirection.Input, aqlz);
                myparam[5] = ModHelper.CreateParameter("@Defect", SqlDbType.Int, 4, ParameterDirection.Input, defect);
                myparam[6] = ModHelper.CreateParameter("@AQL", SqlDbType.Int, 4, ParameterDirection.Input, aql);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblUPTestAtSAmplingPoint_OneAtTime", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool Update_UpAuthorityRemark_tblUPTestAtSAmplingPoint()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@UPSamplingPontTestID", SqlDbType.BigInt, 8, ParameterDirection.Input, uptestsamplingpointid);
                myparam[1] = ModHelper.CreateParameter("@time", SqlDbType.VarChar, 100, ParameterDirection.Input, time);
                myparam[2] = ModHelper.CreateParameter("@ExpectedTime ", SqlDbType.VarChar, 100, ParameterDirection.Input, expectedtime);
                myparam[3] = ModHelper.CreateParameter("@upAuthorityRemark ", SqlDbType.Bit, 1, ParameterDirection.Input, upauthorityremark);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_UPAuthorityRemark_tblUPTestAtSAmplingPoint", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool Update_QualityAuthorityRemark_tblUPTestAtSAmplingPoint()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@UPSamplingPontTestID", SqlDbType.BigInt, 8, ParameterDirection.Input, uptestsamplingpointid);
                myparam[1] = ModHelper.CreateParameter("@time", SqlDbType.VarChar, 100, ParameterDirection.Input, time);
                myparam[2] = ModHelper.CreateParameter("@ExpectedTime ", SqlDbType.VarChar, 100, ParameterDirection.Input, expectedtime);
                myparam[3] = ModHelper.CreateParameter("@QualityAuthorityRemark", SqlDbType.Bit, 1, ParameterDirection.Input, qualityAuthorityremark);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_QualityRemark_tblUPTestAtSAmplingPoint", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public bool Notify_AuthorityRemark()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@UPSamplingPontTestID", SqlDbType.BigInt, 8, ParameterDirection.Input, uptestsamplingpointid);
                myparam[1] = ModHelper.CreateParameter("@time", SqlDbType.VarChar, 100, ParameterDirection.Input, time);
                myparam[2] = ModHelper.CreateParameter("@ExpectedTime", SqlDbType.VarChar, 100, ParameterDirection.Input, expectedtime);
                myparam[3] = ModHelper.CreateParameter("@Permited", SqlDbType.Bit, 1, ParameterDirection.Output);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Notify_AuthorityUPdate", myparam);
                return Convert.ToBoolean(myparam[3].Value.ToString());

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update_NotDoneDesc()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@UPSamplingPontTestID", SqlDbType.BigInt, 8, ParameterDirection.Input, uptestsamplingpointid);
                myparam[1] = ModHelper.CreateParameter("@time", SqlDbType.VarChar, 100, ParameterDirection.Input, time);
                myparam[2] = ModHelper.CreateParameter("@ExpectedTime ", SqlDbType.VarChar, 100, ParameterDirection.Input, expectedtime);
                myparam[3] = ModHelper.CreateParameter("@Desc", SqlDbType.NVarChar, 250, ParameterDirection.Input, notDoneDesc);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblUPTestAtSAmplingPointNotDoneDesc", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet Select_NotDoneDesc()
        {

            try
            {
                DataSet DS = new DataSet();
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@UPSamplingPontTestID", SqlDbType.BigInt, 8, ParameterDirection.Input, uptestsamplingpointid);
                myparam[1] = ModHelper.CreateParameter("@time", SqlDbType.VarChar, 100, ParameterDirection.Input, time);
                myparam[2] = ModHelper.CreateParameter("@ExpectedTime ", SqlDbType.VarChar, 100, ParameterDirection.Input, expectedtime);
                DS = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SelectNonDoneDesc_tblUPTestAtSAmplingPoint", myparam);
                return DS;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet Get_DEfectCount()
        {
            DataSet Ds = new DataSet();
            SqlParameter[] myparam = new SqlParameter[1];
            myparam[0] = ModHelper.CreateParameter("@UPSamplingPontTestID", SqlDbType.BigInt, 8, ParameterDirection.Input, uptestsamplingpointid);
            Ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_GetDefectCount_UptestSamplingPoint", myparam);
            return Ds;

        }

        public DataSet Get_DEfectCount2()
        {
            DataSet Ds = new DataSet();
            SqlParameter[] myparam = new SqlParameter[1];
            myparam[0] = ModHelper.CreateParameter("@UPSamplingPontTestID", SqlDbType.BigInt, 8, ParameterDirection.Input, uptestsamplingpointid);
            Ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_GetDefectCount_UptestSamplingPoint2", myparam);
            return Ds;
        }

        public bool Insert_tblScpTstMethod_SamplingPt_Rltn()
        {

            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@SCPTestMethodID ", SqlDbType.BigInt, 8, ParameterDirection.Input, SCPTestMethodID);
                myparam[1] = ModHelper.CreateParameter("@UPSamplingPointTestID", SqlDbType.BigInt, 8, ParameterDirection.Input,uptestsamplingpointid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblScpTstMethod_SamplingPt_Rltn", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        
        }

        public DataSet Select_Select_Scoop_TEstMethods()
        {
            try
            {
                DataSet Ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@UPSamplingPointTestID", SqlDbType.BigInt, 8, ParameterDirection.Input, uptestsamplingpointid);
                Ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_Scoop_TEstMethods", myparam);
                return Ds;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        
        }



        #endregion

        public int CheckIsLastWasDone()
        {
            SqlParameter[] myparam = new SqlParameter[2];
            myparam[0] = ModHelper.CreateParameter("@UPTestAtSamplingPointId", SqlDbType.BigInt, 8, ParameterDirection.Input, uptestsamplingpointid);
            myparam[1] = ModHelper.CreateParameter("@Count", SqlDbType.Int, 8, ParameterDirection.Output, DBNull.Value);
            DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_tblUPTestAtSamplingPoint_CheckIsLastWasDone", myparam);
            if (ds.Tables.Count>0)
            {
                if (ds.Tables[0].Rows.Count>0)
                {
                    int Count = Convert.ToInt32(ds.Tables[0].Rows[0]["IsLast"]);
                    return Count;
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }
        /// <summary>
        /// This Method Update ApproveUpPMNotDone Flag When Get Aproval from UP authority
        /// </summary>
        /// <returns></returns>

        public bool Update_NotDoneDescAfterUPApproval()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@UPSamplingPontTestID", SqlDbType.BigInt, 8, ParameterDirection.Input, uptestsamplingpointid);
                myparam[1] = ModHelper.CreateParameter("@time", SqlDbType.VarChar, 100, ParameterDirection.Input, time);
                //myparam[2] = ModHelper.CreateParameter("@ExpectedTime ", SqlDbType.VarChar, 100, ParameterDirection.Input, expectedtime);
                myparam[2] = ModHelper.CreateParameter("@Desc", SqlDbType.NVarChar, 250, ParameterDirection.Input, notDoneDesc);
                myparam[3] = ModHelper.CreateParameter("@ApproveUpPMNotDone", SqlDbType.Bit, 1, ParameterDirection.Input, ApproveUpPMNotDone);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblUPTestAtSAmplingPointNotDoneDescUPApproval", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// This Method Update ApproveQualityPMNotDone Flag When Get Aproval from quality authority
        /// </summary>
        /// <returns></returns>

        public bool Update_NotDoneDescAfterQualityApproval()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@UPSamplingPontTestID", SqlDbType.BigInt, 8, ParameterDirection.Input, uptestsamplingpointid);
                myparam[1] = ModHelper.CreateParameter("@time", SqlDbType.VarChar, 100, ParameterDirection.Input, time);
                //myparam[2] = ModHelper.CreateParameter("@ExpectedTime ", SqlDbType.VarChar, 100, ParameterDirection.Input, expectedtime);
                myparam[2] = ModHelper.CreateParameter("@Desc", SqlDbType.NVarChar, 250, ParameterDirection.Input, notDoneDesc);
                myparam[3] = ModHelper.CreateParameter("@ApproveQualityPMNotDone", SqlDbType.Bit, 1, ParameterDirection.Input, ApproveQualityPMNotDone);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblUPTestAtSAmplingPointNotDoneDescQualityApproval", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CheckPMNotDone()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@UPTestAtSamplingPointId", SqlDbType.BigInt, 8, ParameterDirection.Input, uptestsamplingpointid);
                myparam[1] = ModHelper.CreateParameter("@time", SqlDbType.VarChar, 100, ParameterDirection.Input, time);
                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_tblUPTestAtSamplingPoint_CheckIsPMDone", myparam);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int Count = Convert.ToInt32(ds.Tables[0].Rows[0]["NotDone"]);
                        NotDoneDesc = Convert.ToString(ds.Tables[0].Rows[0]["NotDoneDescription"]);
                        return Count;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int CheckQualityApproval()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@UPTestAtSamplingPointId", SqlDbType.BigInt, 8, ParameterDirection.Input, uptestsamplingpointid);
                myparam[1] = ModHelper.CreateParameter("@time", SqlDbType.VarChar, 100, ParameterDirection.Input, time);
                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_tblUPTestAtSamplingPoint_CheckIsPMNotDoneQualityApprove", myparam);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int Count = Convert.ToInt32(ds.Tables[0].Rows[0]["ApproveQualityPMNotDone"]);
                        return Count;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            //throw new Exception("The method or operation is not implemented.");
        }

        public int CheckUPApproval()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@UPTestAtSamplingPointId", SqlDbType.BigInt, 8, ParameterDirection.Input, uptestsamplingpointid);
                myparam[1] = ModHelper.CreateParameter("@time", SqlDbType.VarChar, 100, ParameterDirection.Input, time);
                DataSet ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_tblUPTestAtSamplingPoint_CheckIsPMNotDoneUPApprove", myparam);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        int Count = Convert.ToInt32(ds.Tables[0].Rows[0]["ApproveUpPMNotDone"]);
                        return Count;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            //throw new Exception("The method or operation is not implemented.");
        }       


        public int getUPTestAtSamplingPointID()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@Upsamplingpointid", SqlDbType.BigInt, 8, ParameterDirection.Input, uptestsamplingpointid);
                myparam[1] = ModHelper.CreateParameter("@time", SqlDbType.VarChar, 100, ParameterDirection.Input, time);
                myparam[2] = ModHelper.CreateParameter("@ExpectedTime", SqlDbType.VarChar, 100, ParameterDirection.Input, expectedtime);
                myparam[3] = ModHelper.CreateParameter("@notDoneDesc", SqlDbType.NVarChar, 250, ParameterDirection.Input, notDoneDesc);
                //myparam[4] = ModHelper.CreateParameter("@NotDone", SqlDbType.Bit, 1, ParameterDirection.Input, true);

                DataSet ds=SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_UPTestAtSamplingPointID", myparam);
                if (ds.Tables.Count>0)
                {
                    if (ds.Tables[0].Rows.Count>0)
                    {
                        int idPK = Convert.ToInt32(ds.Tables[0].Rows[0]["UPTestAtSamplingPointID"].ToString());
                        if (ds.Tables[0].Rows[0]["ApproveQualityPMNotDone"] != DBNull.Value)
                        {
                            ApproveQualityPMNotDone = Convert.ToBoolean(ds.Tables[0].Rows[0]["ApproveQualityPMNotDone"]);
                        }
                        if (ds.Tables[0].Rows[0]["ApproveUpPMNotDone"] != DBNull.Value)
                        {
                            ApproveUpPMNotDone = Convert.ToBoolean(ds.Tables[0].Rows[0]["ApproveUpPMNotDone"]);
                        }
                        return idPK;
                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }
                //return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update_ResumeLastSample()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[5];
                myparam[0] = ModHelper.CreateParameter("@UPSamplingPontTestID", SqlDbType.BigInt, 8, ParameterDirection.Input, uptestsamplingpointid);
                myparam[1] = ModHelper.CreateParameter("@time", SqlDbType.VarChar, 100, ParameterDirection.Input, time);
                myparam[2] = ModHelper.CreateParameter("@ExpectedTime ", SqlDbType.VarChar, 100, ParameterDirection.Input, expectedtime);
                myparam[3] = ModHelper.CreateParameter("@ResumeDescription", SqlDbType.NVarChar, 400, ParameterDirection.Input, ResumeDescription);
                myparam[4] = ModHelper.CreateParameter("@ResumeBy", SqlDbType.BigInt, 8, ParameterDirection.Input, loginid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_ResumeLastSample", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
