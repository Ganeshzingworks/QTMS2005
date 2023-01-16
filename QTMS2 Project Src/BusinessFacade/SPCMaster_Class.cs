using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using DataFacade;
using System.Data;

namespace BusinessFacade
{
    /// <summary>
    /// Create By - Avinash S
    /// Created On - 18-Feb-2020
    /// Description - 
    /// </summary>
    public class SPCMaster_Class
    {
        #region Varibles Decleration
        private long SPCID;
        private long LNo;
        private long FGNo;
        private long FNo;
        private string AverageUSL;
        private string AverageUCL;
        private string AverageUpperTOL;
        private string AverageLSL;
        private string AverageLCL;
        private string AverageLowerTOL;
        private string AverageTarget;
        private string DispersionTarget;
        private string DispersionUSL;
        private int Active;
        private long CreatedBy;
        private long ModifiedBy;
        private int GroupNo;
        #endregion
        #region Properties
        public long spcid
        {
            get { return SPCID; }
            set { SPCID = value; }
        }
        public long lno
        {
            get { return LNo; }
            set { LNo = value; }
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
        public string averageUSL
        {
            get { return AverageUSL; }
            set { AverageUSL = value; }
        }
        public string averageUCL
        {
            get { return AverageUCL; }
            set { AverageUCL = value; }
        }
        public string averageUpperTOL
        {
            get { return AverageUpperTOL; }
            set { AverageUpperTOL = value; }
        }
        public string averageLSL
        {
            get { return AverageLSL; }
            set { AverageLSL = value; }
        }
        public string averageLCL
        {
            get { return AverageLCL; }
            set { AverageLCL = value; }
        }
        public string averageLowerTOL
        {
            get { return AverageLowerTOL; }
            set { AverageLowerTOL = value; }
        }
        public string averageTarget
        {
            get { return AverageTarget; }
            set { AverageTarget = value; }
        }
        public string dispersionTarget
        {
            get { return DispersionTarget; }
            set { DispersionTarget = value; }
        }
        public string dispersionUSL
        {
            get { return DispersionUSL; }
            set { DispersionUSL = value; }
        }
        public int active
        {
            get { return Active; }
            set { Active = value; }
        }
        public long createdBy
        {
            get { return CreatedBy; }
            set { CreatedBy = value; }
        }
        public long modifiedBy
        {
            get { return ModifiedBy; }
            set { ModifiedBy = value; }
        }
        public int groupno
        {
            get { return GroupNo; }
            set { GroupNo = value; }
        }
        
        #endregion
        # region Functions
        public bool Insert_tblMettlerSPCMaster()
        {
            try
            {
                SqlParameter[] myaparam = new SqlParameter[15];
                myaparam[0] = ModHelper.CreateParameter("@LNo", SqlDbType.BigInt, 8, ParameterDirection.Input, lno);
                myaparam[1] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                myaparam[2] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myaparam[3] = ModHelper.CreateParameter("@AverageUSL", SqlDbType.VarChar, 50, ParameterDirection.Input, averageUSL);
                myaparam[4] = ModHelper.CreateParameter("@AverageUCL", SqlDbType.VarChar, 50, ParameterDirection.Input, averageUCL);
                myaparam[5] = ModHelper.CreateParameter("@AverageUpperTOL", SqlDbType.VarChar, 50, ParameterDirection.Input, averageUpperTOL);
                myaparam[6] = ModHelper.CreateParameter("@AverageLSL", SqlDbType.VarChar, 50, ParameterDirection.Input, averageLSL);
                myaparam[7] = ModHelper.CreateParameter("@AverageLCL", SqlDbType.VarChar, 50, ParameterDirection.Input, averageLCL);
                myaparam[8] = ModHelper.CreateParameter("@AverageLowerTOL", SqlDbType.VarChar, 50, ParameterDirection.Input, averageLowerTOL);
                myaparam[9] = ModHelper.CreateParameter("@AverageTarget", SqlDbType.VarChar, 50, ParameterDirection.Input, averageTarget);
                myaparam[10] = ModHelper.CreateParameter("@DispersionTarget", SqlDbType.VarChar, 50, ParameterDirection.Input, dispersionTarget);
                myaparam[11] = ModHelper.CreateParameter("@DispersionUSL", SqlDbType.VarChar, 50, ParameterDirection.Input, dispersionUSL);
                myaparam[12] = ModHelper.CreateParameter("@Active", SqlDbType.Int, 4, ParameterDirection.Input, 1);
                myaparam[13] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, createdBy);
                myaparam[14] = ModHelper.CreateParameter("@GroupNo", SqlDbType.Int, 4, ParameterDirection.Input, groupno);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblMettlerSPCMaster", myaparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update_tblMettlerSPCMaster()
        {
            try
            {
                SqlParameter[] myaparam = new SqlParameter[15];
                myaparam[0] = ModHelper.CreateParameter("@LNo", SqlDbType.BigInt, 8, ParameterDirection.Input, lno);
                myaparam[1] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                myaparam[2] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myaparam[3] = ModHelper.CreateParameter("@AverageUSL", SqlDbType.VarChar, 50, ParameterDirection.Input, averageUSL);
                myaparam[4] = ModHelper.CreateParameter("@AverageUCL", SqlDbType.VarChar, 50, ParameterDirection.Input, averageUCL);
                myaparam[5] = ModHelper.CreateParameter("@AverageUpperTOL", SqlDbType.VarChar, 50, ParameterDirection.Input, averageUpperTOL);
                myaparam[6] = ModHelper.CreateParameter("@AverageLSL", SqlDbType.VarChar, 50, ParameterDirection.Input, averageLSL);
                myaparam[7] = ModHelper.CreateParameter("@AverageLCL", SqlDbType.VarChar, 50, ParameterDirection.Input, averageLCL);
                myaparam[8] = ModHelper.CreateParameter("@AverageLowerTOL", SqlDbType.VarChar, 50, ParameterDirection.Input, averageLowerTOL);
                myaparam[9] = ModHelper.CreateParameter("@AverageTarget", SqlDbType.VarChar, 50, ParameterDirection.Input, averageTarget);
                myaparam[10] = ModHelper.CreateParameter("@DispersionTarget", SqlDbType.VarChar, 50, ParameterDirection.Input, dispersionTarget);
                myaparam[11] = ModHelper.CreateParameter("@DispersionUSL", SqlDbType.VarChar, 50, ParameterDirection.Input, dispersionUSL);               
                myaparam[12] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, createdBy);
                myaparam[13] = ModHelper.CreateParameter("@SPCID", SqlDbType.BigInt, 8, ParameterDirection.Input, spcid);
                myaparam[14] = ModHelper.CreateParameter("@GroupNo", SqlDbType.Int, 4, ParameterDirection.Input, groupno);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblMettlerSPCMaster", myaparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete_tblMettlerSPCMaster()
        {
            try
            {
                SqlParameter[] myaparam = new SqlParameter[2];
                myaparam[0] = ModHelper.CreateParameter("@SPCID", SqlDbType.BigInt, 8, ParameterDirection.Input, spcid);
                myaparam[1] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.BigInt, 8, ParameterDirection.Input, createdBy);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblMettlerSPCMaster", myaparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Select_tblMettlerSPCMaster()
        {
            try
            {
                DataTable Dt = new DataTable();              
                Dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblMettlerSPCMaster").Tables[0];
                return Dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataTable Select_tblMettlerSPCMaster_ByID()
        {
            try
            {
                DataTable Dt = new DataTable();
                SqlParameter[] myaparam = new SqlParameter[1];
                myaparam[0] = ModHelper.CreateParameter("@SPCID", SqlDbType.BigInt, 8, ParameterDirection.Input, spcid);
                Dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblMettlerSPCMaster_ByID", myaparam).Tables[0];
                return Dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataTable Select_tblMettlerSPCMaster_Exist()
        {
            try
            {
                DataTable Dt = new DataTable();
                SqlParameter[] myaparam = new SqlParameter[3];
                myaparam[0] = ModHelper.CreateParameter("@LNo", SqlDbType.BigInt, 8, ParameterDirection.Input, lno);
                myaparam[1] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                myaparam[2] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                Dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblMettlerSPCMaster_Exist", myaparam).Tables[0];
                return Dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool Update_tblMettlerSPCMaster_Activate()
        {
            try
            {
                SqlParameter[] myaparam = new SqlParameter[3];
                myaparam[0] = ModHelper.CreateParameter("@LNo", SqlDbType.BigInt, 8, ParameterDirection.Input, lno);
                myaparam[1] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                myaparam[2] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);               
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblMettlerSPCMaster_Activate", myaparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Select_tblMettlerSPCMaster_Export()
        {
            try
            {
                DataTable Dt = new DataTable();
                Dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblMettlerSPCMaster_Export").Tables[0];
                return Dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataTable Select_tblMettlerSPCMaster_ByID(long FGTLFID)
        {
            try
            {
                DataTable Dt = new DataTable();
                SqlParameter[] myaparam = new SqlParameter[1];
                myaparam[0] = ModHelper.CreateParameter("@FGTLFID", SqlDbType.BigInt, 8, ParameterDirection.Input, FGTLFID);
                Dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_FGLIne_tblFGTLF", myaparam).Tables[0];
                return Dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable Select_tblMettlerSPCMaster_ByGroupNo()
        {
            try
            {
                DataTable Dt = new DataTable();
                SqlParameter[] myaparam = new SqlParameter[1];
                myaparam[0] = ModHelper.CreateParameter("@GroupNo", SqlDbType.Int, 4, ParameterDirection.Input, groupno);
                Dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblMettlerSPCMaster_ByGroupNo", myaparam).Tables[0];
                return Dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DataTable Select_tblMettlerSPCMaster_GroupNo()
        {
            try
            {
                DataTable Dt = new DataTable();
                Dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblMettlerSPCMaster_GroupNo").Tables[0];
                return Dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        # endregion
    }
}
