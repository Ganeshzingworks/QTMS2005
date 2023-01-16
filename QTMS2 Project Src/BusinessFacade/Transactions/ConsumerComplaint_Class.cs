using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;

namespace BusinessFacade.Transactions
{
    public class ConsumerComplaint_Class
    {
        #region Variables
        
        private string TrackCode;
        private string BatchNo;
        private string FillVolume;
        private long PKGTechNo;
        private string FormulaNo;
        private long FGPhyMethodNo;
        private string NormsMin;
        private string NormsMax;
        private string NormsReading;        
        private string Comments;        
        private string ComplaintDetail;
        private string ComplaintRefNo;
        private string PackingComments;
        private char Status;                
        private long FNo;        
        private long TransID;        
        private long ObsID;
        private int CategoryID;
        private int InspectedBy;
        private int LoginID;
        private string RootCause;
        private string Step;
        private string RetainerReading;
        private string InspDate;
        private string BatchNoSearch;
        private long FGPhyCheNo;
        #endregion

        #region Properties
        public long fgphycheno
        {
            get { return FGPhyCheNo; }
            set { FGPhyCheNo = value; }
        }
        public string inspdate
        {
            get { return InspDate; }
            set { InspDate = value; }
        }
        public string retainerreading
        {
            get { return RetainerReading; }
            set { RetainerReading = value; }
        }
        public string step
        {
            get { return Step; }
            set { Step = value; }
        }
        public string rootcause
        {
            get { return RootCause; }
            set { RootCause = value; }
        }
        public string trackcode
        {
            get { return TrackCode; }
            set { TrackCode = value; }
        }
        public string batchno
        {
            get { return BatchNo; }
            set { BatchNo = value; }
        }
        public string batchnosearch
        {
            get { return BatchNoSearch; }
            set { BatchNoSearch = value; }
        }
        public string fillvolume
        {
            get { return FillVolume; }
            set { FillVolume = value; }
        }
        public long pkgtechno
        {
            get { return PKGTechNo; }
            set { PKGTechNo = value; }
        }
        public long fgphymethodno
        {
            get { return FGPhyMethodNo; }
            set { FGPhyMethodNo = value; }
        }
        public char status
        {
            get { return Status; }
            set { Status = value; }
        }
        public int categoryid
        {
            get { return CategoryID; }
            set { CategoryID = value; }
        }
        public int loginid
        {
            get { return LoginID; }
            set { LoginID = value; }
        }
        public long fno
        {
            get { return FNo; }
            set { FNo = value; }
        }
        public long obsid
        {
            get { return ObsID; }
            set { ObsID = value; }
        }       
        public long transid
        {
            get { return TransID; }
            set { TransID = value; }
        }
        public string complaintdetail
        {
            get { return ComplaintDetail; }
            set { ComplaintDetail = value; }
        }
        public string comments
        {
            get { return Comments; }
            set { Comments = value; }
        }
        public string complaintrefno
        {
            get { return ComplaintRefNo; }
            set { ComplaintRefNo = value; }
        }
        public string normsmin
        {
            get { return NormsMin; }
            set { NormsMin = value; }
        }
        public string normsmax
        {
            get { return NormsMax; }
            set { NormsMax = value; }
        }
        public string normsreading
        {
            get { return NormsReading; }
            set { NormsReading = value; }
        }
        public string formulano
        {
            get { return FormulaNo; }
            set { FormulaNo = value; }
        }
        public string packingcomments
        {
            get { return PackingComments; }
            set { PackingComments = value; }
        }
        public int inspectedby
        {
            get { return InspectedBy; }
            set { InspectedBy = value; } 
        }
        #endregion
        #region Functions

        public DataSet Select_ComplaintCategory()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblComplaintCategory");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblComplaintPhyCheTestMethodDetails_Done()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                DataSet ds = new DataSet();               
                myparam[0] = ModHelper.CreateParameter("@TransID", SqlDbType.BigInt, 8, ParameterDirection.Input, transid);
                myparam[1] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblComplaintPhyCheTestMethodDetails_Done", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblComplaintObs_Formulas()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();                
                myparam[0] = ModHelper.CreateParameter("@TransID", SqlDbType.BigInt, 8, ParameterDirection.Input, transid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblComplaintObs_Formulas", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblComplaintTransaction_Details()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();                
                myparam[0] = ModHelper.CreateParameter("@ComplaintRefNo", SqlDbType.VarChar, 50, ParameterDirection.Input, complaintrefno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblComplaintTransaction_Details", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblComplaintPackingObs()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[3];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@TrackCode", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, trackcode);
                myparam[1] = ModHelper.CreateParameter("@BatchNo", SqlDbType.VarChar, 50, ParameterDirection.Input, batchno);
                myparam[2] = ModHelper.CreateParameter("@ComplaintRefNo", SqlDbType.VarChar, 50, ParameterDirection.Input, complaintrefno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblComplaintPackingObs", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblComplaintInvestigation()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[3];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@TrackCode", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, trackcode);
                myparam[1] = ModHelper.CreateParameter("@BatchNo", SqlDbType.VarChar, 50, ParameterDirection.Input, batchno);
                myparam[2] = ModHelper.CreateParameter("@ComplaintRefNo", SqlDbType.VarChar, 50, ParameterDirection.Input, complaintrefno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblComplaintInvestigation", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SELECT_ComplaintTransaction()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@ComplaintRefNo", SqlDbType.VarChar, 50, ParameterDirection.Input, complaintrefno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblComplaintTransaction", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Insert_tblComplaintTransaction()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[14];
                myparam[0] = ModHelper.CreateParameter("@ComplaintRefNo", SqlDbType.VarChar, 50, ParameterDirection.Input, complaintrefno);
                myparam[1] = ModHelper.CreateParameter("@ComplaintDetail", SqlDbType.VarChar, 250, ParameterDirection.Input, complaintdetail);
                myparam[2] = ModHelper.CreateParameter("@CategoryID", SqlDbType.Int, 4, ParameterDirection.Input, categoryid);
                myparam[3] = ModHelper.CreateParameter("@TrackCode", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, trackcode);
                myparam[4] = ModHelper.CreateParameter("@BatchNo", SqlDbType.VarChar, 50, ParameterDirection.Input, batchno);
                myparam[5] = ModHelper.CreateParameter("@InspDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, inspdate);
                myparam[6] = ModHelper.CreateParameter("@FillVolume", SqlDbType.VarChar, 50, ParameterDirection.Input, fillvolume);
                myparam[7] = ModHelper.CreateParameter("@PKGTechNo", SqlDbType.BigInt, 8, ParameterDirection.Input, pkgtechno);
                myparam[8] = ModHelper.CreateParameter("@Status", SqlDbType.Char, 1, ParameterDirection.Input, status);
                myparam[9] = ModHelper.CreateParameter("@Comments", SqlDbType.VarChar, 250, ParameterDirection.Input, comments);
                myparam[10] = ModHelper.CreateParameter("@RootCause", SqlDbType.VarChar, 250, ParameterDirection.Input, rootcause);                
                myparam[11] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
                myparam[12] = ModHelper.CreateParameter("@InspectedBy", SqlDbType.Int, 8, ParameterDirection.Input,inspectedby);
                myparam[13] = ModHelper.CreateParameter("@TransID", SqlDbType.BigInt, 8, ParameterDirection.Output);
                

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblComplaintTransaction", myparam);
                TransID = Convert.ToInt64(myparam[13].Value);
                return TransID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet update_tblComplaintTransaction()
        {
            try
            {                
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[14];
                myparam[0] = ModHelper.CreateParameter("@ComplaintRefNo", SqlDbType.VarChar, 50, ParameterDirection.Input, complaintrefno);
                myparam[1] = ModHelper.CreateParameter("@ComplaintDetail", SqlDbType.VarChar, 250, ParameterDirection.Input, complaintdetail);
                myparam[2] = ModHelper.CreateParameter("@CategoryID", SqlDbType.Int, 4, ParameterDirection.Input, categoryid);
                myparam[3] = ModHelper.CreateParameter("@TrackCode", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, trackcode);
                myparam[4] = ModHelper.CreateParameter("@BatchNo", SqlDbType.VarChar, 50, ParameterDirection.Input, batchno);
                myparam[5] = ModHelper.CreateParameter("@InspDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, inspdate);
                myparam[6] = ModHelper.CreateParameter("@FillVolume", SqlDbType.VarChar, 50, ParameterDirection.Input, fillvolume);
                myparam[7] = ModHelper.CreateParameter("@PKGTechNo", SqlDbType.BigInt, 8, ParameterDirection.Input, pkgtechno);
                myparam[8] = ModHelper.CreateParameter("@Status", SqlDbType.Char, 1, ParameterDirection.Input, status);
                myparam[9] = ModHelper.CreateParameter("@Comments", SqlDbType.VarChar, 250, ParameterDirection.Input, comments);
                myparam[10] = ModHelper.CreateParameter("@RootCause", SqlDbType.VarChar, 250, ParameterDirection.Input, rootcause);
                myparam[11] = ModHelper.CreateParameter("@LoginID", SqlDbType.Int, 4, ParameterDirection.Input, loginid);
                myparam[12] = ModHelper.CreateParameter("@TransID", SqlDbType.BigInt, 8, ParameterDirection.Input,transid);
                myparam[13] = ModHelper.CreateParameter("@InspectedBy", SqlDbType.Int, 4, ParameterDirection.Input, inspectedby);

                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_update_tblComplaintTransaction", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        public bool Delete_tblComplaintTransaction()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];                
                myparam[0] = ModHelper.CreateParameter("@ComplaintRefNo", SqlDbType.VarChar, 50, ParameterDirection.Input, complaintrefno);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblComplaintTransaction", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblComplaintPhysicoChemicalTestMethodDetails_ObsID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@ObsID", SqlDbType.BigInt, 8, ParameterDirection.Input, obsid);                
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblComplaintPhysicoChemicalTestMethodDetails_ObsID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblComplaintPhysicoChemicalTestMethodDetails_ObsID_FGPhyMethodNo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@ObsID", SqlDbType.BigInt, 8, ParameterDirection.Input, obsid);
                myparam[1] = ModHelper.CreateParameter("@FGPhyMethodNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgphymethodno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblComplaintPhysicoChemicalTestMethodDetails_ObsID_FGPhyMethodNo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert_tblComplaintPhysicoChemicalTestMethodDetails()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[6];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@ObsID", SqlDbType.BigInt, 8, ParameterDirection.Input, obsid);                
                myparam[1] = ModHelper.CreateParameter("@FGPhyMethodNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgphymethodno);
                myparam[2] = ModHelper.CreateParameter("@NormsMin", SqlDbType.VarChar, 50, ParameterDirection.Input, normsmin);
                myparam[3] = ModHelper.CreateParameter("@NormsMax", SqlDbType.VarChar, 50, ParameterDirection.Input, normsmax);
                myparam[4] = ModHelper.CreateParameter("@NormsReading", SqlDbType.VarChar, 50, ParameterDirection.Input, normsreading);
                myparam[5] = ModHelper.CreateParameter("@RetainerReading", SqlDbType.VarChar, 50, ParameterDirection.Input, retainerreading);               

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblComplaintPhysicoChemicalTestMethodDetails", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete_tblComplaintPhysicoChemicalTestMethodDetails_ObsID()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@ObsID", SqlDbType.BigInt, 8, ParameterDirection.Input, obsid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblComplaintPhysicoChemicalTestMethodDetails_ObsID", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblComplaintObs_TransID_FNo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];                
                myparam[0] = ModHelper.CreateParameter("@TransID", SqlDbType.BigInt, 8, ParameterDirection.Input, transid);
                myparam[1] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);                
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblComplaintObs_TransID_FNo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Insert_ComplaintObs()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[3];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@TransID", SqlDbType.BigInt, 8, ParameterDirection.Input, transid);                
                myparam[1] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[2] = ModHelper.CreateParameter("@ObsID", SqlDbType.BigInt, 8, ParameterDirection.Output);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblComplaintObs", myparam);
                ObsID = Convert.ToInt64(myparam[2].Value);
                return ObsID;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert_tblComplaintHistory()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@TransID", SqlDbType.BigInt, 8, ParameterDirection.Input, transid);
                myparam[1] = ModHelper.CreateParameter("@FGPhyCheNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgphycheno);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblComplaintHistory", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert_ComplaintPackingObs()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@TransID", SqlDbType.BigInt, 8, ParameterDirection.Input, transid);
                myparam[1] = ModHelper.CreateParameter("@PackingComments", SqlDbType.VarChar, 250, ParameterDirection.Input, packingcomments);
                
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblComplaintPackingObs", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert_tblComplaintInvestigation()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@TransID", SqlDbType.BigInt, 8, ParameterDirection.Input, transid);
                myparam[1] = ModHelper.CreateParameter("@Step", SqlDbType.VarChar, 250, ParameterDirection.Input, step);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblComplaintInvestigation", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete_tblComplaintPackingObs()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];                
                myparam[0] = ModHelper.CreateParameter("@TransID", SqlDbType.BigInt, 8, ParameterDirection.Input, transid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblComplaintPackingObs", myparam);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete_tblComplaintHistory()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@TransID", SqlDbType.BigInt, 8, ParameterDirection.Input, transid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblComplaintHistory", myparam);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete_tblComplaintInvestigation()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@TransID", SqlDbType.BigInt, 8, ParameterDirection.Input, transid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblComplaintInvestigation", myparam);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblFGPhysicochemicalTestMethodMaster_FNo()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblFGPhysicochemicalTestMethodMaster_FNo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_FGBulkTestDetails_BatchCode()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@BatchNo", SqlDbType.VarChar, 50, ParameterDirection.Input, batchnosearch);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_FGBulkTestDetails_BatchCode", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_View_FGBulkTestDetails_TransID()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@TransID", SqlDbType.BigInt, 8, ParameterDirection.Input, transid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_View_FGBulkTestDetails_TransID", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_tblFGPhysicochemicalTestMethodDetails_FGPhyCheNo()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                DataSet ds = new DataSet();
                myparam[0] = ModHelper.CreateParameter("@FGPhyCheNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgphycheno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblFGPhysicochemicalTestMethodDetails_FGPhyCheNo", myparam);
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
