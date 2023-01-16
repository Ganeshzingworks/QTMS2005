using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DataFacade;


namespace BusinessFacade.Scoop_Class
{
   public class UPdefect_Class
    {
        #region Private member
        Int64 UPTestAtSamplingPointID;
        string CorrectiveActionTaken, CompletedProductImpactStudy, Treatment, DefectName, DefectType,DefectDescription,ActionTaken;
        string AqlLevel;
        #endregion

        #region properties
       public string defectdescription
       {
           get { return DefectDescription; }
           set { DefectDescription = value; }
       }
       public string actiontaken
       {
           get { return ActionTaken; }
           set { ActionTaken = value; }
       }

        public Int64 uptestatsamplingpointid
        {
            get { return UPTestAtSamplingPointID; }
            set { UPTestAtSamplingPointID = value;}
        }
        public string correctiveactiontaken
        {
            get { return CorrectiveActionTaken; }
            set { CorrectiveActionTaken = value;}
        
        }
       
        public string completedproductimpactstudy
        {
            get { return CompletedProductImpactStudy; }
            set { CompletedProductImpactStudy = value;}
        
        }
        public string treatment
        {
            get { return Treatment;  }
            set { Treatment = value; }
        }
        public string defectname
        {
            get { return DefectName;  }
            set { DefectName = value; }
        }
        public string defecttype
        {
            get { return DefectType; }
            set { DefectType = value;}
        }
        public string aqllevel
        {
            get { return AqlLevel; }
            set { AqlLevel = value; }
        
        }
       private Int64 DefectId;
       public Int64 defectId
       {
           get { return DefectId; }
           set { DefectId = value; }
       
       }
        #endregion

        #region functions

        public bool insert_tblUPTestDefect()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[9];
                myparam[0] = ModHelper.CreateParameter("@UPTestAtSamplingPointID", SqlDbType.BigInt, 8, ParameterDirection.Input,uptestatsamplingpointid);
                myparam[1] = ModHelper.CreateParameter("@CorrectiveActionTaken", SqlDbType.NVarChar,250, ParameterDirection.Input,correctiveactiontaken);
                myparam[2] = ModHelper.CreateParameter("@CompletedProductImpactStudy", SqlDbType.NVarChar, 250, ParameterDirection.Input,completedproductimpactstudy);
                myparam[3] = ModHelper.CreateParameter("@Treatment ", SqlDbType.NVarChar, 250, ParameterDirection.Input, treatment);
                myparam[4] = ModHelper.CreateParameter("@DefectName", SqlDbType.NVarChar, 250, ParameterDirection.Input,defectname);
                myparam[5] = ModHelper.CreateParameter("@DefectType", SqlDbType.NVarChar, 250, ParameterDirection.Input,defecttype);
                myparam[6] = ModHelper.CreateParameter("@AQLLevel", SqlDbType.NVarChar, 250, ParameterDirection.Input, aqllevel);
                myparam[7] = ModHelper.CreateParameter("@DefectDescription", SqlDbType.NVarChar, 250, ParameterDirection.Input, defectdescription);
                myparam[8] = ModHelper.CreateParameter("@Actiontaken", SqlDbType.NVarChar, 250, ParameterDirection.Input, actiontaken);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblUPTestDefect", myparam);
                return true;
            }
            catch (Exception)
            {
                
                throw;
            }
        
        }

        public DataSet Select_tblUPTestDefectByUPTstAtsamplingPoint()//to get the defect  froms data
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@UPTestAtSamplingPointID", SqlDbType.BigInt, 8, ParameterDirection.Input, uptestatsamplingpointid);
                myparam[1] = ModHelper.CreateParameter("@AQLLevel", SqlDbType.NVarChar, 250, ParameterDirection.Input, aqllevel);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblUPTestDefectByUPTstAtsamplingPoint", myparam);
                return ds;
            }
            catch
            {
                throw;
            }
        
        }

       public bool Update_tblUPDefect()
       {

           try
           {
               SqlParameter[] myparam = new SqlParameter[6];
              // myparam[0] = ModHelper.CreateParameter("@UPTestAtSamplingPointID", SqlDbType.BigInt, 8, ParameterDirection.Input, uptestatsamplingpointid);
               myparam[0] = ModHelper.CreateParameter("@CorrectiveActionTaken", SqlDbType.NVarChar, 250, ParameterDirection.Input, correctiveactiontaken);
               myparam[1] = ModHelper.CreateParameter("@CompletedProductImpactStudy", SqlDbType.NVarChar, 250, ParameterDirection.Input, completedproductimpactstudy);
               myparam[2] = ModHelper.CreateParameter("@Treatment ", SqlDbType.NVarChar, 250, ParameterDirection.Input, treatment);
               myparam[3] = ModHelper.CreateParameter("@DefectID", SqlDbType.BigInt, 8, ParameterDirection.Input, defectId);
               myparam[4] = ModHelper.CreateParameter("@DefectDescription", SqlDbType.NVarChar, 250, ParameterDirection.Input, defectdescription);
               myparam[5] = ModHelper.CreateParameter("@Actiontaken", SqlDbType.NVarChar, 250, ParameterDirection.Input, actiontaken);
               SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_ScoopUpadte_UPDefect", myparam);
               return true;
           }
           catch (Exception)
           {

               throw;
           }
       
       
       }
        #endregion

    }
}
