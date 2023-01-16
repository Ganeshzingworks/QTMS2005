using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;
namespace BusinessFacade
{
    public class LineOEEFGMaster_Class
    {
        # region Varibles
        private string FGCode;
        private long FormulaNo;
        private string FGDesc;
        private string FillVolume;
        private int PKGTechNo;
        private long FGGlobalFamilyID;
        private long Result;
        private long FGNo;
        private long SubFGNo;
        private int FNo;
        private int SF;
        private int Kit;
        private int WIP;
        private int FGMicro;
        # endregion
        # region Properties
        public long fgno
        {
            get { return FGNo; }
            set { FGNo = value; }
        }
        public long subfgno
        {
            get { return SubFGNo; }
            set { SubFGNo = value; }
        }
        public long result
        {
            get { return Result; }
            set { Result = value; }
        }
        public string fgcode
        {
            get { return FGCode; }
            set { FGCode = value; }
        }
        public int pkgtechno
        {
            get { return PKGTechNo; }
            set { PKGTechNo = value; }
        }
        public long fgglobalfamilyid
        {
            get { return FGGlobalFamilyID; }
            set { FGGlobalFamilyID = value; }
        }
        public string fgdesc
        {
            get { return FGDesc; }
            set { FGDesc = value; }
        }
        public string fillvolume
        {
            get { return FillVolume; }
            set { FillVolume = value; }
        }
        public long formulano
        {
            get { return FormulaNo; }
            set { FormulaNo = value; }
        }
        public int fno
        {
            get { return FNo; }
            set { FNo = value; }
        }
        public int sf
        {
            get { return SF; }
            set { SF = value; }
        }
        public int kit
        {
            get { return Kit; }
            set { Kit = value; }
        }
        public int wip
        {
            get { return WIP; }
            set { WIP = value; }
        }
        public int fgmicro
        {
            get { return FGMicro; }
            set { FGMicro = value; }
        }
        # endregion
        # region Functions
        public DataSet Select_From_tblLineOEEFGMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblLineOEEFGMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        public DataTable Select_From_tblLineOEEFGMaster_SF(Int16 SF)
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@SF", SqlDbType.TinyInt, 2, ParameterDirection.Input, SF);
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblLineOEEFGMaster_SF", myparam).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet Select_From_tblLineOEEFGMaster_By_FGCode()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FGCode", SqlDbType.NVarChar, 200, ParameterDirection.Input, fgcode);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblLineOEEFGMaster_FgCode", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet STP_SELECT_tblLineOEEFGMaster_FGNo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.NVarChar, 200, ParameterDirection.Input, fgno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblLineOEEFGMaster_FGNo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SELECT_tblLineOEEFGMaster_FormulaNo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FgNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblLineOEEFGMaster_FormulaNo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SELECT_tblLineOEEFGMaster_SubSF()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FgNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblLineOEEFGMaster_SubSF", myparam).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert_tblFGLinkSF()
        {
            try
            {
                SqlParameter[] myaparam = new SqlParameter[2];
                myaparam[0] = ModHelper.CreateParameter("@SFFGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                myaparam[1] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, subfgno);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblFGLinkSF", myaparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Insert_tblFG_FormulaMaster()
        {
            try
            {
                SqlParameter[] myaparam = new SqlParameter[3];
                myaparam[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                myaparam[1] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fno);
                myaparam[2] = ModHelper.CreateParameter("@FGMicro", SqlDbType.TinyInt, 1, ParameterDirection.Input, fgmicro);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblFG_FormulaMaster", myaparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public long Insert_tblLineOEEFGMaster()
        {
            try
            {
                SqlParameter[] myaparam = new SqlParameter[8];
                myaparam[0] = ModHelper.CreateParameter("@FGCode", SqlDbType.NVarChar, 200, ParameterDirection.Input, fgcode);
                myaparam[1] = ModHelper.CreateParameter("@PKGTechNo", SqlDbType.Int, 4, ParameterDirection.Input, pkgtechno);
                //myaparam[2] = ModHelper.CreateParameter("@FGGlobalFamilyID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgglobalfamilyid);
                myaparam[2] = ModHelper.CreateParameter("@FGDesc", SqlDbType.NVarChar, 250, ParameterDirection.Input, fgdesc);
                myaparam[3] = ModHelper.CreateParameter("@FillVolume", SqlDbType.NVarChar, 100, ParameterDirection.Input, fillvolume);
                myaparam[4] = ModHelper.CreateParameter("@Kit", SqlDbType.TinyInt, 1, ParameterDirection.Input, kit);
                myaparam[5] = ModHelper.CreateParameter("@WIP", SqlDbType.TinyInt, 1, ParameterDirection.Input, wip);
                myaparam[6] = ModHelper.CreateParameter("@SF", SqlDbType.TinyInt, 1, ParameterDirection.Input, sf);
                myaparam[7] = ModHelper.CreateParameter("@Result", SqlDbType.BigInt, 8, ParameterDirection.Output);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_INSERT_tblLineOEEFGMaster", myaparam);
                result = Convert.ToInt64(myaparam[7].Value);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update_tblLineOEEFGMaster()
        {
            try
            {
                SqlParameter[] myaparam = new SqlParameter[7];
                myaparam[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                myaparam[1] = ModHelper.CreateParameter("@FGCode", SqlDbType.NVarChar, 200, ParameterDirection.Input, fgcode);
                myaparam[2] = ModHelper.CreateParameter("@PKGTechNo", SqlDbType.Int, 4, ParameterDirection.Input, pkgtechno);
                //myaparam[3] = ModHelper.CreateParameter("@FGGlobalFamilyID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgglobalfamilyid);
                myaparam[3] = ModHelper.CreateParameter("@FGDesc", SqlDbType.NVarChar, 250, ParameterDirection.Input, fgdesc);
                myaparam[4] = ModHelper.CreateParameter("@FillVolume", SqlDbType.NVarChar, 100, ParameterDirection.Input, fillvolume);
                myaparam[5] = ModHelper.CreateParameter("@Kit", SqlDbType.TinyInt, 1, ParameterDirection.Input, kit);
                myaparam[6] = ModHelper.CreateParameter("@SF", SqlDbType.TinyInt, 1, ParameterDirection.Input, sf);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblLineOEEFGMaster", myaparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete_tblLineOEEFGMaster()
        {
            try
            {
                SqlParameter[] myaparam = new SqlParameter[1];
                myaparam[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblLineOEEFGMaster_FormulaNo", myaparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete_tblLineOEEFGMaster_FormulaNo()
        {
            try
            {
                SqlParameter[] myaparam = new SqlParameter[1];
                myaparam[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblLineOEEFGMaster_FormulaNo", myaparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete_tblFGLinkSF()
        {
            try
            {
                SqlParameter[] myaparam = new SqlParameter[1];
                myaparam[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblFGLinkSF", myaparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }




        public DataTable STP_SELECT_tblFGCodeFamilyTestRelation_FGNo()
        {
            try
            {
                DataTable dt = new DataTable();
                // DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.NVarChar, 200, ParameterDirection.Input, fgno);
                // ds = SqlHelper.ExkaireeecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblFGCodeFamilyTestRelation_FGNo", myparam);
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblFGCodeFamilyTestRelation_FGNo", myparam).Tables[0];
                // return ds;
                return dt;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        # endregion


        #region View Upload Line OEE Master

        private long UploadMasterID;

        public long uploadMasterID
        {
            get { return UploadMasterID; }
            set { UploadMasterID = value; }
        }

        private string Family;

        public string family
        {
            get { return Family; }
            set { Family = value; }
        }

        private string Years;

        public string years
        {
            get { return Years; }
            set { Years = value; }
        }

        private string MOD;

        public string mod
        {
            get { return MOD; }
            set { MOD = value; }
        }

        private string UST;

        public string ust
        {
            get { return UST; }
            set { UST = value; }
        }

        private string ProductDesc;

        public string productDesc
        {
            get { return ProductDesc; }
            set { ProductDesc = value; }
        }

        private string LineSpeed;

        public string lineSpeed
        {
            get { return LineSpeed; }
            set { LineSpeed = value; }
        }

        private string LineNos;

        public string lineNos
        {
            get { return LineNos; }
            set { LineNos = value; }
        }


        public DataTable Select_LineOEEUploadMaster_FGCode()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@FGCODE", SqlDbType.VarChar, 200, ParameterDirection.Input, fgcode);
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblLineOEEUploadMaster_FGCODE",param).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public DataTable Select_LineOEEUploadMaster()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblLineOEEUploadMaster").Tables[0];
                return dt;
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }

        public bool Update_LineOEEUploadMaster_UploadMasterID()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[9];
                param[0] = ModHelper.CreateParameter("@UploadMasterID", SqlDbType.BigInt, 8, ParameterDirection.Input, uploadMasterID);
                param[1] = ModHelper.CreateParameter("@FGCODE", SqlDbType.VarChar, 200, ParameterDirection.Input, fgcode);
                param[2] = ModHelper.CreateParameter("@FAMILY", SqlDbType.VarChar, 1000, ParameterDirection.Input, family);
                param[3] = ModHelper.CreateParameter("@YEARS", SqlDbType.VarChar, 20, ParameterDirection.Input, years);
                param[4] = ModHelper.CreateParameter("@MOD", SqlDbType.VarChar, 5, ParameterDirection.Input, mod);
                param[5] = ModHelper.CreateParameter("@UST", SqlDbType.VarChar, 10, ParameterDirection.Input, ust);
                param[6] = ModHelper.CreateParameter("@PRODUCTDESCRIPTION", SqlDbType.VarChar, 1000, ParameterDirection.Input, productDesc);
                param[7] = ModHelper.CreateParameter("@LINESPEED", SqlDbType.VarChar, 10, ParameterDirection.Input, lineSpeed);
                param[8] = ModHelper.CreateParameter("@LINENOS", SqlDbType.VarChar, 5, ParameterDirection.Input, lineNos);
                int i = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblLineOEEUploadMaster_UploadMasterID", param);
                if (i > 0)
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
