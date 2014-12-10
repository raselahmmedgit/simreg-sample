using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIMREG.ViewModels
{
    public class BaseGridViewModel
    {
        public string HasUpdate { get; set; }

        public string IsUpdate { get; set; }

        public string HasDelete { get; set; }

        public string IsDelete { get; set; }

        public string CrudType { get; set; }

        public string ActionLink { get; set; }
    }

    public class SIMREG_MSISDNGridViewModel : BaseGridViewModel
    {
        public string MSISDNID { get; set; }

        public string TITLE { get; set; }

        public string IDATE { get; set; }

        public string IUSER { get; set; }

        public string EDATE { get; set; }

        public string EUSER { get; set; }
    }

    public class SIMREG_REQUESTEDBYGridViewModel : BaseGridViewModel
    {
        public string REQUESTEDBYID { get; set; }

        public string TITLE { get; set; }

        public string IDATE { get; set; }

        public string IUSER { get; set; }

        public string EDATE { get; set; }

        public string EUSER { get; set; }
    }

    public class SIMREG_REQUESTEDTYPEGridViewModel : BaseGridViewModel
    {
        public string REQUESTEDTYPEID { get; set; }

        public string TITLE { get; set; }

        public string IDATE { get; set; }

        public string IUSER { get; set; }

        public string EDATE { get; set; }

        public string EUSER { get; set; }
    }

    public class SIMREG_DELIVEREDBYGridViewModel : BaseGridViewModel
    {
        public string MSISDNID { get; set; }

        public string TITLE { get; set; }

        public string IDATE { get; set; }

        public string IUSER { get; set; }

        public string EDATE { get; set; }

        public string EUSER { get; set; }
    }

    public class SIMREG_NEWFORMGridViewModel : BaseGridViewModel
    {
        public string ID { get; set; }

        public string MSISDNID { get; set; }
        public string MSISDNTITLE { get; set; }

        public string REQUESTEDDATE { get; set; }

        public string REQUESTEDBYID { get; set; }
        public string REQUESTEDBYTITLE { get; set; }

        public string REQUESTEDTYPEID { get; set; }
        public string REQUESTEDTYPETITLE { get; set; }

        public string DELIVEREDBYDATE { get; set; }

        public string DELIVEREDBYID { get; set; }
        public string DELIVEREDBYTITLE { get; set; }

        public string IDATE { get; set; }

        public string IUSER { get; set; }
        public string IUSERNAME { get; set; }

        public string EDATE { get; set; }

        public string EUSER { get; set; }
        public string EUSERNAME { get; set; }
    }
}