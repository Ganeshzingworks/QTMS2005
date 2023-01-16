using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataFacade;
using System.Configuration;

namespace BusinessFacade.Transactions
{
    public class LineOEETransaction
    {
        #region Variables & Proprities

        private int ActivityID;

        public int activityID
        {
            get { return ActivityID; }
            set { ActivityID = value; }
        }

        private string actvityname;

        public string activityName
        {
            get { return actvityname; }
            set { actvityname = value; }
        }

        private bool lastactivity;

        public bool lastActivity
        {
            get { return lastactivity; }
            set { lastactivity = value; }
        }

        private DateTime FromTime;

        public DateTime fromTime
        {
            get { return FromTime; }
            set { FromTime = value; }
        }

        private DateTime ToTime;

        public DateTime toTime
        {
            get { return ToTime; }
            set { ToTime = value; }
        }

        private string CommentDesc;

        public string commentDesc
        {
            get { return CommentDesc; }
            set { CommentDesc = value; }
        }
        private long FGNo;

        public long fgno
        {
            get { return FGNo; }
            set { FGNo = value; }
        }

        private string FGDescription;

        public string fgdescription
        {
            get { return FGDescription; }
            set { FGDescription = value; }
        }

        private DateTime Transdate;

        public DateTime transDate
        {
            get { return Transdate; }
            set { Transdate = value; }
        }

        private int ShiftID;

        public int shiftID
        {
            get { return ShiftID; }
            set { ShiftID = value; }
        }

        private int LNO;

        public int lno
        {
            get { return LNO; }
            set { LNO = value; }
        }
        private double LineSpeed;

        public double lineSpeed
        {
            get { return LineSpeed; }
            set { LineSpeed = value; }
        }
        private int MOD;

        public int mod
        {
            get { return MOD; }
            set { MOD = value; }
        }
        private long DetailID;

        public long detailID
        {
            get { return DetailID; }
            set { DetailID = value; }
        }
        private int COLFROMNUMBER;

        public int colFromNumber
        {
            get { return COLFROMNUMBER; }
            set { COLFROMNUMBER = value; }
        }
        private int COLTONUMBER;

        public int colToNumber
        {
            get { return COLTONUMBER; }
            set { COLTONUMBER = value; }
        }

        private long formno;

        public long formNumber
        {
            get { return formno; }
            set { formno = value; }
        }
        private string PhysicalFormNumber;

        public string physicalFormNumber
        {
            get { return PhysicalFormNumber; }
            set { PhysicalFormNumber = value; }
        }

        private double producedunit;

        public double producedUnits
        {
            get { return producedunit; }
            set { producedunit = value; }
        }

        private int LineOEECategoryID;

        public int lineoeecategoryid
        {
            get { return LineOEECategoryID; }
            set { LineOEECategoryID = value; }
        }

        private string StartDate;

        public string startdate
        {
            get { return StartDate; }
            set { StartDate = value; }
        }
        private string EndDate;

        public string enddate
        {
            get { return EndDate; }
            set { EndDate = value; }
        }


        private double messtdtime;

        public double MESSTDTIME
        {
            get { return messtdtime; }
            set { messtdtime = value; }
        }

        private string flag;

        public string FLAG
        {
            get { return flag; }
            set { flag = value; }
        }

        private long machineid;

        public long MaschineID
        {
            get { return machineid; }
            set { machineid = value; }
        }
        private string operatorname;

        public string OperatorName
        {
            get { return operatorname; }
            set { operatorname = value; }
        }

        private int CategotyID;

        public int categotyId
        {
            get { return CategotyID; }
            set { CategotyID = value; }
        }

        private long LineHrsID;

        public long lineHrsId
        {
            get { return LineHrsID; }
            set { LineHrsID = value; }
        }
	
	

        #endregion

        #region Line OEE Upload Master Properties
        private string FGCODE;

        public string fgCode
        {
            get { return FGCODE; }
            set { FGCODE = value; }
        }

        private string FAMILY;

        public string family
        {
            get { return FAMILY; }
            set { FAMILY = value; }
        }
        private string YEAR;

        public string year
        {
            get { return YEAR; }
            set { YEAR = value; }
        }

        private string MODUpload;

        public string modUpload
        {
            get { return MODUpload; }
            set { MODUpload = value; }
        }

        private string UST;

        public string ust
        {
            get { return UST; }
            set { UST = value; }
        }
        private string PRODUCTDESCRIPTION;

        public string productDescription
        {
            get { return PRODUCTDESCRIPTION; }
            set { PRODUCTDESCRIPTION = value; }
        }
        private string LINESPEEDUpload;

        public string lineSpeedUpload
        {
            get { return LINESPEEDUpload; }
            set { LINESPEEDUpload = value; }
        }


        private string LINENO;

        public string lineNo
        {
            get { return LINENO; }
            set { LINENO = value; }
        }

        #endregion

        #region Functions

        public DataTable SelectLineOEEActivityMaster()
        {
            try
            {
                DataTable dt = new DataTable();
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblLineOEEActivityMaster").Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public long Insert_LineOEEDetails()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[11];
                param[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.Int, 4, ParameterDirection.Input, fgno);
                param[1] = ModHelper.CreateParameter("@LNo", SqlDbType.Int, 4, ParameterDirection.Input, lno);
                param[2] = ModHelper.CreateParameter("@ShiftID", SqlDbType.Int, 4, ParameterDirection.Input, shiftID);
                param[3] = ModHelper.CreateParameter("@STDMOD", SqlDbType.Int, 4, ParameterDirection.Input, mod);
                param[4] = ModHelper.CreateParameter("@TransDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, transDate);
                param[5] = ModHelper.CreateParameter("@LineSpeed", SqlDbType.Float, 4, ParameterDirection.Input, lineSpeed);
                param[6] = ModHelper.CreateParameter("@DetailID", SqlDbType.BigInt, 8, ParameterDirection.Output, detailID);
                param[7] = ModHelper.CreateParameter("@FormNumber", SqlDbType.BigInt, 8, ParameterDirection.Input, formNumber);
                param[8] = ModHelper.CreateParameter("@ProducedUnit", SqlDbType.Float, 8, ParameterDirection.Input, producedUnits);
                param[9] = ModHelper.CreateParameter("@PhysicalFormNumber", SqlDbType.VarChar, 25, ParameterDirection.Input, physicalFormNumber);
                param[10] = ModHelper.CreateParameter("@OperatorNme", SqlDbType.VarChar, 150, ParameterDirection.Input, operatorname);
                //sparam[11] = ModHelper.CreateParameter("@MachineID", SqlDbType.BigInt, 8, ParameterDirection.Input, machineid);

                return Convert.ToInt64(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_Insert_tblLineOEEDetails", param));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update_LineOEEDeatails_LineSpeed_ProducedUnit()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = ModHelper.CreateParameter("@DetailID", SqlDbType.BigInt, 8, ParameterDirection.Input, detailID);
                param[1] = ModHelper.CreateParameter("@ProducedUnit", SqlDbType.Float, 4, ParameterDirection.Input, producedUnits);
                param[2] = ModHelper.CreateParameter("@LineSpeed", SqlDbType.Float, 4, ParameterDirection.Input, lineSpeed);
                param[3] = ModHelper.CreateParameter("@PhysicalFormNumber", SqlDbType.VarChar, 25, ParameterDirection.Input, physicalFormNumber);
                param[4] = ModHelper.CreateParameter("@OperatotName", SqlDbType.VarChar, 150, ParameterDirection.Input, operatorname);
                //param[5] = ModHelper.CreateParameter("@MachineID", SqlDbType.BigInt, 8, ParameterDirection.Input, machineid);

                int i = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblLineOEEDetails_LineSpeed_ProducedUnit", param);
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

        public bool Insert_LineOEEComment()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[11];
                param[0] = ModHelper.CreateParameter("@LineActivityID", SqlDbType.Int, 4, ParameterDirection.Input, activityID);
                param[1] = ModHelper.CreateParameter("@FromTime", SqlDbType.DateTime, 8, ParameterDirection.Input, fromTime);
                param[2] = ModHelper.CreateParameter("@ToTime", SqlDbType.DateTime, 8, ParameterDirection.Input, toTime);
                param[3] = ModHelper.CreateParameter("@CommentDesc", SqlDbType.Text, 1000, ParameterDirection.Input, commentDesc);
                param[4] = ModHelper.CreateParameter("@MOD", SqlDbType.Int, 4, ParameterDirection.Input, mod);
                param[5] = ModHelper.CreateParameter("@DetailID", SqlDbType.BigInt, 8, ParameterDirection.Input, detailID);
                param[6] = ModHelper.CreateParameter("@colFromNumber", SqlDbType.Int, 4, ParameterDirection.Input, colFromNumber);
                param[7] = ModHelper.CreateParameter("@colToNumber", SqlDbType.Int, 4, ParameterDirection.Input, colToNumber);
                param[8] = ModHelper.CreateParameter("@MachineID", SqlDbType.BigInt, 8, ParameterDirection.Input, machineid);
                param[9] = ModHelper.CreateParameter("@CategoryID", SqlDbType.BigInt, 8, ParameterDirection.Input, categotyId);
                param[10] = ModHelper.CreateParameter("@LineHrsID", SqlDbType.BigInt, 8, ParameterDirection.Input, lineHrsId);
                //SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblLineOEEComment", param);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblLineOEEComment_New", param);
                
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete_LineOEEComment()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[11];
                param[0] = ModHelper.CreateParameter("@LineActivityID", SqlDbType.Int, 4, ParameterDirection.Input, activityID);
                param[1] = ModHelper.CreateParameter("@FromTime", SqlDbType.DateTime, 8, ParameterDirection.Input, fromTime);
                param[2] = ModHelper.CreateParameter("@ToTime", SqlDbType.DateTime, 8, ParameterDirection.Input, toTime);
                param[3] = ModHelper.CreateParameter("@CommentDesc", SqlDbType.Text, 1000, ParameterDirection.Input, commentDesc);
                param[4] = ModHelper.CreateParameter("@MOD", SqlDbType.Int, 4, ParameterDirection.Input, mod);
                param[5] = ModHelper.CreateParameter("@DetailID", SqlDbType.BigInt, 8, ParameterDirection.Input, detailID);
                param[6] = ModHelper.CreateParameter("@colFromNumber", SqlDbType.Int, 4, ParameterDirection.Input, colFromNumber);
                param[7] = ModHelper.CreateParameter("@colToNumber", SqlDbType.Int, 4, ParameterDirection.Input, colToNumber);
                param[8] = ModHelper.CreateParameter("@MachineID", SqlDbType.BigInt, 8, ParameterDirection.Input, machineid);
                param[9] = ModHelper.CreateParameter("@CategoryID", SqlDbType.BigInt, 8, ParameterDirection.Input, categotyId);
                param[10] = ModHelper.CreateParameter("@LineHrsID", SqlDbType.BigInt, 8, ParameterDirection.Input, lineHrsId);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblLineOEEComment", param);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete_LineOEEComment_DetailID()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@DetailID", SqlDbType.BigInt, 8, ParameterDirection.Input, detailID);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblLineOEEComment_DetailID", param);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_LineOEEComment_DetailID_LineActivityID()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[6];
                param[0] = ModHelper.CreateParameter("@LineActivityID", SqlDbType.Int, 4, ParameterDirection.Input, activityID);
                param[1] = ModHelper.CreateParameter("@DetailID", SqlDbType.BigInt, 8, ParameterDirection.Input, detailID);
                param[2] = ModHelper.CreateParameter("@CategoryID", SqlDbType.BigInt, 8, ParameterDirection.Input, categotyId);
                param[3] = ModHelper.CreateParameter("@LineHrsID", SqlDbType.BigInt, 8, ParameterDirection.Input, lineHrsId);
                param[4] = ModHelper.CreateParameter("@colFromNumber", SqlDbType.Int, 4, ParameterDirection.Input, colFromNumber);
                param[5] = ModHelper.CreateParameter("@colToNumber", SqlDbType.Int, 4, ParameterDirection.Input, colToNumber);
                
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblLineOEEComment_DetailID_LineActivityID", param).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataTable Select_LineOEEDetails()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[4];
                param[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                param[1] = ModHelper.CreateParameter("@LNo", SqlDbType.Int, 4, ParameterDirection.Input, lno);
                param[2] = ModHelper.CreateParameter("@ShiftID", SqlDbType.Int, 4, ParameterDirection.Input, shiftID);
                param[3] = ModHelper.CreateParameter("@TransDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, transDate);
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblLineOEEDetails", param).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_LineOEEDetails_LineOEEComments()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[2];
                param[0] = ModHelper.CreateParameter("@DetailID", SqlDbType.BigInt, 8, ParameterDirection.Input, detailID);
                param[1] = ModHelper.CreateParameter("@LineHrsID", SqlDbType.BigInt, 8, ParameterDirection.Input, lineHrsId);
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblLineOEEComments_DetailID_LineHrsID", param).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_LineOEEDetails_Lno_TransDate_Shift()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[3];
                param[0] = ModHelper.CreateParameter("@LNo", SqlDbType.Int, 4, ParameterDirection.Input, lno);
                param[1] = ModHelper.CreateParameter("@ShiftID", SqlDbType.Int, 4, ParameterDirection.Input, shiftID);
                param[2] = ModHelper.CreateParameter("@TransDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, transDate);
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblLineOEEDetails_Lno_TransDate_Shift", param).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Select_LineOEEDetails_FGNo_Lno_TransDate()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[4];
                param[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                param[1] = ModHelper.CreateParameter("@LNo", SqlDbType.Int, 4, ParameterDirection.Input, lno);
                param[2] = ModHelper.CreateParameter("@TransDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, transDate);
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP__Select_tblLineOEEDetails_FGNo_Lno_TransDate", param).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public long Select_tblLineOEEDetail_MaxNumber()
        {
            try
            {
                return (Convert.ToInt64(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_tblLineOEEDetails_MaxFormNumber")));
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public DataTable Select_LineOEEDetails_FormNumber()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@FormNumber", SqlDbType.BigInt, 4, ParameterDirection.Input, formNumber);
                //param[1] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                //param[2] = ModHelper.CreateParameter("@LNo", SqlDbType.Int, 4, ParameterDirection.Input, lno);
                //param[3] = ModHelper.CreateParameter("@TransDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, transDate);
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblLineOEEDetails_FormNo", param).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_LineOEEComment()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[3];
                param[0] = ModHelper.CreateParameter("@DetailID", SqlDbType.BigInt, 8, ParameterDirection.Input, detailID);
                param[1] = ModHelper.CreateParameter("@FromTime", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, fromTime);
                param[2] = ModHelper.CreateParameter("@ToTime", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, toTime);
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblLineOEEComment", param).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Insert_LineOEEMaster()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                param[1] = ModHelper.CreateParameter("@LNo", SqlDbType.BigInt, 8, ParameterDirection.Input, lno);
                param[2] = ModHelper.CreateParameter("@StandardMOD", SqlDbType.Int, 4, ParameterDirection.Input, mod);
                param[3] = ModHelper.CreateParameter("@LineSpeed", SqlDbType.Int, 4, ParameterDirection.Input, lineSpeed);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblLineOEEMaster", param);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update_LineOEEMaster()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[4];
                param[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                param[1] = ModHelper.CreateParameter("@LNo", SqlDbType.BigInt, 8, ParameterDirection.Input, lno);
                param[2] = ModHelper.CreateParameter("@StandardMOD", SqlDbType.Int, 4, ParameterDirection.Input, mod);
                param[3] = ModHelper.CreateParameter("@LineSpeed", SqlDbType.Int, 4, ParameterDirection.Input, lineSpeed);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblLineOEEMaster", param);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Select_LineOEEMaster()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[2];
                param[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                param[1] = ModHelper.CreateParameter("@LNo", SqlDbType.BigInt, 8, ParameterDirection.Input, lno);
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblLineOEEMaster", param).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Select_LineOEEMaster_FGNo()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblLineOEEMaster_FGNo", param).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete_LineOEEMaster()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
                param[1] = ModHelper.CreateParameter("@LNo", SqlDbType.BigInt, 8, ParameterDirection.Input, lno);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblLineOEEMaster", param);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Select_LineOEEComment_Comments()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[5];
                param[0] = ModHelper.CreateParameter("@LineActivityID", SqlDbType.Int, 4, ParameterDirection.Input, activityID);
                param[1] = ModHelper.CreateParameter("@colFromNumber", SqlDbType.Int, 4, ParameterDirection.Input, colFromNumber);
                param[2] = ModHelper.CreateParameter("@colToNumber", SqlDbType.Int, 4, ParameterDirection.Input, colToNumber);
                param[3] = ModHelper.CreateParameter("@DetailID", SqlDbType.BigInt, 8, ParameterDirection.Input, detailID);
                param[4] = ModHelper.CreateParameter("@LineHrsID", SqlDbType.BigInt, 8, ParameterDirection.Input, lineHrsId);
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblLineOEEComment_Comments", param).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion

        public bool Insert_tblLineOEEFGMaster_Uploadexcel()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = ModHelper.CreateParameter("@FGCode", SqlDbType.VarChar, 200, ParameterDirection.Input, fgCode);
                param[1] = ModHelper.CreateParameter("@FGDesc", SqlDbType.VarChar, 200, ParameterDirection.Input, productDescription);
              
                int i = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblLineOEEFGMaster_Uploadexcel", param);
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


        #region Line OEE Upload Master Function

        public int CheckFGCodeExist()
        {
            try
            {
                int i = 0;
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@FGCode", SqlDbType.VarChar, 200, ParameterDirection.Input, fgCode);
                i = Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_SELECT_tblLineOEEFGMaster_FgCode", param));
                return i;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int Check_FGCODE_Years_Exist()
        {
            try
            {
                int i = 0;
                SqlParameter[] param = new SqlParameter[2];
                param[0] = ModHelper.CreateParameter("@FGCode", SqlDbType.VarChar, 200, ParameterDirection.Input, fgCode);
                param[1] = ModHelper.CreateParameter("@YEARS", SqlDbType.VarChar, 200, ParameterDirection.Input, year);
                i = Convert.ToInt32(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_Select_tblLineOEEUploadMaster_FGCODE_YEARS", param));
                return i;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public bool Insert_UploadLineOEEMaster()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[8];
                param[0] = ModHelper.CreateParameter("@FGCODE", SqlDbType.VarChar, 200, ParameterDirection.Input, fgCode);
                param[1] = ModHelper.CreateParameter("@FAMILY", SqlDbType.VarChar, 200, ParameterDirection.Input, family);
                param[2] = ModHelper.CreateParameter("@YEARS", SqlDbType.VarChar, 200, ParameterDirection.Input, year);
                param[3] = ModHelper.CreateParameter("@MOD", SqlDbType.VarChar, 200, ParameterDirection.Input, modUpload);
                param[4] = ModHelper.CreateParameter("@UST", SqlDbType.VarChar, 200, ParameterDirection.Input, ust);
                param[5] = ModHelper.CreateParameter("@PRODUCTDESCRIPTION", SqlDbType.VarChar, 200, ParameterDirection.Input, productDescription);
                param[6] = ModHelper.CreateParameter("@LINESPEED", SqlDbType.VarChar, 200, ParameterDirection.Input, lineSpeedUpload);
                param[7] = ModHelper.CreateParameter("@LINENOS", SqlDbType.VarChar, 200, ParameterDirection.Input, lineNo);
                int i = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblLineOEEUploadMaster", param);
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

        public bool Update_UploadLineOEEMaster()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[8];
                param[0] = ModHelper.CreateParameter("@FGCODE", SqlDbType.VarChar, 200, ParameterDirection.Input, fgCode);
                param[1] = ModHelper.CreateParameter("@FAMILY", SqlDbType.VarChar, 200, ParameterDirection.Input, family);
                param[2] = ModHelper.CreateParameter("@YEARS", SqlDbType.VarChar, 200, ParameterDirection.Input, year);
                param[3] = ModHelper.CreateParameter("@MOD", SqlDbType.VarChar, 200, ParameterDirection.Input, modUpload);
                param[4] = ModHelper.CreateParameter("@UST", SqlDbType.VarChar, 200, ParameterDirection.Input, ust);
                param[5] = ModHelper.CreateParameter("@PRODUCTDESCRIPTION", SqlDbType.VarChar, 200, ParameterDirection.Input, productDescription);
                param[6] = ModHelper.CreateParameter("@LINESPEED", SqlDbType.VarChar, 200, ParameterDirection.Input, lineSpeedUpload);
                param[7] = ModHelper.CreateParameter("@LINENOS", SqlDbType.VarChar, 200, ParameterDirection.Input, lineNo);
                int i = SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblLineOEEUploadMaster", param);
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

        #region Line OEE Activity Relation Master
        public DataSet Select_tblLineOEECategoryMaster()
        {
            try
            {
                DataSet ds = new DataSet();
                ds = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblLineOEECategoryMaster");
                return ds;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Select_tblLineOEEActivityMaster_Active()
        {
            try
            {
                return (SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblLineOEEActivityMaster_Active").Tables[0]);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Delete_LineOEEActivityCategoryRelation()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@LineOEECategoryID", SqlDbType.BigInt, 8, ParameterDirection.Input, lineoeecategoryid);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblLineOEEActivityCategoryRelation_LineOEECategoryID", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Insert_tblLineOEEActivityCategoryRelation()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@LineOEECategoryID", SqlDbType.BigInt, 8, ParameterDirection.Input, lineoeecategoryid);
                myparam[1] = ModHelper.CreateParameter("@LineActivityID", SqlDbType.BigInt, 8, ParameterDirection.Input, activityID);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Insert_tblLineOEEActivityCategoryRelation", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Select_tblLineOEEActivityCategoryRelation()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[1];
                myparam[0] = ModHelper.CreateParameter("@LineOEECategoryID", SqlDbType.BigInt, 8, ParameterDirection.Input, lineoeecategoryid);
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_tblLineOEEActivityCategoryRelation_LineOEECategoryID", myparam).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_LineOEE_DataJunction_Report()
        {
            try
            {

                string str = ConfigurationSettings.AppSettings["connectionstring"];
                SqlConnection con = new SqlConnection(str);

                SqlCommand cmd = new SqlCommand("STP_LineOEE_DataJunction_Report", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.SmallDateTime, 4, "StartDate"));
                cmd.Parameters.Add(new SqlParameter("@EndDate", SqlDbType.SmallDateTime, 4, "EndDate"));
                cmd.Parameters[0].Value = startdate;
                cmd.Parameters[1].Value = enddate;
                DataSet ds = new DataSet();
                SqlDataAdapter sqlAdpt = new SqlDataAdapter(cmd);
                sqlAdpt.Fill(ds);
                return ds.Tables[0];

                //SqlParameter[] myparam = new SqlParameter[2];
                //myparam[0] = ModHelper.CreateParameter("@StartDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, startdate);
                //myparam[1] = ModHelper.CreateParameter("@EndDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, enddate);
                //return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_OEEProcess_Report", myparam).Tables[0];//STP_Select_DetailedProcessing_Analysis_Report  old stored procedure

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable Select_LineOEE_DataJunctionShiftWise_Report()
        {
            try
            {

                string str = ConfigurationSettings.AppSettings["connectionstring"];
                SqlConnection con = new SqlConnection(str);

                SqlCommand cmd = new SqlCommand("STP_LineOEE_DataJunctionShiftWise_Report", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.SmallDateTime, 4, "StartDate"));
                cmd.Parameters.Add(new SqlParameter("@EndDate", SqlDbType.SmallDateTime, 4, "EndDate"));
                cmd.Parameters[0].Value = startdate;
                cmd.Parameters[1].Value = enddate;
                DataSet ds = new DataSet();
                SqlDataAdapter sqlAdpt = new SqlDataAdapter(cmd);
                sqlAdpt.Fill(ds);
                return ds.Tables[0];

                //SqlParameter[] myparam = new SqlParameter[2];
                //myparam[0] = ModHelper.CreateParameter("@StartDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, startdate);
                //myparam[1] = ModHelper.CreateParameter("@EndDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, enddate);
                //return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_OEEProcess_Report", myparam).Tables[0];//STP_Select_DetailedProcessing_Analysis_Report  old stored procedure

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_LineOEE_BreackDown_Report()
        {
            try
            {

                string str = ConfigurationSettings.AppSettings["connectionstring"];
                SqlConnection con = new SqlConnection(str);

                SqlCommand cmd = new SqlCommand("STP_LineOEE_BreakDownTime_Report", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.SmallDateTime, 4, "StartDate"));
                cmd.Parameters.Add(new SqlParameter("@EndDate", SqlDbType.SmallDateTime, 4, "EndDate"));
                cmd.Parameters[0].Value = startdate;
                cmd.Parameters[1].Value = enddate;
                DataSet ds = new DataSet();
                SqlDataAdapter sqlAdpt = new SqlDataAdapter(cmd);
                sqlAdpt.Fill(ds);
                return ds.Tables[0];

                //SqlParameter[] myparam = new SqlParameter[2];
                //myparam[0] = ModHelper.CreateParameter("@StartDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, startdate);
                //myparam[1] = ModHelper.CreateParameter("@EndDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, enddate);
                //return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_OEEProcess_Report", myparam).Tables[0];//STP_Select_DetailedProcessing_Analysis_Report  old stored procedure

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_LineOEE_DataSummary_Report()
        {
            try
            {

                string str = ConfigurationSettings.AppSettings["connectionstring"];
                SqlConnection con = new SqlConnection(str);

                SqlCommand cmd = new SqlCommand("STP_LineOEE_Summary_Report", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.SmallDateTime, 4, "StartDate"));
                cmd.Parameters.Add(new SqlParameter("@EndDate", SqlDbType.SmallDateTime, 4, "EndDate"));
                cmd.Parameters[0].Value = startdate;
                cmd.Parameters[1].Value = enddate;
                DataSet ds = new DataSet();
                SqlDataAdapter sqlAdpt = new SqlDataAdapter(cmd);
                sqlAdpt.Fill(ds);
                return ds.Tables[0];

                //SqlParameter[] myparam = new SqlParameter[2];
                //myparam[0] = ModHelper.CreateParameter("@StartDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, startdate);
                //myparam[1] = ModHelper.CreateParameter("@EndDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, enddate);
                //return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_SELECT_OEEProcess_Report", myparam).Tables[0];//STP_Select_DetailedProcessing_Analysis_Report  old stored procedure

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Line OEE monthwise graph report

        public DataTable Select_GetDate_BetweenTwoDate()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@startDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, startdate);
                myparam[1] = ModHelper.CreateParameter("@endDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, enddate);
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_GetDate_BetweenTwoDate", myparam).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_LineOEEDataExistGraph_Report()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@LNo", SqlDbType.Int, 4, ParameterDirection.Input, lno);
                myparam[1] = ModHelper.CreateParameter("@TransDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, transDate);
                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_LineOEEDataExistGraph_Report", myparam).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable Select_LineOEEDataExistGraph_ShiftWiseReport()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[3];
                myparam[0] = ModHelper.CreateParameter("@LNo", SqlDbType.Int, 4, ParameterDirection.Input, lno);
                myparam[1] = ModHelper.CreateParameter("@TransDate", SqlDbType.SmallDateTime, 4, ParameterDirection.Input, transDate);
                myparam[2] = ModHelper.CreateParameter("@ShiftID", SqlDbType.BigInt, 8, ParameterDirection.Input, shiftID);

                return SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_LineOEEDataExistGraph_ShiftWise_Report", myparam).Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region Line OEE UP Tdb Report

        public DataTable Select_LineOEE_UPTdb_Report()
        {
            try
            {
                string str = ConfigurationSettings.AppSettings["connectionstring"];
                SqlConnection con = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand("STP_Line_OEEUPTdb_Report", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.SmallDateTime, 4, "StartDate"));
                cmd.Parameters.Add(new SqlParameter("@EndDate", SqlDbType.SmallDateTime, 4, "EndDate"));
                cmd.Parameters[0].Value = startdate;
                cmd.Parameters[1].Value = enddate;
                DataSet ds = new DataSet();
                SqlDataAdapter sqlAdpt = new SqlDataAdapter(cmd);
                sqlAdpt.Fill(ds);
                return ds.Tables[0];

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion


        #region Line OEE S84bis Report

        public DataTable Select_LineOEE_S84bis_Report()
        {
            try
            {
                string str = ConfigurationSettings.AppSettings["connectionstring"];
                SqlConnection con = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand("STP_LineOEE_S84bis_Report", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.SmallDateTime, 4, "StartDate"));
                cmd.Parameters.Add(new SqlParameter("@EndDate", SqlDbType.SmallDateTime, 4, "EndDate"));
                cmd.Parameters[0].Value = startdate;
                cmd.Parameters[1].Value = enddate;
                DataSet ds = new DataSet();
                SqlDataAdapter sqlAdpt = new SqlDataAdapter(cmd);
                sqlAdpt.Fill(ds);
                return ds.Tables[0];

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion


        #region Line OEE S83 Report

        public DataTable Select_LineOEE_S83_Report()
        {
            try
            {
                string str = ConfigurationSettings.AppSettings["connectionstring"];
                SqlConnection con = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand("STP_LineOEE_S83_Report", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.SmallDateTime, 4, "StartDate"));
                cmd.Parameters.Add(new SqlParameter("@EndDate", SqlDbType.SmallDateTime, 4, "EndDate"));
                cmd.Parameters[0].Value = startdate;
                cmd.Parameters[1].Value = enddate;
                DataSet ds = new DataSet();
                SqlDataAdapter sqlAdpt = new SqlDataAdapter(cmd);
                sqlAdpt.Fill(ds);
                return ds.Tables[0];

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region Line OEE S84 Report

        public DataTable Select_LineOEE_S84_Report()
        {
            try
            {
                string str = ConfigurationSettings.AppSettings["connectionstring"];
                SqlConnection con = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand("STP_LineOEE_S84_Report", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add(new SqlParameter("@StartDate", SqlDbType.SmallDateTime, 4, "StartDate"));
                cmd.Parameters.Add(new SqlParameter("@EndDate", SqlDbType.SmallDateTime, 4, "EndDate"));
                cmd.Parameters[0].Value = startdate;
                cmd.Parameters[1].Value = enddate;
                DataSet ds = new DataSet();
                SqlDataAdapter sqlAdpt = new SqlDataAdapter(cmd);
                sqlAdpt.Fill(ds);
                return ds.Tables[0];

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataTable Select_LineOEE_Setting()
        {
            try
            {
                string str = ConfigurationSettings.AppSettings["connectionstring"];
                SqlConnection con = new SqlConnection(str);
                SqlCommand cmd = new SqlCommand("STP_LineOEESetting", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 0;
                cmd.Parameters.Add(new SqlParameter("@flag", SqlDbType.VarChar, 20, "FLAG"));
                //cmd.Parameters.Add(new SqlParameter("@EndDate", SqlDbType.SmallDateTime, 4, "EndDate"));
                cmd.Parameters[0].Value = "Show";
                //cmd.Parameters[1].Value = enddate;
                DataSet ds = new DataSet();
                SqlDataAdapter sqlAdpt = new SqlDataAdapter(cmd);
                sqlAdpt.Fill(ds);
                return ds.Tables[0];

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Insert_LineOEE_Setting()
        {
            try
            {
                SqlParameter[] myparam = new SqlParameter[2];
                myparam[0] = ModHelper.CreateParameter("@MECSTDTIME", SqlDbType.Float, 4, ParameterDirection.Input, messtdtime);
                myparam[1] = ModHelper.CreateParameter("@flag", SqlDbType.VarChar, 20, ParameterDirection.Input, flag);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_LineOEESetting", myparam);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        /// <summary>
        /// new added by rohan 22/nov/2022
        /// </summary>
        /// <returns></returns>
        public DataTable GetProducedUnitsByHours()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[2];
                param[0] = ModHelper.CreateParameter("@DetailID", SqlDbType.Int, 4, ParameterDirection.Input, detailID);
                param[1] = ModHelper.CreateParameter("@ShiftID", SqlDbType.Int, 4, ParameterDirection.Input, shiftID);
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Select_tblLineOEEHrs", param).Tables[0];
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public DataSet Get_Category_By_Activity()
        {
            try
            {
                DataSet dt = new DataSet();
                SqlParameter[] param = new SqlParameter[1];
                param[0] = ModHelper.CreateParameter("@LineActivityID", SqlDbType.BigInt, 8, ParameterDirection.Input, activityID);
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Get_Category_By_ActivityId_tblLineOEECategoryMaster", param);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public DataTable Get_LineOEEHrsID_tblLineOEEHrs()
        {
            try
            {
                DataTable dt = new DataTable();
                SqlParameter[] param = new SqlParameter[3];
                param[0] = ModHelper.CreateParameter("@DetailID", SqlDbType.BigInt, 8, ParameterDirection.Input, detailID);
                param[1] = ModHelper.CreateParameter("@FromTime", SqlDbType.DateTime, 8, ParameterDirection.Input, fromTime);
                param[2] = ModHelper.CreateParameter("@ToTime", SqlDbType.DateTime, 8, ParameterDirection.Input, toTime);
                //param[3] = ModHelper.CreateParameter("@LineHrsID", SqlDbType.BigInt, 8, ParameterDirection.Output, lineHrsId);
                dt = SqlHelper.ExecuteDataset(CommandType.StoredProcedure, "STP_Get_LineOEEHrsID_tblLineOEEHrs", param).Tables[0];
                return dt;
            
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public long Insert_LineOEEHrs()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[5];
                param[0] = ModHelper.CreateParameter("@DetailID", SqlDbType.BigInt, 8, ParameterDirection.Input, detailID);
                param[1] = ModHelper.CreateParameter("@FromTime", SqlDbType.DateTime, 8, ParameterDirection.Input, fromTime);
                param[2] = ModHelper.CreateParameter("@ToTime", SqlDbType.DateTime, 8, ParameterDirection.Input, toTime);
                param[3] = ModHelper.CreateParameter("@ProducedUnit", SqlDbType.BigInt, 8, ParameterDirection.Input, producedUnits);
                param[4] = ModHelper.CreateParameter("@LineHrsID", SqlDbType.BigInt, 8, ParameterDirection.Output, lineHrsId);
                return Convert.ToInt64(SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_Insert_tblLineOEEHrs", param));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete_LineOEEComment_DetailID_LineHrsID()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];
                param[0] = ModHelper.CreateParameter("@DetailID", SqlDbType.BigInt, 8, ParameterDirection.Input, detailID);
                param[1] = ModHelper.CreateParameter("@LineHrsID", SqlDbType.BigInt, 8, ParameterDirection.Input, lineHrsId);
                SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Delete_tblLineOEEComment_DetailID_LineHrsID", param);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public bool Update_LineOEEDetails()
        //{
        //    try
        //    {
        //        SqlParameter[] param = new SqlParameter[4];
        //        param[0] = ModHelper.CreateParameter("@FGNo", SqlDbType.BigInt, 8, ParameterDirection.Input, fgno);
        //        param[1] = ModHelper.CreateParameter("@LNo", SqlDbType.BigInt, 8, ParameterDirection.Input, lno);
        //        SqlHelper.ExecuteNonQuery(CommandType.StoredProcedure, "STP_Update_tblLineOEEDetails", param);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
    }
}
