using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;
namespace BusinessFacade
{
    public class DocumentMaster
    {
        # region Varibles
        private string DocumentAssociatedDetails;
        private int DocumentAssoId;


        # endregion
        # region Properties

        public string documentAssociatedDetails
        {
            get { return DocumentAssociatedDetails; }
            set { DocumentAssociatedDetails = value; }
        }

        public int documentAssoId
        {
            get { return DocumentAssoId; }
            set { DocumentAssoId = value; }
        }





        # endregion
        # region Functions

        public DataSet Select_tblDocumentAssociatedDetails()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblDocumentAssociatedDetails");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool Insert_tblDocumentAssociatedDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];

                myparam[0] = ModHelper.CreateParameter("@DocumentAssociatedDetails", SqlDbType.VarChar, 400, ParameterDirection.Input, documentAssociatedDetails);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblDocumentAssociatedDetails", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update_tblDocumentAssociatedDetails()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@DocumentAssoId", SqlDbType.BigInt, 8, ParameterDirection.Input,documentAssoId );
                myparam[1] = ModHelper.CreateParameter("@DocumentAssociatedDetails", SqlDbType.VarChar, 400, ParameterDirection.Input, documentAssociatedDetails);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblDocumentAssociatedDetails", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool Delete_tblDocumentAssociatedDetails()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@DocumentAssoId", SqlDbType.BigInt, 8, ParameterDirection.Input, documentAssoId);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblDocumentAssociatedDetails", myparam);
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
