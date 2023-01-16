using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;
namespace BusinessFacade
{
    public class FinishedGoodMaster_Class  
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
        private int CreatedBy;
        private string Type;
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
        public int createdby
        {
            get { return CreatedBy; }
            set { CreatedBy = value; }
        }
        public string type
        {
            get { return Type; }
            set { Type = value; }
        }
        # endregion
        # region Functions
        public DataSet Select_From_tblFGMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblFgMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;

            }

        }

        public DataTable Select_From_tblFGMaster_SF(Int16 SF)
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@SF", SqlDbType.TinyInt,2, ParameterDirection.Input,SF);                
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblFgMaster_SF",myparam).Tables[0];                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public DataSet Select_From_tblFGMaster_By_FGCode()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FGCode", SqlDbType.NVarChar, 200, ParameterDirection.Input, fgcode);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblFgMaster_FgCode", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet STP_SELECT_tblFgMaster_FGNo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.NVarChar, 200, ParameterDirection.Input, fgno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblFgMaster_FGNo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet SELECT_tblFgMaster_FormulaNo()
        {
            try
            {
                DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FgNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblFgMaster_FormulaNo", myparam);
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable SELECT_tblFgMaster_SubSF()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FgNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblFgMaster_SubSF", myparam).Tables[0];
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
                myaparam[0] = ModHelper.CreateParameter("@SFFGNo", SqlDbType.BigInt,8, ParameterDirection.Input, fgno);
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
                SqlParameter[] myaparam = new SqlParameter[4];
                myaparam[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt,8, ParameterDirection.Input, fgno);
                myaparam[1] = ModHelper.CreateParameter("@FNo", SqlDbType.BigInt,8, ParameterDirection.Input,fno);
                myaparam[2] = ModHelper.CreateParameter("@FGMicro", SqlDbType.TinyInt, 1, ParameterDirection.Input, fgmicro);
                myaparam[3] = ModHelper.CreateParameter("@Type", SqlDbType.VarChar, 50, ParameterDirection.Input, type);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblFG_FormulaMaster", myaparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Insert_tblFGMaster()
        {
            try
            {
                SqlParameter[] myaparam = new SqlParameter[10];
                myaparam[0] = ModHelper.CreateParameter("@FGCode", SqlDbType.NVarChar,200, ParameterDirection.Input, fgcode);
                myaparam[1] = ModHelper.CreateParameter("@PKGTechNo", SqlDbType.Int,4, ParameterDirection.Input, pkgtechno);
                myaparam[2] = ModHelper.CreateParameter("@FGGlobalFamilyID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgglobalfamilyid);
                myaparam[3] = ModHelper.CreateParameter("@FGDesc", SqlDbType.NVarChar, 250, ParameterDirection.Input, fgdesc);
                myaparam[4] = ModHelper.CreateParameter("@FillVolume", SqlDbType.NVarChar, 100, ParameterDirection.Input, fillvolume);
                myaparam[5] = ModHelper.CreateParameter("@Kit", SqlDbType.TinyInt, 1, ParameterDirection.Input, kit);
                myaparam[6] = ModHelper.CreateParameter("@WIP", SqlDbType.TinyInt, 1, ParameterDirection.Input, wip);
                myaparam[7] = ModHelper.CreateParameter("@SF", SqlDbType.TinyInt, 1, ParameterDirection.Input,sf);
                myaparam[8] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, createdby);
                myaparam[9] = ModHelper.CreateParameter("@Result", SqlDbType.BigInt,8, ParameterDirection.Output);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_INSERT_tblFGMaster", myaparam);
                result = Convert.ToInt64(myaparam[9].Value);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Update_tblFGMaster()
        {
            try
            {
                SqlParameter[] myaparam = new SqlParameter[9];
                myaparam[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt,8, ParameterDirection.Input, fgno);
                myaparam[1] = ModHelper.CreateParameter("@FGCode", SqlDbType.NVarChar, 200, ParameterDirection.Input, fgcode);
                myaparam[2] = ModHelper.CreateParameter("@PKGTechNo", SqlDbType.Int, 4, ParameterDirection.Input, pkgtechno);
                myaparam[3] = ModHelper.CreateParameter("@FGGlobalFamilyID", SqlDbType.BigInt, 8, ParameterDirection.Input, fgglobalfamilyid);
                myaparam[4] = ModHelper.CreateParameter("@FGDesc", SqlDbType.NVarChar, 250, ParameterDirection.Input, fgdesc);
                myaparam[5] = ModHelper.CreateParameter("@FillVolume", SqlDbType.NVarChar, 100, ParameterDirection.Input, fillvolume);
                myaparam[6] = ModHelper.CreateParameter("@Kit", SqlDbType.TinyInt, 1, ParameterDirection.Input, kit);
                myaparam[7] = ModHelper.CreateParameter("@SF", SqlDbType.TinyInt, 1, ParameterDirection.Input, sf);
                myaparam[8] = ModHelper.CreateParameter("@CreatedBy", SqlDbType.Int, 4, ParameterDirection.Input, createdby);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblFGMaster", myaparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete_tblFGMaster()
        {
            try
            {
                SqlParameter[] myaparam = new SqlParameter[1];
                myaparam[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt,8, ParameterDirection.Input,fgno);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_DELETE_tblFinishedGoodMaster", myaparam);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete_tblFgMaster_FormulaNo()
        {
            try
            {
                SqlParameter[] myaparam = new SqlParameter[1];
                myaparam[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt,8, ParameterDirection.Input, fgno);

                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblFgMaster_FormulaNo", myaparam);
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
//================================ Created By Manish K for Scoop =======================================================================//

        public DataTable STP_SELECT_tblFGCodeFamilyTestRelation_FGNoScoop()
        {
            try
            {
                DataTable dt = new DataTable();
                // DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.NVarChar, 200, ParameterDirection.Input, fgno);
                // ds = SqlHelper.ExkaireeecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblFGCodeFamilyTestRelation_FGNo", myparam);
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblFGCodeFamilyTestRelation_FGNoScoop", myparam).Tables[0];
                // return ds;
                return dt;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



       public  DataTable STP_SELECT_tblFGCodeFamilyTestRelation_FGNoUP()//<------------------------------------------ SELECT FG DETAILS AND TEST METHODS 
        {
            try
            {
                DataTable dt = new DataTable();
                // DataSet ds = new DataSet();
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.NVarChar, 200, ParameterDirection.Input, fgno);
                // ds = SqlHelper.ExkaireeecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblFGCodeFamilyTestRelation_FGNo", myparam);
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblFGCodeFamilyTestRelation_FGNoUP", myparam).Tables[0];
                // return ds;
                return dt;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

//=============================================================================================================================================//
        # endregion


        public DataSet Select_All_Record_tblFGMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "SP_Select_All_tblFGMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
