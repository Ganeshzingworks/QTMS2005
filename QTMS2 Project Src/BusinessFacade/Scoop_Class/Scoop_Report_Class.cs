using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;
using System.Configuration;

namespace BusinessFacade.Scoop_Class
{
   public  class Scoop_Report_Class
    {
       //private int _MfgById;
       private int _MfgById;

       public int MfgById
       {
           get { return _MfgById; }
           set { _MfgById = value; }
       }
	

        private string FromDate;
        public string fromdate
        {
            get { return FromDate; }
            set { FromDate = value; }
        }

        private string ToDate;
        public string todate
        {
            get { return ToDate; }
            set { ToDate = value; }
        }

        private Int64 FGTLFID;
        public Int64 fgtlfid
       {

           get { return FGTLFID; }
           set { FGTLFID = value; }
       
       }

       private Int64 UPID;
       public Int64 upid
       {
           get { return UPID; }
           set { UPID = value; }
       
       }

       private string UPID_str;
       public string upis_str
       {
           get { return UPID_str; }
           set { UPID_str = value; }
       }


       public DataSet SElect_VIEW_Global_FG_TDB_Report_Scoop()
       {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@FromDate", SqlDbType.VarChar, 50, ParameterDirection.Input, fromdate);
                myparam[1] = ModHelper.CreateParameter("@ToDate", SqlDbType.VarChar, 50, ParameterDirection.Input, todate);
                myparam[2] = ModHelper.CreateParameter("@MfgById", SqlDbType.Int, 8, ParameterDirection.Input, MfgById);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIEW_Global_FG_TDB_Report_Scoop", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        
        }

       public DataSet Select_tblFGTLF_Details_Scoop()
       {
          
           try
           {
               DataSet ds = new DataSet();
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblFGTLF_Details_Scoop");
               return ds;
           }
           catch (Exception)
           {
               
               throw;
           }
       }

       public DataSet Select_View_FG_AnalysisReport_Scoop()
       {
           DataSet ds = new DataSet();
           SqlParameter[] myparam = new SqlParameter[1];
           myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt,8, ParameterDirection.Input,fgtlfid);
           ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_FG_AnalysisReport_Scoop", myparam);
           return ds;
       
       }

       public DataSet Select_VIew_FG_Analysis_SamplingTest_Report()
       {
           DataSet ds = new DataSet();
           SqlParameter[] myparam = new SqlParameter[1];
           myparam[0] = ModHelper.CreateParameter("@UPID", SqlDbType.BigInt, 8, ParameterDirection.Input, upid);
           ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIew_FG_Analysis_SamplingTest_Report", myparam);
           return ds;
       
       }

       public DataSet Select_VIew_FG_Analysis_SamplingTest_Report_1()
       {
           DataSet ds = new DataSet();
           SqlParameter[] myparam = new SqlParameter[1];
           myparam[0] = ModHelper.CreateParameter("@UPID", SqlDbType.BigInt, 8, ParameterDirection.Input, upid);
           ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIew_FG_Analysis_SamplingTest_Report_1", myparam);
           return ds;

       }

       public DataSet Select_VIew_FG_Analysis_SamplingNotDoneTest_Report()
       {
           DataSet ds = new DataSet();
           SqlParameter[] myparam = new SqlParameter[1];
           myparam[0] = ModHelper.CreateParameter("@UPID", SqlDbType.BigInt, 8, ParameterDirection.Input, upid);
           ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_FG_Analysis_SamplingTestNotDone_Report", myparam);
           return ds;

       }
       public DataSet Select_VIew_FG_Analysis_SamplingYellowTest_Report()
       {
           DataSet ds = new DataSet();
           SqlParameter[] myparam = new SqlParameter[1];
           myparam[0] = ModHelper.CreateParameter("@UPID", SqlDbType.BigInt, 8, ParameterDirection.Input, upid);
           ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_FG_Analysis_SamplingTestYellow_Report", myparam);
           return ds;

       }
       public DataSet Select_VIew_FG_Analysis_SamplingRedTest_Report()
       {
           DataSet ds = new DataSet();
           SqlParameter[] myparam = new SqlParameter[1];
           myparam[0] = ModHelper.CreateParameter("@UPID", SqlDbType.BigInt, 8, ParameterDirection.Input, upid);
           ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_FG_Analysis_SamplingTestRed_Report", myparam);
           return ds;

       }

       public DataSet Select_VIew_FG_Analysis_SamplingGreenTest_Report()
       {
           DataSet ds = new DataSet();
           SqlParameter[] myparam = new SqlParameter[1];
           myparam[0] = ModHelper.CreateParameter("@UPID", SqlDbType.BigInt, 8, ParameterDirection.Input, upid);
           ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_FG_Analysis_SamplingTestGreen_Report", myparam);
           return ds;

       }

       public DataSet Select_VIew_FG_Analysis_OBS_Report()
       {
           DataSet ds = new DataSet();
           SqlParameter[] myparam = new SqlParameter[1];
           myparam[0] = ModHelper.CreateParameter("@UPID", SqlDbType.BigInt, 8, ParameterDirection.Input, upid);
           ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_VIew_FG_Analysis_OBS_Report", myparam);
           return ds;

       }

       public DataSet Select_VIew_FG_Analysis_Transaction_Report()
       {
           DataSet ds = new DataSet();
           SqlParameter[] myparam = new SqlParameter[1];
           myparam[0] = ModHelper.CreateParameter("@UPID", SqlDbType.NVarChar, 400, ParameterDirection.Input, upis_str);
           ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_VIew_FG_Analysis_Transaction_SamplingTest_Report", myparam);
           return ds;

       }
    }
}
