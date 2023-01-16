using DataFacade;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BusinessFacade
{
    public class LayoutLineValidationMaster_Class
    { 
        #region Varibles
        private long Id;
        private long Loginuser;
        private long LineDescription;
        private string Name;
        private string Parameter;
        private string MinValue;
        private string MaxValue;
        private string Value;
        private DateTime ValiddummydateforFrom;
        private DateTime ValidFrom;
        private DateTime? ValidTo;
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
        public long lineDescription
        {
            get { return LineDescription; }
            set { LineDescription = value; }
        }
        public string name
        {
            get { return Name; }
            set { Name = value; }
        }
        public string parameter
        {
            get { return Parameter; }
            set { Parameter = value; }
        }
        public string minValue
        {
            get { return MinValue; }
            set { MinValue = value; }
        }
        public string maxValue
        {
            get { return MaxValue; }
            set { MaxValue = value; }
        }
        public string value
        {
            get { return Value; }
            set { Value = value; }
        }
        public DateTime validdummydateforFrom
        {
            get { return ValidFrom; }
            set { ValidFrom = value; }
        }
        public DateTime validFrom
        {
            get { return ValidFrom; }
            set { ValidFrom = value; }
        }
        public DateTime? validTo
        {
            get { return ValidTo; }
            set { ValidTo = value; }
        }

        public long ManufacturedById
        {
            get { return _ManufacturedById; }
            set { _ManufacturedById = value; }
        }

        #endregion
        #region Functions
        public DataSet Select_LayoutLineValidationMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblLayoutLineValidationMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Insert_LayoutLineValidationMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[9];
                myparam[0] = ModHelper.CreateParameter("@LayoutLineDescriptionId", SqlDbType.BigInt, 8, ParameterDirection.Input, lineDescription);
                myparam[1] = ModHelper.CreateParameter("@Name", SqlDbType.NVarChar, 250, ParameterDirection.Input, name);
                myparam[2] = ModHelper.CreateParameter("@Parameter", SqlDbType.NVarChar, 250, ParameterDirection.Input, parameter);
                myparam[3] = ModHelper.CreateParameter("@MinValue", SqlDbType.NVarChar, 250, ParameterDirection.Input, minValue);
                myparam[4] = ModHelper.CreateParameter("@MaxValue", SqlDbType.NVarChar, 250, ParameterDirection.Input, maxValue);
                myparam[5] = ModHelper.CreateParameter("@Value", SqlDbType.NVarChar, 250, ParameterDirection.Input, value);
                myparam[6] = ModHelper.CreateParameter("@ValidFrom", SqlDbType.DateTime, 250, ParameterDirection.Input, validFrom);
                myparam[7] = ModHelper.CreateParameter("@ValidTo", SqlDbType.DateTime, 250, ParameterDirection.Input, validTo);
                myparam[8] = ModHelper.CreateParameter("@LoginBy", SqlDbType.BigInt, 8, ParameterDirection.Input, loginuser);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_INSERT_tblLayoutLineValidationMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update_LayoutLineValidationMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[8];
                myparam[0] = ModHelper.CreateParameter("@Id", SqlDbType.BigInt, 8, ParameterDirection.Input, Id);
                myparam[1] = ModHelper.CreateParameter("@LayoutLineDescriptionId", SqlDbType.BigInt, 8, ParameterDirection.Input, lineDescription);
                myparam[2] = ModHelper.CreateParameter("@MinValue", SqlDbType.NVarChar, 250, ParameterDirection.Input, minValue);
                myparam[3] = ModHelper.CreateParameter("@MaxValue", SqlDbType.NVarChar, 250, ParameterDirection.Input, maxValue);
                myparam[4] = ModHelper.CreateParameter("@Value", SqlDbType.NVarChar, 250, ParameterDirection.Input, value);
                myparam[5] = ModHelper.CreateParameter("@ValidFrom", SqlDbType.DateTime, 250, ParameterDirection.Input, validFrom);
                myparam[6] = ModHelper.CreateParameter("@ValidTo", SqlDbType.DateTime, 250, ParameterDirection.Input, validTo);
                myparam[7] = ModHelper.CreateParameter("@LoginBy", SqlDbType.BigInt, 8, ParameterDirection.Input, loginuser);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblLayoutLineValidationMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete_LayoutLineValidationMaster()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@Id", SqlDbType.BigInt, 8, ParameterDirection.Input, Id);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblLayoutLineValidationMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public DataSet Select_All_Record_tblLayoutLineValidationMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "SP_Select_All_tblLayoutLineValidationMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet Select_LayoutLineTransactionMasterByLineDescriptionId(long lineDescriptionId)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@LayoutLineDescriptionId", SqlDbType.BigInt, 8, ParameterDirection.Input, lineDescriptionId);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblLayoutLineValidationMaster_By_LayoutLineDescriptionId", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataSet SelectAll_LayoutLineTransactionMasterByLineDescriptionId(long lineDescriptionId)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@LayoutLineDescriptionId", SqlDbType.BigInt, 8, ParameterDirection.Input, lineDescriptionId);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SelectAll_tblLayoutLineValidationMaster_By_LayoutLineDescriptionId", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
