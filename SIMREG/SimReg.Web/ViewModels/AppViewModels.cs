using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimReg.Web.ViewModels
{
    public class BaseViewModel
    {
        public bool HasUpdate { get; set; }

        public bool IsUpdate { get; set; }

        public bool HasDelete { get; set; }

        public bool IsDelete { get; set; }

        public string CrudType { get; set; }

        public DateTime IDATE { get; set; }

        public int IUSER { get; set; }

        public DateTime EDATE { get; set; }

        public int EUSER { get; set; }

        public string ActionLink { get; set; }
    }

    public class SIMREG_MSISDNViewModel : BaseViewModel
    {
        [Required]
        public int MSISDNID { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string TITLE { get; set; }

    }

    public class SIMREG_REQUESTEDBYViewModel : BaseViewModel
    {
        [Required]
        public int REQUESTEDBYID { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string TITLE { get; set; }

    }

    public class SIMREG_REQUESTEDTYPEViewModel : BaseViewModel
    {
        [Required]
        public int REQUESTEDTYPEID { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string TITLE { get; set; }

    }

    public class SIMREG_DELIVEREDBYViewModel : BaseViewModel
    {
        [Required]
        public int DELIVEREDBYID { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string TITLE { get; set; }

        [Required]
        [Display(Name = "Login Name")]
        public string USERNAME { get; set; }

        public string CANEDIT { get; set; }

    }

    public class SIMREG_NEWFORMViewModel : BaseViewModel
    {
        public int ID { get; set; }

        //[Range(1, long.MaxValue, ErrorMessage = "Please Select One.")]
        [Display(Name = "MSISDN")]
        public int MSISDNID { get; set; }
        [Display(Name = "MSISDN")]
        [RegularExpression(@"^[0-9]{0,15}$", ErrorMessage = "MSISDN should contain only numbers")]
        [StringLength(11, ErrorMessage = "MSISDN should be less than 11")]
        public string MSISDNTITLE { get; set; }

        [Display(Name = "Requested On")]
        public DateTime? REQUESTEDDATE { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = "Please Select One.")]
        [Display(Name = "Requested From")]
        public int REQUESTEDBYID { get; set; }
        public string REQUESTEDBYTITLE { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = "Please Select One.")]
        [Display(Name = "Requested Item")]
        public int REQUESTEDTYPEID { get; set; }
        public string REQUESTEDTYPETITLE { get; set; }

        [Display(Name = "Delivered On")]
        public DateTime? DELIVEREDBYDATE { get; set; }

        [Range(1, long.MaxValue, ErrorMessage = "Please Select One.")]
        [Display(Name = "Delivered By")]
        public int DELIVEREDBYID { get; set; }
        public string DELIVEREDBYTITLE { get; set; }

        public string IUSERNAME { get; set; }

        public string EUSERNAME { get; set; }

        public IEnumerable<SelectListItem> ddlMSISDNS { get; set; }
        public IEnumerable<SelectListItem> ddlREQUESTEDBYS { get; set; }
        public IEnumerable<SelectListItem> ddlREQUESTEDTYPES { get; set; }
        public IEnumerable<SelectListItem> ddlDELIVEREDBYS { get; set; }
    }

    public class SIMREG_NEWFORMSearchViewModel : BaseViewModel
    {
        public int ID { get; set; }

        //[Range(1, long.MaxValue, ErrorMessage = "Please Select One.")]
        [Display(Name = "MSISDN")]
        public int MSISDNID { get; set; }
        [Display(Name = "MSISDN")]
        public string MSISDNTITLE { get; set; }

        [Display(Name = "Requested On")]
        public DateTime? REQUESTEDDATE { get; set; }

        public DateTime? REQUESTEDDATEFrom { get; set; }
        public DateTime? REQUESTEDDATETo { get; set; }

        //[Range(1, long.MaxValue, ErrorMessage = "Please Select One.")]
        [Display(Name = "Requested From")]
        public int REQUESTEDBYID { get; set; }
        public string REQUESTEDBYTITLE { get; set; }

        //[Range(1, long.MaxValue, ErrorMessage = "Please Select One.")]
        [Display(Name = "Requested Item")]
        public int REQUESTEDTYPEID { get; set; }
        public string REQUESTEDTYPETITLE { get; set; }

        [Display(Name = "Delivered On")]
        public DateTime? DELIVEREDBYDATE { get; set; }

        public DateTime? DELIVEREDBYDATEFrom { get; set; }
        public DateTime? DELIVEREDBYDATETo { get; set; }

        //[Range(1, long.MaxValue, ErrorMessage = "Please Select One.")]
        [Display(Name = "Delivered By")]
        public int DELIVEREDBYID { get; set; }
        public string DELIVEREDBYTITLE { get; set; }

        public string IUSERNAME { get; set; }

        public string EUSERNAME { get; set; }

        public IEnumerable<SelectListItem> ddlMSISDNS { get; set; }
        public IEnumerable<SelectListItem> ddlREQUESTEDBYS { get; set; }
        public IEnumerable<SelectListItem> ddlREQUESTEDTYPES { get; set; }
        public IEnumerable<SelectListItem> ddlDELIVEREDBYS { get; set; }
    }
}