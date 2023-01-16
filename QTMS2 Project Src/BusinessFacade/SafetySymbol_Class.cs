using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DataFacade;
namespace BusinessFacade
{
    public class SafetySymbol_Class
    {
        #region Variables & Functions
        private int SymID;
        private long CreatedBy;
        private long ModifiedBy;
        public int symid
        {
            get { return SymID; }
            set { SymID = value; }
        }
        private string SynName;

        public string symname
        {
            get { return SynName; }
            set { SynName = value; }
        }

        private byte[] ImageData;

        public byte[] imagedata
        {
            get { return ImageData; }
            set { ImageData = value; }
        }

        private char SafetyAcc;

        public char safetyacc
        {
            get { return SafetyAcc; }
            set { SafetyAcc = value; }
        }

        private string SafetySign;

        public string safetysign
        {
            get { return SafetySign; }
            set { SafetySign = value; }
        }
        public long createdby
        {
            get { return CreatedBy; }
            set { CreatedBy = value; }
        }
        public long modifiedby
        {
            get { return ModifiedBy; }
            set { ModifiedBy = value; }
        }
        #endregion

        #region Function
        public DataTable Select_SafetySymbol()
        {
            try
            {
                DataTable Dt = new DataTable();
                Dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure,"STP_Select_tblSafetySymbol").Tables[0];
                return Dt;
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        public DataSet Select_SafetySymbol_symb()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblSafetySymbol_symb");
                return ds;
            }
            catch (Exception ex)
            {

                throw ex;

                
            }
        }


         public DataSet Select_SafetySymbol_acc()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblSafetySymbol_acc");
                return ds;
            }
            catch (Exception ex)
            {

                throw ex;

                
            }
        }








        public DataTable Select_SafetySymbol_SymID()
        {
            try
            {
                DataTable Dt = new DataTable();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@SymID", SqlDbType.Int, 4, ParameterDirection.Input,symid);
                Dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblRMSafetyAccessoriesSymbol", param).Tables[0];
                return Dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool Insert_SafetySymbol()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = ModHelper.CreateParameter("@SymName", SqlDbType.VarChar, 50, ParameterDirection.Input,symname);
                param[1] = ModHelper.CreateParameter("@SymImage", SqlDbType.Image,2147483647, ParameterDirection.Input,imagedata);
                param[2] = ModHelper.CreateParameter("@SafetyAcc", SqlDbType.Char, 1, ParameterDirection.Input,safetyacc);
                param[3] = ModHelper.CreateParameter("@Safetysign", SqlDbType.VarChar, 50, ParameterDirection.Input, safetysign);
                param[4] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, createdby);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblRMSafetyAccessoriesSymbol", param);
                return true;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public bool Update_SafetySymbol()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[6];
                param[0] = ModHelper.CreateParameter("@SymID", SqlDbType.Int, 4, ParameterDirection.Input,symid);
                param[1] = ModHelper.CreateParameter("@SymName", SqlDbType.VarChar, 50, ParameterDirection.Input,symname);
                param[2] = ModHelper.CreateParameter("@SymImage", SqlDbType.Image, 2147483647, ParameterDirection.Input,imagedata);
                param[3] = ModHelper.CreateParameter("@SafetyAcc", SqlDbType.Char, 1, ParameterDirection.Input,safetyacc);
                param[4] = ModHelper.CreateParameter("@Safetysign", SqlDbType.VarChar, 50, ParameterDirection.Input, safetysign);
                param[5] = ModHelper.CreateParameter("@ModifiedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, modifiedby);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblRMSafetyAccessoriesSymbol", param);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete_SafetySymbol()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@SymID", SqlDbType.Int, 4, ParameterDirection.Input,symid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblRMSafetyAccessoriesSymbol", param);
                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
}
