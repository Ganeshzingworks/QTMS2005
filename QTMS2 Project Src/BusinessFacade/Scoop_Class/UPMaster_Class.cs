using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DataFacade;

namespace BusinessFacade.Scoop_Class
{
   public class UPMaster_Class
   {

        #region private member
        Int64 UPID, FGTLFID;
        DateTime LineStartTime;
       char UpAuthorityStatus, QualityAuthorityStatus, FinalStatus;
       int UPAuthorityInspectedById, QualityAuthorityInspectedById, FinalInspectedBy;
       string UPAuthorityComment, QualityAuthorityComment, FinalComment, ControlType;
        #endregion

        #region Properties

        public Int64 upid
        {
            get { return UPID;}
            set { UPID = value; }
        
        }

        public Int64 fgtlfid
        {
            get { return FGTLFID; }
            set { FGTLFID = value; }

        }

        public DateTime linestarttime
        {
            get { return LineStartTime; }
            set { LineStartTime = value; }

        }
        public char upauthorityStatus
        {
            get { return UpAuthorityStatus; }
            set { UpAuthorityStatus = value; }
        }
        public char qualityAuthorityStatus
        {
            get { return QualityAuthorityStatus; }
            set { QualityAuthorityStatus = value; }
        }
        public int upauthorityInspectedById
        {
            get { return UPAuthorityInspectedById; }
            set { UPAuthorityInspectedById = value;} 
        }
        public int qualityauthorityInspectedById
        {
            get { return QualityAuthorityInspectedById; }
            set { QualityAuthorityInspectedById = value;}
        }
        public string upauthorityComment
        {
            get { return UPAuthorityComment; }
            set { UPAuthorityComment = value;} 
        }
        public string qualityauthorityComment
        {
            get { return QualityAuthorityComment; }
            set { QualityAuthorityComment = value; }
        }

       public string finalComment
       {
           get { return FinalComment; }
           set { FinalComment = value; }
       }

       public int finalInspectedBy
       {
           get { return FinalInspectedBy; }
           set { FinalInspectedBy = value; }
       }

       public char finalStatus
       {
           get { return FinalStatus; }
           set { FinalStatus = value; }
       }

       public string controlType
       {
           get { return ControlType; }
           set { ControlType = value; }
       }

        #endregion

        #region Function

        public bool Insert_tblUpTestMaster()
        {

            try
            {
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                myparam[1] = ModHelper.CreateParameter("@LineStartTim", SqlDbType.DateTime, 8, ParameterDirection.Input, linestarttime);
                myparam[2] = ModHelper.CreateParameter("@ControlType", SqlDbType.VarChar, 50, ParameterDirection.Input, controlType);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblUpTestMaster", myparam);
                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public Int64 GetLastAdded_tblUpTestMaster()
        {
            try
            {
                 Int64 Id = 0;
                 Id = Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_GetLastAdded_tblUpTestMaster").ToString());
                return Id;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        public DataSet Select_GetSamplingPoints_tblUpTestMasterFGTLF()//to get sampling points on up master form
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                myparam[1] = ModHelper.CreateParameter("@LineStartTime", SqlDbType.DateTime, 8, ParameterDirection.Input, linestarttime);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure,"STP_GetSamplingPoints_tblUpTestMasterFGTLF", myparam);
                return ds;
            }
            catch (Exception)
            {
                
                throw;
            }
        
        }

        public DataSet select_GetPendingDetailsForUpAuthority()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure,"STP_GetPendingDetailForScoopUPAuthority");
                return ds;
            }
            catch (Exception)
            {
                
                throw;
            }
        
        
        }

        public bool Update_UPAuthority()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[5];
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                myparam[1] = ModHelper.CreateParameter("@LineStartTime", SqlDbType.DateTime, 8, ParameterDirection.Input, linestarttime);
                myparam[2] = ModHelper.CreateParameter("@UPAuthorityInspectedById", SqlDbType.Int, 4, ParameterDirection.Input, upauthorityInspectedById);
                myparam[3] = ModHelper.CreateParameter("@UPAuthorityComment", SqlDbType.NVarChar, 250, ParameterDirection.Input, upauthorityComment);
                myparam[4] = ModHelper.CreateParameter("@UPAuthorityStatus", SqlDbType.Char, 1, ParameterDirection.Input, upauthorityStatus);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_UPAuhtority_tblUpTestMaster", myparam);
                return true;
            }
            catch (Exception)
            {
                return false;
               // throw;
            }
        
        }

        public bool Update_QualityAuthority()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[5];
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                myparam[1] = ModHelper.CreateParameter("@LineStartTime", SqlDbType.DateTime, 8, ParameterDirection.Input, linestarttime);
                myparam[2] = ModHelper.CreateParameter("@QualityAuthorityInspectedBy", SqlDbType.Int, 4, ParameterDirection.Input, qualityauthorityInspectedById);
                myparam[3] = ModHelper.CreateParameter("@QualityAuthorityComment", SqlDbType.NVarChar, 250, ParameterDirection.Input,qualityauthorityComment);
                myparam[4] = ModHelper.CreateParameter("@QualityAuthorityStatus", SqlDbType.Char, 1, ParameterDirection.Input,qualityAuthorityStatus);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_QualityAuhtority_tblUpTestMaster", myparam);
                return true;
            }
            catch (Exception)
            {
                return false;
                // throw;
            }

        }

        public DataSet Select_UpAuthority()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                myparam[1] = ModHelper.CreateParameter("@LineStartTime", SqlDbType.DateTime, 8, ParameterDirection.Input, linestarttime);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_UPAuthority_tblUpTestMaster", myparam);
                return ds;

            }
            catch (Exception)
            {
                
                throw;
            }
        
        }

        public DataSet Select_QualityAuthority()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
                myparam[1] = ModHelper.CreateParameter("@LineStartTime", SqlDbType.DateTime, 8, ParameterDirection.Input, linestarttime);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_QualityAuthority_tblUpTestMaster", myparam);
                return ds;

            }
            catch (Exception)
            {

                throw;
            }

        }

        public DateTime GetCurrentTime()
        {
            try
            {
                DateTime CurrTme;
                CurrTme = (DateTime)SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_GetCurrentDateTime_UP");
                return CurrTme;
            }
            catch
            {
                throw;
            }
        }

        public DataSet Select_UPMaster()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[2];
               myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
               myparam[1] = ModHelper.CreateParameter("@LineStartTime", SqlDbType.DateTime, 8, ParameterDirection.Input, linestarttime);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SelectUPMaster_FgtlfID_StartTme", myparam);
               return ds;
           }
           catch (Exception)
           {

               throw;
           }
       }

       public bool Update_UPMasterFinal()
       {

           try
           {
               SqlParameter[] myparam = new SqlParameter[4];
               myparam[0] = ModHelper.CreateParameter("@UPID", SqlDbType.BigInt, 8, ParameterDirection.Input, upid);
               myparam[1] = ModHelper.CreateParameter("@FinalStatus", SqlDbType.Char, 1, ParameterDirection.Input, finalStatus);
               myparam[2] = ModHelper.CreateParameter("@FinalComment", SqlDbType.NVarChar,250, ParameterDirection.Input,finalComment);
               myparam[3] = ModHelper.CreateParameter("@FinalInspectedBy", SqlDbType.Int, 4, ParameterDirection.Input, finalInspectedBy);
               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblUpTestMaster_Final", myparam);
               return true;
           }
           catch (Exception)
           {
               return false;
               // throw;
           }
       }

        #endregion
       /// <summary>
       /// 2013-07-24 Pandurang Kumbhar for Retrieve Status and Comment from tblFinishedGoodTestDetails
       /// </summary>
       /// <returns></returns>
       public DataSet Select_tblFinishedGoodTestDetailsStatus()
       {
           try
           {
               DataSet ds = new DataSet();
               SqlParameter[] myparam = new SqlParameter[2];
               myparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgtlfid);
               //myparam[1] = ModHelper.CreateParameter("@LineStartTime", SqlDbType.DateTime, 8, ParameterDirection.Input, linestarttime);
               ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SelectStatusandComment", myparam);
               return ds;
           }
           catch (Exception)
           {
               throw;
           }
           //throw new Exception("The method or operation is not implemented.");
       }
   }
}
