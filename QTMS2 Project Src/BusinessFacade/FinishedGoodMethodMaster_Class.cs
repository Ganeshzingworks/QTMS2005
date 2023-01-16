using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;
namespace BusinessFacade
{
    public class FinishedGoodMethodMaster_Class
    {
        # region Varibles
        private long PKGTechNo_1;
        private string InspectionMethod_3;
        private string Type_11;
        private int SampleSize;
        private string AQL;
        private string AQLZ;
        private string AQLC;
        private string AQLM;
        private string AQLM1;
        private string Frequency;
        private int TestNo_2;
        private string LotSize_12;
        private string TorqueMin;
        private string TorqueMax;
        # endregion
        # region Properties
        public string torquemin
        {
            get { return TorqueMin; }
            set { TorqueMin = value; }
        }
        public string torquemax
        {
            get { return TorqueMax; }
            set { TorqueMax = value; }
        }  
        public int testno_2
        {
            get { return TestNo_2; }
            set { TestNo_2 = value; }
        }
        public int samplesize
        {
            get { return SampleSize; }
            set { SampleSize = value; }
        }
        public string lotsize_12
        {
            get { return LotSize_12; }
            set { LotSize_12 = value; }
        }
        public string inspectionMethod_3
        {
            get { return InspectionMethod_3; }
            set { InspectionMethod_3 = value; }
        }
        public long pkgTechNo_1
        {
            get { return PKGTechNo_1; }
            set { PKGTechNo_1 = value; }
        }
        public string type_11
        {
            get { return Type_11; }
            set { Type_11 = value; }
        }
        public string aql
        {
            get { return AQL; }
            set { AQL = value; }
        }
        public string aqlz
        {
            get { return AQLZ; }
            set { AQLZ = value; }
        }
        public string aqlc
        {
            get { return AQLC; }
            set { AQLC = value; }
        }
        public string aqlm
        {
            get { return AQLM; }
            set { AQLM = value; }
        }
        public string aqlm1
        {
            get { return AQLM1; }
            set { AQLM1 = value; }
        }
       
       
        public string frequency
        {
            get { return Frequency; }
            set { Frequency = value; }
        }
       
        # endregion
        # region Functions
        public DataSet Select_From_tblFGMethodMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblFinishedGoodMethodMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
        //public DataSet Select_From_tblFGMethodMaster_MethodNo()
        //{
        //    try
        //    {
        //        DataSet ds = new DataSet();
        //        SqlParameter[] myaparam = new SqlParameter[1];
        //        myaparam[0] = ModHelper.CreateParameter("@MethodNo", SqlDbType.Int, 4, ParameterDirection.Input, methodno);
        //        ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblFinishedGoodMethodMaster_MethodNo",myaparam);
        //        return ds;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;

        //    }

        //}
        //public DataSet Select_From_tblFGMethodMaster_FgMethodNo()
        //{
        //    //try
        //    //{
        //    //    DataSet ds = new DataSet();
        //    //    SqlParameter[] myaparam = new SqlParameter[1];
        //    //    myaparam[0] = ModHelper.CreateParameter("@FgMethodNo", SqlDbType.BigInt,8, ParameterDirection.Input,fgmethodno);
        //    //    ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblFinishedGoodMethodMaster_FgMethodNo", myaparam);
        //    //    return ds;
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    throw ex;

        //    //}

        //}
        public bool Delete_From_tblFGMethodMaster_FgMethodNo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myaparam = new SqlParameter[1];
                myaparam[0] = ModHelper.CreateParameter("@FgMethodNo", SqlDbType.BigInt, 8, ParameterDirection.Input, testno_2);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_DELETE_tblFinishedGoodMethodMaster_FgMethodNo", myaparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        public DataSet  Select_Existsin_tblFinishGoodDetails()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myaparam = new SqlParameter[3];
                myaparam[0] = ModHelper.CreateParameter("@PKGTechNo", SqlDbType.BigInt, 8, ParameterDirection.Input, pkgTechNo_1);                
                myaparam[1] = ModHelper.CreateParameter("@InspectionMethod", SqlDbType.VarChar, 50, ParameterDirection.Input, inspectionMethod_3);
                myaparam[2] = ModHelper.CreateParameter("@TestNo", SqlDbType.Int, 4, ParameterDirection.Input, testno_2);

                ds=SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_Existsin_tblFinishGoodDetails", myaparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert_tblFinishedGoodMethodMaster()
        {
            try
            {
                SqlParameter[] myaparam = new SqlParameter[14];
                myaparam[0] = ModHelper.CreateParameter("@PKGTechNo_1", SqlDbType.BigInt,8, ParameterDirection.Input, PKGTechNo_1);
                myaparam[1] = ModHelper.CreateParameter("@TestNo_2", SqlDbType.Int,4, ParameterDirection.Input, testno_2);
                myaparam[2] = ModHelper.CreateParameter("@InspectionMethod_3", SqlDbType.VarChar, 50, ParameterDirection.Input, InspectionMethod_3);
                myaparam[3] = ModHelper.CreateParameter("@Frequency_4", SqlDbType.VarChar,50, ParameterDirection.Input, frequency);
                myaparam[4] = ModHelper.CreateParameter("@AQL_5", SqlDbType.VarChar,50, ParameterDirection.Input, AQL);
                myaparam[5] = ModHelper.CreateParameter("@AQLZ_6", SqlDbType.VarChar,50, ParameterDirection.Input, AQLZ);
                myaparam[6] = ModHelper.CreateParameter("@AQLC_7", SqlDbType.VarChar,50, ParameterDirection.Input, AQLC);
                myaparam[7] = ModHelper.CreateParameter("@AQLM_8", SqlDbType.VarChar,50, ParameterDirection.Input, AQLM);
                myaparam[8] = ModHelper.CreateParameter("@AQLM1_9", SqlDbType.VarChar,50, ParameterDirection.Input, AQLM1);
                myaparam[9] = ModHelper.CreateParameter("@SampleSize_10", SqlDbType.Int, 4, ParameterDirection.Input, SampleSize);
                myaparam[10] = ModHelper.CreateParameter("@Type_11", SqlDbType.VarChar,50, ParameterDirection.Input, type_11);
                myaparam[11] = ModHelper.CreateParameter("@LotSize_12", SqlDbType.VarChar, 50, ParameterDirection.Input, lotsize_12);
                myaparam[12] = ModHelper.CreateParameter("@TorqueMin", SqlDbType.VarChar, 50, ParameterDirection.Input, torquemin);
                myaparam[13] = ModHelper.CreateParameter("@TorqueMax", SqlDbType.VarChar, 50, ParameterDirection.Input, torquemax);
                
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblFinishGoodDetails", myaparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update_tblFinishedGoodMethodMaster()
        {
            try
            {
                SqlParameter[] myaparam = new SqlParameter[14];
                myaparam[0] = ModHelper.CreateParameter("@PKGTechNo_1", SqlDbType.BigInt, 8, ParameterDirection.Input, PKGTechNo_1);
                myaparam[1] = ModHelper.CreateParameter("@TestNo_2", SqlDbType.Int, 4, ParameterDirection.Input, testno_2);
                myaparam[2] = ModHelper.CreateParameter("@InspectionMethod_3", SqlDbType.VarChar, 50, ParameterDirection.Input, InspectionMethod_3);
                myaparam[3] = ModHelper.CreateParameter("@Frequency_4", SqlDbType.VarChar, 50, ParameterDirection.Input, frequency);
                myaparam[4] = ModHelper.CreateParameter("@AQL_5", SqlDbType.VarChar, 50, ParameterDirection.Input, AQL);
                myaparam[5] = ModHelper.CreateParameter("@AQLZ_6", SqlDbType.VarChar, 50, ParameterDirection.Input, AQLZ);
                myaparam[6] = ModHelper.CreateParameter("@AQLC_7", SqlDbType.VarChar, 50, ParameterDirection.Input, AQLC);
                myaparam[7] = ModHelper.CreateParameter("@AQLM_8", SqlDbType.VarChar, 50, ParameterDirection.Input, AQLM);
                myaparam[8] = ModHelper.CreateParameter("@AQLM1_9", SqlDbType.VarChar, 50, ParameterDirection.Input, AQLM1);
                myaparam[9] = ModHelper.CreateParameter("@SampleSize_10", SqlDbType.Int, 4, ParameterDirection.Input, SampleSize);
                myaparam[10] = ModHelper.CreateParameter("@Type_11", SqlDbType.VarChar, 50, ParameterDirection.Input, type_11);
                myaparam[11] = ModHelper.CreateParameter("@LotSize_12", SqlDbType.VarChar, 50, ParameterDirection.Input, lotsize_12);
                myaparam[12] = ModHelper.CreateParameter("@TorqueMin", SqlDbType.VarChar, 50, ParameterDirection.Input, torquemin);
                myaparam[13] = ModHelper.CreateParameter("@TorqueMax", SqlDbType.VarChar, 50, ParameterDirection.Input, torquemax);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblFinishGoodDetails", myaparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        # endregion

    }
}
