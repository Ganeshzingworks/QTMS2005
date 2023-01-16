using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;

namespace BusinessFacade
{
    public class BAGPMCode
    {
        #region Property
        private long PMCodeID;

        public long pmcodeId
        {
            get { return PMCodeID; }
            set { PMCodeID = value; }
        }

        private string PMCode;

        public string pmcode
        {
            get { return PMCode; }
            set { PMCode = value; }
        }

        private string PMDescription;
        public string pmdescription
        {
            get { return PMDescription; }
            set { PMDescription = value; }
        }

        private long PMFamilyID;
        public long pmfamilyid
        {
            get { return PMFamilyID; }
            set { PMFamilyID = value; }
        }

        private long BAGID;

        public long bagid
        {
            get { return BAGID; }
            set { BAGID = value; }
        }
       
        #endregion
        #region Function
        public DataSet Select_PMMaster_PMFamilyID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@PMFamilyID", SqlDbType.VarChar, 50, ParameterDirection.Input, pmfamilyid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_PMCode_PMFamilyID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert_Upload_BagFile(long PMCodeID, DateTime receviedDate, string Imagepath,string fileName,string desc, int active,long createdby)
        {
            string conString = System.Configuration.ConfigurationSettings.AppSettings["connectionstring"].ToString();
            SqlConnection con = new SqlConnection(conString);
            try
            {               
               
                con.Open();
                SqlCommand CATcmd = new SqlCommand("STP_Insert_BagUpload", con);
                CATcmd.CommandType = CommandType.StoredProcedure;
                SqlParameter myParm = new SqlParameter();
                myParm = CATcmd.Parameters.Add("@PMCodeID", SqlDbType.BigInt);
                myParm.Value = PMCodeID;
                myParm = CATcmd.Parameters.Add("UploadedDate", SqlDbType.DateTime);
                myParm.Value = receviedDate;
                myParm = CATcmd.Parameters.Add("@ImagePath", SqlDbType.VarChar, 500);
                myParm.Value = Imagepath;
                myParm = CATcmd.Parameters.Add("@FileName", SqlDbType.VarChar, 300);
                myParm.Value = fileName;
                myParm = CATcmd.Parameters.Add("@Description", SqlDbType.Text);
                myParm.Value = desc;
                myParm = CATcmd.Parameters.Add("@Active", SqlDbType.Bit);
                myParm.Value = active;
                myParm = CATcmd.Parameters.Add("@CreatedBy", SqlDbType.BigInt);
                myParm.Value = createdby;
                CATcmd.ExecuteNonQuery();
                return true;


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
        /// <summary>
        /// Show the uploaded file names by PM codeId
        /// </summary>
        /// <returns></returns>
        public DataSet Select_BAGUpload_PMCodeID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@PMCodeID", SqlDbType.VarChar, 50, ParameterDirection.Input, pmcodeId);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "Select_BAGUpload_PMCodeID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Show the uploaded file names by BagID
        /// </summary>
        /// <returns></returns>
        public DataSet Select_BAGUpload_BagID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@BagID", SqlDbType.VarChar, 50, ParameterDirection.Input, bagid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_BAGUpload_BagID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Show the uploaded file names by PM codeId
        /// </summary>
        /// <returns></returns>
        public DataSet Select_BAGUpload_Files_PMCodeID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@PMCodeID", SqlDbType.VarChar, 50, ParameterDirection.Input, pmcodeId);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_BAGUpload_Files_PMCodeID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete the records (Update the active flag value)
        /// </summary>
        /// <returns></returns>
        public bool Delete_BAGUpload_BagID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@BagID", SqlDbType.VarChar, 50, ParameterDirection.Input, bagid);
                int i = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_BAGUpload_BagID", myparam);
                if (i == 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
