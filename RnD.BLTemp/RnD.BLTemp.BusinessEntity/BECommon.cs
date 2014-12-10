using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RnD.BLTemp.BusinessEntity
{
    public class BECommon
    {
        public static string GetAgentPhoneNumber(string str)
        {
            string phoneNumber = string.Empty;
            string[] temp = str.Split(new char[] { '|' });

            if (temp.Length > 1)
                phoneNumber = temp[0];

            return phoneNumber.Trim();
        }

        public static string GetAgentEmailAddress(string str)
        {
            string emailAddress = string.Empty;
            string[] temp = str.Split(new char[] { '|' });

            if (temp.Length > 1)
                emailAddress = temp[1];
            else if (temp.Length == 1)
                emailAddress = temp[0];

            return emailAddress.Trim();
        }
    }
}
