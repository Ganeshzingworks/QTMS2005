using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;
namespace BusinessFacade
{
    public class LineMaster_Class
    {
        #region Varibles
        private long LNo;
        private long Loginuser;
        private string TrainingFileName;
        private string TrainingFilePath;
        private string LayoutFileName;
        private List<string> TraningFileNameList;
        private List<string> TraningFilePathList;
        private List<string> TraningFileIdList;
        private string LayoutFilePath;
        private string LineName;
        private bool ScoopApplicable;
        long _ManufacturedById;
        #endregion
        #region Properties
        public long lno
        {
            get { return LNo; }
            set { LNo = value; }
        }
        public long loginuser
        {
            get { return Loginuser; }
            set { Loginuser = value; }
        }
        public string trainingFileName
        {
            get { return TrainingFileName; }
            set { TrainingFileName = value; }
        }
        public string trainingFilePath
        {
            get { return TrainingFilePath; }
            set { TrainingFilePath = value; }
        }
        private int SetofSample;

        public int setofsample
        {
            get { return SetofSample; }
            set { SetofSample = value; }
        }
	

        public List<string> trainingFileNameList = new List<string>();

        public List<string> trainingFilePathList = new List<string>();

        public List<string> trainingFileIdList = new List<string>();

        public List<string> layoutFileNameList = new List<string>();

        public List<string> layoutFilePathList = new List<string>();

        public List<string> trainingFileDescription = new List<string>();

        public List<string> layoutFileDescription = new List<string>();

        public string layoutFileName
        {
            get { return LayoutFileName; }
            set { LayoutFileName = value; }
        }
        public string layoutFilePath
        {
            get { return LayoutFilePath; }
            set { LayoutFilePath = value; }
        }
        public string linename
        {
            get { return LineName; }
            set { LineName = value; }
        }
        public bool scoopApplicable
        {
            get { return ScoopApplicable; }
            set { ScoopApplicable = value; }
        }

        public long ManufacturedById
        {
            get { return _ManufacturedById; }
            set { _ManufacturedById = value; }
        }

        #endregion
        #region Functions
        public DataSet Select_LineMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_TblLineMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_LineViewDetails(long lineDiscriptionid)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@LineNo", SqlDbType.BigInt, 8, ParameterDirection.Input, lineDiscriptionid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "SP_Select_All_LineViewDetails", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_LineTransactionModificationList()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblLineTransactionModificationList");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert_LineMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@LineName", SqlDbType.NVarChar, 250, ParameterDirection.Input, linename);
                myparam[1] = ModHelper.CreateParameter("@ScoopApplicable", SqlDbType.Bit, 1, ParameterDirection.Input, scoopApplicable);
                myparam[2] = ModHelper.CreateParameter("@ManuBy", SqlDbType.Int, 8, ParameterDirection.Input, ManufacturedById);
                myparam[3] = ModHelper.CreateParameter("@SetofSample", SqlDbType.Int, 8, ParameterDirection.Input, setofsample);
                //myparam[3] = ModHelper.CreateParameter("@TraningFileName", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, trainingFileName);
                //myparam[4] = ModHelper.CreateParameter("@TraningFilePath", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, trainingFilePath);
                //myparam[5] = ModHelper.CreateParameter("@TraningFileNameList", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, string.Join(",", trainingFileNameList.ToArray()));
                //myparam[6] = ModHelper.CreateParameter("@TraningFilePathList", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, string.Join(",", trainingFilePathList.ToArray()));
                //myparam[7] = ModHelper.CreateParameter("@LayoutFileName", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, layoutFileName);
                //myparam[8] = ModHelper.CreateParameter("@LayoutFilePath", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, layoutFilePath);
                //myparam[9] = ModHelper.CreateParameter("@LayoutFileNameList", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, string.Join(",", layoutFileNameList.ToArray()));
                //myparam[10] = ModHelper.CreateParameter("@LayoutFilePathList", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, string.Join(",", layoutFilePathList.ToArray()));
                //myparam[11] = ModHelper.CreateParameter("@TraningFileDescription", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, string.Join(",", trainingFileDescription.ToArray()));
                //myparam[12] = ModHelper.CreateParameter("@LayoutFileDescription", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, string.Join(",", layoutFileDescription.ToArray()));
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_INSERT_TblLineMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update_LineMaster()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[9];
                myparam[0] = ModHelper.CreateParameter("@LineNo", SqlDbType.BigInt, 8, ParameterDirection.Input, lno);
                myparam[1] = ModHelper.CreateParameter("@LineName", SqlDbType.NVarChar, 250, ParameterDirection.Input, linename);
                myparam[2] = ModHelper.CreateParameter("@ScoopApplicable", SqlDbType.Bit, 1, ParameterDirection.Input, scoopApplicable);
                myparam[3] = ModHelper.CreateParameter("@ManuBy", SqlDbType.Int, 8, ParameterDirection.Input, ManufacturedById);
                myparam[4] = ModHelper.CreateParameter("@TraningFileName", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, trainingFileName);
                myparam[5] = ModHelper.CreateParameter("@TraningFilePath", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, trainingFilePath);
                myparam[6] = ModHelper.CreateParameter("@LayoutFileName", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, layoutFileName);
                myparam[7] = ModHelper.CreateParameter("@LayoutFilePath", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, layoutFilePath);
                myparam[8] = ModHelper.CreateParameter("@SetofSample", SqlDbType.Int, 8, ParameterDirection.Input, setofsample);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_TblLineMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Insert_LineTraningFileMaster(long LNo, string TrainingFileName, string TrainingFilePath,int FileType, string LayoutFileName, string LayoutFilePath,string Description) 
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[7];
                myparam[0] = ModHelper.CreateParameter("@LNo", SqlDbType.BigInt, int.MaxValue, ParameterDirection.Input, LNo);
                myparam[1] = ModHelper.CreateParameter("@TraningFileName", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, TrainingFileName);
                myparam[2] = ModHelper.CreateParameter("@TraningFilePath", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, TrainingFilePath);
                myparam[3] = ModHelper.CreateParameter("@FileType", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, FileType);
                myparam[4] = ModHelper.CreateParameter("@LayoutFileName", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, LayoutFileName);
                myparam[5] = ModHelper.CreateParameter("@LayoutFilePath", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, LayoutFilePath);
                myparam[6] = ModHelper.CreateParameter("@Description", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, Description);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_INSERT_TblLineTrainingFileMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete_LineTraningFileMaster(long LNo)
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@LNo", SqlDbType.BigInt, int.MaxValue, ParameterDirection.Input, LNo);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblLineTrainingFileMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update_LineTraningFileMaster(long Id, long LNo, string TrainingFileName, string TrainingFilePath)
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@Id", SqlDbType.BigInt, int.MaxValue, ParameterDirection.Input, Id);
                myparam[1] = ModHelper.CreateParameter("@LNo", SqlDbType.BigInt, int.MaxValue, ParameterDirection.Input, LNo);
                myparam[2] = ModHelper.CreateParameter("@TraningFileName", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, TrainingFileName);
                myparam[3] = ModHelper.CreateParameter("@TraningFilePath", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, TrainingFilePath);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_TblLineTrainingFileMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete_LineMaster()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@LineNo", SqlDbType.BigInt, 8, ParameterDirection.Input, lno);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_TblLineMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public DataSet Select_All_Record_tblLineMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "SP_Select_All_tblLineMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public bool Select_IsScoopApp_ByLineDesc()
        {
            try
            {
                bool B;
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@LineDesc", SqlDbType.NVarChar, 250, ParameterDirection.Input, linename);
                B = (bool)SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "Select_IsScoopLineMaster_ByLineDesc");
                return B;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_ScoopApplLineMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_ScoopApptblLineMaster");
                return ds;
            }
            catch
            {
                throw;
            }

        }

        public DataSet Select_Manufacturer()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblManufacturedBy");
                return ds;
            }
            catch
            {
                throw;
            }
        }

        public DataSet Select_LayoutLineTrainingFiles(long lineid)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@LNo", SqlDbType.BigInt, 8, ParameterDirection.Input, lineid);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblLineTrainingFileMaster", myparam);
                return ds;
            }
            catch
            {
                throw;
            }
        }

        public bool Insert_LineTrainingFileMaster(LineTraingFile_Class LineTraingFile_Class) 
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[6];
                myparam[0] = ModHelper.CreateParameter("@TraningFileName", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, LineTraingFile_Class.TrainingFileName);
                myparam[1] = ModHelper.CreateParameter("@TraningFilePath", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, LineTraingFile_Class.TrainingFilePath);
                myparam[2] = ModHelper.CreateParameter("@LayoutFileName", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, LineTraingFile_Class.LayoutFileName);
                myparam[3] = ModHelper.CreateParameter("@LayoutFilePath", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, LineTraingFile_Class.LayoutFilePath);
                myparam[4] = ModHelper.CreateParameter("@Description", SqlDbType.NVarChar, int.MaxValue, ParameterDirection.Input, LineTraingFile_Class.Description);
                myparam[5] = ModHelper.CreateParameter("@FileType", SqlDbType.Int, int.MaxValue, ParameterDirection.Input, LineTraingFile_Class.FileType);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_INSERTBeforeLineNoInsert_tblLineTrainingFileMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_tblLineMaster_ByLNo(long lineid)
        {
            try
            {
                DataTable Dt = new DataTable();
                SqlParameter[] myaparam = new SqlParameter[1];
                myaparam[0] = ModHelper.CreateParameter("@LNo", SqlDbType.BigInt, 8, ParameterDirection.Input, lineid);
                Dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblLineMaster_ByLNo", myaparam).Tables[0];
                return Dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

    public class LineTraingFile_Class
    {
        public long Id;
        public int FileType ;
        public string TrainingFileName ;
        public string TrainingFilePath ;
        public string LayoutFileName ;
        public string LayoutFilePath ;
        public string Description ;
    }
}
