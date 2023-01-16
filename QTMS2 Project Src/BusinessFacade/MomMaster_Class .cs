using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;
using System.Reflection;

namespace BusinessFacade
{
    public class MomMaster_Class 
    {
        # region Variables
        private string  MOMNo;
        private int DetailId;
        private int FooterId;
        private int MOMId;
        private string FormulaNo;
        private int Fno;
        private Double SrNo;
        private int PrintSequenceNo;
       private int IsNoteProSubPro;
        private string BatchSize;
        private string ProductDescription;
        private string IQualityPreparedBy;
        private string IQualityAcceptedBy;
        private string IQualityPreparedByD;
        private string IQualityAcceptedByD;
        private DateTime IQualityDate;
        private string UPAcceptedBy;
        private string UPAcceptedByD;
        private DateTime UPAcceptedByDate;
        private string SHEAcceptedBy;
        private string SHEAcceptedByD;
        private DateTime SHEAcceptedByDate;
        private string ReferenceDocument;
        private string ReasonforIssue;
        private string ISODocumentNo;
        private string DocumentsAssoociated;
        private string Equipmentstobeused;
        private string VesselId;
        private string AnnexTankId;
         private string  ProcessDesc;
        private string  Scrapper;
         private string  Impeller;
         private string   Emulsifer;
         private string   Vac;
        private string   Symb;
        private string     Accsessories;
       private int DetailID;
      
        private string Adjustmentquantity;
        private int Isupdate;
        private string HTMLProcessDesc;

        public int IsUpdate
            
        {
            get { return Isupdate; }
            set { Isupdate = value; }
        }
        private int DummySrNo;
      
        #endregion

        # region Properties

        public string htmlProcessDesc
        {
            get { return HTMLProcessDesc; }
            set { HTMLProcessDesc = value; }
        }
        public string  momno
        {
            get { return MOMNo; }
            set { MOMNo = value; }
        }

        public int footerId
        {
            get { return FooterId; }
            set { FooterId = value; }
        }

        public int detailId
        {
            get { return DetailId; }
            set { DetailId = value; }
        }

        public int dummysrno
        {
            get { return DummySrNo; }
            set { DummySrNo = value; }
        }

      
         public string symb
        {
            get { return Symb; }
            set {Symb= value; }
        }

        public int detailID
        {
            get { return DetailID; }
            set { DetailID  = value; }
        }
         public string accsessories
        {
            get { return Accsessories; }
            set {Accsessories = value; }
        }

         public string  scrapper
        {
            get { return Scrapper; }
            set { Scrapper = value; }
        }
   

          public string  impeller
        {
            get { return Impeller; }
            set { Impeller = value; }
        }

        
          public string  vac
        {
            get { return  Vac; }
            set {  Vac = value; }
        }



          public string    emulsifer
        {
            get { return    Emulsifer; }
            set {    Emulsifer = value; }
        }

         public string  processDesc
        {
            get { return ProcessDesc; }
            set {ProcessDesc = value; }
        }
        public int isNoteProSubPro
        {
            get { return IsNoteProSubPro; }
            set {   IsNoteProSubPro = value; }
        }
        public Double srNo
        {
            get { return SrNo; }
            set {   SrNo = value; }
        }
        public string vesselId
        {
            get { return VesselId; }
            set { VesselId = value; }
        }
        public string annexTankId
        {
            get { return AnnexTankId; }
            set { AnnexTankId = value; }
        }
        public int fno
        {
            get { return Fno; }
            set { Fno = value; }
        }


        public int printSequenceNo
        {
            get { return PrintSequenceNo; }
            set { PrintSequenceNo = value; }
        }
        public string formulaNo
        {
            get { return FormulaNo; }
            set { FormulaNo = value; }
        }

        public string batchSize
        {
            get { return BatchSize; }
            set { BatchSize = value; }
        }
        public string productDescription
        {
            get { return ProductDescription; }
            set { ProductDescription = value; }
        }
        public string iQualityPreparedBy
        {
            get { return IQualityPreparedBy; }
            set { IQualityPreparedBy = value; }
        }
        public string iQualityAcceptedBy
        {
            get { return IQualityAcceptedBy; }
            set { IQualityAcceptedBy = value; }
        }
        public string iQualityPreparedByD
        {
            get { return IQualityPreparedByD; }
            set { IQualityPreparedByD = value; }
        }


        public string iQualityAcceptedByD
        {
            get { return IQualityAcceptedByD; }

            set { IQualityAcceptedByD = value; }
        }
        public DateTime iQualityDate
        {
            get { return IQualityDate; }
            set { IQualityDate = value; }
        }
        public string upAcceptedBy
        {
            get { return UPAcceptedBy; }
            set { UPAcceptedBy = value; }
        }

        public string upAcceptedByD
        {
            get { return UPAcceptedByD; }
            set { UPAcceptedByD = value; }
        }
        public DateTime upAcceptedByDate
        {
            get { return UPAcceptedByDate; }
            set { UPAcceptedByDate = value; }
        }

        public string sheAcceptedBy
        {
            get { return SHEAcceptedBy; }
            set { SHEAcceptedBy = value; }
        }
        public string adjustmentquantity
        {
            get { return Adjustmentquantity; }
            set { Adjustmentquantity = value; }
        }
        public string sheAcceptedByD
        {
            get { return SHEAcceptedByD; }
            set { SHEAcceptedByD = value; }
        }

        public DateTime sheAcceptedByDate
        {
            get { return SHEAcceptedByDate; }
            set { SHEAcceptedByDate = value; }
        }
        public string referenceDocument
        {
            get { return ReferenceDocument; }
            set { ReferenceDocument = value; }
        }
        public string reasonforIssue
        {
            get { return ReasonforIssue; }
            set { ReasonforIssue = value; }
        }

        public string iSODocumentNo
        {
            get { return ISODocumentNo; }
            set { ISODocumentNo = value; }
        }
        public string documentsAssoociated
        {
            get { return DocumentsAssoociated; }
            set { DocumentsAssoociated = value; }
        }
        public string equipmentstobeused
        {
            get { return Equipmentstobeused; }
            set { Equipmentstobeused = value; }
        }

        public int momid
        {
            get { return MOMId ; }

            set { MOMId  = value; }

        }
        private string DeleteDetailID;

        public string deletedetailid
        {
            get { return DeleteDetailID; }
            set { DeleteDetailID = value; }
        }

        private int UserID;

        public int userId
        {
            get { return UserID; }
            set { UserID = value; }
        }

        private int SignatureRoleID;

        public int signatureRoleId
        {
            get { return SignatureRoleID; }
            set { SignatureRoleID = value; }
        }
	
        # endregion



        public long Insert_MOMMaster()
        {
            try
            {
                SqlParameter[] myaparam = new SqlParameter[18];
                myaparam[0] = ModHelper.CreateParameter("@MOMNo", SqlDbType.VarChar, 150, ParameterDirection.Input, momno);
                myaparam[1] = ModHelper.CreateParameter("@FormulaNo", SqlDbType.VarChar, 150, ParameterDirection.Input, formulaNo);
                myaparam[2] = ModHelper.CreateParameter("@BatchSize", SqlDbType.VarChar, 50, ParameterDirection.Input, batchSize);
                myaparam[3] = ModHelper.CreateParameter("@ProductDescription", SqlDbType.VarChar, 200, ParameterDirection.Input, productDescription);
                myaparam[4] = ModHelper.CreateParameter("@IQualityPreparedBy", SqlDbType.VarChar, 100, ParameterDirection.Input, iQualityPreparedBy);
                myaparam[5] = ModHelper.CreateParameter("@IQualityAcceptedBy", SqlDbType.VarChar, 100, ParameterDirection.Input, iQualityAcceptedBy);
                myaparam[6] = ModHelper.CreateParameter("@IQualityDate", SqlDbType.DateTime, 50, ParameterDirection.Input, iQualityDate);
                myaparam[7] = ModHelper.CreateParameter("@UPAcceptedBy", SqlDbType.VarChar, 100, ParameterDirection.Input, upAcceptedBy);
                myaparam[8] = ModHelper.CreateParameter("@UPAcceptedByDate", SqlDbType.DateTime, 50, ParameterDirection.Input, upAcceptedByDate);
                myaparam[9] = ModHelper.CreateParameter("@SHEAcceptedBy", SqlDbType.VarChar, 100, ParameterDirection.Input, sheAcceptedBy);
                myaparam[10] = ModHelper.CreateParameter("@SHEAcceptedByDate", SqlDbType.DateTime, 50, ParameterDirection.Input, sheAcceptedByDate);
                myaparam[11] = ModHelper.CreateParameter("@ReferenceDocument", SqlDbType.VarChar, 100, ParameterDirection.Input, referenceDocument);
                myaparam[12] = ModHelper.CreateParameter("@ReasonforIssue", SqlDbType.VarChar, 100, ParameterDirection.Input, reasonforIssue);
                myaparam[13] = ModHelper.CreateParameter("@ISODocumentNo", SqlDbType.VarChar, 50, ParameterDirection.Input, iSODocumentNo);
               // myaparam[14] = ModHelper.CreateParameter("@DocumentsAssoociated", SqlDbType.VarChar, 50, ParameterDirection.Input, documentsAssoociated);
              //  myaparam[14] = ModHelper.CreateParameter("@Equipmentstobeused", SqlDbType.VarChar, 50, ParameterDirection.Input, equipmentstobeused);
                myaparam[14] = ModHelper.CreateParameter("@Fno", SqlDbType.Int, 4, ParameterDirection.Input,fno );
                myaparam[15] = ModHelper.CreateParameter("@VesselId", SqlDbType.VarChar, 1000, ParameterDirection.Input,vesselId);
                myaparam[16] = ModHelper.CreateParameter("@AnnexTankId", SqlDbType.VarChar, 1000, ParameterDirection.Input,annexTankId);
                myaparam[17] = ModHelper.CreateParameter("@MOMId", SqlDbType.VarChar, 50, ParameterDirection.Output,momid );
               
                SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_INSERT_tblMOMMaster", myaparam);
                return Convert.ToInt32(myaparam[17].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        public DataSet Select_From_tblMOMMaster_By_MOMNo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@MOMNo", SqlDbType.VarChar, 200, ParameterDirection.Input,momno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblMOMMaster_MOMNo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        //public DataSet Select_From_tblMOMMaster_By_MOMId()
        //{
        //    try
        //    {
        //        DataSet ds = new DataSet();
        //        SqlParameter[] myparam = new SqlParameter[1];
        //        myparam[0] = ModHelper.CreateParameter("@MOMId", SqlDbType.Int, 8, ParameterDirection.Input, momid);
        //        ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblMOMMaster_By_MOMId", myparam);
        //        return ds;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //}

        public DataSet Select_From_tblMOMProcessMaster_By_momid()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@MOMId", SqlDbType.Int, 4, ParameterDirection.Input,momid );
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblMOMProcessMaster_MOMId", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public bool Delete_tblMOMMaster()
        {
            try
            {
                SqlParameter[] myaparam = new SqlParameter[1];
                myaparam[0] = ModHelper.CreateParameter("@MOMId", SqlDbType.Int, 4, ParameterDirection.Input,momid);
                SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_Delete_tblMOMMaster", myaparam);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete_tblMOMProcessMaster_By_MOMId()
        {
            try
            {
                SqlParameter[] myaparam = new SqlParameter[1];
                myaparam[0] = ModHelper.CreateParameter("@MOMId", SqlDbType.Int, 4, ParameterDirection.Input, momid);
                SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_Delete_tblMOMProcessMaster_By_MOMId", myaparam);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete_tblMOMProcessMaster()
        {
            try
            {
                SqlParameter[] myaparam = new SqlParameter[1];
                myaparam[0] = ModHelper.CreateParameter("@MOMId", SqlDbType.Int, 4, ParameterDirection.Input, momid);
                SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_Delete_tblMOMMaster", myaparam);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete_tblMOMProcessMaster_DetailID()
        {
            try
            {
                SqlParameter[] myaparam = new SqlParameter[1];
                myaparam[0] = ModHelper.CreateParameter("@DetailID", SqlDbType.Int, 4, ParameterDirection.Input, detailID);
                SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_Delete_tblMOMProcessMaster", myaparam);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_From_tblMOMFooterMaster_By_momid()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@MOMId", SqlDbType.Int, 4, ParameterDirection.Input, momid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblMOMFooterMaste_MOMId", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public DataSet Select_From_tblMOMMaster_By_FBV()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@FormulaNo", SqlDbType.VarChar, 200, ParameterDirection.Input,formulaNo );
                myparam[1] = ModHelper.CreateParameter("@BatchSize", SqlDbType.VarChar, 200, ParameterDirection.Input,batchSize);
                myparam[2] = ModHelper.CreateParameter("@VesselId", SqlDbType.VarChar, 200, ParameterDirection.Input,vesselId );
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblMOMMaster_By_FBV", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        
             public DataSet Select_From_tblMOMMaster_Vessel()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FormulaNo", SqlDbType.VarChar, 200, ParameterDirection.Input,formulaNo) ;
                myparam[1] = ModHelper.CreateParameter("@BatchSize", SqlDbType.VarChar, 200, ParameterDirection.Input,batchSize);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblMOMMaster_Vessel", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet   Select_tblMOMProcessMaster_By_MOMId()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@MOMId", SqlDbType.Int, 4, ParameterDirection.Input,momid) ;
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_tblMOMProcessMaster_By_MOMId", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    


        public DataSet SELECT_tblMOMMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblMOMMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public DataSet SELECT_tblAgitationRpm_Scrapper()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblAgitationRpm_Scrapper");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public DataSet SELECT_tblAgitationRpm_Impeller()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblAgitationRpm_Impeller");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public DataSet SELECT_tblAgitationRpm_Emulsifier()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblAgitationRpm_Emulsifier");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }



        public DataSet SELECT_tblAgitationRpm_Vac()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblAgitationRpm_Vac");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        public DataSet Select_From_tblMOMMaster_By_MOMId()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@MOMId", SqlDbType.BigInt, 8, ParameterDirection.Input,momid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblMOMMaster_MOMId", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }




        public DataSet Select_From_tblMOMProcessMaster_By_MOMId()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@MOMId", SqlDbType.Int, 4, ParameterDirection.Input, momid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_tblMOMProcessMaster_By_MOMId", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
       



        public DataSet SELECT_tblMOMProcessMaster_SrnoProcess()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@IsNoteProSubPro", SqlDbType.BigInt, 8, ParameterDirection.Input,isNoteProSubPro);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "SELECT_tblMOMProcessMaster_SrnoProcess", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }
        public DataSet SELECT_tblMOMProcessMaster_SrnosubProcess()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@IsNoteProSubPro", SqlDbType.BigInt, 8, ParameterDirection.Input,isNoteProSubPro);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "SELECT_tblMOMProcessMaster_SrnosubProcess", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }


        public long Insert_tblMOMProcessMaster(MomMaster_Class obj)
        {
            try
            {
                SqlParameter[] myaparam = new SqlParameter[12];
                myaparam[0] = ModHelper.CreateParameter("@MomId", SqlDbType.Int, 4, ParameterDirection.Input, obj.momid);
                myaparam[1] = ModHelper.CreateParameter("@SrNo", SqlDbType.Float, 50, ParameterDirection.Input, obj.srNo);
                myaparam[2] = ModHelper.CreateParameter("@IsNoteProSubPro", SqlDbType.Int,4, ParameterDirection.Input,obj.isNoteProSubPro);
                myaparam[3] = ModHelper.CreateParameter("@ProcessDesc", SqlDbType.Text, 2147483647, ParameterDirection.Input,obj.htmlProcessDesc );
                myaparam[4] = ModHelper.CreateParameter("@Scrapper", SqlDbType.VarChar, 50, ParameterDirection.Input,obj.scrapper );
                myaparam[5] = ModHelper.CreateParameter("@Impeller", SqlDbType.VarChar, 50, ParameterDirection.Input,obj.impeller);
                myaparam[6] = ModHelper.CreateParameter("@Emulsifer", SqlDbType.VarChar,50, ParameterDirection.Input,obj.emulsifer);
                myaparam[7] = ModHelper.CreateParameter("@Vac", SqlDbType.VarChar, 50, ParameterDirection.Input,obj.vac);
                myaparam[8] = ModHelper.CreateParameter("@Symb", SqlDbType.VarChar, 50, ParameterDirection.Input,obj.symb );
               myaparam[9] = ModHelper.CreateParameter("@Accsessories", SqlDbType.VarChar, 50, ParameterDirection.Input, obj.accsessories);
                myaparam[10] = ModHelper.CreateParameter("@PrintSequenceNo", SqlDbType.VarChar, 50, ParameterDirection.Input,obj.printSequenceNo);
               
                myaparam[11] = ModHelper.CreateParameter("@DetailID", SqlDbType.Int, 4, ParameterDirection.Output,obj.detailID);

                    SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_INSERT_tblMOMProcessMaster", myaparam);
                return Convert.ToInt32(myaparam[11].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public  void  UPDATE_tblMOMProcessMaster (MomMaster_Class obj)
        {
            try
            {
                SqlParameter[] myaparam = new SqlParameter[13];
                myaparam[0] = ModHelper.CreateParameter("@MomId", SqlDbType.Int, 4, ParameterDirection.Input, obj.momid);
                myaparam[1] = ModHelper.CreateParameter("@SrNo", SqlDbType.Float, 50, ParameterDirection.Input, obj.srNo);
                myaparam[2] = ModHelper.CreateParameter("@IsNoteProSubPro", SqlDbType.Int,4, ParameterDirection.Input,obj.isNoteProSubPro);
                myaparam[3] = ModHelper.CreateParameter("@ProcessDesc", SqlDbType.Text,2147483647, ParameterDirection.Input,obj.htmlProcessDesc );
                myaparam[4] = ModHelper.CreateParameter("@Scrapper", SqlDbType.VarChar, 50, ParameterDirection.Input,obj.scrapper );
                myaparam[5] = ModHelper.CreateParameter("@Impeller", SqlDbType.VarChar, 50, ParameterDirection.Input,obj.impeller);
                myaparam[6] = ModHelper.CreateParameter("@Emulsifer", SqlDbType.VarChar,50, ParameterDirection.Input,obj.emulsifer);
                myaparam[7] = ModHelper.CreateParameter("@Vac", SqlDbType.VarChar, 50, ParameterDirection.Input,obj.vac);
                myaparam[8] = ModHelper.CreateParameter("@Symb", SqlDbType.VarChar, 50, ParameterDirection.Input,obj.symb );
               myaparam[9] = ModHelper.CreateParameter("@Accsessories", SqlDbType.VarChar, 50, ParameterDirection.Input, obj.accsessories);
                myaparam[10] = ModHelper.CreateParameter("@PrintSequenceNo", SqlDbType.VarChar, 50, ParameterDirection.Input,obj.printSequenceNo);
                myaparam[11] = ModHelper.CreateParameter("@IsUpdate", SqlDbType.Int, 4, ParameterDirection.Input, IsUpdate);
                myaparam[12] = ModHelper.CreateParameter("@DetailID", SqlDbType.Int, 4, ParameterDirection.Input,obj.detailID);

                SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_UPDATE_tblMOMProcessMaster", myaparam);
                //return Convert.ToInt32(myaparam[11].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UPDATE_tblMOMMaster()
        {
            try
            {
             SqlParameter[] myaparam = new SqlParameter[18];
                myaparam[0] = ModHelper.CreateParameter("@MOMNo", SqlDbType.VarChar, 150, ParameterDirection.Input, momno);
                myaparam[1] = ModHelper.CreateParameter("@FormulaNo", SqlDbType.VarChar, 150, ParameterDirection.Input, formulaNo);
                myaparam[2] = ModHelper.CreateParameter("@BatchSize", SqlDbType.VarChar, 50, ParameterDirection.Input, batchSize);
                myaparam[3] = ModHelper.CreateParameter("@ProductDescription", SqlDbType.VarChar, 200, ParameterDirection.Input, productDescription);
                myaparam[4] = ModHelper.CreateParameter("@IQualityPreparedBy", SqlDbType.VarChar, 100, ParameterDirection.Input, iQualityPreparedBy);
                myaparam[5] = ModHelper.CreateParameter("@IQualityAcceptedBy", SqlDbType.VarChar, 100, ParameterDirection.Input, iQualityAcceptedBy);
                myaparam[6] = ModHelper.CreateParameter("@IQualityDate", SqlDbType.DateTime, 50, ParameterDirection.Input, iQualityDate);
                myaparam[7] = ModHelper.CreateParameter("@UPAcceptedBy", SqlDbType.VarChar, 100, ParameterDirection.Input, upAcceptedBy);
                myaparam[8] = ModHelper.CreateParameter("@UPAcceptedByDate", SqlDbType.DateTime, 50, ParameterDirection.Input, upAcceptedByDate);
                myaparam[9] = ModHelper.CreateParameter("@SHEAcceptedBy", SqlDbType.VarChar, 100, ParameterDirection.Input, sheAcceptedBy);
                myaparam[10] = ModHelper.CreateParameter("@SHEAcceptedByDate", SqlDbType.DateTime, 50, ParameterDirection.Input, sheAcceptedByDate);
                myaparam[11] = ModHelper.CreateParameter("@ReferenceDocument", SqlDbType.VarChar, 100, ParameterDirection.Input, referenceDocument);
                myaparam[12] = ModHelper.CreateParameter("@ReasonforIssue", SqlDbType.VarChar, 100, ParameterDirection.Input, reasonforIssue);
                myaparam[13] = ModHelper.CreateParameter("@ISODocumentNo", SqlDbType.VarChar, 50, ParameterDirection.Input, iSODocumentNo);
               // myaparam[14] = ModHelper.CreateParameter("@DocumentsAssoociated", SqlDbType.VarChar, 50, ParameterDirection.Input, documentsAssoociated);
              //  myaparam[14] = ModHelper.CreateParameter("@Equipmentstobeused", SqlDbType.VarChar, 50, ParameterDirection.Input, equipmentstobeused);
                myaparam[14] = ModHelper.CreateParameter("@Fno", SqlDbType.Int, 4, ParameterDirection.Input,fno );
                myaparam[15] = ModHelper.CreateParameter("@VesselId", SqlDbType.VarChar, 1000, ParameterDirection.Input,vesselId);
                myaparam[16] = ModHelper.CreateParameter("@AnnexTankId", SqlDbType.VarChar, 1000, ParameterDirection.Input,annexTankId);
                  myaparam[17] = ModHelper.CreateParameter("@MOMId", SqlDbType.Int, 4, ParameterDirection.Input,momid );
                  SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_UPDATE_tblMOMMaster", myaparam);
                

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UPDATE_tblMOMFooterMaster()
        {
            try
            {
                SqlParameter[] myaparam = new SqlParameter[2];
                myaparam[0] = ModHelper.CreateParameter("@Adjustmentquantity", SqlDbType.VarChar, 1000, ParameterDirection.Input,adjustmentquantity);
                myaparam[1] = ModHelper.CreateParameter("@MOMId", SqlDbType.Int, 4, ParameterDirection.Input, momid);
                SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_UPDATE_tblMOMFooterMaster", myaparam);
           
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }




      



        public long Insert_tblMOMFooterMaster()
        {
            try
            {
                SqlParameter[] myaparam = new SqlParameter[3];
                myaparam[0] = ModHelper.CreateParameter("@MomId", SqlDbType.Int, 4, ParameterDirection.Input, momid);
                myaparam[1] = ModHelper.CreateParameter("@Adjustmentquantity", SqlDbType.VarChar, 1000, ParameterDirection.Input,adjustmentquantity);
                myaparam[2] = ModHelper.CreateParameter("@FooterId", SqlDbType.Int, 4, ParameterDirection.Output,footerId );

                SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_INSERT_tblMOMFooterMaster", myaparam);
                return Convert.ToInt32(myaparam[2].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_From_tblMOMFooterMaster_By_MOMId()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@MOMId", SqlDbType.Int, 4, ParameterDirection.Input, momid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_tblMOMFooterMaster_By_MOMId", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;

            }
        }

        #region Digital Signature

        public DataTable Select_tblMOMSignatureRole()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblMOMSignatureRole").Tables[0];
                return dt;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public DataTable Select_tblMOMUserSignRole()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@UserID",SqlDbType.Int,4,ParameterDirection.Input,userId);
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblMOMUserSignRole",param).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert_tblMOMUserSignRole()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = ModHelper.CreateParameter("@UserID", SqlDbType.Int, 4, ParameterDirection.Input, userId);
                param[1] = ModHelper.CreateParameter("@SignatureRoleID", SqlDbType.Int, 4, ParameterDirection.Input, signatureRoleId);
                int i = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblMOMUserSignRole",param);
                if (i == 1)
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
        public bool Update_tblMOMUserSignRole()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = ModHelper.CreateParameter("@UserID", SqlDbType.Int, 4, ParameterDirection.Input, userId);
                param[1] = ModHelper.CreateParameter("@SignatureRoleID", SqlDbType.Int, 4, ParameterDirection.Input, signatureRoleId);
                int i = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_UPDATE_tblMOMUserSignRole",param);
                if (i == 1)
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete_tblMOMUserSignRole()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = ModHelper.CreateParameter("@UserID", SqlDbType.Int, 4, ParameterDirection.Input, userId);
                param[1] = ModHelper.CreateParameter("@SignatureRoleID", SqlDbType.Int, 4, ParameterDirection.Input, signatureRoleId);
                int i = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblMOMUserSignRole", param);
                if (i == 1)
                    return true;
                else
                    return false;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

    }
   
}