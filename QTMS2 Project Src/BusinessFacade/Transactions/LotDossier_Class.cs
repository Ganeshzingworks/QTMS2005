using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DataFacade;

namespace BusinessFacade.Transactions
{
    public class LotDossier_Class
    {
        private long FGTestNo;
        public long fgtestno
        {
            get { return FGTestNo; }
            set { FGTestNo = value; }
        }
        private char Release;
        public char release
        {
            get { return Release; }
            set { Release = value; }
        }
        private char Status;
        public char status
        {
            get { return Status; }
            set { Status = value; }
        }
        private string DateOfRelease;
        public string dateofrelease
        {
            get { return DateOfRelease; }
            set { DateOfRelease = value; }
        }
        private string Comment;
        public string comment
        {
            get { return Comment; }
            set { Comment = value; }
        }
        private int InspectedBy;
        public int inspectedby
        {
            get { return InspectedBy; }
            set { InspectedBy = value; }
        }

        public DataSet Select_tblLotDossier_FGTestNo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtestno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblLotDossier_FGTestNo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert_tblLotDossier()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[6];
                myparam[0] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtestno);
                myparam[1] = ModHelper.CreateParameter("@Release", SqlDbType.Char, 1, ParameterDirection.Input, release);
                myparam[2] = ModHelper.CreateParameter("@Status", SqlDbType.Char, 1, ParameterDirection.Input, status);
                myparam[3] = ModHelper.CreateParameter("@DateOfRelease", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, dateofrelease);
                myparam[4] = ModHelper.CreateParameter("@Comment", SqlDbType.NVarChar, 250, ParameterDirection.Input, comment);
                myparam[5] = ModHelper.CreateParameter("@InspectedBy", SqlDbType.Int, 4, ParameterDirection.Input, inspectedby);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblLotDossier", myparam);                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update_tblLotDossier()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[6];
                myparam[0] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtestno);
                myparam[1] = ModHelper.CreateParameter("@Release", SqlDbType.Char, 1, ParameterDirection.Input, release);
                myparam[2] = ModHelper.CreateParameter("@Status", SqlDbType.Char, 1, ParameterDirection.Input, status);
                myparam[3] = ModHelper.CreateParameter("@DateOfRelease", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, dateofrelease);
                myparam[4] = ModHelper.CreateParameter("@Comment", SqlDbType.NVarChar, 250, ParameterDirection.Input, comment);
                myparam[5] = ModHelper.CreateParameter("@InspectedBy", SqlDbType.Int, 4, ParameterDirection.Input, inspectedby);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblLotDossier", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
