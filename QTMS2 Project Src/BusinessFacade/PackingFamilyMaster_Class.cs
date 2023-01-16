using System.Data;
using System.Data.SqlClient;
using DataFacade;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessFacade
{
    public class PackingFamilyMaster_Class
    {
        #region Varibles
        private long PkgTechNo;
        private string TechFamDesc;
        private string Type;
        private string VersionNo;
        private long FGNO;
        private long FMID;
        #endregion
        # region Properties
        public long pkgtechno
        {
            get { return PkgTechNo; }
            set { PkgTechNo = value; }
        }
        public long fmid
        {
            get { return FMID; }
            set { FMID = value; }
        }
        public long fgno
        {
            get { return FGNO; }
            set { FGNO = value; }
        }
        public string techfamdesc
        {
            get { return TechFamDesc; }
            set { TechFamDesc = value; }
        }
        public string type
        {
            get { return Type; }
            set { Type = value; }
        }
        public string versionno
        {
            get { return VersionNo; }
            set { VersionNo = value; }
        }
        #endregion
        #region Functions
        public DataSet Select_tblPkgFamilyMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblPkgFamilyMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataSet Select_tblPkgFamilyMaster_By_TechFamNo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@PkgTechNo", SqlDbType.BigInt, 8, ParameterDirection.Input, pkgtechno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblPkgFamilyMaster_PkgTechNo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet STP_SELECT_FGNo_FMID_PkgSamp()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                //myparam[0] = ModHelper.CreateParameter("@FMID", SqlDbType.BigInt, 8, ParameterDirection.Input, fmid);
                myparam[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_FGNo_FMID_PkgSamp",myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete_tblPkgFamilyMaster()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@PkgTechNo", SqlDbType.BigInt, 8, ParameterDirection.Input, pkgtechno);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_DELETE_tblPkgFamilyMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Insert_tblPkgFamilyMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@TechFamDesc", SqlDbType.NVarChar, 250, ParameterDirection.Input, techfamdesc);
                myparam[1] = ModHelper.CreateParameter("@pktype", SqlDbType.NVarChar, 250, ParameterDirection.Input, type);
                myparam[2] = ModHelper.CreateParameter("@VersionNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, versionno);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_INSERT_tblPkgFamilyMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update_tblPkgFamilyMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[4];
                myparam[0] = ModHelper.CreateParameter("@PkgTechNo", SqlDbType.BigInt, 8, ParameterDirection.Input, pkgtechno);
                myparam[1] = ModHelper.CreateParameter("@TechFamDesc", SqlDbType.NVarChar, 250, ParameterDirection.Input, techfamdesc);
                myparam[2] = ModHelper.CreateParameter("@pktype", SqlDbType.NVarChar, 250, ParameterDirection.Input, type);
                myparam[3] = ModHelper.CreateParameter("@VersionNo", SqlDbType.NVarChar, 50, ParameterDirection.Input, versionno);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_UPDATE_tblPkgFamilyMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public DataSet Select_All_Record_tblPkgFamilyMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "SP_Select_All_tblPkgFamilyMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
