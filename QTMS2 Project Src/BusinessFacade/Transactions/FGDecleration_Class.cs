using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;

namespace BusinessFacade.Transactions
{
    public class FGDecleration_Class
    {
        # region Variables
        private long FGTLFID;
        private string DeclerationLotNo;
        private string Qty;
        private int Active;
        private long CreatedBy;
        private string DeclerationType;
        # endregion
        # region Properties
        public long createdby
        {
            get { return CreatedBy; }
            set { CreatedBy = value; }
        }        
        public int active
        {
            get { return Active; }
            set { Active = value; }
        }
        public string qty
        {
            get { return Qty; }
            set { Qty = value; }
        }
        public string declerationlotno
        {
            get { return DeclerationLotNo; }
            set { DeclerationLotNo = value; }
        }
        public long fgtlfid
        {
            get { return FGTLFID; }
            set { FGTLFID = value; }
        }
        public string declerationtype
        {
            get { return DeclerationType; }
            set { DeclerationType = value; }
        }
        # endregion 

        # region Functions

        public void Insert_tblFGDecleration()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[6];
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                myparam[1] = ModHelper.CreateParameter("@DeclerationLotNo", SqlDbType.VarChar, 150, ParameterDirection.Input, declerationlotno);
                myparam[2] = ModHelper.CreateParameter("@Qty", SqlDbType.VarChar, 50, ParameterDirection.Input, qty);
                myparam[3] = ModHelper.CreateParameter("@Active", SqlDbType.Int, 4, ParameterDirection.Input, active);
                myparam[4] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, createdby);
                myparam[5] = ModHelper.CreateParameter("@DeclerationType", SqlDbType.VarChar, 50, ParameterDirection.Input, declerationtype);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblFGDecleration", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_tblFGDecleration_FGTLFID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblFGDecleration_FGTLFID", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }
        public void Delete_tblFGDecleration_FGTLFID()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
               
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblFGDecleration_FGTLFID", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        # endregion
    }
}
