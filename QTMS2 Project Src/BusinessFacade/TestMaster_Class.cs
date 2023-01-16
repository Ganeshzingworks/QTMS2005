using System;
using System.Data;
using System.Data.SqlClient;
using DataFacade;
namespace BusinessFacade
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class TestMaster_Class
	{
		public TestMaster_Class()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		# region varibles
			private string TestName;
			private long TestNo;
            private string TestDesc;
            private string TestType;
            private long TypeID;
		# endregion
		# region Properties
        public long typeid
        {
            get
            {
                return TypeID;
            }
            set
            {
                TypeID = value;
            }
        }
		public string testname
		{
			get
			{
				return TestName;
			}
			set
			{
				TestName=value;
			}
		}
        public string testdesc
        {
            get
            {
                return TestDesc;
            }
            set
            {
                TestDesc = value;
            }
        }
        public string testtype
        {
            get
            {
                return TestType;
            }
            set
            {
                TestType = value;
            }
        }
		public long testno
		{
			get
			{
				return TestNo;
			}
			set
			{
				TestNo=value;
			}
		}
		# endregion
		# region Functions
		public DataSet Select_TestMaster()
		{
			try
			{
				DataSet ds=new DataSet();
				ds=SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tbltestmaster");
				return ds;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		public DataSet Select_TestMaster_TestNo()
		{
			try
			{
				DataSet ds=new DataSet();
				SqlParameter[] myparam=new SqlParameter[1];
				myparam[0]= ModHelper.CreateParameter("@TestNo",SqlDbType.BigInt,8,ParameterDirection.Input,testno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tbltestmaster_TestNo", myparam);
				return ds;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		public bool Update_TestMaster()
		{
			try
			{
				
				SqlParameter[] myparam=new SqlParameter[4];
				myparam[0]= ModHelper.CreateParameter("@TestNo",SqlDbType.BigInt,8,ParameterDirection.Input,testno);
				myparam[1]= ModHelper.CreateParameter("@TestName",SqlDbType.VarChar,50,ParameterDirection.Input,testname);
                myparam[2] = ModHelper.CreateParameter("@TestDesc", SqlDbType.VarChar, 250, ParameterDirection.Input, testdesc);
                myparam[3] = ModHelper.CreateParameter("@TestType", SqlDbType.VarChar, 50, ParameterDirection.Input, testtype);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tbltestmaster", myparam);
				return true;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		public long Insert_TestMaster()
		{
			try
			{
				SqlParameter[] myparam=new SqlParameter[4];
				myparam[0]= ModHelper.CreateParameter("@TestName",SqlDbType.VarChar,250,ParameterDirection.Input,testname);
                myparam[1] = ModHelper.CreateParameter("@TestDesc", SqlDbType.VarChar, 250, ParameterDirection.Input, testdesc);
                myparam[2] = ModHelper.CreateParameter("@TestType", SqlDbType.VarChar, 50, ParameterDirection.Input, testtype);
                myparam[3] = ModHelper.CreateParameter("@TestNo", SqlDbType.BigInt, 8, ParameterDirection.Output, testno);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblTestMaster", myparam);
                return Convert.ToInt64(myparam[3].Value);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		public bool Delete_TestMaster()
		{
			try
			{
				
				SqlParameter[] myparam=new SqlParameter[1];
				myparam[0]= ModHelper.CreateParameter("@TestNo",SqlDbType.BigInt,8,ParameterDirection.Input,testno);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_TestMaster", myparam);
				return true;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}

        public DataSet Select_tbltestmaster_LineSampleTest()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tbltestmaster_LineSampleTest");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;   
            }
        }

        public DataSet Select_tbltestmaster_IdentificationTest()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tbltestmaster_IdentificationTest");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tbltestmaster_ControlTest()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tbltestmaster_ControlTest");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_tblWAType()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblWAType");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Insert_tblWAMethodType()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@TestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, testno);
                myparam[1] = ModHelper.CreateParameter("@TypeID", SqlDbType.BigInt, 8, ParameterDirection.Input, typeid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblWAMethodType", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_tblWAMethodType_TestNo_TypeID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@TestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, testno);
                myparam[1] = ModHelper.CreateParameter("@TypeID", SqlDbType.BigInt, 8, ParameterDirection.Input, typeid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblWAMethodType_TestNo_TypeID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblWAMethodType_TestNo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@TestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, testno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblWAMethodType_TestNo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete_tblWAMethodType_TestNo_TypeID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@TestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, testno);
                myparam[1] = ModHelper.CreateParameter("@TypeID", SqlDbType.BigInt, 8, ParameterDirection.Input, typeid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblWAMethodType_TestNo_TypeID", myparam);                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		#endregion




        public DataSet Select_All_Record_tblTestMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "SP_SelectAllRecordFrom_tblTestMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
