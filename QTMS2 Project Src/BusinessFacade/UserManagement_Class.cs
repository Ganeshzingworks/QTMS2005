using System;
using System.Data;
using System.Data.SqlClient;
using DataFacade;
using System.Configuration;

namespace BusinessFacade
{
    public class UserManagement_Class
    {
        private string userid;
        public string UserID
        {
            get { return userid; }
            set { userid = value; }
        }
        private int uid;
        public int UID
        {
            get { return uid; }
            set { uid = value; }
        }
        private string login;
        public string Login
        {
            get { return login; }
            set { login = value; }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        private string usertype;
        public string userType
        {
            get { return usertype; }
            set { usertype = value; }
        }


        /// <summary>
        /// returns version 
        /// </summary>
        /// <returns></returns>
        public DataSet Select_tblSoftwareVersion()
        {
            try
            {
                DataSet ds = new DataSet();
                //changed by sanjiv on 13-Jan-2014 to get software versions

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_GetMaxVersion");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// returns Company details 
        /// </summary>
        /// <returns></returns>
        public DataSet Select_GetCompanyDetails()
        {
            try
            {
                DataSet ds = new DataSet();
                //changed by sanjiv on 13-Jan-2014 to get software versions

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_GetCompanyDetails");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// returns record from username and password
        /// </summary>
        /// <returns></returns>
        public DataSet Select_User()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[2];
                param[0] = ModHelper.CreateParameter("@Username", SqlDbType.VarChar, 50, ParameterDirection.Input, login);
                param[1] = ModHelper.CreateParameter("@passwd", SqlDbType.VarChar, 50, ParameterDirection.Input, password);

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_User", param);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// returns all record 
        /// </summary>
        /// <returns></returns>
        public DataSet Select_AllUser()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_AllUsers");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_Operator()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_Operator");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// returns user 
        /// </summary>
        /// <returns></returns>
        public DataSet Select_UserName()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@username", SqlDbType.VarChar, 50, ParameterDirection.Input, Login);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_UserName", param);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// insert records into tblUserInfo
        /// </summary>
        public bool Insert_Users()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = ModHelper.CreateParameter("@username", SqlDbType.VarChar, 50, ParameterDirection.Input, Login);
                param[1] = ModHelper.CreateParameter("@passwd", SqlDbType.VarChar, 50, ParameterDirection.Input, Password);
                param[2] = ModHelper.CreateParameter("@usertype", SqlDbType.VarChar, 50, ParameterDirection.Input, userType);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_Users", param);
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// update user
        /// </summary>
        /// <returns></returns>
        public bool Update_User()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = ModHelper.CreateParameter("@userid", SqlDbType.Int, 4, ParameterDirection.Input, UserID);
                param[1] = ModHelper.CreateParameter("@username", SqlDbType.VarChar, 50, ParameterDirection.Input, Login);
                param[2] = ModHelper.CreateParameter("@passwd", SqlDbType.VarChar, 50, ParameterDirection.Input, Password);
                param[3] = ModHelper.CreateParameter("@usertype", SqlDbType.VarChar, 50, ParameterDirection.Input, userType);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_User", param);
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Delete user
        /// </summary>
        /// <returns></returns>
        public bool Delete_User()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@userid", SqlDbType.Int, 4, ParameterDirection.Input, UserID);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_User", param);
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// returns selected user from tbluserinfo
        /// </summary>
        /// <returns></returns>
        public DataSet Select_SelectedUser()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@userid", SqlDbType.Int, 4, ParameterDirection.Input, userid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_SelectedUser", param);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update_UserPassword()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = ModHelper.CreateParameter("@userid", SqlDbType.Int, 4, ParameterDirection.Input, uid);
                param[1] = ModHelper.CreateParameter("@UserPass", SqlDbType.VarChar, 50, ParameterDirection.Input,Password);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_UserPassword", param);
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}
