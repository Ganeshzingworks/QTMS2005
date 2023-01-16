using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;
namespace BusinessFacade
{
    public class TankMaster_Class
    {
        # region Varibles

        private long ID;
        private long TankNo;
        private string TankName;
        private long FGNo;
        private long FNo;
        private string FormulaNo;
        private string BarcodeValue;
        # endregion
        # region Properties
        public long id
        {
            get { return ID; }
            set { ID = value; }
        }
        public long tankno
        {
            get { return TankNo; }
            set { TankNo = value; }
        }
        public string tankname
        {
            get { return TankName; }
            set { TankName = value; }
        }
        public long fgno
        {
            get { return FGNo; }
            set { FGNo = value; }
        }
        public long fno
        {
            get { return FNo; }
            set { FNo = value; }
        }
        public string formulano
        {
            get { return FormulaNo; }
            set { FormulaNo = value; }
        }
        public string barcodevalue
        {
            get { return BarcodeValue; }
            set { BarcodeValue = value; }
        }

        private int LNo;
        public int lno
        {
            get { return LNo; }
            set { LNo = value; }
        }
        private string TrackCode;
        public string trackcode
        {
            get { return TrackCode; }
            set { TrackCode = value; }  
        }
        private string PkgWo;
        public string pkgwo
        {
            get { return PkgWo; }
            set { PkgWo = value; }
        }
        private string LotNo;
        public string lotno
        {
            get { return LotNo; }
            set { LotNo = value; }
        }
        private string BatchCode;
        public string batchcode
        {
            get { return BatchCode; }
            set { BatchCode = value; }
        }
        private string MfgWo;
        public string mfgwo
        {
            get { return MfgWo; }
            set { MfgWo = value; }
        }
        private long CreatedBy;
        public long createdby
        {
            get { return CreatedBy; }
            set { CreatedBy = value; }
        }

        private string Sampling;
        public string sampling
        {
            get { return Sampling; }
            set { Sampling = value; }
        }
        private string SamplingDetails;
        public string samplingdetails
        {
            get { return SamplingDetails; }
            set { SamplingDetails = value; }
        }
        private string SamplingTime;
        public string samplingtime
        {
            get { return SamplingTime; }
            set { SamplingTime = value; }
        }
        private string MRP;
        public string mrp
        {
            get { return MRP; }
            set { MRP = value; }
        }
        private string Details;
        public string details
        {
            get { return Details; }
            set { Details = value; }
        }

        # endregion
        # region Functions
        public DataSet Select_TankMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_TblTankMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Insert_TankMaster()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@TankName", SqlDbType.NVarChar, 250, ParameterDirection.Input, tankname);
                myparam[1] = ModHelper.CreateParameter("@BarcodeValue", SqlDbType.VarChar, 100, ParameterDirection.Input, barcodevalue);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_TblTankMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update_TankMaster()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@TankNo", SqlDbType.BigInt, 8, ParameterDirection.Input, TankNo);
                myparam[1] = ModHelper.CreateParameter("@TankName", SqlDbType.NVarChar, 250, ParameterDirection.Input, TankName);
                myparam[2] = ModHelper.CreateParameter("@BarcodeValue", SqlDbType.VarChar, 100, ParameterDirection.Input, barcodevalue);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_TblTankMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete_TankMaster()
        {
            try
            {

                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@TankNo", SqlDbType.BigInt, 8, ParameterDirection.Input, TankNo);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_TblTankMaster", myparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        # endregion

        public DataSet Select_All_Record_tblTankMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "SP_Select_All_tblTankMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet FG_Formula_Exist()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                myparam[1] = ModHelper.CreateParameter("@FormulaNo", SqlDbType.VarChar, 50, ParameterDirection.Input, formulano);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_FG_Formula_Exist",myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_Tank_By_TankNo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@TankNo", SqlDbType.BigInt, 8, ParameterDirection.Input, TankNo);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "SP_Select_Tank_By_TankNo",myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_Tank_By_BarcodeValue()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@BarcodeValue", SqlDbType.VarChar, 100, ParameterDirection.Input, barcodevalue);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "SP_Select_Tank_By_BarcodeValue", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Insert_TankSelection()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[16];
                myparam[0] = ModHelper.CreateParameter("@LNo", SqlDbType.Int, 4, ParameterDirection.Input, lno);
                myparam[1] = ModHelper.CreateParameter("@FgNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                myparam[2] = ModHelper.CreateParameter("@TrackCode", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, trackcode);
                myparam[3] = ModHelper.CreateParameter("@PkgWo", SqlDbType.VarChar, 50, ParameterDirection.Input, pkgwo);
                myparam[4] = ModHelper.CreateParameter("@LotNo", SqlDbType.VarChar, 50, ParameterDirection.Input, lotno);
                myparam[5] = ModHelper.CreateParameter("@BatchCode", SqlDbType.VarChar, 50, ParameterDirection.Input, batchcode);
                myparam[6] = ModHelper.CreateParameter("@MfgWo", SqlDbType.VarChar, 50, ParameterDirection.Input, mfgwo);
                myparam[7] = ModHelper.CreateParameter("@Fno", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[8] = ModHelper.CreateParameter("@TankNo", SqlDbType.Int, 4, ParameterDirection.Input, tankno);
                myparam[9] = ModHelper.CreateParameter("@Active", SqlDbType.Int, 4, ParameterDirection.Input, 1);
                myparam[10] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, createdby);
                myparam[11] = ModHelper.CreateParameter("@Sampling", SqlDbType.VarChar, 50, ParameterDirection.Input, sampling);
                myparam[12] = ModHelper.CreateParameter("@SamplingDetails", SqlDbType.VarChar, 50, ParameterDirection.Input, samplingdetails);
                myparam[13] = ModHelper.CreateParameter("@SamplingTime", SqlDbType.VarChar, 50, ParameterDirection.Input, samplingtime);
                myparam[14] = ModHelper.CreateParameter("@MRP", SqlDbType.VarChar, 50, ParameterDirection.Input, mrp);
                myparam[15] = ModHelper.CreateParameter("@ID", SqlDbType.BigInt, 8, ParameterDirection.Output, id);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblTankSelection", myparam);

                return Convert.ToInt32(myparam[15].Value);  

                //return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_Tank_LabelPrint()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@ID", SqlDbType.BigInt, 8, ParameterDirection.Input, id);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Tank_LabalPrint", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_tblTankSelection()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblTankSelection");
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_tblTankSelection_ByID()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@ID", SqlDbType.BigInt, 8, ParameterDirection.Input, id);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblTankSelection_ByID", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable GetTank_ByTransaction()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@Fno", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[1] = ModHelper.CreateParameter("@TankNo", SqlDbType.BigInt, 8, ParameterDirection.Input, TankNo);
                myparam[2] = ModHelper.CreateParameter("@MfgWo", SqlDbType.VarChar, 150, ParameterDirection.Input, mfgwo);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_GetTank_ByTransaction", myparam);
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetTankDetails_ByTankSelection()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@Fno", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myparam[1] = ModHelper.CreateParameter("@MfgWo", SqlDbType.VarChar, 50, ParameterDirection.Input, mfgwo);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_GetTankDetails_ByTankSelection", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet GetDetails_TankSelection()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_GetDetails_TankSelection");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Select_TankDetails()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@Details", SqlDbType.VarChar, 400, ParameterDirection.Input, details);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_TankDetails", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
