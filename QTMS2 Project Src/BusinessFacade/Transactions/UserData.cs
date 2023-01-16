using System;
using System.Data;
using System.Data.SqlClient;
using DataFacade;
using System.Configuration;
using System.Collections.Generic;
namespace BusinessFacade.Transactions
{
    public class UserData
    {
        public List<UserData> SubModuleNameList = new List<UserData>();
        public List<UserData> FormNameList = new List<UserData>();

        #region Variables
        private int UserID;
        private string UserName;
        private string Password;
        private int UserTypeID;
        private short Del;
        private int FormID;
        private string ModuleName;
        private string SubModuleName;
        private string FormName;
        private string UserType;
        private short FormPermission;
        private int ParentID;//It is used for to find out parentFormName
        #endregion

        #region Properties
 
        public int userid
        {
            get { return UserID; }
            set { UserID = value; }
        }
        public string username
        {
            get { return UserName; }
            set { UserName = value; }
        }
        public string password
        {
            get { return Password; }
            set { Password = value; }
        }
        public int usertypeid
        {
            get { return UserTypeID; }
            set { UserTypeID = value; }
        }
        public short del
        {
            get { return Del; }
            set { Del = value; }
        }
        public int formid
        {
            get { return FormID; }
            set { FormID = value; }
        }
        public string modulename
        {
            get { return ModuleName; }
            set { ModuleName = value; }
        }
        public string submodulename
        {
            get { return SubModuleName; }
            set { SubModuleName = value; }
        }
        public string formname
        {
            get { return FormName; }
            set { FormName = value; }
        }
        public string usertype
        {
            get { return UserType; }
            set { UserType = value; }
        }
        public short formpermission
        {
            get { return FormPermission; }
            set { FormPermission = value; }
        }
        public int parentid
        {
            get { return ParentID; }
            set { ParentID = value; }
        }
        private string UserMailID;

        public string userMailID
        {
            get { return UserMailID; }
            set { UserMailID = value; }
        }

        private int GroupID;

        public int groupID
        {
            get { return GroupID; }
            set { GroupID = value; }
        }


        #endregion

        #region STPs
        ///<summary>
        ///returns all users whose Del flag is 1
        ///</summary>
        ///<returns></returns>
        public DataTable Show_AllUser()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_ShowAllUser");
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Show_AllUser_Group()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_ShowAllUser_Group");
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Show_AllUser_1()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_ShowAllUser");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        ///<summary>
        ///returns all user Type
        ///</summary>
        ///<returns></returns>
        public DataTable Show_AllUserType()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_AllUsersType");
                return ds.Tables[0];
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
        public DataTable Show_SelectedUser()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@userid", SqlDbType.Int, 4, ParameterDirection.Input, userid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_SelectedUser", param);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Show_SelectedUser_ByUserName()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@UserName", SqlDbType.NVarChar, 50, ParameterDirection.Input, username);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_SelectedUser_ByUserName", param);
                return ds.Tables[0];
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
        public DataTable Select_UserName()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@username", SqlDbType.VarChar, 50, ParameterDirection.Input, username);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_UserName", param);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// insert records into tblUserInfo
        /// </summary>
        public int Insert_Users()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = ModHelper.CreateParameter("@UserName", SqlDbType.VarChar, 50, ParameterDirection.Input, username);
                param[1] = ModHelper.CreateParameter("@UserPass", SqlDbType.VarChar, 50, ParameterDirection.Input, Password);
                param[2] = ModHelper.CreateParameter("@UserTypeID", SqlDbType.BigInt, 8, ParameterDirection.Input, usertypeid);
                param[3] = ModHelper.CreateParameter("@Del", SqlDbType.Bit, 1, ParameterDirection.Input, del);
                param[4] = ModHelper.CreateParameter("@UserMailID", SqlDbType.VarChar, 500, ParameterDirection.Input, userMailID);

                param[5] = ModHelper.CreateParameter("@UserID", SqlDbType.Int, 4, ParameterDirection.Output);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_NewUser", param);
                userid = Convert.ToInt32(param[5].Value);
                return userid;

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
                SqlParameter[] param = new SqlParameter[6];
                param[0] = ModHelper.CreateParameter("@UserName", SqlDbType.VarChar, 50, ParameterDirection.Input, username);
                param[1] = ModHelper.CreateParameter("@UserPass", SqlDbType.VarChar, 50, ParameterDirection.Input, Password);
                param[2] = ModHelper.CreateParameter("@UserTypeID", SqlDbType.BigInt, 8, ParameterDirection.Input, usertypeid);
                param[3] = ModHelper.CreateParameter("@Del", SqlDbType.Bit, 1, ParameterDirection.Input, del);
                param[4] = ModHelper.CreateParameter("@UserID", SqlDbType.Int, 4, ParameterDirection.Input, userid);
                param[5] = ModHelper.CreateParameter("@UserMailID", SqlDbType.VarChar, 500, ParameterDirection.Input, userMailID);
                
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_UserInfo", param);
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
                SqlParameter[] param = new SqlParameter[2];
                param[0] = ModHelper.CreateParameter("@UserID", SqlDbType.Int, 4, ParameterDirection.Input, userid);
                param[1] = ModHelper.CreateParameter("@Del", SqlDbType.Bit, 1, ParameterDirection.Input, del);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_UserInfo", param);
                return true;

            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        /// <summary>
        /// Show all forms
        /// </summary>
        /// <returns></returns>
        public DataTable Show_AllForms()
        {
            try
            {
                DataSet ds = new DataSet();

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure,"STP_ShowAllFormNames");
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }
        /// <summary>
        /// Add new user type
        ///  </summary>
        /// <returns></returns>
        public bool AddUserType_tblUserTypes()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@UserType", SqlDbType.VarChar, 50, ParameterDirection.Input, usertype);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_AddUserType_tblSoftwareUserType", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Update user type
        ///  </summary>
        /// <returns></returns>
        public bool EditUserType_tblUserTypes()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@UserTypeID", SqlDbType.BigInt, 8, ParameterDirection.Input, usertypeid);
                myparam[1] = ModHelper.CreateParameter("@UserType", SqlDbType.VarChar, 50, ParameterDirection.Input, usertype);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_EditUserType_tblSoftwareUserType", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// add user type & formname in tblSoftwareTypeForm 
        /// </summary>
        /// <returns></returns>
        public bool AddUType_FormName_tblSoftwareTypeForm()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@UserTypeID", SqlDbType.BigInt, 8, ParameterDirection.Input, usertypeid);
                myparam[1] = ModHelper.CreateParameter("@FormID", SqlDbType.BigInt, 8, ParameterDirection.Input, formid);
                myparam[2] = ModHelper.CreateParameter("@FormPermission", SqlDbType.Bit, 1, ParameterDirection.Input, formpermission);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_insert_tblSoftwareTypeForm", myparam);
                return true;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        /// <summary>
        /// update user type & formname in tblSoftwareTypeForm 
        /// </summary>
        /// <returns></returns>
        public bool UpdateUType_FormName_tblSoftwareTypeForm()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@UserTypeID", SqlDbType.BigInt, 8, ParameterDirection.Input, usertypeid);
                myparam[1] = ModHelper.CreateParameter("@FormID", SqlDbType.BigInt, 8, ParameterDirection.Input, formid);
                myparam[2] = ModHelper.CreateParameter("@FormPermission", SqlDbType.Bit, 1, ParameterDirection.Input, formpermission);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblSoftwareTypeForm", myparam);
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Check user type & formID already exist in tblSoftwareTypeForm 
        /// </summary>
        /// <returns></returns>
        public DataTable CheckUTID_FormIDExist()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@UserTypeID", SqlDbType.BigInt, 8, ParameterDirection.Input, usertypeid);
                myparam[1] = ModHelper.CreateParameter("@FormID", SqlDbType.BigInt, 8, ParameterDirection.Input, formid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_UserTypeID_FormIDExist", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        /// <summary>
        ///Show Userwise Form in table 
        /// </summary>
        /// <returns></returns>
        public DataTable ShowUserWiseFormPermission()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@UserID", SqlDbType.BigInt, 8, ParameterDirection.Input, userid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_ShowUserWiseFormPermission", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        ///Show FormName  
        /// </summary>
        /// <returns></returns>
        public DataTable ShowFormNameByParentID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FormID", SqlDbType.BigInt, 8, ParameterDirection.Input, formid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_ShowFormNameByParentID", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        ///<Summary>
        ///Insert userid & group id in tblSoftwareGroupRelational
        ///</Summary>

        public bool Insert_SoftwareUserGroupRelation()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = ModHelper.CreateParameter("@GroupID", SqlDbType.Int, 4, ParameterDirection.Input, groupID);
                param[1] = ModHelper.CreateParameter("@UserID", SqlDbType.Int, 4, ParameterDirection.Input, userid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_INSERT_tblSoftwareUserGroupRelation", param);
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete_SoftwareUserGroupRelation()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@GroupID", SqlDbType.Int, 4, ParameterDirection.Input, groupID);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_DELETE_tblSoftwareUserGroupRelation", param);             

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Select_SoftwareUserGroupRelation()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@GroupID", SqlDbType.Int, 4, ParameterDirection.Input, groupID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblSoftwareUserGroupRelation", param);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// add user type & formname in tblImageComparePermission 
        /// </summary>
        /// <returns></returns>
        public void AddUType_FormName_tblImageComparePermission()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@UserTypeID", SqlDbType.BigInt, 8, ParameterDirection.Input, usertypeid);
                myparam[1] = ModHelper.CreateParameter("@ICPermission", SqlDbType.BigInt, 8, ParameterDirection.Input, formid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblImageComparePermission", myparam);
               
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void DeleteUType_FormName_tblImageComparePermission()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@UserTypeID", SqlDbType.BigInt, 8, ParameterDirection.Input, usertypeid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblImageComparePermission", myparam);
               
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        /// <summary>
        /// Check user type & formID already exist in tblSoftwareTypeForm 
        /// </summary>
        /// <returns></returns>
        public DataTable CheckUTID_FormIDExistINImageComapareTable()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@UserTypeID", SqlDbType.BigInt, 8, ParameterDirection.Input, usertypeid);
                myparam[1] = ModHelper.CreateParameter("@ICPermission", SqlDbType.BigInt, 8, ParameterDirection.Input, formid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblImageComparePermission", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataSet Select_All_Record_tblSoftwareUserInfo()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblSoftwareUserInfo");
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
