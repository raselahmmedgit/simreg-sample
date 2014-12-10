using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SimReg.BusinessEntity;

namespace SimReg.Web.Helpers
{
    public class LoginInfo
    {
        public LoginInfo()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        public static void SetLoginInfo(BESIMREG_DOMAINUSER userInfo)
        {
            HttpContext.Current.Session["userinfo"] = userInfo;
        }

        public static BESIMREG_DOMAINUSER Current
        {
            get
            {
                if (HttpContext.Current.Session["userinfo"] == null)
                {
                    HttpContext.Current.Response.Redirect("/Account/LogOn");
                }
                return (BESIMREG_DOMAINUSER)HttpContext.Current.Session["userinfo"];
            }
        }

    }
}