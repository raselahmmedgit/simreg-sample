using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIMREG.Helpers
{
    public class Utility
    {
        private System.String strConnection;

        public string ConnectionString
        {
            get
            {
                return strConnection;
            }
            set
            {
                strConnection = value;
            }
        }

        public static string GetConnectionStringOracle()
        {
            //return "Data Source=DatabaseName; User ID=User; Password=Password;";
            //return ConfigurationSettings.AppSettings["SIMREGConnectionString"].ToString();
            return System.Configuration.ConfigurationManager.ConnectionStrings["SIMREGConnectionString"].ConnectionString;
        }

        public static string GetSchemaSIMREG()
        {
            return "SIMREG.";
            //   return ConfigurationSettings.AppSettings["GetSIMREGSchema"].ToString();
        }

        public static int ErrorCode = -10000000;
    }

}