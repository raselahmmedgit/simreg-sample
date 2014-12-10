using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using System.Configuration;
using RnD.BLTemp.BusinessEntity;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace RnD.BLTemp.Common
{
    public class Utility
    {
        public static string MSISDM { get; set; }
        public static string PREPAID = "PREP";
        public static string POSTPAID = "POST";

        public static string ApplicationId
        {
            get { return Convert.ToString(ConfigurationManager.AppSettings["AppId"]); }
        }

        public static string AuthenticationCode
        {
            get { return Convert.ToString(ConfigurationManager.AppSettings["AuthCode"]); }
        }

        public static string SuperAdminName
        {

            get { return Convert.ToString(ConfigurationManager.AppSettings["SuperAdminName"]); }
        }

        public enum QuestionType
        {
            CheckBoxType = 36,
            DropDownType = 37,
            TextBoxType = 38,
        }

        public enum DataType
        {
            Numeric = 1,
            VarChar = 2,
            DateTime = 3,
        }

        public enum QuestionForEnum
        {
            ICONRegistration = 34,
            Complain = 35,
            Service = 49
        }

        public enum ApplicationTypeEnum
        {
            HVC = 1,
            BOS = 2,
            SMS = 3,
        }

        public enum RequestType
        {
            Complain = 1,
            VASService = 2,
            Promotion = 3,
            Feedback = 4
        }

        public enum TicketMsgFor
        {
            Customer = 0,
            Manager = 1,
            Both = 2
        }

        public enum ImageType
        {
            BillImage = 1,
            HomePageImage = 2,
            BirthDayImage = 3,
            MainPageAdd = 4
        }

        public enum RequisitionPassStatus
        {
            Planning = 0,
            Telecom = 1,
            Done = 2,
            Canceled = 3
        };

        public enum CheckValidationType
        {
            Length = 1,
            Regular = 2,
            Value = 3
        }

        public static string GetImageTypeName(Int32 typeId)
        {
            string typeName = string.Empty;
            ImageType type = (ImageType)typeId;
            switch (type)
            {
                case ImageType.BillImage: typeName = "Bill Image"; break;
                case ImageType.HomePageImage: typeName = "Home Page Image"; break;
                case ImageType.BirthDayImage: typeName = "Birthday Image"; break;
                default: typeName = "Unknown Type of Image"; break;
            }
            return typeName;
        }

        public static int GetPickDuration()
        {
            int defaultDuration = 10;
            string duration = ConfigurationManager.AppSettings["PickDuration"]; /* located in the web.config of web app*/

            if (string.IsNullOrEmpty(duration))
            {
                return defaultDuration;
            }
            else
            {
                return Convert.ToInt32(duration.Trim());
            }
        }

        public static List<string> GetEligiblePackageForItemizedBill()
        {
            List<string> packages = new List<string> { "EIBILM", "EIBILMFREE", "IBILM", "IBILMFREE", "IBNEIBILM" };
            return packages;
        }

        public static string GetResolvedMsg()
        {
            string ResolvedMsg = "";
            ResolvedMsg = ConfigurationManager.AppSettings["ResolvedMsg"]; /* located in the web.config of web app*/

            return ResolvedMsg;
        }

        public static string GetResolvedSubject()
        {
            string ResolvedSubj = "";
            ResolvedSubj = ConfigurationManager.AppSettings["ResolvedSubj"]; /* located in the web.config of web app*/

            return ResolvedSubj;
        }

        public static string GetTicketCreateMsgSubj()
        {
            string MsgSubj = "";
            MsgSubj = ConfigurationManager.AppSettings["TicketCreateMsgSubj"]; /* located in the web.config of web app*/

            return MsgSubj;
        }

        public static string GetComplainTicketCreateMsgSubj()
        {
            string MsgSubj = "";
            MsgSubj = ConfigurationManager.AppSettings["ComplainTicketCreateMsgSubj"]; /* located in the web.config of web app*/

            return MsgSubj;
        }

        public static string GetServiceTicketCreateMsgSubj()
        {
            string MsgSubj = "";
            MsgSubj = ConfigurationManager.AppSettings["ServiceTicketCreateMsgSubj"]; /* located in the web.config of web app*/

            return MsgSubj;
        }

        public static string GetFeedbackTicketCreateMsgSubj()
        {
            string MsgSubj = "";
            MsgSubj = ConfigurationManager.AppSettings["FeedbackTicketCreateMsgSubj"]; /* located in the web.config of web app*/

            return MsgSubj;
        }

        public static string GetPromotionTicketCreateMsgSubj()
        {
            string MsgSubj = "";
            MsgSubj = ConfigurationManager.AppSettings["PromotionTicketCreateMsgSubj"]; /* located in the web.config of web app*/

            return MsgSubj;
        }

        public static string GetComplainTicketStatusChangeMsgSubj()
        {
            string MsgSubj = "";
            MsgSubj = ConfigurationManager.AppSettings["ComplainTicketStatusChangeMsgSubj"]; /* located in the web.config of web app*/

            return MsgSubj;
        }

        public static string GetServiceTicketStatusChangeMsgSubj()
        {
            string MsgSubj = "";
            MsgSubj = ConfigurationManager.AppSettings["ServiceTicketStatusChangeMsgSubj"]; /* located in the web.config of web app*/

            return MsgSubj;
        }

        public static string GetFeedbackTicketStatusChangeMsgSubj()
        {
            string MsgSubj = "";
            MsgSubj = ConfigurationManager.AppSettings["FeedbackTicketStatusChangeMsgSubj"]; /* located in the web.config of web app*/

            return MsgSubj;
        }

        public static string GetPromotionTicketStatusChangeMsgSubj()
        {
            string MsgSubj = "";
            MsgSubj = ConfigurationManager.AppSettings["PromotionTicketStatusChangeMsgSubj"]; /* located in the web.config of web app*/

            return MsgSubj;
        }

        public static string GetComplainTicketCreateMsg()
        {
            string createMsg = "";
            createMsg = ConfigurationManager.AppSettings["ComplainTicketCreateMsg"]; /* located in the web.config of web app*/
            createMsg = createMsg.Replace("$br", "<br/>");
            return createMsg;
        }

        //public static bool IsCorporateMSISDN(string MSISDN, List<BEActiveService> activePackages)
        //{
        //    bool isCorporate = false;
        //    string[] packages = ConfigurationManager.AppSettings["CorporatePackage"].Split(';');
        //    foreach (RnD.BLTemp.BusinessEntity.BEActiveService package in activePackages)
        //    {
        //        foreach (string item in packages)
        //        {
        //            if (item.Trim().Contains(package.ServiceId))
        //            {
        //                isCorporate = true;
        //                break;
        //            }
        //        }
        //    }
        //    return isCorporate;
        //}

        public static string GetSecondToHHMMSS(int Duration)
        {
            int duration = Duration;
            string durationText = "";

            durationText = (duration / (60 * 60)).ToString("00") + ":";
            duration = duration % (60 * 60);
            durationText += (duration / 60).ToString("00") + ":";
            duration = duration % 60;
            durationText += duration.ToString("00");

            return durationText;
        }

        public static string GetFeedbackTicketCreateMsg()
        {
            string createMsg = "";
            createMsg = ConfigurationManager.AppSettings["FeedbackTicketCreateMsg"]; /* located in the web.config of web app*/

            return createMsg;
        }

        public static string GetServiceTicketCreateMsg()
        {
            string createMsg = "";
            createMsg = ConfigurationManager.AppSettings["ServiceTicketCreateMsg"]; /* located in the web.config of web app*/

            return createMsg;
        }

        public static string GetPromotionTicketCreateMsg()
        {
            string createMsg = "";
            createMsg = ConfigurationManager.AppSettings["PromotionTicketCreateMsg"]; /* located in the web.config of web app*/

            return createMsg;
        }

        public static string GetIconManagerUserGroupName()
        {
            string groupName = "";
            groupName = ConfigurationManager.AppSettings["IconManagerUserGroup"]; /* located in the web.config of web app*/

            return groupName;
        }

        public static string GetErrorLogFilePath()
        {
            string errorFilePath = "";
            errorFilePath = ConfigurationManager.AppSettings["ErrorLogFilePath"]; /* located in the web.config of web app*/

            //errorFilePath = HttpContext.Current.Server.MapPath(errorFilePath);
            return errorFilePath;
        }

        public static bool IsValidMSISDN(string msisdn)
        {
            bool result = false;
            string validMSISDNRegx = "";

            validMSISDNRegx = ConfigurationManager.AppSettings["ValidMSISDNRegx"]; /* located in the web.config of web app*/
            Regex reg = new Regex(validMSISDNRegx, RegexOptions.IgnoreCase);
            result = reg.IsMatch(msisdn);

            return result;
        }

        public static bool IsValidBlMSISDN(string msisdn)
        {
            bool result = false;
            string validBlMSISDNRegx = "";

            validBlMSISDNRegx = ConfigurationManager.AppSettings["ValidBlMSISDNRegx"]; /* located in the web.config of web app*/
            Regex reg = new Regex(validBlMSISDNRegx, RegexOptions.IgnoreCase);
            result = reg.IsMatch(msisdn);

            return result;
        }

        public static void SaveErrorLog(string pageName, string methodName, Exception ex)
        {
            try
            {
                string exceptionMsg = ex.Message;
                string stackTrace = ex.StackTrace;
                //string strFilePath = GetErrorLogFilePath();// HttpContext.Current.Server.MapPath("~/ErrorLog/");
                string strFilePath = HttpContext.Current.Server.MapPath(GetErrorLogFilePath());
                string fileName = "error " + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
                FileStream file;
                StreamWriter sw;
                if (!File.Exists(strFilePath + fileName))
                {
                    if (!Directory.Exists(strFilePath))
                    {
                        Directory.CreateDirectory(strFilePath);
                    }
                    try
                    {
                        file = new FileStream(strFilePath + fileName, FileMode.CreateNew, FileAccess.Write, FileShare.Read);
                        sw = new StreamWriter(file);

                        sw.WriteLine("MSISDN\t  Date \t     Time    \t     \tPage       \t\t             Error");
                        sw.WriteLine("=====================================================================================================");
                        sw.Close();
                        file.Close();
                    }
                    catch (Exception e)
                    {
                    }
                }

                try
                {
                    file = new FileStream(strFilePath + fileName, FileMode.Append, FileAccess.Write, FileShare.Read);
                    sw = new StreamWriter(file);

                    string strMsg = MSISDM + "\t " + DateTime.Now.ToString("dd/MM/yyyy  hh:mm:ss tt") + "\t" + "\t" + pageName + "\t " + methodName + "\t" + exceptionMsg + Environment.NewLine + stackTrace;
                    sw.WriteLine(strMsg);
                    sw.WriteLine(Environment.NewLine);
                    sw.Close();
                    file.Close();
                }
                catch (Exception e) { }
            }
            catch (Exception e)
            {
            }
        }

        public static string MakeSQL(string sql, params object[] parameter)
        {
            int i = 0;
            int argIndex = 0;
            string newSQL = string.Empty;
            DateTime date = DateTime.MinValue;
            char paramiterChar = char.MinValue;

            try
            {
                i = sql.IndexOf('$');

                while (i != -1)
                {
                    newSQL += sql.Substring(0, i);
                    paramiterChar = Convert.ToChar(sql.Substring(i + 1, 1));

                    if (parameter[argIndex] == null || parameter[argIndex] == DBNull.Value)
                    {
                        newSQL += "null";
                    }
                    else
                    {
                        switch (paramiterChar)
                        {
                            case 'b':
                                newSQL += Convert.ToBoolean(parameter[argIndex]) ? "1" : "0";
                                break;
                            case 'D':
                                if (parameter[argIndex].ToString() == "null")
                                    newSQL += "null";
                                else
                                {
                                    date = Convert.ToDateTime(parameter[argIndex]);
                                    newSQL += "'" + date.ToString("dd-MMM-yyyy hh:mm:ss tt") + "'";
                                }
                                break;
                            case 'd':
                                if (parameter[argIndex].ToString() == "null")
                                    newSQL += "null";
                                else
                                {
                                    date = Convert.ToDateTime(parameter[argIndex]);
                                    newSQL += "'" + date.ToString("dd-MMM-yyyy") + "'";
                                }
                                break;
                            case 'n':
                                newSQL += parameter[argIndex].ToString();
                                break;
                            case 'q':
                                newSQL += parameter[argIndex].ToString();
                                break;
                            case 's':
                                newSQL += "'" + parameter[argIndex].ToString().Replace("'", "''") + "'";
                                break;
                        }
                    }

                    argIndex++;
                    sql = sql.Substring(i + 2);
                    i = sql.IndexOf('$');
                }

                newSQL += sql;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return newSQL;
        }

        /// <summary>
        /// Encrypt a string.
        /// </summary>
        /// <param name="originalString">The original string.</param>
        /// <returns>The encrypted string.</returns>
        /// <exception cref="ArgumentNullException">This exception will be 
        /// thrown when the original string is null or empty.</exception>
        public static string Encrypt(string originalString, string keys, bool convertToNumber)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(keys));
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;
            byte[] DataToEncrypt = UTF8.GetBytes(originalString);
            try
            {
                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            }
            finally
            {
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }
            string encryptedString = Convert.ToBase64String(Results);

            if (convertToNumber)
            {
                StringBuilder str = new StringBuilder();
                char[] charArray = encryptedString.ToCharArray();
                string s1;
                foreach (char ch in charArray)
                {
                    s1 = ((int)ch).ToString();
                    s1 = s1.PadLeft(3, '0');
                    str.Append(s1);
                }
                encryptedString = str.ToString();
            }

            return encryptedString;
        }

        /// <summary>
        /// Decrypt a crypted string.
        /// </summary>
        /// <param name="cryptedString">The crypted string.</param>
        /// <returns>The decrypted string.</returns>
        /// <exception cref="ArgumentNullException">This exception will be thrown 
        /// when the crypted string is null or empty.</exception>
        public static string Decrypt(string cryptedString, string keys)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(keys));
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;
            byte[] DataToDecrypt = Convert.FromBase64String(cryptedString);
            try
            {
                ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            finally
            {
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }
            string decreptedString = Convert.ToBase64String(Results);
            return decreptedString;
        }
    }
}
