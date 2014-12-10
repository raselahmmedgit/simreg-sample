using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIMREG.Helpers
{
    public static class JQGridHelper
    {
        public static string GenerateActionLink(string id, string controllerName, bool isView = true, bool isEdit = true, bool isDelete = true)
        {
            string strCheckBox = string.Empty;

            if (isView)
            {
                strCheckBox += "<a id='lnkDetails" + controllerName + "_" + id + "' class='lnkDetails" + controllerName + " jq-link' href='/" + controllerName + "/Details/" + id + "'>Details</a>";

            }

            if (isEdit)
            {

                strCheckBox += "<a id='lnkEdit" + controllerName + "_" + id + "' class='lnkEdit" + controllerName + " jq-link' href='/" + controllerName + "/Edit/" + id + "'>Edit</a>";
            }

            if (isDelete)
            {
                strCheckBox += "<a id='lnkDelete" + controllerName + "_" + id + "' class='lnkDelete" + controllerName + " jq-link' href='/" + controllerName + "/Delete/" + id + "'>Delete</a>";
            }

            return strCheckBox;
        }

    }
}