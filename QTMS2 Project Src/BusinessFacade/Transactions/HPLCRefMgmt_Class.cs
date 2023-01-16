using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;

namespace BusinessFacade.Transactions
{
    public class HPLCRefMgmt_Class
    {
        #region Properties
        private long Prsno;

        public long prsno
        {
            get { return Prsno; }
            set { Prsno = value; }
        }

        private DateTime DateOfPreparation;

        public DateTime dateOfPreparation
        {
            get { return DateOfPreparation; }
            set { DateOfPreparation = value; }
        }

        private DateTime DateOfValidation;

        public DateTime dateOfValidation
        {
            get { return DateOfValidation; }
            set { DateOfValidation = value; }
        }

        private int LoginID;

        public int loginID
        {
            get { return LoginID; }
            set { LoginID = value; }
        }

        #endregion
        #region Functions

        public bool Insert_tblHPLCRefMgmt()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = ModHelper.CreateParameter("@Prsno", SqlDbType.BigInt, 8, ParameterDirection.Input, prsno);
                param[1] = ModHelper.CreateParameter("@DateOfPreparation", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, dateOfPreparation);
                param[2] = ModHelper.CreateParameter("@DateOfValidity", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, dateOfValidation);
                param[3] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginID);

                int i = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblHPLCRefMgmt", param);
                if (i > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public DataTable Select_tblHPLCRefMgmt()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@Prsno", SqlDbType.BigInt, 8, ParameterDirection.Input, prsno);
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_select_tblHPLCRefMgmt", param).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion
    }
}
