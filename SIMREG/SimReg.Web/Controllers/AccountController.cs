using System;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using SimReg.BusinessEntity;
using SimReg.BusinessObject;
using SimReg.Web.Models;


namespace SimReg.Web.Controllers
{
    public class AccountController : Controller
    {

        //
        // GET: /Account/LogOn

        public ActionResult LogOn()
        {
            return View();
        }

        //
        // POST: /Account/LogOn

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (CheckUserPasswordInActiveDirectory(model))
                {
                    //FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    if (CheckUserPasswordInDatabase(model))
                    {
                        FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                        Session["UserName"] = model.UserName;
                        Session["Permission"] = "Y";
                        Session["Password"] = model.Password;
                        Session["RememberMe"] = model.RememberMe;

                        return RedirectToAction("Index", "SimRegister");
                    }
                    else
                    {
                        ModelState.AddModelError("", "The user is not permitted to login.");
                    }

                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }

            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/LogOff

        public ActionResult LogOff()
        {
            Session.Remove("UserName");
            Session.Remove("Permission");
            Session.Remove("Password"); ;
            Session.Remove("RememberMe");
            Session.Remove("CanEdit");

            FormsAuthentication.SignOut();

            return RedirectToAction("LogOn", "Account");
        }

        #region Check User

        private bool CheckUserPasswordInActiveDirectory(LogOnModel model)
        {
            string strLoginName = model.UserName;
            string strADDomanName = GetAdDomainName();
            bool result = false;
            //using (DirectoryEntry de = new DirectoryEntry("LDAP://Banglalink", strLoginName, edtPassword.Text.Trim()))
            using (DirectoryEntry de = new DirectoryEntry(String.Format("LDAP://{0}", strADDomanName), strLoginName, model.Password))
            {
                using (DirectorySearcher adSearch = new DirectorySearcher(de))
                {

                    adSearch.Filter = "(sAMAccountName=" + strLoginName + ")";
                    try
                    {
                        SearchResult adSearchResult = adSearch.FindOne();
                        DirectoryEntry adUser = adSearchResult.GetDirectoryEntry();
                        result = true;
                    }
                    catch (Exception)
                    {
                        result = false;
                    }
                    //string UserEmailAddress = adUser.Properties["mail"].Value.ToString();
                }
            }
            return result;
        }

        private bool CheckUserPasswordInDatabase(LogOnModel model)
        {
            bool result = false;
            try
            {
                BOSIMREG_DOMAINUSER boSIMREG_DOMAINUSER = new BOSIMREG_DOMAINUSER();

                //BESIMREG_DOMAINUSER beSIMREG_DOMAINUSER = boSIMREG_DOMAINUSER.GetSIMREG_DOMAINUSER(model.UserName);
                BESIMREG_DELIVEREDBY beSIMREG_DELIVEREDBY = boSIMREG_DOMAINUSER.GetSIMREG_DOMAINUSERbyDELIVER(model.UserName);

                if (beSIMREG_DELIVEREDBY != null)
                {
                    //if (beSIMREG_DOMAINUSER.userid >= 1)
                    if (!String.IsNullOrEmpty(beSIMREG_DELIVEREDBY.USERNAME))
                    {
                        result = true;
                        Session["CanEdit"] = beSIMREG_DELIVEREDBY.CANEDIT;
                    }

                }
                else
                {
                    result = false;
                }

            }
            catch (Exception)
            {
                result = false;
            }

            return result;

        }

        public static string GetAdDomainName()
        {
            return ConfigurationManager.AppSettings["ADDomainName"].ToString();
        }

        #endregion

        #region Status Codes
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion
    }
}
