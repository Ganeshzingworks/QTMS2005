using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;

namespace BusinessFacade.Transactions
{
    public class RMMicrobiologytest_Class
    {
        #region Variables & Properties
        private long rmcodeid;

        public long RMCodeID
        {
            get { return rmcodeid; }
            set { rmcodeid = value; }
        }
        private string receiptdate;

        public string ReceiptDate
        {
            get { return receiptdate; }
            set { receiptdate = value; }
        }
        private string plantlotno;

        public string PlantLotNo
        {
            get { return plantlotno; }
            set { plantlotno = value; }
        }
	
        private long rmdetailid;

        public long RMDetailID
        {
            get { return rmdetailid; }
            set { rmdetailid = value; }
        }

        private string medialotno;

        public string MediaLotNo
        {
            get { return medialotno; }
            set { medialotno = value; }
        }
        private string methodname;

        public string MethodName
        {
            get { return methodname; }
            set { methodname = value; }
        }
        private bool microdone;
        public bool MicroDone
        {
            get { return microdone; }
            set { microdone = value; }
        }
        private int inspectedby;
        public int InspectedBy
        {
            get { return inspectedby; }
            set { inspectedby = value; }
        }
        private DateTime cleardate;
        public DateTime ClearDate
        {
            get { return cleardate; }
            set { cleardate = value; }
        }
        private DateTime innoc_broth_date;
        public DateTime Innoc_Broth_Date
        {
            get { return innoc_broth_date; }
            set { innoc_broth_date = value; }
        }
        private string innoc_broth_time;

        public string Innoc_Broth_Time
        {
            get { return innoc_broth_time; }
            set { innoc_broth_time = value; }
        }

        private DateTime innoc_agar_date ;
        public DateTime Innoc_Agar_Date
        {
            get { return innoc_agar_date; }
            set { innoc_agar_date = value; }
        }
        private string innoc_agar_time ;
        public string Innoc_Agar_Time
        {
            get { return innoc_agar_time; }
            set { innoc_agar_time = value; }
        }

        private DateTime inccubation_broth_date ;
        public DateTime Inccubation_Broth_Date
        {
            get { return inccubation_broth_date; }
            set { inccubation_broth_date = value; }
        }

        private string inccubation_broth_time ;
        public string Inccubation_Broth_Time
        {
            get { return inccubation_broth_time; }
            set { inccubation_broth_time = value; }
        }

        private DateTime inccubation_agar_date;
        public DateTime Inccubation_Agar_Date 
        {
            get { return inccubation_agar_date; }
            set { inccubation_agar_date = value; }
        }

        private string inccubation_agar_time;
        public string Inccubation_Agar_Time 
        {
            get { return inccubation_agar_time; }
            set { inccubation_agar_time = value; }
        }

        private DateTime inccubation_other_date;
        public DateTime Inccubation_Other_Date 
        {
            get { return inccubation_other_date; }
            set { inccubation_other_date = value; }
        }
        private string inccubation_other_time;

        public string Inccubation_Other_Time 
        {
            get { return inccubation_other_time; }
            set { inccubation_other_time = value; }
        }

        // For Dilution D1
        private DateTime dilutionD1Innoc_broth_date;
        public DateTime DilutionD1Innoc_Broth_Date
        {
            get { return dilutionD1Innoc_broth_date; }
            set { dilutionD1Innoc_broth_date = value; }
        }

        private string dilutionD1Innoc_broth_time;
        public string DilutionD1Innoc_Broth_Time
        {
            get { return dilutionD1Innoc_broth_time; }
            set { dilutionD1Innoc_broth_time = value; }
        }

        private DateTime dilutionD1Innoc_agar_date;
        public DateTime DilutionD1Innoc_Agar_Date
        {
            get { return dilutionD1Innoc_agar_date; }
            set { dilutionD1Innoc_agar_date = value; }
        }

        private string dilutionD1Innoc_agar_time;
        public string DilutionD1Innoc_Agar_Time
        {
            get { return dilutionD1Innoc_agar_time; }
            set { dilutionD1Innoc_agar_time = value; }
        }

        private DateTime dilutionD1Innoc_other_date;
        public DateTime DilutionD1Innoc_Other_Date
        {
            get { return dilutionD1Innoc_other_date; }
            set { dilutionD1Innoc_other_date = value; }
        }
        private string dilutionD1Innoc_other_time;

        public string DilutionD1Innoc_Other_Time
        {
            get { return dilutionD1Innoc_other_time; }
            set { dilutionD1Innoc_other_time = value; }
        }



        // For Dilution D2
        private DateTime dilutionD2Innoc_broth_date;
        public DateTime DilutionD2Innoc_Broth_Date
        {
            get { return dilutionD2Innoc_broth_date; }
            set { dilutionD2Innoc_broth_date = value; }
        }

        private string dilutionD2Innoc_broth_time;
        public string DilutionD2Innoc_Broth_Time
        {
            get { return dilutionD2Innoc_broth_time; }
            set { dilutionD2Innoc_broth_time = value; }
        }

        private DateTime dilutionD2Innoc_agar_date;
        public DateTime DilutionD2Innoc_Agar_Date
        {
            get { return dilutionD2Innoc_agar_date; }
            set { dilutionD2Innoc_agar_date = value; }
        }

        private string dilutionD2Innoc_agar_time;
        public string DilutionD2Innoc_Agar_Time
        {
            get { return dilutionD2Innoc_agar_time; }
            set { dilutionD2Innoc_agar_time = value; }
        }

        private DateTime dilutionD2Innoc_other_date;
        public DateTime DilutionD2Innoc_Other_Date
        {
            get { return dilutionD2Innoc_other_date; }
            set { dilutionD2Innoc_other_date = value; }
        }
        private string dilutionD2Innoc_other_time;

        public string DilutionD2Innoc_Other_Time
        {
            get { return dilutionD2Innoc_other_time; }
            set { dilutionD2Innoc_other_time = value; }
        }

  


        // For Dilution D3
        private DateTime dilutionD3Innoc_broth_date;
        public DateTime DilutionD3Innoc_Broth_Date
        {
            get { return dilutionD3Innoc_broth_date; }
            set { dilutionD3Innoc_broth_date = value; }
        }

        private string dilutionD3Innoc_broth_time;
        public string DilutionD3Innoc_Broth_Time
        {
            get { return dilutionD3Innoc_broth_time; }
            set { dilutionD3Innoc_broth_time = value; }
        }

        private DateTime dilutionD3Innoc_agar_date;
        public DateTime DilutionD3Innoc_Agar_Date
        {
            get { return dilutionD3Innoc_agar_date; }
            set { dilutionD3Innoc_agar_date = value; }
        }

        private string dilutionD3Innoc_agar_time;
        public string DilutionD3Innoc_Agar_Time
        {
            get { return dilutionD3Innoc_agar_time; }
            set { dilutionD3Innoc_agar_time = value; }
        }

        private DateTime dilutionD3Innoc_other_date;
        public DateTime DilutionD3Innoc_Other_Date
        {
            get { return dilutionD3Innoc_other_date; }
            set { dilutionD3Innoc_other_date = value; }
        }
        private string dilutionD3Innoc_other_time;

        public string DilutionD3Innoc_Other_Time
        {
            get { return dilutionD3Innoc_other_time; }
            set { dilutionD3Innoc_other_time = value; }
        }

   

        private string inccub_broth_temp;
        public string Inccub_Broth_Temp 
        {
            get { return inccub_broth_temp; }
            set { inccub_broth_temp = value; }
        }
        private string inccub_other_temp;
        public string Inccub_Agar_Temp 
        {
            get { return inccub_other_temp; }
            set { inccub_other_temp = value; }
        }
        private string inccub_agar_temp;
        public string Inccub_Other_Temp 
        {
            get { return inccub_agar_temp; }
            set { inccub_agar_temp = value; }
        }
        private DateTime result_broth_date;
        public DateTime Result_Broth_Date 
        {
            get { return result_broth_date; }
            set { result_broth_date = value; }
        }
        private string result_broth_time;
        public string Result_Broth_Time 
        {
            get { return result_broth_time; }
            set { result_broth_time = value; }
        }
        private DateTime result_agar_date;
        public DateTime Result_Agar_Date 
        {
            get { return result_agar_date; }
            set { result_agar_date = value; }
        }
        private string result_agar_time;
        public string Result_Agar_Time 
        {
            get { return result_agar_time; }
            set { result_agar_time = value; }
        }
        private DateTime result_other_date;
        public DateTime Result_Other_Date 
        {
            get { return result_other_date; }
            set { result_other_date = value; }
        }
        private string result_other_time;
        public string Result_Other_Time 
        {
            get { return result_other_time; }
            set { result_other_time = value; }
        }
        private string totaltime_broth;
        public string TotalTime_Broth 
        {
            get { return totaltime_broth; }
            set { totaltime_broth = value; }
        }
        private string totaltime_agar;
        public string TotalTime_Agar 
        {
            get { return totaltime_agar; }
            set { totaltime_agar = value; }
        }
        private string totaltime_other;
        public string TotalTime_Other 
        {
            get { return totaltime_other; }
            set { totaltime_other = value; }
        }
        private string remarks_broth;
        public string Remarks_Broth 
        {
            get { return remarks_broth; }
            set { remarks_broth = value; }
        }
        private string remarks_agar;
        public string Remarks_Agar 
        {
            get { return remarks_agar; }
            set { remarks_agar = value; }
        }
        private string remarks_other;
        public string Remarks_Other 
        {
            get { return remarks_other; }
            set { remarks_other = value; }
        }
        private char status;
        public char Status 
        {
            get { return status; }
            set { status = value; }
        }
        private char sampletoretainer;

        public char SampleToRetainer
        {
            get { return sampletoretainer; }
            set { sampletoretainer = value; }
        }
        private int loginid;

        public int LoginID
        {
            get { return loginid; }
            set { loginid = value; }
        }
        private string MicroNorms;

        public string micronorm
        {
            get { return MicroNorms; }
            set { MicroNorms = value; }
        }
	
        #endregion

        #region Functions
        public DataTable select_PendingRMMicrobiologyDetails()
        {
            DataTable Dt = new DataTable();
            Dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_PendingRMMicrobiologyDetails").Tables[0];
            return Dt;
        }
        public DataTable select_ModificationRMMicrobiologyDetails()
        {
            DataTable Dt = new DataTable();
            Dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_ModificationRMMicrobiologyDetails").Tables[0];
            return Dt;
        }
        public DataTable select_RMMicrobiologyDetails_RMCodeID()
        {
            DataTable Dt = new DataTable();
            SqlParameter[] myParam = new SqlParameter[3];
            myParam[0] = ModHelper.CreateParameter("@RMCodeID",SqlDbType.BigInt,8,ParameterDirection.Input,RMCodeID);
            myParam[1] = ModHelper.CreateParameter("@ReceiptDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, ReceiptDate);
            myParam[2] = ModHelper.CreateParameter("@PlantLotNo", SqlDbType.VarChar, 50, ParameterDirection.Input, PlantLotNo);

            Dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_RMMicrobiologyDetails_RMCodeID", myParam).Tables[0];
            return Dt;
        }

        public bool Insert_tblRMMicrobiologytest()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[53];
                myparam[0] = ModHelper.CreateParameter("@ClearDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, ClearDate);
                if (Innoc_Broth_Date != Convert.ToDateTime("1 / 1 / 1900"))
                {
                    myparam[1] = ModHelper.CreateParameter("@Innoc_Broth_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, Innoc_Broth_Date);
                }
                else
                {
                    myparam[1] = ModHelper.CreateParameter("@Innoc_Broth_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DBNull.Value);
                }

                if (innoc_broth_time != "")
                {
                    myparam[2] = ModHelper.CreateParameter("@Innoc_Broth_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, innoc_broth_time);
                }
                else
                {
                    myparam[2] = ModHelper.CreateParameter("@Innoc_Broth_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, DBNull.Value);
                }

                if (Innoc_Agar_Date != Convert.ToDateTime("1 / 1 / 1900"))
                {
                    myparam[3] = ModHelper.CreateParameter("@Innoc_Agar_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, Innoc_Agar_Date);
                }
                else
                {
                    myparam[3] = ModHelper.CreateParameter("@Innoc_Agar_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DBNull.Value);
                }
                if (innoc_agar_time != "")
                {
                    myparam[4] = ModHelper.CreateParameter("@Innoc_Agar_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, innoc_agar_time);
                }
                else
                {
                    myparam[4] = ModHelper.CreateParameter("@Innoc_Agar_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, DBNull.Value);
                }
                if (Inccubation_Broth_Date != Convert.ToDateTime("1 / 1 / 1900"))
                {
                    myparam[5] = ModHelper.CreateParameter("@Inccubation_Broth_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, Inccubation_Broth_Date);
                }
                else
                {
                    myparam[5] = ModHelper.CreateParameter("@Inccubation_Broth_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DBNull.Value);
                }

                if (inccubation_broth_time != "")
                {
                    myparam[6] = ModHelper.CreateParameter("@Inccubation_Broth_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, inccubation_broth_time);
                }
                else
                {
                    myparam[6] = ModHelper.CreateParameter("@Inccubation_Broth_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, DBNull.Value);
                }
                if (Inccubation_Agar_Date != Convert.ToDateTime("1 / 1 / 1900"))
                {
                    myparam[7] = ModHelper.CreateParameter("@Inccubation_Agar_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, Inccubation_Agar_Date);
                }
                else
                {
                    myparam[7] = ModHelper.CreateParameter("@Inccubation_Agar_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DBNull.Value);
                }

                if (Inccubation_Agar_Time != "")
                {
                    myparam[8] = ModHelper.CreateParameter("@Inccubation_Agar_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, Inccubation_Agar_Time);
                }
                else
                {
                    myparam[8] = ModHelper.CreateParameter("@Inccubation_Agar_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, DBNull.Value);
                }
                if (Inccubation_Other_Date != Convert.ToDateTime("1 / 1 / 1900"))
                {
                    myparam[9] = ModHelper.CreateParameter("@Inccubation_Other_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, Inccubation_Other_Date);
                }
                else
                {
                    myparam[9] = ModHelper.CreateParameter("@Inccubation_Other_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DBNull.Value);
                }

                if (Inccubation_Other_Time != "")
                {
                    myparam[10] = ModHelper.CreateParameter("@Inccubation_Other_time", SqlDbType.VarChar, 50, ParameterDirection.Input, Inccubation_Other_Time);
                }
                else
                {
                    myparam[10] = ModHelper.CreateParameter("@Inccubation_Other_time", SqlDbType.VarChar, 50, ParameterDirection.Input, DBNull.Value);
                }

                //Add paramater of Dilution D1

                if (DilutionD1Innoc_Broth_Date != Convert.ToDateTime("1 / 1 / 1900"))
                {
                    myparam[11] = ModHelper.CreateParameter("@DilutionD1Innoc_Broth_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DilutionD1Innoc_Broth_Date);
                }
                else
                {
                    myparam[11] = ModHelper.CreateParameter("@DilutionD1Innoc_Broth_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DBNull.Value);
                }

                if (DilutionD1Innoc_Broth_Time != "")
                {
                    myparam[12] = ModHelper.CreateParameter("@DilutionD1Innoc_Broth_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, DilutionD1Innoc_Broth_Time);
                }
                else
                {
                    myparam[12] = ModHelper.CreateParameter("@DilutionD1Innoc_Broth_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, DBNull.Value);
                }
                if (DilutionD1Innoc_Agar_Date != Convert.ToDateTime("1 / 1 / 1900"))
                {
                    myparam[13] = ModHelper.CreateParameter("@DilutionD1Innoc_Agar_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DilutionD1Innoc_Agar_Date);
                }
                else
                {
                    myparam[13] = ModHelper.CreateParameter("@DilutionD1Innoc_Agar_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DBNull.Value);
                }

                if (DilutionD1Innoc_Agar_Time != "")
                {
                    myparam[14] = ModHelper.CreateParameter("@DilutionD1Innoc_Agar_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, DilutionD1Innoc_Agar_Time);
                }
                else
                {
                    myparam[14] = ModHelper.CreateParameter("@DilutionD1Innoc_Agar_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, DBNull.Value);
                }
                if (DilutionD1Innoc_Other_Date != Convert.ToDateTime("1 / 1 / 1900"))
                {
                    myparam[15] = ModHelper.CreateParameter("@DilutionD1Innoc_Other_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DilutionD1Innoc_Other_Date);
                }
                else
                {
                    myparam[15] = ModHelper.CreateParameter("@DilutionD1Innoc_Other_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DBNull.Value);
                }

                if (DilutionD1Innoc_Other_Time != "")
                {
                    myparam[16] = ModHelper.CreateParameter("@DilutionD1Innoc_Other_time", SqlDbType.VarChar, 50, ParameterDirection.Input, DilutionD1Innoc_Other_Time);
                }
                else
                {
                    myparam[16] = ModHelper.CreateParameter("@DilutionD1Innoc_Other_time", SqlDbType.VarChar, 50, ParameterDirection.Input, DBNull.Value);
                }

                // Add parameter of dilution D2
                if (DilutionD2Innoc_Broth_Date != Convert.ToDateTime("1 / 1 / 1900"))
                {
                    myparam[17] = ModHelper.CreateParameter("@DilutionD2Innoc_Broth_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DilutionD2Innoc_Broth_Date);
                }
                else
                {
                    myparam[17] = ModHelper.CreateParameter("@DilutionD2Innoc_Broth_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DBNull.Value);
                }

                if (this.DilutionD2Innoc_Broth_Time != "")
                {
                    myparam[18] = ModHelper.CreateParameter("@DilutionD2Innoc_Broth_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, DilutionD2Innoc_Broth_Time);
                }
                else
                {
                    myparam[18] = ModHelper.CreateParameter("@DilutionD2Innoc_Broth_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, DBNull.Value);
                }
                if (DilutionD2Innoc_Agar_Date != Convert.ToDateTime("1 / 1 / 1900"))
                {
                    myparam[19] = ModHelper.CreateParameter("@DilutionD2Innoc_Agar_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DilutionD2Innoc_Agar_Date);
                }
                else
                {
                    myparam[19] = ModHelper.CreateParameter("@DilutionD2Innoc_Agar_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DBNull.Value);
                }

                if (DilutionD2Innoc_Agar_Time != "")
                {
                    myparam[20] = ModHelper.CreateParameter("@DilutionD2Innoc_Agar_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, DilutionD2Innoc_Agar_Time);
                }
                else
                {
                    myparam[20] = ModHelper.CreateParameter("@DilutionD2Innoc_Agar_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, DBNull.Value);
                }
                if (DilutionD2Innoc_Other_Date != Convert.ToDateTime("1 / 1 / 1900"))
                {
                    myparam[21] = ModHelper.CreateParameter("@DilutionD2Innoc_Other_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DilutionD2Innoc_Other_Date);
                }
                else
                {
                    myparam[21] = ModHelper.CreateParameter("@DilutionD2Innoc_Other_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DBNull.Value);
                }

                if (DilutionD2Innoc_Other_Time != "")
                {
                    myparam[22] = ModHelper.CreateParameter("@DilutionD2Innoc_Other_time", SqlDbType.VarChar, 50, ParameterDirection.Input, DilutionD2Innoc_Other_Time);
                }
                else
                {
                    myparam[22] = ModHelper.CreateParameter("@DilutionD2Innoc_Other_time", SqlDbType.VarChar, 50, ParameterDirection.Input, DBNull.Value);
                }

                // Add paramter of dilution D3

                if (DilutionD3Innoc_Broth_Date != Convert.ToDateTime("1 / 1 / 1900"))
                {
                    myparam[23] = ModHelper.CreateParameter("@DilutionD3Innoc_Broth_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DilutionD3Innoc_Broth_Date);
                }
                else
                {
                    myparam[23] = ModHelper.CreateParameter("@DilutionD3Innoc_Broth_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DBNull.Value);
                }

                if (this.DilutionD3Innoc_Broth_Time != "")
                {
                    myparam[24] = ModHelper.CreateParameter("@DilutionD3Innoc_Broth_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, DilutionD3Innoc_Broth_Time);
                }
                else
                {
                    myparam[24] = ModHelper.CreateParameter("@DilutionD3Innoc_Broth_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, DBNull.Value);
                }
                if (DilutionD3Innoc_Agar_Date != Convert.ToDateTime("1 / 1 / 1900"))
                {
                    myparam[25] = ModHelper.CreateParameter("@DilutionD3Innoc_Agar_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DilutionD3Innoc_Agar_Date);
                }
                else
                {
                    myparam[25] = ModHelper.CreateParameter("@DilutionD3Innoc_Agar_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DBNull.Value);
                }

                if (DilutionD3Innoc_Agar_Time != "")
                {
                    myparam[26] = ModHelper.CreateParameter("@DilutionD3Innoc_Agar_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, DilutionD3Innoc_Agar_Time);
                }
                else
                {
                    myparam[26] = ModHelper.CreateParameter("@DilutionD3Innoc_Agar_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, DBNull.Value);
                }
                if (DilutionD3Innoc_Other_Date != Convert.ToDateTime("1 / 1 / 1900"))
                {
                    myparam[27] = ModHelper.CreateParameter("@DilutionD3Innoc_Other_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DilutionD3Innoc_Other_Date);
                }
                else
                {
                    myparam[27] = ModHelper.CreateParameter("@DilutionD3Innoc_Other_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DBNull.Value);
                }

                if (DilutionD3Innoc_Other_Time != "")
                {
                    myparam[28] = ModHelper.CreateParameter("@DilutionD3Innoc_Other_time", SqlDbType.VarChar, 50, ParameterDirection.Input, DilutionD3Innoc_Other_Time);
                }
                else
                {
                    myparam[28] = ModHelper.CreateParameter("@DilutionD3Innoc_Other_time", SqlDbType.VarChar, 50, ParameterDirection.Input, DBNull.Value);
                }








                myparam[29] = ModHelper.CreateParameter("@Inccub_Broth_Temp", SqlDbType.NVarChar, 50, ParameterDirection.Input, Inccub_Broth_Temp);
                myparam[30] = ModHelper.CreateParameter("@Inccub_Agar_Temp", SqlDbType.NVarChar, 50, ParameterDirection.Input, Inccub_Agar_Temp);
                myparam[31] = ModHelper.CreateParameter("@Inccub_Other_Temp", SqlDbType.NVarChar, 50, ParameterDirection.Input, Inccub_Other_Temp);
                if (Result_Broth_Date != Convert.ToDateTime("1 / 1 / 1900"))
                {
                    myparam[32] = ModHelper.CreateParameter("@Result_Broth_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, Result_Broth_Date);
                }
                else
                {
                    myparam[32] = ModHelper.CreateParameter("@Result_Broth_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DBNull.Value);
                }

                if (Result_Broth_Time != "")
                {
                    myparam[33] = ModHelper.CreateParameter("@Result_Broth_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, Result_Broth_Time);
                }
                else
                {
                    myparam[33] = ModHelper.CreateParameter("@Result_Broth_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, DBNull.Value);
                }
                if (Result_Agar_Date != Convert.ToDateTime("1 / 1 / 1900"))
                {
                    myparam[34] = ModHelper.CreateParameter("@Result_Agar_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, Result_Agar_Date);
                }
                else
                {
                    myparam[34] = ModHelper.CreateParameter("@Result_Agar_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DBNull.Value);
                }

                if (Result_Agar_Time != "")
                {
                    myparam[35] = ModHelper.CreateParameter("@Result_Agar_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, Result_Agar_Time);
                }
                else
                {
                    myparam[35] = ModHelper.CreateParameter("@Result_Agar_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, DBNull.Value);
                }


                if (Result_Other_Date != Convert.ToDateTime("1 / 1 / 1900"))
                {
                    myparam[36] = ModHelper.CreateParameter("@Result_Other_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, Result_Other_Date);
                }
                else
                {
                    myparam[36] = ModHelper.CreateParameter("@Result_Other_Date", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, DBNull.Value);
                }
                if (Result_Other_Time != "")
                {
                    myparam[37] = ModHelper.CreateParameter("@Result_Other_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, Result_Other_Time);
                }
                else
                {
                    myparam[37] = ModHelper.CreateParameter("@Result_Other_Time", SqlDbType.VarChar, 50, ParameterDirection.Input, DBNull.Value);
                }
                myparam[38] = ModHelper.CreateParameter("@TotalTime_Broth", SqlDbType.VarChar, 50, ParameterDirection.Input, TotalTime_Broth);
                myparam[39] = ModHelper.CreateParameter("@TotalTime_Agar", SqlDbType.VarChar, 50, ParameterDirection.Input, TotalTime_Agar);
                myparam[40] = ModHelper.CreateParameter("@TotalTime_Other", SqlDbType.VarChar, 50, ParameterDirection.Input, TotalTime_Other);
                myparam[41] = ModHelper.CreateParameter("@Remarks_Broth", SqlDbType.VarChar, 250, ParameterDirection.Input, Remarks_Broth);
                myparam[42] = ModHelper.CreateParameter("@Remarks_Agar", SqlDbType.VarChar, 250, ParameterDirection.Input, Remarks_Agar);
                myparam[43] = ModHelper.CreateParameter("@Remarks_Other", SqlDbType.VarChar, 250, ParameterDirection.Input, Remarks_Other);
                myparam[44] = ModHelper.CreateParameter("@Status", SqlDbType.Char, 1, ParameterDirection.Input, Status);
                //myparam[27] = ModHelper.CreateParameter("@BpcNonBpc", SqlDbType.Char, 1, ParameterDirection.Input, BpcNonBpc);
                //myparam[28] = ModHelper.CreateParameter("@NonBpcComments", SqlDbType.VarChar, 250, ParameterDirection.Input, NonBpcComments);
                //myparam[29] = ModHelper.CreateParameter("@Comment", SqlDbType.VarChar, 250, ParameterDirection.Input, comments);
                myparam[45] = ModHelper.CreateParameter("@MediaLotNo", SqlDbType.VarChar, 50, ParameterDirection.Input, MediaLotNo);
                myparam[46] = ModHelper.CreateParameter("@MethodName", SqlDbType.VarChar, 15, ParameterDirection.Input, MethodName);
                myparam[47] = ModHelper.CreateParameter("@SampleToRetainer", SqlDbType.Char, 1, ParameterDirection.Input, SampleToRetainer);
                myparam[48] = ModHelper.CreateParameter("@RMDetailID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMDetailID);
                myparam[49] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, LoginID);
                myparam[50] = ModHelper.CreateParameter("@InspectedBy", SqlDbType.Int, 4, ParameterDirection.Input, InspectedBy);
                myparam[51] = ModHelper.CreateParameter("@RMMicroNo", SqlDbType.BigInt, 8, ParameterDirection.Output);
                myparam[52] = ModHelper.CreateParameter("@MicroNorms", SqlDbType.VarChar, 250, ParameterDirection.Input, micronorm);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblRMMicrobiologytest", myparam);
                //microno =Convert.ToInt64(myparam[35].Value);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update_tblRMDetails_MicroDone()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@RMDetailID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMDetailID);
                myparam[1] = ModHelper.CreateParameter("@MicroDone", SqlDbType.Bit, 1, ParameterDirection.Input, MicroDone);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblRMDetails_MicroDone", myparam);
                return true;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
        public DataTable Select_tblRMMicrobiologytest_RMDetailsID()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@RMDetailID", SqlDbType.BigInt, 8, ParameterDirection.Input, RMDetailID);
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMMicrobiologytest_RMDetailID", myparam).Tables[0];
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
