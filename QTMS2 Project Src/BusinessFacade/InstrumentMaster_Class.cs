using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;
namespace BusinessFacade
{
    public class InstrumentMaster_Class
    {
        # region Varibles      
        private long InstNo;
        private string Instrument;
        private string CaliberationDate;
        private string DueDate;
        private long TestNo;        
        private long Result;
        # endregion

        # region Properties                        
        public long instno
        {
            get { return InstNo; }
            set { InstNo = value; }
        }
        public string instrument
        {
            get { return Instrument; }
            set { Instrument = value; }
        }
        public string caliberationdate
        {
            get { return CaliberationDate; }
            set { CaliberationDate = value; }
        }
        public string duedate
        {
            get { return DueDate; }
            set { DueDate = value; }
        }
        public long testno
        {
            get { return TestNo; }
            set { TestNo = value; }
        }
        public long result
        {
            get { return Result; }
            set { Result = value; }
        }
        # endregion

        # region Functions
        public DataSet Select_tblInstrumentMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblInstrumentMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
        public DataSet Select_tblInstrumentMaster_Instrument()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@Instrument", SqlDbType.NVarChar, 100, ParameterDirection.Input, instrument);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblInstrumentMaster_Instrument", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblInstrumentMaster_InstNo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@InstNo", SqlDbType.NVarChar, 200, ParameterDirection.Input, instno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblInstrumentMaster_InstNo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblInstrument_TestMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@InstNo", SqlDbType.BigInt, 8, ParameterDirection.Input, instno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblInstrument_TestMaster", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblInstrument_TestMaster_TestNo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@TestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, testno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblInstrument_TestMaster_TestNo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert_tblInstrument_TestMaster()
        {
            try
            {
                SqlParameter[] myaparam = new SqlParameter[2];
                myaparam[0] = ModHelper.CreateParameter("@InstNo", SqlDbType.BigInt, 8, ParameterDirection.Input, instno);
                myaparam[1] = ModHelper.CreateParameter("@TestNo", SqlDbType.Int, 4, ParameterDirection.Input, testno);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblInstrument_TestMaster", myaparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public long Insert_tblInstrumentMaster()
        {
            try
            {
                SqlParameter[] myaparam = new SqlParameter[4];
                myaparam[0] = ModHelper.CreateParameter("@Instrument", SqlDbType.NVarChar, 100, ParameterDirection.Input, instrument);
                myaparam[1] = ModHelper.CreateParameter("@CaliberationDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, caliberationdate);
                myaparam[2] = ModHelper.CreateParameter("@DueDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, duedate);
                myaparam[3] = ModHelper.CreateParameter("@InstNo", SqlDbType.BigInt, 8, ParameterDirection.Output,instno);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblInstrumentMaster", myaparam);
                instno = Convert.ToInt64(myaparam[3].Value);
                return instno;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update_tblInstrumentMaster()
        {
            try
            {
                SqlParameter[] myaparam = new SqlParameter[4];
                myaparam[0] = ModHelper.CreateParameter("@Instrument", SqlDbType.NVarChar, 100, ParameterDirection.Input, instrument);
                myaparam[1] = ModHelper.CreateParameter("@CaliberationDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, caliberationdate);
                myaparam[2] = ModHelper.CreateParameter("@DueDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, duedate);
                myaparam[3] = ModHelper.CreateParameter("@InstNo", SqlDbType.BigInt, 8, ParameterDirection.Input, instno);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblInstrumentMaster", myaparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete_tblInstrumentMaster()
        {
            try
            {
                SqlParameter[] myaparam = new SqlParameter[1];
                myaparam[0] = ModHelper.CreateParameter("@InstNo", SqlDbType.BigInt, 8, ParameterDirection.Input, instno);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblInstrumentMaster", myaparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete_tblInstrument_TestMaster()
        {
            try
            {
                SqlParameter[] myaparam = new SqlParameter[1];
                myaparam[0] = ModHelper.CreateParameter("@InstNo", SqlDbType.BigInt, 8, ParameterDirection.Input, instno);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblInstrument_TestMaster", myaparam);
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
