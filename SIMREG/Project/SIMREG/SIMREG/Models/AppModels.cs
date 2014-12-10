using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SIMREG.Models
{
    public class BaseViewModel
    {
        public bool HasUpdate { get; set; }

        public bool IsUpdate { get; set; }

        public bool HasDelete { get; set; }

        public bool IsDelete { get; set; }

        public string CrudType { get; set; }

        public string ActionLink { get; set; }
    }

    public class SIMREG_MSISDN : BaseViewModel
    {
        public int MSISDNID { get; set; }

        public string TITLE { get; set; }

        public DateTime IDATE { get; set; }

        public int IUSER { get; set; }

        public DateTime EDATE { get; set; }

        public int EUSER { get; set; }
    }

    public class SIMREG_REQUESTEDBY : BaseViewModel
    {
        public int REQUESTEDBYID { get; set; }

        public string TITLE { get; set; }

        public DateTime IDATE { get; set; }

        public int IUSER { get; set; }

        public DateTime EDATE { get; set; }

        public int EUSER { get; set; }
    }

    public class SIMREG_REQUESTEDTYPE : BaseViewModel
    {
        public int REQUESTEDTYPEID { get; set; }

        public string TITLE { get; set; }

        public DateTime IDATE { get; set; }

        public int IUSER { get; set; }

        public DateTime EDATE { get; set; }

        public int EUSER { get; set; }
    }

    public class SIMREG_DELIVEREDBY : BaseViewModel
    {
        public int DELIVEREDBYID { get; set; }

        public string TITLE { get; set; }

        public DateTime IDATE { get; set; }

        public int IUSER { get; set; }

        public DateTime EDATE { get; set; }

        public int EUSER { get; set; }
    }

    public class SIMREG_NEWFORM : BaseViewModel
    {
        public int ID { get; set; }

        public int MSISDNID { get; set; }

        public DateTime REQUESTEDDATE { get; set; }

        public int REQUESTEDBYID { get; set; }

        public int REQUESTEDTYPEID { get; set; }

        public DateTime DELIVEREDBYDATE { get; set; }

        public int DELIVEREDBYID { get; set; }

        public DateTime IDATE { get; set; }

        public int IUSER { get; set; }

        public DateTime EDATE { get; set; }

        public int EUSER { get; set; }
    }
}