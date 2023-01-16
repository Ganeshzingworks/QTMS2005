using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using BusinessFacade.Transactions;
using DataFacade;
namespace BusinessFacade.Scoop_Class
{
    public class Class_ScoopProcess
    {
        public Class_ScoopProcess() { }

        #region Variable
        Comman_Class Comman_Class_Obj = new BusinessFacade.Transactions.Comman_Class();
        static UPMaster_Class UPMaster_Class_Obj = new UPMaster_Class();
        #endregion

        public static int TimeLeft_AfterLineStart(DateTime LineStartTime)
        {
            try
            {
                int timeleft = 0;
                DateTime TestStart = UPMaster_Class_Obj.GetCurrentTime(); //<-------- get current time of server
                TimeSpan timeDiff = TestStart.Subtract(LineStartTime);
                if (timeDiff.Minutes <= 15 && timeDiff.Days == 0 && timeDiff.Hours == 0)
                {
                    timeleft = 15 - timeDiff.Minutes;
                }
                else
                {
                    timeleft = 0;
                }
                return timeleft;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static bool TimeExid(int timepased, int timeLeft)
        {
            if (timepased == timeLeft)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static List<DateTime> SortDescending(List<DateTime> list)
        {
            list.Sort(DateTime.Compare);
            return list;
        }

        public static DateTime GetCurrentTime()
        {
            try
            {
                DateTime CurrTme;
                CurrTme = (DateTime)SqlHelper.ExecuteScalar(CommandType.StoredProcedure, "STP_GetCurrentDateTime_UP");
                return CurrTme;
            }
            catch
            {
                throw;
            }
        }
    }

}

