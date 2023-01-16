using System;
using System.Data;
using System.Data.SqlClient;
using DataFacade;
using System.Configuration;
namespace BusinessFacade
{
	/// <summary>
	/// Summary description for BulkFamilyMaster_Class.
	/// </summary>
	public class BulkFamilyMaster_Class
	{
		public BulkFamilyMaster_Class()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		#region varibles
			private string FamilyName;	
			private long FamilyNo;
			private long TestNo;
			public static long result;
		#endregion
		#region Properties
        public long Result
        {
            get
            {
                return result;
            }
            set { result = value; }
        }
        public string familyname
		{
			get
			{
				return FamilyName;
			}
			set
			{
				FamilyName=value;
			}
		}
		public long familyno
		{
			get
			{
				return FamilyNo;
			}
			set
			{
				FamilyNo=value;
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
		#endregion
		#region Functions
        
        public DataSet SELECT_tblblkfamilyMaster_TechFamNo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@TechFamNo", SqlDbType.Int, 4, ParameterDirection.Input, familyno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblblkfamilyMaster_TechFamNo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
        public bool Insert_BulkFamilyMaster1()
		{
			try
			{
				SqlConnection con=new SqlConnection(ConfigurationSettings.AppSettings["connectionstring"]);
				con.Open();
				SqlParameter myparam=new SqlParameter();
				SqlCommand cmd=new SqlCommand("STP_Insert_tblBulkFamilyMaster",con);
				cmd.CommandType=CommandType.StoredProcedure;
				
				myparam=cmd.Parameters.Add("@FamilyDesc",SqlDbType.VarChar,250);
				myparam.Direction=ParameterDirection.Input;
				myparam.Value=familyname;
				
				SqlParameter myparam_Out=new SqlParameter();
				myparam_Out=cmd.Parameters.Add("@Result",SqlDbType.BigInt,8);
				myparam_Out.Direction=ParameterDirection.Output;
				
				cmd.ExecuteNonQuery();
				
				long b=Convert.ToInt64(myparam_Out.Value);
				return true;

				
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		public bool Insert_BulkFamilyMaster()
		{
			try
			{
				SqlParameter[] myaparam=new SqlParameter[1];
				myaparam[0]=ModHelper.CreateParameter("@FamilyDesc",SqlDbType.VarChar,250,ParameterDirection.Input,familyname);				
				SqlHelper.ExecuteScalar(CommandType.StoredProcedure,"STP_Insert_tblBulkFamilyMaster",myaparam);				
				return true;
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
		
        public bool Update_tblblkfamilyMaster()
        {
            try
            {
                SqlParameter[] myparam=new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@TechFamNo", SqlDbType.BigInt, 8, ParameterDirection.Input, familyno);
                myparam[1] = ModHelper.CreateParameter("@TechFamName", SqlDbType.VarChar, 250, ParameterDirection.Input, FamilyName);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_UPDATE_tblblkfamilyMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
        public bool Delete_tblblkfamilyMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@TechFamNo", SqlDbType.BigInt, 8, ParameterDirection.Input, familyno);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblblkfamilyMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
		public DataSet Select_BulkFamilyMaster()
		{
			try
			{
				DataSet ds=new DataSet();
				ds=SqlHelper.ExecuteDataset(CommandType.StoredProcedure,"STP_Select_BulkFamilyMaster");
				return ds;
			}
			catch(Exception ex)
			{
				throw ex;
			}

		}
		#endregion


        public DataSet Select_All_Record_tblblkfamilyMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "SP_Select_All_tblblkfamilyMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
