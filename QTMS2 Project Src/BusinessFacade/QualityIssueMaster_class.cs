using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;

namespace BusinessFacade
{
    public class QualityIssueMaster_class
    {


        # region Varibles
        private string QualityIssueDetails;
        private int QualityIssueId;


        # endregion
        # region Properties

        public string qualityIssueDetails
        {
            get { return QualityIssueDetails; }
            set { QualityIssueDetails = value; }
        }

        public int qualityIssueId
        {
            get { return QualityIssueId; }
            set { QualityIssueId = value; }
        }





        # endregion
        # region Functions

        public DataSet Select_tblQualityIssue()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblQualityIssue");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool Insert_tblQualityIssue()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];

                myparam[0] = ModHelper.CreateParameter("@QualityIssueDetails", SqlDbType.VarChar, 250, ParameterDirection.Input, qualityIssueDetails);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblQualityIssue", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update_tblQualityIssue()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@QualityIssueId", SqlDbType.BigInt, 8, ParameterDirection.Input, qualityIssueId);
                myparam[1] = ModHelper.CreateParameter("@QualityIssueDetails", SqlDbType.NVarChar, 250, ParameterDirection.Input, qualityIssueDetails);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblQualityIssue", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool Delete_tblQualityIssue()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@QualityIssueId", SqlDbType.BigInt, 8, ParameterDirection.Input, qualityIssueId);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblQualityIssue", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        # endregion



    }
}

    

