using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SIMREG.ViewModels
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

    public class SIMREG_MSISDNViewModel : BaseViewModel
    {
        public int MSISDNID { get; set; }

        public string TITLE { get; set; }

        public DateTime IDATE { get; set; }

        public int IUSER { get; set; }

        public DateTime EDATE { get; set; }

        public int EUSER { get; set; }
    }

    public class SIMREG_REQUESTEDBYViewModel : BaseViewModel
    {
        public int REQUESTEDBYID { get; set; }

        public string TITLE { get; set; }

        public DateTime IDATE { get; set; }

        public int IUSER { get; set; }

        public DateTime EDATE { get; set; }

        public int EUSER { get; set; }
    }

    public class SIMREG_REQUESTEDTYPEViewModel : BaseViewModel
    {
        public int REQUESTEDTYPEID { get; set; }

        public string TITLE { get; set; }

        public DateTime IDATE { get; set; }

        public int IUSER { get; set; }

        public DateTime EDATE { get; set; }

        public int EUSER { get; set; }
    }

    public class SIMREG_DELIVEREDBYViewModel : BaseViewModel
    {
        public int MSISDNID { get; set; }

        public string TITLE { get; set; }

        public DateTime IDATE { get; set; }

        public int IUSER { get; set; }

        public DateTime EDATE { get; set; }

        public int EUSER { get; set; }
    }

    public class SIMREG_NEWFORMViewModel : BaseViewModel
    {
        public int ID { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = "Please Select One.")]
        [Display(Name = "MSISDN")]
        public int MSISDNID { get; set; }
        public string MSISDNTITLE { get; set; }

        public DateTime REQUESTEDDATE { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = "Please Select One.")]
        [Display(Name = "REQUESTED BY")]
        public int REQUESTEDBYID { get; set; }
        public string REQUESTEDBYTITLE { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = "Please Select One.")]
        [Display(Name = "REQUESTED TYPE")]
        public int REQUESTEDTYPEID { get; set; }
        public string REQUESTEDTYPETITLE { get; set; }

        public DateTime DELIVEREDBYDATE { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = "Please Select One.")]
        [Display(Name = "DELIVERED BY")]
        public int DELIVEREDBYID { get; set; }
        public string DELIVEREDBYTITLE { get; set; }

        public DateTime IDATE { get; set; }

        public int IUSER { get; set; }
        public string IUSERNAME { get; set; }

        public DateTime EDATE { get; set; }

        public int EUSER { get; set; }
        public string EUSERNAME { get; set; }

        public IEnumerable<SelectListItem> ddlMSISDNS { get; set; }
        public IEnumerable<SelectListItem> ddlREQUESTEDBYS { get; set; }
        public IEnumerable<SelectListItem> ddlREQUESTEDTYPES { get; set; }
        public IEnumerable<SelectListItem> ddlDELIVEREDBYS { get; set; }
    }
}