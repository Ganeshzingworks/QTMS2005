using DataFacade;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BusinessFacade
{
    public class LayoutLineMaster_Class
    {
        #region Varibles
        private long Id;
        private long Loginuser; 
        private string LineDescription;
        private string TraningFileName;
        private string TraningFilePath;
        private string LayoutFileName; 
        private string LayoutFilePath; 
        private bool ScoopApplicable;
        long _ManufacturedById;
        #endregion
        #region Properties
        public long id
        { 
            get { return Id; }
            set { Id = value; }
        }
        public long loginuser
        { 
            get { return Loginuser; }
            set { Loginuser = value; }
        }
        public string lineDescription
        {
            get { return LineDescription; }
            set { LineDescription = value; }
        }
        public string traningFileName
        {
            get { return TraningFileName; }
            set { TraningFileName = value; }
        }
        public string traningFilePath
        {
            get { return TraningFilePath; }
            set { TraningFilePath = value; }
        }
        public string layoutFileName
        {
            get { return LayoutFileName; }
            set { LayoutFileName = value; }
        }
        public string layoutFilePath
        {
            get { return LayoutFilePath; }
            set { LayoutFilePath = value; }
        }
        public bool scoopApplicable
        {
            get { return ScoopApplicable; }
            set { ScoopApplicable = value; }
        }

        public long ManufacturedById
        {
            get { return _ManufacturedById; }
            set { _ManufacturedById = value; }
        }

        #endregion
        #region Functions
        public DataSet Select_LayoutLineMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblLayoutLineMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Insert_LayoutLineMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[8];
                //SqlParameter[]myparam=new SqlParameter[]
                myparam[0] = ModHelper.CreateParameter("@LineDescription", SqlDbType.NVarChar, 250, ParameterDirection.Input, lineDescription);
                myparam[1] = ModHelper.CreateParameter("@ScoopApplicable", SqlDbType.Bit, 1, ParameterDirection.Input, scoopApplicable);
                myparam[2] = ModHelper.CreateParameter("@TraningFileName", SqlDbType.NVarChar, 250, ParameterDirection.Input, traningFileName);
                myparam[3] = ModHelper.CreateParameter("@TraningFilePath", SqlDbType.NVarChar, 250, ParameterDirection.Input, traningFilePath);
                myparam[4] = ModHelper.CreateParameter("@LayoutFileName", SqlDbType.NVarChar, 250, ParameterDirection.Input, layoutFileName);
                myparam[5] = ModHelper.CreateParameter("@LayoutFilePath", SqlDbType.NVarChar, 250, ParameterDirection.Input, layoutFilePath);
                myparam[6] = ModHelper.CreateParameter("@ManufacturedOn", SqlDbType.BigInt, 8, ParameterDirection.Input, ManufacturedById);
                myparam[7] = ModHelper.CreateParameter("@LoginBy", SqlDbType.BigInt, 8, ParameterDirection.Input, loginuser);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_INSERT_tblLayoutLineMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update_LayoutLineMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[9];
                myparam[0] = ModHelper.CreateParameter("@Id", SqlDbType.BigInt, 8, ParameterDirection.Input, Id);
                myparam[1] = ModHelper.CreateParameter("@LineDescription", SqlDbType.NVarChar, 250, ParameterDirection.Input, lineDescription);
                myparam[2] = ModHelper.CreateParameter("@ScoopApplicable", SqlDbType.Bit, 1, ParameterDirection.Input, scoopApplicable);
                myparam[3] = ModHelper.CreateParameter("@TraningFileName", SqlDbType.NVarChar, 250, ParameterDirection.Input, traningFileName);
                myparam[4] = ModHelper.CreateParameter("@TraningFilePath", SqlDbType.NVarChar, 250, ParameterDirection.Input, traningFilePath);
                myparam[5] = ModHelper.CreateParameter("@LayoutFileName", SqlDbType.NVarChar, 250, ParameterDirection.Input, layoutFileName);
                myparam[6] = ModHelper.CreateParameter("@LayoutFilePath", SqlDbType.NVarChar, 250, ParameterDirection.Input, layoutFilePath);
                myparam[7] = ModHelper.CreateParameter("@ManufacturedOn", SqlDbType.BigInt, 8, ParameterDirection.Input, ManufacturedById);
                myparam[8] = ModHelper.CreateParameter("@LoginBy", SqlDbType.BigInt, 8, ParameterDirection.Input, loginuser);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblLayoutLineMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete_LayoutLineMaster()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@Id", SqlDbType.BigInt, 8, ParameterDirection.Input, Id);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblLayoutLineMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public DataSet Select_All_Record_tblLayoutLineMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "SP_Select_All_tblLayoutLineMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public bool Select_IsScoopApp_ByLineDesc()
        {
            try
            {
                bool B;
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@LineDesc", SqlDbType.NVarChar, 250, ParameterDirection.Input, lineDescription);
                B = (bool)SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "Select_IsScoopLineMaster_ByLineDesc");
                return B;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_ScoopApplLineMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_ScoopApptblLayoutLineMaster");
                return ds;
            }
            catch
            {
                throw;
            }

        }
               
        public DataSet Select_Manufacturer()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblManufacturedBy");
                return ds;
            }
            catch
            {
                throw;
            }
        }


       
    }
}
