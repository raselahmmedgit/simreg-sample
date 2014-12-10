using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace SIMREG.Helpers
{
    public static class Connection
    {
        public static string ConnectionString()
        {
            string strConnection = string.Empty;
            return strConnection = System.Configuration.ConfigurationManager.ConnectionStrings["SIMREGConnectionString"].ConnectionString;
        }

    }
}