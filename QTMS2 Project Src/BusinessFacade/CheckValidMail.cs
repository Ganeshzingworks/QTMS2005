using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
namespace BusinessFacade
{
    public class CheckValidMail
    {
        public CheckValidMail()
        {
        }

        public static Boolean IsEmailValid(string EmailAddr)
        {

            try
            {
                if (EmailAddr != null || EmailAddr != "")
                {
                    //string strRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
                    //                  @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
                    //                  @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
                    // This exp allows semicolon seperated email id's.
                    string strRegex =@"^(([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5}){1,25})+([;.](([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5}){1,25})+)*$";
                    Regex n = new Regex(strRegex);
                    Match v = n.Match(EmailAddr);

                    if (!v.Success || EmailAddr.Length != v.Length)
                    {

                        return false;
                    }

                    else
                    {

                        return true;
                    }

                }

                else
                {

                    return false;
                }
            }
            catch (Exception ex)
            {                
                throw ex;
            }

        }

    }
}
