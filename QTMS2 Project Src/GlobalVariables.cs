using System;
using System.Collections.Generic;
using System.Text;
using BusinessFacade;
namespace QTMS
{
   public static class GlobalVariables
    {
       public static string companyName, companyAddress, FIName;
        // Use For Dimen
        public static List<DimensionParameter_Class> lstDimensionNorm = new List<DimensionParameter_Class>();
        public static List<long> lstStatusID = new List<long>();

        public static long uid,utypeid;
        public static string uname, pwd;

       //public static string FTPDirectory;
       //public static string FTPHost;
       //public static string FTPPassword;
       //public static int FTPPort;
       //public static string FTPUsername;
       //public static string CurrentFolder;

       private static string ftpDirectory;

       public static string FTPDirectory
       {
           get { return ftpDirectory; }
           set { ftpDirectory = value; }
       }

       private static string ftpHost;

       public static string FTPHost
       {
           get { return ftpHost; }
           set { ftpHost = value; }
       }

       private static string ftpPassword;

       public static string FTPPassword
       {
           get { return ftpPassword; }
           set { ftpPassword = value; }
       }

       private static int ftpPort;

       public static int FTPPort
       {
           get { return ftpPort; }
           set { ftpPort = value; }
       }

       private static string ftpUsername;

       public static string FTPUsername
       {
           get { return ftpUsername; }
           set { ftpUsername = value; }
       }

       private static string currentFolder;

       public static string CurrentFolder
       {
           get { return currentFolder; }
           set { currentFolder = value; }
       }
 
       private static string address1;
       public static string Address1
       {
           get { return address1; }
           set { address1 = value; }
       }

       private static string address2;
       public static string Address2
       {
           get { return address2; }
           set { address2 = value; }
       }

       private static string address3;
       public static string Address3
       {
           get { return address3; }
           set { address3 = value; }
       }
       private static string city;
       public static string City
       {
           get { return city; }
           set { city = value; }
       }

      
     }
}
