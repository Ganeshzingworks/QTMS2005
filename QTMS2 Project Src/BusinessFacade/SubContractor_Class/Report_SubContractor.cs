using System;
using System.Collections.Generic;
using System.Text;
using DataFacade;
using System.Data;
using System.Data.SqlClient;

namespace BusinessFacade.SubContractor_Class
{
    public class Report_SubContractor
    {
        #region variables

        private string _fromdate;
        private string _todate;
        private long _fgtestno;
        private long _fmid;
        private long _fgtlfid;
        #endregion

        #region Properties
        public long fgtlfid
        {
            get { return _fgtlfid; }
            set { _fgtlfid = value; }
        }

        public long fgtestno
        {
            get { return _fgtestno; }
            set { _fgtestno = value; }
        }
        public long fmid
        {
            get { return _fmid; }
            set { _fmid = value; }
        }
        public string fromdate
        {
            get { return _fromdate; }
            set { _fromdate = value; }
        }
        
        public string todate
        {
            get { return _todate; }
            set { _todate = value; }
        }

        #endregion

        #region Functions

        public DataSet Select_tblFGTLF_Details_SubContractor()
        {
            try
            {
                DataSet ds = new DataSet();

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblFGTLF_Details_SubContractor");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_tblTransFMFinishedGoods_Details_SubContractor()
        {
            try
            {
                DataSet ds = new DataSet();

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblTransFMFinishedGoods_Details_SubContractor");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_VIEW_FG_Analysis_Report_SubContractor()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtestno);
                //myparam[1] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_FG_Analysis_Report_SubContractor", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_VIEW_FG_MfgWo_Analysis_Report_SubContractor()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtestno);
                myparam[1] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_FG_Mfg_Analysis_Report_SubContractor", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_VIEW_FG_Analysis_Phy_Report_SubContractor()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtestno);
                //myparam[1] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_FG_Analysis_Phy_Report_SubContractor", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Select_VIEW_FG_MfgWo_Analysis_Phy_Report_SubContractor()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtestno);
                myparam[1] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_FG_MfgWo_Analysis_Phy_Report_SubContractor", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_VIEW_FG_Analysis_Pack_Report_Loreal_SubContractor()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtestno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_FG_Analysis_Pack_Report_Loreal_SubContractor", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_VIEW_FG_Analysis_Pack_Report_Supplier_SubContractor()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtestno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_FG_Analysis_Pack_Report_Supplier_SubContractor", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_VIEW_FG_Analysis_MicrobiologyTest_Report_SubContractor()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtestno);
                //myparam[1] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_FG_Analysis_MicrobiologyTest_Report_SubContractor", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Select_VIEW_FG_MfgWo_Analysis_MicrobiologyTest_Report_SubContractor()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtestno);
                myparam[1] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_FG_MfgWo_Analysis_MicrobiologyTest_Report_SubContractor", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_VIEW_BulkTDB_Report_SubContract()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_BulkTDB_Report_SubContract", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_VIEW_FG_Preservative_Report_SubContractor_Loreal()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtestno);
                //myparam[1] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_FG_Preservative_Report_SubContractor_Loreal", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Select_VIEW_FG_MfgWo_Preservative_Report_SubContractor_Loreal()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtestno);
                myparam[1] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_FG_MfgWo_Preservative_Report_SubContractor_Loreal", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_VIEW_FG_Preservative_Report_SubContractor_Supplier()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtestno);
                //myparam[1] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_FG_Preservative_Report_SubContractor_Supplier", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Select_VIEW_FG_MfgWo_Preservative_Report_SubContractor_Supplier()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FGTestNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtestno);
                myparam[1] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_FG_MfgWo_Preservative_Report_SubContractor_Supplier", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_STP_GET_FGtestNo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_GET_FGtestNo", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Select_STP_GET_FGtestNo_UsingMdfWo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_GET_FGtestNo_UsingMdfWo", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_FGCode_RetainerLocation()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_FGCode_RetainerLocation_Subcontract");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        public DataSet Select_RetainerSampleLocation_Subcontractor_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                myparam[2] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_FGRetainerSampleLocation_Report_Subcontract", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet Select_FinishedGoodSummary_Subcontractor_Report()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_FinishedGoodSummary_Report_Subcontractor", myparam);
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
