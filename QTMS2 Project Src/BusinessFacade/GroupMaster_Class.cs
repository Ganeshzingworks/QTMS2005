using System;
using System.Collections.Generic;
using System.Text;
using DataFacade;
using System.Data;
using System.Data.SqlClient;

namespace BusinessFacade
{
    public class GroupMaster_Class
    {
        #region Varibles & Properties

        private int GroupID;

        public int groupID
        {
            get { return GroupID; }
            set { GroupID = value; }
        }

        private string GroupName;

        public string groupName
        {
            get { return GroupName; }
            set { GroupName = value; }
        }

        private short ActiveFlag;

        public short activeFlag
        {
            get { return ActiveFlag; }
            set { ActiveFlag = value; }
        }

        

        #endregion
      
        #region Functions

        public DataSet Select_tblSoftwareUserGroup()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblSoftwareUserGroup");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public int Insert_tblSoftwareUserGroup()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@GroupName", SqlDbType.NVarChar, 50, ParameterDirection.Input, groupName);
                myparam[1] = ModHelper.CreateParameter("@Del", SqlDbType.Bit,1,ParameterDirection.Input,activeFlag);
                myparam[2] = ModHelper.CreateParameter("@GroupID", SqlDbType.Int, 4, ParameterDirection.Output);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_INSERT_tblSoftwareUserGroup", myparam);
                groupID = Convert.ToInt32(myparam[2].Value);
                 return groupID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool Update_tblSoftwareUserGroup()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@GroupID", SqlDbType.Int, 8, ParameterDirection.Input, groupID);
                myparam[1] = ModHelper.CreateParameter("@GroupName", SqlDbType.NVarChar, 50, ParameterDirection.Input, groupName);
                myparam[2] = ModHelper.CreateParameter("@Del", SqlDbType.Bit, 1, ParameterDirection.Input, activeFlag);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_UPDATE_tblSoftwareUserGroup", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete_tblSoftwareUserGroup()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@GroupID", SqlDbType.Int, 8, ParameterDirection.Input, groupID);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_DELETE_tblSoftwareUserGroup", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblSoftwareUserGroup_GroupID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@GroupID", SqlDbType.Int, 8, ParameterDirection.Input, groupID);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblSoftwareUserGroup_GroupID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblSoftwareUserGroup_GroupName()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@GroupName", SqlDbType.NVarChar, 50, ParameterDirection.Input, groupName);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_Group", myparam);
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
